using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daniel.AulaEnsino.Core.Domain.Entities
{
    public class Produto : Entity
    {
        public string Descricao { get; set; }

        public string Imagem { get; set; }

        public decimal? Valor { get; set; }

        public int? CodigoCliente { get; set; }

        /* EF Relations */
        public Cliente Cliente { get; set; }

        [NotMapped]
        public string StatusPesquisa { get; set; }
    }
}
