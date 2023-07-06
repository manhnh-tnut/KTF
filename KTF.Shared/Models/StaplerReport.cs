using System.ComponentModel.DataAnnotations.Schema;

namespace KTF.Shared.Models
{
    public class StaplerReport
    {
        public StaplerReport()
        {
            Id = Guid.NewGuid();
            Created = DateTime.Now;
        }
        public Guid Id { get; set; }
        public string Line { get; set; }
        public string Model { get; set; }
        public string Code { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public string Creater { get; set; }
        public string? Updater { get; set; }
        public int Ok { get; set; }
        public int Ng { get; set; }

        [NotMapped]
        public int Total { get => Ok + Ng; }
        [NotMapped]
        public float? OkRate { get => Total == 0 ? 0f : 1.0f * Ok / Total; }
        [NotMapped]
        public float? NgRate { get => Total == 0 ? 0f : 1.0f * Ng / Total; }
    }
}
