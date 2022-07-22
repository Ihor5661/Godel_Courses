using System;
using System.Collections.Generic;
using TestProj_18_05.UserInterface;

namespace TestProj_18_05.Service
{
    internal class DataManager : IDataManager
    {
        User user;

        public DataManager(User user)
        {
            if (user == null)
            {
                throw new NoUserInformationException();
            }

            this.user = user;
        }

        public bool AddSoftware(Software software)
        {
            if (software == null)
            {
                throw new NoSoftwareInformationException();
            }

            if (user.Softwares == null)
            {
                user.Softwares = new List<Software>();
            }
            user.Softwares.Add(software);

            return true;
        }

        public bool DeleteSoftware(string softName)
        {
            int numberSoft = FindNumSoftwareByName(softName);

            if (user.Softwares == null)
            {
                throw new NoSoftwareInformationException();
            }

            user.Softwares.RemoveAt(numberSoft);

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

            if (numberSoft == -1)
            {
                throw new NotFoundSoftNameException();
            }

            return numberSoft;
        }

        public List<Software> FindSoftwaresByName(string namer)
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

        public List<Software> FindSoftwaresByType(string type)
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

        public List<Software> SortSoftwares() 
        {
            List<Software> softwares = new List<Software>(user.Softwares);
            softwares.Sort();

            return softwares;
        }

    }
}
