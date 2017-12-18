using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public static class StringExtensions
    {
        public static string Before(this string value, string needle)
        {
            var result = string.Empty;
            if (value.Contains(needle))
            {
                string[] splitted = value.Split(new string[] { needle }, StringSplitOptions.None);
                result = splitted[0];
            }
            else
            {
                result = "";
            }
            return result;
        }
    }
}