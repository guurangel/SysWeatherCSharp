using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SysWeather.Infrastructure.Persistance;

namespace SysWeather.Infrastructure.Mappings
{
    public class OcorrenciaMapping : IEntityTypeConfiguration<Ocorrencia>
    {
        public void Configure(EntityTypeBuilder<Ocorrencia> builder)
        {
            builder.ToTable("OcorrenciasC");

            builder.HasKey(o => o.Id);

            builder.Property(o => o.Descricao)
                   .HasMaxLength(500)
                   .IsRequired();

            builder.Property(o => o.Tipo)
                   .HasConversion<string>()
                   .IsRequired();

            builder.Property(o => o.NivelRisco)
                    .HasConversion<string>()
                   .IsRequired();

            builder.Property(o => o.DataOcorrencia)
                   .IsRequired();

            builder.HasOne(o => o.Municipio)
                   .WithMany(m => m.Ocorrencias)
                   .HasForeignKey(o => o.MunicipioId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}