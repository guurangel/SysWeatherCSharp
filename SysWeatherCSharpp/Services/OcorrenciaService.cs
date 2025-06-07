using Microsoft.EntityFrameworkCore;
using SysWeather.Infrastructure.Contexts;
using SysWeather.Infrastructure.Persistance;
using SysWeatherC_.DTO.Request;
using SysWeatherCSharpp.DTO.Request;
using SysWeatherCSharpp.Infrastructure.Extensions;

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
            // Verificar se o município existe com CountAsync para evitar problemas com Oracle
            bool municipioExiste = await _context.Municipios.CountAsync(m => m.Id == request.MunicipioId) > 0;
            if (!municipioExiste)
                throw new Exception("Município não encontrado.");

            var ocorrencia = new Ocorrencia
            {
                Id = Guid.NewGuid(),
                Descricao = request.Descricao,
                Tipo = request.Tipo,
                NivelRisco = request.NivelRisco,
                DataOcorrencia = request.DataOcorrencia,
                MunicipioId = request.MunicipioId
            };

            _context.Ocorrencias.Add(ocorrencia);

            // Carregar usuários do município
            var usuarios = await _context.Usuarios
                .Where(u => u.MunicipioId == request.MunicipioId)
                .ToListAsync();

            // Para montar a mensagem, pegar o nome do município (aqui buscamos de novo para pegar o nome)
            var municipio = await _context.Municipios.FindAsync(request.MunicipioId);

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

        public async Task<IEnumerable<Ocorrencia>> ObterOcorrenciasComFiltroAsync(OcorrenciaFiltersRequest filtros)
        {
            var query = _context.Ocorrencias
                                .Include(o => o.Municipio)
                                .AsQueryable();

            query = query.AplicarFiltros(filtros);

            return await query.ToListAsync();
        }
    }
}
