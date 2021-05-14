using MovieTickets.CostAnalyzer.Models;
using System;
using System.Linq;

namespace MovieTickets.CostAnalyzer
{
    public static class MathHelper
    {
        public static Tuple<int,double> CalculateCosts(Transaction transaction, double price, CustomerType type, double concession = 0)
        {
            int count = 0;
            switch (type)
            {
                case CustomerType.Child:
                    count = transaction.Customers?.Where(x => x.Age < 11).Count() ?? 0;
                    return new Tuple<int, double>(count, count > 0 ? (count >= 3 ? count * (price - (price * concession)) : count * price) : 0);
                case CustomerType.Adult:
                    count = transaction.Customers?.Where(x => x.Age >= 18 && x.Age < 65).Count() ?? 0;
                    return new Tuple<int, double>(count, count > 0 ? count * price : 0);
                case CustomerType.Teen:
                    count = transaction.Customers?.Where(x => x.Age >= 11 && x.Age < 18).Count() ?? 0;
                    return new Tuple<int, double>(count, count > 0 ? count * price : 0);
                case CustomerType.Senior:
                    count = transaction.Customers?.Where(x => x.Age >= 65).Count() ?? 0; ;
                    return new Tuple<int, double>(count, count > 0 ? count * (price - (price * concession)) : 0);
                default:
                    break;
            }
            return new Tuple<int, double>(count, 0);
        }
    }
}
