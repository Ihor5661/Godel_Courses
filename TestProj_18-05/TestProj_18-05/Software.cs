using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TestProj_18_05
{
    //class CompSoftware : IComparer<Software>
    //{
    //    public int Compare(Software x, Software y)
    //    {
    //        return string.Compare(x.SoftwareName, y.SoftwareName);
    //    }
    //}

    [DataContract]
    internal /*abstract*/ class Software
    {
        protected string softwareName;
        protected string softwareManufacturer;
        protected string softwareType;

        public Software(string softwareName, string softwareManufacturer)
        {
            this.softwareName = softwareName;
            this.softwareManufacturer = softwareManufacturer;
            this.softwareType = "Software";
        }

        [DataMember]
        public string SoftwareName
        {
            get { return softwareName; }
            set { softwareName = value; }
        }

        [DataMember]
        public string SoftwareManufacturer
        {
            get { return softwareManufacturer; }
            set { softwareManufacturer = value; }
        }

        [DataMember]
        public string SoftwareType
        {
            get { return softwareType; }
            private set { softwareType = value; }
        }
    }

    [DataContract]
    internal class FreeSoftware : Software
    {
        private DateTime installationDate;
        private TimeSpan freeTrialPeriod;

        public FreeSoftware(string softwareName, string softwareManufacturer, DateTime installationDate,
            TimeSpan freeTrialPeriod) : base(softwareName, softwareManufacturer)
        {
            this.softwareName = softwareName;
            this.softwareManufacturer = softwareManufacturer;
            this.installationDate = installationDate;
            this.freeTrialPeriod = freeTrialPeriod;
            this.softwareType = "FreeSoftware";
        }

        [DataMember]
        public DateTime InstallationDate
        {
            get { return installationDate; }
            private set { installationDate = value; }
        }

        [DataMember]
        public TimeSpan FreeTrialPeriod
        {
            get { return freeTrialPeriod; }
            private set { freeTrialPeriod = value; }
        }

        [DataMember]
        public string SoftwareType
        {
            get { return softwareType; }
            private set { softwareType = value; }
        }
    }

    [DataContract]
    internal class SharewareSoftware : Software
    {
        private decimal price;
        private DateTime installationDate;
        private TimeSpan termOfUse;

        public SharewareSoftware(string softwareName, string softwareManufacturer,
            DateTime installationDate, TimeSpan termOfUse, decimal price) : base(softwareName, softwareManufacturer)
        {
            this.softwareName = softwareName;
            this.softwareManufacturer = softwareManufacturer;
            this.price = price;
            this.installationDate = installationDate;
            this.termOfUse = termOfUse;
            this.softwareType = "SharewareSoftware";
        }

        [DataMember]
        public decimal Price
        {
            get { return price; }
            private set { price = value; }
        }

        [DataMember]
        public DateTime InstallationDate
        {
            get { return installationDate; }
            private set { installationDate = value; }
        }

        [DataMember]
        public TimeSpan TermOfUse
        {
            get { return termOfUse; }
            private set { termOfUse = value; }
        }

        [DataMember]
        public string SoftwareType
        {
            get { return softwareType; }
            private set { softwareType = value; }
        }
    }

    [DataContract]
    internal class ProprietarySoftware : Software
    {
        public ProprietarySoftware(string softwareName, string softwareManufacturer)
            : base(softwareName, softwareManufacturer)
        {
            this.softwareName = softwareName;
            this.softwareManufacturer = softwareManufacturer;
            this.softwareType = "ProprietarySoftware";
        }

        [DataMember]
        public string SoftwareType
        {
            get { return softwareType; }
            private set { softwareType = value; }
        }
    }

}
