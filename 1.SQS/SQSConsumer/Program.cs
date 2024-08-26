using SQSConsumer;
using System.Collections;


bool result = await Queueu.Pull();

if (result)
{
    Console.WriteLine("Mesajlar Çekildi.");
}
else
{
    Console.WriteLine("Mesaj Çekimi Başarısız");
}
Console.ReadLine();