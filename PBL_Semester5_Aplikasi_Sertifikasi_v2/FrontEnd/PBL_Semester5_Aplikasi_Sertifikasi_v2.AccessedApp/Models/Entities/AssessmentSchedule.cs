namespace PBL_Semester5_Aplikasi_Sertifikasi_v2.AccessedApp.Models.Entities
{
    public class AssessmentSchedule
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int AccessedId { get; set; }
        public int AccessorID { get; set; }
        public int QuestionsId { get; set; }
    }
}
