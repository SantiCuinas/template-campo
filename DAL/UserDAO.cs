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
                    var usuario = new User() { name = data["name"].ToString(), password = data["password"].ToString(), intentosLogin = int.Parse(data["intentos"].ToString()), rol = getFamilia(data["rol"].ToString()) };
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
    }
}
