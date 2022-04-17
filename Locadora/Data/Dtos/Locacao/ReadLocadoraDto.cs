using Rental.Models;

namespace Locadora.Data.Dtos.Locacao
{
    public class ReadLocadoraDto
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int IdFilme { get; set; }

        //public Cliente Cliente { get; set; }
        //public Filme Filme { get; set; }
        public DateTime DataLocacao { get; set; }
        public DateTime DataDevolucao { get; set; }

    }
}
