using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProj_18_05.Service
{
    internal class DataManager : IDataController
    {
        private bool isConnect = false;

        public void Connect(string host, string port)
        {
            isConnect = true;
            return;
        }

        public void Disconnect(string host, string port)
        {
            isConnect = false;
            return;
        }

        public void AddSoftware(string login, Software software)
        {
            throw new NotImplementedException();
        }

        public Software FindSoftwareByName(string name)
        {
            throw new NotImplementedException();
        }

        public Software FindSoftwareByType(string type)
        {
            throw new NotImplementedException();
        }

        public List<Software> GetSoftwares()
        {
            throw new NotImplementedException();
        }

        public void SignIn(string login, string password)
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
        }

        public void SignUp(string username, string password)
        {
            throw new NotImplementedException();
        }

        private bool CheckLoginExist(string login)
        {
            return true; // TODO
        }
    }
}
