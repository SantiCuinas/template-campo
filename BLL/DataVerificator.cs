using System.Collections.Generic;
using System.Text.RegularExpressions;
using BE;

namespace BLL
{
    public class DataVerificator
    {
        private List<string> errorMessage;
        public List<string> CheckAlumno(Alumno alumno)
        {
            errorMessage = new List<string>();
            CheckForEmpty(alumno);
            CheckDNI(alumno.dni);
            CheckEmail(alumno.email);
            CheckFecha(alumno.fecha_nacimiento);
            return errorMessage;
        }

        private void CheckForEmpty(Alumno alumno)
        {
            if (alumno.dni == "") errorMessage.Add("VER_01");
            if (alumno.nombre == "") errorMessage.Add("VER_02");
            if (alumno.apellido == "") errorMessage.Add("VER_03");
            if (alumno.fecha_nacimiento == "") errorMessage.Add("VER_04");
            if (alumno.email == "") errorMessage.Add("VER_05");
            if (alumno.direccion == "") errorMessage.Add("VER_06");
        }

        private void CheckDNI(string dni)
        {
            Regex regex = new Regex(@"^[0-9]*$");
            if (!regex.IsMatch(dni) && dni != "") errorMessage.Add("VER_07");
        }
        private void CheckEmail(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if (!regex.IsMatch(email) && email != "") errorMessage.Add("VER_08");
        }

        private void CheckFecha(string fecha)
        {
            Regex regex = new Regex(@"^([0]?[0-9]|[12][0-9]|[3][01])[./-]([0]?[1-9]|[1][0-2])[./-]([0-9]{4}|[0-9]{2})$");
            if (!regex.IsMatch(fecha) && fecha != "") errorMessage.Add("VER_09");
        }
    }
}
