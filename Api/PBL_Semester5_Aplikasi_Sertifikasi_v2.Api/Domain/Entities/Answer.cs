using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PBL_Semester5_Aplikasi_Sertifikasi_v2.Api.Domain.Entities
{
    [Table("jawaban_peserta_assessi")]
    public record Answer
    {
        [Key]
        [Required]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column("jawaban assessment")]
        public string? AssessmentAnswer { get; set; }

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
        [Column("id pertanyaan")]
        public int QuestionId { get; set; }

        [Column("file")]
        public string? FilePath { get; set; }
    }
}
