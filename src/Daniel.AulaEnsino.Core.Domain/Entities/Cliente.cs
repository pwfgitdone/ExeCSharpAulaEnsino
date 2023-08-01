using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daniel.AulaEnsino.Core.Domain.Entities
{
    public class Cliente : Entity
    {
        public string Documento { get; set; }

        public string TipoPessoa { get; set; }

        /* EF Relations */

        public Endereco Endereco { get; set; }

        public ICollection<Produto> Produtos { get; set; }

        [NotMapped]
        public string StatusPesquisa { get; set; }
    }
}
