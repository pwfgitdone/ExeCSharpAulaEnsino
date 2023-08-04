using Daniel.AulaEnsino.Core.Domain.Interfaces.Notifications;
using Daniel.AulaEnsino.Core.Domain.Notifications;
using Daniel.AulaEnsino.Core.WebApi.ViewModels.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Daniel.AulaEnsino.Core.WebApi.Controllers
{
    public abstract class APIController : ControllerBase
    {
        #region Properties

        protected readonly DomainNotificationHandler _notifications;
        protected IEnumerable<DomainNotification> Notifications =>
                    _notifications.GetNotifications();

        #endregion

        #region Constructor

        protected APIController(INotificationHandler<DomainNotification> notifications)
        {
            _notifications = (DomainNotificationHandler)notifications;
        }

        #endregion

        #region Methods

        protected bool IsValidOperation() =>
            (!_notifications.HasNotifications());

        protected new IActionResult Response(object result = null)
        {
            if (IsValidOperation())
            {
                return Ok(new ResponseSuccesso<object>
                {
                    Success = true,
                    Data = result
                });
            }

            return Conflict(new ResponseFalha
            {
                Success = false,
                Errors = _notifications.GetNotifications().Select(n => n.Value)
            });
        }

        #endregion
    }
}
