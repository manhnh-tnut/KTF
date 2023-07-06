using System.ComponentModel.DataAnnotations.Schema;

namespace KTF.Shared.Models
{
    public class ScaleHistory
    {
        public ScaleHistory()
        {
            Id = Guid.NewGuid();
            Created = DateTime.Now;
        }
        public Guid Id { get; set; }
        public string Line { get; set; }
        public string Model { get; set; }
        public string Code { get; set; }
        public float Unit { get; set; }
        public int Quantity { get; set; }
        public float Minimum { get; set; }
        public float Maximun { get; set; }
        public float Weight { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public string Creater { get; set; }
        public string? Updater { get; set; }

        [NotMapped]
        public Guid LineId { get; set; }

        [NotMapped]
        public string Name { get; set; }
    }
}
