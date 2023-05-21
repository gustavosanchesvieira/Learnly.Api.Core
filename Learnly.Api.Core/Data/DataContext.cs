using Learnly.Api.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Learnly.Api.Core.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Subjects>().
                HasOne(subject => subject.Teacher).
                WithMany(teacher => teacher.Subjects).
                HasForeignKey(subject => subject.TeacherId);

            builder.Entity<Grades>().
                HasOne(x => x.Subject).
                WithMany(y => y.Grades).
                HasForeignKey(y => y.SubjectId);
            
            builder.Entity<Grades>().
                HasOne(x => x.Student).
                WithMany(y => y.Grades).
                HasForeignKey(y => y.StudentId);

            builder.Entity<Matriculation>().
                HasKey(x => new { x.StudentId, x.SubjectId });

            builder.Entity<Matriculation>().
                HasOne(s => s.Student).
                WithMany(m => m.Matriculations).
                HasForeignKey(x => x.StudentId);
            
            builder.Entity<Matriculation>().
                HasOne(s => s.Subject).
                WithMany(m => m.Matriculations).
                HasForeignKey(x => x.SubjectId);

        }

        public DbSet<Subjects> Subjects { get; set; }
        public DbSet<Students> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Abcences> Abcenses { get; set; }
        public DbSet<Lessons> Lessons { get; set; }
        public DbSet<Grades> Grades { get; set; }
        public DbSet<Matriculation> Matriculations { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
