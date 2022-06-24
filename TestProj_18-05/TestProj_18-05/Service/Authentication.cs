using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProj_18_05.UserInterface;

namespace TestProj_18_05.Service
{
    internal class Authentication : IUserConnector
    {
        User user;
        bool existError = false;
        IGetInfo getInfo = new InConsoleInterface();

        public Authentication(User user)
        {
            this.user = user;
        }

        public User SignIn(string login, string password)
        {
            ExistError = false;
            IErrorCatcher errorCatcher = new ErrorCatcher();

            if (user == null)
            {
                errorCatcher.Error("This user is not logged in!!!");
                getInfo.GetInfo("");
                ExistError = true;
                return null;
            }
            else if (user.Password != password)
            {
                errorCatcher.Error("Password entered incorrectly!!!");
                getInfo.GetInfo("");
                ExistError = true;
                return null;
            }
            else
            {
                return user;
            }        
        }

        public User SignUp(string login, string password, string secondPassword)
        {
            const int minPassLength = 6;
            ExistError = false;

            IErrorCatcher errorCatcher = new ErrorCatcher();

            if (user != null)
            {
                errorCatcher.Error("This username is already registered in the database!!!");
                getInfo.GetInfo("");
                ExistError = true;
                return null;
            }
            else if (password != secondPassword)
            {
                errorCatcher.Error("Password 1 and password 2 do not match!!!");
                getInfo.GetInfo("");
                ExistError = true;
                return null;
            }
            else if (password.Length < minPassLength)
            {
                errorCatcher.Error("Password is too small!!!");
                getInfo.GetInfo("");
                ExistError = true;
                return null;
            }
            else
            {
                user = new User(login, password);
                return user;
            }
        }

        public bool ExistError
        {
            get { return existError; }
            private set { existError = value; }
        }
    }
}
