using System.Security.Claims;
using team_scriptslingers_backend.Models;
using team_scriptslingers_backend.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace team_scriptslingers_backend.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly ILogger<PostController> _logger;
        private readonly IPostRepository _postRepository;
        private readonly IAuthRepository _authService;

        public PostController(ILogger<PostController> logger, IPostRepository repository, IAuthRepository service)
        {
            _logger = logger;
            _postRepository = repository;
            _authService = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Post>> GetAllPosts()
        {
            return Ok(_postRepository.GetAllPosts());
        }

        [HttpGet]
        [Route("{postId:int}")]
        public ActionResult<Post> GetPostById(int postId)
        {
            var post = _postRepository.GetPostById(postId);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<Post> CreatePost(Post newPost)
        {
            if (!ModelState.IsValid || newPost == null)
            {
                return BadRequest();
            }

            var UserName = HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;

            if (UserName == null)
            {
                return Unauthorized();
            }

            var createdPost = new Post
            {
                postContent = newPost.postContent,
                hostName = UserName,
                postedAt = DateTime.Now
            };

            var newCreatedTweet = _postRepository.CreatePost(createdPost);

            return Created(nameof(GetPostById), newCreatedTweet);
        }

        [HttpPut]
        [Route("{postId:int}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<Post> EditPost(int postId, Post post)
        {
            var existingPost = _postRepository.GetPostById(postId);

            if (existingPost == null)
            {
                return NotFound();
            }

            if (post == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid || post == null)
            {
                return BadRequest();
            }

            var UserName = HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;

            if (UserName == null)
            {
                return Unauthorized();
            }

            existingPost.postContent = post.postContent;
            existingPost.hostName = UserName;
            existingPost.postedAt = DateTime.Now;

            return Ok(_postRepository.EditPost(existingPost)
            );
        }

        [HttpDelete]
        [Route("{postId:int}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult DeletePost(int postId)
        {
            var existingPost = _postRepository.GetPostById(postId);
            if (existingPost == null){
                return NotFound();
            }
            var userName = HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;

            if (existingPost.hostName != userName){
                return Unauthorized();
            }      

            _postRepository.DeletePost(postId);
            return NoContent();
        }
    }
}