using System.Collections.Generic;
using System.Data.SqlClient;
using Services;

namespace DAL
{
    public class RolDAO : Connection
    {
        private List<Rol> getRoles(string familiaId)
        {
            var listRol = new List<Rol>();
            var conn = new SqlConnection(this.connectionString);

            var queryString = "SELECT * FROM familia_patente WHERE id_familia = @IdFamilia";
            SqlParameter[] param = new SqlParameter[1];
            var query = new SqlCommand(queryString, conn);
            param[0] = new SqlParameter("@IdFamilia", familiaId);
            query.Parameters.Add(param[0]);

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

        public Familia getFamilia(string familiaId)
        {
            var conn = new SqlConnection(this.connectionString);
            var queryString = "SELECT * FROM familia WHERE id = @FamiliaId";

            SqlParameter[] param = new SqlParameter[1];
            var query = new SqlCommand(queryString, conn);
            param[0] = new SqlParameter("@FamiliaId", familiaId);
            query.Parameters.Add(param[0]);

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

            var queryString = "SELECT * FROM patente WHERE id = @PatenteId";
            SqlParameter[] param = new SqlParameter[1];
            var query = new SqlCommand(queryString, conn);
            param[0] = new SqlParameter("@PatenteId", patenteId);
            query.Parameters.Add(param[0]);

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

        public void AddRol(Rol rol)
        {
            var conn = this.conn;

            var queryString = string.Format("INSERT INTO {0} (id, nombre) VALUES (@Id, @Name);", rol.GetType().Name == "Familia" ? "familia" : "patente");
            SqlParameter[] param = new SqlParameter[2];
            var query = new SqlCommand(queryString, conn);
            param[0] = new SqlParameter("@Id", rol.id);
            param[1] = new SqlParameter("@Name", rol.name);

            query.Parameters.Add(param[0]);
            query.Parameters.Add(param[1]);

            conn.Open();
            query.ExecuteNonQuery();
            conn.Close();

            if (rol.GetType().Name == "Familia")
            {
                var familia = (Familia)rol;
                foreach (var child in familia.patentes)
                {
                    queryString = string.Format("INSERT INTO familia_patente (id_familia, id_hijo, tipo) VALUES ('{0}', '{1}', '{2}');", familia.id, child.id, child.GetType().Name == "Familia" ? "familia" : "patente");

                    query = new SqlCommand(queryString, conn);
                    conn.Open();
                    query.ExecuteNonQuery();
                    conn.Close();
                }
            }

        }

        public void DeleteRol(Rol rol)
        {
            var conn = this.conn;
            var queryString = string.Format("DELETE FROM {0} WHERE id = @Id;", rol.GetType().Name == "Familia" ? "familia" : "patente");
            SqlParameter[] param = new SqlParameter[2];

            var query = new SqlCommand(queryString, conn);
            param[0] = new SqlParameter("@Id", rol.id);
            param[1] = new SqlParameter("@Id", rol.id);

            query.Parameters.Add(param[0]);

            conn.Open();
            query.ExecuteNonQuery();
            conn.Close();

            queryString = "DELETE FROM familia_patente WHERE id_familia = @Id;";

            query = new SqlCommand(queryString, conn);
            query.Parameters.Add(param[1]);

            conn.Open();
            query.ExecuteNonQuery();
            conn.Close();
        }
    }
}
