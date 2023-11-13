using Microsoft.AspNetCore.Mvc;
using seikatsu.Services;
using seikatsu.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace seikatsu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        private readonly IPropertiesService propertiesService;

        public PropertiesController(IPropertiesService propertiesService)
        {
            this.propertiesService = propertiesService;
        }
        // GET: api/<StudentsController>
        [HttpGet]
        public ActionResult<List<Properties>> Get()
        {
            return propertiesService.Get();
        }

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public ActionResult<Properties> Get(string id)
        {
            var property = propertiesService.Get(id);

            if (property == null)
            {
                return NotFound($"Property with Id = {id} not found");
            }
            return property;
        }

        // POST api/<StudentsController>
        [HttpPost]
        public ActionResult<Properties> Post([FromBody] Properties property)
        {

            propertiesService.Create(property);

            return CreatedAtAction(nameof(Get), new { id = property.Id }, property);
        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public ActionResult<Properties> Put(string id, [FromBody] Properties property)
        {
            var existingProperty = propertiesService.Get(id);

            if (existingProperty == null)
            {
                return NotFound($"User with id = {id} not found");
            }

            propertiesService.Update(id, property);

            return NoContent();
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public ActionResult<Properties> Delete(string id)
        {
            var property = propertiesService.Get(id);

            if (property == null)
            {
                return NotFound($"Property with Id = {id} not found");
            }

            propertiesService.Remove(property.Id);

            return Ok($"Property with Id = {id} successfully removed");
        }
    }
}