using Microsoft.AspNetCore.SignalR;
using KTF.WebApp.Hubs.Interfaces;
using KTF.Service.Interfaces;
using Microsoft.Extensions.Options;
using KTF.Shared.Models;

namespace KTF.WebApp.Hubs
{
    public class MonitorHub : Hub<IMonitorHub>
    {
        private readonly ILogger<MonitorHub> _logger;
        private readonly IGpioService _gpioService;
        private readonly IUartService _uartService;
        private readonly Setting _setting;

        public MonitorHub(ILogger<MonitorHub> logger,
            IOptions<Setting> setting,
            IGpioService gpioService,
            IUartService uartService)
        {
            _logger = logger;
            _gpioService = gpioService;
            _uartService = uartService;
            _setting = setting.Value;
        }

        public Task SendCommandToIO(string name, int delay, int times = 1)
        {
            var output = _setting.Outputs.Where(i => string.Equals(i.Name, name, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
            if (output != null)
            {
                _logger.LogInformation("***Send Command To IO***");
                return _gpioService.WriteAsync(output, delay, times);
            }

            return Task.CompletedTask;
        }

        public Task SendCommandToScanner()
        {
            var scanner = _setting.SerialPorts.Where(i => string.Equals(i.Name, "Scanner", StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
            if (scanner != null)
            {
                _logger.LogInformation("***Send Command To Scanner***");
                _uartService.Write(scanner.Name);
            }
            return Task.CompletedTask;
        }

        public Task SendCommandToWeight()
        {
            var weight = _setting.SerialPorts.Where(i => string.Equals(i.Name, "Weight", StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
            if (weight != null)
            {
                _logger.LogInformation("***Send Command To Weight***");
                _uartService.Write(weight.Name);
            }
            return Task.CompletedTask;
        }
    }
}
