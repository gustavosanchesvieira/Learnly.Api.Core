using Learnly.Api.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Learnly.Api.Core.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Subjects> Subjects { get; set; }
        public DbSet<Students> Students { get; set; }
    }
}
