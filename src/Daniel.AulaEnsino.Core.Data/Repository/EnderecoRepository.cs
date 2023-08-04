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
    public class EnderecoRepository : RepositoryBase<Endereco>, IEnderecoRepository
    {
        #region Constructor

        public EnderecoRepository(MeuContextoBD context) : base(context) { }

        #endregion

        #region Methods

        public async Task<Endereco> ObterEnderecoPorCliente(int codigoCliente)
        {
            return await Db.Enderecos.AsNoTracking()
                .FirstOrDefaultAsync(f => f.CodigoCliente == codigoCliente);
        }

        #endregion
    }
}
