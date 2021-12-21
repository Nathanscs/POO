using MediatR;

namespace Poo.Api.Core.Domain.Shared;

    public interface IAggregateRoot
    {
        ICollection<INotification> GetDomainEvents();
        void ClearDomainEvents();
    }
