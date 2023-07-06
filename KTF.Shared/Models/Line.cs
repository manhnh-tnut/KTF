using System.ComponentModel.DataAnnotations.Schema;

namespace KTF.Shared.Models
{
    public class Line
    {
        public Line()
        {
            Id = Guid.NewGuid();
            Created = DateTime.Now;
            IsDeleted = false;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string Code { get; set; }
        public float? Unit { get; set; }
        public int? Quantity { get; set; }
        public float? Minimum { get; set; }
        public float? Maximun { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public string Creater { get; set; }
        public string? Updater { get; set; }
        public string Machine { get; set; }
        [NotMapped]
        public float? Total { get => Unit * Quantity; }
    }
}
