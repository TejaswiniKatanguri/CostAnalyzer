using MovieTickets.CostAnalyzer.Models;
using NUnit.Framework;
using System.Collections.Generic;

namespace MovieTickets.CostAnalyzer.Tests.Unit
{
    public class Tests
    {
        Transaction transaction = new Transaction();

        [SetUp]
        public void Setup()
        {
            transaction = new Transaction()
            {
                TransactionId = 1,
                Customers = new List<Customer>()
                {
                    new Customer
                    {
                        Name = "child",
                        Age = 5
                    },
                    new Customer
                    {
                        Name = "teen",
                        Age = 15
                    },
                    new Customer
                    {
                        Name = "adult",
                        Age = 30
                    },
                    new Customer
                    {
                        Name = "senior",
                        Age = 68
                    }
                }
            };
        }

        [Test]
        public void Test()
        {
            Process proc = new Process();
            try
            {
                proc.Calculate(new List<Transaction>() { transaction });
                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false);
            }
        }
    }
}