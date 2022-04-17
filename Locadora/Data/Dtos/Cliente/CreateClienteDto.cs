using System.ComponentModel.DataAnnotations;

namespace Locadora.Data.Dtos
{
    public class CreateClienteDto
    {
        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo de CPF é obrigatório")]
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        
    }
}
