namespace TestProj_18_05.Service
{
    public class InvalidTimeFormat : InvalidInputFormat
    {
        private string message;

        public InvalidTimeFormat()
        {
            message = "Invalid time format!!!";
        }

        public override string Message
        {
            get { return message; }
        }
    }
}
