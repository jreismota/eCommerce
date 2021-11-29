using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace eCommerce.Models.DTO
{
    public partial class PessoaDTO
    {
        public int IdPessoa { get; set; }
        public string Nome { get; set; }
        public long CpfCnpj { get; set; }
        public string Email { get; set; }
        public virtual PessoaFisicaDTO PessoaFisica { get; set; }
        public virtual PessoaJuridicaDTO PessoaJuridica { get; set; }
    }
}
