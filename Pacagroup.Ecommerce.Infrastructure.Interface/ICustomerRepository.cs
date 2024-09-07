﻿using Pacagroup.Ecommerce.Domain.Entity;

namespace Pacagroup.Ecommerce.Infrastructure.Interface
{
    public interface ICustomerRepository
    {
        #region sync methods
        bool Insert(Customer customer);

        bool Update(Customer customer);

        bool Delete(string customerId);

        Customer Get(string customerId);

        IEnumerable<Customer> GetAll();
        #endregion

        #region async methods
        Task<bool> InsertAsync(Customer customer);

        Task<bool> UpdateAsync(Customer customer);

        Task<bool> DeleteAsync(string customerId);

        Task<Customer> GetAsync(string customerId);

        Task<IEnumerable<Customer>> GetAllAsync();
        #endregion
    }
}
