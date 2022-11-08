using CustomeExceptionHandler.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomeExceptionHandler.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public ActionResult<List<AppUser>> Get()
        {
            List<AppUser> users = new List<AppUser>();
            users.Add(new AppUser
            {
                Username = "test",
                FirstName = "Abc",
                LastName = "Xyz",
                Age = 30,
                Email = "test@test.com"
            });
            return users;
        }

        [HttpGet("{username}")]
        public ActionResult<AppUser> GetUserByName(string username)
        {
            List<AppUser> users = new List<AppUser>();
            var user = users.Where(x => x.Username == username).First();
            return NotFound();
        }

        // POST api/<UsersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
    }
}
