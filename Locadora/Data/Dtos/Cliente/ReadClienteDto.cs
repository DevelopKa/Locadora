using System.ComponentModel.DataAnnotations;

namespace Locadora.Data.Dtos
{
    public class ReadClienteDto
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo de nome é obrigatório")]        
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
