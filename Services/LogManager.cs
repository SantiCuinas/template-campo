using System.Linq;
using BE;
using DAL;
using System.Data.SqlClient;

namespace Services
{
    public class LogManager 
    {
        UserDAO userDAO = new UserDAO();

        protected SqlConnection conn = new SqlConnection(@"Data Source=KUMA;Initial Catalog=TCI;Integrated Security=True");

        public bool log(string name, string pass)
        {
            var sesion = Session.GetInstance();

            var bdUser = getUser("Admin");
            if (bdUser != null ? bdUser.password == CryptographyHelper.encrypt(pass) : false)
            {
                sesion.user = bdUser;
                return true;
            }
            else
            {
                return false;
            }
        }

        private User getUser(string userName)
        {
            return userDAO.Select(userName).FirstOrDefault();
        }
    }
}
