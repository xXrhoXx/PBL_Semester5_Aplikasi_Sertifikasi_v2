using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PBL_Semester5_Aplikasi_Sertifikasi_v2.Api.Domain.Entities
{
    [Table("jadwal")] // Translates to "schedule" in Bahasa
    public record Schedule
    {
        [Key]
        [Required]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column("tanggal")] 
        public DateTime Date { get; set; }

        [Required]
        [Column("id Assessi")]
        public int AccessedId { get; set; }

        [Required]
        [Column("id Assessor")]
        public int AccessorID { get; set; }

        [Column("id Soal")]
        public int QuestionsId { get; set; } 
    }
}
