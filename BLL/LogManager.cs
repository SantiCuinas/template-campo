using System.Collections.Generic;
using System.Linq;
using DAL;
using Services;

namespace BLL
{
    public class LogManager
    {
        UserDAO userDAO = new UserDAO();
        public bool log(string name, string pass)
        {
            var bdUser = getUser(name);
            if ((bdUser != null ? bdUser.password != CryptographyHelper.hash(pass) : true) || bdUser.intentosLogin >= 3)
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
                    if (ex is UsuarioBloqueadoException)
                    {
                        throw ex;
                    }
                    return false;
                }

            }
            else
            {
                Session.user = bdUser;
                // Levantar esta data de la BD
                Session.idioma = new Idioma() { id = "", nombre = "", textos = new List<Texto>() { new Texto() { id = "ENG_BTN_01", idioma_id = "", texto = "Add User" } } };
                return true;
            }
        }

        private User getUser(string userName)
        {
            return userDAO.Select(userName).FirstOrDefault();
        }
    }
}
