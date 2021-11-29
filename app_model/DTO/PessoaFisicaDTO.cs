using System;
using System.Collections.Generic;

#nullable disable

namespace eCommerce.Models.DTO
{
    public partial class PessoaFisicaDTO
    {
        public int IdPessoa { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Rg { get; set; }

    }
}
