using System;
using System.Collections.Generic;

#nullable disable

namespace eCommerce.Models.Table
{
    public partial class Telefone
    {
        public int IdTelefone { get; set; }
        public int IdPessoa { get; set; }
        public long Numero { get; set; }
        public int IdTipo { get; set; }

        public virtual Pessoa IdPessoaNavigation { get; set; }
        public virtual TabelaDescritivaConteudo IdTipoNavigation { get; set; }
    }
}
