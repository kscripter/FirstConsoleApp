using System;
using System.Collections.Generic;
using System.Text;

namespace AccountManangementSystemFile
{
    public class Manager : Details
    {
        public Manager(int id, string firstName, string lastName, string middleName, string email, string password) : base(id, firstName, lastName, middleName, email, password)
        {
        }

        public static string ConvertToString(Manager manager){
            return $"{manager.Id}\t{manager.FirstName}\t{manager.MiddleName}\t{manager.LastName}\t{manager.Email}\t{manager.Password}";
        }

        public static Manager TextSplitter(string loanText){
            var splitted = loanText.Split("\t");

            int id = Int32.Parse(splitted[0]);

            return new Manager(id, splitted[1], splitted[3], splitted[2], splitted[4], splitted[5]);
        }
    }
}
