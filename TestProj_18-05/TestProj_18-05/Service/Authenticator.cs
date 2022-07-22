using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProj_18_05.UserInterface;

namespace TestProj_18_05.Service
{
    internal class Authenticator : IAuthenticator
    {
        User user;
        const int minPassLength = 6;

        public Authenticator(User user)
        {
            this.user = user;
        }

        public User SignIn(string login, string password)
        {
            if (user == null)
            {
                throw new UnknownUserNameException();
            }
            if (user.Password != password)
            {
                throw new PasswordValidationException();
            }

            return user;
        }

        public User SignUp(string login, string password, string secondPassword)
        {
            if (user != null)
            {
                throw new UserNameException();
            }
            if (password != secondPassword)
            {
                throw new PasswordEqualsException();
            }
            if (password.Length < minPassLength)
            {
                throw new PasswordFormatException();
            }

            user = new User(login, password);
            return user;
        }

        public bool Exit(User user)
        {
            user = null;
            return true;
        }
    }
}
