using SGFlooring.Models;
using SGFlooring.Models.Interfaces;
using System.Collections.Generic;

namespace SGFlooring.Data
{
    public class TaxTestRepository : ITaxRepository
    {
        private static Tax t1 = new Tax
        {
            StateAbbreviation = "OH",
            StateName = "Ohio",
            TaxRate = 6.25M
        };
        private static Tax t2 = new Tax
        {
            StateAbbreviation = "PA",
            StateName = "Pennsylvania",
            TaxRate = 6.75M
        };
        private static Tax t3 = new Tax
        {
            StateAbbreviation = "MI",
            StateName = "Michigan",
            TaxRate = 5.75M
        };
        private static Tax t4 = new Tax
        {
            StateAbbreviation = "IN",
            StateName = "Indiana",
            TaxRate = 6.00M
        };
        private static List<Tax> AllStates = new List<Tax>
        { t1,t2,t3,t4};

        public List<Tax> GetList()
        {
            return AllStates;
        }

        public Order AddStateToOrder(Order newOrder)
        {
            Order toReturn = newOrder;
            foreach (Tax t in AllStates)
            {
                if (toReturn.State == t.StateName)
                {
                    toReturn.State = t.StateAbbreviation;
                }
                if (toReturn.State == t.StateAbbreviation)
                {
                    toReturn.TaxRate = t.TaxRate;
                }
            }
            return toReturn;
        }
    }
}
