using System;
using System.Collections.Generic;

namespace SplitBillLibrary
{
    public class BillSplitter
    {
        public decimal splitAmount(decimal amount, int people)
        {
            if (people <= 0)
            {
                throw new ArgumentException("Number of people must be greater than zero.");
            }

            return amount / people;
        }

        public Dictionary<string, decimal> CalculateTip(Dictionary<string, decimal> mealCost, float tipPercentage)
        {
            var Cost = 0m;
            foreach (var cost in mealCost.Values)
            {
                Cost += cost;
            }

            var tip = Cost * (decimal)(tipPercentage / 100);
            var tipPerPerson = tip / mealCost.Count;

            var tipPerPerDict = new Dictionary<string, decimal>();
            foreach (var name in mealCost.Keys)
            {
                tipPerPerDict[name] = tipPerPerson;
            }

            return tipPerPerDict;
        }

        public decimal TipPerPerson(decimal price, int numberOfPatrons, float tipPercentage)
        {
            if (numberOfPatrons <= 0)
            {
                throw new ArgumentException("Number of patrons must be greater than zero.");
            }

            var totalTip = price * (decimal)(tipPercentage / 100);
            return totalTip / numberOfPatrons;
        }
    }
}
