using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace B3.Cdb.Domain.Notifications
{
    public class Notifier : INotifier
    {
        private readonly List<Notification> _notifications;

        public Notifier()
        {
            _notifications = new List<Notification>();
        }

        public bool HasNotifications()
        {
            return _notifications.Any();
        }

        public List<Notification> GetNotifications()
        {
            return _notifications;
        }

        public void Add(Notification notification)
        {
            _notifications.Add(notification);
        }

        public void NotifyErrors(ValidationResult validationResult)
        {
            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    _notifications.Add(new Notification(error.ErrorMessage));
                }
            }
        }
    }
}
