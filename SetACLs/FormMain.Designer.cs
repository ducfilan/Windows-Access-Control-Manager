using System;

namespace SetACLs
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnCopyBrowseDestFolder = new System.Windows.Forms.Button();
            this.btnCopyBrowseSourceFolder = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtCopyProcessingFileSize = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCopyProcessingFileName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCopyProcessingOperation = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCopyPerformCopying = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCopyDestinationFolderPath = new System.Windows.Forms.TextBox();
            this.txtCopySourceFolderPath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chkOnlySubFolder = new System.Windows.Forms.CheckBox();
            this.btnExportToTemplate = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.cbIpAddresses = new System.Windows.Forms.ComboBox();
            this.btnSetDomain = new System.Windows.Forms.Button();
            this.btnExportPermission = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnAssignPermission = new System.Windows.Forms.Button();
            this.btnCreateFolderTree = new System.Windows.Forms.Button();
            this.btnBrowseTemplate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTemplatePath = new System.Windows.Forms.TextBox();
            this.txtDomain = new System.Windows.Forms.TextBox();
            this.txtFolderPath = new System.Windows.Forms.TextBox();
            this.btnImportTemplate = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgvImportedPermission = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvCurrentPermission = new System.Windows.Forms.DataGridView();
            this.btnSaveCurrentPermission = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.trvImportedDirectory = new System.Windows.Forms.TreeView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.trvFolderTree = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRefreshFolder = new System.Windows.Forms.Button();
            this.btnBrowseFolder = new System.Windows.Forms.Button();
            this.Folder = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImportedPermission)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrentPermission)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.FileName = "Permission";
            this.saveFileDialog.Filter = "Excel files(*.xlsx)|*.xlsx|Excel files 97-2003(*.xls)|*.xls|All files (*.*)|*.*";
            this.saveFileDialog.Title = "Save exported permissions file";
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Excel files(*.xlsx)|*.xlsx|Excel files 97-2003(*.xls)|*.xls|All files (*.*)|*.*";
            this.openFileDialog.Title = "Import permissions file";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnCopyBrowseDestFolder);
            this.tabPage2.Controls.Add(this.btnCopyBrowseSourceFolder);
            this.tabPage2.Controls.Add(this.groupBox5);
            this.tabPage2.Controls.Add(this.btnCopyPerformCopying);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.txtCopyDestinationFolderPath);
            this.tabPage2.Controls.Add(this.txtCopySourceFolderPath);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1179, 396);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Folder Copying";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnCopyBrowseDestFolder
            // 
            this.btnCopyBrowseDestFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopyBrowseDestFolder.Location = new System.Drawing.Point(957, 33);
            this.btnCopyBrowseDestFolder.Name = "btnCopyBrowseDestFolder";
            this.btnCopyBrowseDestFolder.Size = new System.Drawing.Size(75, 23);
            this.btnCopyBrowseDestFolder.TabIndex = 45;
            this.btnCopyBrowseDestFolder.Text = "Browse";
            this.btnCopyBrowseDestFolder.UseVisualStyleBackColor = true;
            this.btnCopyBrowseDestFolder.Click += new System.EventHandler(this.btnCopyBrowseDestFolder_Click);
            // 
            // btnCopyBrowseSourceFolder
            // 
            this.btnCopyBrowseSourceFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopyBrowseSourceFolder.Location = new System.Drawing.Point(957, 6);
            this.btnCopyBrowseSourceFolder.Name = "btnCopyBrowseSourceFolder";
            this.btnCopyBrowseSourceFolder.Size = new System.Drawing.Size(75, 23);
            this.btnCopyBrowseSourceFolder.TabIndex = 44;
            this.btnCopyBrowseSourceFolder.Text = "Browse";
            this.btnCopyBrowseSourceFolder.UseVisualStyleBackColor = true;
            this.btnCopyBrowseSourceFolder.Click += new System.EventHandler(this.btnCopyBrowseSourceFolder_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.txtCopyProcessingFileSize);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.txtCopyProcessingFileName);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.txtCopyProcessingOperation);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Location = new System.Drawing.Point(8, 291);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1163, 97);
            this.groupBox5.TabIndex = 43;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Processing info";
            // 
            // txtCopyProcessingFileSize
            // 
            this.txtCopyProcessingFileSize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCopyProcessingFileSize.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCopyProcessingFileSize.Location = new System.Drawing.Point(102, 70);
            this.txtCopyProcessingFileSize.Name = "txtCopyProcessingFileSize";
            this.txtCopyProcessingFileSize.ReadOnly = true;
            this.txtCopyProcessingFileSize.Size = new System.Drawing.Size(1055, 12);
            this.txtCopyProcessingFileSize.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(46, 70);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 12);
            this.label8.TabIndex = 5;
            this.label8.Text = "File size:";
            // 
            // txtCopyProcessingFileName
            // 
            this.txtCopyProcessingFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCopyProcessingFileName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCopyProcessingFileName.Location = new System.Drawing.Point(102, 47);
            this.txtCopyProcessingFileName.Name = "txtCopyProcessingFileName";
            this.txtCopyProcessingFileName.ReadOnly = true;
            this.txtCopyProcessingFileName.Size = new System.Drawing.Size(1055, 12);
            this.txtCopyProcessingFileName.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 12);
            this.label7.TabIndex = 3;
            this.label7.Text = "Processing File: ";
            // 
            // txtCopyProcessingOperation
            // 
            this.txtCopyProcessingOperation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCopyProcessingOperation.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCopyProcessingOperation.Location = new System.Drawing.Point(102, 24);
            this.txtCopyProcessingOperation.Name = "txtCopyProcessingOperation";
            this.txtCopyProcessingOperation.ReadOnly = true;
            this.txtCopyProcessingOperation.Size = new System.Drawing.Size(1055, 12);
            this.txtCopyProcessingOperation.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 12);
            this.label6.TabIndex = 1;
            this.label6.Text = "Information:";
            // 
            // btnCopyPerformCopying
            // 
            this.btnCopyPerformCopying.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopyPerformCopying.BackColor = System.Drawing.Color.Red;
            this.btnCopyPerformCopying.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCopyPerformCopying.ForeColor = System.Drawing.Color.White;
            this.btnCopyPerformCopying.Location = new System.Drawing.Point(1038, 6);
            this.btnCopyPerformCopying.Name = "btnCopyPerformCopying";
            this.btnCopyPerformCopying.Size = new System.Drawing.Size(138, 50);
            this.btnCopyPerformCopying.TabIndex = 42;
            this.btnCopyPerformCopying.Text = "Perform copying";
            this.btnCopyPerformCopying.UseVisualStyleBackColor = false;
            this.btnCopyPerformCopying.Click += new System.EventHandler(this.btnCopyPerformCopying_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 12);
            this.label4.TabIndex = 41;
            this.label4.Text = "Destination";
            // 
            // txtCopyDestinationFolderPath
            // 
            this.txtCopyDestinationFolderPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCopyDestinationFolderPath.Location = new System.Drawing.Point(75, 35);
            this.txtCopyDestinationFolderPath.Name = "txtCopyDestinationFolderPath";
            this.txtCopyDestinationFolderPath.Size = new System.Drawing.Size(876, 19);
            this.txtCopyDestinationFolderPath.TabIndex = 40;
            // 
            // txtCopySourceFolderPath
            // 
            this.txtCopySourceFolderPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCopySourceFolderPath.Location = new System.Drawing.Point(75, 8);
            this.txtCopySourceFolderPath.Name = "txtCopySourceFolderPath";
            this.txtCopySourceFolderPath.Size = new System.Drawing.Size(876, 19);
            this.txtCopySourceFolderPath.TabIndex = 38;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 12);
            this.label5.TabIndex = 39;
            this.label5.Text = "Source";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chkOnlySubFolder);
            this.tabPage1.Controls.Add(this.btnExportToTemplate);
            this.tabPage1.Controls.Add(this.progressBar);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.cbIpAddresses);
            this.tabPage1.Controls.Add(this.btnSetDomain);
            this.tabPage1.Controls.Add(this.btnExportPermission);
            this.tabPage1.Controls.Add(this.btnHelp);
            this.tabPage1.Controls.Add(this.btnAssignPermission);
            this.tabPage1.Controls.Add(this.btnCreateFolderTree);
            this.tabPage1.Controls.Add(this.btnBrowseTemplate);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtTemplatePath);
            this.tabPage1.Controls.Add(this.txtDomain);
            this.tabPage1.Controls.Add(this.txtFolderPath);
            this.tabPage1.Controls.Add(this.btnImportTemplate);
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.btnRefreshFolder);
            this.tabPage1.Controls.Add(this.btnBrowseFolder);
            this.tabPage1.Controls.Add(this.Folder);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1179, 396);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Permission Assignment";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // chkOnlySubFolder
            // 
            this.chkOnlySubFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkOnlySubFolder.AutoSize = true;
            this.chkOnlySubFolder.Checked = true;
            this.chkOnlySubFolder.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOnlySubFolder.Location = new System.Drawing.Point(738, 354);
            this.chkOnlySubFolder.Name = "chkOnlySubFolder";
            this.chkOnlySubFolder.Size = new System.Drawing.Size(110, 16);
            this.chkOnlySubFolder.TabIndex = 47;
            this.chkOnlySubFolder.Text = "Only sub-folders";
            this.chkOnlySubFolder.UseVisualStyleBackColor = true;
            this.chkOnlySubFolder.CheckedChanged += new System.EventHandler(this.chkOnlySubFolder_CheckedChanged);
            // 
            // btnExportToTemplate
            // 
            this.btnExportToTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExportToTemplate.Font = new System.Drawing.Font("MS UI Gothic", 11.25F);
            this.btnExportToTemplate.Location = new System.Drawing.Point(226, 345);
            this.btnExportToTemplate.Name = "btnExportToTemplate";
            this.btnExportToTemplate.Size = new System.Drawing.Size(210, 35);
            this.btnExportToTemplate.TabIndex = 46;
            this.btnExportToTemplate.Text = "Export permission to template";
            this.btnExportToTemplate.UseVisualStyleBackColor = true;
            this.btnExportToTemplate.Click += new System.EventHandler(this.btnExportToTemplate_Click);
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar.Location = new System.Drawing.Point(3, 383);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(1173, 10);
            this.progressBar.Step = 1;
            this.progressBar.TabIndex = 45;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(895, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 12);
            this.label3.TabIndex = 44;
            this.label3.Text = "IP";
            // 
            // cbIpAddresses
            // 
            this.cbIpAddresses.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbIpAddresses.FormattingEnabled = true;
            this.cbIpAddresses.Location = new System.Drawing.Point(916, 31);
            this.cbIpAddresses.Name = "cbIpAddresses";
            this.cbIpAddresses.Size = new System.Drawing.Size(218, 20);
            this.cbIpAddresses.TabIndex = 43;
            this.cbIpAddresses.SelectedValueChanged += new System.EventHandler(this.cbIpAddresses_SelectedValueChanged);
            // 
            // btnSetDomain
            // 
            this.btnSetDomain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetDomain.Location = new System.Drawing.Point(1140, 4);
            this.btnSetDomain.Name = "btnSetDomain";
            this.btnSetDomain.Size = new System.Drawing.Size(32, 23);
            this.btnSetDomain.TabIndex = 42;
            this.btnSetDomain.Text = "Set";
            this.btnSetDomain.UseVisualStyleBackColor = true;
            this.btnSetDomain.Click += new System.EventHandler(this.btnSetDomain_Click);
            // 
            // btnExportPermission
            // 
            this.btnExportPermission.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExportPermission.Font = new System.Drawing.Font("MS UI Gothic", 11.25F);
            this.btnExportPermission.Location = new System.Drawing.Point(10, 345);
            this.btnExportPermission.Name = "btnExportPermission";
            this.btnExportPermission.Size = new System.Drawing.Size(210, 35);
            this.btnExportPermission.TabIndex = 34;
            this.btnExportPermission.Text = "Export permission with path";
            this.btnExportPermission.UseVisualStyleBackColor = true;
            this.btnExportPermission.Click += new System.EventHandler(this.btnExportPermission_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHelp.BackColor = System.Drawing.Color.Transparent;
            this.btnHelp.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonFace;
            this.btnHelp.FlatAppearance.BorderSize = 0;
            this.btnHelp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnHelp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.Location = new System.Drawing.Point(1146, 352);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(32, 21);
            this.btnHelp.TabIndex = 41;
            this.btnHelp.Text = "?";
            this.btnHelp.UseVisualStyleBackColor = false;
            this.btnHelp.Click += new System.EventHandler(this.BtnHelp_Click);
            // 
            // btnAssignPermission
            // 
            this.btnAssignPermission.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAssignPermission.BackColor = System.Drawing.Color.Red;
            this.btnAssignPermission.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnAssignPermission.ForeColor = System.Drawing.Color.White;
            this.btnAssignPermission.Location = new System.Drawing.Point(1000, 345);
            this.btnAssignPermission.Name = "btnAssignPermission";
            this.btnAssignPermission.Size = new System.Drawing.Size(140, 35);
            this.btnAssignPermission.TabIndex = 40;
            this.btnAssignPermission.Text = "Assign Permission";
            this.btnAssignPermission.UseVisualStyleBackColor = false;
            this.btnAssignPermission.Click += new System.EventHandler(this.BtnAssignPermission_Click);
            // 
            // btnCreateFolderTree
            // 
            this.btnCreateFolderTree.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateFolderTree.BackColor = System.Drawing.Color.Red;
            this.btnCreateFolderTree.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCreateFolderTree.ForeColor = System.Drawing.Color.White;
            this.btnCreateFolderTree.Location = new System.Drawing.Point(854, 345);
            this.btnCreateFolderTree.Name = "btnCreateFolderTree";
            this.btnCreateFolderTree.Size = new System.Drawing.Size(140, 35);
            this.btnCreateFolderTree.TabIndex = 39;
            this.btnCreateFolderTree.Text = "Create Folder Tree";
            this.btnCreateFolderTree.UseVisualStyleBackColor = false;
            this.btnCreateFolderTree.Click += new System.EventHandler(this.BtnCreateFolderTree_Click);
            // 
            // btnBrowseTemplate
            // 
            this.btnBrowseTemplate.Location = new System.Drawing.Point(529, 33);
            this.btnBrowseTemplate.Name = "btnBrowseTemplate";
            this.btnBrowseTemplate.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseTemplate.TabIndex = 38;
            this.btnBrowseTemplate.Text = "Browse";
            this.btnBrowseTemplate.UseVisualStyleBackColor = true;
            this.btnBrowseTemplate.Click += new System.EventHandler(this.btnBrowseTemplate_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 12);
            this.label2.TabIndex = 37;
            this.label2.Text = "Template";
            // 
            // txtTemplatePath
            // 
            this.txtTemplatePath.Location = new System.Drawing.Point(61, 35);
            this.txtTemplatePath.Name = "txtTemplatePath";
            this.txtTemplatePath.Size = new System.Drawing.Size(462, 19);
            this.txtTemplatePath.TabIndex = 36;
            // 
            // txtDomain
            // 
            this.txtDomain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDomain.Location = new System.Drawing.Point(916, 6);
            this.txtDomain.Name = "txtDomain";
            this.txtDomain.Size = new System.Drawing.Size(218, 19);
            this.txtDomain.TabIndex = 31;
            // 
            // txtFolderPath
            // 
            this.txtFolderPath.Location = new System.Drawing.Point(61, 6);
            this.txtFolderPath.Name = "txtFolderPath";
            this.txtFolderPath.Size = new System.Drawing.Size(462, 19);
            this.txtFolderPath.TabIndex = 27;
            // 
            // btnImportTemplate
            // 
            this.btnImportTemplate.Location = new System.Drawing.Point(610, 33);
            this.btnImportTemplate.Name = "btnImportTemplate";
            this.btnImportTemplate.Size = new System.Drawing.Size(119, 23);
            this.btnImportTemplate.TabIndex = 35;
            this.btnImportTemplate.Text = "Import template";
            this.btnImportTemplate.UseVisualStyleBackColor = true;
            this.btnImportTemplate.Click += new System.EventHandler(this.btnImportTemplate_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox4, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 62);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1168, 284);
            this.tableLayoutPanel1.TabIndex = 33;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgvImportedPermission);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(879, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(286, 278);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Imported Permission";
            // 
            // dgvImportedPermission
            // 
            this.dgvImportedPermission.AllowUserToAddRows = false;
            this.dgvImportedPermission.AllowUserToDeleteRows = false;
            this.dgvImportedPermission.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvImportedPermission.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvImportedPermission.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvImportedPermission.Location = new System.Drawing.Point(3, 15);
            this.dgvImportedPermission.Name = "dgvImportedPermission";
            this.dgvImportedPermission.ReadOnly = true;
            this.dgvImportedPermission.RowTemplate.Height = 21;
            this.dgvImportedPermission.Size = new System.Drawing.Size(280, 260);
            this.dgvImportedPermission.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.splitContainer1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(587, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(286, 278);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Current Permission";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(3, 15);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvCurrentPermission);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnSaveCurrentPermission);
            this.splitContainer1.Size = new System.Drawing.Size(280, 260);
            this.splitContainer1.SplitterDistance = 202;
            this.splitContainer1.TabIndex = 1;
            // 
            // dgvCurrentPermission
            // 
            this.dgvCurrentPermission.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCurrentPermission.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCurrentPermission.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCurrentPermission.Location = new System.Drawing.Point(0, 0);
            this.dgvCurrentPermission.Name = "dgvCurrentPermission";
            this.dgvCurrentPermission.RowTemplate.Height = 21;
            this.dgvCurrentPermission.Size = new System.Drawing.Size(280, 202);
            this.dgvCurrentPermission.TabIndex = 1;
            // 
            // btnSaveCurrentPermission
            // 
            this.btnSaveCurrentPermission.BackColor = System.Drawing.Color.Red;
            this.btnSaveCurrentPermission.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSaveCurrentPermission.Font = new System.Drawing.Font("MS UI Gothic", 11.25F);
            this.btnSaveCurrentPermission.ForeColor = System.Drawing.Color.White;
            this.btnSaveCurrentPermission.Location = new System.Drawing.Point(0, 0);
            this.btnSaveCurrentPermission.Name = "btnSaveCurrentPermission";
            this.btnSaveCurrentPermission.Size = new System.Drawing.Size(280, 54);
            this.btnSaveCurrentPermission.TabIndex = 0;
            this.btnSaveCurrentPermission.Text = "Save";
            this.btnSaveCurrentPermission.UseVisualStyleBackColor = false;
            this.btnSaveCurrentPermission.Click += new System.EventHandler(this.btnSaveCurrentPermission_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.trvImportedDirectory);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(295, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(286, 278);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Imported Directory tree";
            // 
            // trvImportedDirectory
            // 
            this.trvImportedDirectory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvImportedDirectory.Location = new System.Drawing.Point(3, 15);
            this.trvImportedDirectory.Name = "trvImportedDirectory";
            this.trvImportedDirectory.Size = new System.Drawing.Size(280, 260);
            this.trvImportedDirectory.TabIndex = 0;
            this.trvImportedDirectory.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvImportedDirectory_AfterSelect);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.trvFolderTree);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(286, 278);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Current Directory tree";
            // 
            // trvFolderTree
            // 
            this.trvFolderTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvFolderTree.Location = new System.Drawing.Point(3, 15);
            this.trvFolderTree.Name = "trvFolderTree";
            this.trvFolderTree.Size = new System.Drawing.Size(280, 260);
            this.trvFolderTree.TabIndex = 0;
            this.trvFolderTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvFolderTree_AfterSelect);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(867, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 12);
            this.label1.TabIndex = 32;
            this.label1.Text = "Domain";
            // 
            // btnRefreshFolder
            // 
            this.btnRefreshFolder.Location = new System.Drawing.Point(610, 4);
            this.btnRefreshFolder.Name = "btnRefreshFolder";
            this.btnRefreshFolder.Size = new System.Drawing.Size(119, 23);
            this.btnRefreshFolder.TabIndex = 30;
            this.btnRefreshFolder.Text = "Refresh";
            this.btnRefreshFolder.UseVisualStyleBackColor = true;
            this.btnRefreshFolder.Click += new System.EventHandler(this.btnRefreshFolder_Click);
            // 
            // btnBrowseFolder
            // 
            this.btnBrowseFolder.Location = new System.Drawing.Point(529, 4);
            this.btnBrowseFolder.Name = "btnBrowseFolder";
            this.btnBrowseFolder.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseFolder.TabIndex = 29;
            this.btnBrowseFolder.Text = "Browse";
            this.btnBrowseFolder.UseVisualStyleBackColor = true;
            this.btnBrowseFolder.Click += new System.EventHandler(this.btnBrowseFolder_Click);
            // 
            // Folder
            // 
            this.Folder.AutoSize = true;
            this.Folder.Location = new System.Drawing.Point(18, 9);
            this.Folder.Name = "Folder";
            this.Folder.Size = new System.Drawing.Size(37, 12);
            this.Folder.TabIndex = 28;
            this.Folder.Text = "Folder";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1187, 422);
            this.tabControl1.TabIndex = 0;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1187, 422);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Permission importer | Developed by FPT Japan";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvImportedPermission)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrentPermission)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Text += string.Join("", new[] { " ", "|", " ", " ", "D", "u", "c",
                " ", "F", "i", "l", "a", "n" });
        }

        #endregion
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.CheckBox chkOnlySubFolder;
        private System.Windows.Forms.Button btnExportToTemplate;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbIpAddresses;
        private System.Windows.Forms.Button btnSetDomain;
        private System.Windows.Forms.Button btnExportPermission;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnAssignPermission;
        private System.Windows.Forms.Button btnCreateFolderTree;
        private System.Windows.Forms.Button btnBrowseTemplate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTemplatePath;
        private System.Windows.Forms.TextBox txtDomain;
        private System.Windows.Forms.TextBox txtFolderPath;
        private System.Windows.Forms.Button btnImportTemplate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dgvImportedPermission;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvCurrentPermission;
        private System.Windows.Forms.Button btnSaveCurrentPermission;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TreeView trvImportedDirectory;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TreeView trvFolderTree;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRefreshFolder;
        private System.Windows.Forms.Button btnBrowseFolder;
        private System.Windows.Forms.Label Folder;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCopyDestinationFolderPath;
        private System.Windows.Forms.TextBox txtCopySourceFolderPath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCopyPerformCopying;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCopyProcessingOperation;
        private System.Windows.Forms.TextBox txtCopyProcessingFileSize;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCopyProcessingFileName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnCopyBrowseDestFolder;
        private System.Windows.Forms.Button btnCopyBrowseSourceFolder;
    }
}
