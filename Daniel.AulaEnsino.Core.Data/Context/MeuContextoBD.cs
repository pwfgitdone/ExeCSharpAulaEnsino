using Microsoft.EntityFrameworkCore;

namespace Daniel.AulaEnsino.Core.Data.Context
{
    public class MeuContextoBD : DbContext
    {
        #region Constructor
        public MeuContextoBD(DbContextOptions options) : base(options) { } 

        #endregion
    }
}