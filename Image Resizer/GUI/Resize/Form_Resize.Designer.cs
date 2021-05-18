namespace ImageResizer
{
    partial class Form_Resize
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
            this.checkBox_keepAspectRatio = new System.Windows.Forms.CheckBox();
            this.groupBox_percentage = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label_widthPc = new System.Windows.Forms.Label();
            this.label_heightPc = new System.Windows.Forms.Label();
            this.numUD_heightPc = new System.Windows.Forms.NumericUpDown();
            this.numUD_widthPc = new System.Windows.Forms.NumericUpDown();
            this.groupBox_flat = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label_width = new System.Windows.Forms.Label();
            this.label_height = new System.Windows.Forms.Label();
            this.numUD_height = new System.Windows.Forms.NumericUpDown();
            this.numUD_width = new System.Windows.Forms.NumericUpDown();
            this.textBox_outputFolderPath = new System.Windows.Forms.TextBox();
            this.label_outputFolder = new System.Windows.Forms.Label();
            this.radioButton_flat = new System.Windows.Forms.RadioButton();
            this.radioButton_percentage = new System.Windows.Forms.RadioButton();
            this.button_start = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.button_selectOutputFolder = new System.Windows.Forms.Button();
            this.toolTip_main = new System.Windows.Forms.ToolTip(this.components);
            this.folderBrowserDialog_main = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox_percentage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_heightPc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_widthPc)).BeginInit();
            this.groupBox_flat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_height)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_width)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBox_keepAspectRatio
            // 
            this.checkBox_keepAspectRatio.AutoSize = true;
            this.checkBox_keepAspectRatio.Checked = true;
            this.checkBox_keepAspectRatio.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_keepAspectRatio.Location = new System.Drawing.Point(15, 139);
            this.checkBox_keepAspectRatio.Name = "checkBox_keepAspectRatio";
            this.checkBox_keepAspectRatio.Size = new System.Drawing.Size(114, 17);
            this.checkBox_keepAspectRatio.TabIndex = 2;
            this.checkBox_keepAspectRatio.Text = "Keep Aspect Ratio";
            this.toolTip_main.SetToolTip(this.checkBox_keepAspectRatio, "Keep the same width-height proportions");
            this.checkBox_keepAspectRatio.UseVisualStyleBackColor = true;
            this.checkBox_keepAspectRatio.CheckedChanged += new System.EventHandler(this.checkBox_keepAspectRatio_CheckedChanged);
            // 
            // groupBox_percentage
            // 
            this.groupBox_percentage.Controls.Add(this.label4);
            this.groupBox_percentage.Controls.Add(this.label3);
            this.groupBox_percentage.Controls.Add(this.label_widthPc);
            this.groupBox_percentage.Controls.Add(this.label_heightPc);
            this.groupBox_percentage.Controls.Add(this.numUD_heightPc);
            this.groupBox_percentage.Controls.Add(this.numUD_widthPc);
            this.groupBox_percentage.Enabled = false;
            this.groupBox_percentage.Location = new System.Drawing.Point(248, 44);
            this.groupBox_percentage.Name = "groupBox_percentage";
            this.groupBox_percentage.Size = new System.Drawing.Size(226, 89);
            this.groupBox_percentage.TabIndex = 1;
            this.groupBox_percentage.TabStop = false;
            this.groupBox_percentage.Text = "Percentage";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(190, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "%";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(190, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "%";
            // 
            // label_widthPc
            // 
            this.label_widthPc.AutoSize = true;
            this.label_widthPc.Location = new System.Drawing.Point(19, 23);
            this.label_widthPc.Name = "label_widthPc";
            this.label_widthPc.Size = new System.Drawing.Size(39, 13);
            this.label_widthPc.TabIndex = 0;
            this.label_widthPc.Text = "Width:";
            // 
            // label_heightPc
            // 
            this.label_heightPc.AutoSize = true;
            this.label_heightPc.Location = new System.Drawing.Point(19, 54);
            this.label_heightPc.Name = "label_heightPc";
            this.label_heightPc.Size = new System.Drawing.Size(42, 13);
            this.label_heightPc.TabIndex = 2;
            this.label_heightPc.Text = "Height:";
            // 
            // numUD_heightPc
            // 
            this.numUD_heightPc.Location = new System.Drawing.Point(67, 50);
            this.numUD_heightPc.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numUD_heightPc.Name = "numUD_heightPc";
            this.numUD_heightPc.Size = new System.Drawing.Size(120, 20);
            this.numUD_heightPc.TabIndex = 3;
            this.numUD_heightPc.ValueChanged += new System.EventHandler(this.numUD_heightPc_ValueChanged);
            // 
            // numUD_widthPc
            // 
            this.numUD_widthPc.Location = new System.Drawing.Point(64, 19);
            this.numUD_widthPc.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numUD_widthPc.Name = "numUD_widthPc";
            this.numUD_widthPc.Size = new System.Drawing.Size(120, 20);
            this.numUD_widthPc.TabIndex = 1;
            this.numUD_widthPc.ValueChanged += new System.EventHandler(this.numUD_widthPc_ValueChanged);
            // 
            // groupBox_flat
            // 
            this.groupBox_flat.Controls.Add(this.label6);
            this.groupBox_flat.Controls.Add(this.label5);
            this.groupBox_flat.Controls.Add(this.label_width);
            this.groupBox_flat.Controls.Add(this.label_height);
            this.groupBox_flat.Controls.Add(this.numUD_height);
            this.groupBox_flat.Controls.Add(this.numUD_width);
            this.groupBox_flat.Location = new System.Drawing.Point(15, 44);
            this.groupBox_flat.Name = "groupBox_flat";
            this.groupBox_flat.Size = new System.Drawing.Size(226, 89);
            this.groupBox_flat.TabIndex = 0;
            this.groupBox_flat.TabStop = false;
            this.groupBox_flat.Text = "Flat";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(182, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Pixels";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(182, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Pixels";
            // 
            // label_width
            // 
            this.label_width.AutoSize = true;
            this.label_width.Location = new System.Drawing.Point(11, 23);
            this.label_width.Name = "label_width";
            this.label_width.Size = new System.Drawing.Size(39, 13);
            this.label_width.TabIndex = 0;
            this.label_width.Text = "Width:";
            // 
            // label_height
            // 
            this.label_height.AutoSize = true;
            this.label_height.Location = new System.Drawing.Point(11, 54);
            this.label_height.Name = "label_height";
            this.label_height.Size = new System.Drawing.Size(42, 13);
            this.label_height.TabIndex = 2;
            this.label_height.Text = "Height:";
            // 
            // numUD_height
            // 
            this.numUD_height.Location = new System.Drawing.Point(56, 50);
            this.numUD_height.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numUD_height.Name = "numUD_height";
            this.numUD_height.Size = new System.Drawing.Size(120, 20);
            this.numUD_height.TabIndex = 3;
            this.numUD_height.ValueChanged += new System.EventHandler(this.numUD_height_ValueChanged);
            // 
            // numUD_width
            // 
            this.numUD_width.Location = new System.Drawing.Point(56, 19);
            this.numUD_width.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numUD_width.Name = "numUD_width";
            this.numUD_width.Size = new System.Drawing.Size(120, 20);
            this.numUD_width.TabIndex = 1;
            this.numUD_width.ValueChanged += new System.EventHandler(this.numUD_width_ValueChanged);
            // 
            // textBox_outputFolderPath
            // 
            this.textBox_outputFolderPath.Location = new System.Drawing.Point(15, 191);
            this.textBox_outputFolderPath.Name = "textBox_outputFolderPath";
            this.textBox_outputFolderPath.ReadOnly = true;
            this.textBox_outputFolderPath.Size = new System.Drawing.Size(355, 20);
            this.textBox_outputFolderPath.TabIndex = 4;
            this.toolTip_main.SetToolTip(this.textBox_outputFolderPath, "Path of the output folder");
            this.textBox_outputFolderPath.TextChanged += new System.EventHandler(this.textBox_outputFolderPath_TextChanged);
            // 
            // label_outputFolder
            // 
            this.label_outputFolder.AutoSize = true;
            this.label_outputFolder.Location = new System.Drawing.Point(15, 174);
            this.label_outputFolder.Name = "label_outputFolder";
            this.label_outputFolder.Size = new System.Drawing.Size(78, 13);
            this.label_outputFolder.TabIndex = 3;
            this.label_outputFolder.Text = "Output Folder:";
            // 
            // radioButton_flat
            // 
            this.radioButton_flat.AutoSize = true;
            this.radioButton_flat.Checked = true;
            this.radioButton_flat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.radioButton_flat.Location = new System.Drawing.Point(18, 12);
            this.radioButton_flat.Name = "radioButton_flat";
            this.radioButton_flat.Size = new System.Drawing.Size(85, 17);
            this.radioButton_flat.TabIndex = 7;
            this.radioButton_flat.TabStop = true;
            this.radioButton_flat.Text = "Flat Resizing";
            this.radioButton_flat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip_main.SetToolTip(this.radioButton_flat, "Resize images by giving fixed values for width and height");
            this.radioButton_flat.UseVisualStyleBackColor = true;
            this.radioButton_flat.CheckedChanged += new System.EventHandler(this.radioButton_flat_CheckedChanged);
            // 
            // radioButton_percentage
            // 
            this.radioButton_percentage.AutoSize = true;
            this.radioButton_percentage.Location = new System.Drawing.Point(248, 12);
            this.radioButton_percentage.Name = "radioButton_percentage";
            this.radioButton_percentage.Size = new System.Drawing.Size(122, 17);
            this.radioButton_percentage.TabIndex = 7;
            this.radioButton_percentage.TabStop = true;
            this.radioButton_percentage.Text = "Percentage Resizing";
            this.toolTip_main.SetToolTip(this.radioButton_percentage, "Resize images by giving percentage values relative to the original width and heig" +
        "ht\r\n");
            this.radioButton_percentage.UseVisualStyleBackColor = true;
            this.radioButton_percentage.CheckedChanged += new System.EventHandler(this.radioButton_percentage_CheckedChanged);
            // 
            // button_start
            // 
            this.button_start.Image = global::ImageResizer.Properties.Resources.accept_button;
            this.button_start.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_start.Location = new System.Drawing.Point(374, 235);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(100, 23);
            this.button_start.TabIndex = 6;
            this.button_start.Text = "Start";
            this.toolTip_main.SetToolTip(this.button_start, "Start resizing images and saving them to the output folder");
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_cancel.Image = global::ImageResizer.Properties.Resources.cancel;
            this.button_cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_cancel.Location = new System.Drawing.Point(268, 235);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(100, 23);
            this.button_cancel.TabIndex = 8;
            this.button_cancel.Text = "Cancel";
            this.toolTip_main.SetToolTip(this.button_cancel, "Close this window");
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // button_selectOutputFolder
            // 
            this.button_selectOutputFolder.Image = global::ImageResizer.Properties.Resources.folder;
            this.button_selectOutputFolder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_selectOutputFolder.Location = new System.Drawing.Point(374, 190);
            this.button_selectOutputFolder.Name = "button_selectOutputFolder";
            this.button_selectOutputFolder.Size = new System.Drawing.Size(100, 23);
            this.button_selectOutputFolder.TabIndex = 5;
            this.button_selectOutputFolder.Text = "Select";
            this.toolTip_main.SetToolTip(this.button_selectOutputFolder, "Select the folder where to save the resulting images");
            this.button_selectOutputFolder.UseVisualStyleBackColor = true;
            this.button_selectOutputFolder.Click += new System.EventHandler(this.button_selectOutputFolder_Click);
            // 
            // Form_Resize
            // 
            this.AcceptButton = this.button_start;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_cancel;
            this.ClientSize = new System.Drawing.Size(489, 271);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.radioButton_percentage);
            this.Controls.Add(this.radioButton_flat);
            this.Controls.Add(this.button_start);
            this.Controls.Add(this.checkBox_keepAspectRatio);
            this.Controls.Add(this.groupBox_percentage);
            this.Controls.Add(this.groupBox_flat);
            this.Controls.Add(this.button_selectOutputFolder);
            this.Controls.Add(this.textBox_outputFolderPath);
            this.Controls.Add(this.label_outputFolder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Resize";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Resize Images";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Resize_FormClosing);
            this.groupBox_percentage.ResumeLayout(false);
            this.groupBox_percentage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_heightPc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_widthPc)).EndInit();
            this.groupBox_flat.ResumeLayout(false);
            this.groupBox_flat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_height)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_width)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox_keepAspectRatio;
        private System.Windows.Forms.GroupBox groupBox_percentage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_widthPc;
        private System.Windows.Forms.Label label_heightPc;
        private System.Windows.Forms.NumericUpDown numUD_heightPc;
        private System.Windows.Forms.NumericUpDown numUD_widthPc;
        private System.Windows.Forms.GroupBox groupBox_flat;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label_width;
        private System.Windows.Forms.Label label_height;
        private System.Windows.Forms.NumericUpDown numUD_height;
        private System.Windows.Forms.NumericUpDown numUD_width;
        private System.Windows.Forms.Button button_selectOutputFolder;
        private System.Windows.Forms.TextBox textBox_outputFolderPath;
        private System.Windows.Forms.Label label_outputFolder;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.RadioButton radioButton_flat;
        private System.Windows.Forms.RadioButton radioButton_percentage;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.ToolTip toolTip_main;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog_main;
    }
}