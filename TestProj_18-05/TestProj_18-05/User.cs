using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProj_18_05
{
    internal class User
    {
        private string login;
        private string password;
        private List<Software> softwares;

        public string Login
        {
            get { return login; }
            private set { login = value; }
        }

        public string Password
        {
            get { return password; }
            private set { password = value; }
        }

        public List<Software> Softwares
        {
            get { return softwares; }
            set { softwares = value; }
        }
    }
}
