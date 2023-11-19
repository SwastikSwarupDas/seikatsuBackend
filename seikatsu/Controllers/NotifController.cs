using Microsoft.AspNetCore.Mvc;
using seikatsu.Services;
using seikatsu.Models;


namespace seikatsu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotifController : ControllerBase
    {
        private readonly INotifService notifService;

        public NotifController(INotifService notifService)
        {
            this.notifService = notifService;
        }

        [HttpGet]
        public ActionResult<List<Notif>> Get()
        {
            return notifService.Get();
        }


        [HttpGet("{receiver}")]
        public ActionResult<Notif> Get(string receiver)
        {
            var notif = notifService.Get(receiver);

            if (notif == null)
            {
                return NotFound($"Bad Notification 404");
            }
            return notif;
        }

        // POST api/<StudentsController>
        [HttpPost]
        public ActionResult<Notif> Post([FromBody] Notif notif)
        {
 
                notifService.Create(notif);

                return CreatedAtAction(nameof(Get), new { id = notif.Id }, notif);
    
        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public ActionResult<Notif> Put(string id, [FromBody] Notif notif)
        {
            var existingNotif = notifService.Get(id);

            if (existingNotif == null)
            {
                return NotFound($"Notif with id = {id} not found");
            }

            notifService.Update(id, notif);

            return NoContent();
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public ActionResult<Notif> Delete(string id)
        {
            var notif = notifService.Get(id);

            if (notif == null)
            {
                return NotFound($"Property with Id = {id} not found");
            }

            notifService.Remove(notif.Id);

            return Ok($"Property with Id = {id} successfully removed");
        }

    }
}
