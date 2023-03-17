using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

namespace StudentManagement.RegEX
{
    public class RegularExpression
    {
        public Regex Password = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");
        public Regex Email = new Regex("^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\\.[a-zA-Z0-9-.]+$");

        public bool isMatch(string input, Regex validation)
        {
            if (validation.IsMatch(input))
            {
                return true;
            }
            return false;
        }
    }
}