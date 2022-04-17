using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rental.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Locacaos = new HashSet<Locacao>();
        }

        [Key]
        [Required] 
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Cpf { get; set; }
        public DateTime? DataNascimento { get; set; }

        public virtual ICollection<Locacao> Locacaos { get; set; }
    }
}
