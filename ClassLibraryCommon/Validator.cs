using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClassLibraryCommon
{
    public class Validator
    {


        public bool IsValidEmail(string inEmail)
        {
            // regular expressions
            string _pattern = @"([-!#-'*+/-9=?A-Z^-~]+(\.[-!#-'*+/-9=?A-Z^-~]+)*|([]!#-[^-~ \t]|(\\[\t -~]))+)@[0-9A-Za-z]([0-9A-Za-z-]{0,61}[0-9A-Za-z])?(\.[0-9A-Za-z]([0-9A-Za-z-]{0,61}[0-9A-Za-z])?)+";
            Regex r = new Regex(_pattern, RegexOptions.IgnoreCase);
            var _m =  r.Match(inEmail);
            return _m.Success;

        }


        // TODO - finish
        public bool IsValidUSPhoneWithAreaCode(string inPhone)
        {

            bool _isValid = false;
            // 573-228-8059

            // (573)228-8059

            // 5732288059

            // (573)2288059
            return _isValid;  
        }
    }


}
