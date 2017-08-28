using System;

namespace Warmups.BLL
{
    public class Strings
    {

        public string SayHi(string name)
        {
            return "Hello " + name + "!";
        }

        public string Abba(string a, string b)
        {
            return (a + b + b + a);
        }

        public string MakeTags(string tag, string content)
        {
            return ($"<{tag}>{content}</{tag}>");
        }

        public string InsertWord(string container, string word) {
            string a = container.Substring(0, 2);
            string b = container.Substring(2, 2);
            return (a + word + b);
        }

        public string MultipleEndings(string str)
        {
            string a = str.Substring(str.Length - 2, 2);
            return (a + a + a);
        }

        public string FirstHalf(string str)
        {
            int a = str.Length / 2;
            return (str.Substring(0, a));
        }

        public string TrimOne(string str)
        {
            string str2 = str.Substring (0,str.Length-1);
            return (str2.Remove(0, 1));
        }

        public string LongInMiddle(string a, string b)
        {
            if (a.Length > b.Length)
            {
                return (b + a + b);
            }
            else
                return (a + b + a);
        }

        public string RotateLeft2(string str)
        {
            if (str.Length < 3)
            {
                return str;
            }
            else
            {
                string a = str.Substring(0, 2);
                string b = str.Substring(2,str.Length - 2);
                return (b + a);
            }
        }

        public string RotateRight2(string str)
        {
            if (str.Length < 3)
            {
                return str;
            }
            else
            {
                string a = str.Substring(0, str.Length - 2);
                string b = str.Substring(str.Length - 2, 2);
                return (b + a);
            }
        }

        public string TakeOne(string str, bool fromFront)
        {
            if (!fromFront)
            {
                return str.Substring(str.Length - 1, 1);
            }
            else
                return str.Substring(0, 1);
        }

        public string MiddleTwo(string str)
        {
            return (str.Substring((str.Length / 2) - 1, 2));
        }

        public bool EndsWithLy(string str)
        {
            if (str.Length < 2)
            {
                return false;
            }
            else
                return (true && (str.Substring(str.Length - 2, 2) == "ly"));
        }

        public string FrontAndBack(string str, int n)
        {
            string a = str.Substring(0, n);
            string b = str.Substring(str.Length - n, n);
            return a + b;
        }

        public string TakeTwoFromPosition(string str, int n)
        {
            if (str.Length - n < 2)
            {
                return str.Substring(0, 2);
            }
            else
                return str.Substring(n, 2);
        }

        public bool HasBad(string str)
        {
            if (str.Length < 3)
            {
                return false;
            }
            else
                return (true && ((str.Substring(0, 3) == "bad") || (str.Substring(1, 3) == "bad")));    
        }

        public string AtFirst(string str)
        {
            if (str.Length < 2 && str.Length > 0)
            {
                return str + "@";
            }
            else if (str.Length >= 2)
            {
                return str.Substring(0, 2);
            }
            else
                return "@@";
        }

        public string LastChars(string a, string b)
        {
            if (a == "" && b == "")
            {
                return "@@";
            }
            if (a == "")
            {
                a = "@";
                return a + b;
            }
            else if (b == "")
            {
                b = "@";
                return a.Substring(0, 1) + b;
            }
            else
                return a.Substring(0, 1) + b.Substring(b.Length - 1, 1);
        }

        public string ConCat(string a, string b)
        {
            string x = "dandelion";
            if (a == "" || b == "")
            {
                return a + b;
            }
            else if (a.Substring(a.Length - 1, 1) == b.Substring(0, 1))
            {
                x = a + b.Substring(1, b.Length - 1);
                return x;
            }
            else
            {
                x = a + b;
                x.Replace("cc", "c");
                return x;
            }
        }

        public string SwapLast(string str)
        {
            if (str.Length < 2)
            {
                return str;
            }
            else
            {
                string a = str.Substring(0, str.Length - 2);
                string b = str.Substring(str.Length - 2, 1);
                string c = str.Substring(str.Length - 1, 1);
                return (a + c + b);
            }
        }

        public bool FrontAgain(string str)
        {
            string a = str.Substring(0, 2);
            string b = str.Substring(str.Length - 2, 2);
            return (true && (a == b));
        }

        public string MinCat(string a, string b)
        {
            if (a == "" || b == "") 
            {
                return "";
            }
            else if (a.Length == b.Length)
            {
                return a + b;
            }
            else if (a.Length > b.Length)
            {
                int n = a.Length - b.Length;
                string c = a.Substring(n, a.Length - n);
                return c + b;
            }
            else
            {
                int n = b.Length - a.Length;
                string c = b.Substring(n, b.Length - n);
                return a + c;
            }

        }

        public string TweakFront(string str)
        {
            if (str == "")
            {
                return "";
            }

            string a = str.Substring(0, 1);
            string b = str.Substring(1, 1);
            string c = str.Substring(2, str.Length - 2);

            if ((a == "a" || a == "b") && (b == "a" || b == "b"))
            {
                return str;
            }
            else if (a == "a" || a == "b")
            {
                return a + c;
            }
            else if (b == "a" || b == "b")
            {
                return b + c;
            }
            else
                return c;
        }

        public string StripX(string str)
        {
            if (str == "x" || str == "")
            {
                return "";
            }
            string a = str.Substring(0, 1);
            string b = str.Substring(str.Length - 1, 1);
            if (a == "x" && b == "x")
            {
                return str.Substring(1, str.Length - 2);
            }
            else if (a == "x")
            {
                return str.Substring(1, str.Length - 1);
            }
            else
            {
                return str.Substring(0, str.Length - 1);
            }
        }
    }
}
