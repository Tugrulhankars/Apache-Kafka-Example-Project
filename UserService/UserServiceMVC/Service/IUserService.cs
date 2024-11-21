using UserServiceMVC.Models;

namespace UserServiceMVC.Service;

public interface IUserService
{
    public Task UserCreate(User user);
}
