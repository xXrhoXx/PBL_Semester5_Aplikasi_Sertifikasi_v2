using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PBL_Semester5_Aplikasi_Sertifikasi_v2.AccessorApp.Models.Entities
{
    public class Pertanyaan
    {
        public int id { get; set; }
        public string text { get; set; }
        public int questionsId { get; set; }
    }
}
