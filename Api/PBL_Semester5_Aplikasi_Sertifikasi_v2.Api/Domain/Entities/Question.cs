using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PBL_Semester5_Aplikasi_Sertifikasi_v2.Api.Domain.Entities
{
    [Table("pertanyaan")]
    public record Question
    {
        [Key]
        [Required]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column("text")]
        public string? Text { get; set; }

        [Required]
        [Column("id soal")]
        public int QuestionsId { get; set; }
    }
}
