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
            this.listView_main = new System.Windows.Forms.ListView();
            this.imageList_main = new System.Windows.Forms.ImageList(this.components);
            this.toolTip_main = new System.Windows.Forms.ToolTip(this.components);
            this.button_resize = new System.Windows.Forms.Button();
            this.button_clear = new System.Windows.Forms.Button();
            this.button_view = new System.Windows.Forms.Button();
            this.button_remove = new System.Windows.Forms.Button();
            this.button_about = new System.Windows.Forms.Button();
            this.button_add = new System.Windows.Forms.Button();
            this.button_imagesCount = new System.Windows.Forms.Button();
            this.openFileDialog_main = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // comboBox_view
            // 
            this.comboBox_view.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_view.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_view.FormattingEnabled = true;
            this.comboBox_view.Location = new System.Drawing.Point(472, 14);
            this.comboBox_view.Name = "comboBox_view";
            this.comboBox_view.Size = new System.Drawing.Size(100, 21);
            this.comboBox_view.TabIndex = 8;
            this.toolTip_main.SetToolTip(this.comboBox_view, "Change the view of the list");
            this.comboBox_view.SelectedIndexChanged += new System.EventHandler(this.comboBox_view_SelectedIndexChanged);
            // 
            // listView_main
            // 
            this.listView_main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView_main.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView_main.LargeImageList = this.imageList_main;
            this.listView_main.Location = new System.Drawing.Point(12, 42);
            this.listView_main.Name = "listView_main";
            this.listView_main.Size = new System.Drawing.Size(560, 278);
            this.listView_main.SmallImageList = this.imageList_main;
            this.listView_main.TabIndex = 6;
            this.listView_main.UseCompatibleStateImageBehavior = false;
            this.listView_main.View = System.Windows.Forms.View.Details;
            this.listView_main.SelectedIndexChanged += new System.EventHandler(this.listView_main_SelectedIndexChanged);
            this.listView_main.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView_main_MouseDoubleClick);
            // 
            // imageList_main
            // 
            this.imageList_main.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList_main.ImageSize = new System.Drawing.Size(256, 256);
            this.imageList_main.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // button_resize
            // 
            this.button_resize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_resize.Image = global::ImageResizer.Properties.Resources.resize_picture;
            this.button_resize.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_resize.Location = new System.Drawing.Point(472, 326);
            this.button_resize.Name = "button_resize";
            this.button_resize.Size = new System.Drawing.Size(100, 23);
            this.button_resize.TabIndex = 13;
            this.button_resize.Text = "Resize";
            this.toolTip_main.SetToolTip(this.button_resize, "Resize all images in the list");
            this.button_resize.UseVisualStyleBackColor = true;
            this.button_resize.Click += new System.EventHandler(this.button_resize_Click);
            // 
            // button_clear
            // 
            this.button_clear.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_clear.Image = global::ImageResizer.Properties.Resources.cross;
            this.button_clear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_clear.Location = new System.Drawing.Point(224, 13);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(100, 23);
            this.button_clear.TabIndex = 14;
            this.button_clear.Text = "Clear";
            this.toolTip_main.SetToolTip(this.button_clear, "Remove all images from the list");
            this.button_clear.UseVisualStyleBackColor = true;
            this.button_clear.Click += new System.EventHandler(this.button_clear_Click);
            // 
            // button_view
            // 
            this.button_view.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_view.Image = global::ImageResizer.Properties.Resources.eye;
            this.button_view.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_view.Location = new System.Drawing.Point(366, 13);
            this.button_view.Name = "button_view";
            this.button_view.Size = new System.Drawing.Size(100, 23);
            this.button_view.TabIndex = 16;
            this.button_view.Text = "View";
            this.toolTip_main.SetToolTip(this.button_view, "View selected image");
            this.button_view.UseVisualStyleBackColor = true;
            this.button_view.Click += new System.EventHandler(this.button_view_Click);
            // 
            // button_remove
            // 
            this.button_remove.Image = global::ImageResizer.Properties.Resources.delete;
            this.button_remove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_remove.Location = new System.Drawing.Point(118, 13);
            this.button_remove.Name = "button_remove";
            this.button_remove.Size = new System.Drawing.Size(100, 23);
            this.button_remove.TabIndex = 15;
            this.button_remove.Text = "Remove";
            this.toolTip_main.SetToolTip(this.button_remove, "Remove selected images from the list");
            this.button_remove.UseVisualStyleBackColor = true;
            this.button_remove.Click += new System.EventHandler(this.button_remove_Click);
            // 
            // button_about
            // 
            this.button_about.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_about.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_about.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.button_about.FlatAppearance.BorderSize = 0;
            this.button_about.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_about.Image = global::ImageResizer.Properties.Resources.help;
            this.button_about.Location = new System.Drawing.Point(12, 326);
            this.button_about.Name = "button_about";
            this.button_about.Size = new System.Drawing.Size(25, 23);
            this.button_about.TabIndex = 12;
            this.toolTip_main.SetToolTip(this.button_about, "About");
            this.button_about.UseVisualStyleBackColor = true;
            this.button_about.Click += new System.EventHandler(this.button_about_Click);
            // 
            // button_add
            // 
            this.button_add.Image = global::ImageResizer.Properties.Resources.add;
            this.button_add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_add.Location = new System.Drawing.Point(12, 13);
            this.button_add.Name = "button_add";
            this.button_add.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button_add.Size = new System.Drawing.Size(100, 23);
            this.button_add.TabIndex = 7;
            this.button_add.Text = "Add";
            this.toolTip_main.SetToolTip(this.button_add, "Add images to the list");
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.button_add_Click);
            // 
            // button_imagesCount
            // 
            this.button_imagesCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_imagesCount.AutoSize = true;
            this.button_imagesCount.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.button_imagesCount.FlatAppearance.BorderSize = 0;
            this.button_imagesCount.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.button_imagesCount.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.button_imagesCount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_imagesCount.Image = global::ImageResizer.Properties.Resources.image;
            this.button_imagesCount.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_imagesCount.Location = new System.Drawing.Point(366, 326);
            this.button_imagesCount.Name = "button_imagesCount";
            this.button_imagesCount.Size = new System.Drawing.Size(100, 23);
            this.button_imagesCount.TabIndex = 18;
            this.button_imagesCount.Text = "0 images";
            this.button_imagesCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_imagesCount.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip_main.SetToolTip(this.button_imagesCount, "Number of images in the list");
            this.button_imagesCount.UseVisualStyleBackColor = true;
            // 
            // openFileDialog_main
            // 
            this.openFileDialog_main.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.gif; *.bmp)|*.jpg; *.jpeg; *.png; *.gif; *.b" +
    "mp";
            this.openFileDialog_main.Multiselect = true;
            // 
            // Form_Main
            // 
            this.AcceptButton = this.button_resize;
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_clear;
            this.ClientSize = new System.Drawing.Size(584, 362);
            this.Controls.Add(this.button_imagesCount);
            this.Controls.Add(this.button_view);
            this.Controls.Add(this.button_remove);
            this.Controls.Add(this.button_clear);
            this.Controls.Add(this.button_resize);
            this.Controls.Add(this.button_about);
            this.Controls.Add(this.comboBox_view);
            this.Controls.Add(this.button_add);
            this.Controls.Add(this.listView_main);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "Form_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Image Resize";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Main_FormClosing);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form_Main_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form_Main_DragEnter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_view;
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.ListView listView_main;
        private System.Windows.Forms.Button button_about;
        private System.Windows.Forms.ImageList imageList_main;
        private System.Windows.Forms.Button button_resize;
        private System.Windows.Forms.Button button_clear;
        private System.Windows.Forms.Button button_remove;
        private System.Windows.Forms.Button button_view;
        private System.Windows.Forms.ToolTip toolTip_main;
        private System.Windows.Forms.OpenFileDialog openFileDialog_main;
        private System.Windows.Forms.Button button_imagesCount;


    }
}