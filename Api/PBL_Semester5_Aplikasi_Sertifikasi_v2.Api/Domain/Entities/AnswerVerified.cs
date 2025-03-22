using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PBL_Semester5_Aplikasi_Sertifikasi_v2.Api.Domain.Entities
{
    [Table("jawaban_peserta_assessi_terverifikasi")]
    public record AnswerVerified
    {
        [Key]
        [Required]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column("rekomendasi")]
        public string? Rekomendasi { get; set; }

        [Required]
        [Column("tanggapan")]
        public string? Tanggapan { get; set; }

        [Required]
        [Column("pertanyaan")]
        public string? Question { get; set; }

        [Required]
        [Column("jawaban")]
        public string? Answer { get; set; }

        [Required]
        [Column("id assessi")]
        public int AccessedId { get; set; }

        [Required]
        [Column("id assessor")]
        public int AccessorId { get; set; }

        [Required]
        [Column("id soal")]
        public int QuestionsId { get; set; }

        [Required]
        [Column("id sesi assessment")]
        public int AssessmentSessionId { get; set; }

        [Column("file")]
        public string? FilePath { get; set; }
    }
}
