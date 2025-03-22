using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PBL_Semester5_Aplikasi_Sertifikasi_v2.Api.Domain.Entities
{
    [Table("sesi_assessment")]
    public record AssessmentSession
    {
        [Key]
        [Required]
        [Column("id sesi assessment")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AssessmentSessionId { get; init; }
    }
}
