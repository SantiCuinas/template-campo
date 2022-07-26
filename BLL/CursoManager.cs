using System.Collections.Generic;
using BE;
using DAL;

namespace BLL
{
    public class CursoManager
    {
        public List<Curso> GetCursos()
        {
            CursoDAO cursoDAO = new CursoDAO();
            return cursoDAO.GetAllCursos();
        }

        public void UpdateCursos(Alumno alumno)
        {
            CursoDAO cursoDAO = new CursoDAO();
            cursoDAO.UpdateCursos(alumno);
        }

        public Curso AsignarAlumno(Alumno alumno, Curso curso)
        {
            if (curso.listaInscriptos.alumnos.Count >= curso.listaInscriptos.capacidad)
            {
                curso.listaEspera.alumnos.Add(alumno);
            } else
            {
                curso.listaInscriptos.alumnos.Add(alumno);
            }

            return curso;
        }
    }
}
