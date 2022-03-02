using CodeChallenge.Blogs.API.Rest.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CodeChallenge.Blogs.API.Rest.Controllers
{
    [Route("api/Posts")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _conf;

        public PostController(IHttpClientFactory httpClient, IConfiguration conf)
        {
            _httpClientFactory = httpClient; _conf = conf;
        }
        // GET: api/<PostController>
        [HttpGet("")]
        public async Task<IActionResult> GetPostsAsync()
        {
            var httpClient = _httpClientFactory.CreateClient("gnews");
            var httpResponseMessage = await httpClient.GetAsync($"api/v4/search?q=watches&token={_conf.GetSection("Gnews:Token").Value}");
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();
                var posts = await JsonSerializer.DeserializeAsync<Post>(contentStream);
                return Ok(posts);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
