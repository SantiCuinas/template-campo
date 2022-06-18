using System.Data.SqlClient;
using BE;

namespace DAL
{
    public class AlumnoDAO : Connection
    {
        public Alumno getAlumno(string dni)
        {
            var conn = new SqlConnection(this.connectionString);
            CursoDAO cursoDAO = new CursoDAO();
            var queryString = string.Format("SELECT * FROM alumno WHERE dni = '{0}'", dni);
            var query = new SqlCommand(queryString, conn);
            Alumno alumno = new Alumno();
            conn.Open();
            var data = query.ExecuteReader();
            if (data.HasRows)
            {
                data.Read();
                alumno = new Alumno() { nombre = data["nombre"].ToString(), id = data["id"].ToString(), apellido = data["apellido"].ToString(), fecha_nacimiento = data["fecha_nacimiento"].ToString(), email = data["email"].ToString(), direccion = data["direccion"].ToString(), fecha_alta = data["fecha_alta"].ToString(), dni = data["dni"].ToString(), cursos = cursoDAO.getCursosForStudent(data["id"].ToString()) };
            }

            conn.Close();
            return alumno;
        }

        public void addAlumno(Alumno alumno)
        {
            var conn = this.conn;
            var queryString = string.Format("INSERT INTO alumno (id, nombre, apellido, fecha_nacimiento, email, direccion, fecha_alta, dni) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}' );", alumno.id, alumno.nombre, alumno.apellido, alumno.fecha_nacimiento, alumno.email, alumno.direccion, alumno.fecha_alta, alumno.dni);

            var query = new SqlCommand(queryString, conn);
            conn.Open();
            query.ExecuteNonQuery();
            conn.Close();

        }
    }
}
