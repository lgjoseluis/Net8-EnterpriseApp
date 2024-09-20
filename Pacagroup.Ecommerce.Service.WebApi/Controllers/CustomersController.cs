using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Application.Interface;
using Pacagroup.Ecommerce.Transversal.Common;


namespace Pacagroup.Ecommerce.Service.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerApplication _customerApplication;

        public CustomersController(ICustomerApplication customerApplication)
        {
            this._customerApplication = customerApplication;
        }        

        #region async methods
        [HttpPost]
        [SwaggerOperation(
            Summary = "Create a customer",
            Description = "Create a customer"

        )]
        [SwaggerResponse(StatusCodes.Status200OK, "OK. Customer created", typeof(bool))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad Request. Validate the data sent in the request", typeof(ProblemDetails))]
        public async Task<IActionResult> InsertAsync([FromBody, SwaggerRequestBody("Customer payload", Required = true)] CustomerDto customerDto)
        {
            if (customerDto is null)
                return BadRequest();

            Response<bool> response = await _customerApplication.InsertAsync(customerDto);

            if (response.IsSuccess)
                return Ok(response);

            return NotFound(response.Message);  //TODO: [Status for NO CONTENT, check ProblemDetails]
        }

        [HttpPut]
        [SwaggerOperation(
            Summary = "Update a customer",
            Description = "Update a customer"

        )]
        [SwaggerResponse(StatusCodes.Status200OK, "OK. Customer updated", typeof(bool))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad Request. Validate the data sent in the request", typeof(ProblemDetails))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Not Found. Customer not found", typeof(ProblemDetails))]
        public async Task<IActionResult> UpdateAsync([FromBody, SwaggerRequestBody("Customer payload", Required = true)] CustomerDto customerDto)
        {
            if (customerDto is null)
                return BadRequest();

            Response<bool> response = await _customerApplication.UpdateAsync(customerDto);

            if (response.IsSuccess)
                return Ok(response);

            return NotFound(response.Message);
        }


        [HttpDelete("{customerId}")]
        [SwaggerOperation(
            Summary = "Delete a customer by ID",
            Description = "Delete a customer"
            
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "OK. Customer deleted", typeof(bool))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad Request. Validate the data sent in the request (ID)", typeof(ProblemDetails))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Not Found. Customer not found", typeof(ProblemDetails))]
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
        [SwaggerOperation(
            Summary = "Returns a customer by ID",
            Description = "Information about a customer by ID"            
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "OK. Customer information", typeof(CustomerDto))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad Request. Validate the data sent in the request (ID)", typeof(ProblemDetails))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Not Found. Customer not found", typeof(ProblemDetails))]        
        public async Task<IActionResult> Get([FromRoute] string customerId)
        {
            if (string.IsNullOrEmpty(customerId))
                return BadRequest();

            Response<CustomerDto> response = await _customerApplication.GetAsync(customerId);

            if (response.IsSuccess)
                return Ok(response);

            return NotFound(response.Message);
        }
        

        [HttpGet]
        [SwaggerOperation(
            Summary = "Returns a list of customers",
            Description = "A list of customers"
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "OK. A list of customers", typeof(IEnumerable<CustomerDto>))]        
        [SwaggerResponse(StatusCodes.Status404NotFound, "Not Found. Customer's list not found", typeof(ProblemDetails))]
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
