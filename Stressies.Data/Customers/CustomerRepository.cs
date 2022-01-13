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
        private string insertStatement = @"INSERT INTO Customers (FirstName, LastName, Email, StreetAddress, StreetAddress2, City, State, Zip) 
                    OUTPUT Inserted.CustomerID, Inserted.FirstName
                 VALUES (@FirstName, @LastName, @Email, @StreetAddress, @StreetAddress2, @City, @State, @Zip)";
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
        //add OUTPUT to hard coded statements and then change the Execute Async to Query
        public async Task<Customer> AddCustomer(Customer customer)
        {
            using (var connection = new SqlConnection(connectionString))
                //call the stored proc
                return await connection.QuerySingleAsync<Customer>(insertStatement, customer);
        //        await connection.ExecuteAsync(insertStatement, customer);
          //  return customer;
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
                                                                                        //sql argument could be the name of the stored procedure
                return results;
            }
        }

        public async Task<Customer> UpdateCustomer(Customer customer)
        {
            using (SqlConnection sqlconnection = new SqlConnection(connectionString))
            {
                await sqlconnection.ExecuteAsync(updateStatement, customer);
                return customer;

            }
        }
    }
}
