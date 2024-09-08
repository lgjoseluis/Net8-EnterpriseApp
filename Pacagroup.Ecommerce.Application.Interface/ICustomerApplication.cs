using System.Threading.Tasks;

using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Transversal.Common;

namespace Pacagroup.Ecommerce.Application.Interface
{
    public interface ICustomerApplication
    {
        #region sync methods
        Response<bool> Insert(CustomerDto customerDto);

        Response<bool> Update(CustomerDto customerDto);

        Response<bool> Delete(string customerId);

        Response<CustomerDto> Get(string customerId);

        Response<IEnumerable<CustomerDto>> GetAll();
        #endregion

        #region async methods
        Task<Response<bool>> InsertAsync(CustomerDto customerDto);

        Task<Response<bool>> UpdateAsync(CustomerDto customerDto);

        Task<Response<bool>> DeleteAsync(string customerId);

        Task<Response<CustomerDto>> GetAsync(string customerId);

        Task<Response<IEnumerable<CustomerDto>>> GetAllAsync();
        #endregion
    }
}
