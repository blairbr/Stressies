using Dapper;
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
        private string insertStatement = "INSERT INTO Customers (FirstName, LastName, Email, Password, StreetAddress, StreetAddress2, City, State, Zip) VALUES (@FirstName, @LastName, @Email, @Password, @StreetAddress, @StreetAddress2, @City, @State, @Zip)";
        private string deleteStatement = "DELETE FROM Customers WHERE [CustomerID] = @CustomerID";
        private string getByIdStatement = "SELECT * FROM Customers WHERE CustomerID = @CustomerID";
        private string updateStatement = @"
                UPDATE Customers SET FirstName = @FirstName, 
                                     LastName = @LastName, 
                                     Email = @Email, 
                                     Password = @Password,
                                     StreetAddress = @StreetAddress, 
                                     StreetAddress2 = @StreetAddress2,           
                                     City = @City, 
                                     State = @State, 
                                     Zip = @Zip 
                               WHERE CustomerID = @CustomerID";

        public async Task<Customer> AddCustomer(Customer customer)
        {
            using (var connection = new SqlConnection(connectionString))
                //call the stored proc
                await connection.ExecuteAsync(insertStatement, customer);
            return customer;
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

        public async Task<Customer> UpdateCustomer(Customer customer)
        {
            using (SqlConnection sqlconnection = new SqlConnection(connectionString))
            {
                await sqlconnection.ExecuteAsync(updateStatement, customer);
                return customer;
                //dont want to return what was sent in nomas... how do i return what was updated

            }
        }
    }
}
