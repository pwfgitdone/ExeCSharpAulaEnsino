using System.ComponentModel.DataAnnotations.Schema;

namespace Daniel.AulaEnsino.Core.WebApi.ViewModels.DTOs
{
    public class ClienteDTO
    {
        public int Codigo { get; set; }

        public string Nome { get; set; }

        public string Documento { get; set; }

        public string TipoPessoa { get; set; }

        public bool Status { get; set; }

        public virtual EnderecoDTO Endereco { get; set; }

        public virtual ICollection<ProdutoDTO> Produtos { get; set; }

        [NotMapped]
        public string StatusPesquisa { get; set; }
    }
}
