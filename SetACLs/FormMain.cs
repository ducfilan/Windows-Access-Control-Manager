using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using SetACLs.Business;
using SetACLs.Model;

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

        private void btnBrowseFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() != DialogResult.OK) return;

            txtFolderPath.Text = Properties.Settings.Default.FolderPath = folderBrowserDialog.SelectedPath;
            Properties.Settings.Default.Save();
            PopulateFolderTree(trvFolderTree, txtFolderPath);
        }

        private void PopulateFolderTree(TreeView treeView, Control folderPathTextBox)
        {
            if (string.IsNullOrEmpty(folderPathTextBox.Text)) return;

            treeView.Nodes.Clear();
            var rootDirectoryInfo = new DirectoryInfo(folderPathTextBox.Text);
            trvFolderTree.Nodes.AddRange(CreateDirectoryNode(rootDirectoryInfo).Nodes.Cast<TreeNode>().ToArray());
            trvFolderTree.ExpandAll();
        }

        private static TreeNode CreateDirectoryNode(DirectoryInfo directoryInfo)
        {
            var directoryNode = new TreeNode(directoryInfo.Name);
            foreach (var directory in directoryInfo.GetDirectories())
                directoryNode.Nodes.Add(CreateDirectoryNode(directory));

            foreach (var file in directoryInfo.GetFiles())
                directoryNode.Nodes.Add(new TreeNode(file.Name));
            return directoryNode;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            txtFolderPath.Text   = Properties.Settings.Default.FolderPath;
            txtDomain.Text       = Properties.Settings.Default.Domain;
            txtTemplatePath.Text = Properties.Settings.Default.TemplatePath;

            _toolBusiness = new ToolBusiness
            {
                TemplatePath = txtTemplatePath.Text
            };

            _formManipulator = new FormManipulator();

            PopulateFolderTree(trvFolderTree, txtFolderPath);
        }

        private void btnRefreshFolder_Click(object sender, EventArgs e)
        {
            PopulateFolderTree(trvFolderTree, txtFolderPath);
        }

        private void btnExportPermission_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                _toolBusiness.ExportPermission(txtFolderPath.Text, 
                    saveFileDialog.FileName, 
                    txtDomain.Text);
            }
        }

        private void txtDomain_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Domain = txtDomain.Text;
            Properties.Settings.Default.Save();
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
			var permissions = _toolBusiness.GetPermissionsCurrentFolder(txtFolderPath.Text + @"\" + e.Node.FullPath, txtDomain.Text);

			var list = new BindingList<UserPermission>(permissions.Select(p => new UserPermission
			{
				Username = p.IdentityReference.Value,
				AccessType = p.AccessControlType.ToString(),
				Permission = p.FileSystemRights.ToString()
			}).ToList());
			dgvCurrentPermission.DataSource = list;
		}

		private void trvImportedDirectory_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var list = new BindingList<UserPermission>(ImportedFolderPermissions
                .First(ifp => ifp.NodeKey.Equals(e.Node.Name))
                .UserPermission
                .Select(p => new UserPermission
                {
                    Username = p.Username,
                    Permission = p.Permission
                }).ToList());
            dgvImportedPermission.DataSource = list;
        }

		private void BtnCreateFolderTree_Click(object sender, EventArgs e)
		{
			if (_formManipulator.ShowWarning("You're gonna create a folder tree based on the imported folder structure. Are you sure?") == 
                DialogResult.No) return;

			CreateFolder(txtFolderPath.Text, trvImportedDirectory.Nodes);

            PopulateFolderTree(trvFolderTree, txtFolderPath);

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
				_toolBusiness.SetPermission(txtFolderPath.Text, txtDomain.Text, ImportedRootNodeChildren, ImportedFolderPermissions);

				_formManipulator.ShowInformation("Permissions are successfully set!");
			}
			catch(Exception ex)
            {
                _formManipulator.ShowError(ex.Message);
;			}
		}

		private void BtnHelp_Click(object sender, EventArgs e)
		{
			_formManipulator.ShowInformation("Access rights manipulator by Duc Filan!");
		}
	}
}