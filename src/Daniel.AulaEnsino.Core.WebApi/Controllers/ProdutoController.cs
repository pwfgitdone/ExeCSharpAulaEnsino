using Microsoft.AspNetCore.Mvc;
using Daniel.AulaEnsino.Core.Domain.Interfaces.Notifications;
using Daniel.AulaEnsino.Core.Domain.Interfaces.Services;
using Daniel.AulaEnsino.Core.WebApi.Mapper;
using Daniel.AulaEnsino.Core.Domain.Notifications;
using Daniel.AulaEnsino.Core.WebApi.ViewModels.Request.Produto;
using Daniel.AulaEnsino.Core.WebApi.ViewModels.Responses;

namespace Daniel.AulaEnsino.Core.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : APIController
    {
        #region Properties

        private readonly IProdutoAppService _produtoAppServ;

        #endregion

        #region Constructor

        public ProdutoController(INotificationHandler<DomainNotification> notifications,
            IProdutoAppService produtoAppServ) : base(notifications)
        {
            _produtoAppServ = produtoAppServ;
        }

        #endregion

        #region Methods

        [HttpGet("ListarTodos")]
        [Consumes("application/Json")]
        [Produces("application/Json")]
        [ProducesResponseType(typeof(ResponseEntidadeBase), 200)]
        [ProducesResponseType(typeof(ResponseFalha), 400)]
        [ProducesResponseType(typeof(ResponseFalha), 403)]
        [ProducesResponseType(typeof(ResponseFalha), 409)]
        [ProducesResponseType(typeof(ResponseFalha), 500)]
        [ProducesResponseType(typeof(ResponseFalha), 502)]
        public async Task<IActionResult> ListarTodos()
        {
            var retorno = await _produtoAppServ.ListarTodos();
            return Response(retorno.Select(x => x.ToResponse()));
        }

        [HttpGet("ListarTodosAtivos")]
        [Consumes("application/Json")]
        [Produces("application/Json")]
        [ProducesResponseType(typeof(ResponseEntidadeBase), 200)]
        [ProducesResponseType(typeof(ResponseFalha), 400)]
        [ProducesResponseType(typeof(ResponseFalha), 403)]
        [ProducesResponseType(typeof(ResponseFalha), 409)]
        [ProducesResponseType(typeof(ResponseFalha), 500)]
        [ProducesResponseType(typeof(ResponseFalha), 502)]
        public async Task<IActionResult> ListarTodosAtivos()
        {
            var retorno = await _produtoAppServ.ListarTodosAtivos();
            return Response(retorno.Select(x => x.ToResponse()));
        }

        [HttpGet("ListarProdutosPorCliente/{codigoCliente}")]
        [Consumes("application/Json")]
        [Produces("application/Json")]
        [ProducesResponseType(typeof(ResponseEntidadeBase), 200)]
        [ProducesResponseType(typeof(ResponseFalha), 400)]
        [ProducesResponseType(typeof(ResponseFalha), 403)]
        [ProducesResponseType(typeof(ResponseFalha), 409)]
        [ProducesResponseType(typeof(ResponseFalha), 500)]
        [ProducesResponseType(typeof(ResponseFalha), 502)]
        public async Task<IActionResult> ListarProdutosPorCliente(int codigoCliente)
        {
            var retorno = await _produtoAppServ.ListarProdutosPorCliente(codigoCliente);
            return Response(retorno.Select(x => x.ToResponseProdutoCliente()));
        }

        [HttpPost("BuscarProdutosClientes")]
        [Consumes("application/Json")]
        [Produces("application/Json")]
        [ProducesResponseType(typeof(ResponseEntidadeBase), 200)]
        [ProducesResponseType(typeof(ResponseFalha), 400)]
        [ProducesResponseType(typeof(ResponseFalha), 403)]
        [ProducesResponseType(typeof(ResponseFalha), 409)]
        [ProducesResponseType(typeof(ResponseFalha), 500)]
        [ProducesResponseType(typeof(ResponseFalha), 502)]
        public async Task<IActionResult> BuscarProdutosClientes([FromBody] RequestBuscarProdutoCliente request)
        {
            var retorno = await _produtoAppServ.BuscarProdutosClientes(request.ToRequest());
            return Response(retorno.Select(x => x.ToResponseProdutoCliente()));
        }

        [HttpGet("ObterPorCodigo/{codigo}")]
        [Consumes("application/Json")]
        [Produces("application/Json")]
        [ProducesResponseType(typeof(ResponseEntidadeBase), 200)]
        [ProducesResponseType(typeof(ResponseFalha), 400)]
        [ProducesResponseType(typeof(ResponseFalha), 403)]
        [ProducesResponseType(typeof(ResponseFalha), 409)]
        [ProducesResponseType(typeof(ResponseFalha), 500)]
        [ProducesResponseType(typeof(ResponseFalha), 502)]
        public async Task<IActionResult> ObterPorCodigo(int codigo)
        {
            var retorno = await _produtoAppServ.ObterPorCodigo(codigo);
            return Response(retorno?.ToResponse());
        }

        [HttpGet("ObterProdutoCliente/{codigo}")]
        [Consumes("application/Json")]
        [Produces("application/Json")]
        [ProducesResponseType(typeof(ResponseEntidadeBase), 200)]
        [ProducesResponseType(typeof(ResponseFalha), 400)]
        [ProducesResponseType(typeof(ResponseFalha), 403)]
        [ProducesResponseType(typeof(ResponseFalha), 409)]
        [ProducesResponseType(typeof(ResponseFalha), 500)]
        [ProducesResponseType(typeof(ResponseFalha), 502)]
        public async Task<IActionResult> ObterProdutoCliente(int codigo)
        {
            var retorno = await _produtoAppServ.ObterProdutoCliente(codigo);
            return Response(retorno?.ToResponseProdutoCliente());
        }

        [HttpPost("Adicionar")]
        [Consumes("application/Json")]
        [Produces("application/Json")]
        [ProducesResponseType(typeof(ResponseEntidadeBase), 200)]
        [ProducesResponseType(typeof(ResponseFalha), 400)]
        [ProducesResponseType(typeof(ResponseFalha), 403)]
        [ProducesResponseType(typeof(ResponseFalha), 409)]
        [ProducesResponseType(typeof(ResponseFalha), 500)]
        [ProducesResponseType(typeof(ResponseFalha), 502)]
        public async Task<IActionResult> Adicionar([FromBody] RequestAdicionarProduto request)
        {
            return Response(await _produtoAppServ.Adicionar(request.ToRequest()));
        }

        [HttpPut("Alterar")]
        [Consumes("application/Json")]
        [Produces("application/Json")]
        [ProducesResponseType(typeof(ResponseEntidadeBase), 200)]
        [ProducesResponseType(typeof(ResponseFalha), 400)]
        [ProducesResponseType(typeof(ResponseFalha), 403)]
        [ProducesResponseType(typeof(ResponseFalha), 409)]
        [ProducesResponseType(typeof(ResponseFalha), 500)]
        [ProducesResponseType(typeof(ResponseFalha), 502)]
        public async Task<IActionResult> Alterar([FromBody] RequestAtualizarProduto request)
        {
            return Response(await _produtoAppServ.Alterar(request.ToRequest()));
        }

        [HttpPut("Excluir")]
        [Consumes("application/Json")]
        [Produces("application/Json")]
        [ProducesResponseType(typeof(ResponseEntidadeBase), 200)]
        [ProducesResponseType(typeof(ResponseFalha), 400)]
        [ProducesResponseType(typeof(ResponseFalha), 403)]
        [ProducesResponseType(typeof(ResponseFalha), 409)]
        [ProducesResponseType(typeof(ResponseFalha), 500)]
        [ProducesResponseType(typeof(ResponseFalha), 502)]
        public async Task<IActionResult> Excluir([FromBody] RequestReativarExcluirProduto request)
        {
            return Response(await _produtoAppServ.Excluir(request.ToRequest()));
        }

        [HttpPut("Reativar")]
        [Consumes("application/Json")]
        [Produces("application/Json")]
        [ProducesResponseType(typeof(ResponseEntidadeBase), 200)]
        [ProducesResponseType(typeof(ResponseFalha), 400)]
        [ProducesResponseType(typeof(ResponseFalha), 403)]
        [ProducesResponseType(typeof(ResponseFalha), 409)]
        [ProducesResponseType(typeof(ResponseFalha), 500)]
        [ProducesResponseType(typeof(ResponseFalha), 502)]
        public async Task<IActionResult> Reativar([FromBody] RequestReativarExcluirProduto request)
        {
            return Response(await _produtoAppServ.Reativar(request.ToRequest()));
        }

        #endregion
    }
}
