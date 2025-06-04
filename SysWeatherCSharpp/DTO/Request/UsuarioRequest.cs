using System.ComponentModel.DataAnnotations;

namespace SysWeatherC_.DTO.Request
{
    public class UsuarioRequest
    {

        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }
        public Guid MunicipioId { get; set; }
    }
}