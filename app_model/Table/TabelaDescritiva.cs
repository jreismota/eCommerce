using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace eCommerce.Models.Table
{
    public partial class TabelaDescritiva
    {
        public TabelaDescritiva()
        {
            TabelaDescritivaConteudos = new HashSet<TabelaDescritivaConteudo>();
        }

        public int IdTabelaDescritiva { get; set; }
        [Required]
        public string Nome { get; set; }

        public virtual ICollection<TabelaDescritivaConteudo> TabelaDescritivaConteudos { get; set; }
    }
}
