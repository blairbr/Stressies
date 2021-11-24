﻿using Dapper;
using Stressies.Domain;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Stressies.Data.Customers
{
    public class CustomerRepository : ICustomerRepository
    {
        private string connectionString = "Data Source = (LocalDb)\\MSSQLLocalDB; Initial Catalog = Stressies; Integrated Security = True;";
        private string insertStatement = "INSERT INTO Customers (FirstName, LastName, Email, StreetAddress, StreetAddress2, City, State, Zip) VALUES (@FirstName, @LastName, @Email, @StreetAddress, @StreetAddress2, @City, @State, @Zip)";
        private string deleteStatement = "DELETE FROM Customers WHERE [CustomerID] = @CustomerID";
        private string getByIdStatement = "SELECT * FROM Customers WHERE CustomerID = @CustomerID";

        public async Task AddCustomer(Customer customer)
        {
            using (var connection = new SqlConnection(connectionString))
                //call the stored proc
                await connection.ExecuteAsync(insertStatement, customer);
        }

        public async Task DeleteCustomer(int customerId) 
        {
            using (var connection = new SqlConnection(connectionString)) 
            {
                await connection.ExecuteAsync(deleteStatement, new { CustomerID = customerId});
            }
        }

        public async Task<Customer> GetCustomerById(string customerId) 
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                var results = await sqlConnection.QueryAsync<Customer>(getByIdStatement, new { CustomerId = customerId });
                return results.FirstOrDefault();
            }
        }

    }
}
