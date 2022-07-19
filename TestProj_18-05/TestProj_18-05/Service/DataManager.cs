using System;
using System.Collections.Generic;
using TestProj_18_05.UserInterface;

namespace TestProj_18_05.Service
{
    enum SoftwareTypes
    {
        FreeSoftware,
        SharewareSoftware,
        ProprietarySoftware
    }

    internal class DataManager : IDataManager
    {
        User user;
        IRead read;

        public DataManager(User user, IRead read)
        {
            if (user == null)
            {
                throw new NoUserInformation();
            }

            this.user = user;
            this.read = read;
        }

        public bool AddSoftware(Software software)
        {
            if (software == null)
            {
                //throw new NoSoftwareInformation();
                software = GetSoftware();
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
                throw new NoSoftwareInformation();
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
                throw new NotFoundSoftName();
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

        /////////////////////////////////////////////////////////////////////
        private Software GetSoftware()
        {
            Software software;
            string softwareName;
            string softwareManufacturer;
            DateTime installationDate;
            TimeSpan freeTrialPeriod, termOfUse;
            decimal price;
            int softwareType;


            softwareType = GetTypeSoftware();

            softwareName = read.GetInfo("Enter software name: ");
            softwareManufacturer = read.GetInfo("Enter software manufacturer: ");

            switch (softwareType)
            {
                case (int)SoftwareTypes.FreeSoftware:
                    {
                        installationDate = read.GetDateTime("Enter installation date (dd.mm.yyyy hh:mm:ss): ");
                        freeTrialPeriod = read.GetTime("Enter free trial period (ddd.hh:mm:ss): ");
                        software = new FreeSoftware(softwareName, softwareManufacturer, installationDate, freeTrialPeriod);
                        break;
                    }
                case (int)SoftwareTypes.SharewareSoftware:
                    {
                        installationDate = read.GetDateTime("Enter installation date (dd.mm.yyyy hh:mm:ss): ");
                        termOfUse = read.GetTime("Enter term of use (ddd.hh:mm:ss): ");
                        price = read.GetCount("Enter price ($$$$.$$): ");

                        software = new SharewareSoftware(softwareName, softwareManufacturer, installationDate, termOfUse, price);
                        break;
                    }
                case (int)SoftwareTypes.ProprietarySoftware:
                    {
                        software = new ProprietarySoftware(softwareName, softwareManufacturer);
                        break;
                    }
                default:
                    {
                        throw new OperationNotFound();
                    }
            }

            return software;
        }

        private int GetTypeSoftware()
        {
            int softwareType;
            string input;
            string message = "";


            for (int i = (int)SoftwareTypes.FreeSoftware; i < Enum.GetNames(typeof(SoftwareTypes)).Length; i++)
            {
                message += ($"{i + 1} - {(SoftwareTypes)i}\n");
            }
            message += ("Enter software type: ");

            input = read.GetInfo(message);

            if (!int.TryParse(input, out softwareType))
            {
                throw new InvalidInputFormat();
            }

            if (!IsPermissibleTypeSoftwareNumber(softwareType))
            {
                throw new OperationNotFound();
            }

            return --softwareType;
        }

        private bool IsPermissibleTypeSoftwareNumber(int number)
        {
            bool result = ((int)SoftwareTypes.FreeSoftware < number && number <= Enum.GetNames(typeof(SoftwareTypes)).Length);
            return result;
        }

    }
}
