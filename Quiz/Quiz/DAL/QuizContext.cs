using Microsoft.EntityFrameworkCore;
using Quiz.DTO;

namespace Quiz.DAL
{
    public class QuizContext : DbContext
    {

        public QuizContext(DbContextOptions options) : base(options) { }
        public DbSet<Question> Question { get; set; }
        public DbSet<Answer> Answer { get; set; }
        public DbSet<UserSession> UserSession { get; set; }
        public DbSet<DetailUserSession> DetailUserSession { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
   
}
