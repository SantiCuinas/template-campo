using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class Idioma
    {
        public string id { get; set; }
        public string nombre { get; set; }
        public List<Texto> textos { get; set; }
    }
}
