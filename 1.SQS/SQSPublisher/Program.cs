using Amazon.Runtime.Internal.Settings;
using Amazon.SQS;
using Amazon.SQS.Model;
using SQSPublisher;
using System.Text.Json;


bool result = await Queueu.SendQueueMessageAsync();
if (result)
{
    Console.WriteLine("Mesaj başarıyla kuyruğa eklendi.");
}
else
{
    Console.WriteLine("Mesaj kuyruğa eklenemedi.");
}

Console.WriteLine("İşlem tamamlandı, çıkmak için bir tuşa basın.");
Console.ReadKey();