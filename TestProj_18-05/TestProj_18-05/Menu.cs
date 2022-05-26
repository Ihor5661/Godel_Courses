using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProj_18_05
{
    /// Todo // Refactor


    //static class Menu
    //{
    //    private static string _login;

    //    public static void StartMenu()
    //    {
    //        int inputVar;
    //        string input;
    //        Console.WriteLine("1) Sign in; \n2) Sign up; \n3) Exit;");
    //        input = Console.ReadLine();
    //        int.TryParse(input, out inputVar);
    //        Console.Clear();

    //        switch (inputVar)
    //        {
    //            case 1:
    //                {
    //                    //SignIn();
    //                    string login, password;
    //                    Console.WriteLine(new string('=', 20) + " Sign in " + new string('=', 20));
    //                    Console.Write("Enter login: ");
    //                    login = Console.ReadLine();
    //                    Console.Write("Enter password: ");
    //                    password = Console.ReadLine();

    //                    break;
    //                }
    //            case 2:
    //                {
    //                    SignUp();
    //                    break;
    //                }
    //            case 3:
    //                {
    //                    Console.WriteLine("Bye-Bye!!!");
    //                    break;
    //                }
    //            default:
    //                {
    //                    Console.WriteLine("Operation not found!!!");
    //                    break;
    //                }
    //        }
    //    }

    //    public static void SignIn()
    //    {
    //        string login ="", password="";

    //        //if (CheckLoginExist(login) && CheckUserPassword(login, password))
    //        //{
    //        //    _login = login;
    //        //    MainMenu();
    //        //}
    //        //else
    //        //{
    //        //    Console.WriteLine("Login or password was entered incorrectly!!!");
    //        //    Console.ReadLine();
    //        //    Console.Clear();
    //        //    SignIn();
    //        //}
    //    }

    //    private static bool CheckUserPassword(string login, string password)
    //    {
    //        return true;
    //    }

    //    public static void SignUp()
    //    {
    //        string login, password, passwordRep;
    //        Console.WriteLine(new string('=', 20) + " Sign up " + new string('=', 20));
    //        Console.WriteLine("Enter login: ");
    //        login = Console.ReadLine();
    //        Console.WriteLine("Enter password: ");
    //        password = Console.ReadLine();
    //        Console.WriteLine("Repeat password: ");
    //        passwordRep = Console.ReadLine();
    //    }

    //    private static void MainMenu()
    //    {
    //        int inputVar;
    //        string input;
    //        Console.WriteLine(new string('=', 20) + " Hello, " + _login + "!!! " + new string('=', 20));
    //        Console.WriteLine("1) Add record; \n2) Find record; \n 3) Show information about all records; \n4) Exit;");
    //        input = Console.ReadLine();
    //        int.TryParse(input, out inputVar);
    //        Console.Clear();

    //        switch (inputVar)
    //        {
    //            case 1:
    //                {
    //                    AddRecord();
    //                    break;
    //                }
    //            case 2:
    //                {
    //                    FindRecord();
    //                    break;
    //                }
    //            case 3:
    //                {
    //                    ShowInformationAboutAllRecords();
    //                    break;
    //                }
    //            case 4:
    //                {
    //                    Console.WriteLine("Bye-Bye!!!");
    //                    break;
    //                }
    //            default:
    //                {
    //                    Console.WriteLine("Operation not found!!!");
    //                    break;
    //                }
    //        }
    //    }

    //    private static void AddRecord()
    //    {
    //        int inputVar;
    //        string input;
    //        Console.WriteLine(new string('=', 50));
    //        Console.WriteLine("Enter type Software.");
    //        Console.WriteLine("1) Free software; \n2) Shareware software; \n3) Proprietary software; \n4) Go back; \n5) Exit;");
    //        input = Console.ReadLine();
    //        int.TryParse(input, out inputVar);
    //        Console.Clear();
    //        switch (inputVar)
    //        {
    //            case 1:
    //                {
    //                    break;
    //                }
    //            case 2:
    //                {
    //                    break;
    //                }
    //            case 3:
    //                {
    //                    break;
    //                }
    //            case 4:
    //                {
    //                    MainMenu();
    //                    break;
    //                }
    //            case 5:
    //                {
    //                    Console.WriteLine("Bye-Bye!!!");
    //                    break;
    //                }
    //            default:
    //                {
    //                    Console.WriteLine("Operation not found!!!");
    //                    break;
    //                }
    //        }
    //    }

    //    private static void FindRecord()
    //    {
    //        int inputVar;
    //        string input;
    //        Console.WriteLine(new string('=', 50));
    //        Console.WriteLine("Enter search parameter.");
    //        Console.WriteLine("1) Type software; \n2) Name software; \n3) Go back; \n4) Exit;");
    //        input = Console.ReadLine();
    //        int.TryParse(input, out inputVar);
    //        Console.Clear();
    //        switch (inputVar)
    //        {
    //            case 1:
    //                {
    //                    break;
    //                }
    //            case 2:
    //                {
    //                    break;
    //                }
    //            case 3:
    //                {
    //                    MainMenu();
    //                    break;
    //                }
    //            case 4:
    //                {
    //                    Console.WriteLine("Bye-Bye!!!");
    //                    break;
    //                }
    //            default:
    //                {
    //                    Console.WriteLine("Operation not found!!!");
    //                    break;
    //                }
    //        }
    //    }

    //    private static void ShowInformationAboutAllRecords()
    //    {
            
    //    }
       
    //}
}
