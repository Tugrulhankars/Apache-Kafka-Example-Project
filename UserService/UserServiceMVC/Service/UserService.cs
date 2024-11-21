using UserServiceMVC.Message;
using UserServiceMVC.Models;

namespace UserServiceMVC.Service;

public class UserService : IUserService
{
    private readonly IKafkaService _kafkaService;
    public UserService(IKafkaService kafkaService)
    {
        _kafkaService = kafkaService;
    }
    public async Task UserCreate(User user)
    {
        string topic = "user-created";
        UserCreated userCreated = new()
        {
            PhoneNumber = user.PhoneNumber,
            FirstName = user.FirstName,
            LastName = user.LastName,
        };
       // _kafkaService.CreateTopicAsync(topic);
      await _kafkaService.SendCreatedMessage(topic,userCreated);
    }
}
