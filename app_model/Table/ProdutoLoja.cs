using System;
using System.Collections.Generic;

#nullable disable

namespace eCommerce.Models.Table
{
    public partial class ProdutoLoja
    {
        public ProdutoLoja()
        {
            MovimentoItems = new HashSet<MovimentoItem>();
        }

        public int IdProdutoLoja { get; set; }
        public int IdProduto { get; set; }
        public int IdPessoa { get; set; }
        public short EstoqueMinimo { get; set; }

        public virtual Loja IdPessoaNavigation { get; set; }
        public virtual Produto IdProdutoNavigation { get; set; }
        public virtual ICollection<MovimentoItem> MovimentoItems { get; set; }
    }
}
