namespace TestProj_18_05.Service
{
    internal interface IAuthenticator
    {
        User SignIn(string username, string password);
        User SignUp(string username, string password, string secondPassword);
    }
}
