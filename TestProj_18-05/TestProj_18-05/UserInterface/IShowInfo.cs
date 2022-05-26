using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProj_18_05.UserInterface
{
    internal interface IShowInfo
    {
        void ShowHeaderInfo(string message);
        void ShowInfo(string message);
        void ShowError(string message);
        void ClearDisplay();
        void SkipLines(int qtyLine);
        void ShowFooterInfo(string message);

        void ShowSoftwareInfo(Software software);
        //void SoftwareInfo(FreeSoftware software);
        //void SoftwareInfo(SharewareSoftware software);
        //void SoftwareInfo(ProprietarySoftware software);
        
        void UserInfo(User user);
    }
}
