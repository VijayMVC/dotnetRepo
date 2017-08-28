using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warmups.BLL
{
    public class Logic
    {

        public bool GreatParty(int cigars, bool isWeekend)
        {
            { 
                bool isGreatParty = cigars >= 40;
                if (!isWeekend && isGreatParty)
                {
                    isGreatParty = cigars <= 60;
                }
                return isGreatParty;
            }
        }
        
        public int CanHazTable(int yourStyle, int dateStyle)
        {
            int getTable = 0;
            if (yourStyle <= 2 || dateStyle <= 2)
            {
                return getTable;
            }
            else if (yourStyle >= 8 || dateStyle >= 8)
            {
                getTable = 2;
            }
            else
                getTable = 1;
            return getTable;
        }

        public bool PlayOutside(int temp, bool isSummer)
        {
            if (isSummer && (temp >= 60 && temp <= 100))
            {
                return true;
            }
            else if (temp >= 60 && temp <= 90)
            {
                return true;
            }
            else
                return false;
        }
        
        public int CaughtSpeeding(int speed, bool isBirthday)
        {
            int ticket = 2;
            if (isBirthday)
            {
                if (speed <= 65)
                {
                    ticket = 0;
                }
                else if (speed >= 66 && speed <= 85)
                {
                    ticket = 1;
                }
                else
                    ticket = 2;                              
            }
            else
            {
                if (speed <= 60)
                {
                    ticket = 0;
                }
                else if (speed >= 61 && speed <= 80)
                {
                    ticket = 1;
                }
                else
                    ticket = 2;
            }
            return ticket;
           
        }
        
        public int SkipSum(int a, int b)
        {
            int sum = 0;
            sum = a + b;
            if (sum >= 10 && sum <= 19)
            {
                return 20;
            }
            else
                return sum;
        }
        
        public string AlarmClock(int day, bool vacation)
        {
            string time = "off";
            if (vacation)
            {
                if (day > 0 && day < 6)
                {
                    time = "10:00";
                }
                else
                    return time;
            }
            else
            {
                if (day > 0 && day < 6)
                {
                    time = "7:00";
                }
                else
                {
                    time = "10:00";
                }

            }
            return time;
        }
        
        public bool LoveSix(int a, int b)
        {
            if (a == 6 || b == 6)
            {
                return true;
            }
            else if (a + b == 6 || Math.Abs(a - b) == (6))
            {
                return true;
            }
            else
                return false;
        }
        
        public bool InRange(int n, bool outsideMode)
        {
            if (outsideMode)
            {
                if (n <= 1 || n >= 10)
                {
                    return true;
                }
                else
                    return false;
            }
            else if (n >= 1 && n <= 10)
            {
                return true;
            }
            else
                return false;
        }
        
        public bool SpecialEleven(int n)
        {
            return (true && ((n % 11 == 0) || ((n - 1) % 11 == 0)));
        }
        
        public bool Mod20(int n)
        {
            return (true && ((n - 1) % 20 == 0) || (n - 2) % 20 == 0);
        }
        
        public bool Mod35(int n)
        {
            if ((n % 3 == 0) && (n % 5 == 0))
            {
                return false;
            }
            else if ((n % 3 == 0) || (n % 5 == 0))
            {
                return true;
            }
            else
                return false;
        }
        
        public bool AnswerCell(bool isMorning, bool isMom, bool isAsleep)
        {
            if (isAsleep || (isMorning && !isMom))
            {
                return false;
            }
            else
                return true;
        }
        
        public bool TwoIsOne(int a, int b, int c)
        {
            return (true && ((a + b == c) || (a + c == b) || (b + c == a)));
        }
        
        public bool AreInOrder(int a, int b, int c, bool bOk)
        {
            if (bOk)
            {
                return (true && (c > b));
            }
            else if (b > a && c > b)
            {
                return true;
            }
            else
                return false;
        }
        
        public bool InOrderEqual(int a, int b, int c, bool equalOk)
        {
            if (equalOk)
            {
                return (true && ((a <= b) && (b <= c)));
            }
            else return (true && ((a < b) && (b < c)));
        }

        public bool LastDigit(int a, int b, int c)
        {
            string aString = a.ToString();
            string bString = b.ToString();
            string cString = c.ToString();
            string x = char.ToString(aString[aString.Length-1]);
            string y = char.ToString(bString[bString.Length-1]);
            string z = char.ToString(cString[cString.Length-1]);

            return (true && ((x == y) || (x == z) || (y == z)));
        }
        
        public int RollDice(int die1, int die2, bool noDoubles)
        {
            if (noDoubles && die1 == die2 && die1 == 6)
            {
                die1 = 1;
                return (die1 + die2);
            }
            if (noDoubles && die1 == die2)
            {
                die1++;
                return (die1 + die2);
            }
            else
                return (die1 + die2);
        }

    }
}
