using System.Collections.Generic;
using System.Data.SqlClient;
using BE;

namespace DAL
{
    public class UserDAO : Connection
    {
        public List<User> Select(string username)
        {
            var conn = this.conn;
            var queryString = string.Format("SELECT * FROM users WHERE name = '{0}'", username);

            var query = new SqlCommand(queryString, conn);
            conn.Open();
            var data = query.ExecuteReader();
            List<User> usuarios = new List<User>();

            if (data.HasRows)
            {
                while (data.Read())
                {
                    var usuario = new User() { name = data["name"].ToString(), password = data["password"].ToString() };
                    usuarios.Add(usuario);
                }
            }

            conn.Close();
            return usuarios;
        }
    }
}
