using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandardAlgorithmsLibrary.ExtensionClasses
{
    public static class StringExtensions
    {
        /// <summary>
        /// Вовзращает строку в обратном порядке.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Inverse(this string str)
        {
            char[] charArray = str.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
