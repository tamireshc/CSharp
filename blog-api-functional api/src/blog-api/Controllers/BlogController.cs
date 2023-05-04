namespace blog_api.Controllers;

using Microsoft.AspNetCore.Mvc;
using blog_api.Models;

[ApiController]
[Route("api")]
public class BlogController : Controller
{
    private readonly BlogRepository _repository;
    public BlogController(BlogRepository repository)
    {
        _repository = repository;
    }

    [HttpPost("Post")]
    public void CreatePost(Post post)
    {
        _repository.Add(post);
    }

    [HttpDelete("Post/{id}")]
    public void DeletePost(int id)
    {
        var post = _repository.Get<Post>(id);
        _repository.Delete<Post>(post);
    }

    [HttpGet("Post/{id}")]
    public Post? GetPost(int id)
    {
        return _repository.Get<Post>(id);
    }

    [HttpPut("Post")]
    public void UpdatePost(Post post)
    {
        _repository.Update(post);
    }


}