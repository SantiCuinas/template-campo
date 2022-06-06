namespace Services
{
    public class User
    {
        public string name { get; set; }
        public string password { get; set; }
        public int intentosLogin { get; set; }
        public Rol rol { get; set; }
    }
}