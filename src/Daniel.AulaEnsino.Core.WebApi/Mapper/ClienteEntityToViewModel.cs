using Daniel.AulaEnsino.Common.Utilities;
using Daniel.AulaEnsino.Core.Domain.Entities;
using Daniel.AulaEnsino.Core.WebApi.ViewModels.DTOs;
using Daniel.AulaEnsino.Core.WebApi.ViewModels.Request.Cliente;

namespace Daniel.AulaEnsino.Core.WebApi.Mapper
{
    public static class ClienteEntityToViewModel
    {
        #region "ToRequest"

        public static Cliente ToRequest(this RequestAdicionarCliente request)
        {
            var retorno = new Cliente();

            if (request != null)
            {
                retorno.Nome = request.Nome;
                retorno.Documento = Util.RemoveNaoNumericos(request.Documento);
                retorno.TipoPessoa = request.TipoPessoa.Trim().ToUpper();
                retorno.Status = true;
                retorno.Endereco = request?.Endereco.ToRequest() ?? new Endereco();
            }

            return retorno;
        }

        public static Cliente ToRequest(this RequestAtualizarCliente request)
        {
            var retorno = new Cliente();

            if (request != null)
            {
                retorno.Codigo = request.Codigo;
                retorno.Nome = request.Nome;
                retorno.Documento = Util.RemoveNaoNumericos(request.Documento);
                retorno.TipoPessoa = request.TipoPessoa.Trim().ToUpper();

                retorno.Endereco = request?.Endereco.ToRequest() ?? new Endereco();
            }

            return retorno;
        }

        public static Cliente ToRequest(this RequestReativarExcluirCliente request)
        {
            return new Cliente()
            {
                Codigo = request.Codigo
            };
        }

        public static Cliente ToRequest(this RequestBuscarCliente request)
        {
            return new Cliente()
            {
                Nome = request.Nome != null ? request.Nome.Trim().ToUpper() : string.Empty,
                TipoPessoa = request.TipoPessoa != null ? request.TipoPessoa.Trim().ToUpper() : string.Empty,
                Documento = request.Documento != null ? request.Documento.Trim() : string.Empty,
                StatusPesquisa = request.StatusPesquisa
            };
        }

        #endregion

        #region "ToResponse"

        public static ClienteDTO ToResponse(this Cliente entity)
        {
            return new ClienteDTO()
            {
                Codigo = entity.Codigo,
                Nome = entity.Nome,
                Status = entity.Status,
                Documento = entity.Documento,
                TipoPessoa = entity.TipoPessoa.Trim().ToUpper(),
                Endereco = entity?.Endereco.ToResponse() ?? new EnderecoDTO()
            };
        }

        public static ClienteDTO ToResponseClienteEndereco(this Cliente entity)
        {
            return new ClienteDTO()
            {
                Codigo = entity.Codigo,
                Nome = entity.Nome,
                Status = entity.Status,
                Documento = entity.Documento,
                TipoPessoa = entity.TipoPessoa.Trim().ToUpper(),
                Endereco = entity?.Endereco.ToResponse() ?? new EnderecoDTO(),
                Produtos = entity?.Produtos?.ToResponse()
            };
        }

        #endregion
    }
}
