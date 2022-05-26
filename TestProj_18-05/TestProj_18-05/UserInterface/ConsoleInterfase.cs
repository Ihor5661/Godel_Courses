using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProj_18_05.Service;

namespace TestProj_18_05.UserInterface
{
    enum SoftwareTypes
    {
        Software,
        FreeSoftware,
        SharewareSoftware,
        ProprietarySoftware
    }

    internal class ConsoleInterfase : IShowInfo, IGetInfo
    {
        public void ClearDisplay()
        {
            Console.ResetColor();
            Console.Clear();
        }

        public void ShowError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public void ShowFooterInfo(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (!string.IsNullOrEmpty(message))
            {
                Console.WriteLine(new string('=', 50));
                Console.WriteLine($"{message}");
            }
            Console.WriteLine(new string('=', 50));
            Console.ResetColor();
        }

        public void ShowHeaderInfo(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(new string('=', 20) + $" {message} " + new string('=', 20));
            Console.ResetColor();
        }

        public void ShowInfo(string message)
        {
            Console.WriteLine(message);
        }

        public void SkipLines(int numLine)
        {
            if (!(numLine <= 0))
            {
                Console.Write(new string('\n', numLine));
            }
        }

        public void ShowSoftwareInfo(Software software)
        {
            if (software == null)
            {
                IErrorCatcher errorCatcher = new ErrorCatcher();
                errorCatcher.Error(0);
                return;
            }

            ShowInfo("Software name: " + software.softwareName);
            ShowInfo("Manufacturer software: " + software.softwareManufacturer);

            if (software is FreeSoftware)
            {
                FreeSoftware freeSoftware = (FreeSoftware)software;
                ShowInfo("Type software: " + freeSoftware.softwareType);
                ShowInfo("Installation date: " + freeSoftware.InstallationDate.ToString());
                ShowInfo("Free trial period" + freeSoftware.freeTrialPeriod.ToString());
            }
            if (software is SharewareSoftware)
            {
                SharewareSoftware sharewareSoftware = (SharewareSoftware)software;
                ShowInfo("Type software: " + sharewareSoftware.softwareType);
                ShowInfo("Installation date: " + sharewareSoftware.installationDate.ToString());
                ShowInfo("Term of use: " + sharewareSoftware.termOfUse.ToString());
                ShowInfo("Price: " + sharewareSoftware.price.ToString() + "$");
            }
            if (software is ProprietarySoftware)
            {
                ProprietarySoftware proprietarySoftware = (ProprietarySoftware)software;
                ShowInfo("Type software: " + proprietarySoftware.softwareType);
            }

            ShowFooterInfo(null);
        }

        //public void SoftwareInfo(FreeSoftware software)
        //{
        //    ShowInfo("Software name: " + software.softwareName);
        //    ShowInfo("Manufacturer software: " + software.softwareManufacturer);
        //    ShowInfo("Installation date: " + software.InstallationDate.ToString());
        //    ShowInfo("Free trial period" + software.freeTrialPeriod.ToString());
        //    ShowFooterInfo(null);
        //}

        //public void SoftwareInfo(SharewareSoftware software)
        //{
        //    ShowInfo("Software name: " + software.softwareName);
        //    ShowInfo("Manufacturer software: " + software.softwareManufacturer);
        //    ShowInfo("Installation date: " + software.installationDate.ToString());
        //    ShowInfo("Term of use: " + software.termOfUse.ToString());
        //    ShowInfo("Price: " + software.price.ToString() + "$");
        //    ShowFooterInfo(null);
        //}

        //public void SoftwareInfo(ProprietarySoftware software)
        //{
        //    ShowInfo("Software name: " + software.softwareName);
        //    ShowInfo("Manufacturer software: " + software.softwareManufacturer);
        //    ShowFooterInfo(null);
        //}

        public void UserInfo(User user)
        {
            ShowInfo("User login: " + user.Login);
            ShowInfo("Quantity softwares: " + user.Softwares.Count);
            SkipLines(1);
            foreach (var software in user.Softwares)
            {
                ShowSoftwareInfo(software);
            }
            ShowFooterInfo($"End information about user {user.Login}");
            SkipLines(2);

            return;
        }

        //---------------------------------------------------------------------------//

        public string GetInfo(string message)
        {
            ShowInfo(message);
            string info = Console.ReadLine();
            if (info == null)
            {
                info = "";
            }
            return info;
        }

        public Software GetSoftware()
        {
            Software software;
            string softwareName;
            string softwareManufacturer;

            int softwareType;
            softwareType = GetTypeSoftware();

            if (IsPermissibleTypeSoftwareNumber(softwareType))
            {
                softwareName = GetInfo("Enter software name: ");
                softwareManufacturer = GetInfo("Enter software manufacturer: ");
            }

            switch (softwareType)
            {
                case (int)SoftwareTypes.FreeSoftware:
                    {
                        DateTime installationDate;
                        TimeSpan freeTrialPeriod;
                        //software = new FreeSoftware(softwareName, softwareManufacturer,);
                        break;
                    }
                case (int)SoftwareTypes.SharewareSoftware:
                    {
                        //software = new FreeSoftware();
                        break;
                    }
                case (int)SoftwareTypes.ProprietarySoftware:
                    {
                        // = new FreeSoftware();
                        break;
                    }
                default:
                    {
                        IErrorCatcher errorCatcher = new ErrorCatcher();
                        errorCatcher.Error(1);
                        break;
                    }
            }

            return null;
        }

        public User GetUserData()
        {
            return null;
        }

        private int GetTypeSoftware()
        {
            string message = "";
            for (int i = (int)SoftwareTypes.FreeSoftware; i < Enum.GetNames(typeof(SoftwareTypes)).Length; i++)
            {
                message += ($"{i} - {(SoftwareTypes)i}\n");
            }
            message += ("Enter software type: ");

            int softwareType;
            string input = GetInfo(message);
            int.TryParse(input, out softwareType);

            if (softwareType >= Enum.GetNames(typeof(SoftwareTypes)).Length
                || softwareType < (int)SoftwareTypes.Software)
            {
                softwareType = 3; //ToDo // No default value // Error
            }

            return softwareType;
        }

        private DateTime GetDateTime()
        {
            return DateTime.Now;
        }


        private bool IsPermissibleTypeSoftwareNumber(int number)
        {
            bool result = ((int)SoftwareTypes.FreeSoftware <= number && number < Enum.GetNames(typeof(SoftwareTypes)).Length);
            return result;
        }


    }
}
