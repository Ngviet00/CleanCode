using CleanCode.Common;
using Microsoft.Extensions.Hosting;

namespace CleanCode.Application.Jobs
{
    public class DeleteFileLog : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(TimeSpan.FromHours(2), stoppingToken);
                DeleteLog();
            }
        }

        private static void DeleteLog()
        {
            DateTime thresholdDate = DateTime.Now.Subtract(TimeSpan.FromDays(20));

            string folderLog = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");

            if (!Directory.Exists(folderLog))
            {
                Log.Error("Not exists path folder log!");
                return;
            }

            string[] files = Directory.GetFiles(folderLog, "*.txt");

            foreach (string file in files)
            {
                var fileInfo = new FileInfo(file);

                try
                {
                    if (fileInfo.CreationTime < thresholdDate)
                    {
                        File.Delete(file);
                    }
                }
                catch (Exception ex)
                {
                    Log.Error("DeleteFileLog", "DeleteLog", ex.Message);
                }
            }

            Log.Info("Delete file log success");
        }
    }
}
