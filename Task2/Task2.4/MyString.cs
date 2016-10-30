using System;

namespace Task2._4
{
    class MyString
    {
        private char[] massiveChars;

        public MyString(int length)
        {
            this.massiveChars = new char[length];
        }
        public MyString(string line)
        {
            this.massiveChars = line.ToCharArray();
        }
        public MyString(char[] myArray)
        {
            this.massiveChars = myArray;
        }
        public int Length => this.massiveChars.Length;
        
        public char this[int index]
        {
            get
            {
                return this.massiveChars[index];
            }
            set
            {
                this.massiveChars[index] = value;
            }
        }

        public static explicit operator char[](MyString myString)
        {
            return myString.massiveChars;
        }

        public static explicit operator MyString(char[] myArray)
        {
            return new MyString(myArray);
        }

        public static MyString operator +(MyString string1, MyString string2)
        {
            char[] answer = new char[string1.Length + string2.Length];
            Array.Copy(string1.massiveChars, answer, string1.Length);
            Array.Copy(string2.massiveChars, 0, answer, string1.Length, string2.Length);
            return (MyString)answer; ;
        }

        public static bool operator <(MyString string1, MyString string2)
        {
            return Compare(string1, string2) < 0;
        }
        public static bool operator >(MyString string1, MyString string2)
        {
            return Compare(string1, string2) > 0;
        }

        public static int Compare(MyString string1, MyString string2)
        {
            if (string1 == null)
            {
                return -1;
            }
            if (string2 == null)
            {
                return 1;
            }
            if (string1.Length < string2.Length)
            {
                return -1;
            }
            if (string1.Length > string2.Length)
            {
                return 1;
            }
            int minLength = Math.Min(string1.Length, string2.Length);

            for (int i = 0; i < minLength; i++)
            {
                if (string1.massiveChars[i] < string2.massiveChars[i])
                {
                    return -1;
                }
                else if (string1.massiveChars[i] > string2.massiveChars[i])
                {
                    return 1;
                }
                else continue;
            }
            return 0;
        }

        public override string ToString()
        {
            return new string(this.massiveChars);
        }

        public static bool Equals(MyString string1, MyString string2)
        {
            if (string1.Length == string2.Length)
            {
                for (int i = 0; i < string1.Length; i++)
                {
                    if (string1[i] != string2[i])
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        public int IndexOf(char letter)
        {
            return Array.IndexOf(this.massiveChars, letter);
        }
    }
}
