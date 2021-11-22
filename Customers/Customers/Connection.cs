using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Customers.Models;

namespace Customers
{
    public class Connection
    {
        private SqlConnection connection;

        public Connection(string connectionString)
        {
            connection = new SqlConnection(connectionString);
        }

        public void OpenConnection()
        {
            connection.Open();
        }

        public void CloseConnection()
        {
            connection.Close();
        }

        public void SetCustomer(Customer customer)
        {
            string insert = "INSERT INTO CUSTOMERS (Id, Name, Address, City, Country, PostalCode, Phone) ";
            insert += "VALUES (@id, @name, @address, @city, @country, @postalcode, @phone)";
            using (SqlCommand command = new SqlCommand(insert, connection))
            {
                command.Parameters.Add("@id", SqlDbType.NVarChar, 5).Value = customer.Id;
                command.Parameters.Add("@name", SqlDbType.NVarChar, 30).Value = customer.Name;
                command.Parameters.Add("@address", SqlDbType.NVarChar, 60).Value = customer.Address;
                command.Parameters.Add("@city", SqlDbType.NVarChar, 15).Value = customer.City;
                command.Parameters.Add("@country", SqlDbType.NVarChar, 15).Value = customer.Country;
                command.Parameters.Add("@postalCode", SqlDbType.NVarChar, 10).Value = customer.PostalCode;
                command.Parameters.Add("@phone", SqlDbType.NVarChar, 24).Value = customer.Phone;
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
            };
        }
     
    }
}
