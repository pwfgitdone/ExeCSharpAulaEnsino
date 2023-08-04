namespace Daniel.AulaEnsino.Core.WebApi.ViewModels.Request.Cliente
{
    public class RequestBuscarCliente
    {
        public string Nome { get; set; }

        public string Documento { get; set; }

        public string TipoPessoa { get; set; }

        public string StatusPesquisa { get; set; }
    }
}
