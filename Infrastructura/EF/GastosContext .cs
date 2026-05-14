using Infrastructura.Config;
using LogicaNegocio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Infrastructura.EF
{
    public class GastosContext : DbContext
    {
            public DbSet<Gasto> Gastos { get; set; }
            public DbSet<Categoria> Categorias { get; set; }

            public GastosContext(DbContextOptions<GastosContext> options) : base(options)
            {
            }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new GastoConfiguration());
            modelBuilder.ApplyConfiguration(new CategoriaConfiguration());
        }
        }
    }

