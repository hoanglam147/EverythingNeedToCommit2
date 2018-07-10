using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;
namespace ConsoleApp1
{
    class Program
    {

        // Declare the SetConsoleCtrlHandler function
        // as external and receiving a delegate.
        private static bool isclosing = false;
        private static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            isclosing = true;
            Console.WriteLine("CTRL+C received!");
        }

        static void Main(string[] args)
        {
            Console.CancelKeyPress += Console_CancelKeyPress;

            Console.WriteLine("CTRL+C,CTRL+BREAK or suppress the application to exit");
            while (!isclosing) ;
            Console.WriteLine("CTRL+C,CTRL+BREAK or suppress the application to exit");
            Console.ReadLine();

        }
    }
}
