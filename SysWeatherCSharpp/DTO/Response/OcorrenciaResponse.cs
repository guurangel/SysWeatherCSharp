using SysWeather.Infrastructure.Persistance.Enums;

namespace SysWeatherC_.DTO.Response
{
    public class OcorrenciaResponse
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public TipoOcorrencia Tipo { get; set; }
        public NivelRisco NivelRisco { get; set; }
        public DateTime DataOcorrencia { get; set; }
        public Guid MunicipioId { get; set; }
        public string MunicipioNome { get; set; } = string.Empty;
    }
}
