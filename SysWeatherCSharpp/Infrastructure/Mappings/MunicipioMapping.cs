using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SysWeather.Infrastructure.Persistance;

namespace SysWeather.Infrastructure.Mappings
{
    public class MunicipioMapping : IEntityTypeConfiguration<Municipio>
    {
        public void Configure(EntityTypeBuilder<Municipio> builder)
        {
            builder
                .ToTable("MunicipiosC");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Estado)
                   .HasConversion<string>()
                   .IsRequired();

            builder.Property(m => m.Regiao)
                   .HasConversion<string>()
                   .IsRequired();

            builder.Property(m => m.Clima)
                   .HasConversion<string>()
                   .IsRequired();

            builder.HasMany(m => m.Usuarios)
                   .WithOne(u => u.Municipio);

            builder.HasMany(m => m.Ocorrencias)
                   .WithOne(o => o.Municipio);
        }
    }
}
