using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rental.Models
{
    public partial class Filme
    {
        public Filme()
        {
            Locacaos = new HashSet<Locacao>();
        }

        [Key]
        [Required]
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public int? ClassificacaoIndicativa { get; set; }
        public sbyte? Lancamento { get; set; }

        public virtual ICollection<Locacao> Locacaos { get; set; }
    }
}
