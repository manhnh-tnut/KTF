namespace KTF.Shared.Models
{
    public class SerialPortModel
    {
        public string Name { get; set; }
        public string Data { get; set; }
        public string PortName { get; set; }
        public int BaudRate { get; set; }
        public bool IsActive { get; set; }
    }
}
