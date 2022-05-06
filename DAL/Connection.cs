using System.Data.SqlClient;

namespace DAL
{
    public abstract class Connection
    {
        protected SqlConnection conn = new SqlConnection(@"Data Source=localhost;Initial Catalog=TCI;Integrated Security=True");
    }
}
