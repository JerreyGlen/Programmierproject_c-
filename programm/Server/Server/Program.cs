using System;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            //create a server and start it
            ServerNetworking.Server s = new ServerNetworking.Server(4444);
            s.start();

            Console.WriteLine("Press ENTER to stop the Server...");
            
            //stop the server when ENTER-Key is pressed
            ConsoleKeyInfo cki;
            while (true)
            {
                cki = Console.ReadKey();
                if (cki.Key == ConsoleKey.Enter) break;
            }
            s.stop();
        }
    }
}
