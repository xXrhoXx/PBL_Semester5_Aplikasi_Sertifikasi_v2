using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MauiAccessorApp2.Models.Entities
{
    public class Pertanyaan
    {
        public int id { get; set; }
        public string text { get; set; }
        public int questionsId { get; set; }
    }
}
