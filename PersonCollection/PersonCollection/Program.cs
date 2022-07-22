using System;
using System.Collections.Generic;

namespace PersonCollection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            MyStack<int> vs = new MyStack<int>();


            for (int i = 0; i < 11; i++)
            {
                vs.Push(i + 1);
            }



            foreach (var item in vs)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            //foreach (var item in vs)
            //{
            //    Console.WriteLine(item);
            //}
        }
    }
}
