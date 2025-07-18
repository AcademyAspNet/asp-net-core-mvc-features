using Microsoft.Data.SqlClient;
using WebApplication7.Models.Entities;

namespace WebApplication7.Data.Repositories
{
    public class ProductRepository
    {
        private readonly string _databaseConnectionString;

        public ProductRepository(IConfiguration configuration)
        {
            string? databaseConnectionString = configuration.GetConnectionString("Default");

            if (databaseConnectionString == null)
                throw new MissingFieldException("Failed to get access to 'Default' connection string");

            _databaseConnectionString = databaseConnectionString;
        }

        private Product ReadProduct(SqlDataReader reader)
        {
            return new Product()
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                Description = !reader.IsDBNull(2) ? reader.GetString(2) : null,
                Price = reader.GetDecimal(3),
                CreatedAt = reader.GetDateTime(4)
            };
        }

        public IList<Product> GetAll()
        {
            IList<Product> products = new List<Product>();

            using (SqlConnection connection = new SqlConnection(_databaseConnectionString))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT Id, Name, Description, Price, CreatedAt FROM Products";

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (!reader.HasRows)
                        return products;

                    while (reader.Read())
                        products.Add(ReadProduct(reader));
                }
            }

            return products;
        }

        public Product? GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_databaseConnectionString))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT Id, Name, Description, Price, CreatedAt FROM Products WHERE Id = @Id";
                command.Parameters.AddWithValue("@Id", id);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (!reader.HasRows)
                        return null;

                    reader.Read();

                    return ReadProduct(reader);
                }
            }
        }
    }
}
