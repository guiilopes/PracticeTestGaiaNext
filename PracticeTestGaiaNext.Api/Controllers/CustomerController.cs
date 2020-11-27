using Microsoft.AspNetCore.Mvc;
using PracticeTestGaiaNext.Api.Data;
using PracticeTestGaiaNext.Api.Enums;
using PracticeTestGaiaNext.Api.Model;
using System.Collections.Generic;
using System.Linq;

namespace PracticeTestGaiaNext.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public CustomerController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> GetCustomers()
        {
            return _dataContext.Customers.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Customer> Get(int id)
        {
            return _dataContext.Customers.FirstOrDefault(x => x.Id == id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
