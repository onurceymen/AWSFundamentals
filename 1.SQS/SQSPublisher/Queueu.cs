using Amazon.SQS;
using Amazon.SQS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SQSPublisher
{
    public class Queueu
    {
        public static async Task<bool> SendQueueMessageAsync()
        {
            var region = Amazon.RegionEndpoint.EUNorth1;
            var sqsClient = new AmazonSQSClient(region);
            var customer = new User
            {
                Name = "Onur",
                LastName = "Eymen",
                Age = 0,
            };

            try
            {

                var queueUrlResponse = await sqsClient.GetQueueUrlAsync("customers");

                var sendMessageRequest = new SendMessageRequest
                {
                    QueueUrl = queueUrlResponse.QueueUrl,
                    MessageBody = JsonSerializer.Serialize(customer)
                };

                var response = await sqsClient.SendMessageAsync(sendMessageRequest);

                if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
                {
                    Console.WriteLine("Mesaj başarıyla gönderildi");
                    return true;
                }
                else
                {
                    Console.WriteLine("Başarısız işlem");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata oluştu: {ex.Message}");
                return false;
            }
        }
    }
}
