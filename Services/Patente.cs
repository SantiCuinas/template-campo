namespace Services
{
    public class Patente : Rol
    {
        public override bool tienePermiso(string permiso)
        {
            return permiso == this.name;
        }
    }
}
