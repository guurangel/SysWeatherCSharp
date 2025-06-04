using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using SysWeather.Infrastructure.Persistance.Enums;

namespace SysWeather.Infrastructure.Persistance
{
    public class Municipio
    {
        
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O nome do município não pode estar em branco.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "O nome deve ter entre 2 e 100 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O estado é obrigatório.")]
        public Estado Estado { get; set; }

        [Required(ErrorMessage = "O número de habitantes é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "O número de habitantes deve ser positivo.")]
        public int NumeroHabitantes { get; set; }

        [Required(ErrorMessage = "O clima é obrigatório.")]
        public Clima Clima { get; set; }

        [Required(ErrorMessage = "A região é obrigatória.")]
        public Regiao Regiao { get; set; }

        [Required(ErrorMessage = "A altitude é obrigatória.")]
        [Range(0, double.MaxValue, ErrorMessage = "A altitude não pode ser negativa.")]
        public double Altitude { get; set; }

        [Required(ErrorMessage = "A área (km²) é obrigatória.")]
        [Range(0.0001, double.MaxValue, ErrorMessage = "A área (km²) deve ser um valor positivo.")]
        public double AreaKm2 { get; set; }

        public ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();

        public ICollection<Ocorrencia> Ocorrencias { get; set; } = new List<Ocorrencia>();
    }
}