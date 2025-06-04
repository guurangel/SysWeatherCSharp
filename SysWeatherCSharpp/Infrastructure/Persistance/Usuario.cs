using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SysWeather.Infrastructure.Persistance
{
    public class Usuario
    {
 
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "O nome deve ter entre 2 e 100 caracteres")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O e-mail é obrigatório")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "A senha é obrigatória")]
        [MinLength(6, ErrorMessage = "A senha deve ter pelo menos 6 caracteres")]
        public string Senha { get; set; } = string.Empty;

        [Required(ErrorMessage = "O CPF é obrigatório")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "O CPF deve conter 11 dígitos numéricos")]
        public string Cpf { get; set; } = string.Empty;

        [Required(ErrorMessage = "A data de nascimento é obrigatória")]
        [DataType(DataType.Date)]
        public DateOnly DataNascimento { get; set; }

        [Required]
        public DateTime DataCadastro { get; set; } = DateTime.UtcNow;

        [Required]
        public Guid MunicipioId { get; set; }

        [Required]
        public Municipio Municipio { get; set; } = null!;

        public ICollection<NotificacaoOcorrencia> Notificacoes { get; set; } = new List<NotificacaoOcorrencia>();
    }
}