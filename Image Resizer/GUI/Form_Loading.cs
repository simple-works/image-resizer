using System;
using System.Windows.Forms;

namespace ImageResizer
{
    public partial class Form_Loading : Form
    {
        private static Form_Loading s_singleton;
        public static Form_Loading Singleton
        {
            get
            {
                if (s_singleton == null || s_singleton.IsDisposed)
                {
                    s_singleton = new Form_Loading();
                }
                return s_singleton;
            }
        }
        public string Title
        {
            get { return label_title.Text; }
            set { label_title.Text = value; }
        }
        public int ProgressPercentage
        {
            get { return progressBar_main.Value; }
        }
        public Action CancelProgress;

        public Form_Loading()
        {
            InitializeComponent();
        }

        public DialogResult ShowDialog(string title, Action cancelProgress)
        {
            Title = title;
            CancelProgress = cancelProgress;
            return ShowDialog();
        }

        public void SetProgressPercentage(int percentage)
        {
            if (percentage >= progressBar_main.Minimum &&
                percentage <= progressBar_main.Maximum)
            {
                progressBar_main.Value = percentage;
                label_progressPercentage.Text = String.Format("{0}%", percentage);
            }
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form_Loading_FormClosing(object sender, FormClosingEventArgs e)
        {
            CancelProgress();
        }
    }
}
