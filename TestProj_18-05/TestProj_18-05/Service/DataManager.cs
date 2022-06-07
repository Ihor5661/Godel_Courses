using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using TestProj_18_05.UserInterface;

namespace TestProj_18_05.Service
{
    internal class DataManager : IDataController
    {
        private List<User> users = new List<User>();
        private bool isConnect = false;

        public void Connect(string host, string port)
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(User));

            using (var file = new FileStream("../../../../DB/User.json", FileMode.OpenOrCreate)) // ToDo
            {
                var user = jsonFormatter.ReadObject(file) as User;

                if (user != null)
                {
                    users.Add(user); 
                }
            }

            isConnect = true;
            return;
        }

        public void Disconnect(string host, string port)
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(User));

            using (var file = new FileStream("../../../../DB/User.json", FileMode.Create)) // ToDo // the path to the file 
            {
                jsonFormatter.WriteObject(file, new User(null, null)); // ToDo // User data
            }

            isConnect = false;
            return;
        }

        public void AddSoftware(Software software)
        {
            IShowInfo showInfo = new OutConsoleInterface();
            IGetInfo getInfo = new InConsoleInterface();

            if (software != null)
            {
                users[0].Softwares.Add(software); //ToDo // index users
            }
            else
            {
                showInfo.ShowError("No software information!!!");
            }

            return;
        }

        public Software FindSoftwareByName(string name)
        {
            return null;
        }

        public Software FindSoftwareByType(string type)
        {
            return null;
        }

        public List<Software> GetSoftwares()
        {
            return null;
        }


        public User SignIn(string login, string password)
        {
            if (!string.IsNullOrEmpty(password) && CheckLoginExist(login) && !string.IsNullOrEmpty(password))
            {
                //_login = login;
                //MainMenu();
            }
            else
            {
                //Console.WriteLine("Error!!!");
                //Console.ReadLine();
                //Console.Clear();
            }
            return null;
        }

        public User SignUp(string username, string password, string secondPassword)
        {
            return null;
        }

        private bool CheckLoginExist(string login)
        {
            return true; // TODO
        }
    }
}
