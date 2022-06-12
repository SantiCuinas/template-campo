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

            if (data.HasRows)
            {
                while (data.Read())
                {
                    var usuario = new User() { id = data["id"].ToString(), name = data["name"].ToString(), password = data["password"].ToString(), intentosLogin = int.Parse(data["intentos"].ToString()), rol = getFamilia(data["rol"].ToString()) };
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

            if (data.HasRows)
            {
                while (data.Read())
                {
                    var usuario = new User() { id = data["id"].ToString(), name = data["name"].ToString(), password = data["password"].ToString(), intentosLogin = int.Parse(data["intentos"].ToString()), rol = getFamilia(data["rol"].ToString()) };
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

        private List<Rol> getRoles(string familiaId)
        {
            var listRol = new List<Rol>();
            var conn = new SqlConnection(this.connectionString);

            var queryString = string.Format("SELECT * FROM familia_patente WHERE id_familia = '{0}'", familiaId);

            var query = new SqlCommand(queryString, conn);
            conn.Open();
            var data = query.ExecuteReader();
            if (data.HasRows)
            {
                while (data.Read())
                {
                    if (data["tipo"].ToString() == "patente")
                    {
                        listRol.Add(getPatente(data["id_hijo"].ToString()));
                    }
                    else
                    {
                        listRol.Add(getFamilia(data["id_hijo"].ToString()));
                    }
                }
            }

            conn.Close();

            return listRol;
        }

        public List<Rol> getAllRoles()
        {
            var listRol = new List<Rol>();
            listRol.AddRange(getAllFamilia());
            listRol.AddRange(getAllPatente());

            return listRol;
        }

        public List<Familia> getAllFamilia()
        {
            var conn = new SqlConnection(this.connectionString);
            var queryString = "SELECT * FROM familia";

            var query = new SqlCommand(queryString, conn);
            var listFamilia = new List<Familia>();

            conn.Open();
            var data = query.ExecuteReader();
            if (data.HasRows)
            {
                while (data.Read())
                {
                    listFamilia.Add(new Familia() { name = data["nombre"].ToString(), id = data["id"].ToString(), patentes = getRoles(data["id"].ToString()) });
                }
            }

            conn.Close();
            return listFamilia;
        }

        private Familia getFamilia(string familiaId)
        {
            var conn = new SqlConnection(this.connectionString);
            var queryString = string.Format("SELECT * FROM familia WHERE id = '{0}'", familiaId);

            var query = new SqlCommand(queryString, conn);
            Familia familia = new Familia();

            conn.Open();
            var data = query.ExecuteReader();
            if (data.HasRows)
            {
                data.Read();
                familia = new Familia() { name = data["nombre"].ToString(), id = data["id"].ToString(), patentes = getRoles(familiaId) };
            }

            conn.Close();
            return familia;
        }

        private Patente getPatente(string patenteId)
        {
            var conn = new SqlConnection(this.connectionString);

            var queryString = string.Format("SELECT * FROM patente WHERE id = '{0}'", patenteId);
            var query = new SqlCommand(queryString, conn);
            Patente patente = new Patente();
            conn.Open();
            var data = query.ExecuteReader();
            if (data.HasRows)
            {
                data.Read();
                patente = new Patente() { name = data["nombre"].ToString(), id = data["id"].ToString() };
            }

            conn.Close();
            return patente;
        }

        public List<Patente> getAllPatente()
        {
            var conn = new SqlConnection(this.connectionString);
            var queryString = "SELECT * FROM patente";

            var query = new SqlCommand(queryString, conn);
            var listPatente = new List<Patente>();

            conn.Open();
            var data = query.ExecuteReader();
            if (data.HasRows)
            {
                while (data.Read())
                {
                    listPatente.Add(new Patente() { name = data["nombre"].ToString(), id = data["id"].ToString() });
                }
            }

            conn.Close();
            return listPatente;
        }

        public void AddUser(User user)
        {
            var conn = this.conn;
            var queryString = string.Format("INSERT INTO users (id, name, password, intentos) VALUES ('{0}', '{1}', '{2}', '{3}');", user.id, user.name, user.password, user.intentosLogin);

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
            var queryString = string.Format("UPDATE users SET name = '{0}', password = '{1}', intentos = '{2}' WHERE id = '{3}';", user.name, user.password, user.intentosLogin, user.id);

            var query = new SqlCommand(queryString, conn);
            conn.Open();
            query.ExecuteNonQuery();
            conn.Close();

        }
    }
}
