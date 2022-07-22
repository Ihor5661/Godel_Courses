namespace TestProj_18_05.Service
{
    public class InvalidTimeFormatException : InvalidInputFormatException
    {
        public InvalidTimeFormatException() : base("Invalid time format!!!")
        {
            
        }

    }
}
