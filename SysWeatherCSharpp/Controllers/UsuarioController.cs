using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SysWeather.Infrastructure.Contexts;
using SysWeather.Infrastructure.Persistance;
using SysWeatherC_.DTO.Request;
using SysWeatherC_.DTO.Response;
using SysWeatherC_.Services;
using SysWeatherCSharpp.DTO.Request;

namespace SysWeatherC_.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly SysWeatherDbContext _context;
        private readonly UsuarioService _service;

        public UsuarioController(SysWeatherDbContext context, UsuarioService service)
        {
            _context = context;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] UsuarioFiltersRequest filtros)
        {
            var usuarios = (await _service.ObterUsuariosComFiltroAsync(filtros)).ToList(); // Executa a consulta primeiro

            var response = usuarios.Select(u => new UsuarioResponse
            {
                Id = u.Id,
                Nome = u.Nome,
                Email = u.Email,
                Cpf = u.Cpf,
                DataCadastro = u.DataCadastro,
                DataNascimento = u.DataNascimento.Date,
                MunicipioId = u.MunicipioId,
                MunicipioNome = u.Municipio.Nome
            });

            return Ok(response);
        }

        // GET: api/usuario/{id}
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<UsuarioResponse>> GetById(Guid id)
        {
            var usuario = await _context.Usuarios
                .Include(u => u.Municipio)
                .FirstOrDefaultAsync(u => u.Id == id);

            if (usuario == null)
                return NotFound();

            var response = new UsuarioResponse
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Cpf = usuario.Cpf,
                MunicipioId = usuario.MunicipioId,
                MunicipioNome = usuario.Municipio.Nome
            };

            return Ok(response);
        }

        // POST: api/usuario
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] UsuarioRequest request)
        {
            try
            {
                var novoUsuario = new Usuario
                {
                    Nome = request.Nome,
                    Email = request.Email,
                    Senha = request.Senha,
                    Cpf = request.Cpf,
                    DataNascimento = request.DataNascimento.Date,
                    MunicipioId = request.MunicipioId
                };

                var id = await _service.CriarUsuarioAsync(novoUsuario);
                return CreatedAtAction(nameof(GetById), new { id }, null);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/usuario/{id}
        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Update(Guid id, [FromBody] AtualizarUsuarioRequest request)
        {
            try
            {
                await _service.AtualizarUsuarioAsync(id, request);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/usuario/{id}
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
                return NotFound();

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
