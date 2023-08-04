using Daniel.AulaEnsino.Core.Data.Context;
using Daniel.AulaEnsino.Core.Domain.Entities;
using Daniel.AulaEnsino.Core.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daniel.AulaEnsino.Core.Data.Repository
{
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
        #region Constructor

        public ClienteRepository(MeuContextoBD context) : base(context) { }

        #endregion

        #region Methods

        public async Task<IEnumerable<Cliente>> ListarTodosClienteEndereco()
        {
            return await Db.Clientes.AsNoTracking()
                                    .Where(x => x.Status)
                                    .Include(c => c.Endereco)
                                    .ToListAsync();
        }

        public async Task<ICollection<Cliente>> BuscarClientes(Cliente pesq)
        {
            var query = Db.Clientes.AsNoTracking()
                                   .Include(e => e.Endereco)
                                   .Include(f => f.Produtos)
                                   .AsQueryable();

            if (pesq.Codigo != 0)
            {
                query = query.Where(x => x.Codigo == pesq.Codigo);
            }

            if (!string.IsNullOrEmpty(pesq.Nome))
            {
                query = query.Where(x => x.Nome.Trim().ToUpper().Contains(pesq.Nome.Trim().ToUpper()));
            }

            if (!string.IsNullOrEmpty(pesq.Documento))
            {
                query = query.Where(x => x.Documento.Trim().Equals(pesq.Documento.Trim()));
            }

            if (!string.IsNullOrEmpty(pesq.TipoPessoa))
            {
                query = query.Where(x => x.TipoPessoa.Trim().ToUpper() == pesq.TipoPessoa.Trim().ToUpper());
            }

            if (!string.IsNullOrEmpty(pesq.StatusPesquisa))
            {
                var bStatus = Convert.ToInt32(pesq.StatusPesquisa) == 0 ? false : true;
                query = query.Where(x => x.Status == bStatus);
            }

            var retorno = await query.OrderBy(p => p.Nome).ToListAsync();
            return retorno;
        }

        public async Task<Cliente> NomeExiste(string nomeDoCliente)
        {
            return await DbSet.Where(x => x.Nome.Trim().Contains(nomeDoCliente.Trim())).FirstOrDefaultAsync();
        }

        public async Task<Cliente> DocumentoExiste(string documento)
        {
            return await DbSet.Where(x => x.Documento.Trim().Equals(documento.Trim())).FirstOrDefaultAsync();
        }

        public async Task<Cliente> ObterClienteEndereco(int codigoCliente)
        {
            return await Db.Clientes.AsNoTracking()
                .Include(c => c.Endereco)
                .FirstOrDefaultAsync(c => c.Codigo == codigoCliente);
        }

        #endregion
    }
}
