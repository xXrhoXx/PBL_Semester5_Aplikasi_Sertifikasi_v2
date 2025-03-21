using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PBL_Semester5_Aplikasi_Sertifikasi_v2.Api.Domain.Entities
{
    [Table("soal")]
    public record Questions
    {
        [Key]
        [Required]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column("judul")]
        public string? Title { get; set; }

        [Required]
        [Column("Deskripsi")]
        public string? Description { get; set; }

        [Required]
        [Column("id accessor")]
        public int AccessorId { get; set; }
    }
}
