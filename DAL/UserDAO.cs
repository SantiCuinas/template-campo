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

            var queryString = "SELECT * FROM users WHERE name = @Name";
            SqlParameter[] param = new SqlParameter[1];
            var query = new SqlCommand(queryString, conn);
            param[0] = new SqlParameter("@Name", username);
            query.Parameters.Add(param[0]);

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

        public bool CheckIfUserExists(string id)
        {

            var conn = this.conn;

            var queryString = "SELECT * FROM users WHERE id = @Id";
            SqlParameter[] param = new SqlParameter[1];
            var query = new SqlCommand(queryString, conn);
            param[0] = new SqlParameter("@Id", id);
            query.Parameters.Add(param[0]);

            conn.Open();
            var data = query.ExecuteReader();

            var respnse = data.HasRows;
            conn.Close();
            return respnse;
        }

        public void actualizarIntentos(string username, int intentos)
        {
            var conn = this.conn;
            var queryString = "UPDATE users SET [intentos] = @Intentos where name = @Name";
            SqlParameter[] param = new SqlParameter[2];
            var query = new SqlCommand(queryString, conn);
            param[0] = new SqlParameter("@Intentos", intentos);
            param[1] = new SqlParameter("@Name", username);
            query.Parameters.Add(param[0]);
            query.Parameters.Add(param[1]);
            conn.Open();
            query.ExecuteNonQuery();
            conn.Close();

        }

        public void AddUser(User user, Rol rol)
        {
            var conn = this.conn;

            var queryString = "INSERT INTO users (id, name, password, intentos, rol) VALUES (@Id, @Name, @Password, @Intentos, @Rol)";
            SqlParameter[] param = new SqlParameter[5];
            var query = new SqlCommand(queryString, conn);
            param[0] = new SqlParameter("@Id", user.id);
            param[1] = new SqlParameter("@Name", user.name);
            param[2] = new SqlParameter("@Password", user.password);
            param[3] = new SqlParameter("@Intentos", user.intentosLogin);
            param[4] = new SqlParameter("@Rol", user.id);

            query.Parameters.Add(param[0]);
            query.Parameters.Add(param[1]);
            query.Parameters.Add(param[2]);
            query.Parameters.Add(param[3]);
            query.Parameters.Add(param[4]);

            conn.Open();
            query.ExecuteNonQuery();
            conn.Close();

            var rolDao = new RolDAO();
            rolDao.AddRol(rol);
        }

        public void DeleteUser(string userId, Rol rol)
        {
            var conn = this.conn;
            var queryString = "DELETE FROM users WHERE id = @Id";
            SqlParameter[] param = new SqlParameter[1];
            var query = new SqlCommand(queryString, conn);
            param[0] = new SqlParameter("@Id", userId);
            query.Parameters.Add(param[0]);

            conn.Open();
            query.ExecuteNonQuery();
            conn.Close();

            var rolDao = new RolDAO();
            rolDao.DeleteRol(rol);
        }

        public void UpdateUser(User user)
        {
            var conn = this.conn;
            var queryString = "UPDATE users SET name = @Name, password = @Password, intentos = @Intentos WHERE id = @Id";
            SqlParameter[] param = new SqlParameter[5];
            var query = new SqlCommand(queryString, conn);
            param[0] = new SqlParameter("@Name", user.name);
            param[1] = new SqlParameter("@Password", user.password);
            param[2] = new SqlParameter("@Intentos", user.intentosLogin);
            param[3] = new SqlParameter("@Id", user.id);

            query.Parameters.Add(param[0]);
            query.Parameters.Add(param[1]);
            query.Parameters.Add(param[2]);
            query.Parameters.Add(param[3]);

            conn.Open();
            query.ExecuteNonQuery();
            conn.Close();

        }
    }
}
