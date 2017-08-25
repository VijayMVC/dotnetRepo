using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finding_indexes_of_letters_within_string
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "Hey there, let me take a moment to tell you why I like cheese";

            int i = 0; // start index

            // loop until we explicitly break
            while (true)
            {
                // check for an e starting at index i
                i = s.IndexOf("e", i);

                if (i == -1)
                    break; // no more e's
                else
                    Console.WriteLine($"Found an e at index: {i}");

                // move to the next index after the e we found.
                i++;
            }
            Console.ReadLine();
        }
    }
}
