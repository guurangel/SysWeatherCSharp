using System.ComponentModel.DataAnnotations;
using SysWeather.Infrastructure.Persistance.Enums;

namespace SysWeather.Infrastructure.Persistance
{
    public class Ocorrencia
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "A descrição da ocorrência é obrigatória.")]
        public string Descricao { get; set; } = string.Empty;

        [Required(ErrorMessage = "O tipo da ocorrência é obrigatório.")]
        public TipoOcorrencia Tipo { get; set; }

        [Required(ErrorMessage = "O nível de risco é obrigatório.")]
        public NivelRisco NivelRisco { get; set; }

        [Required(ErrorMessage = "A data da ocorrência é obrigatória.")]
        public DateTime DataOcorrencia { get; set; }

        [Required]
        public Guid MunicipioId { get; set; }

        [Required]
        public Municipio Municipio { get; set; } = null!;

        public ICollection<NotificacaoOcorrencia> Notificacoes { get; set; } = new List<NotificacaoOcorrencia>();
    }
}
