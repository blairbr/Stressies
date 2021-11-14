using Dapper;
using Stressies.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Stressies.Data.Customers
{
    public class CustomerRepository : ICustomerRepository
    {
        private string connectionString = "Data Source = (LocalDb)\\MSSQLLocalDB; Initial Catalog = PracticeCommerce; Integrated Security = True;";
        private string insertStatement = "INSERT INTO Customers (FirstName, LastName) VALUES (@FirstName, @LastName)";
        private string deleteStatement = "DELETE FROM Customers WHERE [CustomerID] = @CustomerID";
        public async Task AddCustomer(Customer customer)
        {
            using (var connection = new SqlConnection(connectionString))
                //call the stored proc
                await connection.ExecuteAsync(insertStatement, customer);
        }

        public async Task DeleteCustomer(string customerId) 
        {
            using (var connection = new SqlConnection(connectionString)) 
            {
                await connection.ExecuteAsync(deleteStatement, new { CustomerID = customerId});
            }
        }

    }
}
