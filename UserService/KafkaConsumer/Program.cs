
using KafkaConsumer;

KafkaService kafkaService = new KafkaService();
SmsService smsService = new SmsService();
UserCreated user= await kafkaService.Subcribe();
await smsService.TwilioInit();
var message = $"Sayın {user.FirstName} {user.LastName} hesabınız başarılı bir şekilde oluşturuldu.Aramıza Hoş geldiniz";
await smsService.SendSms($"+90{user.PhoneNumber}",message);