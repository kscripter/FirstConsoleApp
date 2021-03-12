using System;
using System.Collections.Generic;
using System.Text;

namespace AccountManangementSystemFile
{
   public class OverDraft
   {
       public int Id{get; set;}
       public int AccountHolderId{get; set;}
       public double Amount{get; set;}
       public double AmountLeft{get; set;}
       public string Status{get; set;}
       public string OverdraftDate{get; set;}


        public OverDraft(int id, AccountHolder accountHolder, double amount, string status = "active")
        {
            Id = id;
            AccountHolderId = accountHolder.Id;
            Amount = amount;
            OverdraftDate = DateTime.Now.ToString("yyyy/MM/dd");
            Status = status;
            AmountLeft = amount - accountHolder.AccountBalance;
        }

        public OverDraft (int id, int accountHolderId, double amount, string overdraftDate, string status, double amountLeft)
        {
            Id = Id;
            AccountHolderId = accountHolderId;
            Amount = amount;
            OverdraftDate = overdraftDate;
            Status = status;
            AmountLeft = amountLeft;

        }

        public static string ConvertToString(OverDraft overDraft){
            return $"{overDraft.Id}\t{overDraft.AccountHolderId}\t{overDraft.Amount}\t{overDraft.OverdraftDate}\t{overDraft.Status}\t{overDraft.AmountLeft}";
        }

        public static OverDraft TextSplitter(string overdraftText){


            var splitted = overdraftText.Split("\t");
            int id = Int32.Parse(splitted[0]);
            int accountHolderId = Int32.Parse(splitted[1]);
            double overdraftAmount = double.Parse(splitted[2]);
            double amountLeft = double.Parse(splitted[5]);

            return new OverDraft(id, accountHolderId, overdraftAmount, splitted[3], splitted[4], amountLeft);
        }

       
    }
}
