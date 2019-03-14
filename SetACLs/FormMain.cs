using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Windows.Forms;
using SetACLs.Business;
using SetACLs.Model;
using System.Threading.Tasks;

namespace SetACLs
{
    public partial class FormMain : Form
    {
        private ToolBusiness _toolBusiness;
        private FormManipulator _formManipulator;

        public TreeNodeCollection ImportedRootNodeChildren { get; set; }
        public List<FolderPermission> ImportedFolderPermissions { get; set; }

        public FormMain()
        {
            InitializeComponent();
        }

        private async void btnBrowseFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() != DialogResult.OK) return;

            txtFolderPath.Text = Properties.Settings.Default.FolderPath = folderBrowserDialog.SelectedPath;
            Properties.Settings.Default.Save();
            await Task.Run(() => PopulateFolderTreeAsync(trvFolderTree, txtFolderPath.Text));
        }

        private async Task PopulateFolderTreeAsync(TreeView treeView, string folderPath)
        {
            if (string.IsNullOrEmpty(folderPath)) return;

            progressBar.BeginInvoke((MethodInvoker) delegate
			{
				progressBar.Style = ProgressBarStyle.Marquee;
				progressBar.MarqueeAnimationSpeed = 30;
			});

			if (!Directory.Exists(folderPath))
            {
                _formManipulator.ShowError("Folder is not exists! Browse a new folder!");
                return;
            }

            var rootDirectoryInfo = new DirectoryInfo(folderPath);
            var nodes = await Task.Run(() => CreateDirectoryNode(rootDirectoryInfo));

            treeView.BeginInvoke((MethodInvoker) delegate
			{
				treeView.Nodes.Clear();
				treeView.Nodes.AddRange(nodes.Nodes.Cast<TreeNode>().ToArray());
				treeView.ExpandAll();
			});

            progressBar.BeginInvoke((MethodInvoker)delegate
            {
	            progressBar.Style = ProgressBarStyle.Blocks;
            });
		}

        private static async Task<TreeNode> CreateDirectoryNode(DirectoryInfo directoryInfo)
        {
            var directoryNode = new TreeNode(directoryInfo.Name);

            try
            {
                foreach (var directory in directoryInfo.GetDirectories()
                    .Where(d => !d.Attributes.HasFlag(FileAttributes.Hidden)))
                    directoryNode.Nodes.Add(await Task.Run(() => CreateDirectoryNode(directory)));

                foreach (var file in directoryInfo.GetFiles())
                    directoryNode.Nodes.Add(new TreeNode(file.Name));
            }
            catch (UnauthorizedAccessException)
            {
                // Ignore.
            }

            return directoryNode;
        }

        private async void FormMain_Load(object sender, EventArgs e)
        {

            if (!StartAsAdminManipulator.IsAdmin())
            {
                StartAsAdminManipulator.RestartElevated();
            }

            txtFolderPath.Text       = Properties.Settings.Default.FolderPath;
            txtDomain.Text           = Properties.Settings.Default.Domain;
            txtTemplatePath.Text     = Properties.Settings.Default.TemplatePath;
            chkOnlySubFolder.Checked = Properties.Settings.Default.IsSubFolderOnly;

            _toolBusiness = new ToolBusiness
            {
                TemplatePath = txtTemplatePath.Text
            };

            _formManipulator = new FormManipulator();

            var ipAddresses = NetworkInfoExtractor.GetLocalIpAddress();
            PopulateComboBox(cbIpAddresses, ipAddresses, Properties.Settings.Default.IpAddress);

            await Task.Run(() => PopulateFolderTreeAsync(trvFolderTree, txtFolderPath.Text));
		}

        private void PopulateComboBox(ComboBox comboBox, IEnumerable<string> items, string selectedItemText = null)
        {
            comboBox.Items.AddRange(items.ToArray<object>());
            comboBox.SelectedText = selectedItemText;
        }

        private async void btnRefreshFolder_Click(object sender, EventArgs e)
        {
            await Task.Run(() => PopulateFolderTreeAsync(trvFolderTree, txtFolderPath.Text));
		}

        private async void btnExportPermission_Click(object sender, EventArgs e)
        {
	        if (saveFileDialog.ShowDialog() != DialogResult.OK) return;

            progressBar.Value = 0;
            var progress = new Progress<int>(v =>
            {
                progressBar.Value = v;
            });

            var exportIpAddress = cbIpAddresses.Text;
            try
            {
                await Task.Run(() => _toolBusiness.ExportPermission(
                    DirectoryInfoExtractor.GetBaseFolderPath(txtFolderPath.Text),
                    saveFileDialog.FileName,
                    txtDomain.Text,
                    exportIpAddress,
                    progress));

                Process.Start(saveFileDialog.FileName);
            }
            catch (Win32Exception)
            {
                _formManipulator.ShowError("Tried to open the exported file but Excel is not installed!");
            }
            catch (InvalidOperationException)
            {
                _formManipulator.ShowError("Tried to save the exported file but the file is being opened by another process!");
            }
            catch (Exception exception)
            {
                _formManipulator.ShowError(exception.Message);
            }
        }

        private async void btnExportToTemplate_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;

            progressBar.Value = 0;
            var progress = new Progress<int>(v =>
            {
                progressBar.Value = v;
            });

            var exportIpAddress = cbIpAddresses.Text;
            try
            {
                await Task.Run(() => _toolBusiness.ExportPermissionByTemplate(
                    DirectoryInfoExtractor.GetBaseFolderPath(txtFolderPath.Text),
                    saveFileDialog.FileName,
                    txtDomain.Text,
                    exportIpAddress,
                    progress));

                Process.Start(saveFileDialog.FileName);
            }
            catch (Win32Exception)
            {
                _formManipulator.ShowError("Tried to open the exported file but Excel is not installed!");
            }
            catch (InvalidOperationException)
            {
                _formManipulator.ShowError("Tried to save the exported file but the file is being opened by another process!");
            }
            catch (Exception exception)
            {
                _formManipulator.ShowError(exception.Message);
            }
        }

        private void btnImportTemplate_Click(object sender, EventArgs e)
        {
	        var templateTuple = _toolBusiness.ImportTemplate();
            ImportedRootNodeChildren = templateTuple.Item1;
            ImportedFolderPermissions = templateTuple.Item2;

            trvImportedDirectory.Nodes.Clear();
	        trvImportedDirectory.Nodes.AddRange(ImportedRootNodeChildren
		        .Cast<TreeNode>()
		        .Select(node => node.Clone() as TreeNode)
		        .ToArray());
            trvImportedDirectory.ExpandAll();
        }

        private void btnBrowseTemplate_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() != DialogResult.OK) return;

            txtTemplatePath.Text = Properties.Settings.Default.TemplatePath = openFileDialog.FileName;
            _toolBusiness.TemplatePath = openFileDialog.FileName;

            Properties.Settings.Default.Save();
		}

		private void trvFolderTree_AfterSelect(object sender, TreeViewEventArgs e)
		{
			var permissions = PermissionManipulator
			                      .GetPermissionsCurrentFolder(
                                      DirectoryInfoExtractor.GetBaseFolderPath(txtFolderPath.Text, !chkOnlySubFolder.Checked) + @"\" + e.Node.FullPath, 
                                      txtDomain.Text) 
			                  ?? new List<FileSystemAccessRule>();

			var list = new BindingList<ExportInfo>(permissions.Select(_toolBusiness.ToExportInfo).ToList());
			dgvCurrentPermission.DataSource = list;
		}

		private void trvImportedDirectory_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var list = new BindingList<ExportInfo>(ImportedFolderPermissions
                .First(ifp => ifp.NodeKey.Equals(e.Node.Name))
                .UserPermission
                .Select(p => new ExportInfo
                {
                    Account = p.Username,
                    Rights = p.Permission
                }).ToList());
            dgvImportedPermission.DataSource = list;
        }

		private async void BtnCreateFolderTree_Click(object sender, EventArgs e)
		{
			if (_formManipulator.ShowWarning("You're gonna create a folder tree based on the imported folder structure. Are you sure?") == 
                DialogResult.No) return;

            CreateFolder(DirectoryInfoExtractor.GetBaseFolderPath(txtFolderPath.Text, chkOnlySubFolder.Checked), trvImportedDirectory.Nodes);

			await Task.Run(() => PopulateFolderTreeAsync(trvFolderTree, txtFolderPath.Text));

            _formManipulator.ShowMessage("Folders have been created successfully!");
		}

		private void CreateFolder(string basePath, TreeNodeCollection nodes)
		{
			foreach (TreeNode node in nodes)
			{
				Directory.CreateDirectory(basePath + @"\" + node.Text);
				CreateFolder(basePath + @"\" + node.Text, node.Nodes);
			}
		}

		private void BtnAssignPermission_Click(object sender, EventArgs e)
		{
			if (_formManipulator.ShowWarning("You're gonna assign all permissions based on the imported template. Are you sure?") == 
                DialogResult.No) return;

			if (ImportedRootNodeChildren == null)
			{
				_formManipulator.ShowMessage("Please import template first!");
				return;
            }
            
            try
			{
				_toolBusiness.ApplyPermissionFromImportedTemplate(
                    DirectoryInfoExtractor.GetBaseFolderPath(txtFolderPath.Text), 
                    txtDomain.Text, 
                    ImportedRootNodeChildren, 
                    ImportedFolderPermissions);

				_formManipulator.ShowInformation("Permissions are successfully set!");
			}
			catch(Exception ex)
            {
                _formManipulator.ShowError(ex.Message);
			}
		}

		private void BtnHelp_Click(object sender, EventArgs e)
		{
			_formManipulator.ShowInformation("Access rights manipulator by Duc Filan!");
		}

        private void btnSetDomain_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Domain = txtDomain.Text;
            Properties.Settings.Default.Save();
        }

        private void cbIpAddresses_SelectedValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.IpAddress = cbIpAddresses.SelectedItem.ToString();
            Properties.Settings.Default.Save();
        }

        private void btnSaveCurrentPermission_Click(object sender, EventArgs e)
        {
            if (_formManipulator.ShowWarning("You're gonna assign all permissions based on the edited values. Are you sure?") ==
                DialogResult.No) return;

            var editedDataSource = dgvCurrentPermission.DataSource as BindingList<ExportInfo>;
            if (editedDataSource == null) return;

            var permissions = new FolderPermission
            {
                NodeKey = string.Empty, // Not important here.
                UserPermission = editedDataSource.Select(ei => new UserPermission
                {
                    Permission = ei.Rights,
                    Username = ei.Account
                }).ToList()
            };

            try
            {
                _toolBusiness.SetIndividualPermission(
                    txtFolderPath.Text + @"\" + trvFolderTree.SelectedNode.FullPath,
                    txtDomain.Text, 
                    permissions);

                _formManipulator.ShowInformation("Permissions are successfully set!");
            }
            catch (Exception exception)
            {
                _formManipulator.ShowError(exception.Message);
            }
        }

        private void chkOnlySubFolder_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.IsSubFolderOnly = ((CheckBox) sender).Checked;
            Properties.Settings.Default.Save();
        }
    }
}
