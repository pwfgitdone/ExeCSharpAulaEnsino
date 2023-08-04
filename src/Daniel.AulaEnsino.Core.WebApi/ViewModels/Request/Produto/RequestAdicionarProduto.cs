namespace Daniel.AulaEnsino.Core.WebApi.ViewModels.Request.Produto
{
    public class RequestAdicionarProduto
    {
        public string Nome { get; set; }

        public string Descricao { get; set; }

        public string Imagem { get; set; }

        public decimal? Valor { get; set; }

        public bool Status { get; set; }

        public int CodigoCliente { get; set; }
    }
}
