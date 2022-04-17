using System.ComponentModel.DataAnnotations;

namespace Locadora.Data.Dtos
{
    public class UpdateClienteDto
    {
        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
