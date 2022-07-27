using BE;
using DAL;
using System.Collections.Generic;

namespace BLL
{
    public class CursoManager
    {
        public List<Curso> GetCursos()
        {
            CursoDAO cursoDAO = new CursoDAO();
            return cursoDAO.GetAllCursos();
        }

        public void UpdateCursos(List<Curso> curso, Alumno alumno)
        {
            CursoDAO cursoDAO = new CursoDAO();
            cursoDAO.UpdateCursos3(alumno, curso);
        }

        public Curso AsignarAlumno(Alumno alumno, Curso curso)
        {
            if (curso.listaEspera.alumnos.Find(x => x.id == alumno.id) != null)
            {
                var alumnoEspera = curso.listaEspera.alumnos.Find(x => x.id == alumno.id);
                curso.listaEspera.alumnos.Remove(alumnoEspera);
            }

            if (curso.listaInscriptos.alumnos.Find(x => x.id == alumno.id) == null)
            {
                if (curso.listaInscriptos.alumnos.Count >= curso.listaInscriptos.capacidad)
                {
                    curso.listaEspera.alumnos.Add(alumno);
                }
                else
                {
                    curso.listaInscriptos.alumnos.Add(alumno);
                }
            }
            return curso;
        }
    }
}
