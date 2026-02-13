using Serilog.Core;

namespace PaybillAPI.Service
{
    public class DailyBackgroundService(ILogger<DailyBackgroundService> logger, IWebHostEnvironment webHostEnvironment) : BackgroundService
    {
        private static async Task ClearTemp(string tempPath)
        {
            if (!Directory.Exists(tempPath)) return;
            try
            {
                if (Directory.Exists(tempPath))
                {
                    DirectoryInfo directoryInfo = new(tempPath);
                    FileInfo[] files = directoryInfo.GetFiles().Where(p => p.CreationTime.Date < DateTime.Now.AddDays(-2).Date).ToArray();
                    foreach (FileInfo file in files)
                        file.Delete();
                }
                await Task.CompletedTask;
            }
            catch (Exception) { }
        }

        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    DateTime now = DateTime.UtcNow;

                    DateTime nextRun = now.Date.AddDays(1);

                    TimeSpan delay = nextRun - now;

                    if (delay < TimeSpan.Zero)
                        delay = TimeSpan.Zero;

                    await ClearTemp(System.IO.Path.Combine(webHostEnvironment.WebRootPath, "temp"));

                    await Task.Delay(delay, stoppingToken);
                }
                catch (OperationCanceledException ex)
                {
                    logger.LogError(ex, "Background Service Error: {Error}", ex.Message);
                    continue;
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "An error occurred in Background Service:{Error}", ex.Message);
                    TimeSpan delay = TimeSpan.FromMinutes(1);
                    if (logger.IsEnabled(LogLevel.Information))
                        logger.LogInformation("The Background Service has been rescheduled to | Local: {LocalTime} | UTC: {UtcTime}", TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow.Add(delay), TimeZoneInfo.Local), DateTime.UtcNow.Add(delay));
                    await Task.Delay(delay, stoppingToken);
                }
            }
        }
    }
}
