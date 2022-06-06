using System.Data.SqlClient;

namespace DAL
{
    public abstract class Connection
    {
        protected string connectionString = @"Data Source=localhost;Initial Catalog=TCI;Integrated Security=True";
        protected SqlConnection conn = new SqlConnection(@"Data Source=localhost;Initial Catalog=TCI;Integrated Security=True");
    }
}
