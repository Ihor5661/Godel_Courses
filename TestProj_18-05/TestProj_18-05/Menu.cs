using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProj_18_05.Service;
using TestProj_18_05.UserInterface;

namespace TestProj_18_05
{
    class Menu
    {
        private bool existError = false;

        public bool ExistError
        {
            get { return existError; }
            private set { existError = value; }
        }

        IShowInfo showInfo = new OutConsoleInterface();
        IGetInfo getInfo = new InConsoleInterface();
        IErrorCatcher errorCatcher = new ErrorCatcher();
        IDataController dataController = new DataManager();
        User user;

        public void StartMenu()
        {
            int inputVar;
            string input;

            showInfo.ClearDisplay();
            input = getInfo.GetInfo("1) Sign in; \n2) Sign up; \n3) Exit;");
            int.TryParse(input, out inputVar);
            showInfo.ClearDisplay();

            switch (inputVar)
            {
                case 1:
                    {
                        try
                        {
                            string login, password;
                            dataController.Connect(null, null);

                            login = getInfo.GetInfo("Enter login: ");
                            password = getInfo.GetInfo("Enter password: ");
                            user = dataController.SignIn(login, password);
                            if (user != null)
                            {
                                MainMenu(user);
                            }
                            else
                            {
                                errorCatcher.Error(""); // warning
                            }

                            dataController.Disconnect(null, null);
                        }
                        catch (Exception)
                        {
                            errorCatcher.Error(1);
                            existError = true;
                        }

                        break;
                    }
                case 2:
                    {
                        try
                        {
                            string login, password, secondPassword;
                            dataController.Connect(null, null);

                            login = getInfo.GetInfo("Enter login: ");
                            password = getInfo.GetInfo("Enter password: ");
                            secondPassword = getInfo.GetInfo("Enter password again: ");
                            user = dataController.SignUp(login, password, secondPassword);

                            if (user != null)
                            {
                                MainMenu(user);
                            }
                            else
                            {
                                errorCatcher.Error(1);  // warning
                            }

                            dataController.Disconnect(null, null);
                        }
                        catch (Exception)
                        {
                            errorCatcher.Error(1);
                            existError = true;
                        }

                        break;
                    }
                case 3:
                    {
                        showInfo.ShowInfo("Bye-Bye!!!");
                        getInfo.GetInfo("");
                        break;
                    }
                default:
                    {
                        showInfo.ShowError("Operation not found!!!");
                        existError = true;
                        break;
                    }
            }
        }

        private void MainMenu(User user)
        {
            int inputVar;
            string input;
            bool exit = false;

            while (!exit)
            {
                showInfo.ClearDisplay();
                showInfo.ShowHeaderInfo($"Hello, {user.Login} !!!");
                input = getInfo.GetInfo("1) Add record; \n2) Find record;" +
                    " \n3) Show information about all user`s records; \n4) Exit;");
                int.TryParse(input, out inputVar);
                showInfo.ClearDisplay();

                switch (inputVar)
                {
                    case 1:
                        {
                            Software software = getInfo.GetSoftware();
                            dataController.AddSoftware(software);
                            break;
                        }
                    case 2:
                        {
                            input = getInfo.GetInfo("1) Find by name; \n2) Find by type; \n3) Exit;");
                            int.TryParse(input, out inputVar);
                            showInfo.ClearDisplay();

                            switch (inputVar)
                            {
                                case 1:
                                    {
                                        string softName;
                                        softName = getInfo.GetInfo("Enter software name: ");
                                        dataController.FindSoftwareByName(softName);
                                        break;
                                    }
                                case 2:
                                    {
                                        string softType;
                                        softType = getInfo.GetInfo("Enter software type: ");
                                        dataController.FindSoftwareByType(softType);
                                        break;
                                    }
                                case 3:
                                    {
                                        showInfo.ShowInfo("Bye-Bye!!!");
                                        getInfo.GetInfo("");
                                        break;
                                    }
                                default:
                                    {
                                        showInfo.ShowError("Operation not found!!!");
                                        existError = true;
                                        break;
                                    }
                            }
                            break;
                        }
                    case 3:
                        {
                            showInfo.ShowAllSoftwaresInfo(user.Softwares);
                            break;
                        }
                    case 4:
                        {
                            showInfo.ShowInfo("Bye-Bye!!!");
                            exit = true;
                            break;
                        }
                    default:
                        {
                            showInfo.ShowError("Operation not found!!!");
                            existError = true;
                            exit = true;
                            break;
                        }
                }
            }
        }
    }
}
