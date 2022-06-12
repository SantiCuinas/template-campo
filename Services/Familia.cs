using System.Collections.Generic;

namespace Services
{
    public class Familia : Rol
    {
        public List<Rol> patentes = new List<Rol>();
        public override bool tienePermiso(string permiso)
        {
            foreach (var patente in patentes)
            {
                if (patente.tienePermiso(permiso))
                {
                    return true;
                };
            }
            return false;
        }
    }
}
