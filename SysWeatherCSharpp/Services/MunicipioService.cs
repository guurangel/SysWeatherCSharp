using Microsoft.EntityFrameworkCore;
using SysWeather.Infrastructure.Persistance;
using SysWeatherC_.DTO.Request;
using SysWeather.Infrastructure.Contexts;

namespace SysWeatherC_.Services
{
    public class MunicipioService
    {
        private readonly SysWeatherDbContext _context;

        public MunicipioService(SysWeatherDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> CriarMunicipioAsync(MunicipioRequest request)
        {
            bool existeMunicipio = await _context.Municipios
                .CountAsync(m =>
                    m.Nome.ToUpper() == request.Nome.ToUpper() &&
                    m.Estado.ToString() == request.Estado.ToString()
                ) > 0;

            if (existeMunicipio)
                throw new Exception($"Já existe um município chamado '{request.Nome}' no estado '{request.Estado}'.");

            var municipio = new Municipio
            {
                Id = Guid.NewGuid(),
                Nome = request.Nome,
                Estado = request.Estado,
                NumeroHabitantes = request.NumeroHabitantes,
                Clima = request.Clima,
                Regiao = request.Regiao,
                Altitude = request.Altitude,
                AreaKm2 = request.AreaKm2
            };

            _context.Municipios.Add(municipio);
            await _context.SaveChangesAsync();

            return municipio.Id;
        }

        public async Task AtualizarMunicipioAsync(Guid municipioId, MunicipioRequest request)
        {
            var municipio = await _context.Municipios.FindAsync(municipioId);

            if (municipio == null)
                throw new Exception("Município não encontrado.");

            bool existeOutro = await _context.Municipios
                .CountAsync(m =>
                    m.Id != municipioId &&
                    m.Nome.ToUpper() == request.Nome.ToUpper() &&
                    m.Estado.ToString() == request.Estado.ToString()
                ) > 0;

            if (existeOutro)
                throw new Exception($"Já existe outro município chamado '{request.Nome}' no estado '{request.Estado}'.");

            municipio.Nome = request.Nome;
            municipio.Estado = request.Estado;
            municipio.NumeroHabitantes = request.NumeroHabitantes;
            municipio.Clima = request.Clima;
            municipio.Regiao = request.Regiao;
            municipio.Altitude = request.Altitude;
            municipio.AreaKm2 = request.AreaKm2;

            await _context.SaveChangesAsync();
        }
    }
}
