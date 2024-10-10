using AutoMapper;
using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Application.Interface.Persistence;
using Pacagroup.Ecommerce.Application.Interface.UseCases;
using Pacagroup.Ecommerce.Domain.Entity;
using Pacagroup.Ecommerce.Transversal.Common;

namespace Pacagroup.Ecommerce.Application.UseCases.CustomersApp
{
    public class CustomerApplication : ICustomerApplication
    {
        private readonly IMapper _mapper;
        private readonly IAppLogger<CustomerApplication> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerApplication(IMapper mapper, IAppLogger<CustomerApplication> logger, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        #region async methods
        public async Task<Response<bool>> InsertAsync(CustomerDto customerDto)
        {
            Response<bool> response = new Response<bool>();

            Customers customer = _mapper.Map<Customers>(customerDto);

            response.Data = await _unitOfWork.Customers.InsertAsync(customer);

            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = "Registro exitoso";
            }

            return response;
        }

        public async Task<Response<bool>> UpdateAsync(CustomerDto customerDto)
        {
            Response<bool> response = new Response<bool>();

            Customers customer = _mapper.Map<Customers>(customerDto);

            response.Data = await _unitOfWork.Customers.UpdateAsync(customer);

            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = "Actualización exitosa";
                _logger.LogInformation($"Actualización exitosa. [{nameof(Customers)}]<<Id: {customer.CustomerId}>>");
            }

            return response;
        }

        public async Task<Response<bool>> DeleteAsync(string customerId)
        {
            Response<bool> response = new Response<bool>();

            response.Data = await _unitOfWork.Customers.DeleteAsync(customerId);

            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = "Eliminación exitosa";
            }


            return response;
        }

        public async Task<Response<CustomerDto>> GetAsync(string customerId)
        {
            Response<CustomerDto> response = new Response<CustomerDto>();

            Customers? customer = await _unitOfWork.Customers.GetAsync(customerId);

            response.Data = _mapper.Map<CustomerDto>(customer);

            if (response.Data != null)
            {
                response.IsSuccess = true;
                response.Message = "Consulta exitosa";
                _logger.LogInformation($"Consulta exitosa. [{nameof(Customers)}]<<Id: {customerId}>>");
            }

            return response;
        }

        public async Task<Response<IEnumerable<CustomerDto>>> GetAllAsync()
        {
            Response<IEnumerable<CustomerDto>> response = new Response<IEnumerable<CustomerDto>>();

            IEnumerable<Customers> customers = await _unitOfWork.Customers.GetAllAsync();

            response.Data = _mapper.Map<IEnumerable<CustomerDto>>(customers);

            if (response.Data != null)
            {
                response.IsSuccess = true;
                response.Message = "Consulta exitosa";
            }

            return response;
        }
        #endregion
    }
}
