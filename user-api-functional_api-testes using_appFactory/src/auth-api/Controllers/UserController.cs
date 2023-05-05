using Microsoft.AspNetCore.Mvc;
using auth_api.Models;
using auth_api.Store;
using auth_api.Repository;

namespace auth_api.Controllers
{
  [ApiController]
  [Route("user")]
  public class UserController : ControllerBase
  {
    private readonly UserRepository _repository;
    public UserController(UserRepository repository)
    {
      _repository = repository;
    }

    /// <summary> This function return all users</summary>
    /// <returns> A list of user</returns>
    [HttpGet(Name = "GetUsers")]
    public IActionResult Get()
    {
      var users = _repository.GetUsers();
      return Ok(users);
    }

    /// <summary> This function create a user</summary>
    /// <param name="user"> The user values</param>
    /// <returns> A user</returns>
    [HttpPost]
    public IActionResult CreateUser(User user)
    {
      if (user.Email != null && user.FullName != null && user.Password != null)
      {
        _repository.AddUser(user);
        return Ok();
      }
      return BadRequest();
    }
  }
}
