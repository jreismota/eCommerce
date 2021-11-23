using System;
using System.Collections.Generic;

#nullable disable

namespace eCommerce.Models.Table
{
    public partial class Fornecedor
    {
        public int IdPessoa { get; set; }
        public short PrazoPrevistoEntrega { get; set; }

        public virtual Pessoa IdPessoaNavigation { get; set; }
    }
}
