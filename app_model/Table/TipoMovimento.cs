using System;
using System.Collections.Generic;

#nullable disable

namespace eCommerce.Models.Table
{
    public partial class TipoMovimento
    {
        public TipoMovimento()
        {
            Movimentos = new HashSet<Movimento>();
        }

        public int IdTipoMovimento { get; set; }
        public string Descricao { get; set; }
        public short OperacaoEstoque { get; set; }
        public bool Cliente { get; set; }

        public virtual ICollection<Movimento> Movimentos { get; set; }
    }
}
