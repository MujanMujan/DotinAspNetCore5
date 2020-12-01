using Dotin.Session01.HelloEF.DataLayer;
using System;

namespace Dotin.Session01.HelloEF
{
    class Program
    {
        static void Main(string[] args)
        {
            DataClass.ReadAllData();
            Console.WriteLine("Hello World!");
        }
    }
}
