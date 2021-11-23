using System;
using System.Collections.Generic;

#nullable disable

namespace eCommerce.Models.Table
{
    public partial class Cidade
    {
        public Cidade()
        {
            Enderecos = new HashSet<Endereco>();
        }

        public int IdCidade { get; set; }
        public short IdUf { get; set; }
        public string Nome { get; set; }

        public virtual Uf IdUfNavigation { get; set; }
        public virtual ICollection<Endereco> Enderecos { get; set; }
    }
}
