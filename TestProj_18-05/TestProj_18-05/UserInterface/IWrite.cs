namespace TestProj_18_05.UserInterface
{
    internal interface IWrite
    {
        void HeaderInfo(string message);
        void Info(string message);
        void Error(string message);
        void ClearDisplay();
        void SkipLines(int qtyLine);
        void FooterInfo(string message);
    }
}
