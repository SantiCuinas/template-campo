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
                    var texto = new Texto() {id = data["id"].ToString(), idioma_id = data["id"].ToString(), texto = data["texto"].ToString() };
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
    }
}
