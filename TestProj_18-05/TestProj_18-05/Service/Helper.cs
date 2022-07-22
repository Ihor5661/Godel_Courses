using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProj_18_05.Service;
using TestProj_18_05.UserInterface;

namespace TestProj_18_05
{
    enum SoftwareTypes
    {
        FreeSoftware,
        SharewareSoftware,
        ProprietarySoftware
    }

    internal class Helper : IHelper
    {
        private readonly IRead read;

        public Helper(IRead read)
        {
            this.read = read;
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
                        throw new OperationNotFoundException();
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
                throw new InvalidInputFormatException();
            }

            if (!IsPermissibleTypeSoftwareNumber(softwareType))
            {
                throw new OperationNotFoundException();
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
