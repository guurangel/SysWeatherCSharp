using System.ComponentModel.DataAnnotations;
using SysWeather.Infrastructure.Persistance;

namespace SysWeather.Infrastructure.Persistance
{
    public class NotificacaoOcorrencia
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Mensagem não pode estar em branco.")]
        public string Mensagem { get; set; } = string.Empty;

        [Required]
        public DateTime DataEnvio { get; set; } = DateTime.UtcNow;

        [Required]
        public Guid UsuarioId { get; set; }

        [Required]
        public Usuario Usuario { get; set; } = null!;

        [Required]
        public Guid OcorrenciaId { get; set; }

        [Required]
        public Ocorrencia Ocorrencia { get; set; } = null!;
    }
}