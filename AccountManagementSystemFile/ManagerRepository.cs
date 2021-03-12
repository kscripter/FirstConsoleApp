using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;

namespace AccountManangementSystemFile
{
    public class ManagerRepository
    {
        public static List<Manager> Managers;
        public static Manager LoggedInManager;
        public static string ManagerFilePath = "Managers.txt";

        public ManagerRepository()
        {
            Managers = new List<Manager>();
             try
            {
                if (!File.Exists(ManagerFilePath))
                {

                }
                else
                {
                    var lines = File.ReadAllLines(ManagerFilePath);
                    foreach (var line in lines)
                    {
                        var manager = Manager.TextSplitter(line);
                        Managers.Add(manager);
                    }
                }
            }
            catch (IOException ex)
            {
                throw new Exception(ex.Message);
            }
        }


        private static void RefreshFile()
        {
            TextWriter textWriter = new StreamWriter(ManagerFilePath);

            foreach (Manager manager in Managers)
            {
                textWriter.WriteLine(Manager.ConvertToString(manager));
            }
            textWriter.Flush();
            textWriter.Close();
        }


        public void Read(Manager manager)
        {
            Console.WriteLine($"{manager.Id}, {manager.FirstName}, {manager.LastName}, {manager.MiddleName}, {manager.Email}, {manager.Password}");
        }

        public static bool IsEmpty<T>(List<T> list)
        {
            if (list == null)
            {
                return true;
            }

            return !list.Any();
        }

        public void List()
        {
            bool isEmpty = IsEmpty(Managers);

            if (isEmpty)
            {
                throw new Exception("No records found!");
            }

            foreach (Manager manager in Managers)
            {
                Read(manager);
            }
        }
        public void CreateManager(int id, string firstName, string lastName, string middleName, string email, string password, string confirmPassword)
        {
            Manager manager = new Manager(id, firstName, lastName, middleName, email, password);

            try
            {
                if (password == confirmPassword)
                {
                    var accountHolders = FindByIdOrEmail(id, email);

                    if (accountHolders == null)
                    {
                        Managers.Add(manager);
                        RefreshFile();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(" Manager's Account Created Succesfully!");
                        Menu.ShowContinueMenu();
                    }
                    else
                    {
                        throw new Exception($"Manager with this id {id} or email {email} already exists.");
                    }
                }
                else
                {
                  throw new Exception("Password did not match... Registration Failed");
                }
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Menu.ShowContinueMenu();
            }
        }

        public Manager FindByIdOrEmail(int id, string email)
        {
            return Managers.Find(i => i.Id == id || i.Email == email);
        }

        public static Manager FindByEmail(string email)
        {
            return Managers.Find(i => i.Email == email);
        }

        public int LoginAccountManager(string userEmail)
        {

            try
            {
                bool isRightPassword = false;

                int tries = 3;

                string userPassword = string.Empty;

                bool recordIsEmpty = IsEmpty(Managers);

                if (!recordIsEmpty)
                {
                    Manager manager = FindByEmail(userEmail);

                    if (manager == null)
                    {
                        throw new Exception("Email not found!");
                    }
                    else
                    {
                        do
                        {
                            Console.Write("Enter your password: ");
                            userPassword = Console.ReadLine();

                            if (userPassword.Equals(manager.Password))
                            {
                                
                                isRightPassword = true;
                                LoggedInManager = manager;
                                // Console.WriteLine($"Welcome Manager {manager.FirstName}");
                                return manager.Id;  
                            }
                            else
                            {
                                if (tries > 1)
                                {
                                    Console.WriteLine($"Invalid Password. You have {--tries} tries left");
                                }
                                else
                                {
                                    Console.WriteLine("Account Locked. Contact Admin");
                                    return 0;
                                }
                            }
                            return 0;
                        } while (!isRightPassword);
                    }

                }
                else
                {
                    throw new Exception("No records found!");
                }
            }
            catch (Exception em)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(em.Message);
                Menu.ShowContinueMenu();
                return 0;
            }
        }


        public static void LogOutAccountManager()
        {
            LoggedInManager = null;
        }

    }
}

