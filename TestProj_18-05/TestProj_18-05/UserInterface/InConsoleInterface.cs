using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProj_18_05.Service;

namespace TestProj_18_05.UserInterface
{
    internal class InConsoleInterface : IGetInfo
    {
        IShowInfo showInfo = new OutConsoleInterface();

        public string GetInfo(string message)
        {
            showInfo.ShowInfo(message);
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
            DateTime installationDate;
            TimeSpan freeTrialPeriod, termOfUse;
            decimal price;

            int softwareType;
            softwareType = GetTypeSoftware();

            if (!IsPermissibleTypeSoftwareNumber(softwareType))
            {
                IErrorCatcher errorCatcher = new ErrorCatcher();
                errorCatcher.Error("Unkown software type");
                return null;
            }

            softwareName = GetInfo("Enter software name: ");
            softwareManufacturer = GetInfo("Enter software manufacturer: ");

            switch (softwareType)
            {
                case (int)SoftwareTypes.FreeSoftware:
                    {
                        installationDate = GetDateTime();
                        freeTrialPeriod = GetTimeSpan("Enter free trial period (ddd.hh:mm:ss): ");
                        software = new FreeSoftware(softwareName, softwareManufacturer, installationDate, freeTrialPeriod);
                        break;
                    }
                case (int)SoftwareTypes.SharewareSoftware:
                    {
                        installationDate = GetDateTime();
                        termOfUse = GetTimeSpan("Enter term of use (ddd.hh:mm:ss): ");
                        price = GetDecimal();

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
                        IErrorCatcher errorCatcher = new ErrorCatcher();
                        errorCatcher.Error("Unkown software type");
                        software = null;
                        break;
                    }
            }

            return software;
        }

        //public User GetUserData()
        //{
        //    User user;
        //    string login, password, secondPassword;

        //    login = GetInfo("Enter login: ");
        //    password = GetInfo("Enter password");
        //    //secondPassword = GetInfo("Enter password secondary: "); //TODO check

        //    user = new User(login, password);

        //    return user;
        //}


        //---------------------------------------------------//

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
            DateTime date;
            string input;

            input = GetInfo("Enter installation date (dd.mm.yyyy hh:mm:ss): ");
            try
            {
                date = DateTime.Parse(input);
            }
            catch (Exception)
            {
                IErrorCatcher errorCatcher = new ErrorCatcher();
                errorCatcher.Error("Invalid date format");
                date = DateTime.Now; // TODO
            }
            
            return date;
        }
        private TimeSpan GetTimeSpan(string message)
        {
            TimeSpan timeSpan;
            string input;

            input = GetInfo(message);
            try
            {
                timeSpan = TimeSpan.Parse(input);
            }
            catch (Exception)
            {
                IErrorCatcher errorCatcher = new ErrorCatcher();
                errorCatcher.Error("Invalid time format");
                timeSpan = TimeSpan.Zero; // TODO
            }

            return timeSpan;
        }
        private decimal GetDecimal()
        {
            decimal price;
            string input;

            input = GetInfo("Enter price ($$$$.$$): ");
            try
            {
                price = decimal.Parse(input);
            }
            catch (Exception)
            {
                IErrorCatcher errorCatcher = new ErrorCatcher();
                errorCatcher.Error("Invalid price format");
                price = decimal.Zero; // TODO
            }

            return price;
        }
        private bool IsPermissibleTypeSoftwareNumber(int number)
        {
            bool result = ((int)SoftwareTypes.FreeSoftware <= number && number < Enum.GetNames(typeof(SoftwareTypes)).Length);
            return result;
        }
    }
}
