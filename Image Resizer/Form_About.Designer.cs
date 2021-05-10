namespace ImageResizer
{
    partial class Form_About
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
            this.button_ok = new System.Windows.Forms.Button();
            this.label_title = new System.Windows.Forms.Label();
            this.label_copyright = new System.Windows.Forms.Label();
            this.linkLabel_website = new System.Windows.Forms.LinkLabel();
            this.linkLabel_email = new System.Windows.Forms.LinkLabel();
            this.pictureBox_logo = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox_thirdPartyLicenses = new System.Windows.Forms.TextBox();
            this.label_thirdPartyLicenses = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_logo)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_ok
            // 
            this.button_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_ok.Location = new System.Drawing.Point(277, 204);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(75, 23);
            this.button_ok.TabIndex = 0;
            this.button_ok.Text = "OK";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // label_title
            // 
            this.label_title.AutoSize = true;
            this.label_title.Location = new System.Drawing.Point(75, 0);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(137, 13);
            this.label_title.TabIndex = 2;
            this.label_title.Text = "Image Resizer 1.0 (32 bits)";
            // 
            // label_copyright
            // 
            this.label_copyright.AutoSize = true;
            this.label_copyright.Location = new System.Drawing.Point(75, 20);
            this.label_copyright.Name = "label_copyright";
            this.label_copyright.Size = new System.Drawing.Size(253, 13);
            this.label_copyright.TabIndex = 4;
            this.label_copyright.Text = "Copyright © 2021 Abdelhakim El hafid @Ambratolm";
            // 
            // linkLabel_website
            // 
            this.linkLabel_website.AutoSize = true;
            this.linkLabel_website.Location = new System.Drawing.Point(75, 60);
            this.linkLabel_website.Name = "linkLabel_website";
            this.linkLabel_website.Size = new System.Drawing.Size(71, 13);
            this.linkLabel_website.TabIndex = 5;
            this.linkLabel_website.TabStop = true;
            this.linkLabel_website.Text = "ambratolm.ml";
            this.linkLabel_website.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_website_LinkClicked);
            // 
            // linkLabel_email
            // 
            this.linkLabel_email.AutoSize = true;
            this.linkLabel_email.Location = new System.Drawing.Point(75, 40);
            this.linkLabel_email.Name = "linkLabel_email";
            this.linkLabel_email.Size = new System.Drawing.Size(114, 13);
            this.linkLabel_email.TabIndex = 6;
            this.linkLabel_email.TabStop = true;
            this.linkLabel_email.Text = "ambratolm@gmail.com";
            this.linkLabel_email.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_email_LinkClicked);
            // 
            // pictureBox_logo
            // 
            this.pictureBox_logo.Image = global::ImageResizer.Properties.Resources.logo;
            this.pictureBox_logo.Location = new System.Drawing.Point(3, 3);
            this.pictureBox_logo.Name = "pictureBox_logo";
            this.tableLayoutPanel1.SetRowSpan(this.pictureBox_logo, 4);
            this.pictureBox_logo.Size = new System.Drawing.Size(64, 74);
            this.pictureBox_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_logo.TabIndex = 7;
            this.pictureBox_logo.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.20482F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 78.79518F));
            this.tableLayoutPanel1.Controls.Add(this.label_title, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_copyright, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.linkLabel_email, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.linkLabel_website, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox_logo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox_thirdPartyLicenses, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.label_thirdPartyLicenses, 1, 5);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(340, 186);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // textBox_thirdPartyLicenses
            // 
            this.textBox_thirdPartyLicenses.Location = new System.Drawing.Point(75, 123);
            this.textBox_thirdPartyLicenses.Multiline = true;
            this.textBox_thirdPartyLicenses.Name = "textBox_thirdPartyLicenses";
            this.textBox_thirdPartyLicenses.ReadOnly = true;
            this.textBox_thirdPartyLicenses.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_thirdPartyLicenses.Size = new System.Drawing.Size(262, 60);
            this.textBox_thirdPartyLicenses.TabIndex = 8;
            // 
            // label_thirdPartyLicenses
            // 
            this.label_thirdPartyLicenses.AutoSize = true;
            this.label_thirdPartyLicenses.Location = new System.Drawing.Point(75, 100);
            this.label_thirdPartyLicenses.Name = "label_thirdPartyLicenses";
            this.label_thirdPartyLicenses.Size = new System.Drawing.Size(107, 13);
            this.label_thirdPartyLicenses.TabIndex = 9;
            this.label_thirdPartyLicenses.Text = "Third Party Licenses:";
            // 
            // Form_About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 235);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.button_ok);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_About";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_logo)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.Label label_title;
        private System.Windows.Forms.Label label_copyright;
        private System.Windows.Forms.LinkLabel linkLabel_website;
        private System.Windows.Forms.LinkLabel linkLabel_email;
        private System.Windows.Forms.PictureBox pictureBox_logo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox textBox_thirdPartyLicenses;
        private System.Windows.Forms.Label label_thirdPartyLicenses;
    }
}