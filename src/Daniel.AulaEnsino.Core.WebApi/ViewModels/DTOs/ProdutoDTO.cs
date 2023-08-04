using System.ComponentModel.DataAnnotations.Schema;

namespace Daniel.AulaEnsino.Core.WebApi.ViewModels.DTOs
{
    public class ProdutoDTO
    {
        public int Codigo { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public string Imagem { get; set; }

        public decimal? Valor { get; set; }

        public bool Status { get; set; }

        public int? CodigoCliente { get; set; }

        /* EF Relations */
        public virtual ClienteDTO Cliente { get; set; }

        [NotMapped]
        public string StatusPesquisa { get; set; }
    }
}
