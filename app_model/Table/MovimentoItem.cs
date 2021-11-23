using System;
using System.Collections.Generic;

#nullable disable

namespace eCommerce.Models.Table
{
    public partial class MovimentoItem
    {
        public int IdMovimento { get; set; }
        public int IdProdutoLoja { get; set; }
        public decimal Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }

        public virtual Movimento IdMovimentoNavigation { get; set; }
        public virtual ProdutoLoja IdProdutoLojaNavigation { get; set; }
    }
}
