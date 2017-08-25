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
            throw new NotImplementedException();
        }
        
        public string AlarmClock(int day, bool vacation)
        {
            throw new NotImplementedException();
        }
        
        public bool LoveSix(int a, int b)
        {
            throw new NotImplementedException();
        }
        
        public bool InRange(int n, bool outsideMode)
        {
            throw new NotImplementedException();
        }
        
        public bool SpecialEleven(int n)
        {
            throw new NotImplementedException();
        }
        
        public bool Mod20(int n)
        {
            throw new NotImplementedException();
        }
        
        public bool Mod35(int n)
        {
            throw new NotImplementedException();
        }
        
        public bool AnswerCell(bool isMorning, bool isMom, bool isAsleep)
        {
            throw new NotImplementedException();
        }
        
        public bool TwoIsOne(int a, int b, int c)
        {
            throw new NotImplementedException();
        }
        
        public bool AreInOrder(int a, int b, int c, bool bOk)
        {
            throw new NotImplementedException();
        }
        
        public bool InOrderEqual(int a, int b, int c, bool equalOk)
        {
            throw new NotImplementedException();
        }
        
        public bool LastDigit(int a, int b, int c)
        {
            throw new NotImplementedException();
        }
        
        public int RollDice(int die1, int die2, bool noDoubles)
        {
            throw new NotImplementedException();
        }

    }
}
