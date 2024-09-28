using Pacagroup.Ecommerce.Domain.Entity;

namespace Pacagroup.Ecommerce.Domain.Interface
{
    public interface ICustomerDomain
    {
        #region async methods
        Task<bool> InsertAsync(Customers customer);

        Task<bool> UpdateAsync(Customers customer);

        Task<bool> DeleteAsync(string customerId);

        Task<Customers?> GetAsync(string customerId);

        Task<IEnumerable<Customers>> GetAllAsync();
        #endregion
    }
}
