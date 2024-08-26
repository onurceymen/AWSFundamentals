using Amazon.SQS.Model;
using Amazon.SQS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQSConsumer
{
    public  class Queueu
    {
        public static async Task<bool> Pull()
        {
            var sqsClient = new AmazonSQSClient();

            var queueUrlResponse = await sqsClient.GetQueueUrlAsync("customers");

            var receiveMessageRequest = new ReceiveMessageRequest
            {
                QueueUrl = queueUrlResponse.QueueUrl,
                MaxNumberOfMessages = 10,  // Bir seferde alınacak maksimum mesaj sayısı
                WaitTimeSeconds = 20       // Long polling için bekleme süresi
            };

            var cts = new CancellationTokenSource();

            try
            {
                var response = await sqsClient.ReceiveMessageAsync(receiveMessageRequest);

                if (response.Messages.Any())
                {
                    foreach (var message in response.Messages)
                    {
                        Console.WriteLine($"Message Id:{message.MessageId}");
                        Console.WriteLine($"Message Body:{message.Body}");
                    }

                    await Task.Delay(21000, cts.Token);  // Sürekli çekim için bekleme süresi
                }
                else
                {
                    Console.WriteLine("Kuyrukta şu anda mesaj yok.");
                    await Task.Delay(5000, cts.Token);
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Bir hata oluştu: {ex.Message}");
                return false;
            }

            return true;
        }
    }
}
