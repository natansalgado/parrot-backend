using Microsoft.AspNetCore.Mvc;
using Parrot.Model;
using Parrot.Repositories.Interfaces;

namespace Parrot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _postRepository;

        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<PostModel>>> GetAllPosts()
        {
            List<PostModel> posts = await _postRepository.GetAllPosts();
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PostModel>> GetPostById(int id)
        {
            PostModel post = await _postRepository.GetPostById(id);
            return Ok(post);
        }

        [HttpPost]
        public async Task<ActionResult<PostModel>> CreatePost([FromBody] PostModel postModel)
        {
            PostModel post = await _postRepository.CreatePost(postModel);
            return Ok(post);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePost(int id)
        {
            bool postDeleted = await _postRepository.DeletePost(id);
            return Ok(postDeleted);
        }
    }
}
