using System;
using System.Collections.Generic;
using System.Text;

namespace AccountManangementSystemFile
{
   public class Loan
    {
        public int Id {get; set;}
        public int AccountHolderId {get; set;}
        public string Status {get; set;}
        public string LoanType {get; set;}
        public string DateOfLoan {get; set;}
        public double Amount {get; set;}
        public double AmountLeft {get; set;}

        public Loan(int id, int accountHolderId, string loanType, double amount, string status="active")
        {
            Id = id;
            AccountHolderId = accountHolderId;
            Status = status;
            LoanType = loanType;
            DateOfLoan = DateTime.Now.ToString("yyyy/MM/dd");
            Amount = amount;
            AmountLeft = amount;
        }
        public Loan(int id, int accountHolderId, string loanType, double amount, string dateOfLoan, double amountLeft, string status)
        {
            Id = id;
            AccountHolderId = accountHolderId;
            Status = status;
            LoanType = loanType;
            DateOfLoan = dateOfLoan; 
            Amount = amount;
            AmountLeft = amountLeft;
        }

        public static string ConvertToString(Loan loan){
            return $"{loan.Id}\t{loan.AccountHolderId}\t{loan.LoanType}\t{loan.Amount}\t{loan.DateOfLoan}\t{loan.AmountLeft}\t{loan.Status}";
        }

        public static Loan TextSplitter(string loanText){
            var splitted = loanText.Split("\t");

            int id = Int32.Parse(splitted[0]);
            int accountHolderId = Int32.Parse(splitted[1]);
            double amount = double.Parse(splitted[3]);
            double amountLeft = double.Parse(splitted[5]);


            return new Loan(id, accountHolderId, splitted[2], amount, splitted[4], amountLeft, splitted[6]);
        }

        
    }
}
