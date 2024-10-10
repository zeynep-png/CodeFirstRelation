using CodeFirstRelation.Context;
using CodeFirstRelation.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace CodeFirstRelation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly PatikaSecondDbContext _context;

        public PostsController(PatikaSecondDbContext context)
        {
            _context = context;
        }

        // GET: api/Posts
        [HttpGet]
        public IActionResult GetPosts()
        {
            var posts = _context.Posts.Include(p => p.User).ToList();
            return Ok(posts);
        }

        // GET: api/Posts/5
        [HttpGet("{id}")]
        public IActionResult GetPost(int id)
        {
            var post = _context.Posts.Include(p => p.User).FirstOrDefault(p => p.Id == id);

            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }

        // POST: api/Posts
        [HttpPost]
        public IActionResult CreatePost([FromBody] PostEntity newPost)
        {
            if (newPost == null)
            {
                return BadRequest();
            }

            // Foreign key olarak kullanıcının var olup olmadığını kontrol edelim
            var user = _context.Users.FirstOrDefault(u => u.Id == newPost.UserId);
            if (user == null)
            {
                return BadRequest("User not found");
            }

            _context.Posts.Add(newPost);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetPost), new { id = newPost.Id }, newPost);
        }

        // PUT: api/Posts/5
        [HttpPut("{id}")]
        public IActionResult UpdatePost(int id, [FromBody] PostEntity updatedPost)
        {
            var post = _context.Posts.Find(id);
            if (post == null)
            {
                return NotFound();
            }

            // Gönderi verilerini güncelle
            post.Title = updatedPost.Title;
            post.Content = updatedPost.Content;
            post.UserId = updatedPost.UserId;

            _context.Posts.Update(post);
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Posts/5
        [HttpDelete("{id}")]
        public IActionResult DeletePost(int id)
        {
            var post = _context.Posts.Find(id);
            if (post == null)
            {
                return NotFound();
            }

            _context.Posts.Remove(post);
            _context.SaveChanges();

            return NoContent();
        }
    }
}

