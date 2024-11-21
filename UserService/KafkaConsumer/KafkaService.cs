using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafkaConsumer;

public class KafkaService
{

    public async Task<UserCreated> Subcribe()
    {
        var config = new ConsumerConfig()
        {
            BootstrapServers="localhost:9092",
            GroupId="group one",
            AutoOffsetReset=AutoOffsetReset.Earliest
        };

        var consumer = new ConsumerBuilder<Null, UserCreated>(config)
            .SetValueDeserializer(new ValueDeserializer<UserCreated>()).Build();
        consumer.Subscribe("user-created");
        var result = consumer.Consume();
        var userCreated = result.Message.Value;
        Console.WriteLine($"First Name={userCreated.FirstName},Last Name={userCreated.LastName},Email Address={userCreated.PhoneNumber}");

        return userCreated;
    }
}
