using System.ComponentModel.DataAnnotations;


namespace Locadora.Data.Dtos
{
    public class ReadFilmeDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int ClassificacaoIndicativa { get; set; }
        public sbyte Lancamento { get; set; }

    }
}
