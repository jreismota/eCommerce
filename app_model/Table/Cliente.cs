using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace eCommerce.Models.Table
{
    public partial class Cliente
    {
        public int IdPessoa { get; set; }
        [Display(Name = "Preferencial")]
        public bool IsPreferencial { get; set; }

        public virtual Pessoa IdPessoaNavigation { get; set; }
    }
}
