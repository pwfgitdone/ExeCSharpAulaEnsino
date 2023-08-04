using Daniel.AulaEnsino.Core.WebApi.ViewModels.Request.Endereco;

namespace Daniel.AulaEnsino.Core.WebApi.ViewModels.Request.Cliente
{
    public class RequestAdicionarCliente
    {
        public string Nome { get; set; }

        public string Documento { get; set; }

        public string TipoPessoa { get; set; }

        public RequestEndereco Endereco { get; set; }

    }
}
