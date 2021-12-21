namespace Poo.Api.Core.Domain.Shared.Repositories
{
    public interface IUnitOfWork
    {
        void SaveChanges();
    }
}