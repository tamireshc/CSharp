
using auth_api.Models;

namespace auth_api.Repository
{
  public interface IUserRepository
  {
    public User GetUser(int id);

    public IEnumerable<User> GetUsers();

    public User AddUser(User user);

    public User UpdateUser(User user);

    public User DeleteUser(int id);

  }
}