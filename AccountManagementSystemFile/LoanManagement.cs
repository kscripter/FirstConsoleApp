using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AccountManangementSystemFile
{
    public class LoanManagement
    {
        public static List<Loan> Loans;

        public static string LoanFilePath = "Loan.txt";

        public LoanManagement()
        {
            Loans = new List<Loan>();

            try
            {
                if (!File.Exists(LoanFilePath))
                {

                }
                else
                {
                    var lines = File.ReadAllLines(LoanFilePath);
                    foreach (var line in lines)
                    {
                        var loan = Loan.TextSplitter(line);
                        Loans.Add(loan);
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
            TextWriter textWriter = new StreamWriter(LoanFilePath);

            foreach (Loan loan in Loans)
            {
                textWriter.WriteLine(Loan.ConvertToString(loan));
            }
            textWriter.Flush();
            textWriter.Close();
        }


        public void ListLoans()
        {
            foreach (Loan loan in Loans)
            {
                Console.WriteLine($"{loan.AccountHolderId} - {loan.Status} - {loan.Amount} - {loan.DateOfLoan} - {loan.LoanType}");
            }
        }

        public void AddLoan(int accountHolderId, double amount, string loanType)
        {

            int id = Loans.Count() + 1;

            List<Loan> allLoans = FindMultipleLoanByAccountHolderId(accountHolderId);

            try
            {
                if (allLoans == null)
                {
                    //Can get Loan
                    Loan newLoan = new Loan(id, accountHolderId, loanType, amount);
                    Loans.Add(newLoan);
                    RefreshFile();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Congratualtions! You have recieve a loan of {amount}");
                    Menu.ShowContinueMenu();
                }

                else
                {
                    Loan activeLoan = FindActiveLoan(allLoans);

                    if (activeLoan == null)
                    {
                        // Can Get loan
                        Loan newLoan = new Loan(id, accountHolderId, loanType, amount);
                        Loans.Add(newLoan);
                        RefreshFile();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Congratualtions! You have recieve a loan of {amount}");
                        Menu.ShowContinueMenu();
                    }
                    else
                    {
                        //Cannot Get loan;
                        throw new Exception($"You already have an unpaid loan of {activeLoan.AmountLeft}. Pay up to qualify for another ):");
                    }
                }
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: {e.Message}");
                Menu.ShowContinueMenu();
            }

        }


        public Loan FindLoanByAccountHolderId(int id)
        {
            return Loans.Find(i => i.AccountHolderId == id);
        }
        public List<Loan> FindMultipleLoanByAccountHolderId(int id)
        {

            List<Loan> allLoans = Loans.Where(e => e.AccountHolderId == id).ToList();

            return allLoans;
        }

        public Loan FindActiveLoan(List<Loan> multipleLoan)
        {

            Loan activeLoan = multipleLoan.Find(i => i.Status == "active");

            return activeLoan;
        }
        public Loan FindActiveLoan(int accountHolderId)
        {

            List<Loan> allLoans = FindMultipleLoanByAccountHolderId(accountHolderId);
            Loan activeLoan = FindActiveLoan(allLoans);
            return activeLoan;
        }

        public int CountLoan(List<Loan> multipleLoan)
        {
            return multipleLoan.Count();
        }


        public bool checkLoanBalance(int accountHolderId, bool printStatus = true)
        {
            List<Loan> allLoans = FindMultipleLoanByAccountHolderId(accountHolderId);
            string noLoan = "You do not have an active loan at the moment.";

            if (allLoans == null)
            {
                Console.WriteLine(noLoan);
                return false;
            }

            else
            {
                Loan activeLoan = FindActiveLoan(allLoans);

                if (activeLoan == null)
                {
                    Console.WriteLine(noLoan);
                    return false;
                }
                else
                {
                    if (printStatus)
                    {
                        Console.WriteLine($"You currently have unpaid loan of {activeLoan.AmountLeft}");
                    }
                    return true;

                }
            }
        }

        public void payBackLoan(int accountHolderId, double amountToPay)
        {
            Loan activeLoan = FindActiveLoan(accountHolderId);

            try
            {
                if (amountToPay > activeLoan.AmountLeft)
                {
                    throw new Exception($"Entered amount is more than amount left to pay for loan. Please Enter amount within the range of your loan. Your  loan balance is {activeLoan.AmountLeft} ");
                }
                else
                {
                    activeLoan.AmountLeft -= amountToPay;

                    if (activeLoan.AmountLeft == 0)
                    {
                        activeLoan.Status = "inactive";
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("You have successfully paid back all your loan and you do not have any active loan left");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"You have successfully paid {amountToPay} and you have {activeLoan.AmountLeft} left to pay");

                    }

                    RefreshFile();
                }
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: {e.Message}");
            }


        }

    }
}