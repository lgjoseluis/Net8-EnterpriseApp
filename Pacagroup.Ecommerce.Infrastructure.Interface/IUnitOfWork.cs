using System.Data;

namespace Pacagroup.Ecommerce.Infrastructure.Interface
{
    public interface IUnitOfWork:IDisposable
    {
        ICustomerRepository Customers { get; }
        IUserRepository Users { get; }

        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
