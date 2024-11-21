using Confluent.Kafka;
using Confluent.Kafka.Admin;
using UserServiceMVC.Message;

namespace UserServiceMVC.Service;

public class KafkaService : IKafkaService
{
    public async Task CreateTopicAsync(string topic)
    {
        using var admin =new AdminClientBuilder(new AdminClientConfig()
        {
            BootstrapServers="localhost:9092"
        }).Build();

      await  admin.CreateTopicsAsync(new[]
        {
            new TopicSpecification()
            {
                Name = topic,NumPartitions = 3,ReplicationFactor = 1
            }
        });
    }

    public async Task SendCreatedMessage(string topic, UserCreated userCreated)
    {
        var config = new ProducerConfig() { BootstrapServers = "localhost:9092" };
        using var producer = new ProducerBuilder<Null, UserCreated>(config)
            .SetValueSerializer(new ValueSerializer<UserCreated>()).Build();

        var message = new Message<Null, UserCreated>()
        {
            Value = userCreated
        };
        producer.ProduceAsync(topic,message);
    }
}
