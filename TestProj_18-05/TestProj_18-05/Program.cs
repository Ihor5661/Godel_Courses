using System;

namespace TestProj_18_05
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            while (!menu.ExistError)
            {
                menu.StartMenu();
            }
        }
    }
}
