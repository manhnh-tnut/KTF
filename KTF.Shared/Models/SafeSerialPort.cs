using System.IO.Ports;

namespace KTF.Shared.Models
{
    public class SafeSerialPort : SerialPort
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public byte[] Data { get; set; }

        public new void Open()
        {
            if (!base.IsOpen)
            {
                base.Open();
                GC.SuppressFinalize(this.BaseStream);
            }
        }

        public new void Close()
        {
            if (base.IsOpen)
            {
                GC.ReRegisterForFinalize(this.BaseStream);
                base.Close();
            }
        }

        protected override void Dispose(bool disposing)
        {
            try
            {
                base.Dispose(disposing);
            }
            catch 
            {
                throw;
            }

        }
    }
}
