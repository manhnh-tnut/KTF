using System.ComponentModel.DataAnnotations.Schema;

namespace KTF.Shared.Models
{
    public class StaplerHistory
    {
        public StaplerHistory()
        {
            Id = Guid.NewGuid();
            Created = DateTime.Now;
            IsCancelled = false;
        }
        public Guid Id { get; set; }
        public string Line { get; set; }
        public string Model { get; set; }
        public string Code { get; set; }
        public string CurrentCode { get; set; }
        public bool IsCancelled { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public string Creater { get; set; }
        public string? Updater { get; set; }

        [NotMapped]
        public Guid LineId { get; set; }

        [NotMapped]
        public string Name { get; set; }

        [NotMapped]
        public int Pin { get; set; }
    }
}
