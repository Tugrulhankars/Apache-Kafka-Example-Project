using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace KafkaConsumer;

public class SmsService
{
    public async Task TwilioInit()
    {
        string accountSid = "****************";//oluşturduğunuz hesabın account id'nizi yazınız
        string authToken = "********************";//oluşturduğunuz hesaba ait authTone'ı yazınız
        TwilioClient.Init(accountSid,authToken);
    }
    public async Task SendSms(string to,string messageBody)
    {
        var message = await MessageResource
            .CreateAsync(
              body:messageBody,
              from: new Twilio.Types.PhoneNumber("*****************"),//Twilio'da oluşturduğunuz hesabın telefon numarasını yazınız
              to:new Twilio.Types.PhoneNumber(to)
            );


    }
}
