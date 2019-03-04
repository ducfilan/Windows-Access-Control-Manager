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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.txtFolderPath = new System.Windows.Forms.TextBox();
            this.Folder = new System.Windows.Forms.Label();
            this.btnBrowseFolder = new System.Windows.Forms.Button();
            this.btnRefreshFolder = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDomain = new System.Windows.Forms.TextBox();
            this.trvFolderTree = new System.Windows.Forms.TreeView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgvImportedPermission = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvCurrentPermission = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.trvImportedDirectory = new System.Windows.Forms.TreeView();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnImportTemplate = new System.Windows.Forms.Button();
            this.btnExportPermission = new System.Windows.Forms.Button();
            this.btnBrowseTemplate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTemplatePath = new System.Windows.Forms.TextBox();
            this.btnCreateFolderTree = new System.Windows.Forms.Button();
            this.btnAssignPermission = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImportedPermission)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrentPermission)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFolderPath
            // 
            this.txtFolderPath.Location = new System.Drawing.Point(68, 10);
            this.txtFolderPath.Name = "txtFolderPath";
            this.txtFolderPath.Size = new System.Drawing.Size(462, 19);
            this.txtFolderPath.TabIndex = 1;
            // 
            // Folder
            // 
            this.Folder.AutoSize = true;
            this.Folder.Location = new System.Drawing.Point(25, 13);
            this.Folder.Name = "Folder";
            this.Folder.Size = new System.Drawing.Size(37, 12);
            this.Folder.TabIndex = 2;
            this.Folder.Text = "Folder";
            // 
            // btnBrowseFolder
            // 
            this.btnBrowseFolder.Location = new System.Drawing.Point(536, 8);
            this.btnBrowseFolder.Name = "btnBrowseFolder";
            this.btnBrowseFolder.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseFolder.TabIndex = 3;
            this.btnBrowseFolder.Text = "Browse";
            this.btnBrowseFolder.UseVisualStyleBackColor = true;
            this.btnBrowseFolder.Click += new System.EventHandler(this.btnBrowseFolder_Click);
            // 
            // btnRefreshFolder
            // 
            this.btnRefreshFolder.Location = new System.Drawing.Point(617, 8);
            this.btnRefreshFolder.Name = "btnRefreshFolder";
            this.btnRefreshFolder.Size = new System.Drawing.Size(119, 23);
            this.btnRefreshFolder.TabIndex = 4;
            this.btnRefreshFolder.Text = "Refresh";
            this.btnRefreshFolder.UseVisualStyleBackColor = true;
            this.btnRefreshFolder.Click += new System.EventHandler(this.btnRefreshFolder_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.FileName = "Permission";
            this.saveFileDialog.Filter = "Excel files(*.xlsx)|*.xlsx|Excel files 97-2003(*.xls)|*.xls|All files (*.*)|*.*";
            this.saveFileDialog.Title = "Save exported permissions file";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(807, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "Domain";
            // 
            // txtDomain
            // 
            this.txtDomain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDomain.Location = new System.Drawing.Point(856, 10);
            this.txtDomain.Name = "txtDomain";
            this.txtDomain.Size = new System.Drawing.Size(218, 19);
            this.txtDomain.TabIndex = 7;
            this.txtDomain.TextChanged += new System.EventHandler(this.txtDomain_TextChanged);
            // 
            // trvFolderTree
            // 
            this.trvFolderTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvFolderTree.Location = new System.Drawing.Point(3, 15);
            this.trvFolderTree.Name = "trvFolderTree";
            this.trvFolderTree.Size = new System.Drawing.Size(285, 461);
            this.trvFolderTree.TabIndex = 0;
            this.trvFolderTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvFolderTree_AfterSelect);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.trvFolderTree);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(291, 479);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Current Directory tree";
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 66);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1190, 485);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgvImportedPermission);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(894, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(293, 479);
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
            this.dgvImportedPermission.Size = new System.Drawing.Size(287, 461);
            this.dgvImportedPermission.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvCurrentPermission);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(597, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(291, 479);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Current Permission";
            // 
            // dgvCurrentPermission
            // 
            this.dgvCurrentPermission.AllowUserToAddRows = false;
            this.dgvCurrentPermission.AllowUserToDeleteRows = false;
            this.dgvCurrentPermission.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCurrentPermission.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCurrentPermission.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCurrentPermission.Location = new System.Drawing.Point(3, 15);
            this.dgvCurrentPermission.Name = "dgvCurrentPermission";
            this.dgvCurrentPermission.ReadOnly = true;
            this.dgvCurrentPermission.RowTemplate.Height = 21;
            this.dgvCurrentPermission.Size = new System.Drawing.Size(285, 461);
            this.dgvCurrentPermission.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.trvImportedDirectory);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(300, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(291, 479);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Imported Directory tree";
            // 
            // trvImportedDirectory
            // 
            this.trvImportedDirectory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvImportedDirectory.Location = new System.Drawing.Point(3, 15);
            this.trvImportedDirectory.Name = "trvImportedDirectory";
            this.trvImportedDirectory.Size = new System.Drawing.Size(285, 461);
            this.trvImportedDirectory.TabIndex = 0;
            this.trvImportedDirectory.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvImportedDirectory_AfterSelect);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Excel files(*.xlsx)|*.xlsx|Excel files 97-2003(*.xls)|*.xls|All files (*.*)|*.*";
            this.openFileDialog.Title = "Import permissions file";
            // 
            // btnImportTemplate
            // 
            this.btnImportTemplate.Location = new System.Drawing.Point(617, 37);
            this.btnImportTemplate.Name = "btnImportTemplate";
            this.btnImportTemplate.Size = new System.Drawing.Size(119, 23);
            this.btnImportTemplate.TabIndex = 12;
            this.btnImportTemplate.Text = "Import template";
            this.btnImportTemplate.UseVisualStyleBackColor = true;
            this.btnImportTemplate.Click += new System.EventHandler(this.btnImportTemplate_Click);
            // 
            // btnExportPermission
            // 
            this.btnExportPermission.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportPermission.Location = new System.Drawing.Point(1080, 8);
            this.btnExportPermission.Name = "btnExportPermission";
            this.btnExportPermission.Size = new System.Drawing.Size(119, 23);
            this.btnExportPermission.TabIndex = 11;
            this.btnExportPermission.Text = "Export permission";
            this.btnExportPermission.UseVisualStyleBackColor = true;
            this.btnExportPermission.Click += new System.EventHandler(this.btnExportPermission_Click);
            // 
            // btnBrowseTemplate
            // 
            this.btnBrowseTemplate.Location = new System.Drawing.Point(536, 37);
            this.btnBrowseTemplate.Name = "btnBrowseTemplate";
            this.btnBrowseTemplate.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseTemplate.TabIndex = 15;
            this.btnBrowseTemplate.Text = "Browse";
            this.btnBrowseTemplate.UseVisualStyleBackColor = true;
            this.btnBrowseTemplate.Click += new System.EventHandler(this.btnBrowseTemplate_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "Template";
            // 
            // txtTemplatePath
            // 
            this.txtTemplatePath.Location = new System.Drawing.Point(68, 39);
            this.txtTemplatePath.Name = "txtTemplatePath";
            this.txtTemplatePath.Size = new System.Drawing.Size(462, 19);
            this.txtTemplatePath.TabIndex = 13;
            // 
            // btnCreateFolderTree
            // 
            this.btnCreateFolderTree.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCreateFolderTree.BackColor = System.Drawing.Color.Red;
            this.btnCreateFolderTree.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCreateFolderTree.ForeColor = System.Drawing.Color.White;
            this.btnCreateFolderTree.Location = new System.Drawing.Point(12, 557);
            this.btnCreateFolderTree.Name = "btnCreateFolderTree";
            this.btnCreateFolderTree.Size = new System.Drawing.Size(140, 35);
            this.btnCreateFolderTree.TabIndex = 18;
            this.btnCreateFolderTree.Text = "Create Folder Tree";
            this.btnCreateFolderTree.UseVisualStyleBackColor = false;
            this.btnCreateFolderTree.Click += new System.EventHandler(this.BtnCreateFolderTree_Click);
            // 
            // btnAssignPermission
            // 
            this.btnAssignPermission.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAssignPermission.BackColor = System.Drawing.Color.Red;
            this.btnAssignPermission.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnAssignPermission.ForeColor = System.Drawing.Color.White;
            this.btnAssignPermission.Location = new System.Drawing.Point(158, 557);
            this.btnAssignPermission.Name = "btnAssignPermission";
            this.btnAssignPermission.Size = new System.Drawing.Size(140, 35);
            this.btnAssignPermission.TabIndex = 19;
            this.btnAssignPermission.Text = "Assign Permission";
            this.btnAssignPermission.UseVisualStyleBackColor = false;
            this.btnAssignPermission.Click += new System.EventHandler(this.BtnAssignPermission_Click);
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
            this.btnHelp.Location = new System.Drawing.Point(1170, 565);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(32, 21);
            this.btnHelp.TabIndex = 20;
            this.btnHelp.Text = "?";
            this.btnHelp.UseVisualStyleBackColor = false;
            this.btnHelp.Click += new System.EventHandler(this.BtnHelp_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1214, 595);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnAssignPermission);
            this.Controls.Add(this.btnCreateFolderTree);
            this.Controls.Add(this.btnBrowseTemplate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTemplatePath);
            this.Controls.Add(this.btnImportTemplate);
            this.Controls.Add(this.btnExportPermission);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDomain);
            this.Controls.Add(this.btnRefreshFolder);
            this.Controls.Add(this.btnBrowseFolder);
            this.Controls.Add(this.Folder);
            this.Controls.Add(this.txtFolderPath);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Permission setter";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvImportedPermission)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrentPermission)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtFolderPath;
        private System.Windows.Forms.Label Folder;
        private System.Windows.Forms.Button btnBrowseFolder;
        private System.Windows.Forms.Button btnRefreshFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDomain;
        private System.Windows.Forms.TreeView trvFolderTree;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TreeView trvImportedDirectory;
        private System.Windows.Forms.DataGridView dgvImportedPermission;
        private System.Windows.Forms.DataGridView dgvCurrentPermission;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button btnImportTemplate;
        private System.Windows.Forms.Button btnExportPermission;
        private System.Windows.Forms.Button btnBrowseTemplate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTemplatePath;
        private System.Windows.Forms.Button btnCreateFolderTree;
        private System.Windows.Forms.Button btnAssignPermission;
		private System.Windows.Forms.Button btnHelp;
	}
}