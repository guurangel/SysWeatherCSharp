namespace SysWeatherC_.DTO.Response
{
    public class NotificacaoOcorrenciaResponse
    {
        public Guid Id { get; set; }
        public string Mensagem { get; set; } = string.Empty;
        public DateTime DataEnvio { get; set; }
        public Guid UsuarioId { get; set; }
        public string UsuarioNome { get; set; } = string.Empty;
        public Guid OcorrenciaId { get; set; }
        public string OcorrenciaDescricao { get; set; } = string.Empty;
    }
}
