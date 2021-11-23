using System;
using System.Collections.Generic;

#nullable disable

namespace eCommerce.Models.Table
{
    public partial class Endereco
    {
        public int IdEndereco { get; set; }
        public int IdPessoa { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public int Cep { get; set; }
        public int IdCidade { get; set; }
        public int IdTipo { get; set; }

        public virtual Cidade IdCidadeNavigation { get; set; }
        public virtual Pessoa IdPessoaNavigation { get; set; }
        public virtual TabelaDescritivaConteudo IdTipoNavigation { get; set; }
    }
}
