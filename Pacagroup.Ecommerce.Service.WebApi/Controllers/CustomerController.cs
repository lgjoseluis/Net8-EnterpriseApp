using Microsoft.AspNetCore.Mvc;

using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Application.Interface;
using Pacagroup.Ecommerce.Transversal.Common;

namespace Pacagroup.Ecommerce.Service.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerApplication _customerApplication;

        public CustomerController(ICustomerApplication customerApplication)
        {
            this._customerApplication = customerApplication;
        }        

        #region async methods
        [HttpPost]
        public async Task<IActionResult> InsertAsync([FromBody] CustomerDto customerDto)
        {
            if (customerDto is null)
                return BadRequest();

            Response<bool> response = await _customerApplication.InsertAsync(customerDto);

            if (response.IsSuccess)
                return Ok(response);

            return NotFound(response.Message);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] CustomerDto customerDto)
        {
            if (customerDto is null)
                return BadRequest();

            Response<bool> response = await _customerApplication.UpdateAsync(customerDto);

            if (response.IsSuccess)
                return Ok(response);

            return NotFound(response.Message);
        }

        [HttpDelete("{customerId}")]
        public async Task<IActionResult> DeleteAsync(string customerId)
        {
            if (string.IsNullOrEmpty(customerId))
                return BadRequest();

            Response<bool> response = await _customerApplication.DeleteAsync(customerId);

            if (response.IsSuccess)
                return Ok(response);

            return NotFound(response.Message);
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> Get(string customerId)
        {
            if (string.IsNullOrEmpty(customerId))
                return BadRequest();

            Response<CustomerDto> response = await _customerApplication.GetAsync(customerId);

            if (response.IsSuccess)
                return Ok(response);

            return NotFound(response.Message);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        { 
            Response<IEnumerable<CustomerDto>> response = await _customerApplication.GetAllAsync();

            if (response.IsSuccess)
                return Ok(response);

            return NotFound(response.Message);
        }
        #endregion
    }
}
