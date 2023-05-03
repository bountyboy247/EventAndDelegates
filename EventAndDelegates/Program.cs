using System;
using System.Collections.Generic;
using System.Linq;

namespace EventAndDelegates
{
    public class CompById: IComparer<Customer>
    {
        public int Compare(Customer x, Customer y)
        {
            if (x.CustomerId > y.CustomerId) return 1;
            else if(x.CustomerId <y.CustomerId) return -1;
            return 0;
        }
    }
    public class CompByLocation : IComparer<Customer>
    {
        public int Compare(Customer x, Customer y)
        {
           return x.Location.CompareTo(y.Location);
        }
    }
    internal class Program
    {
        //define delegate 
        public delegate void CustomerSorter( List<Customer> customers);
        static void Main(string[] args)
        {
            //create array of customers
            List<Customer> customers = new List<Customer>()
            {
                new Customer()
                {
                    Name = "Hari", CustomerId= 5,Location ="Austin"
                },
                new Customer()
                {
                    Name = "Samy", CustomerId= 2,Location ="Phoenix"
                },
                new Customer()
                {
                    Name = "Sanjit", CustomerId= 3,Location ="Denver"
                }
            };

            Console.WriteLine("Choose sort type, L => location, I => Id");
            string c = Console.ReadLine();
            CustomerSorter customerSorter = null;
            if(c == "L")
            {
                customerSorter = SortByLocation;
            }
            else if(c == "I")
            {
                customerSorter= SortByCustomerId;
            }
            customerSorter(customers);
            foreach(Customer customer in customers)
            {
                Console.WriteLine(customer.Name);
            }
        }
        static void SortByCustomerId(List<Customer> customers)
        {
            customers.Sort(new CompById());
        }
        static void SortByLocation(List<Customer> customers) { 
            customers.Sort(new CompByLocation());
        }
    }
}
