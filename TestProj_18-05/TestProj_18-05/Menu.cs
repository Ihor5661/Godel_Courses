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
        IConnector connectorDB = new Context("../../../../DB/");
        IUserConnector userConnector; // = new Authentication();

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
                            
                            login = getInfo.GetInfo("Enter login: ");
                            password = getInfo.GetInfo("Enter password: ");

                            user = connectorDB.Connect(login);
                            userConnector = new Authentication(user);
                            user = userConnector.SignIn(login, password);

                            if (!userConnector.ExistError)
                            {
                                MainMenu(user);
                            }
                            else
                            {
                                errorCatcher.Error("");
                            }

                            connectorDB.Disconnect();
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

                            login = getInfo.GetInfo("Enter login: ");
                            password = getInfo.GetInfo("Enter password: ");
                            secondPassword = getInfo.GetInfo("Enter password again: ");

                            user = connectorDB.Connect(login);
                            userConnector = new Authentication(user);
                            user = userConnector.SignUp(login, password, secondPassword);

                            if (!userConnector.ExistError)
                            {
                                MainMenu(user);
                            }
                            else
                            {
                                errorCatcher.Error("");
                            }

                            connectorDB.Disconnect();
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
            IDataController dataController = new DataManager(user);
            int inputVar;
            string input;
            bool exit = false;

            if (user == null)
            {
                exit = true;
                errorCatcher.Error(0);
            }

            while (!exit)
            {
                showInfo.ClearDisplay();
                showInfo.ShowHeaderInfo($"Hello, {user.Login} !!!");
                input = getInfo.GetInfo("1) Add record; \n2) Delete record; \n3) Find record;" +
                    " \n4) Show information about all user`s records; \n5) Sort software by name; " +
                    " \n6) Save changes; \n7) Exit;");
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
                            string nameSoftware = getInfo.GetInfo("Enter software name: ");
                            dataController.DeleteSoftware(nameSoftware);
                            break;
                        }
                    case 3:
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
                                        showInfo.ShowAllSoftwaresInfo(dataController.FindSoftwareByName(softName));
                                        getInfo.GetInfo("");
                                        break;
                                    }
                                case 2:
                                    {
                                        string softType;
                                        softType = getInfo.GetInfo("Enter software type: ");
                                        showInfo.ShowAllSoftwaresInfo(dataController.FindSoftwareByType(softType));
                                        getInfo.GetInfo("");
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
                    case 4:
                        {
                            showInfo.ShowAllSoftwaresInfo(dataController.GetSoftwares());
                            getInfo.GetInfo("");
                            break;
                        }
                    case 5:
                        {
                            showInfo.ShowAllSoftwaresInfo(dataController.SortSoftwares());
                            getInfo.GetInfo("");
                            break;
                        }
                    case 6:
                        {
                            if (connectorDB.SaveChanges(user))
                            {
                                showInfo.ShowInfo("Data saved successfully");
                            }
                            else
                            {
                                errorCatcher.Error(0);
                            }
                            getInfo.GetInfo("");
                            break;
                        }
                    case 7:
                        {
                            showInfo.ShowInfo("Bye-Bye!!!");
                            getInfo.GetInfo("");
                            exit = true;
                            break;
                        }
                    default:
                        {
                            showInfo.ShowError("Operation not found!!!");
                            getInfo.GetInfo("");
                            existError = true;
                            exit = true;
                            break;
                        }
                }

                if (dataController.ExistError)
                {
                    exit = dataController.ExistError;
                    errorCatcher.Error("");
                }
                
            }
        }
    }
}
