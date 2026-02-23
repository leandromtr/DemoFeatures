
namespace BackgroundDemo
{
    public class BackgroundRefresh : IHostedService, IDisposable
    {
        private Timer? _timer;
        private readonly SampleData _sampleData;

        public BackgroundRefresh(SampleData sampleData)
        {
            _sampleData = sampleData;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(AddToCache, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
            return Task.CompletedTask;
        }

        private void AddToCache(object? state)
        {
            _sampleData.Data.Add($"The new data was added at {DateTime.Now.ToLongTimeString()}");
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
