using System;

namespace OOPEngine
{
    class Log
    {
        public static void Info(object sender, object message)
        {
            Console.WriteLine($"[{sender.GetType().Name}]: {message}");
        }
    }
}
