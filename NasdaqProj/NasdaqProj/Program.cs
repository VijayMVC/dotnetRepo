using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NasdaqProj
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Repos\dotnet-jake-ganser\Nasdaq Project\HistoricalQuotes.csv";
            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                reader.ReadLine();
                reader.ReadLine();
                List<DailyQuote> DailyQ = new List<DailyQuote>();
                DailyQuote Averages = new DailyQuote();
                for (line = reader.ReadLine(); line != null; line = reader.ReadLine())
                {
                   string[] Cells = line.Replace("\"","").Split(',');
                    DailyQuote d = new DailyQuote();
                    d.Date = DateTime.ParseExact(Cells[0],(@"yyyy/MM/dd"),null);
                    d.Open = decimal.Parse(Cells[1]);
                    d.High = decimal.Parse(Cells[4]);
                    d.Low = decimal.Parse(Cells[3]);
                    d.Close = decimal.Parse(Cells[4]);
                    d.Volume = decimal.Parse(Cells[2]);

                    Averages.Open += d.Open;
                    Averages.High += d.High;
                    Averages.Low += d.Low;
                    Averages.Close += d.Close;
                    Averages.Volume += d.Volume;

                    DailyQ.Add(d);
                }

                Averages.Open /= DailyQ.Count;
                Averages.High /= DailyQ.Count;
                Averages.Low /= DailyQ.Count;
                Averages.Close /= DailyQ.Count;
                Averages.Volume /= DailyQ.Count;

                Console.WriteLine("Average Open: " + Averages.Open);
                Console.WriteLine("Average High: " + Averages.High);
                Console.WriteLine("Average Low: " + Averages.Low);
                Console.WriteLine("Average Close: " + Averages.Close);
                Console.WriteLine("Average Volume: " + Averages.Volume);
                Console.ReadKey();
                Console.WriteLine(Averages.Open);
            }
        }
    }
}
