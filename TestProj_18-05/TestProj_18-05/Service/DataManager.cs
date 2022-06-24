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
        User user;
        IErrorCatcher errorCatcher = new ErrorCatcher();
        IShowInfo showInfo = new OutConsoleInterface();
        IGetInfo getInfo = new InConsoleInterface();
        bool existError = false;


        public DataManager(User user)
        {
            if (user == null)
            {
                errorCatcher.Error("No user information!!!");
                existError = true;
                getInfo.GetInfo("");
            }
            else
            {
                this.user = user;
            }
        }

        public bool AddSoftware(Software software)
        {
            if (software != null)
            {
                if (user.Softwares == null)
                {
                    user.Softwares = new List<Software>();
                }
                user.Softwares.Add(software);
            }
            else
            {
                errorCatcher.Error("No software information!!!");
                existError = true;
                getInfo.GetInfo("");
            }

            return true;
        }

        public bool DeleteSoftware(string softName)
        {
            int numberSoft = FindNumSoftwareByName(softName);

            if (user.Softwares != null)
            {
                if (user.Softwares.Count > 0 && numberSoft != -1)
                {
                    user.Softwares.RemoveAt(numberSoft);
                }
                else
                {
                    errorCatcher.Error("Software with this name was not found!!!");
                    existError = true;
                }
               
            }
            else
            {
                errorCatcher.Error("No software info!!!");
                existError = true;
            }

            return true;
        }

        private int FindNumSoftwareByName(string namer)
        {
            int numberSoft = -1;

            for (int i = 0; i < user.Softwares.Count; i++)
            {
                if (user.Softwares[i].SoftwareName == namer)
                {
                    numberSoft = i;
                    break;
                }
            }

            return numberSoft;
        }
        

        public List<Software> FindSoftwareByName(string namer)
        {
            List<Software> softwares = new List<Software>();
            bool isSoft = false;

            for (int i = 0; i < user.Softwares.Count; i++)
            {
                if (user.Softwares[i].SoftwareName == namer)
                {
                    softwares.Add(user.Softwares[i]);
                    isSoft = true;
                }
            }
            if (isSoft)
            {
                return softwares;
            }
            return null;
        }

        public List<Software> FindSoftwareByType(string type)
        {
            List<Software> softwares = new List<Software>();
            bool isSoft = false;

            for (int i = 0; i < user.Softwares.Count; i++)
            {
                if (user.Softwares[i].SoftwareType == type)
                {
                    softwares.Add(user.Softwares[i]);
                    isSoft = true;
                }
            }
            if (isSoft)
            {
                return softwares;
            }
            return null;
        }

        public List<Software> GetSoftwares()
        {
            return user.Softwares;
        }

        public List<Software> SortSoftwares() //ToDo
        {
            List<Software> softwaresTemp = new List<Software>(user.Softwares);
            List<string> softName = new List<string>();
            List<Software> softwares = new List<Software>();

            for (int i = 0; i < user.Softwares.Count; i++)
            {
                softName.Add(user.Softwares[i].SoftwareName);
            }
            softName.Sort();

            for (int i = 0; i < user.Softwares.Count; i++)
            {
                for (int j = 0; j < softwaresTemp.Count; j++)
                {
                    if (softName[i] == softwaresTemp[j].SoftwareName)
                    {
                        softwares.Add(softwaresTemp[j]);
                        softwaresTemp.RemoveAt(j);
                        break;
                    }
                }
            }
            
            return softwares;
        }

        public bool ExistError
        {
            get { return existError; }
            private set { existError = value; }
        }

    }
}
