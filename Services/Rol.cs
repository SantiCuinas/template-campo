namespace Services
{
    public abstract class Rol
    {
        public string name { get; set; }
        public string id { get; set; }
        public abstract bool tienePermiso(string permiso);

        public string idName
        {
            get
            {
                return id + " - " + name;
            }
        }
    }
}
