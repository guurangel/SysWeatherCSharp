using SysWeather.Infrastructure.Persistance;
using SysWeatherCSharpp.DTO.Request;

namespace SysWeatherCSharpp.Infrastructure.Extensions
{
    public static class MunicipioFiltersExtensions
    {
        public static IQueryable<Municipio> AplicarFiltros(this IQueryable<Municipio> query, MunicipioFiltersRequest filtros)
        {
            if (!string.IsNullOrWhiteSpace(filtros.Nome))
                query = query.Where(m => m.Nome.ToLower().Contains(filtros.Nome.ToLower()));

            if (filtros.Estado.HasValue)
                query = query.Where(m => m.Estado == filtros.Estado);

            if (filtros.Regiao.HasValue)
                query = query.Where(m => m.Regiao == filtros.Regiao);

            if (filtros.Clima.HasValue)
                query = query.Where(m => m.Clima == filtros.Clima);

            if (filtros.NumeroHabitantes.HasValue)
                query = query.Where(m => m.NumeroHabitantes == filtros.NumeroHabitantes);

            if (filtros.NumeroHabitantesMin.HasValue)
                query = query.Where(m => m.NumeroHabitantes >= filtros.NumeroHabitantesMin);

            if (filtros.NumeroHabitantesMax.HasValue)
                query = query.Where(m => m.NumeroHabitantes <= filtros.NumeroHabitantesMax);

            if (filtros.AreaKm2.HasValue)
                query = query.Where(m => m.AreaKm2 == filtros.AreaKm2);

            if (filtros.AreaKm2Min.HasValue)
                query = query.Where(m => m.AreaKm2 >= filtros.AreaKm2Min);

            if (filtros.AreaKm2Max.HasValue)
                query = query.Where(m => m.AreaKm2 <= filtros.AreaKm2Max);

            if (filtros.Altitude.HasValue)
                query = query.Where(m => m.Altitude == filtros.Altitude);

            if (filtros.AltitudeMin.HasValue)
                query = query.Where(m => m.Altitude >= filtros.AltitudeMin);

            if (filtros.AltitudeMax.HasValue)
                query = query.Where(m => m.Altitude <= filtros.AltitudeMax);

            return query;
        }
    }
}
