using Microsoft.EntityFrameworkCore;
using Blogs.Models;

namespace Blogs.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
        }

        public DbSet<Usuario> Usuario { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<Usuario>(entity =>
        //    {
        //        entity.HasKey(e => e.id);
        //        entity.Property(e => e.id).ValueGeneratedOnAdd();
        //    });
        //}

    }
}
