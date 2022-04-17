using System.ComponentModel.DataAnnotations;


namespace Locadora.Data.Dtos
{
    public class UpdateFilmeDto
    {
        public string Titulo { get; set; }
        public int ClassificacaoIndicativa { get; set; }
        public sbyte Lancamento { get; set; }

    }
}
