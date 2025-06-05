using SysWeather.Infrastructure.Persistance;
using SysWeatherCSharpp.DTO.Request;

namespace SysWeatherCSharpp.Infrastructure.Extensions
{
    public static class UsuarioFiltersExtensions
    {
        public static IQueryable<Usuario> AplicarFiltros(this IQueryable<Usuario> query, UsuarioFiltersRequest filtros)
        {
            if (!string.IsNullOrWhiteSpace(filtros.Nome))
                query = query.Where(u => u.Nome.ToLower().Contains(filtros.Nome.ToLower()));

            if (!string.IsNullOrWhiteSpace(filtros.Email))
                query = query.Where(u => u.Email.ToLower().Contains(filtros.Email.ToLower()));

            if (!string.IsNullOrWhiteSpace(filtros.Cpf))
                query = query.Where(u => u.Cpf == filtros.Cpf.Trim());

            if (!string.IsNullOrWhiteSpace(filtros.MunicipioNome))
                query = query.Where(u => u.Municipio != null && u.Municipio.Nome.ToLower().Contains(filtros.MunicipioNome.ToLower()));

            if (filtros.DataCadastro.HasValue)
                query = query.Where(u => u.DataCadastro.Date == filtros.DataCadastro.Value.Date);

            if (filtros.DataCadastroInicio.HasValue)
                query = query.Where(u => u.DataCadastro.Date >= filtros.DataCadastroInicio.Value.Date);

            if (filtros.DataCadastroFim.HasValue)
                query = query.Where(u => u.DataCadastro.Date <= filtros.DataCadastroFim.Value.Date);

            if (filtros.DataNascimento.HasValue)
                query = query.Where(u => u.DataNascimento == filtros.DataNascimento.Value);

            if (filtros.DataNascimentoInicio.HasValue)
                query = query.Where(u => u.DataNascimento >= filtros.DataNascimentoInicio.Value);

            if (filtros.DataNascimentoFim.HasValue)
                query = query.Where(u => u.DataNascimento <= filtros.DataNascimentoFim.Value);

            return query;
        }
    }
}