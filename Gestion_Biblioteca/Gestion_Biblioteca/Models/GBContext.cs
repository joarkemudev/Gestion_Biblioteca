using Gestion_Biblioteca.Models;
using Microsoft.EntityFrameworkCore;

namespace Gestion_Biblioteca.Models
{
    public class GBContext : DbContext
    {
        public GBContext(DbContextOptions<GBContext> options) : base(options)
        {
        }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Libro> Libros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autor>()
                .HasMany(a => a.Libros)
                .WithOne(l => l.Autor)
                .HasForeignKey(l => l.AutorID);

            base.OnModelCreating(modelBuilder);
        }
    }
}
