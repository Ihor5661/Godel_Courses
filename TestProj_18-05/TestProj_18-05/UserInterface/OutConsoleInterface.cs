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

    internal class OutConsoleInterface : IShowInfo
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

            ShowInfo("Software name: " + software.SoftwareName);
            ShowInfo("Manufacturer software: " + software.SoftwareManufacturer);

            if (software is FreeSoftware)
            {
                FreeSoftware freeSoftware = (FreeSoftware)software;
                ShowInfo("Type software: " + freeSoftware.SoftwareType);
                ShowInfo("Installation date: " + freeSoftware.InstallationDate.ToString());
                ShowInfo("Free trial period" + freeSoftware.FreeTrialPeriod.ToString());
            }
            if (software is SharewareSoftware)
            {
                SharewareSoftware sharewareSoftware = (SharewareSoftware)software;
                ShowInfo("Type software: " + sharewareSoftware.SoftwareType);
                ShowInfo("Installation date: " + sharewareSoftware.InstallationDate.ToString());
                ShowInfo("Term of use: " + sharewareSoftware.TermOfUse.ToString());
                ShowInfo("Price: " + sharewareSoftware.Price.ToString() + "$");
            }
            if (software is ProprietarySoftware)
            {
                ProprietarySoftware proprietarySoftware = (ProprietarySoftware)software;
                ShowInfo("Type software: " + proprietarySoftware.SoftwareType);
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
        public void ShowAllSoftwaresInfo(List<Software> softwares)
        {
            foreach (var software in softwares)
            {
                ShowSoftwareInfo(software);
            }
            ShowInfo("Quantity softwares: " + softwares.Count);
            SkipLines(2);

            return;
        }

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
    }
}
