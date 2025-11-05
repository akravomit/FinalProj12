using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Customer
    {
        public Customer() { }
        public Customer(int iD, string name, bool isAdmin)
        {
            _ID = iD;
            _Name = name;
            _IsAdmin = isAdmin;
        }
        public int _ID { get; set; }
        public string _Name { get; set; }
        public bool _IsAdmin { get; set; }
        public override string ToString()
        {
            string ret = string.Empty;
            ret += $"CUSTOMER DATA FOR CUSTOMER NUMBER: {_ID}";
            ret += $"CUSTOMER NAME: {_Name} | IS CUSTOMER ADMIN: {_IsAdmin.ToString().ToUpper()}";
            return ret;
        }
    }
}
