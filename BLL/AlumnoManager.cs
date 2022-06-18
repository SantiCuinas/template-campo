using BE;
using DAL;
using Services;

namespace BLL
{
    public class AlumnoManager
    {
        public Alumno verificarDatos(string dni)
        {
            AlumnoDAO alumnoDAO = new AlumnoDAO();
            var alumno = alumnoDAO.getAlumno(dni);
            return alumno.id == null ? null : desenciptarDatosSensibles(alumno);
        }

        private Alumno desenciptarDatosSensibles(Alumno alumno)
        {
            alumno.fecha_nacimiento = CryptographyHelper.decrypt(alumno.fecha_nacimiento);
            alumno.email = CryptographyHelper.decrypt(alumno.email);
            alumno.direccion = CryptographyHelper.decrypt(alumno.direccion);

            return alumno;
        }

        public void altaAlumno(Alumno alumno)
        {
            AlumnoDAO alumnoDAO = new AlumnoDAO();
            alumnoDAO.addAlumno(enciptarDatosSensibles(alumno));
        }

        private Alumno enciptarDatosSensibles(Alumno alumno)
        {
            alumno.fecha_nacimiento = CryptographyHelper.encrypt(alumno.fecha_nacimiento);
            alumno.email = CryptographyHelper.encrypt(alumno.email);
            alumno.direccion = CryptographyHelper.encrypt(alumno.direccion);

            return alumno;
        }

    }
}
