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
        }

        public DbSet<Subjects> Subjects { get; set; }
        public DbSet<Students> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Abcences> Abcenses { get; set; }
        public DbSet<Lessons> Lessons { get; set; }
    }
}
