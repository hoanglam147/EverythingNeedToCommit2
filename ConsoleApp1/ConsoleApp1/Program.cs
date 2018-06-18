using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Net;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            //Byte[] filebin;
            //filebin = File.ReadAllBytes("D:\\WORK\\M300Job\\m220Job\\2.dlcfg");
            //byte[] asciiArray = Encoding.Convert(Encoding.UTF8, Encoding.ASCII, filebin);
            //string finalString = Encoding.ASCII.GetString(asciiArray);
            //StreamWriter sw = new StreamWriter("test.txt");
            //sw.Write(finalString);
            ////for (int i = 0;i<filebin.Length;i++)
            ////{
            ////    sw.WriteLine(filebin[i]);
            ////}
            //sw.Close();
            if (args == null)
            {
                Console.WriteLine("args is null"); // Check for null array
                Console.WriteLine("Press any key to exit ...");
                Console.ReadKey();
                Environment.Exit(0)
            }
            else
            {
                for (int i = 0;i<args.Length;i++)
                {
                    Console.WriteLine(args[i]);
                }
                
            }
        }
    }
}
