using Dapper;
using Stressies.Domain;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Stressies.Data.Customers
{
    public class CustomerRepository : ICustomerRepository
    {
        private string connectionString = "Data Source = (LocalDb)\\MSSQLLocalDB; Initial Catalog = Stressies; Integrated Security = True;";
        private string insertStatement = "INSERT INTO Customers (FirstName, LastName, Email, StreetAddress, StreetAddress2, City, State, Zip) VALUES (@FirstName, @LastName, @Email, @StreetAddress, @StreetAddress2, @City, @State, @Zip)";
        private string deleteStatement = "DELETE FROM Customers WHERE [CustomerID] = @CustomerID";
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

    }
}
