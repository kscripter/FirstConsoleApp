using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManangementSystemFile         
{
    public abstract class Details
    {
        private int _id;
        private string _firstName;
        private string _lastName;
        private string _middleName;
        private string _email;
        private string _password;

        public Details(int id, string firstName, string lastName, string middleName, string email, string password)
        {
            _id = id;
            _firstName = firstName;
            _lastName = lastName;
            _middleName = middleName;
            _email = email;
            _password = password;
        }

        public int Id
        {
            get { return _id;  }
            set { _id = value; }
        }

        public string FirstName
        {
            get { return _firstName;  }
            set { _firstName = value;  }
        }
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string MiddleName
        {
            get { return _middleName; }
            set { _middleName = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
    }
}
