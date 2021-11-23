using System;
using System.Collections.Generic;

#nullable disable

namespace eCommerce.Models.Table
{
    public partial class Loja
    {
        public Loja()
        {
            InverseIdLojaMatrizNavigation = new HashSet<Loja>();
            ProdutoLojas = new HashSet<ProdutoLoja>();
        }

        public int IdPessoa { get; set; }
        public int IdTipoLoja { get; set; }
        public int IdLojaMatriz { get; set; }

        public virtual Loja IdLojaMatrizNavigation { get; set; }
        public virtual Pessoa IdPessoaNavigation { get; set; }
        public virtual TabelaDescritivaConteudo IdTipoLojaNavigation { get; set; }
        public virtual ICollection<Loja> InverseIdLojaMatrizNavigation { get; set; }
        public virtual ICollection<ProdutoLoja> ProdutoLojas { get; set; }
    }
}
