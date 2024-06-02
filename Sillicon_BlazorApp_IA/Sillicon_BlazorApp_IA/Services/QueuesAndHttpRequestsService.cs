using Azure.Messaging.ServiceBus;
using Infrastructure.Models.Account;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Sillicon_BlazorApp_IA.Services
{
    public class QueuesAndHttpRequestsService
    {
        public async Task<bool> SendToVeificationlQueue(VerifyEmailModel email, string key, string queue)
        {
            try
            {
                await using var client = new ServiceBusClient(key);
                ServiceBusSender sender = client.CreateSender(queue);
                var json = JsonConvert.SerializeObject(email);
                ServiceBusMessage message = new ServiceBusMessage(json) { ContentType = "application/json" };
                await sender.SendMessageAsync(message);

                return true;
            }
            catch (Exception e) { Debug.WriteLine($"Error serverbusque ::: {e.Message}"); }
            return false;
        }

        public async Task<bool> SendToEmailQueue(SubscribeConfirmModel email, string key, string queue)
        {
            try
            {
                await using var client = new ServiceBusClient(key);
                ServiceBusSender sender = client.CreateSender(queue);
                var json = JsonConvert.SerializeObject(email);
                ServiceBusMessage message = new ServiceBusMessage(json) { ContentType = "application/json" };
                await sender.SendMessageAsync(message);

                return true;
            }
            catch (Exception e) { Debug.WriteLine($"Error serverbusque ::: {e.Message}"); }
            return false;
        }

        public string HtmlBody(string title, string name, string text)
        {
            string bodyAndMessage = $@"<html lang='en'>
                              <head>
                                <meta charset='UTF-8' />
                                <meta name='viewport' content='width=device-width, initial-scale=1.0' />
                                <title>{title}</title>
                              </head>
                              <body>
                                <div style='border-radius:15px; padding:20px; background-color:#9495FF; margin-bottom:20px; box-shadow: 2px 2px 10px 2px #807b7b; max-width:750px;'>
                                <div style='font-size: 30px; font-weight: 600; color:#000000;'>{title}<hr></div>
                                <div style='font-size: 15px; font-weight: 400; color:#000000;'>
                                   Hi {name},<br>
                           {text},<br>
                                   Sillicon-crew!
                                   </div>
                                </div>
                               </body>
                              </html>";

            return bodyAndMessage;
        }
    }
}
