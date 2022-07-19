using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TestProj_18_05
{
    [DataContract]
    internal class User
    {
        [DataMember]
        public string Login
        {
            get;
            private set;
        }

        [DataMember]
        public string Password
        {
            get;
            set;
        }

        [DataMember]
        public List<Software> Softwares
        {
            get;
            set;
        }

        public User(string login, string password)
        {
            this.Login = login;
            this.Password = password;
        }

        public override string ToString()
        {
            string userInfo, softInfo;

            softInfo = "";
            foreach (var soft in Softwares)
            {
                softInfo += soft.ToString();
            }

            userInfo = $"\nUser login: {this.Login} \nQuantity softwares: {this.Softwares.Count} \n{softInfo}\n{new string('-', 20)}";

            return userInfo;
        }

    }
}
