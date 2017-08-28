using System;

namespace Warmups.BLL
{
    public class Loops
    {

        public string StringTimes(string str, int n)
        {
            string x = "";
            for (int i = 0; i < n; i++)
            {
                x += str;
            }
            return x;
        }

        public string FrontTimes(string str, int n)
        {
            string x = "";
            for (int i = 0; i < n; i++)
            {
                x += str.Substring(0, 3);
            }
            return x;
        }

        public int CountXX(string str)
        {
            int count = 0;
            for (int i = 0; i < str.Length - 1; i++)
            {
                char current = str[i];
                char next = str[i + 1];

                if (char.ToString(current) == "x" && char.ToString(next) == "x")
                {
                    count++;
                }
            }
            return count;
        }

        public bool DoubleX(string str)
        {
            if ((str.Length < 3) && (str != "xx"))
            {
                return false;
            }
            int marker = str.IndexOf("x");
            return (true && (str.Substring(marker + 1, 1) == "x"));
        }

        public string EveryOther(string str)
        {
            if (str.Length < 3)
            {
                return str.Substring(0, 1);
            }

            string track = "";
            for (int i = 0; i <= str.Length; i += 2)
            {
                track += str[i];
            }
            return track;
        }

        public string StringSplosion(string str)
        {
            string track = "";
            for (int i = 0; i <= str.Length; i++)
            {
                track += str.Substring(0, i);
            }
            return track;
        }

        public int CountLast2(string str)
        {
            string track = str.Substring(str.Length - 2, 2);
            string var = "";
            int count = 0;
            for (int i = 0; i < str.Length - 1; i++)
            {
                var = str.Substring(i, 2);
                if (var == track)
                {
                    count++;
                }
            }
            return count - 1;
        }

        public int Count9(int[] numbers)
        {
            int count = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == 9)
                {
                    count++;
                }
            }
            return count;
        }

        public bool ArrayFront9(int[] numbers)
        {

            if (numbers.Length < 4)
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (numbers[i] == 9)
                    {
                        return true;
                    }
                }
            }
            else
                for (int i = 0; i < 4; i++)
                {
                    if (numbers[i] == 9)
                    {
                        return true;
                    }
                }
            return false;
        }

        public bool Array123(int[] numbers)
        {
            int[] check = new int[] { 1, 2, 3 };
            int[] winner = new int[3];
            bool ans = false;
            for (int i = 0; i < numbers.Length - 3; i++)
            {
                int[] newArray = new int[] { numbers[i], numbers[i + 1], numbers[i + 2] };
                if (newArray[0] == 1 && newArray[1] == 2 && newArray[2] == 3)
                {
                    ans = true;
                }
            }
            return ans;
        }

        public int SubStringMatch(string a, string b)
        {
            string subA = "";
            string subB = "";
            int count = 0;
            if (b.Length < a.Length)
            {
                for (int i = 0; i < b.Length - 1; i++)
                {
                    subA = a.Substring(i, 2);
                    subB = b.Substring(i, 2);
                    if (subA == subB)
                    {
                        count++;
                    }
                }
            }
            else
            {
                for (int i = 0; i < a.Length - 1; i++)
                {
                    subA = a.Substring(i, 2);
                    subB = b.Substring(i, 2);
                    if (subA == subB)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public string StringX(string str)
        {
            string mid = str.Substring(1, str.Length - 2);
            string a = str.Substring(0, 1);
            string b = str.Substring(str.Length - 1, 1);
            mid = mid.Replace("x", "");
            return a + mid + b;
        }

        public string AltPairs(string str)
        {
            string final = "";
            string spaced = str + "     ";
            for (int i = 0; i < spaced.Length - 2; i += 4)
            {
                final += spaced.Substring(i, 2);
            }
            return final.TrimEnd();
        }

        public string DoNotYak(string str)
        {
            int index1 = str.IndexOf("yak");
            if (index1 != -1)
            {
                string result2 = str.Remove(index1, 3);
                return result2;
            }
            else return str;
        }

        public int Array667(int[] numbers)
        {
            int count66 = 0;
            int count67 = 0;
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (numbers[i] == 6 && numbers[i + 1] == 6)
                {
                    count66++;
                }
                else if (numbers[i] == 6 && numbers[i + 1] == 7)
                {
                    count67++;
                }
            }
            return count66;
        } 

        public bool NoTriples(int[] numbers)
        {
            bool ans = true;
            for (int i = 0; i < numbers.Length-3; i++)
            {
                if (numbers[i] == numbers[i + 1] && numbers[i + 1] == numbers[i + 2])
                {
                    ans = false;
                }
            }
            return ans;
        }

        public bool Pattern51(int[] numbers)
        {
            bool ans = false;
                for (int i = 0; i <= numbers.Length - 3; i++)
                {
                    int[] newArray = new int[] { numbers[i], numbers[i + 1], numbers[i + 2] };
                    if (newArray[0] == 2 && newArray[1] == 7 && newArray[2] == 1)
                    {
                        ans = true;
                    }
                }
            return ans;
        }

    }
}
