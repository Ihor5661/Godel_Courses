namespace TestProj_18_05.Service
{
    public class InvalidPriceFormat : InvalidInputFormat
    {
        private string message;

        public InvalidPriceFormat()
        {
            message = "Invalid price format!!!";
        }

        public override string Message
        {
            get { return message; }
        }
    }
}
