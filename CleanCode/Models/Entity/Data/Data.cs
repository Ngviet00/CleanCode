using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clean_Code.Models.Entity
{
    [Table("data")]
    public class Data : BaseEntity
    {
        [Column("time")]
        public DateTime? Time { get; set; }

        [Column("model"), MaxLength(255)]
        public string? Model { get; set; } = string.Empty;

        [Column("tray")]
        public int Tray { get; set; }

        [Column("client_id")]
        public int? ClientId { get; set; }

        [Column("side"), MaxLength(255)]
        public string? Side { get; set; } = string.Empty;

        [Column("index")]
        public int? Index { get; set; }

        [Column("camera"), MaxLength(255)]
        public string? Camera { get; set; } = string.Empty;

        [Column("result_area")]
        public int? ResultArea { get; set; }

        [Column("result_line")]
        public int? ResultLine { get; set; }

        [Column("timeline")]
        public string? TimeLine { get; set; }
    }
}
