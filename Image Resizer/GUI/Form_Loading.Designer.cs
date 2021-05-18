namespace ImageResizer
{
    partial class Form_Loading
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
            this.button_cancel = new System.Windows.Forms.Button();
            this.progressBar_main = new System.Windows.Forms.ProgressBar();
            this.label_progressPercentage = new System.Windows.Forms.Label();
            this.label_title = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.backgroundWorker_main = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(188, 70);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_cancel.TabIndex = 0;
            this.button_cancel.Text = "Cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // progressBar_main
            // 
            this.progressBar_main.Location = new System.Drawing.Point(14, 37);
            this.progressBar_main.Name = "progressBar_main";
            this.progressBar_main.Size = new System.Drawing.Size(249, 23);
            this.progressBar_main.TabIndex = 1;
            // 
            // label_progressPercentage
            // 
            this.label_progressPercentage.Location = new System.Drawing.Point(227, 11);
            this.label_progressPercentage.Name = "label_progressPercentage";
            this.label_progressPercentage.Size = new System.Drawing.Size(36, 23);
            this.label_progressPercentage.TabIndex = 2;
            this.label_progressPercentage.Text = "0%";
            this.label_progressPercentage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_title
            // 
            this.label_title.Location = new System.Drawing.Point(11, 11);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(199, 23);
            this.label_title.TabIndex = 3;
            this.label_title.Text = "Loading...";
            this.label_title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.progressBar_main);
            this.panel1.Controls.Add(this.label_title);
            this.panel1.Controls.Add(this.button_cancel);
            this.panel1.Controls.Add(this.label_progressPercentage);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(276, 107);
            this.panel1.TabIndex = 4;
            // 
            // backgroundWorker_main
            // 
            this.backgroundWorker_main.WorkerReportsProgress = true;
            this.backgroundWorker_main.WorkerSupportsCancellation = true;
            this.backgroundWorker_main.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_main_DoWork);
            this.backgroundWorker_main.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_main_ProgressChanged);
            this.backgroundWorker_main.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_main_RunWorkerCompleted);
            // 
            // Form_Loading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 107);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Loading";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Loading_FormClosing);
            this.Load += new System.EventHandler(this.Form_Loading_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.ProgressBar progressBar_main;
        private System.Windows.Forms.Label label_progressPercentage;
        private System.Windows.Forms.Label label_title;
        private System.Windows.Forms.Panel panel1;
        private System.ComponentModel.BackgroundWorker backgroundWorker_main;
    }
}