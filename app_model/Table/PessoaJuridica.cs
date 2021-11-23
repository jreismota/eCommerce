using System;
using System.Collections.Generic;

#nullable disable

namespace eCommerce.Models.Table
{
    public partial class PessoaJuridica
    {
        public int IdPessoa { get; set; }
        public string InscricaoEstadual { get; set; }
        public string NomeFantasia { get; set; }

        public virtual Pessoa IdPessoaNavigation { get; set; }
    }
}
