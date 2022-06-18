using System.Collections.Generic;

namespace BE
{
    public class Alumno
    {
        public string id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string fecha_nacimiento { get; set; }
        public string email { get; set; }
        public string direccion { get; set; }
        public string fecha_alta { get; set; }
        public string dni { get; set; }
        public List<Curso> cursos { get; set; }
    }
}
