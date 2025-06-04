using Microsoft.EntityFrameworkCore;
using SysWeather.Infrastructure.Contexts;
using SysWeather.Infrastructure.Persistance;
using SysWeatherC_.DTO.Request;

namespace SysWeatherC_.Services
{
    public class UsuarioService
    {
        private readonly SysWeatherDbContext _context;

        public UsuarioService(SysWeatherDbContext context)
        {
            _context = context;
        }

        public async Task AtualizarUsuarioAsync(Guid usuarioId, AtualizarUsuarioRequest request)
        {
            var usuario = await _context.Usuarios.FindAsync(usuarioId);
            if (usuario == null)
                throw new Exception("Usuário não encontrado.");

            bool emailExistente = await _context.Usuarios
                .AnyAsync(u => u.Email == request.Email && u.Id != usuarioId);
            if (emailExistente)
                throw new Exception("Email já está em uso por outro usuário.");

            usuario.Nome = request.Nome;
            usuario.Email = request.Email;
            usuario.Senha = request.Senha;
            usuario.MunicipioId = request.MunicipioId;

            await _context.SaveChangesAsync();
        }

        public async Task<Guid> CriarUsuarioAsync(Usuario novoUsuario)
        {
            bool emailExistente = await _context.Usuarios.AnyAsync(u => u.Email == novoUsuario.Email);
            if (emailExistente)
                throw new Exception("Email já está em uso.");

            bool cpfExistente = await _context.Usuarios.AnyAsync(u => u.Cpf == novoUsuario.Cpf);
            if (cpfExistente)
                throw new Exception("CPF já está em uso.");

            novoUsuario.Id = Guid.NewGuid();
            novoUsuario.DataCadastro = DateTime.UtcNow;

            _context.Usuarios.Add(novoUsuario);
            await _context.SaveChangesAsync();

            return novoUsuario.Id;
        }

    }
}
