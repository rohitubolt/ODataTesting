using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace DockerDemo.Data
{
    public class SampleDbContext:DbContext
    {
        public SampleDbContext(DbContextOptions<SampleDbContext> options):base(options)
        {
           
        }

        public DbSet<User> Users { get; set; }
        public DbSet<School> Schools { get; set; }
    }
}
