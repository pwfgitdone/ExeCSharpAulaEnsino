using Daniel.AulaEnsino.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daniel.AulaEnsino.Core.Domain.Interfaces.Repositories
{
    public interface IProdutoRepository : IRepositoryBase<Produto>
    {
        Task<IEnumerable<Produto>> ListarTodosAtivos();

        Task<IEnumerable<Produto>> ListarProdutosPorCliente(int clienteId);

        // Task<IEnumerable<Produto>> ListarProdutosClientes();
        Task<ICollection<Produto>> BuscarProdutosClientes(Produto prod);

        Task<Produto> ObterProdutoCliente(int codigo);
    }
}
