namespace Pacagroup.Ecommerce.Application.Interface.Persistence
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
