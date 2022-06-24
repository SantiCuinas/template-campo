namespace Services
{
    public class Session
    {
        private Session() { }
        public static User user { get; set; }
        public static Idioma idioma { get; set; }

        private static Session instance;

        public static string selectedIdioma { get; set; }

        public static Session GetInstance()
        {
            if (instance == null)
            {
                instance = new Session();
            }
            return instance;
        }

        public static void CloseSession()
        {
            instance = null;
        }

        public static void SetIdioma(Idioma idioma)
        {
            Session.idioma = idioma;
        }
    }
}
