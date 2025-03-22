using Microsoft.EntityFrameworkCore;
using PBL_Semester5_Aplikasi_Sertifikasi_v2.Api.Domain.Entities;

namespace PBL_Semester5_Aplikasi_Sertifikasi_v2.Api.Data
{
    public class DemoDbContext : DbContext
    {
        public DemoDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<Accessor> accessors { get; set; }
        public DbSet<Accessed> accesseds { get; set; }
        public DbSet<Admin> admins { get; set; }
        public DbSet<Questions> questions { get; set; }
        public DbSet<Question> question { get; set; }
        public DbSet<Answer> answer { get; set; }
        public DbSet<AnswerVerified> answerVerified { get; set; }
        public DbSet<Schedule> schedules { get; set; }
        public DbSet<AssessmentSession> assessmentSessions { get; set; }
    }
}
