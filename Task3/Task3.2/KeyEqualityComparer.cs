using System;
using System.Collections.Generic;

namespace Task3._2
{
    public class KeyEqualityComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            return string.Compare(x, y, true) == 0;
        }

        public int GetHashCode(string obj)
        {
            return obj.Length;
        }
    }
}
