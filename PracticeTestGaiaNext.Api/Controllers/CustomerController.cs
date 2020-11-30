using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticeTestGaiaNext.Domain.Entities;
using PracticeTestGaiaNext.Domain.Repositories;
using System.Threading.Tasks;

namespace PracticeTestGaiaNext.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _repository;

        public CustomerController(ICustomerRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            try
            {
                return Ok(await _repository.GetCustomersAsync());
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Não foi possível exibir os clientes!");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(await _repository.GetCustomersAsyncById(id));

            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Não foi possível exibir o cliente código {id}!");
            }

        }

        [HttpPost]
        public async Task<IActionResult> Post(Customer customer)
        {
            try
            {
                _repository.Add(customer);

                if (await _repository.SaveChangesAsync())
                    return Created($"/api/customer/{customer.Id}", customer);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Não foi possível inserir o cliente código {customer.Id}!");
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Customer customer)
        {
            try
            {
                var reponse = await _repository.GetCustomersAsyncById(id);

                if (reponse == null) return NotFound();

                _repository.Update(customer);

                if (await _repository.SaveChangesAsync())
                    return Created($"/api/customer/{customer.Id}", customer);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Não foi possível salvar o cliente código {customer.Id}!");
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, Customer customer)
        {
            try
            {
                var reponse = await _repository.GetCustomersAsyncById(id);

                if (reponse == null) return NotFound();

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
