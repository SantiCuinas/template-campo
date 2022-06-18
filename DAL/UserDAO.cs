using System.Collections.Generic;
using System.Data.SqlClient;
using Services;

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
            var rolDao = new RolDAO();

            if (data.HasRows)
            {
                while (data.Read())
                {
                    var usuario = new User() { id = data["id"].ToString(), name = data["name"].ToString(), password = data["password"].ToString(), intentosLogin = int.Parse(data["intentos"].ToString()), rol = new Familia() { id = data["rol"].ToString() } };
                    usuarios.Add(usuario);
                }
            }

            conn.Close();
            return usuarios;
        }

        public List<User> SelectAll()
        {
            var conn = this.conn;
            var queryString = "SELECT * FROM users";

            var query = new SqlCommand(queryString, conn);
            conn.Open();
            var data = query.ExecuteReader();
            List<User> usuarios = new List<User>();
            var rolDao = new RolDAO();

            if (data.HasRows)
            {
                while (data.Read())
                {
                    var usuario = new User() { id = data["id"].ToString(), name = data["name"].ToString(), password = data["password"].ToString(), intentosLogin = int.Parse(data["intentos"].ToString()), rol = rolDao.getFamilia(data["rol"].ToString()) };
                    usuarios.Add(usuario);
                }
            }

            conn.Close();
            return usuarios;
        }

        public void actualizarIntentos(string username, int intentos)
        {
            var conn = this.conn;
            var queryString = string.Format("UPDATE users SET [intentos] ={0} where name = '{1}';", intentos, username);

            var query = new SqlCommand(queryString, conn);
            conn.Open();
            query.ExecuteNonQuery();
            conn.Close();

        }

        public void AddUser(User user)
        {
            var conn = this.conn;
            var queryString = string.Format("INSERT INTO users (id, name, password, intentos, rol) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');", user.id, user.name, user.password, user.intentosLogin, user.rol.id);

            var query = new SqlCommand(queryString, conn);
            conn.Open();
            query.ExecuteNonQuery();
            conn.Close();

        }

        public void DeleteUser(string userId)
        {
            var conn = this.conn;
            var queryString = string.Format("DELETE FROM users WHERE id = '{0}';", userId);

            var query = new SqlCommand(queryString, conn);
            conn.Open();
            query.ExecuteNonQuery();
            conn.Close();

        }

        public void UpdateUser(User user)
        {
            var conn = this.conn;
            var queryString = string.Format("UPDATE users SET name = '{0}', password = '{1}', intentos = '{2}', rol = '{3}' WHERE id = '{4}';", user.name, user.password, user.intentosLogin, user.rol.id, user.id);

            var query = new SqlCommand(queryString, conn);
            conn.Open();
            query.ExecuteNonQuery();
            conn.Close();

        }
    }
}
