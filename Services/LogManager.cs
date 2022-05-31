using System.Linq;
using BE;
using DAL;

namespace Services
{
    public class LogManager
    {
        UserDAO userDAO = new UserDAO();
        public bool log(string name, string pass)
        {
            var sesion = Session.GetInstance();

            var bdUser = getUser(name);
            if ((bdUser != null ? CryptographyHelper.decrypt(bdUser.password) != pass : true) || bdUser.intentosLogin >= 3)
            {
                try
                {
                    if (bdUser.intentosLogin >= 3)
                    {
                        throw new UsuarioBloqueadoException();
                    }

                    userDAO.actualizarIntentos(name, bdUser.intentosLogin + 1);
                    return false;
                }
                catch (System.Exception ex)
                {
                    if(ex is UsuarioBloqueadoException)
                    {
                        throw ex;
                    }
                    return false;
                }

            }
            else
            {
                sesion.user = bdUser;
                return true;

            }
        }

        private User getUser(string userName)
        {
            return userDAO.Select(userName).FirstOrDefault();
        }
    }
}
