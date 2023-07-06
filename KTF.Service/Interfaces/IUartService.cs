using KTF.Shared.Models;

namespace KTF.Service.Interfaces
{
    public interface IUartService
    {
        void Write(string name);
        void Open();
        event Action<string> EventDataReceived;
    }
}
