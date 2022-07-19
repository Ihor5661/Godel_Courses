namespace TestProj_18_05.Service
{
    public class InvalidDateTimeFormat : InvalidInputFormat
    {
        private string message;

        public InvalidDateTimeFormat()
        {
            message = "Invalid data-time format!!!";
        }

        public override string Message
        {
            get { return message; }
        }
    }
}
