using SGFlooring.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFlooring.Models;
using System.IO;

namespace SGFlooring.Data
{
    public class TaxFileRepository : ITaxRepository
    {
        List<Tax> allStates = new List<Tax>();
        private string _filepath;

        public TaxFileRepository(string filepath)
        {
            _filepath = filepath;
            List();
        }

        public void List()
        {
            using (StreamReader sr = new StreamReader(_filepath))
            {
                sr.ReadLine();
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    Tax newState = new Tax();

                    string[] columns = line.Split(',');
                    newState.StateAbbreviation = columns[0];
                    newState.StateName = columns[1];
                    newState.TaxRate = decimal.Parse(columns[2]);

                    allStates.Add(newState);
                }
            }
        }
        public List<Tax> GetList()
        {
            return allStates;
        }

        public Order GetState(Order newOrder)
        {
            Order toReturn = newOrder;
            foreach (Tax t in allStates)
            {
                if (toReturn.State == t.StateAbbreviation)
                {
                    toReturn.TaxRate = t.TaxRate;
                }
            }
            return toReturn;
        }
    }
}
