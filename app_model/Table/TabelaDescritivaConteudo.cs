using System;
using System.Collections.Generic;

#nullable disable

namespace eCommerce.Models.Table
{
    public partial class TabelaDescritivaConteudo
    {
        public TabelaDescritivaConteudo()
        {
            Enderecos = new HashSet<Endereco>();
            Lojas = new HashSet<Loja>();
            ProdutoIdCategoriaNavigations = new HashSet<Produto>();
            ProdutoIdCorNavigations = new HashSet<Produto>();
            ProdutoIdMarcaNavigations = new HashSet<Produto>();
            ProdutoIdTamanhoNavigations = new HashSet<Produto>();
            ProdutoIdUnidadeNavigations = new HashSet<Produto>();
            Telefones = new HashSet<Telefone>();
        }

        public int IdTabelaDescritivaConteudo { get; set; }
        public int IdTabelaDescritiva { get; set; }
        public string Descricao { get; set; }

        public virtual TabelaDescritiva IdTabelaDescritivaNavigation { get; set; }
        public virtual ICollection<Endereco> Enderecos { get; set; }
        public virtual ICollection<Loja> Lojas { get; set; }
        public virtual ICollection<Produto> ProdutoIdCategoriaNavigations { get; set; }
        public virtual ICollection<Produto> ProdutoIdCorNavigations { get; set; }
        public virtual ICollection<Produto> ProdutoIdMarcaNavigations { get; set; }
        public virtual ICollection<Produto> ProdutoIdTamanhoNavigations { get; set; }
        public virtual ICollection<Produto> ProdutoIdUnidadeNavigations { get; set; }
        public virtual ICollection<Telefone> Telefones { get; set; }
    }
}
