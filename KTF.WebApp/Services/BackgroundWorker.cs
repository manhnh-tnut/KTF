using Microsoft.AspNetCore.SignalR;
using KTF.WebApp.Hubs;
using KTF.WebApp.Hubs.Interfaces;
using KTF.Service.Interfaces;

namespace KTF.WebApp.Services
{
    public class BackgroundWorker : BackgroundService
    {
        private readonly ILogger<BackgroundService> _logger;
        private readonly IHubContext<MonitorHub, IMonitorHub> _hub;
        private readonly IGpioService _gpioService;
        private readonly IUartService _uartService;

        public BackgroundWorker(ILogger<BackgroundService> logger,
                            IHubContext<MonitorHub, IMonitorHub> hub,
                            IGpioService gpioService,
                            IUartService uartService)
        {
            _logger = logger;
            _hub = hub;
            _gpioService = gpioService;
            _uartService = uartService;
            _uartService.EventDataReceived += DataReceived;
        }

        private async void DataReceived(string data)
        {
            _logger.LogInformation($"DataReceived: {data}");
            await _hub.Clients.All.UartResponse(data);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _uartService.Open();
                await _hub.Clients.All.GpioResponse(Newtonsoft.Json.JsonConvert.SerializeObject(_gpioService.Read()));
                await Task.Delay(10, stoppingToken);
            }
        }
    }
}