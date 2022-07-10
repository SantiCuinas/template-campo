namespace Services
{
    public class Texto
    {
        public string texto { get; set; }
        public string id { get; set; }
        public string idioma_id { get; set; }
        public string IdTexto
        {
            get
            {
                return id + " - " + texto;
            }
        }
    }
}
