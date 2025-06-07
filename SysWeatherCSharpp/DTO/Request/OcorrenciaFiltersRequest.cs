using SysWeather.Infrastructure.Persistance.Enums;

namespace SysWeatherCSharpp.DTO.Request
{
    public class OcorrenciaFiltersRequest
    {
        public string? MunicipioNome { get; set; }
        public NivelRisco? NivelRisco { get; set; }
        public TipoOcorrencia? Tipo { get; set; }

        public DateTime? DataOcorrencia { get; set; }
        public DateTime? DataOcorrenciaInicio { get; set; }
        public DateTime? DataOcorrenciaFim { get; set; }
    }
}
