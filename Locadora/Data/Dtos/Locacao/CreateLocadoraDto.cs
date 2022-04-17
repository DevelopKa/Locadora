namespace Locadora.Data.Dtos.Locacao
{
    public class CreateLocadoraDto
    {
        public int IdCliente { get; set; }
        public int IdFilme { get; set; }
        public DateTime DataLocacao { get; set; }
        public DateTime DataDevolucao { get; set; }

    }
}
