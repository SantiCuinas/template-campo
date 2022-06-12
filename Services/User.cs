namespace Services
{
    public class User
    {
        public string id { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public int intentosLogin { get; set; }
        public Rol rol { get; set; }
    }
}