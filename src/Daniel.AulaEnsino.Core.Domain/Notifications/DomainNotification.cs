using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daniel.AulaEnsino.Core.Domain.Notifications
{
    public class DomainNotification
    {
        #region Properties

        public string Key { get; private set; }

        public string Value { get; private set; }

        #endregion

        #region Constructor

        public DomainNotification(string key, string value)
        {
            Key = key;
            Value = value;
        }

        #endregion
    }
}
