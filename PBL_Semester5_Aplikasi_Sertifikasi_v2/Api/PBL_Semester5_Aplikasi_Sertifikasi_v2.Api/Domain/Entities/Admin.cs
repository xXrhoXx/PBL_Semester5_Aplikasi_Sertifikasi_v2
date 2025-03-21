using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PBL_Semester5_Aplikasi_Sertifikasi_v2.Api.Domain.Entities
{
    [Table("admin")]
    public record Admin
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
