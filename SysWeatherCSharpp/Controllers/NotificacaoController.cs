using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SysWeather.Infrastructure.Contexts;
using SysWeather.Infrastructure.Persistance;
using SysWeatherC_.DTO.Response;

namespace SysWeatherC_.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificacaoController : ControllerBase
    {
        private readonly SysWeatherDbContext _context;

        public NotificacaoController(SysWeatherDbContext context)
        {
            _context = context;
        }

        // GET: api/notificacao
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NotificacaoOcorrenciaResponse>>> GetAll()
        {
            var notificacoes = await _context.NotificacoesOcorrencia
                .Include(n => n.Usuario)
                .Include(n => n.Ocorrencia)
                .Select(n => new NotificacaoOcorrenciaResponse
                {
                    Id = n.Id,
                    Mensagem = n.Mensagem,
                    DataEnvio = n.DataEnvio,
                    UsuarioId = n.UsuarioId,
                    UsuarioNome = n.Usuario.Nome,
                    OcorrenciaId = n.OcorrenciaId,
                    OcorrenciaDescricao = n.Ocorrencia.Descricao
                })
                .ToListAsync();

            return Ok(notificacoes);
        }

        // GET: api/notificacao/{id}
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<NotificacaoOcorrenciaResponse>> GetById(Guid id)
        {
            var notificacao = await _context.NotificacoesOcorrencia
                .Include(n => n.Usuario)
                .Include(n => n.Ocorrencia)
                .Where(n => n.Id == id)
                .Select(n => new NotificacaoOcorrenciaResponse
                {
                    Id = n.Id,
                    Mensagem = n.Mensagem,
                    DataEnvio = n.DataEnvio,
                    UsuarioId = n.UsuarioId,
                    UsuarioNome = n.Usuario.Nome,
                    OcorrenciaId = n.OcorrenciaId,
                    OcorrenciaDescricao = n.Ocorrencia.Descricao
                })
                .FirstOrDefaultAsync();

            if (notificacao == null)
                return NotFound();

            return Ok(notificacao);
        }
    }
}