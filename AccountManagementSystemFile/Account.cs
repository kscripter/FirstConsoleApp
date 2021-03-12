using System;
using System.Collections.Generic;
using System.Text;

namespace AccountManangementSystemFile
{
    public class Account
    {
        public string AccountNumber;
        public int  Id;
        public string Pin;
        public AccountHolder AccountHolder;
        public string AccountType;
        public DateTime DateOfCreation;
        public double AccountBalance;


        public Account(string accountNumber, int id, string pin, string accountType, DateTime dateOfCreation, double accountBalance)
        {
            this.AccountNumber = accountNumber;
            this.Id = id;
            this.Pin = pin;
            this.AccountType = accountType;
            this.DateOfCreation = dateOfCreation;
            this.AccountBalance = accountBalance;
        }

       /* public string GetAccountNumber()
        {
            return AccountNumber;
        }
        public void SetAccountNumber(string accountNumber)
        {
            this.AccountNumber = accountNumber;
        }
        public int GetId()
        {
            return Id;
        }
        public void SetId(int id)
        {
            this.Id = id;
        }
        public string GetPin()
        {
            return Pin;
        }
        public void SetPin(string pin)
        {
            this.Pin  = pin;
        }
        public string GetAccountType()
        {
            return AccountType;
        }
        public void SetAccountType(string accountType)
        {
            this.AccountType = accountType;
        }
        public DateTime GetDateOfCreation()
        {
            return DateOfCreation;
        }
        public void SetDateOfCreation(DateTime dateOfCreation)
        {
            this.DateOfCreation = dateOfCreation;
        }
        public double GetAccountBalance()
        {
            return AccountBalance;
        }
        public void SetAccountBalance(double accountBalance)
        {
            this.AccountBalance = accountBalance;
        }*/
    }
    

   
}
