using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProj_18_05
{
    internal abstract class Software
    {
        public string softwareName;
        public string softwareManufacturer;
        public string softwareType;

        public Software(string softwareName, string softwareManufacturer)
        {
            this.softwareName = softwareName;
            this.softwareManufacturer = softwareManufacturer;
            this.softwareType = "Software";
    }

        public string SoftwareName
        {
            get { return softwareName; }
            set { softwareName = value; }
        }

        public string SoftwareManufacturer
        {
            get { return softwareManufacturer; }
            set { softwareManufacturer = value; }
        }
    }

    internal class FreeSoftware : Software
    {
        public DateTime installationDate;
        public TimeSpan freeTrialPeriod;

        public FreeSoftware(string softwareName, string softwareManufacturer, DateTime installationDate,
            TimeSpan freeTrialPeriod) : base(softwareName, softwareManufacturer)
        {
            this.softwareName = softwareName;
            this.softwareManufacturer = softwareManufacturer;
            this.installationDate = installationDate;
            this.freeTrialPeriod = freeTrialPeriod;
            this.softwareType = "FreeSoftware";
        }

        public DateTime InstallationDate
        {
            get { return installationDate; }
            private set { installationDate = value; }
        }

        public TimeSpan FreeTrialPeriod
        {
            get { return freeTrialPeriod; }
            private set { freeTrialPeriod = value; }
        }
    }

    internal class SharewareSoftware : Software
    {
        public decimal price;
        public DateTime installationDate;
        public TimeSpan termOfUse;

        public SharewareSoftware(string softwareName, string softwareManufacturer, decimal price,
            DateTime installationDate, TimeSpan termOfUse) : base(softwareName, softwareManufacturer)
        {
            this.softwareName = softwareName;
            this.softwareManufacturer = softwareManufacturer;
            this.price = price;
            this.installationDate = installationDate;
            this.termOfUse = termOfUse;
            this.softwareType = "SharewareSoftware";
        }

        public decimal Price
        {
            get { return price; }
            private set { price = value; }
        }

        public DateTime InstallatioDate
        {
            get { return installationDate; }
            private set { installationDate = value; }
        }

        public TimeSpan TermOfUse
        {
            get { return termOfUse; }
            private set { termOfUse = value; }
        }
    }

    internal class ProprietarySoftware : Software
    {
        public ProprietarySoftware(string softwareName, string softwareManufacturer)
            : base(softwareName, softwareManufacturer)
        {
            this.softwareName = softwareName;
            this.softwareManufacturer = softwareManufacturer;
            this.softwareType = "ProprietarySoftware";
        }
    }

}
