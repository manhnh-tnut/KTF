namespace KTF.Shared.Models
{
    public class Machine
    {
        public Machine()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public string Creater { get; set; }
        public string? Updater { get; set; }
    }
}
