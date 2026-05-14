using LogicaNegocio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructura.Config
{
    internal class GastoConfiguration : IEntityTypeConfiguration<Gasto>
    {
        public void Configure(EntityTypeBuilder<Gasto> builder)
        {
            builder.OwnsOne(g => g.Descripcion, d =>
             d.Property(v => v.Value)
                 .HasColumnName("Descripcion")
                 .IsRequired());

            builder.OwnsOne(g => g.Precio, p =>
                p.Property(v => v.Value)
                    .HasColumnName("Precio")
                    .IsRequired());

            builder.Property(g => g.Fecha)
                .IsRequired();

            builder.HasOne(g => g.Categoria)
                   .WithMany()
                   .HasForeignKey(g => g.CategoriaId)
                   .IsRequired();
        }
    }
}