using System;
using System.Collections.Generic;

#nullable disable

namespace eCommerce.Models.Table
{
    public partial class Movimento
    {
        public Movimento()
        {
            MovimentoItems = new HashSet<MovimentoItem>();
        }

        public int IdMovimento { get; set; }
        public int IdTipoMovimento { get; set; }
        public int IdPessoa { get; set; }
        public DateTime Data { get; set; }

        public virtual Pessoa IdPessoaNavigation { get; set; }
        public virtual TipoMovimento IdTipoMovimentoNavigation { get; set; }
        public virtual ICollection<MovimentoItem> MovimentoItems { get; set; }
    }
}
