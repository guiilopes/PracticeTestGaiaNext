using Microsoft.AspNetCore.Mvc;
using PracticeTestGaiaNext.Api.Enums;
using PracticeTestGaiaNext.Api.Model;
using System.Collections.Generic;
using System.Linq;

namespace PracticeTestGaiaNext.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> Get()
        {
            return new Customer[] {
            new Customer(1, "GuiiLopes", CompanySize.Pequena),
            new Customer(2, "Teste", CompanySize.Grande)
            };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Customer> Get(int id)
        {
            return new Customer[] {
            new Customer(1, "GuiiLopes", CompanySize.Pequena),
            new Customer(2, "Teste", CompanySize.Grande)
            }.FirstOrDefault(x => x.Id == id);
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
