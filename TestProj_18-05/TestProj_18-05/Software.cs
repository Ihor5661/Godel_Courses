﻿using System;
using System.Runtime.Serialization;

namespace TestProj_18_05
{
    [DataContract]
    internal abstract class Software
    {
        [DataMember]
        public string SoftwareName
        {
            get;
            protected set;
        }

        [DataMember]
        public string SoftwareManufacturer
        {
            get;
            protected set;
        }

        [DataMember]
        public virtual string SoftwareType
        {
            get;
            protected set;
        }

        public Software(string softwareName, string softwareManufacturer)
        {
            this.SoftwareName = softwareName;
            this.SoftwareManufacturer = softwareManufacturer;
            this.SoftwareType = "Software";
        }

        public abstract override string ToString();
    }

    [DataContract]
    internal class FreeSoftware : Software
    {
        [DataMember]
        public DateTime InstallationDate
        {
            get;
            private set;
        }

        [DataMember]
        public TimeSpan FreeTrialPeriod
        {
            get;
            private set;
        }

        [DataMember]
        public override string SoftwareType
        {
            get;
            protected set;
        }

        public FreeSoftware(string softwareName, string softwareManufacturer, DateTime installationDate,
            TimeSpan freeTrialPeriod) : base(softwareName, softwareManufacturer)
        {
            this.SoftwareName = softwareName;
            this.SoftwareManufacturer = softwareManufacturer;
            this.InstallationDate = installationDate;
            this.FreeTrialPeriod = freeTrialPeriod;
            this.SoftwareType = "FreeSoftware";
        }

        public override string ToString()
        {
            string softInfo;

            softInfo = $"\nSoftware name: {this.SoftwareName} \nManufacturer software: {this.SoftwareManufacturer} \nType software: {this.SoftwareType} \nInstallation date: {this.InstallationDate} \nFree trial period: {this.FreeTrialPeriod}\n";

            return softInfo;
        }
    }

    [DataContract]
    internal class SharewareSoftware : Software
    {
        [DataMember]
        public decimal Price
        {
            get;
            private set;
        }

        [DataMember]
        public DateTime InstallationDate
        {
            get;
            private set;
        }

        [DataMember]
        public TimeSpan TermOfUse
        {
            get;
            private set;
        }

        [DataMember]
        public override string SoftwareType
        {
            get;
            protected set;
        }

        public SharewareSoftware(string softwareName, string softwareManufacturer,
            DateTime installationDate, TimeSpan termOfUse, decimal price) : base(softwareName, softwareManufacturer)
        {
            this.SoftwareName = softwareName;
            this.SoftwareManufacturer = softwareManufacturer;
            this.Price = price;
            this.InstallationDate = installationDate;
            this.TermOfUse = termOfUse;
            this.SoftwareType = "SharewareSoftware";
        }

        public override string ToString()
        {
            string softInfo;

            softInfo = $"\nSoftware name: {this.SoftwareName} \nManufacturer software: {this.SoftwareManufacturer} \nType software: {this.SoftwareType} \nInstallation date: {this.InstallationDate} \nTerm of use: {this.TermOfUse} \nPrice: {this.Price}$\n";

            return softInfo;
        }
    }

    [DataContract]
    internal class ProprietarySoftware : Software
    {
        public ProprietarySoftware(string softwareName, string softwareManufacturer)
            : base(softwareName, softwareManufacturer)
        {
            this.SoftwareName = softwareName;
            this.SoftwareManufacturer = softwareManufacturer;
            this.SoftwareType = "ProprietarySoftware";
        }

        public override string ToString()
        {
            string softInfo;

            softInfo = $"\nSoftware name: {this.SoftwareName} \nManufacturer software: {this.SoftwareManufacturer} \nType software: {this.SoftwareType}\n";

            return softInfo;
        }
    }

}
