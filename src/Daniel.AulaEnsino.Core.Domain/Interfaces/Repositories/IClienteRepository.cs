using Daniel.AulaEnsino.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Daniel.AulaEnsino.Core.Domain.Interfaces.Repositories
{
    public interface IClienteRepository : IRepositoryBase<Cliente>
    {
        Task<Cliente> NomeExiste(string nomeDoCliente);

        Task<Cliente> DocumentoExiste(string documento);

        Task<Cliente> ObterClienteEndereco(int codigoCliente);

        Task<IEnumerable<Cliente>> ListarTodosClienteEndereco();

        Task<ICollection<Cliente>> BuscarClientes(Cliente pesq);
    }
}
