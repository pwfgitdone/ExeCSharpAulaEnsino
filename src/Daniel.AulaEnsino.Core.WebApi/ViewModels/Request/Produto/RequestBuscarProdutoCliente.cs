namespace Daniel.AulaEnsino.Core.WebApi.ViewModels.Request.Produto
{
    public class RequestBuscarProdutoCliente
    {
        public string Nome { get; set; }

        public int? CodigoCliente { get; set; }

        public string StatusPesquisa { get; set; }
    }
}
