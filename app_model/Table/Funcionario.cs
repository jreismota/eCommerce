using System;
using System.Collections.Generic;

#nullable disable

namespace eCommerce.Models.Table
{
    public partial class Funcionario
    {
        public int IdPessoa { get; set; }
        public string CarteiraTrabalho { get; set; }

        public virtual Pessoa IdPessoaNavigation { get; set; }
    }
}
