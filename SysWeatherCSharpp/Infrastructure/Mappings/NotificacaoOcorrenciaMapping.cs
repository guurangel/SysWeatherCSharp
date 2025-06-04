using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SysWeather.Infrastructure.Persistance;

namespace SysWeather.Infrastructure.Mappings
{
    public class NotificacaoOcorrenciaMapping : IEntityTypeConfiguration<NotificacaoOcorrencia>
    {
        public void Configure(EntityTypeBuilder<NotificacaoOcorrencia> builder)
        {
            builder.ToTable("NotificacoesOcorrenciaC");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Mensagem)
                   .HasMaxLength(500)
                   .IsRequired();

            builder.Property(e => e.DataEnvio)
                   .IsRequired();

            builder.HasOne(e => e.Usuario)
                   .WithMany(u => u.Notificacoes)
                   .HasForeignKey(e => e.UsuarioId);

            builder.HasOne(e => e.Ocorrencia)
                   .WithMany(o => o.Notificacoes)
                   .HasForeignKey(e => e.OcorrenciaId);
        }
    }
}
