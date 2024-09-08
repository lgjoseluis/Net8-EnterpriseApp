using System.Collections.Generic;
using System.Threading.Tasks;

using Pacagroup.Ecommerce.Domain.Entity;
using Pacagroup.Ecommerce.Domain.Interface;
using Pacagroup.Ecommerce.Infrastructure.Interface;

namespace Pacagroup.Ecommerce.Domain.Core
{
    public class CustomerDomain : ICustomerDomain
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerDomain(ICustomerRepository customerRepository)
        {
            this._customerRepository = customerRepository;
        }

        #region sync methods
        public bool Insert(Customer customer)
        {
            return this._customerRepository.Insert(customer);
        }

        public bool Update(Customer customer)
        {
            return this._customerRepository.Update(customer);
        }

        public bool Delete(string customerId)
        {
            return this._customerRepository.Delete(customerId);
        }        

        public Customer Get(string customerId)
        {
            return this._customerRepository.Get(customerId);
        }

        public IEnumerable<Customer> GetAll()
        {
            return this._customerRepository.GetAll();
        }
        #endregion


        #region async methods
        public async Task<bool> InsertAsync(Customer customer)
        {
            return await this._customerRepository.InsertAsync(customer);
        }

        public async Task<bool> UpdateAsync(Customer customer)
        {
            return await this._customerRepository.UpdateAsync(customer);
        }

        public async Task<bool> DeleteAsync(string customerId)
        {
            return await this._customerRepository.DeleteAsync(customerId);
        }

        public async Task<Customer> GetAsync(string customerId)
        {
            return await this._customerRepository.GetAsync(customerId);
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await this._customerRepository.GetAllAsync();
        }
        #endregion
    }
}
