using System;
using System.Collections.Generic;
using System.Text;

namespace AccountManangementSystemFile
{
    public class Auth
    {
        static AccountHolderRepository accountHolder;
        // static ManagerRepository accountManager = new ManagerRepository();
        public static bool isHolderLoggedIn = false;
        public static bool isManagerLoggedIn = false;

        public Auth()
        {
            accountHolder = new AccountHolderRepository();
        }
        public static void RegisterAccountHolder()
        {
            accountHolder = new AccountHolderRepository();
            Random random = new Random();
            Console.Clear();
            Console.WriteLine("     ACCOUNT HOLDER REGISTRATION");
            Console.Write("Enter your ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter your First Name: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter your Middle Name: ");
            string middleName = Console.ReadLine();

            Console.Write("Enter your Last Name: ");
            string lastName = Console.ReadLine();

            Console.Write("Enter your Date Of Birth (yyyy/mm/dd): ");
            DateTime dateOfBirth = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Enter your Email Address: ");
            string email = Console.ReadLine();

            Console.Write("Enter your Phone Number: ");
            string phoneNumber = Console.ReadLine();

            Console.Write("Enter your Address: ");
            string address = Console.ReadLine();

            Console.Write("Enter your Password: ");
            string password = Console.ReadLine();

            Console.Write("Confirm your Password:  ");
            string confirmPassword = Console.ReadLine();

            string firstFive = random.Next(1, 10000).ToString("00000");
            string secondFive = random.Next(1, 10000).ToString("00000");
            string accountNumber = firstFive + secondFive;

            accountHolder.CreateAccountHolder(id, firstName, middleName, lastName, dateOfBirth, email, phoneNumber, address, password, confirmPassword, accountNumber);
        }


        public static bool LoginAccountHolder()
        {
            accountHolder = new AccountHolderRepository();
            if (isHolderLoggedIn == true)
            {
                return isHolderLoggedIn;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("    ACCOUNT HOLDER LOGIN");
                Console.Write("Enter your email: ");
                string email = Console.ReadLine();

                int userId = AccountHolderRepository.LoginAccountHolder(email);
                isHolderLoggedIn = (userId != 0);

                return isHolderLoggedIn;
            }


        }

        public static void LogOutAccountHolder()
        {
            isHolderLoggedIn = false;
            AccountHolderRepository.LogOutAccountHolder();
        }



        //FOR ACCOUNT MANAGERS

        public static void CreateAccountManager()
        {
            ManagerRepository accountManager = new ManagerRepository();

            Console.Clear();
            Console.WriteLine("     ACCOUNT MANAGER REGISTRATION");
            Console.Write("Enter your Id: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter your First Name: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter your Middle Name: ");
            string middleName = Console.ReadLine();

            Console.Write("Enter your Last Name: ");
            string lastName = Console.ReadLine();

            Console.Write("Enter your Email: ");
            string email = Console.ReadLine();

            Console.Write("Enter your Password: ");
            string password = Console.ReadLine();

            Console.Write("Confirm Your Password: ");
            string checkPassword = Console.ReadLine();

            accountManager.CreateManager(id, firstName, middleName, lastName, email, password, checkPassword);
        }

        public static bool LoginAccountManager()
        {

            ManagerRepository accountManager = new ManagerRepository();

            if (isManagerLoggedIn)
            {
                return true;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("     ACCOUNT MANAGER LOGIN");
                Console.Write("Enter your email: ");
                string email = Console.ReadLine();
                int id = accountManager.LoginAccountManager(email);

                isManagerLoggedIn = (id != 0);

                return isManagerLoggedIn;
            }


        }

        public static void LogoutAccountManager()
        {
            ManagerRepository.LogOutAccountManager();
            isManagerLoggedIn = false;
        }



    }
}
