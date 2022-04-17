using Rental.Models;

namespace Locadora.Data.Dtos.Locacao
{
    public class UpdateLocadoraDto
    {        
        public DateTime DataLocacao { get; set; }
        public DateTime DataDevolucao { get; set; }        

    }
}
