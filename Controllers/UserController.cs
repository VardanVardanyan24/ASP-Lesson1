using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using Lesson1;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Linq;

namespace Lesson1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private static List<User> users = new List<User>
        {
            new User { Id = 1, Email = "john.doe@example.com", First_Name = "John", Last_Name = "Doe", Avatar = "john_avatar.png" },
            new User { Id = 2, Email = "jane.smith@example.com", First_Name = "Jane", Last_Name = "Smith", Avatar = "jane_avatar.png" },
            new User { Id = 3, Email = "alice.johnson@example.com", First_Name = "Alice", Last_Name = "Johnson", Avatar = "alice_avatar.png" }
        };

        [HttpGet("{id}")]
        public ActionResult<User> GetUserById(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public ActionResult<User> CreateUser(User user)
        {
            users.Add(user);
            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateUser(int id, User updatedUser)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null) return NotFound();

            user.Email = updatedUser.Email;
            user.First_Name = updatedUser.First_Name;
            user.Last_Name = updatedUser.Last_Name;
            user.Avatar = updatedUser.Avatar;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null) return NoContent();

            users.Remove(user);
            return NoContent();
        }
    }
}

