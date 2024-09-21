﻿using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;

using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Application.Interface;
using Pacagroup.Ecommerce.Domain.Entity;
using Pacagroup.Ecommerce.Domain.Interface;
using Pacagroup.Ecommerce.Transversal.Common;

namespace Pacagroup.Ecommerce.Application.Main
{
    public class CustomerApplication : ICustomerApplication
    {
        private readonly IMapper _mapper;
        private readonly IAppLogger<CustomerApplication> _logger;
        private readonly ICustomerDomain _customerDomain;

        public CustomerApplication(ICustomerDomain customerDomain, IMapper mapper, IAppLogger<CustomerApplication> logger) 
        { 
            _customerDomain = customerDomain;
            _mapper = mapper;
            _logger = logger;
        }

        #region sync methods
        public Response<bool> Insert(CustomerDto customerDto)
        {
            Response<bool> response = new Response<bool>();

            try
            {
                Customer customer = _mapper.Map<Customer>(customerDto);

                response.Data = _customerDomain.Insert(customer);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro exitoso";
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                response.Message = e.Message;             
            }

            return response;
        }

        public Response<bool> Update(CustomerDto customerDto)
        {
            Response<bool> response = new Response<bool>();

            try
            {
                Customer customer = _mapper.Map<Customer>(customerDto);

                response.Data = _customerDomain.Update(customer);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Actualización exitosa";
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                response.Message = e.Message;
            }

            return response;
        }

        public Response<bool> Delete(string customerId)
        {
            Response<bool> response = new Response<bool>();

            try
            {
                response.Data = _customerDomain.Delete(customerId);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Eliminación exitosa";
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                response.Message = e.Message;
            }

            return response;
        }        

        public Response<CustomerDto> Get(string customerId)
        {
            Response<CustomerDto> response = new Response<CustomerDto>();

            try
            {
                Customer customer =  _customerDomain.Get(customerId);

                response.Data = _mapper.Map<CustomerDto>(customer);

                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta exitosa";
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                response.Message = e.Message;
            }

            return response;
        }

        public Response<IEnumerable<CustomerDto>> GetAll()
        {
            Response<IEnumerable<CustomerDto>> response = new Response<IEnumerable<CustomerDto>>();

            try
            {
                IEnumerable<Customer> customers = _customerDomain.GetAll();

                response.Data = _mapper.Map<IEnumerable<CustomerDto>>(customers);

                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta exitosa";
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                response.Message = e.Message;
            }

            return response;
        }
        #endregion

        #region async methods
        public async Task<Response<bool>> InsertAsync(CustomerDto customerDto)
        {
            Response<bool> response = new Response<bool>();

            try
            {
                Customer customer = _mapper.Map<Customer>(customerDto);

                response.Data = await _customerDomain.InsertAsync(customer);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro exitoso";
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                response.Message = e.Message;
            }

            return response;
        }

        public async Task<Response<bool>> UpdateAsync(CustomerDto customerDto)
        {
            Response<bool> response = new Response<bool>();

            try
            {
                Customer customer = _mapper.Map<Customer>(customerDto);

                response.Data = await _customerDomain.UpdateAsync(customer);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Actualización exitosa";
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                response.Message = e.Message;
            }

            return response;
        }

        public async Task<Response<bool>> DeleteAsync(string customerId)
        {
            Response<bool> response = new Response<bool>();

            try
            {
                response.Data = await _customerDomain.DeleteAsync(customerId);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Eliminación exitosa";
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                response.Message = e.Message;
            }

            return response;
        }

        public async Task<Response<CustomerDto>> GetAsync(string customerId)
        {
            Response<CustomerDto> response = new Response<CustomerDto>();

            try
            {
                Customer customer = await _customerDomain.GetAsync(customerId);

                response.Data = _mapper.Map<CustomerDto>(customer);

                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta exitosa";
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                response.Message = e.Message;
            }

            return response;
        }

        public async Task<Response<IEnumerable<CustomerDto>>> GetAllAsync()
        {
            Response<IEnumerable<CustomerDto>> response = new Response<IEnumerable<CustomerDto>>();

            try
            {
                IEnumerable<Customer> customers = await _customerDomain.GetAllAsync();

                response.Data = _mapper.Map<IEnumerable<CustomerDto>>(customers);

                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta exitosa";
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                response.Message = e.Message;
            }

            return response;
        }
        #endregion
    }
}
