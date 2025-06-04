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
    public class MunicipioController : ControllerBase
    {
        private readonly SysWeatherDbContext _context;
        private readonly MunicipioService _service;

        public MunicipioController(SysWeatherDbContext context, MunicipioService service)
        {
            _context = context;
            _service = service;
        }

        // GET: api/municipio
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MunicipioResponse>>> GetAll()
        {
            var municipios = await _context.Municipios.ToListAsync();

            var response = municipios.Select(m => new MunicipioResponse
            {
                Id = m.Id,
                Nome = m.Nome,
                Estado = m.Estado,
                NumeroHabitantes = m.NumeroHabitantes,
                Clima = m.Clima,
                Regiao = m.Regiao,
                Altitude = m.Altitude,
                AreaKm2 = m.AreaKm2
            });

            return Ok(response);
        }

        // GET: api/municipio/{id}
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<MunicipioResponse>> GetById(Guid id)
        {
            var municipio = await _context.Municipios.FindAsync(id);

            if (municipio == null)
                return NotFound();

            var response = new MunicipioResponse
            {
                Id = municipio.Id,
                Nome = municipio.Nome,
                Estado = municipio.Estado,
                NumeroHabitantes = municipio.NumeroHabitantes,
                Clima = municipio.Clima,
                Regiao = municipio.Regiao,
                Altitude = municipio.Altitude,
                AreaKm2 = municipio.AreaKm2
            };

            return Ok(response);
        }

        // POST: api/municipio
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] MunicipioRequest request)
        {
            try
            {
                var id = await _service.CriarMunicipioAsync(request);
                return CreatedAtAction(nameof(GetById), new { id }, null);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/municipio/{id}
        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Update(Guid id, [FromBody] MunicipioRequest request)
        {
            try
            {
                await _service.AtualizarMunicipioAsync(id, request);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/municipio/{id}
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var municipio = await _context.Municipios.FindAsync(id);
            if (municipio == null)
                return NotFound();

            _context.Municipios.Remove(municipio);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
