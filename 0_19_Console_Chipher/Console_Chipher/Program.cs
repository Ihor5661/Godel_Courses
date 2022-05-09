using System;

namespace Console_Chipher
{
    internal class Program
    {
        static string Cipher(string text)
        {
            int codeCh = text.Length;
            string result = "";

            for (int i = 0; i < text.Length; i++)
            {
                result += (char)(text[i] ^ codeCh);
            }

            return result;
        }

        static void Main(string[] args)
        {
            int requestData = 0;
            bool mainLoop = true;
            string data;

            while (mainLoop)
            {
                Console.Clear();
                Console.WriteLine("1) Enter text;\n2) Enter cipher;\n3) Exit;");
                requestData = Convert.ToInt32(Console.ReadLine());

                if (requestData != 3)
                {
                    Console.WriteLine("Enter: ");
                    data = Console.ReadLine();
                    Console.WriteLine(Cipher(data));
                }
                else
                {
                    mainLoop = false;
                }
                data = Console.ReadLine();
            }
        }
    }
}
