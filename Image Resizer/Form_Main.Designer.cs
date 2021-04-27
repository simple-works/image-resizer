namespace ImageResizer
{
    partial class Form_Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            this.comboBox_view = new System.Windows.Forms.ComboBox();
            this.button_add = new System.Windows.Forms.Button();
            this.listView_main = new System.Windows.Forms.ListView();
            this.imageList_main = new System.Windows.Forms.ImageList(this.components);
            this.button_about = new System.Windows.Forms.Button();
            this.button_resize = new System.Windows.Forms.Button();
            this.imageList_backup = new System.Windows.Forms.ImageList(this.components);
            this.button_clear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBox_view
            // 
            this.comboBox_view.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_view.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_view.FormattingEnabled = true;
            this.comboBox_view.Location = new System.Drawing.Point(451, 12);
            this.comboBox_view.Name = "comboBox_view";
            this.comboBox_view.Size = new System.Drawing.Size(121, 21);
            this.comboBox_view.TabIndex = 8;
            this.comboBox_view.SelectedIndexChanged += new System.EventHandler(this.comboBox_view_SelectedIndexChanged);
            // 
            // button_add
            // 
            this.button_add.Location = new System.Drawing.Point(12, 10);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(75, 23);
            this.button_add.TabIndex = 7;
            this.button_add.Text = "Add";
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.button_add_Click);
            // 
            // listView_main
            // 
            this.listView_main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView_main.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView_main.LargeImageList = this.imageList_main;
            this.listView_main.Location = new System.Drawing.Point(12, 41);
            this.listView_main.Name = "listView_main";
            this.listView_main.Size = new System.Drawing.Size(560, 280);
            this.listView_main.SmallImageList = this.imageList_main;
            this.listView_main.TabIndex = 6;
            this.listView_main.UseCompatibleStateImageBehavior = false;
            this.listView_main.View = System.Windows.Forms.View.Details;
            this.listView_main.SelectedIndexChanged += new System.EventHandler(this.listView_main_SelectedIndexChanged);
            // 
            // imageList_main
            // 
            this.imageList_main.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList_main.ImageSize = new System.Drawing.Size(32, 32);
            this.imageList_main.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // button_about
            // 
            this.button_about.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_about.Location = new System.Drawing.Point(12, 327);
            this.button_about.Name = "button_about";
            this.button_about.Size = new System.Drawing.Size(30, 23);
            this.button_about.TabIndex = 12;
            this.button_about.Text = "?";
            this.button_about.UseVisualStyleBackColor = true;
            this.button_about.Click += new System.EventHandler(this.button_about_Click);
            // 
            // button_resize
            // 
            this.button_resize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_resize.Location = new System.Drawing.Point(497, 327);
            this.button_resize.Name = "button_resize";
            this.button_resize.Size = new System.Drawing.Size(75, 23);
            this.button_resize.TabIndex = 13;
            this.button_resize.Text = "Resize";
            this.button_resize.UseVisualStyleBackColor = true;
            this.button_resize.Click += new System.EventHandler(this.button_resize_Click);
            // 
            // imageList_backup
            // 
            this.imageList_backup.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList_backup.ImageSize = new System.Drawing.Size(256, 256);
            this.imageList_backup.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // button_clear
            // 
            this.button_clear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_clear.Location = new System.Drawing.Point(370, 10);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(75, 23);
            this.button_clear.TabIndex = 14;
            this.button_clear.Text = "Clear";
            this.button_clear.UseVisualStyleBackColor = true;
            this.button_clear.Click += new System.EventHandler(this.button_clear_Click);
            // 
            // Form_Main
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 362);
            this.Controls.Add(this.button_clear);
            this.Controls.Add(this.button_resize);
            this.Controls.Add(this.button_about);
            this.Controls.Add(this.comboBox_view);
            this.Controls.Add(this.button_add);
            this.Controls.Add(this.listView_main);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "Form_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Image Resize";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Main_FormClosing);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form_Main_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form_Main_DragEnter);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_view;
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.ListView listView_main;
        private System.Windows.Forms.Button button_about;
        private System.Windows.Forms.ImageList imageList_main;
        private System.Windows.Forms.Button button_resize;
        private System.Windows.Forms.ImageList imageList_backup;
        private System.Windows.Forms.Button button_clear;


    }
}