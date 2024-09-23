using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pacagroup.Ecommerce.Domain.Entity;

namespace Pacagroup.Ecommerce.Domain.Interface
{
    public interface ICustomerDomain
    {
        #region sync methods
        bool Insert(Customers customer);

        bool Update(Customers customer);

        bool Delete(string customerId);

        Customers Get(string customerId);

        IEnumerable<Customers> GetAll();
        #endregion

        #region async methods
        Task<bool> InsertAsync(Customers customer);

        Task<bool> UpdateAsync(Customers customer);

        Task<bool> DeleteAsync(string customerId);

        Task<Customers> GetAsync(string customerId);

        Task<IEnumerable<Customers>> GetAllAsync();
        #endregion
    }
}
