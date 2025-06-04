namespace SysWeatherC_.DTO.Request
{
    public class AtualizarUsuarioRequest
    {
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public Guid MunicipioId { get; set; }
    }
}
