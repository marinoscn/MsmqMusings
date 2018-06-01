using System;
using System.Messaging;

namespace MsmqServer
{
    class Program
    {
        static MessageQueue _messageQueue;
        private static int _counter;

        static void Main()
        {
            Console.WriteLine($"Enter some messages, type 'q' to quit{Environment.NewLine}");
            var exit = false;
            while (!exit)
            {

                var message = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(message))
                {
                    if (message.Trim().ToLower() == "q")
                        exit = true;
                    else
                    {
                        // put message on message q
                        if (!MessageQueue.Exists(GlobalVars.GlobalVars.MessageQueue))
                        {
                            CreateMessageQueue();
                        }

                        SendMessage(message);
                    }
                }
            }
        }

        private static void SendMessage(string message)
        {
            _messageQueue = new MessageQueue(GlobalVars.GlobalVars.MessageQueue);
            _messageQueue.Label = "Server Queue";
            _messageQueue.Send(message, "Message #: " + (++_counter).ToString() );
        }

        private static void CreateMessageQueue()
        {
            // Create the Queue
            MessageQueue.Create(GlobalVars.GlobalVars.MessageQueue);

        }
    }
}
