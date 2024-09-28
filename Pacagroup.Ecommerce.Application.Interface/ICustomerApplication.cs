using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Transversal.Common;

namespace Pacagroup.Ecommerce.Application.Interface
{
    public interface ICustomerApplication
    {
        #region async methods
        Task<Response<bool>> InsertAsync(CustomerDto customerDto);

        Task<Response<bool>> UpdateAsync(CustomerDto customerDto);

        Task<Response<bool>> DeleteAsync(string customerId);

        Task<Response<CustomerDto>> GetAsync(string customerId);

        Task<Response<IEnumerable<CustomerDto>>> GetAllAsync();
        #endregion
    }
}
