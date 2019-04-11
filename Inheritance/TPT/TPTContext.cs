using Microsoft.EntityFrameworkCore;

namespace TPT
{
    public class TPTContext : DbContext
    {
        private const string connectionString = "Server=(localdb)\\mssqllocaldb;Database=TPT;Trusted_Connection=True;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<LabCourse> LabCourses { get; set; }
        public DbSet<OnlineCourse> OnlineCourses { get; set; }


    }
}