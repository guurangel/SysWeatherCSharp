using Microsoft.EntityFrameworkCore;
using SysWeather.Infrastructure.Persistance;
using SysWeatherC_.DTO.Request;
using SysWeather.Infrastructure.Contexts;


namespace SysWeatherC_.Services
{
    public class OcorrenciaService
    {
        private readonly SysWeatherDbContext _context;

        public OcorrenciaService(SysWeatherDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> CriarOcorrenciaAsync(OcorrenciaRequest request)
        {
            var ocorrencia = new Ocorrencia
            {
                Id = Guid.NewGuid(),
                Descricao = request.Descricao,
                Tipo = request.Tipo,
                NivelRisco = request.NivelRisco,
                DataOcorrencia = request.DataOcorrencia,
                MunicipioId = request.MunicipioId
            };

            var municipio = await _context.Municipios
                .Where(m => m.Id == request.MunicipioId)
                .FirstOrDefaultAsync();

            if (municipio == null)
                throw new Exception("Município não encontrado");

            _context.Ocorrencias.Add(ocorrencia);

            var usuarios = await _context.Usuarios
                .Where(u => u.MunicipioId == request.MunicipioId)
                .ToListAsync();

            var notificacoes = usuarios.Select(u => new NotificacaoOcorrencia
            {
                Id = Guid.NewGuid(),
                Mensagem = $"Nova ocorrência de {ocorrencia.Tipo} com risco {ocorrencia.NivelRisco} em {municipio.Nome} reportada às {ocorrencia.DataOcorrencia:dd/MM/yyyy HH:mm}!!!",
                DataEnvio = DateTime.UtcNow,
                UsuarioId = u.Id,
                OcorrenciaId = ocorrencia.Id
            }).ToList();

            _context.NotificacoesOcorrencia.AddRange(notificacoes);

            await _context.SaveChangesAsync();

            return ocorrencia.Id;
        }
    }
}
