using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Messaging;
using GlobalVars;


//    MessageQueue messageQueue = null;
//    if (MessageQueue.Exists(@".\Private$\SomeTestName"))
//{
//messageQueue = new MessageQueue(@".\Private$\SomeTestName");
//messageQueue.Label = "Testing Queue";
//}
//else
//{
//// Create the Queue
//MessageQueue.Create(@".\Private$\SomeTestName");
//messageQueue = new MessageQueue(@".\Private$\SomeTestName");
//messageQueue.Label = "Newly Created Queue";
//}
//messageQueue.Send("First ever Message is sent to MSMQ", "Title");


namespace MsmqServer
{
    class Program
    {
        static MessageQueue _messageQueue = null;

        static void Main(string[] args)
        {
            
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
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }

        private static void SendMessage(string message)
        {
            _messageQueue = new MessageQueue(GlobalVars.GlobalVars.MessageQueue);
            _messageQueue.Label = "Testing Queue";
            _messageQueue.Send();
        }

        private static void CreateMessageQueue()
        {
            // Create the Queue
            MessageQueue.Create(@".\Private$\SomeTestName");

        }
    }
}
