namespace TestProj_18_05.Service
{
    public class InvalidPriceFormatException : InvalidInputFormatException
    {
        public InvalidPriceFormatException() : base("Invalid price format!!!")
        {
            
        }
    }
}
