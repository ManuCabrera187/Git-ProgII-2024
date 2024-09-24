using Microsoft.EntityFrameworkCore;

namespace _24_09.Models
{
    public class AppDbContext:DbContext
    {
        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<Rol> roles { get; set; }

        public AppDbContext() { }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


    }
}
