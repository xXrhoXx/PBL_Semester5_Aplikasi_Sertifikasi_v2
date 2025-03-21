namespace MauiAccessorApp.Models.Entities
{
    public class Jawaban
    {
        public int id { get; set; }
        public string? assessmentAnswer { get; set; }
        public int accessedId { get; set; }
        public int accessorId { get; set; }
        public int questionsId { get; set; }
        public int questionId { get; set; }
    }
}
