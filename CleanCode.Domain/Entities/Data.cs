using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CleanCode.Domain.Entities
{
    [Table("data")]
    public class Data : BaseEntity
    {
        [Column("time")]
        public DateTime? Time { get; set; } = DateTime.UtcNow.AddHours(7);

        [Column("model"), MaxLength(255)]
        public string? Model { get; set; } = string.Empty;

        [Column("client_id")]
        public int? ClientId { get; set; }

        [Column("index")]
        public int? Index { get; set; }

        [Column("timeline")]
        public string? TimeLine { get; set; }
    }
}
