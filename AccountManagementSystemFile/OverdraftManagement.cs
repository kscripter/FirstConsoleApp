using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AccountManangementSystemFile
{
    public class OverdraftManagement
    {
        public static List<OverDraft> Overdrafts;
        private static string OverdraftsFilePath = "overdrafts.txt";

        public OverdraftManagement()
        {
            Overdrafts = new List<OverDraft>();

            try
            {
                if (!File.Exists(OverdraftsFilePath))
                {

                }
                else
                {
                    var lines = File.ReadAllLines(OverdraftsFilePath);
                    foreach (var line in lines)
                    {
                        var overdrafts = OverDraft.TextSplitter(line);
                        Overdrafts.Add(overdrafts);
                    }
                }
            }
            catch (IOException ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void ListOverdrafts()
        {
            foreach (OverDraft overdraft in Overdrafts)
            {
                Console.WriteLine($"{overdraft.AccountHolderId} - {overdraft.Status} - {overdraft.Amount} - {overdraft.OverdraftDate}");
            }
        }


        public OverDraft FindOverdraftByAccountHolderId(int id)
        {
            return Overdrafts.Find(i => i.AccountHolderId == id);
        }
        public List<OverDraft> FindMultipleOverdraftByAccountHolderId(int id)
        {

            List<OverDraft> allOverdrafts = Overdrafts.Where(e => e.AccountHolderId == id).ToList();

            return allOverdrafts;
        }

        public OverDraft FindActiveOverdraft(List<OverDraft> multipleOverdraft)
        {

            OverDraft activeOverdraft = multipleOverdraft.Find(i => i.Status == "active");

            return activeOverdraft;
        }
        public OverDraft FindActiveOverdraft(int accountHolderId)
        {

            List<OverDraft> allOverdraft = FindMultipleOverdraftByAccountHolderId(accountHolderId);
            OverDraft activeOverdraft = FindActiveOverdraft(allOverdraft);
            return activeOverdraft;
        }

        public bool checkOverdraftBalance(int accountHolderId, bool printStatus = true)
        {
            List<OverDraft> allOverdrafts = FindMultipleOverdraftByAccountHolderId(accountHolderId);

            if (allOverdrafts == null)
            {
                return false;
            }

            else
            {
                OverDraft activeOverdraft = FindActiveOverdraft(allOverdrafts);

                if (activeOverdraft == null)
                {
                    return false;
                }
                else
                {
                    if (printStatus)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"You currently have unpaid overdraft of of {activeOverdraft.AmountLeft}");
                    }
                    return true;

                }
            }
        }

        public void GetOverdraft(AccountHolder account, double amount)
        {
            int id = Overdrafts.Count() + 1;
            OverDraft newOverdraft = new OverDraft(id, account, amount);
            Overdrafts.Add(newOverdraft);
            RefreshFile();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"You have successfully gotten an overdraft of {amount}");
        }

        public void PayOverdraft(AccountHolder account, double amount)
        {

            // account.AccountBalance+=amount;
            OverDraft activeOverdraft = FindActiveOverdraft(account.Id);

            if (activeOverdraft != null)
            {
                activeOverdraft.AmountLeft -= amount;
                
                

                if (activeOverdraft.AmountLeft <= 0)
                {
                    activeOverdraft.AmountLeft = 0;
                    activeOverdraft.Status = "inactive";
                    
                }

                RefreshFile();
            }

        }

        private static void RefreshFile()
        {
            TextWriter textWriter = new StreamWriter(OverdraftsFilePath);

            foreach (OverDraft overDraft in Overdrafts)
            {
                textWriter.WriteLine(OverDraft.ConvertToString(overDraft));
            }
            textWriter.Flush();
            textWriter.Close();
        }

        // private void RefreshList(){
        //     OverDraft overdraftToRefresh = FindActiveOverdraft(AccountHolderRepository.LoggedInAccount.Id);
        //     Overdrafts[Overdrafts.FindIndex(overdraft => overdraft.Equals(overdraftToRefresh))] = A;
        // }







    }
}