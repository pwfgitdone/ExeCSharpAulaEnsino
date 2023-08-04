using Daniel.AulaEnsino.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daniel.AulaEnsino.Core.Domain.Interfaces.Repositories
{
    public interface IEnderecoRepository : IRepositoryBase<Endereco>
    {
        Task<Endereco> ObterEnderecoPorCliente(int codigoCliente);
    }
}
