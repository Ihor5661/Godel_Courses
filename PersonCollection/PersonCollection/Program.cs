using System;
using System.Collections.Generic;

namespace PersonCollection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyList<int> vs = new MyList<int>();

            Console.WriteLine(vs[0] = 10);
            Console.WriteLine("Hello World!");

            int[] a = new int[3];

            for (int i = 0; i < a.Length; i++)
            {
                a[i] = i + 1;
            }

           // Console.WriteLine("Hello World!");

            int[] b = new int[4];
            a.CopyTo(b, 0);
            b[3] = 9999;
            for (int i = 0; i < b.Length; i++)
            {
                Console.WriteLine(b[i]);
            }
        }
    }
}
