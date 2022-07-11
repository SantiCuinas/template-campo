﻿    using System.Collections.Generic;
using System.Data.SqlClient;
using BE;

namespace DAL
{
    public class CursoDAO : Connection
    {
        public List<Curso> getCursosForStudent(string id)
        {
            var conn = new SqlConnection(this.connectionString);
            var queryString = "SELECT * FROM curso_alumno WHERE alumno_id = @Id";
            SqlParameter[] param = new SqlParameter[1];
            var query = new SqlCommand(queryString, conn);
            param[0] = new SqlParameter("@Id", id);
            query.Parameters.Add(param[0]);

            List<Curso> cursoList = new List<Curso>();
            conn.Open();
            var data = query.ExecuteReader();

            if (data.HasRows)
            {
                while (data.Read())
                {
                    var curso = GetCurso(data["curso_id"].ToString());
                    if (curso != null) cursoList.Add(curso);

                }
            }

            conn.Close();
            return cursoList;
        }

        public Curso GetCurso(string cursoId)
        {
            var conn = new SqlConnection(this.connectionString);
            var queryString = "SELECT * FROM curso WHERE id = @CursoId";
            SqlParameter[] param = new SqlParameter[1];
            var query = new SqlCommand(queryString, conn);
            param[0] = new SqlParameter("@CursoId", cursoId);
            query.Parameters.Add(param[0]);

            Curso curso = null;
            conn.Open();
            var data = query.ExecuteReader();
            if (data.HasRows)
            {
                data.Read();
                curso = new Curso() { nombre = data["nombre"].ToString(), id = data["id"].ToString() };
            }
            conn.Close();
            return curso;
        }

        public List<Curso> GetAllCursos()
        {
            var conn = new SqlConnection(this.connectionString);
            var queryString = string.Format("SELECT * FROM curso");
            var query = new SqlCommand(queryString, conn);

            List<Curso> listaCurso = new List<Curso>();
            conn.Open();
            var data = query.ExecuteReader();
            if (data.HasRows)
            {
                while (data.Read())
                {
                    listaCurso.Add(new Curso() { nombre = data["nombre"].ToString(), id = data["id"].ToString() });
                }
            }
            conn.Close();
            return listaCurso;
        }

        public void UpdateCursos(Alumno alumno)
        {
            var conn = new SqlConnection(this.connectionString);
            var queryString = string.Format("DELETE FROM curso_alumno WHERE alumno_id = '{0}'", alumno.id);
            var query = new SqlCommand(queryString, conn);

            List<Curso> listaCurso = new List<Curso>();
            conn.Open();
            query.ExecuteNonQuery();
            conn.Close();
            foreach (var curso in alumno.cursos)
            {
                queryString = string.Format("INSERT INTO curso_alumno (alumno_id, curso_id) VALUES('{0}', '{1}')", alumno.id, curso.id);
                query = new SqlCommand(queryString, conn);
                conn.Open();
                query.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
