using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CleanCode.Domain.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Column("created_at")]
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow.AddHours(7);

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow.AddHours(7);

        [Column("created_by")]
        [MaxLength(255)]
        public string? CreatedBy { get; set; } = string.Empty;

        [Column("updated_by")]
        [MaxLength(255)]
        public string? UpdatedBy { get; set; } = string.Empty;
    }
}
