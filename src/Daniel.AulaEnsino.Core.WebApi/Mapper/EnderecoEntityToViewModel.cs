using Daniel.AulaEnsino.Core.Domain.Entities;
using Daniel.AulaEnsino.Core.WebApi.ViewModels.DTOs;
using Daniel.AulaEnsino.Core.WebApi.ViewModels.Request.Endereco;

namespace Daniel.AulaEnsino.Core.WebApi.Mapper
{
    public static class EnderecoEntityToViewModel
    {
        /// <summary>
        /// Request de inclusão do endereço por cliente
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static Endereco ToRequest(this RequestEndereco entity)
        {
            return new Endereco()
            {
                Codigo = entity.Codigo ?? 0,
                Logradouro = entity.Logradouro,
                Numero = entity.Numero,
                Complemento = entity.Complemento,
                Bairro = entity.Bairro,
                Cep = entity.Cep,
                Cidade = entity.Cidade,
                Estado = entity.Estado,
                CodigoCliente = entity.CodigoCliente ?? 0
            };
        }

        public static EnderecoDTO ToResponse(this Endereco entity)
        {
            var retorno = new EnderecoDTO();

            if (entity != null)
            {
                retorno.Codigo = entity.Codigo;
                retorno.Logradouro = entity.Logradouro;
                retorno.Numero = entity.Numero;
                retorno.Complemento = entity.Complemento;
                retorno.Bairro = entity.Bairro;
                retorno.Cep = entity.Cep;
                retorno.Cidade = entity.Cidade;
                retorno.Estado = entity.Estado;
                retorno.CodigoCliente = entity?.CodigoCliente;
            }

            return retorno;
        }
    }
}
