using System;

namespace Console_Chipher
{
    internal class Program
    {
        static string GetCipher(string text)
        {
            int stepShear = text.Length;
            string result = "";

            for (int i = 0; i < text.Length; i++)
            {
                result += (char)(text[i] ^ stepShear);
            }

            return result;
        }

        static void Main(string[] args)
        {
            string input, result;
            int inputData;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("1) Enter text;\n2) Enter cipher;\n3) Exit;");
                input = Console.ReadLine();
                int.TryParse(input, out inputData);

                if (inputData == 3)
                {
                    break;
                }

                Console.WriteLine("Enter: ");
                input = Console.ReadLine();
                result = GetCipher(input);
                Console.WriteLine(result);

                Console.ReadKey();
            }
        }
    }
}
