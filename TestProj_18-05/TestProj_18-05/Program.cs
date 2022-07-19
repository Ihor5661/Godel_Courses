using System;
using System.Collections.Generic;
using TestProj_18_05.Service;
using TestProj_18_05.UserInterface;

namespace TestProj_18_05
{

    internal class Program
    {
        static void Main(string[] args)
        {
            const string path = "../../../../DB/";
            IWrite writeInfo = new WriteConsole();
            IRead readInfo = new ReadConsole(writeInfo);
            IConnectorDB connectorDB = new ConnectorDB(path);
            IComparer<Software> comparer = new SoftwareComparer();

            Menu menu = new Menu(writeInfo, readInfo, connectorDB, comparer);

            try
            {
                while (!menu.Exit)
                {
                    menu.StartMenu();
                }
            }
            catch (Exception ex)
            {
                writeInfo.Error(ex.Message);
            }

        }
    }
}
