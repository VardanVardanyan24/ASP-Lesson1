using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Lesson1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private static List<Post> posts = new List<Post>
        {
            new Post
            {
                UserId = 1,
                Id = 2,
                Title = "qui est esse",
                Body = "est rerum tempore vitae\nsequi sint nihil reprehenderit dolor beatae ea dolores neque\nfugiat blanditiis voluptate porro vel nihil molestiae ut reiciendis\nqui aperiam non debitis possimus qui neque nisi nulla"
            }
        };

        [HttpGet("byuser/{userId}/{title}")]
        public ActionResult<List<Post>> GetPostsByUserIdAndTitle(int userId, string title)
        {
            var userPosts = posts.Where(p => p.UserId == userId && p.Title.Contains(title)).ToList();
            if (userPosts.Count == 0) return NotFound();
            return Ok(userPosts);
        }

        [HttpGet("{id}")]
        public ActionResult<Post> GetPostById(int id)
        {
            var post = posts.FirstOrDefault(p => p.Id == id);
            if (post == null) return NotFound();
            return Ok(post);
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePost(int id)
        {
            var post = posts.FirstOrDefault(p => p.Id == id);
            if (post == null) return NotFound();

            posts.Remove(post);
            return NoContent();
        }
    }
}
