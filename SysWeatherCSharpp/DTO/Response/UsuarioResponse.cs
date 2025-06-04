namespace SysWeatherC_.DTO.Response
{
    public class UsuarioResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string senha { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }
        public DateTime DataCadastro { get; set; }
        public Guid MunicipioId { get; set; }
        public string MunicipioNome { get; set; } = string.Empty;
    }
}
