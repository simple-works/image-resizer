using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace ImageResizer
{
    public partial class Form_Loading : Form
    {
        public string Title
        {
            get { return label_title.Text; }
            set { label_title.Text = value; }
        }
        public int ProgressPercentage
        {
            get { return progressBar_main.Value; }
        }
        public delegate void StartCallback(BackgroundWorker w, DoWorkEventArgs e);
        public delegate void ProgressCallback(BackgroundWorker w, ProgressChangedEventArgs e);
        public delegate void CompleteCallback(BackgroundWorker w, RunWorkerCompletedEventArgs e);
        public StartCallback Start;
        public ProgressCallback Progress;
        public CompleteCallback Complete;
        public Action Cancel;

        public Form_Loading()
        {
            InitializeComponent();
        }

        public static DialogResult Show(string title = "",
            StartCallback start = null,
            ProgressCallback progress = null,
            CompleteCallback complete = null,
            Action cancel = null)
        {
            Form_Loading loadingForm = new Form_Loading();
            loadingForm.Title = String.IsNullOrEmpty(title) ? loadingForm.Title : title;
            loadingForm.Start = start;
            loadingForm.Progress = progress;
            loadingForm.Complete = complete;
            loadingForm.Cancel = cancel;
            return loadingForm.ShowDialog();
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

        private void Form_Loading_Load(object sender, EventArgs e)
        {
            if (!backgroundWorker_main.IsBusy)
            {
                backgroundWorker_main.RunWorkerAsync();
            }
        }

        private void backgroundWorker_main_DoWork(object sender, DoWorkEventArgs e)
        {
            if (Start != null)
            {
                Start(sender as BackgroundWorker, e);
            }
        }

        private void backgroundWorker_main_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (Progress != null)
            {
                Progress(sender as BackgroundWorker, e);
            }
            SetProgressPercentage(e.ProgressPercentage);
        }

        private void backgroundWorker_main_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (Complete != null)
            {
                Complete(sender as BackgroundWorker, e);
            }
            this.Close();
        }

        private void Form_Loading_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (backgroundWorker_main.WorkerSupportsCancellation)
            {
                if (Cancel != null)
                {
                    Cancel();
                }
                backgroundWorker_main.CancelAsync();
            }
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
