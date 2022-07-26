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
            var queryString = "SELECT * FROM alumno WHERE dni = @DNI";
            SqlParameter[] param = new SqlParameter[1];
            var query = new SqlCommand(queryString, conn);
            param[0] = new SqlParameter("@DNI", dni);
            query.Parameters.Add(param[0]);
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

        public Alumno getAlumnoById(string id)
        {
            var conn = new SqlConnection(this.connectionString);
            CursoDAO cursoDAO = new CursoDAO();
            var queryString = "SELECT * FROM alumno WHERE id = @ID";
            SqlParameter[] param = new SqlParameter[1];
            var query = new SqlCommand(queryString, conn);
            param[0] = new SqlParameter("@ID", id);
            query.Parameters.Add(param[0]);
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
            var queryString = "INSERT INTO alumno (id, nombre, apellido, fecha_nacimiento, email, direccion, fecha_alta, dni) VALUES (@Id, @Nombre, @Apellido, @FechaNacimiento, @Email, @Direccion, @FechaAlta, @DNI );";
            SqlParameter[] param = new SqlParameter[8];

           var query = new SqlCommand(queryString, conn);
            param[0] = new SqlParameter("@Id", alumno.id);
            param[1] = new SqlParameter("@Nombre", alumno.nombre);
            param[2] = new SqlParameter("@Apellido", alumno.apellido);
            param[3] = new SqlParameter("@FechaNacimiento", alumno.fecha_nacimiento);
            param[4] = new SqlParameter("@Email", alumno.email);
            param[5] = new SqlParameter("@Direccion", alumno.direccion);
            param[6] = new SqlParameter("@FechaAlta", alumno.fecha_alta);
            param[7] = new SqlParameter("@DNI", alumno.dni);

            query.Parameters.Add(param[0]);
            query.Parameters.Add(param[1]);
            query.Parameters.Add(param[2]);
            query.Parameters.Add(param[3]);
            query.Parameters.Add(param[4]);
            query.Parameters.Add(param[5]);
            query.Parameters.Add(param[6]);
            query.Parameters.Add(param[7]);

            conn.Open();
            query.ExecuteNonQuery();
            conn.Close();
        }
    }
}
