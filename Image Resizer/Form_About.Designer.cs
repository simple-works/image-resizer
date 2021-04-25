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
            this.textBox_about = new System.Windows.Forms.TextBox();
            this.button_ok = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_about
            // 
            this.textBox_about.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_about.Location = new System.Drawing.Point(12, 12);
            this.textBox_about.Multiline = true;
            this.textBox_about.Name = "textBox_about";
            this.textBox_about.ReadOnly = true;
            this.textBox_about.Size = new System.Drawing.Size(266, 104);
            this.textBox_about.TabIndex = 1;
            this.textBox_about.Text = "Image Resize\r\nVersion 1.0 (32 bits)\r\nCopyright © 2021 Abdelhakim El hafid\r\n\r\nAlia" +
    "s: Ambratolm\r\nEmail: ambratolm@gmail.com\r\nWebsite: https://ambratolm.ml\r\n";
            // 
            // button_ok
            // 
            this.button_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_ok.Location = new System.Drawing.Point(203, 122);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(75, 23);
            this.button_ok.TabIndex = 0;
            this.button_ok.Text = "OK";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // Form_About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 153);
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.textBox_about);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_About";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_about;
        private System.Windows.Forms.Button button_ok;
    }
}