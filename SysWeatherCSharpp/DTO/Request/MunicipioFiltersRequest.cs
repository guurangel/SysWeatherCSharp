using SysWeather.Infrastructure.Persistance.Enums;

namespace SysWeatherCSharpp.DTO.Request
{
    public class MunicipioFiltersRequest
    {
        public string? Nome { get; set; }
        public Estado? Estado { get; set; }
        public Regiao? Regiao { get; set; }
        public Clima? Clima { get; set; }

        public int? NumeroHabitantes { get; set; }
        public int? NumeroHabitantesMin { get; set; }
        public int? NumeroHabitantesMax { get; set; }

        public double? AreaKm2 { get; set; }
        public double? AreaKm2Min { get; set; }
        public double? AreaKm2Max { get; set; }

        public double? Altitude { get; set; }
        public double? AltitudeMin { get; set; }
        public double? AltitudeMax { get; set; }
    }
}
