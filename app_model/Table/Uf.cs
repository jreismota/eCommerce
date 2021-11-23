using System;
using System.Collections.Generic;

#nullable disable

namespace eCommerce.Models.Table
{
    public partial class Uf
    {
        public Uf()
        {
            Cidades = new HashSet<Cidade>();
        }

        public short IdUf { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }

        public virtual ICollection<Cidade> Cidades { get; set; }
    }
}
