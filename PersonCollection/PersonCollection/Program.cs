using System;
using System.Collections.Generic;

namespace PersonCollection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> vs = new LinkedList<int>();

            for (int i = 0; i < 10; i++)
            {
                vs.AddLast(i + 1);
            }

            Console.WriteLine(vs.Find(1).Value);

            //foreach (var item in vs)
            //{
            //    Console.WriteLine(item);
            //}
        }
    }
}
