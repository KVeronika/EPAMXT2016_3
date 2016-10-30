using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4._5
{
    internal static class StringHelper
    {
        public static bool IsPositiveInt(this string line)
        {
            string state = "00";

            for (int i = 0; i < line.Length; i++)
            {
                switch (state)
                {
                    case "00":
                        {
                            if (line[i] >= '1' && line[i] <= '9')
                            {
                                state = "01";
                                break;
                            }

                            if (line[i] == '+')
                            {
                                state = "02";
                                break;
                            }

                            return false;
                        }
                    case "01":
                        {
                            if (line[i] >= '0' && line[i] <= '9')
                            {
                                state = "10";
                                break;
                            }

                            if (line[i] == '.' || line[i] ==',')
                            {
                                state = "20";
                                break;
                            }

                            return false;
                        }
                    case "02":
                        {
                            if (line[i] >= '1' && line[i] <= '9')
                            {
                                state = "01";
                                break;
                            }

                            return false;
                        }
                    case "10":
                        {
                            if (line[i] >= '0' && line[i] <= '9')
                            {
                                break;
                            }

                            return false;
                        }
                    case "20":
                        {
                            if (line[i] >= '0' && line[i] <= '9')
                            {
                                state = "21";
                                break;
                            }

                            return false;
                        }
                    case "21":
                        {
                            if (line[i] >= '0' && line[i] <= '9')
                            {
                                break;
                            }

                            if (line[i] == 'e' || line[i] == 'E')
                            {
                                if (++i >= line.Length)
                                {
                                    return false;
                                }

                                state = "22";
                                break;
                            }

                            return false;
                        }
                    case "22":
                        {
                            if (line[i] >= '1' && line[i] <= '9')
                            {
                                state = "23";
                                break;
                            }

                            if (line[i] == '+')
                            {
                                if (++i >= line.Length)
                                {
                                    return false;
                                }
                                state = "24";
                                break;
                            }

                            return false;
                        }
                    case "23":
                        {
                            if (line[i] >= '0' && line[i] <= '9')
                            {
                                break;
                            }

                            return false;
                        }
                    case "24":
                        {
                            if (line[i] >= '1' && line[i] <= '9')
                            {
                                state = "23";
                                break;
                            }

                            return false;
                        }
                }
            }

            if (state == "22" || state == "23")
            {
                return IsRightPow(line);
            }
            return true;
        }

        private static bool IsRightPow(string line)
        {
            char[] arr = line.ToCharArray();
            int indexOfDot = Array.IndexOf(arr, '.');
            if (indexOfDot == 0)
            {
                indexOfDot = Array.IndexOf(arr, ',');
            }

            int indexOfExp = Array.IndexOf(arr, 'e');
            if (indexOfExp == 0)
            {
                indexOfExp = Array.IndexOf(arr, 'E');
            }

            int rightPow = indexOfExp - indexOfDot - 1;

            char[] powArr = new char[arr.Length - indexOfExp - 1];
            Array.Copy(arr, indexOfExp + 1, powArr, 0, powArr.Length);

            double currentPow = CountCurrentPow(powArr);

            return rightPow <= currentPow;
        }

        private static double CountCurrentPow(char[] powArr)
        {
            double currentPow = 0;
            for (int i = 0; i < powArr.Length; i++)
            {
                currentPow += (powArr[i] - '0') * Math.Pow(10, powArr.Length - 1 - i);
            }

            return currentPow;
        }
    }
}
