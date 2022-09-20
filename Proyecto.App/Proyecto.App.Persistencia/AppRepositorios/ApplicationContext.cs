using Microsoft.EntityFrameworkCore;
using Proyecto.App.Dominio;

namespace Proyecto.App.Persistencia
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Abogado> Abogados { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<FaseCaso> FaseCasos { get; set; }
        public DbSet<Caso> Casos { get; set; }
        public DbSet<Pais> Paises { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source= (localdb)\\MSSQLLocalDB; Initial Catalog=PROYECTO_CICLO_3");
            }
        }

    }
}
