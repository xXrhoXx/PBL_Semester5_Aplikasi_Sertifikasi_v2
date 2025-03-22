using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PBL_Semester5_Aplikasi_Sertifikasi_v2.AccessorApp.Models.Entities
{
    public class JawabanTerverifikasi
    {
        public int id { get; set; }
        public string Rekomendasi { get; set; }
        public string Tanggapan { get; set; }
        public string question { get; set; }
        public string answer { get; set; }
        public int accessedId { get; set; }
        public int accessorId { get; set; }
        public int questionsId { get; set; }
        public int AssessmentSessionId { get; set; }
        public string? filePath { get; set; }
    }
}
