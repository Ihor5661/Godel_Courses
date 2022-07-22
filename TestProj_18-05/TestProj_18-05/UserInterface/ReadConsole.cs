using System;
using TestProj_18_05.Service;

namespace TestProj_18_05.UserInterface
{
    internal class ReadConsole : IRead
    {
        private IWrite write;

        public ReadConsole(IWrite write)
        {
            this.write = write;
        }

        public string GetInfo(string message)
        {
            write.Info(message);

            string info = Console.ReadLine();

            return info;
        }

        public DateTime GetDateTime(string message)
        {
            DateTime date;
            string input;

            input = GetInfo(message);

            if (!DateTime.TryParse(input, out date))
            {
                throw new InvalidDateTimeFormatException();
            }

            return date;
        }

        public TimeSpan GetTime(string message)
        {
            TimeSpan timeSpan;
            string input;

            input = GetInfo(message);

            if (!TimeSpan.TryParse(input, out timeSpan))
            {
                throw new InvalidTimeFormatException();
            }

            return timeSpan;
        }

        public decimal GetCount(string message)
        {
            decimal price;
            string input;
            input = GetInfo(message);

            if (!decimal.TryParse(input, out price))
            {
                throw new InvalidPriceFormatException();
            }

            return price;
        }
    }
}
