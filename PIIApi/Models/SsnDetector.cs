using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace PIIApi.Models
{
    public class SsnDetector
    {
        public bool FindSocialSecurityNumber(string text)
        {
            Regex ssnRegex = new Regex(@"(\d{3}-?\d{2}-?\d{4})");
            Match match = ssnRegex.Match(text);
            
            if (match.Success)
            {
                return true;
            }
            return false;
        }
    }
}
