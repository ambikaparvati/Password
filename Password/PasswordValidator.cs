using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password
{
    public class PasswordValidator
    {
        public bool Verify(string password, string usertype)
        {
            if (usertype.Equals("Internal"))
            {
                InternalPassword _InternalPassword = new InternalPassword();
                return _InternalPassword.VerifyInternal(password);
            }
            else if (usertype.Equals("External"))
            {
                ExternalPassword _ExternalPassword = new ExternalPassword();
                return _ExternalPassword.VerifyExternal(password);
            }
            else throw (new Exception("Wrong usertype"));
        }
    }

    public class InternalPassword : PasswordValidator
    {
        public bool VerifyInternal(string password)
        {
            if (password.Length > 8) return true;
            else throw (new Exception("Password should be larger than 8 chars"));
        }
    }
    public class ExternalPassword : PasswordValidator
    {
        public int count = 0;
        public bool VerifyExternal(string str)
        {
            if (CheckLength(str) && CheckNull(str) && CheckUpperCase(str) && CheckLowerCase(str) && CheckNumber(str))
                return true;
            else if (count > 2)
                return true;
            else if (!CheckUpperCase(str))
                return false;
            else return false;
        }
        public bool CheckLength(string str)
        {
            if (str.Length > 8)
            {
                count = count + 1;
                return true;
            }
            else throw (new Exception("Password should be larger than 8 chars"));
        }
        public bool CheckNull(string str)
        {
            if (str != "")
            {
                count = count + 1;
                return true;
            }
            else throw (new Exception("Password should not be null"));
        }
        public bool CheckUpperCase(string str)
        {
            if (str.Any(char.IsUpper))
            {
                count = count + 1;
                return true;
            }
            else throw (new Exception("Password should have one uppercase letter at least"));
        }
        public bool CheckLowerCase(string str)
        {
            if (str.Any(char.IsLower))
            {
                count = count + 1;
                return true;
            }
            else throw (new Exception("Password should have one lowercase letter at least"));
        }
        public bool CheckNumber(string str)
        {
            if (str.Any(char.IsDigit))
            {
                count = count + 1;
                return true;
            }
            else throw (new Exception("Password should have one number at least"));
        }
    }
}
