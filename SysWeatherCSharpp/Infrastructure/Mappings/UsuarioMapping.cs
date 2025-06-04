using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SysWeather.Infrastructure.Persistance;

namespace SysWeather.Infrastructure.Mappings
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder
                .ToTable("UsuariosC");

            builder
                .HasKey(u => u.Id);

            builder
                .HasIndex(u => u.Email).IsUnique();
            builder
                .HasIndex(u => u.Cpf).IsUnique();

            builder.Property(u => u.Email)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(u => u.Nome)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(u => u.Senha)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(u => u.Cpf)
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            builder.Property(u => u.Cpf)
                   .HasMaxLength(11)
                   .IsRequired();

            builder.Property(u => u.DataNascimento)
                   .IsRequired();

            builder.Property(u => u.DataCadastro)
                   .IsRequired();

            builder.HasOne(u => u.Municipio)
               .WithMany(m => m.Usuarios)
               .HasForeignKey(u => u.MunicipioId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}