using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace eCommerce.Models.DTO
{
    public partial class ClienteDTO
    {
        public int IdPessoa { get; set; }
        public bool IsPreferencial { get; set; }
        public virtual PessoaDTO IdPessoaNavigation { get; set; }
    }
}
