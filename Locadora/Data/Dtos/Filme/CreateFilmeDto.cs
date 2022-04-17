using System.ComponentModel.DataAnnotations;

namespace Locadora.Data.Dtos
{
    public class CreateFilmeDto
    {
        [Required(ErrorMessage = "O campo título é obrigatório")]
        public string Titulo { get; set; }        
        public int ClassificacaoIndicativa { get; set; }       
        public int Lancamento { get; set; }
        
    }
}
