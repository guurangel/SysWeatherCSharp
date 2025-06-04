using System.ComponentModel.DataAnnotations;
using SysWeather.Infrastructure.Persistance.Enums;

namespace SysWeatherC_.DTO.Request
{
    public class OcorrenciaRequest
    {
        public string Descricao { get; set; } = string.Empty;
        public TipoOcorrencia Tipo { get; set; }
        public NivelRisco NivelRisco { get; set; }
        public DateTime DataOcorrencia { get; set; }
        public Guid MunicipioId { get; set; }
    }
}