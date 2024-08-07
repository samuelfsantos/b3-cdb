using FluentValidation.Results;
using System.Collections.Generic;

namespace B3.Cdb.Domain.Notifications
{
    public interface INotifier
    {
        bool HasNotifications();
        List<Notification> GetNotifications();
        void Add(Notification notification);
        void NotifyErrors(ValidationResult validationResult);
    }
}
