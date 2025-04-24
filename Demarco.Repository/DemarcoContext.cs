using Demarco.Domain;
using Microsoft.EntityFrameworkCore;

namespace Demarco.Repository
{
    public class DemarcoContext :  DbContext
    {
        public DemarcoContext(DbContextOptions<DemarcoContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Empregado>().HasKey(m => m.ID);
            builder.Entity<Usuario>().HasKey(u => u.ID);
            base.OnModelCreating(builder);
        }

        public DbSet<Empregado> Empregados { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
