using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SysWeather.Infrastructure.Contexts;
using SysWeatherC_.DTO.Request;
using SysWeatherC_.DTO.Response;
using SysWeatherC_.Services;

namespace SysWeatherC_.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OcorrenciaController : ControllerBase
    {
        private readonly SysWeatherDbContext _context;
        private readonly OcorrenciaService _service;

        public OcorrenciaController(SysWeatherDbContext context, OcorrenciaService service)
        {
            _context = context;
            _service = service;
        }

        // GET: api/ocorrencia
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OcorrenciaResponse>>> GetAll()
        {
            var ocorrencias = await _context.Ocorrencias
                .Include(o => o.Municipio)
                .ToListAsync();

            var response = ocorrencias.Select(o => new OcorrenciaResponse
            {
                Id = o.Id,
                Descricao = o.Descricao,
                Tipo = o.Tipo,
                NivelRisco = o.NivelRisco,
                DataOcorrencia = o.DataOcorrencia,
                MunicipioId = o.MunicipioId,
                MunicipioNome = o.Municipio.Nome
            });

            return Ok(response);
        }

        // GET: api/ocorrencia/{id}
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<OcorrenciaResponse>> GetById(Guid id)
        {
            var ocorrencia = await _context.Ocorrencias
                .Include(o => o.Municipio)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (ocorrencia == null)
                return NotFound();

            var response = new OcorrenciaResponse
            {
                Id = ocorrencia.Id,
                Descricao = ocorrencia.Descricao,
                Tipo = ocorrencia.Tipo,
                NivelRisco = ocorrencia.NivelRisco,
                DataOcorrencia = ocorrencia.DataOcorrencia,
                MunicipioId = ocorrencia.MunicipioId,
                MunicipioNome = ocorrencia.Municipio.Nome
            };

            return Ok(response);
        }

        // POST: api/ocorrencia
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] OcorrenciaRequest request)
        {
            try
            {
                var id = await _service.CriarOcorrenciaAsync(request);
                return CreatedAtAction(nameof(GetById), new { id }, new { id });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/ocorrencia/{id}
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var ocorrencia = await _context.Ocorrencias.FindAsync(id);
            if (ocorrencia == null)
                return NotFound();

            _context.Ocorrencias.Remove(ocorrencia);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}