using System.Collections.Generic;
using System.Threading.Tasks;

using Pacagroup.Ecommerce.Domain.Entity;
using Pacagroup.Ecommerce.Domain.Interface;
using Pacagroup.Ecommerce.Infrastructure.Interface;

namespace Pacagroup.Ecommerce.Domain.Core
{
    public class CustomerDomain : ICustomerDomain
    {
        private readonly IUnitOfWork _unitOfWork;        

        public CustomerDomain(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        #region async methods
        public async Task<bool> InsertAsync(Customers customer)
        {
            return await this._unitOfWork.Customers.InsertAsync(customer);
        }

        public async Task<bool> UpdateAsync(Customers customer)
        {
            await _unitOfWork.BeginTransactionAsync();

            bool result = await this._unitOfWork.Customers.UpdateAsync(customer);

            await _unitOfWork.CommitAsync();

            return result;
        }

        public async Task<bool> DeleteAsync(string customerId)
        {
            return await this._unitOfWork.Customers.DeleteAsync(customerId);
        }

        public async Task<Customers?> GetAsync(string customerId)
        {
            Customers? result = await this._unitOfWork.Customers.GetAsync(customerId);

            return result;
        }

        public async Task<IEnumerable<Customers>> GetAllAsync()
        {
            return await this._unitOfWork.Customers.GetAllAsync();
        }
        #endregion
    }
}
