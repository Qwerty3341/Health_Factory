using Health_Factory.Modelos;
using Health_Factory.Utilidades;
using Microsoft.EntityFrameworkCore;

namespace Health_Factory.DataAccess
{
    public class UsuarioDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conexionDB = $"Filename={ConexionDB.DevolverRuta("usuarios.db")}";
            optionsBuilder.UseSqlite(conexionDB);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(col => col.IdUsuario);
                entity.Property(col => col.IdUsuario).IsRequired().ValueGeneratedOnAdd();
            }); 
        }
    }
}
