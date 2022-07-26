using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Curso
    {
        public string id { get; set; }
        public string nombre { get; set; }
        public ListaInscriptos listaInscriptos { get; set; }
        public Lista listaEspera { get; set; }
    }
}
