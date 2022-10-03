using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class StringExtensions
    {
        public static string ToSlug(this string text)
        {
            return text.ToLower()
                .Replace(" ", "_")
                .Replace("?", "")
                .Replace("#", "")
                .Replace("@", "")
                .Replace("&", "")
                .Replace("!","")
                .Replace(",","")
                .Replace("%","")
                .Replace("/","")
                .Replace("$","")
                ;
        }
    }
}
