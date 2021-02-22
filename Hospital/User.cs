using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    class User
    {
        public User() { }
        public User(string name, string surname, string email, string phone)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Phone = phone;
        }

        private string _name;
        public string Name 
        {
            get { return _name; }
            set
            {
                if (!value.Equals(string.Empty))
                    _name = value;
                else throw new ArgumentNullException("User name can't be NULL !");
            }
        }
        private string _surname;
        public string Surname
        {
            get { return _surname; }
            set
            {
                if (!value.Equals(string.Empty))
                    _surname = value;
                else throw new ArgumentNullException("User surname can't be NULL !");
            }
        }
        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                if (!value.Equals(string.Empty))
                    _email = value;
                else throw new ArgumentNullException("User email can't be NULL !");
            }
        }
        private string _phone;
        public string Phone
        {
            get { return _phone; }
            set
            {
                if (!value.Equals(string.Empty))
                    _phone = value;
                else throw new ArgumentNullException("User phone can't be NULL !");
            }
        }
    }
}
