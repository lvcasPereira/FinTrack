using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructura.EF
{
    public class GastosContextFactory : IDesignTimeDbContextFactory<GastosContext>
    {
        public GastosContext CreateDbContext(string[] args)
        {
            var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION")
                ?? throw new Exception("No se encontró la variable de entorno DB_CONNECTION");

            var optionsBuilder = new DbContextOptionsBuilder<GastosContext>();
            optionsBuilder.UseNpgsql(connectionString);

            return new GastosContext(optionsBuilder.Options);
        }
    }
}