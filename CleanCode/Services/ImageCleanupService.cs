using CleanCode.CommonClass;

namespace CleanCode.Services
{
    public class ImageCleanupService : BackgroundService
    {
        private readonly string? _folderPath;

        public ImageCleanupService(string? folderPath)
        {
            _folderPath = folderPath;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(TimeSpan.FromHours(3), stoppingToken);

                CleanupOldFiles();
            }
        }

        private void CleanupOldFiles()
        {
            try
            {
                string[] files = Directory.GetFiles(_folderPath ?? "");

                foreach (var file in files)
                {
                    var fileInfo = new FileInfo(file);

                    if (DateTime.Now - fileInfo.CreationTime > TimeSpan.FromDays(15))
                    {
                        File.Delete(file);
                    }
                }

                CmFunc.Log("Delete file old successfully!");
            }
            catch (Exception ex)
            {
                CmFunc.Log("ImageCleanupImage", "CleanupOldFiles", ex.Message);
            }
        }
    }
}
