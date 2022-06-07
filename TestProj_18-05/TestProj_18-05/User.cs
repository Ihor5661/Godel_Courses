using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TestProj_18_05
{
    [DataContract]
    internal class User
    {
        private string login;
        private string password;
        private List<Software> softwares;

        public User(string login, string password)
        {
            this.login = login;
            this.password = password;
        }

        [DataMember]
        public string Login
        {
            get { return login; }
            private set { login = value; }
        }

        [DataMember]
        public string Password
        {
            get { return password; }
            private set { password = value; }
        }

        [DataMember]
        public List<Software> Softwares
        {
            get { return softwares; }
            set { softwares = value; }
        }
    }
}
