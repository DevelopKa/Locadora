using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rental.Models
{
    public partial class Locacao
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public int? IdCliente { get; set; }
        public int? IdFilme { get; set; }
        public virtual Cliente? Cliente { get; set; }
        public virtual Filme? Filme { get; set; }
        public DateTime? DataLocacao { get; set; }
        public DateTime? DataDevolucao { get; set; }

    }
}
