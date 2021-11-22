using Customers.Models;
using System;
using System.Configuration;
using System.IO;

namespace Customers
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
            Connection connection = new Connection(connectionString);
            StreamReader sr;

            try
            {
                sr = new StreamReader(File.OpenRead(@"Customers.csv"));
                string header_file = sr.ReadLine();

                connection.OpenConnection();
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] values = line.Split(';');

                    Customer customer = new Customer
                    {
                        Id = values[0],
                        Name = values[1],
                        Address = values[2],
                        City = values[3],
                        Country = values[4],
                        PostalCode = values[5],
                        Phone = values[6]
                    };

                    connection.SetCustomer(customer);
                }
                connection.CloseConnection();

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception ", e);
            }
            finally
            {
                Console.ReadLine();
                Console.WriteLine();
            }
        }
    }
}
