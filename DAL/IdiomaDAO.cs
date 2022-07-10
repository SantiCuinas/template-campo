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
            var queryString = string.Format("SELECT * FROM texto WHERE idioma_id = '{0}'", idiomaId);

            var query = new SqlCommand(queryString, conn);
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
            var queryString = string.Format("SELECT * FROM idioma WHERE id = '{0}'", idiomaId);

            var query = new SqlCommand(queryString, conn);
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
            var queryString = string.Format("INSERT INTO idioma (id, nombre) VALUES ('{0}', '{1}');", idioma.id, idioma.nombre);

            var query = new SqlCommand(queryString, conn);
            conn.Open();
            query.ExecuteNonQuery();
            conn.Close();
            populateTextos(idioma.id);
        }

        public void populateTextos (string idiomaId)
        {
            var conn = this.conn;
            var queryString = string.Format("INSERT INTO texto ( idioma_id, id, texto) SELECT '{0}', id, texto FROM texto WHERE idioma_id = 'ESP'; ", idiomaId);

            var query = new SqlCommand(queryString, conn);
            conn.Open();
            query.ExecuteNonQuery();
            conn.Close();
        }

        public void updateTexto (string idiomaId, string textoId, string texto)
        {
            var conn = this.conn;
            var queryString = string.Format("UPDATE texto SET [texto] = '{0}' where id = '{1}' and idioma_id = '{2}';", texto, textoId, idiomaId);

            var query = new SqlCommand(queryString, conn);
            conn.Open();
            query.ExecuteNonQuery();
            conn.Close();

        }
    }
}
