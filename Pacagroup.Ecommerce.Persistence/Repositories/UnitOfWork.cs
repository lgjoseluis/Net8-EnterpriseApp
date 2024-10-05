using System.Data;
using Pacagroup.Ecommerce.Application.Interface.Persistence;

namespace Pacagroup.Ecommerce.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbConnection _dbConnection;
        private IDbTransaction? _dbTransaction;

        public ICustomerRepository Customers { get; }
        public IUserRepository Users { get; }

        public UnitOfWork(IDbConnection dbConnection, ICustomerRepository customerRepository, IUserRepository userRepository)
        {
            _dbConnection = dbConnection;
            Customers = customerRepository;
            Users = userRepository;

            ((RepositoryBase)Customers).SetConnection(_dbConnection);
            ((RepositoryBase)Users).SetConnection(_dbConnection);
        }

        public async Task BeginTransactionAsync()
        {
            if (_dbTransaction == null)
            {
                _dbConnection.Open();
                _dbTransaction = await Task.FromResult(_dbConnection.BeginTransaction());
                ((RepositoryBase)Users).SetTransaction(_dbTransaction);
                ((RepositoryBase)Customers).SetTransaction(_dbTransaction);

            }
        }

        public async Task CommitAsync()
        {
            if (_dbTransaction != null)
            {
                await Task.Run(() => _dbTransaction.Commit());
                _dbTransaction = null;
                _dbConnection.Close();
            }
        }

        public async Task RollbackAsync()
        {
            if (_dbTransaction != null)
            {
                await Task.Run(() => _dbTransaction.Rollback());
                _dbTransaction = null;
                _dbConnection.Close();
            }
        }

        public void Dispose()
        {
            if (_dbTransaction != null)
            {
                _dbTransaction.Dispose();
            }
            _dbConnection.Dispose();

            GC.SuppressFinalize(this);
        }
    }
}
