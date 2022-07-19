using System;

namespace TestProj_18_05.UserInterface
{
    //enum SoftwareTypes // ToDo slove question about enum
    //{
    //    Software,
    //    FreeSoftware,
    //    SharewareSoftware,
    //    ProprietarySoftware
    //}

    internal class WriteConsole : IWrite
    {
        public void ClearDisplay()
        {
            Console.ResetColor();
            Console.Clear();
        }

        public void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public void FooterInfo(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (!string.IsNullOrEmpty(message))
            {
                Console.WriteLine(new string('=', 50));
                Console.WriteLine($"{message}");
            }
            Console.WriteLine(new string('=', 50));
            Console.ResetColor();
        }

        public void HeaderInfo(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(new string('=', 20) + $" {message} " + new string('=', 20));
            Console.ResetColor();
        }

        public void Info(string message)
        {
            Console.WriteLine(message);
        }

        public void SkipLines(int numLine)
        {
            if (!(numLine <= 0))
            {
                Console.Write(new string('\n', numLine));
            }
        }
    }
}
