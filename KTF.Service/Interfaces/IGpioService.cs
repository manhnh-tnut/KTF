using KTF.Shared.Models;

namespace KTF.Service.Interfaces
{
    public interface IGpioService
    {
        void Write(Item item);
        Task WriteAsync(Item item, int delay = 2000, int times = 1);
        List<Item> Read();
        Item[] GetOutputs();
    }
}
