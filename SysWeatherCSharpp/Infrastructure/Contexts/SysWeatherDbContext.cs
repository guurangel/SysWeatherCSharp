using Microsoft.EntityFrameworkCore;
using SysWeather.Infrastructure.Mappings;
using SysWeather.Infrastructure.Persistance;

namespace SysWeather.Infrastructure.Contexts
{
    public class SysWeatherDbContext : DbContext
    {
        public SysWeatherDbContext(DbContextOptions<SysWeatherDbContext> options)
            : base(options)
        {
        }

        public DbSet<Municipio> Municipios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Ocorrencia> Ocorrencias { get; set; }
        public DbSet<NotificacaoOcorrencia> NotificacoesOcorrencia { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new MunicipioMapping());
            modelBuilder.ApplyConfiguration(new UsuarioMapping());
            modelBuilder.ApplyConfiguration(new OcorrenciaMapping());
            modelBuilder.ApplyConfiguration(new NotificacaoOcorrenciaMapping());
        }
    }
}