using Daniel.AulaEnsino.Core.Domain.Entities;
using Daniel.AulaEnsino.Core.WebApi.ViewModels.DTOs;
using Daniel.AulaEnsino.Core.WebApi.ViewModels.Request.Produto;

namespace Daniel.AulaEnsino.Core.WebApi.Mapper
{
    public static class ProdutoEntityToViewModel
    {
        #region "ToRequest"

        public static Produto ToRequest(this RequestAdicionarProduto request)
        {
            var retorno = new Produto();

            if (request != null)
            {
                retorno.Nome = request.Nome;
                retorno.Descricao = request.Descricao;
                retorno.Imagem = request.Imagem;
                retorno.Valor = request.Valor;
                retorno.Status = true;
                retorno.CodigoCliente = request.CodigoCliente;
            }

            return retorno;
        }

        public static Produto ToRequest(this RequestAtualizarProduto request)
        {
            var retorno = new Produto();

            if (request != null)
            {
                retorno.Codigo = request.Codigo;
                retorno.Nome = request.Nome;
                retorno.Descricao = request.Descricao;
                retorno.Imagem = request.Imagem;
                retorno.Valor = request.Valor;
                retorno.Status = true;
                retorno.CodigoCliente = request.CodigoCliente;
            }

            return retorno;
        }

        public static Produto ToRequest(this RequestBuscarProdutoCliente request)
        {
            var retorno = new Produto();

            if (request != null)
            {
                retorno.Nome = request.Nome != null ? request.Nome.Trim().ToUpper() : string.Empty;
                retorno.CodigoCliente = request.CodigoCliente ?? 0;
                retorno.StatusPesquisa = request.StatusPesquisa;
            }

            return retorno;
        }

        public static Produto ToRequest(this RequestReativarExcluirProduto request)
        {
            var retorno = new Produto();

            if (request != null)
                retorno.Codigo = request.Codigo;

            return retorno;
        }

        #endregion

        #region "ToResponse"

        public static ProdutoDTO ToResponse(this Produto entity)
        {
            var retorno = new ProdutoDTO();

            if (entity != null)
            {
                retorno.Codigo = entity.Codigo;
                retorno.Nome = entity.Nome;
                retorno.Status = entity.Status;
                retorno.Descricao = entity.Descricao;
                retorno.Valor = entity.Valor;
                retorno.Imagem = entity.Imagem;
                retorno.CodigoCliente = entity.CodigoCliente;
            }

            return retorno;
        }

        public static ProdutoDTO ToResponseProdutoCliente(this Produto entity)
        {
            var retorno = new ProdutoDTO();

            if (entity != null)
            {
                retorno.Codigo = entity.Codigo;
                retorno.Nome = entity.Nome;
                retorno.Status = entity.Status;
                retorno.Descricao = entity.Descricao;
                retorno.Valor = entity.Valor;
                retorno.Imagem = entity.Imagem;
                retorno.CodigoCliente = entity.CodigoCliente;
                retorno.Cliente = entity?.Cliente?.ToResponse() ?? new ClienteDTO();
            }

            return retorno;
        }

        public static List<ProdutoDTO> ToResponse(this ICollection<Produto> entities)
        {
            var lista = new List<ProdutoDTO>();

            if (entities.Count > 0)
            {
                foreach (var item in entities)
                {
                    var produto = new ProdutoDTO();
                    produto.Codigo = item.Codigo;
                    produto.Nome = item.Nome;
                    produto.Status = item.Status;
                    produto.Descricao = item.Descricao;
                    produto.Valor = item.Valor;
                    produto.Imagem = item.Imagem;
                    produto.CodigoCliente = item.CodigoCliente;

                    lista.Add(produto);
                }
            }

            return lista;
        }

        #endregion
    }
}
