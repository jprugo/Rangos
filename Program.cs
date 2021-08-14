using System;
using System.Collections.Generic;

namespace Rangos
{
    public static class Program
    {

        private static void Main(string[] args)
        {
            Service service = new Service();

            service.PrintLines();

            Console.WriteLine("Nuevas lineas:");

            var newList = service.MergeLines();

            newList.ForEach(e => Console.WriteLine(e.ToString()));
        }
    }
}
