namespace ExeGenerator
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnSave = new System.Windows.Forms.Button();
            this.tbxUsername = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.saveConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbxPassword = new System.Windows.Forms.TextBox();
            this.tbxCommands = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.tbxDomain = new System.Windows.Forms.TextBox();
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.lblDomain = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblCommands = new System.Windows.Forms.Label();
            this.lblIncludeFolder = new System.Windows.Forms.Label();
            this.lblSave = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.tbxIncludeFolder = new System.Windows.Forms.TextBox();
            this.btnClearIncludeFolder = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(194, 326);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(154, 41);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tbxUsername
            // 
            this.tbxUsername.ContextMenuStrip = this.contextMenuStrip1;
            this.tbxUsername.Location = new System.Drawing.Point(97, 33);
            this.tbxUsername.Name = "tbxUsername";
            this.tbxUsername.Size = new System.Drawing.Size(252, 20);
            this.tbxUsername.TabIndex = 1;
            this.tbxUsername.Tag = "";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveConfigToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(138, 26);
            // 
            // saveConfigToolStripMenuItem
            // 
            this.saveConfigToolStripMenuItem.Name = "saveConfigToolStripMenuItem";
            this.saveConfigToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.saveConfigToolStripMenuItem.Text = "Save Config";
            this.saveConfigToolStripMenuItem.Click += new System.EventHandler(this.saveConfigToolStripMenuItem_Click);
            // 
            // tbxPassword
            // 
            this.tbxPassword.ContextMenuStrip = this.contextMenuStrip1;
            this.tbxPassword.Location = new System.Drawing.Point(97, 85);
            this.tbxPassword.Name = "tbxPassword";
            this.tbxPassword.PasswordChar = '*';
            this.tbxPassword.Size = new System.Drawing.Size(252, 20);
            this.tbxPassword.TabIndex = 3;
            // 
            // tbxCommands
            // 
            this.tbxCommands.ContextMenuStrip = this.contextMenuStrip1;
            this.tbxCommands.Location = new System.Drawing.Point(97, 124);
            this.tbxCommands.Multiline = true;
            this.tbxCommands.Name = "tbxCommands";
            this.tbxCommands.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxCommands.Size = new System.Drawing.Size(251, 126);
            this.tbxCommands.TabIndex = 4;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.BackColor = System.Drawing.Color.Transparent;
            this.lblUsername.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblUsername.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblUsername.Location = new System.Drawing.Point(26, 36);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(65, 13);
            this.lblUsername.TabIndex = 5;
            this.lblUsername.Text = "Username";
            // 
            // tbxDomain
            // 
            this.tbxDomain.ContextMenuStrip = this.contextMenuStrip1;
            this.tbxDomain.Location = new System.Drawing.Point(97, 59);
            this.tbxDomain.Name = "tbxDomain";
            this.tbxDomain.Size = new System.Drawing.Size(252, 20);
            this.tbxDomain.TabIndex = 2;
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.Font = new System.Drawing.Font("Tahoma", 7F);
            this.btnSelectFolder.Location = new System.Drawing.Point(30, 275);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(65, 20);
            this.btnSelectFolder.TabIndex = 6;
            this.btnSelectFolder.Text = "Select";
            this.btnSelectFolder.UseVisualStyleBackColor = true;
            this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // lblDomain
            // 
            this.lblDomain.AutoSize = true;
            this.lblDomain.BackColor = System.Drawing.Color.Transparent;
            this.lblDomain.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblDomain.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblDomain.Location = new System.Drawing.Point(32, 61);
            this.lblDomain.Name = "lblDomain";
            this.lblDomain.Size = new System.Drawing.Size(50, 13);
            this.lblDomain.TabIndex = 11;
            this.lblDomain.Text = "Domain";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.BackColor = System.Drawing.Color.Transparent;
            this.lblPassword.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblPassword.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblPassword.Location = new System.Drawing.Point(26, 88);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(61, 13);
            this.lblPassword.TabIndex = 12;
            this.lblPassword.Text = "Password";
            // 
            // lblCommands
            // 
            this.lblCommands.AutoSize = true;
            this.lblCommands.BackColor = System.Drawing.Color.Transparent;
            this.lblCommands.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblCommands.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblCommands.Location = new System.Drawing.Point(25, 124);
            this.lblCommands.Name = "lblCommands";
            this.lblCommands.Size = new System.Drawing.Size(70, 13);
            this.lblCommands.TabIndex = 13;
            this.lblCommands.Text = "Commands";
            // 
            // lblIncludeFolder
            // 
            this.lblIncludeFolder.AutoSize = true;
            this.lblIncludeFolder.BackColor = System.Drawing.Color.Transparent;
            this.lblIncludeFolder.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblIncludeFolder.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblIncludeFolder.Location = new System.Drawing.Point(12, 257);
            this.lblIncludeFolder.Name = "lblIncludeFolder";
            this.lblIncludeFolder.Size = new System.Drawing.Size(146, 13);
            this.lblIncludeFolder.TabIndex = 14;
            this.lblIncludeFolder.Text = "Include Folder (optional)";
            // 
            // lblSave
            // 
            this.lblSave.AutoSize = true;
            this.lblSave.BackColor = System.Drawing.Color.Transparent;
            this.lblSave.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblSave.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblSave.Location = new System.Drawing.Point(21, 340);
            this.lblSave.Name = "lblSave";
            this.lblSave.Size = new System.Drawing.Size(83, 13);
            this.lblSave.TabIndex = 15;
            this.lblSave.Text = "Generate Exe";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(11, 368);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(338, 10);
            this.progressBar.TabIndex = 16;
            this.progressBar.Visible = false;
            // 
            // tbxIncludeFolder
            // 
            this.tbxIncludeFolder.ContextMenuStrip = this.contextMenuStrip1;
            this.tbxIncludeFolder.Location = new System.Drawing.Point(97, 275);
            this.tbxIncludeFolder.Multiline = true;
            this.tbxIncludeFolder.Name = "tbxIncludeFolder";
            this.tbxIncludeFolder.Size = new System.Drawing.Size(251, 38);
            this.tbxIncludeFolder.TabIndex = 5;
            // 
            // btnClearIncludeFolder
            // 
            this.btnClearIncludeFolder.Font = new System.Drawing.Font("Tahoma", 7F);
            this.btnClearIncludeFolder.Location = new System.Drawing.Point(30, 296);
            this.btnClearIncludeFolder.Name = "btnClearIncludeFolder";
            this.btnClearIncludeFolder.Size = new System.Drawing.Size(65, 20);
            this.btnClearIncludeFolder.TabIndex = 7;
            this.btnClearIncludeFolder.Text = "Clear";
            this.btnClearIncludeFolder.UseVisualStyleBackColor = true;
            this.btnClearIncludeFolder.Click += new System.EventHandler(this.btnClearIncludeFolder_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 383);
            this.Controls.Add(this.btnClearIncludeFolder);
            this.Controls.Add(this.tbxIncludeFolder);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lblSave);
            this.Controls.Add(this.lblIncludeFolder);
            this.Controls.Add(this.lblCommands);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblDomain);
            this.Controls.Add(this.btnSelectFolder);
            this.Controls.Add(this.tbxDomain);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.tbxCommands);
            this.Controls.Add(this.tbxPassword);
            this.Controls.Add(this.tbxUsername);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "RunAs - iTech AppDev";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox tbxUsername;
        private System.Windows.Forms.TextBox tbxPassword;
        private System.Windows.Forms.TextBox tbxCommands;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox tbxDomain;
        private System.Windows.Forms.Button btnSelectFolder;
        private System.Windows.Forms.Label lblDomain;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblCommands;
        private System.Windows.Forms.Label lblIncludeFolder;
        private System.Windows.Forms.Label lblSave;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem saveConfigToolStripMenuItem;
        private System.Windows.Forms.TextBox tbxIncludeFolder;
        private System.Windows.Forms.Button btnClearIncludeFolder;
    }
}

