using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using Lesson1;

namespace Lesson1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserRepository repoo;

        public UserController(UserRepository repo)
        {
            this.repoo = repo;
        }



        // GET: api/<BooksController>
        [HttpGet]
        public IEnumerable<User> Get([FromServices] UserRepository repoo2)
        {
            return new List<User>() { repoo.Get(1), repoo2.Get(2) };
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public User Get([FromServices] UserRepository repo, int id)
        {
            return repoo.Get(id);
        }

        // POST api/<BooksController>
        [HttpPost]
        public void Post()
        {
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public void Put()
        {
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public void Delete()
        {
        }
    }
}
