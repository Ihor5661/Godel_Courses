namespace TestProj_18_05.Service
{
    public class InvalidDateTimeFormatException : InvalidInputFormatException
    {
        public InvalidDateTimeFormatException() : base("Invalid data-time format!!!")
        {
            
        }
    }
}
