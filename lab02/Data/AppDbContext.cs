using Microsoft.EntityFrameworkCore;
using lab02.Models;

namespace lab02.Data
{
   
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Configure AuthorBook as a many-to-many relationship
            builder.Entity<StudentCourse>()
                .HasKey(ab => new { ab.StId, ab.CId });

            builder.Entity<StudentCourse>()
                .HasOne(ab => ab.Courses)
                .WithMany(a => a.StudentCourses)
                .HasForeignKey(ab => ab.CId);

            builder.Entity<StudentCourse>()
                .HasOne(ab => ab.Student)
                .WithMany(b => b.StudentCourses)
                .HasForeignKey(ab => ab.StId);

            // Seed database with authors and books for demo
            new DbInitializer(builder).Seed();
        }
    }
}