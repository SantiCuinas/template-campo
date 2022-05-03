using BE;

namespace Services
{
    public class Session
    {
        private Session() { }
        public User user { get; set; }

        private static Session instance;

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
    }
}
