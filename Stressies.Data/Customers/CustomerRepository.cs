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
        private const string connectionString = "Data Source = (LocalDb)\\MSSQLLocalDB; Initial Catalog = Stressies; Integrated Security = True;";
        private const string insertStatement =
                  @"INSERT INTO Customers (FirstName, LastName, Email, StreetAddress, StreetAddress2, City, State, Zip) 
                    OUTPUT INSERTED.CustomerID, INSERTED.FirstName, INSERTED.LastName, INSERTED.Email, INSERTED.StreetAddress, INSERTED.StreetAddress2, INSERTED.City, INSERTED.State, INSERTED.Zip
                    VALUES (@FirstName, @LastName, @Email, @StreetAddress, @StreetAddress2, @City, @State, @Zip)";
        private string deleteStatement = 
                  @"DELETE FROM Customers WHERE [CustomerID] = @CustomerID";
        private string getByIdStatement = 
                  @"SELECT * FROM Customers WHERE CustomerID = @CustomerID";
        private string updateStatement =
                  @"UPDATE Customers 
                                     SET FirstName = @FirstName, 
                                     LastName = @LastName, 
                                     Email = @Email, 
                                     Password = @Password,
                                     StreetAddress = @StreetAddress, 
                                     StreetAddress2 = @StreetAddress2,           
                                     City = @City, 
                                     State = @State, 
                                     Zip = @Zip 
                    OUTPUT INSERTED.[FirstName],
                           INSERTED.[LastName], 
                           INSERTED.[Email], 
                           INSERTED.[Password], 
                           INSERTED.[StreetAddress], 
                           INSERTED.[StreetAddress2], 
                           INSERTED.[City], 
                           INSERTED.[State], 
                           INSERTED.[Zip]
                    WHERE CustomerID = @CustomerID";
        public async Task<Customer> AddCustomer(Customer customer)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var addedCustomer = await connection.QuerySingleAsync<Customer>(insertStatement, customer);
                return addedCustomer;
            }
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
                var results = await sqlConnection.QuerySingleOrDefaultAsync<Customer>(getByIdStatement, new { CustomerId = customerId });
                                                                                    // this could also be done with stored procedures by replacing the SQL statement with the name of the stored procedure
                return results;
            }
        }

        public async Task<Customer> UpdateCustomer(Customer customer)
        {
            using (SqlConnection sqlconnection = new SqlConnection(connectionString))
            {
                var updatedCustomer = await sqlconnection.QuerySingleAsync<Customer>(updateStatement, customer);
                return updatedCustomer;

            }
        }
    }
}
