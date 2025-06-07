namespace SysWeatherCSharpp.DTO.Request
{
    public class UsuarioFiltersRequest
    {
        public string? MunicipioNome { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Cpf { get; set; }

        public DateTime? DataCadastro { get; set; }
        public DateTime? DataCadastroInicio { get; set; }
        public DateTime? DataCadastroFim { get; set; }

        public DateTime? DataNascimento { get; set; }
        public DateTime? DataNascimentoInicio { get; set; }
        public DateTime? DataNascimentoFim { get; set; }
    }
}

