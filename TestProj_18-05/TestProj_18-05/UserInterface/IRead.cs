using System;

namespace TestProj_18_05.UserInterface
{
    internal interface IRead
    {
        string GetInfo(string message);
        DateTime GetDateTime(string message);
        TimeSpan GetTime(string message);
        decimal GetCount(string message);

    }
}
