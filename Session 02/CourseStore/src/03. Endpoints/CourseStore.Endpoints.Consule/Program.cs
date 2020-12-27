using CourseStore.Infra.Dal;
using System;

namespace CourseStore.Endpoints.Consule
{
    class Program
    {
        static void Main(string[] args)
        {
            //DataClass.SeedData();
            Console.WriteLine("[+] Eager Loading:\n");
            DataClass.LoadEager01();
            Console.WriteLine("[+] Explicit Loading:\n");
            DataClass.LoadExplicti01();
            Console.WriteLine("[+] Select Loading:\n");
            DataClass.LoadSelection();
            Console.WriteLine("Finished!");
        }
    }
}
