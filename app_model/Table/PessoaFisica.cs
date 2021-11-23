using System;
using System.Collections.Generic;

#nullable disable

namespace eCommerce.Models.Table
{
    public partial class PessoaFisica
    {
        public int IdPessoa { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Rg { get; set; }

        public virtual Pessoa IdPessoaNavigation { get; set; }
    }
}
