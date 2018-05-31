using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsmqServer
{
    class Program
    {
        static void Main(string[] args)
        {
            var exit = false;
            while (!exit)
            {
                var message = Console.ReadLine();
                if (message.Trim().ToLower() == "q")
                    exit = true;
                else
                {
                    // put message on message q
                }
            }
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
