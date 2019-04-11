using Microsoft.EntityFrameworkCore;

namespace TPH
{
    public class TPHContext : DbContext
    {
        private const string connectionString = "Server=(localdb)\\mssqllocaldb;Database=TPH;Trusted_Connection=True;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<LabCourse> LabCourses { get; set; }
        public DbSet<OnlineCourse> OnlineCourses { get; set; }


    }
}