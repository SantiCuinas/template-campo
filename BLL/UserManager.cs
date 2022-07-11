using System.Collections.Generic;
using System.Linq;
using DAL;
using Services;

namespace BLL
{
    public class UserManager
    {
        public User getUserFromName(string username)
        {
            var userDao = new UserDAO();
            var rolMngr = new RolManager();
            var user = userDao.Select(username).FirstOrDefault();
            if (user != null) user.rol = rolMngr.getRolForUser(user.rol.id);
            return user;
        }
        public List<User> getUsuarios()
        {
            var UserDao = new UserDAO();
            return UserDao.SelectAll();
        }

        public bool CheckUser(string id)
        {
            var UserDao = new UserDAO();
            return UserDao.CheckIfUserExists(id);
        }

        public void addUser(User user, Rol rol)
        {
            var UserDao = new UserDAO();
            UserDao.AddUser(user, rol);
        }

        public void deleteUser(string userId, Rol rol)
        {
            var UserDao = new UserDAO();
            UserDao.DeleteUser(userId, rol);
        }

        public void updateUser(User user)
        {
            var UserDao = new UserDAO();
            UserDao.UpdateUser(user);
        }

        public void resetIntentos(string username)
        {
            var UserDao = new UserDAO();
            UserDao.actualizarIntentos(username, 0);
        }
    }
}
