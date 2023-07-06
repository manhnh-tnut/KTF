namespace KTF.Shared.Models
{
    public class Setting
    {
        public Item[] Inputs { get; set; }
        public Item[] Outputs { get; set; }
        public SerialPortModel[] SerialPorts { get; set; }
        public int Delay { get; set; }
        public int Sensor { get; set; }
        public float Minimum { get; set; }
        public string Password { get; set; }
    }
}
