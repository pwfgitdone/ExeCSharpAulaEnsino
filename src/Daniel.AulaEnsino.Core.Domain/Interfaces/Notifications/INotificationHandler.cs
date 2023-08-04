using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daniel.AulaEnsino.Core.Domain.Interfaces.Notifications
{
    public interface INotificationHandler<T> where T : class
    {
        Task Handler(T notification);
    }
}
