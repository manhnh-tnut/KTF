namespace KTF.WebApp.Hubs.Interfaces
{
    public interface IMonitorHub
    {
        Task GpioResponse(string message);
        Task UartResponse(string message);
    }
}
