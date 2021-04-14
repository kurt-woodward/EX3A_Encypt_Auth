using System;

namespace EX3A_Encypt_Auth
{
    class Program
    {
        static void Main(string[] args)
        {
            Input.Menu();
        }

        public static void Terminate()
        {
            Console.WriteLine("Application terminated");
            Environment.Exit(0);
        }
    }
}
