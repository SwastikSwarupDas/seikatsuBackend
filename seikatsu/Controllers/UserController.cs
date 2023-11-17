using Microsoft.AspNetCore.Mvc;
using seikatsu.Services;
using seikatsu.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace seikatsu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService userService;

        public UsersController(IUsersService userService)
        {
            this.userService = userService;
        }
        // GET: api/<StudentsController>
        [HttpGet]
        public ActionResult<List<Users>> Get()
        {
            return userService.Get();
        }

        // GET api/<StudentsController>/5
        [HttpGet("{username}")]
        public ActionResult<Users> Get(string username)
        {
            var user = userService.Get(username);

            if (user == null)
            {
                return NotFound($"User with Username = {username} not found");
            }
            return user;
        }

        // POST api/<StudentsController>
        [HttpPost]
        public ActionResult<Users> Post([FromBody] Users user)
        {

            if (!userService.CheckUserAlreadyPresent(user.Username,user.Email))
            {
                userService.Create(user);

                return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
            }

            return BadRequest();
        }

      
        // PUT api/<StudentsController>/5
        [HttpPut("{username}")]
        public ActionResult<Users> Put(string username, [FromBody] Users user)
        {
            var existingUser = userService.Get(username);

            if (existingUser == null)
            {
                return NotFound($"User with username = {username} not found");
            }

            userService.Update(username, user);

            return NoContent();
        }

        [HttpPatch("addproperty")]
        public ActionResult<Users> Patch(string username, [FromBody] Users user)
        {
            var existingUser = userService.Get(username);

            if(existingUser == null)
            {
                return NotFound($"User with username = {username} not found");
            }

            existingUser.PropertyIds = existingUser.PropertyIds.Concat(user.PropertyIds).ToArray();
            userService.Update(existingUser.Username, existingUser);

            return Ok(new { Message = "User updated successfully!" });
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public ActionResult<Users> Delete(string id)
        {
            var user = userService.Get(id);

            if (user == null)
            {
                return NotFound($"User with Id = {id} not found");
            }

            userService.Remove(user.Id);

            return Ok($"User with Id = {id} successfully removed");
        }
    
    }

    
}