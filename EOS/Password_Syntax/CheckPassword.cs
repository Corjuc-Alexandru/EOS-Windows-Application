using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOS.Password_Syntax
{
    internal class CheckPassword
    {
        public static bool ValidatePassword(string passwordsign)
        {
            int validConditions = 0;
            foreach (char c in passwordsign)
            {
                if (c >= 'a' && c <= 'z')
                {
                    validConditions++;
                    break;
                }
            }
            foreach (char c in passwordsign)
            {
                if (c >= 'A' && c <= 'Z')
                {
                    validConditions++;
                    break;
                }
            }
            if (validConditions == 0)
            {
                return false;
            }
            foreach (char c in passwordsign)
            {
                if (c >= '0' && c <= '9')
                {
                    validConditions++;
                    break;
                }
            }
            if (validConditions == 1)
            {
                return false;
            }
            if (validConditions == 2)
            {
                char[] special = { '@', '#', '$', '%', '^', '&', '+', '=' };
                // or whatever    
                if (passwordsign.IndexOfAny(special) == -1)
                {
                    return false;
                }
            }
            return true;
        }

    }
}
