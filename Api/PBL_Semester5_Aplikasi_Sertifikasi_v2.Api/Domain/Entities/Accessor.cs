using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PBL_Semester5_Aplikasi_Sertifikasi_v2.Api.Domain.Entities
{

    [Table("accessor")]
    public record Accessor
    {
        [Key]
        [Required]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; init; }

        [Required]
        [Column("nama")]
        [MaxLength(50)]
        public string? Nama { get; init; }

        [Column("alamat")]
        [MaxLength(100)]
        public string? Alamat { get; init; }

        [Column("email")]
        [Required]
        [MaxLength(100)]
        public string? Email { get; init; }

        [Column("password")]
        [Required]
        [MaxLength(100)]
        public string? Password { get; init; }
    }
}
