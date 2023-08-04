using Microsoft.AspNetCore.Mvc;
using Daniel.AulaEnsino.Core.Domain.Interfaces.Notifications;
using Daniel.AulaEnsino.Core.Domain.Interfaces.Services;
using Daniel.AulaEnsino.Core.Domain.Notifications;
using Daniel.AulaEnsino.Core.WebApi.ViewModels.Responses;
using Daniel.AulaEnsino.Core.WebApi.ViewModels.Request.Cliente;
using Daniel.AulaEnsino.Core.WebApi.Mapper;
using Daniel.AulaEnsino.Common.Utilities;

namespace Daniel.AulaEnsino.Core.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : APIController
    {
        #region Properties

        private readonly IClienteAppService _clienteAppServ;

        #endregion

        #region Constructor

        public ClienteController(INotificationHandler<DomainNotification> notifications,
            IClienteAppService clienteAppServ) : base(notifications)
        {
            _clienteAppServ = clienteAppServ;
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
            var retorno = await _clienteAppServ.ListarTodos();
            return Response(retorno.Select(x => x.ToResponse()));
        }

        [HttpPost("BuscarClientes")]
        [Consumes("application/Json")]
        [Produces("application/Json")]
        [ProducesResponseType(typeof(ResponseEntidadeBase), 200)]
        [ProducesResponseType(typeof(ResponseFalha), 400)]
        [ProducesResponseType(typeof(ResponseFalha), 403)]
        [ProducesResponseType(typeof(ResponseFalha), 409)]
        [ProducesResponseType(typeof(ResponseFalha), 500)]
        [ProducesResponseType(typeof(ResponseFalha), 502)]
        public async Task<IActionResult> BuscarClientes([FromBody] RequestBuscarCliente request)
        {
            var retorno = await _clienteAppServ.BuscarClientes(request.ToRequest());
            return Response(retorno.Select(x => x.ToResponseClienteEndereco()));
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
            var retorno = await _clienteAppServ.ObterPorCodigo(codigo);
            return Response(retorno?.ToResponse());
        }

        [HttpGet("ObterClienteEndereco/{codigo}")]
        [Consumes("application/Json")]
        [Produces("application/Json")]
        [ProducesResponseType(typeof(ResponseEntidadeBase), 200)]
        [ProducesResponseType(typeof(ResponseFalha), 400)]
        [ProducesResponseType(typeof(ResponseFalha), 403)]
        [ProducesResponseType(typeof(ResponseFalha), 409)]
        [ProducesResponseType(typeof(ResponseFalha), 500)]
        [ProducesResponseType(typeof(ResponseFalha), 502)]
        public async Task<IActionResult> ObterClienteEndereco(int codigo)
        {
            var retorno = await _clienteAppServ.ObterClienteEndereco(codigo);
            return Response(retorno?.ToResponseClienteEndereco());
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
        public async Task<IActionResult> Adicionar([FromBody] RequestAdicionarCliente request)
        {
            return Response(await _clienteAppServ.Adicionar(request.ToRequest()));
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
        public async Task<IActionResult> Alterar([FromBody] RequestAtualizarCliente request)
        {
            return Response(await _clienteAppServ.Alterar(request.ToRequest()));
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
        public async Task<IActionResult> Excluir([FromBody] RequestReativarExcluirCliente request)
        {
            return Response(await _clienteAppServ.Excluir(request.ToRequest()));
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
        public async Task<IActionResult> Reativar([FromBody] RequestReativarExcluirCliente request)
        {
            return Response(await _clienteAppServ.Reativar(request.ToRequest()));
        }

        [HttpGet]
        [Route("NomeExiste/{nomeDoCliente}")]
        [Consumes("application/Json")]
        [Produces("application/Json")]
        [ProducesResponseType(typeof(ResponseEntidadeBase), 200)]
        [ProducesResponseType(typeof(ResponseFalha), 400)]
        [ProducesResponseType(typeof(ResponseFalha), 403)]
        [ProducesResponseType(typeof(ResponseFalha), 409)]
        [ProducesResponseType(typeof(ResponseFalha), 500)]
        [ProducesResponseType(typeof(ResponseFalha), 502)]
        public async Task<IActionResult> NomeExiste(string nomeDoCliente)
        {
            var retorno = await _clienteAppServ.NomeExiste(nomeDoCliente);
            return Response(retorno?.ToResponse());
        }

        [HttpGet]
        [Route("DocumentoExiste/{documento}")]
        [Consumes("application/Json")]
        [Produces("application/Json")]
        [ProducesResponseType(typeof(ResponseEntidadeBase), 200)]
        [ProducesResponseType(typeof(ResponseFalha), 400)]
        [ProducesResponseType(typeof(ResponseFalha), 403)]
        [ProducesResponseType(typeof(ResponseFalha), 409)]
        [ProducesResponseType(typeof(ResponseFalha), 500)]
        [ProducesResponseType(typeof(ResponseFalha), 502)]
        public async Task<IActionResult> DocumentoExiste(string documento)
        {
            var retorno = await _clienteAppServ.DocumentoExiste(Util.RemoveNaoNumericos(documento));
            return Response(retorno?.ToResponse());
        }

        #endregion
    }
}
