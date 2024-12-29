using Microsoft.EntityFrameworkCore;
using School_Final.Models.Entities;

namespace School_Final.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext>options):base(options) { }
        public DbSet<Teacher> teachers { get; set; }
        public DbSet<Subject>Subjects { get; set; }
        public DbSet<Assignment> assignment { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Assignment>()
                 .HasOne(x => x.teacher)
                 .WithMany(x => x.Assignments)
                 .HasForeignKey(x => x.TeacherIDd)
                 .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Assignment>()
                 .HasOne(x => x.subject)
                 .WithMany(x => x.Assignments)
                 .HasForeignKey(x => x.SubjectIDd)
                 .OnDelete(DeleteBehavior.NoAction);



        }
    }
}
