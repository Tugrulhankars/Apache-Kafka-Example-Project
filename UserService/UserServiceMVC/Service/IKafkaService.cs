using UserServiceMVC.Message;

namespace UserServiceMVC.Service;

public interface IKafkaService
{
    public Task CreateTopicAsync(string topic);
    public Task SendCreatedMessage(string topic, UserCreated userCreated);
}
