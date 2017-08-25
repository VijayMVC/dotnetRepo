using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splitting_a_sentence_into_words
{
    class Program
    {

            public bool HasConsecutiveVowels(string s)
            {
                // index 0 to the next-to-last index since we are selecting 2 characters at a time.
                for (int i = 0; i < s.Length - 1; i++)
                {
                    // get the current char
                    char current = s[i];
                    // get the char to the right of current
                    char next = s[i + 1];

                    if (IsVowel(current) && IsVowel(next))
                    {
                        // we found two vowels, we can stop now
                        return true;
                    }
                }

                // we looped the whole string and didn't find two vowels
                return false;
            }

            public bool IsVowel(char c)
            {
                switch (c)
                {
                    case 'a':
                    case 'A':
                    case 'e':
                    case 'E':
                    case 'i':
                    case 'I':
                    case 'o':
                    case 'O':
                    case 'u':
                    case 'U':
                        return true;
                    default:
                        return false;
                }
            }
            Console.ReadLine();
        }
    }
}
