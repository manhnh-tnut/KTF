using Microsoft.Extensions.Options;
using KTF.Shared.Models;
using KTF.Service.Interfaces;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace KTF.Service
{
    public class UartService : IUartService
    {
        private readonly Setting _settings;
        private readonly ILogger<UartService> _logger;
        private readonly List<SafeSerialPort> _serialPorts;
        public event Action<string> EventDataReceived = delegate { };
        public UartService(IOptions<Setting> settings, ILogger<UartService> logger)
        {
            _settings = settings?.Value;
            _logger = logger;

            _logger.LogInformation("*************INIT SERIAL PORT*************");
            if (_settings != null && _settings.SerialPorts != null)
            {
                _serialPorts = new List<SafeSerialPort>();
                foreach (SerialPortModel serial in _settings.SerialPorts)
                {
                    byte[] bytes = serial.Data.Split('-').Select(i => Convert.ToByte(i, 16)).ToArray();
                    SafeSerialPort serialPort = new SafeSerialPort()
                    {
                        Name = serial.Name,
                        Data = bytes,
                        BaudRate = serial.BaudRate,
                        PortName = serial.PortName,
                        IsActive = serial.IsActive,
                    };
                    serialPort.DataReceived += SerialPort_DataReceived;

                    _serialPorts.Add(serialPort);
                };
            }
            _logger.LogInformation("*************INIT SERIAL PORT DONE*************");
        }

        public void Open()
        {
            foreach (var _serialPort in _serialPorts)
            {
                if (_serialPort == null || _serialPort.IsOpen || !_serialPort.IsActive)
                {
                    return;
                }
                if (System.IO.Ports.SerialPort.GetPortNames().Contains(_serialPort.PortName))
                {
                    _logger.LogInformation($"*********OPEN {_serialPort.PortName}*********");
                    try
                    {
                        _serialPort.Open();
                    }
                    catch (Exception e)
                    {
                        _logger.LogError(e.InnerException?.Message ?? e.Message);
                    }
                }
                else
                {
                    _logger.LogError($"{_serialPort.PortName} Not found!\r\n{string.Join(",", System.IO.Ports.SerialPort.GetPortNames())}");
                }

            }
        }

        private void SerialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            var serialPort = (SafeSerialPort)sender;
            EventDataReceived(JsonSerializer.Serialize(new { Name = serialPort.Name, Data = serialPort.ReadExisting() }));
        }

        public void Write(string name)
        {
            var _serialPort = _serialPorts.Find(x => x.Name == name);
            if (_serialPort == null) { return; }
            if (_serialPort.IsOpen && _serialPort.IsActive)
            {
                try
                {
                    _logger.LogInformation($"**********WRITE DATA TO '{name}'**********");
                    _serialPort.Write(_serialPort.Data, 0, _serialPort.Data.Length);
                    _logger.LogInformation($"**********SUCCESS**********");
                }
                catch (Exception e)
                {
                    _logger.LogError(e.InnerException?.Message ?? e.Message);
                }
            }
        }
    }
}