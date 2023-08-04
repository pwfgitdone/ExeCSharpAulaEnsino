using Daniel.AulaEnsino.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daniel.AulaEnsino.Core.Domain.Interfaces.Services
{
    public interface IClienteAppService : IDisposable
    {
        Task<IEnumerable<Cliente>> ListarTodos();

        Task<ICollection<Cliente>> BuscarClientes(Cliente pesq);

        Task<Cliente> ObterPorCodigo(int codigo);

        Task<Cliente> ObterClienteEndereco(int codigoCliente);

        Task<int> Adicionar(Cliente entity);

        Task<bool> Alterar(Cliente entity);

        Task<bool> Excluir(Cliente entity);

        Task<bool> Reativar(Cliente entity);

        Task<Cliente> NomeExiste(string nomeDoCliente);

        Task<Cliente> DocumentoExiste(string documento);
    }
}
