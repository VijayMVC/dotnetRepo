using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConsoleApp2
{
    public class Program
    {
        static void Main(string[] args)
        {
            var sw = Stopwatch.StartNew();
            CreatNewDictionary();
            sw.Stop();
            decimal Stop = sw.ElapsedTicks / 10000000.0m;

            sw = Stopwatch.StartNew();
            CreatNewList();
            sw.Stop();
            decimal Stop2 = sw.ElapsedTicks / 10000000.0m;
            
            Console.WriteLine($"{Stop} seconds dictionary, {Stop2} seconds list");
            Console.ReadKey();
        }

        public static bool CreatNewList()
        {
            List<Person> people = new List<Person>();
            for (int i = 0; i < 1000000; i++)
            {
                Person P = new Person();
                P.FirstName = "First" + i;
                P.LastName = "Last" + i;
                P.email = i + "gmail.com";

                people.Add(P);
            }
            return true;
        }

        public static bool CreatNewDictionary()
        {
            Dictionary<string, Person> people = new Dictionary<string, Person>();
            for (int i = 0; i < 1000000; i++)
            {
                Person P = new Person();
                P.FirstName = "First" + i;
                P.LastName = "Last" + i;
                P.email = i + "gmail.com";

                people.Add(P.email, P);
            }
            return true;
        }

        public static bool TestList()
        {
            List<Person> people = new List<Person>();
            for (int i = 0; i < 1000000; i++)
            {
                Person P = new Person();
                P.FirstName = "First" + i;
                P.LastName = "Last" + i;
                P.email = i + "gmail.com";

                people.Add(P);
            }
            for (int i = 0; i < 10000; i++)
            {
                people.Add(new Person()

            }
            return true;
        }

        

    }



}



