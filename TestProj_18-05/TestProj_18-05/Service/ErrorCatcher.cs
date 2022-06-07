using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProj_18_05.UserInterface;

namespace TestProj_18_05.Service
{
    enum ErrorList
    {
        System,
        DataBase,
        SignInLogin,
        SignInPassword,
        SignUpLogin,
        SignUpPassword
    }

    internal class ErrorCatcher : IErrorCatcher
    {
        public void Error(string message)
        {
            IShowInfo outInfo = new OutConsoleInterface();
            outInfo.ShowError(message);
        }

        public void Error(int NumberError)
        {
            string message;

            switch (NumberError)
            {
                case (int)ErrorList.System:
                    {
                        message = "System Error";
                        break;
                    }
                case (int)ErrorList.DataBase:
                    {
                        message = "Database not connected or not found";
                        break;
                    }
                case (int)ErrorList.SignInLogin:
                    {
                        message = "Login entered incorrectly";
                        break;
                    }
                case (int)ErrorList.SignInPassword:
                    {
                        message = "Password entered incorrectly";
                        break;
                    }
                case (int)ErrorList.SignUpLogin:
                    {
                        message = "The login you entered is already registered, try to sign in";
                        break;
                    }
                case (int)ErrorList.SignUpPassword:
                    {
                        message = "Passwords don't match";
                        break;
                    }
                default:
                    {
                        message = "Unknown Error";
                        break;
                    }
            }
            Error(message);
        }
    }
}
