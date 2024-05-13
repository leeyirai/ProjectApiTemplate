using BusinessLayer;
using BusinessLayer.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplicationApiTemplate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemplateController : ControllerBase
    {
        private readonly IAccountLogic _accountLogic;

        public TemplateController(IAccountLogic accountLogic)
        {
            _accountLogic = accountLogic;
        }

        // GET: api/<TemplateController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TemplateController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _accountLogic.Query(id));
        }

        // POST api/<TemplateController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AccountModel value)
        {
            return Ok(await _accountLogic.Insert(value));
        }

        // PUT api/<TemplateController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] AccountModel value)
        {
            return Ok(await _accountLogic.Update(value));
        }

        // DELETE api/<TemplateController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            return Ok(await _accountLogic.Delete(id));
        }
    }
}
