using System.Collections.Generic;
using System.Data.SqlClient;
using Services;

namespace DAL
{
    public class IdiomaDAO : Connection
    {
        private List<Texto> getTextos(string idiomaId)
        {
            var conn = this.conn;

            var queryString = "SELECT * FROM texto WHERE idioma_id = @IdiomaId";
            SqlParameter[] param = new SqlParameter[1];
            var query = new SqlCommand(queryString, conn);
            param[0] = new SqlParameter("@IdiomaId", idiomaId);
            query.Parameters.Add(param[0]);

            conn.Open();
            var data = query.ExecuteReader();
            List<Texto> textos = new List<Texto>();

            if (data.HasRows)
            {
                while (data.Read())
                {
                    var texto = new Texto() {id = data["id"].ToString(), idioma_id = data["idioma_id"].ToString(), texto = data["texto"].ToString() };
                    textos.Add(texto);
                }
            }

            conn.Close();
            return textos;
        }

        public Idioma getIdioma(string idiomaId)
        {
            var conn = new SqlConnection(this.connectionString);

            var queryString = "SELECT * FROM idioma WHERE id = @IdiomaId";
            SqlParameter[] param = new SqlParameter[1];
            var query = new SqlCommand(queryString, conn);
            param[0] = new SqlParameter("@IdiomaId", idiomaId);
            query.Parameters.Add(param[0]);

            Idioma idioma = new Idioma();

            conn.Open();
            var data = query.ExecuteReader();
            if (data.HasRows)
            {
                data.Read();
                idioma = new Idioma() { nombre = data["nombre"].ToString(), id = data["id"].ToString(), textos = getTextos(idiomaId) };
            }

            conn.Close();
            return idioma;
        }

        public List<Idioma> getIdiomas()
        {
            var conn = new SqlConnection(this.connectionString);
            var queryString = string.Format("SELECT * FROM idioma");

            var query = new SqlCommand(queryString, conn);
            List<Idioma> idiomaList = new List<Idioma>();

            conn.Open();
            var data = query.ExecuteReader();
            if (data.HasRows)
            {
                while (data.Read())
                {
                    var idioma = new Idioma() { nombre = data["nombre"].ToString(), id = data["id"].ToString(), textos = getTextos(data["id"].ToString()) };
                    idiomaList.Add(idioma);
                }
            }

            conn.Close();
            return idiomaList;
        }

        public void createIdioma (Idioma idioma)
        {
            var conn = this.conn;

            var queryString = "INSERT INTO idioma (id, nombre) VALUES (@Id, @Nombre);";
            SqlParameter[] param = new SqlParameter[2];
            var query = new SqlCommand(queryString, conn);
            param[0] = new SqlParameter("@Id", idioma.id);
            param[1] = new SqlParameter("@Nombre", idioma.nombre);

            query.Parameters.Add(param[0]);
            query.Parameters.Add(param[1]);

            conn.Open();
            query.ExecuteNonQuery();
            conn.Close();
            populateTextos(idioma.id);
        }

        public void populateTextos (string idiomaId)
        {
            var conn = this.conn;
            var queryString = "INSERT INTO texto ( idioma_id, id, texto) SELECT @IdiomaId, id, texto FROM texto WHERE idioma_id = 'ESP'; ";
            SqlParameter[] param = new SqlParameter[1];
            var query = new SqlCommand(queryString, conn);
            param[0] = new SqlParameter("@IdiomaId", idiomaId);
            query.Parameters.Add(param[0]);

            conn.Open();
            query.ExecuteNonQuery();
            conn.Close();
        }

        public void updateTexto (string idiomaId, string textoId, string texto)
        {
            var conn = this.conn;

            var queryString = "UPDATE texto SET [texto] = @Texto where id = @Id and idioma_id = @IdiomaId";
            SqlParameter[] param = new SqlParameter[3];
            var query = new SqlCommand(queryString, conn);
            param[0] = new SqlParameter("@Texto", texto);
            param[1] = new SqlParameter("@Id", textoId);
            param[2] = new SqlParameter("@IdiomaId", idiomaId);

            query.Parameters.Add(param[0]);
            query.Parameters.Add(param[1]);
            query.Parameters.Add(param[2]);

            conn.Open();
            query.ExecuteNonQuery();
            conn.Close();
        }
    }
}
