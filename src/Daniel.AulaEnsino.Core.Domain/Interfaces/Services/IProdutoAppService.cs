using Daniel.AulaEnsino.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daniel.AulaEnsino.Core.Domain.Interfaces.Services
{
    public interface IProdutoAppService : IDisposable
    {
        Task<IEnumerable<Produto>> ListarTodos();

        Task<IEnumerable<Produto>> ListarTodosAtivos();

        Task<IEnumerable<Produto>> ListarProdutosPorCliente(int clienteId);

        //  Task<IEnumerable<Produto>> ListarProdutosClientes();
        Task<ICollection<Produto>> BuscarProdutosClientes(Produto prod);

        Task<Produto> ObterPorCodigo(int codigo);

        Task<Produto> ObterProdutoCliente(int codigo);

        Task<int> Adicionar(Produto entity);

        Task<bool> Alterar(Produto entity);

        Task<bool> Excluir(Produto entity);

        Task<bool> Reativar(Produto entity);
    }
}
