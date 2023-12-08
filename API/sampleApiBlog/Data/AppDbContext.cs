using sampleApiBlog.Models;
using Microsoft.EntityFrameworkCore;

namespace sampleApiBlog.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Blogs> BLOGS { get; set; }
        public DbSet<Comments> COMMENTS { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blogs>().ToTable("BLOGS");
            modelBuilder.Entity<Comments>().ToTable("COMMENTS");
            modelBuilder.Entity<Users>().ToTable("USERS");
            base.OnModelCreating(modelBuilder); 
        }
    }
}
