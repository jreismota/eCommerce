using System;
using System.Collections.Generic;

#nullable disable

namespace eCommerce.Models.Table
{
    public partial class Produto
    {
        public Produto()
        {
            ProdutoLojas = new HashSet<ProdutoLoja>();
        }

        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public int IdCategoria { get; set; }
        public int IdMarca { get; set; }
        public int IdCor { get; set; }
        public int IdTamanho { get; set; }
        public int IdUnidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public short? EstoqueMinimoSugerido { get; set; }

        public virtual TabelaDescritivaConteudo IdCategoriaNavigation { get; set; }
        public virtual TabelaDescritivaConteudo IdCorNavigation { get; set; }
        public virtual TabelaDescritivaConteudo IdMarcaNavigation { get; set; }
        public virtual TabelaDescritivaConteudo IdTamanhoNavigation { get; set; }
        public virtual TabelaDescritivaConteudo IdUnidadeNavigation { get; set; }
        public virtual ICollection<ProdutoLoja> ProdutoLojas { get; set; }
    }
}
