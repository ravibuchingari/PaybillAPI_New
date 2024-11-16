
using PaybillAPI.Data;
using PaybillAPI.Models;

namespace PaybillAPI.Service
{
    public class DailyBackgroundService(IServiceProvider serviceProvider) : BackgroundService
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
            catch (Exception){}
        }

        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using var scope = serviceProvider.CreateScope();
                IWebHostEnvironment webHostEnvironment = scope.ServiceProvider.GetRequiredService<IWebHostEnvironment>();
                await ClearTemp(System.IO.Path.Combine(webHostEnvironment.WebRootPath, "temp"));
                DateTime nextCycle = DateTime.Now.Date.AddDays(1);
                nextCycle = nextCycle.AddDays(1);
                nextCycle = new(nextCycle.Year, nextCycle.Month, nextCycle.Day, 1, 0, 0);
                await Task.Delay(nextCycle.TimeOfDay, stoppingToken);
            }
        }
    }
}
