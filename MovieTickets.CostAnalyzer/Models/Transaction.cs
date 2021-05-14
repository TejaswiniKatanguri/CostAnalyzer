using System.Collections.Generic;

namespace MovieTickets.CostAnalyzer.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public List<Customer> Customers { get; set; }
    }

    public class Customer
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public enum CustomerType
    {
        Child,
        Teen,
        Adult,
        Senior
    }
}
