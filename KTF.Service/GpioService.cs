using Microsoft.Extensions.Options;
using KTF.Shared.Models;
using System.Device.Gpio;
using KTF.Service.Interfaces;
using Microsoft.Extensions.Logging;
using System.Runtime.InteropServices;

namespace KTF.Service
{
    public class GpioService : IGpioService
    {
        private readonly Setting _settings;
        private readonly ILogger<GpioService> _logger;
        private readonly GpioController _controller;
        public GpioService(IOptions<Setting> settings, ILogger<GpioService> logger)
        {
            _settings = settings.Value;
            _logger = logger;

            if (!System.Diagnostics.Debugger.IsAttached && RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                _controller = new GpioController(PinNumberingScheme.Board);
                _logger.LogInformation("*************INIT GPIO*************");
                if (_settings != null)
                {
                    _logger.LogInformation("*************INIT INPUT GPIO*************");
                    try
                    {
                        for (int i = 0; i < _settings.Inputs.Length; i++)
                        {
                            Item input = _settings.Inputs[i];
                            if (_controller.IsPinModeSupported(input.Pin, PinMode.InputPullDown))
                            {
                                _controller.OpenPin(input.Pin, PinMode.InputPullDown);
                                input.Value = true;
                            }
                            else
                            {
                                throw new ArgumentException($"Pin {input.Pin} not support mode InputPullDown");
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        _logger.LogError(message: e.InnerException?.Message ?? e.Message);
                    }

                    _logger.LogInformation("*************INIT OUTPUT GPIO*************");
                    try
                    {
                        for (int i = 0; i < _settings.Outputs.Length; i++)
                        {
                            Item output = _settings.Outputs[i];
                            if (_controller.IsPinModeSupported(output.Pin, PinMode.Output))
                            {
                                _controller.OpenPin(output.Pin, PinMode.Output);
                                _controller.Write(output.Pin, PinValue.Low);
                                output.Value = false;
                            }
                            else
                            {
                                throw new ArgumentException($"Pin {output.Pin} not support mode Output");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex.InnerException?.Message ?? ex.Message);
                    }
                }
                _logger.LogInformation("*************INIT GPIO DONE*************");
            }
        }

        public void Write(Item item)
        {
            if (!System.Diagnostics.Debugger.IsAttached)
            {

                if (_settings.Outputs.Any(i => i.Name == item.Name && i.Pin == item.Pin))
                {
                    try
                    {
                        if (_controller.IsPinOpen(item.Pin))
                        {
                            _controller.Write(item.Pin, item.Value);
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex.InnerException?.Message ?? ex.Message);
                    }
                }
            }
        }

        public async Task WriteAsync(Item item, int delay = 2000, int times = 1)
        {
            if (!System.Diagnostics.Debugger.IsAttached)
            {
                if (_settings.Outputs.Any(i => i.Name == item.Name && i.Pin == item.Pin))
                {
                    try
                    {
                        if (_controller.IsPinOpen(item.Pin))
                        {
                            for (int i = 0; i < times;)
                            {
                                _controller.Write(item.Pin, PinValue.High);
                                await Task.Delay(delay);
                                _controller.Write(item.Pin, PinValue.Low);
                                if (++i != times)
                                {
                                    await Task.Delay(delay);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex.InnerException?.Message ?? ex.Message);
                    }
                }
            }
        }

        public List<Item> Read()
        {
            if (_settings == null)
            {
                return null;
            }
            if (!System.Diagnostics.Debugger.IsAttached)
            {
                foreach (var item in _settings.Inputs)
                {
                    try
                    {
                        if (_controller.IsPinOpen(item.Pin))
                        {
                            item.Value = Equals(_controller.Read(item.Pin), PinValue.High);
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex.InnerException?.Message ?? ex.Message);
                    }
                }
            }
            return _settings.Inputs.Union(_settings.Outputs).ToList();
        }

        public Item[] GetOutputs()
        {
            return _settings.Outputs;
        }
    }
}