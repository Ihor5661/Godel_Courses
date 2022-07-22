using System.Collections.Generic;
using TestProj_18_05.Service;
using TestProj_18_05.UserInterface;

namespace TestProj_18_05
{
    class Menu
    {
        private readonly IWrite writeInfo;
        private readonly IRead readInfo;
        private readonly IConnectorDB connectorDB;
        private readonly IHelper helper;
        private IAuthenticator userAuthenticator;
        private IDataManager dataManager;
        private User user;

        public bool Exit
        {
            get;
            private set;
        }

        public Menu(IWrite writeInfo, IRead readInfo, IConnectorDB connectorDB, IHelper helper)
        {
            this.writeInfo = writeInfo;
            this.readInfo = readInfo;
            this.connectorDB = connectorDB;
            this.helper = helper;
            this.Exit = false;
        }

        public void StartMenu()
        {
            int inputVar;
            string input;
            string login, password, secondPassword;

            writeInfo.ClearDisplay();
            input = readInfo.GetInfo("1) Sign in; \n2) Sign up; \n3) Exit;");
            writeInfo.ClearDisplay();

            if (!int.TryParse(input, out inputVar))
            {
                throw new InvalidInputFormatException();
            }

            switch (inputVar)
            {
                case 1:
                    {
                        login = readInfo.GetInfo("Enter login: ");
                        password = readInfo.GetInfo("Enter password: ");

                        user = connectorDB.Connect(login);
                        userAuthenticator = new Authenticator(user);
                        user = userAuthenticator.SignIn(login, password);

                        UserMenu(user);

                        userAuthenticator.Exit(user);
                        connectorDB.Disconnect();

                        break;
                    }
                case 2:
                    {
                        login = readInfo.GetInfo("Enter login: ");
                        password = readInfo.GetInfo("Enter password: ");
                        secondPassword = readInfo.GetInfo("Enter password again: ");

                        user = connectorDB.Connect(login);
                        userAuthenticator = new Authenticator(user);
                        user = userAuthenticator.SignUp(login, password, secondPassword);
                        connectorDB.SaveChanges(user);


                        UserMenu(user);

                        userAuthenticator.Exit(user);
                        connectorDB.Disconnect();

                        break;
                    }
                case 3:
                    {
                        Exit = true;
                        readInfo.GetInfo("Bye-Bye!!!");
                        break;
                    }
                default:
                    {
                        throw new OperationNotFoundException();
                    }
            }
        }

        private void UserMenu(User user)
        {
            int inputVar;
            string input;
            bool exit;
            Software software;
            string nameSoftware;

            if (user == null)
            {
                throw new NoUserInformationException();
            }

            exit = false;
            dataManager = new DataManager(user);

            while (!exit)
            {
                writeInfo.ClearDisplay();
                writeInfo.HeaderInfo($"Hello, {user.Login} !!!");
                input = readInfo.GetInfo("1) Add record; \n2) Delete record; \n3) Find record;" +
                    " \n4) Show information about all user`s records; \n5) Sort software by name; " +
                    " \n6) Save changes; \n7) Exit;");
                writeInfo.ClearDisplay();

                if (!int.TryParse(input, out inputVar))
                {
                    throw new InvalidInputFormatException();
                }

                switch (inputVar)
                {
                    case 1:
                        {
                            software = helper.GetSoftware();
                            dataManager.AddSoftware(software);
                            break;
                        }
                    case 2:
                        {
                            nameSoftware = readInfo.GetInfo("Enter software name: ");
                            dataManager.DeleteSoftware(nameSoftware);
                            break;
                        }
                    case 3:
                        {
                            input = readInfo.GetInfo("1) Find by name; \n2) Find by type; \n3) Exit;");
                            writeInfo.ClearDisplay();

                            if (!int.TryParse(input, out inputVar))
                            {
                                throw new InvalidInputFormatException();
                            }

                            switch (inputVar)
                            {
                                case 1:
                                    {
                                        string softName;
                                        softName = readInfo.GetInfo("Enter software name: ");
                                        foreach (var item in dataManager.FindSoftwaresByName(softName))
                                        {
                                            writeInfo.Info(item.ToString());
                                        }
                                        break;
                                    }
                                case 2:
                                    {
                                        string softType;
                                        softType = readInfo.GetInfo("Enter software type: ");
                                        foreach (var item in dataManager.FindSoftwaresByType(softType))
                                        {
                                            writeInfo.Info(item.ToString());
                                        }
                                        
                                        break;
                                    }
                                case 3:
                                    {
                                        writeInfo.Info("Bye-Bye!!!");
                                        break;
                                    }
                                default:
                                    {
                                        throw new OperationNotFoundException();
                                    }
                            }
                            break;
                        }
                    case 4:
                        {
                            var collections = dataManager.GetSoftwares();

                            if (collections == null)
                            {
                                writeInfo.Info("Software list is empty!!!");
                                break;
                            }

                            foreach (var item in collections)
                            {
                                writeInfo.Info(item.ToString());
                            }
                            break;
                        }
                    case 5:
                        {
                            var collections = dataManager.GetSoftwares();

                            if (collections == null)
                            {
                                writeInfo.Info("Software list is empty!!!");
                                break;
                            }

                            foreach (var item in dataManager.SortSoftwares())
                            {
                                writeInfo.Info(item.ToString());
                            }
                            
                            break;
                        }
                    case 6:
                        {
                            if (!connectorDB.SaveChanges(user))
                            {
                                throw new SaveDataException();
                            }

                            writeInfo.Info("Data saved successfully");

                            break;
                        }
                    case 7:
                        {
                            writeInfo.Info("Bye-Bye!!!");

                            exit = true;
                            break;
                        }
                    default:
                        {
                            throw new OperationNotFoundException();
                        }
                }

                readInfo.GetInfo("");
            }
        }
    }
}
