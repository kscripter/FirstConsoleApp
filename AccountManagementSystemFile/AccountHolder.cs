using System;
using System.Collections.Generic;
using System.Text;

namespace AccountManangementSystemFile
{
    public class AccountHolder : Details
    {
        public string DateOfBirth { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string AccountNumber { get; set; }

        public double AccountBalance { get; set; }

        public int AccountStatus { get; set; }

        public int Pin { get; set; }

        public string CreatedAt { get; set; }

        public AccountHolder(int id, string firstName, string lastName, string middleName, string email, string password, DateTime dateOfBirth, string phoneNumber, string address, string accountNumber, double accountBalance = 0.00, int accountStatus = 1, int pin = 0) : base(id, firstName, lastName, middleName, email, password)
        {
            DateOfBirth = dateOfBirth.ToShortDateString();

            PhoneNumber = phoneNumber;

            Address = address;

            AccountNumber = accountNumber;

            AccountBalance = accountBalance;

            AccountStatus = accountStatus;

            Pin = pin;

            CreatedAt = DateTime.Now.ToString("yyyy/MM/dd");;
        }

        public static string ConvertToString(AccountHolder accountHolder)
        {
            return $"{accountHolder.Id}\t{accountHolder.FirstName}\t{accountHolder.LastName}\t{accountHolder.MiddleName}\t{accountHolder.Email}\t{accountHolder.Password}\t{accountHolder.DateOfBirth}\t{accountHolder.PhoneNumber}\t {accountHolder.Address}\t{accountHolder.AccountNumber}\t{accountHolder.AccountBalance}\t {accountHolder.AccountStatus}\t{accountHolder.Pin}\t{accountHolder.CreatedAt}";
        }

        public static AccountHolder TextSplitter(string accountText)
        {
            var splitted = accountText.Split("\t");
            int id = Int32.Parse(splitted[0]);
            DateTime dateOfBirth = DateTime.Parse(splitted[6]);
            double accountBalance = Double.Parse(splitted[10]);
            int accountStatus = Int32.Parse(splitted[11]);
            int pin = Int32.Parse(splitted[12]);

            return new AccountHolder(id, splitted[1], splitted[2], splitted[3], splitted[4], splitted[5], dateOfBirth, splitted[7], splitted[8], splitted[9] , accountBalance, accountStatus,pin);
            
        }

        
    }

}
