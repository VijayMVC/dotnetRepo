using System;

namespace Warmups.BLL
{
    public class Arrays
    {

        public bool FirstLast6(int[] numbers)
        {
            if ((numbers[0] == 6) || (numbers[numbers.Length - 1] == 6))
            {
                return true;
            }
            else
                return false;
        }

        public bool SameFirstLast(int[] numbers)
        {
            return (true && (numbers.Length >= 1 && numbers[0] == numbers[numbers.Length - 1]));
        }
        public int[] MakePi(int n)
        {
            int[] pi = new int[] { 3, 1, 4, 1, 5, 9, 2, 6, 5 };
            int[] answer = new int[n];
            for (int i =0;i<n;i++)
            {
                answer[i] += pi[i];
            }
            return answer;
        }
        
        public bool CommonEnd(int[] a, int[] b)
        {
            if ((a[0] == b[0]) || (a[a.Length - 1] == b[b.Length - 1]))
            {
                return true;
            }
            else
                return false;
        }
        
        public int Sum(int[] numbers)
        {
            int sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }
            return sum;
        }
        
        public int[] RotateLeft(int[] numbers)
        {
            int[] newArray = new int[] {numbers[1],numbers[2],numbers[0]};
            return newArray;
            
        }
        
        public int[] Reverse(int[] numbers)
        {
            int[] newArray = new int[numbers.Length];
            for (int i = 0; i < numbers.Length; i++)
            {
                newArray[i] = numbers[(numbers.Length -1) - i];
            }
            return newArray;
        }
        
        public int[] HigherWins(int[] numbers)
        {
            if (numbers[0] > numbers[numbers.Length - 1])
            {
                int[] answerA = new int[] { numbers[0], numbers[0], numbers[0] };
                return answerA;
            }
            else
            {
                int[] answerB = new int[] { numbers[numbers.Length - 1], numbers[numbers.Length - 1], numbers[numbers.Length - 1] };
                return answerB;
            }
        }
        
        public int[] GetMiddle(int[] a, int[] b)
        {
            int[] newArray = new int[] { a[1], b[1] };
            return newArray;
        }
        
        public bool HasEven(int[] numbers)
        {
            for (int i = 0; i<numbers.Length;i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    return true;
                }
            }
            return false;
        }
        
        public int[] KeepLast(int[] numbers)
        {
            int[] finalAnswer = new int[numbers.Length*2];
            finalAnswer[finalAnswer.Length-1] = numbers[numbers.Length-1];
            return finalAnswer;
        }
        
        public bool Double23(int[] numbers)
        {
            int track2 = 0;
            int track3 = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == 2)
                {
                    track2++;
                }
                else if (numbers[i] == 3)
                {
                    track3++;
                }
            }
            if (track2 == 2 || track3 == 2)
            {
                return true;
            }
            else
                return false;
        }
        
        public int[] Fix23(int[] numbers)
        {
            if (numbers[0] == 2 && numbers[1] == 3)
            {
                numbers[1] = 0;
                return numbers;
            }
            else if (numbers[1] == 2 && numbers[2] == 3)
            {
                numbers[2] = 0;
                return numbers;
            }
            else
                return numbers;
        }
        
        public bool Unlucky1(int[] numbers)
        {
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if ((numbers[0] == 1 && numbers[1] == 3) || (numbers[1] == 1 && numbers[2] == 3)
                        || (numbers[numbers.Length - 2] == 1) && (numbers[numbers.Length - 1] == 3))
                {
                    return true;
                }
            }    
            return false;                    
        }
        
        public int[] Make2(int[] a, int[] b)
        {
            if (a.Length > 1)
            {
                return a;
            }
            else if (a.Length == 1)
            {
                int[] answer = new int[2] { a[0], b[0] };
                return answer;
            }
            else
                return b;
        }

    }
}
