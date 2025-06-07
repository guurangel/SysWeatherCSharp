using SysWeather.Infrastructure.Persistance;
using SysWeatherCSharpp.DTO.Request;

namespace SysWeatherCSharpp.Infrastructure.Extensions
{
    public static class OcorrenciaFiltersExtensions
    {
        public static IQueryable<Ocorrencia> AplicarFiltros(this IQueryable<Ocorrencia> query, OcorrenciaFiltersRequest filtros)
        {
            if (!string.IsNullOrWhiteSpace(filtros.MunicipioNome))
                query = query.Where(o => o.Municipio.Nome.ToLower().Contains(filtros.MunicipioNome.ToLower()));

            if (filtros.NivelRisco.HasValue)
                query = query.Where(o => o.NivelRisco == filtros.NivelRisco);

            if (filtros.Tipo.HasValue)
                query = query.Where(o => o.Tipo == filtros.Tipo);

            if (filtros.DataOcorrencia.HasValue)
                query = query.Where(o => o.DataOcorrencia.Date == filtros.DataOcorrencia.Value.Date);

            if (filtros.DataOcorrenciaInicio.HasValue)
                query = query.Where(o => o.DataOcorrencia.Date >= filtros.DataOcorrenciaInicio.Value.Date);

            if (filtros.DataOcorrenciaFim.HasValue)
                query = query.Where(o => o.DataOcorrencia.Date <= filtros.DataOcorrenciaFim.Value.Date);

            return query;
        }
    }
}
