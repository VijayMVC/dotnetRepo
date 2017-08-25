using System;

namespace Warmups.BLL
{
    public class Conditionals
    {
        public bool AreWeInTrouble(bool aSmile, bool bSmile)
        {
            bool inTrouble = false;
            if (aSmile && bSmile || !aSmile && !bSmile)
            {
                inTrouble = true;
            }
            return inTrouble;
        }

        public bool CanSleepIn(bool isWeekday, bool isVacation)
        {
            if (isVacation || !isWeekday)
            {
                return true;
            }
            else
                return false;
        }

        public int SumDouble(int a, int b)
        {
            if (a == b)
            {
                return (a + b) * 2;
            }
            else
                return a + b;
        }

        public int Diff21(int n)
        {
            if (n > 21)
            {
                return Math.Abs((n - 21) * 2);
            }
            else
                return Math.Abs(n - 21);
        }


        public bool ParrotTrouble(bool isTalking, int hour)
        {
            return (isTalking && (hour < 7 || hour > 20));

        }

        public bool Makes10(int a, int b)
        {
            if (a == 10 || b == 10)
            {
                return true;
            }
            else if (a + b == 10)
            {
                return true;
            }
            else
                return false;
        }

        public bool NearHundred(int n)
        {
            int x = Math.Abs(100 - n);
            int y = Math.Abs(200 - n);
            if (x <= 10 || y < 10)
            {
                return true;
            }
            else
                return false;
        }

        public bool PosNeg(int a, int b, bool negative)
        {
            if (negative)
            {
                return (true == (a < 0 && b < 0));
            }
            else
            {
                return (true == (a * b < 0));
            }
        }

        public string NotString(string s)
        {
            if (s.IndexOf("not") != 0)
            {
                s = "not " + s;
            }
            return s;
        }

        public string MissingChar(string str, int n)
        {
            return str.Remove(n, 1);
        }

        public string FrontBack(string str)
        {
            if (str.Length <= 1)
            {
                return str;
            }
            else
            {
                string mid = str.Substring(1, str.Length - 2);
                return str[str.Length - 1] + mid + str[0];
            }
        }

        public string Front3(string str)
        {
            if (str.Length <= 2)
            {
                return (str + str + str);
            }
            else
            {
                string aString = str.Substring(0, 3);
                return (aString + aString + aString);
            }
        }
             
        
        public string BackAround(string str)
        {
            return str[str.Length - 1] + str + str[str.Length - 1];
        }
        
        public bool Multiple3or5(int number)
        {
            if (number % 3 == 0 || number % 5 == 0)
            {
                return true;
            }
            else
                return false;
        }

        public bool StartHi(string str)
        {
            return (str == "hi") || ((str.IndexOf("hi") == 0) && (!Char.IsLetter(str[2])));
        }
        
        public bool IcyHot(int temp1, int temp2)
        {
            if (temp1 < 0 && temp2 > 100)
            {
                return true;
            }
            else if (temp2 < 0 && temp1 > 100)
            {
                return true;
            }
            else
                return false;
        }
        
        public bool Between10and20(int a, int b)
        {
            return (a > 10 && a < 20) || (b > 10 && b < 20);
        }
        
        public bool HasTeen(int a, int b, int c)
        {
            return (a > 12 && a < 20) || (b > 12 && b < 20) || (c > 12 && c < 20);
        }
        
        public bool SoAlone(int a, int b)
        {
            if ((a > 12 && a < 20) && (b > 12 && b < 20))
            {
                return false;
            }
            else if ((a > 12 && a < 20) || (b > 12 && b < 20))
            {
                return true;
            }
            else
                return false;
        }
        
        public string RemoveDel(string str)
        {
            if (str.Substring(1, 3) == "del")
            {
                string aString = str.Remove(1, 3);
                return aString;
            }
            else
                return (str);
        }
        
        public bool IxStart(string str)
        {
            return (str.Substring(1, 2) == "ix");
        }
        
        public string StartOz(string str)
        {
            if (str.Length < 2 && str.Substring(0,1) != "o")
            {
                return ("");
            }
            else if (str.Substring(0, 2) == "oz")
            {
                return ("oz");
            }
            else if (str.Substring(0, 1) == "o")
            {
                return ("o");
            }
            else if (str.Substring(1, 1) == "z")
            {
                return ("z");
            }
            else
                return ("");
        }
        
        public int Max(int a, int b, int c)
        {
            if (a > b && a > c)
            {
                return (a);
            }
            else if (b > a && b > c)
            {
                return (b);
            }
            else
                return (c);
        }
        
        public int Closer(int a, int b)
        {
            if (Math.Abs(10 - a) < Math.Abs(10 - b))
            {
                return (a);
            }
            else if (Math.Abs(10 - b) < Math.Abs(10 - a))
            {
                return (b);
            }
            else
                return (0);
        }
        
        public bool GotE(string str)
        {
            char y = 'e';
            int z = 0;
            for (int i = 0; i < str.Length; i++)
            {
                char x = str[i];
                if (x == y)
                {
                    z++;
                }
            }
            return (z >= 1 && z <= 3);
        }
        
        public string EndUp(string str)
        {
            if (str.Length < 3)
            {
                return (str.ToUpper());
            }
            else
            {
                string newstring = (str.Substring(str.Length - 3,3));
                return (str.Remove(str.Length - 3,3) + newstring.ToUpper()); 
                
            }
        }
        
        public string EveryNth(string str, int n)
        {
            string newString = "";
            for (int i = 0; i < str.Length; i += n) 
            {
                newString += str[i];
            }
            return newString;
        }
    }
}
