using CleanCode.CommonClass;
using CleanCode.Const;

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

                CleanupOldFilesInFolderAfterManyDays(Constants.DAY_CLEAN_UP_FILE);
            }
        }

        private void CleanupOldFilesInFolderAfterManyDays(int days)
        {
            try
            {
                if (!Directory.Exists(_folderPath))
                {
                    CmFunc.Log("ImageCleanupImage", "CleanupOldFiles", $"Directory does not exist: {_folderPath}");
                    return;
                }

                var files = Directory.EnumerateFiles(_folderPath ?? "");

                foreach (var file in files)
                {
                    var fileInfo = new FileInfo(file);

                    if (DateTime.Now - fileInfo.CreationTime > TimeSpan.FromDays(days))
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
