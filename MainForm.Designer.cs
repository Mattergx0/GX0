namespace FileTaggerApp
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TextBox txtNewFolderName;
        private System.Windows.Forms.Button btnAddFolder;
        private System.Windows.Forms.ListBox listBoxFolders;
        private System.Windows.Forms.ListBox listBoxFiles;
        private System.Windows.Forms.TextBox txtFileTags;
        private System.Windows.Forms.Button btnAddFile;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtNewFolderName = new System.Windows.Forms.TextBox();
            this.btnAddFolder = new System.Windows.Forms.Button();
            this.listBoxFolders = new System.Windows.Forms.ListBox();
            this.listBoxFiles = new System.Windows.Forms.ListBox();
            this.txtFileTags = new System.Windows.Forms.TextBox();
            this.btnAddFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtNewFolderName
            // 
            this.txtNewFolderName.Location = new System.Drawing.Point(12, 12);
            this.txtNewFolderName.Name = "txtNewFolderName";
            this.txtNewFolderName.Size = new System.Drawing.Size(150, 22);
            this.txtNewFolderName.TabIndex = 0;
            // 
            // btnAddFolder
            // 
            this.btnAddFolder.Location = new System.Drawing.Point(168, 12);
            this.btnAddFolder.Name = "btnAddFolder";
            this.btnAddFolder.Size = new System.Drawing.Size(100, 23);
            this.btnAddFolder.TabIndex = 1;
            this.btnAddFolder.Text = "Map toevoegen";
            this.btnAddFolder.UseVisualStyleBackColor = true;
            this.btnAddFolder.Click += new System.EventHandler(this.btnAddFolder_Click);
            // 
            // listBoxFolders
            // 
            this.listBoxFolders.FormattingEnabled = true;
            this.listBoxFolders.ItemHeight = 16;
            this.listBoxFolders.Location = new System.Drawing.Point(12, 50);
            this.listBoxFolders.Name = "listBoxFolders";
            this.listBoxFolders.Size = new System.Drawing.Size(256, 180);
            this.listBoxFolders.TabIndex = 2;
            this.listBoxFolders.SelectedIndexChanged += new System.EventHandler(this.listBoxFolders_SelectedIndexChanged);
            // 
            // listBoxFiles
            // 
            this.listBoxFiles.FormattingEnabled = true;
            this.listBoxFiles.ItemHeight = 16;
            this.listBoxFiles.Location = new System.Drawing.Point(274, 50);
            this.listBoxFiles.Name = "listBoxFiles";
            this.listBoxFiles.Size = new System.Drawing.Size(350, 180);
            this.listBoxFiles.TabIndex = 3;
            this.listBoxFiles.DoubleClick += new System.EventHandler(this.listBoxFiles_DoubleClick);
            // 
            // txtFileTags
            // 
            this.txtFileTags.Location = new System.Drawing.Point(274, 12);
            this.txtFileTags.Name = "txtFileTags";
            this.txtFileTags.Size = new System.Drawing.Size(200, 22);
            this.txtFileTags.TabIndex = 4;
            this.txtFileTags.PlaceholderText = "Tags (komma gescheiden)";
            // 
            // btnAddFile
            // 
            this.btnAddFile.Location = new System.Drawing.Point(480, 12);
            this.btnAddFile.Name = "btnAddFile";
            this.btnAddFile.Size = new System.Drawing.Size(144, 23);
            this.btnAddFile.TabIndex = 5;
            this.btnAddFile.Text = "Bestand toevoegen";
            this.btnAddFile.UseVisualStyleBackColor = true;
            this.btnAddFile.Click += new System.EventHandler(this.btnAddFile_Click);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(640, 250);
            this.Controls.Add(this.btnAddFile);
            this.Controls.Add(this.txtFileTags);
            this.Controls.Add(this.listBoxFiles);
            this.Controls.Add(this.listBoxFolders);
            this.Controls.Add(this.btnAddFolder);
            this.Controls.Add(this.txtNewFolderName);
            this.Name = "MainForm";
            this.Text = "FileTagger";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
