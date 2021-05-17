using System.ComponentModel;

namespace ImageResizer
{
    public static partial class API
    {
        public static void ReportProgressAsPercentage(this BackgroundWorker backgroundWorker, 
            int flat, int total, object userState = null)
        {
            int progressPercentage = flat.ToPercentage(total);
            backgroundWorker.ReportProgress(progressPercentage, userState);
        }
    }
}
