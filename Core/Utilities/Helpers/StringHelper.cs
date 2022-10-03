using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers
{
    public static class StringHelper
    {
        public static string TitleToSlug(string title)
        {
            return title.ToLower().Replace(" ", "_");
        }

        public static bool IsLike(string s1, string s2)
        {
            if (s1 == null || s2 == null)
                return false;
            return s1.ToLower().Contains(s2.ToLower());
        }
    }
}
