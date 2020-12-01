using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticeTestGaiaNext.Api.Dtos;
using PracticeTestGaiaNext.Domain.Entities;
using PracticeTestGaiaNext.Domain.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PracticeTestGaiaNext.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _repository;
        private readonly IMapper _iMapper;

        public CustomerController(ICustomerRepository repository, IMapper iMapper)
        {
            _repository = repository;
            _iMapper = iMapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            try
            {
                var customers = await _repository.GetCustomersAsync();

                var results = _iMapper.Map<IEnumerable<CustomerDto>>(customers);

                return Ok(results);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Não foi possível exibir os clientes! Ex: {ex.Message}" );
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var customer = await _repository.GetCustomersAsyncById(id);

                var results = _iMapper.Map<CustomerDto>(customer);

                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Não foi possível exibir o cliente código {id}!");
            }

        }

        [HttpPost]
        public async Task<IActionResult> Post(CustomerDto customerDto)
        {
            try
            {
                var customer = _iMapper.Map<Customer>(customerDto);

                _repository.Add(customer);

                if (await _repository.SaveChangesAsync())
                    return Created($"/api/customer/{customer.Id}", _iMapper.Map<CustomerDto>(customer));
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Não foi possível inserir o cliente código {customerDto.Id}!");
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, CustomerDto customerDto)
        {
            try
            {
                var customer = await _repository.GetCustomersAsyncById(id);

                if (customer == null) return NotFound();

                _iMapper.Map(customerDto, customer);

                _repository.Update(customer);

                if (await _repository.SaveChangesAsync())
                    return Created($"/api/customer/{customerDto.Id}", _iMapper.Map<CustomerDto>(customer));
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Não foi possível salvar o cliente código {customerDto.Id}! Ex:{ex.Message}");
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Customer customer = null;

            try
            {
                customer = await _repository.GetCustomersAsyncById(id);

                if (customer == null) return NotFound();

                _repository.Delete(customer);

                if (await _repository.SaveChangesAsync())
                    return Ok();
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Não foi possível eliminar o cliente código {customer.Id}!");
            }

            return BadRequest();
        }
    }
}
