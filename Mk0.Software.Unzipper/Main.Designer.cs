namespace Mk0.Software.Unzipper
{
    partial class Main
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
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
            this.labelInformation = new System.Windows.Forms.Label();
            this.buttonSelectZip = new System.Windows.Forms.Button();
            this.buttonTargetDir = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.buttonExtract = new System.Windows.Forms.Button();
            this.labelZipFile = new System.Windows.Forms.Label();
            this.labelTarget = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(96, 44);
            this.progressBar.Margin = new System.Windows.Forms.Padding(5);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(396, 35);
            this.progressBar.TabIndex = 0;
            this.progressBar.Visible = false;
            // 
            // pictureBoxIcon
            // 
            this.pictureBoxIcon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBoxIcon.Image = global::Mk0.Software.Unzipper.Properties.Resources.Unzipper;
            this.pictureBoxIcon.Location = new System.Drawing.Point(14, 14);
            this.pictureBoxIcon.Margin = new System.Windows.Forms.Padding(5);
            this.pictureBoxIcon.Name = "pictureBoxIcon";
            this.pictureBoxIcon.Size = new System.Drawing.Size(72, 72);
            this.pictureBoxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxIcon.TabIndex = 2;
            this.pictureBoxIcon.TabStop = false;
            // 
            // labelInformation
            // 
            this.labelInformation.AutoSize = true;
            this.labelInformation.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInformation.Location = new System.Drawing.Point(93, 14);
            this.labelInformation.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelInformation.Name = "labelInformation";
            this.labelInformation.Size = new System.Drawing.Size(68, 15);
            this.labelInformation.TabIndex = 3;
            this.labelInformation.Text = "Extrahiere...";
            this.labelInformation.Visible = false;
            // 
            // buttonSelectZip
            // 
            this.buttonSelectZip.Location = new System.Drawing.Point(96, 14);
            this.buttonSelectZip.Name = "buttonSelectZip";
            this.buttonSelectZip.Size = new System.Drawing.Size(173, 23);
            this.buttonSelectZip.TabIndex = 4;
            this.buttonSelectZip.Text = "zu entpackendes ZIP wählen...";
            this.buttonSelectZip.UseVisualStyleBackColor = true;
            this.buttonSelectZip.Click += new System.EventHandler(this.ButtonSelectZip_Click);
            // 
            // buttonTargetDir
            // 
            this.buttonTargetDir.Enabled = false;
            this.buttonTargetDir.Location = new System.Drawing.Point(275, 14);
            this.buttonTargetDir.Name = "buttonTargetDir";
            this.buttonTargetDir.Size = new System.Drawing.Size(121, 23);
            this.buttonTargetDir.TabIndex = 5;
            this.buttonTargetDir.Text = "Zielordner wählen...";
            this.buttonTargetDir.UseVisualStyleBackColor = true;
            this.buttonTargetDir.Click += new System.EventHandler(this.ButtonTargetDir_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "*.zip";
            this.openFileDialog.Filter = "ZIP-Dateien|*.zip";
            this.openFileDialog.Title = "zu entpackendes ZIP wählen...";
            // 
            // buttonExtract
            // 
            this.buttonExtract.Enabled = false;
            this.buttonExtract.Location = new System.Drawing.Point(402, 14);
            this.buttonExtract.Name = "buttonExtract";
            this.buttonExtract.Size = new System.Drawing.Size(90, 23);
            this.buttonExtract.TabIndex = 6;
            this.buttonExtract.Text = "Entpacken";
            this.buttonExtract.UseVisualStyleBackColor = true;
            this.buttonExtract.Click += new System.EventHandler(this.ButtonExtract_Click);
            // 
            // labelZipFile
            // 
            this.labelZipFile.AutoSize = true;
            this.labelZipFile.Location = new System.Drawing.Point(94, 44);
            this.labelZipFile.Name = "labelZipFile";
            this.labelZipFile.Size = new System.Drawing.Size(98, 15);
            this.labelZipFile.TabIndex = 7;
            this.labelZipFile.Text = "ZIP: unknown.zip";
            this.labelZipFile.Visible = false;
            // 
            // labelTarget
            // 
            this.labelTarget.AutoSize = true;
            this.labelTarget.Location = new System.Drawing.Point(94, 59);
            this.labelTarget.Name = "labelTarget";
            this.labelTarget.Size = new System.Drawing.Size(160, 15);
            this.labelTarget.TabIndex = 8;
            this.labelTarget.Text = "entpacken nach C:\\unknown";
            this.labelTarget.Visible = false;
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.Description = "Zielordner zum entpacken wählen...";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(506, 100);
            this.Controls.Add(this.labelTarget);
            this.Controls.Add(this.labelZipFile);
            this.Controls.Add(this.buttonExtract);
            this.Controls.Add(this.buttonTargetDir);
            this.Controls.Add(this.buttonSelectZip);
            this.Controls.Add(this.labelInformation);
            this.Controls.Add(this.pictureBoxIcon);
            this.Controls.Add(this.progressBar);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Unzipper v1.0 | © 2019-2020 by mk0.at";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Shown += new System.EventHandler(this.Main_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.PictureBox pictureBoxIcon;
        private System.Windows.Forms.Label labelInformation;
        private System.Windows.Forms.Button buttonSelectZip;
        private System.Windows.Forms.Button buttonTargetDir;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button buttonExtract;
        private System.Windows.Forms.Label labelZipFile;
        private System.Windows.Forms.Label labelTarget;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
    }
}

