using System.ComponentModel.DataAnnotations;
using SysWeather.Infrastructure.Persistance.Enums;

namespace SysWeatherC_.DTO.Request
{
    public class MunicipioRequest
    {

        public string Nome { get; set; } = string.Empty;
        public Estado Estado { get; set; }
        public int NumeroHabitantes { get; set; }
        public Clima Clima { get; set; }
        public Regiao Regiao { get; set; }
        public double Altitude { get; set; }
        public double AreaKm2 { get; set; }
    }
}