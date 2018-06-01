using System;
using System.Messaging;

namespace MsmqClient
{
    class Program
    {
        static MessageQueue _messageQueue;

        static void Main(string[] args)
        {
            _messageQueue = new MessageQueue(GlobalVars.GlobalVars.MessageQueue);
            _messageQueue.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });
            var messages = _messageQueue.GetAllMessages();

            foreach (System.Messaging.Message message in messages)
            {
                try
                {
                    var text = (string)message.Body;
                    Console.WriteLine(text);
                }
                catch (MessageQueueException ex)
                {
                    Console.WriteLine($"Message Queue Exception: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"General Exception: {ex.Message}");
                }
            }
            _messageQueue.Purge();

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();

        }
    }
}
