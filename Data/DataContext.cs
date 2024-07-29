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
        public DbSet<Entrada> Entrada { get; set;}
    }
}
