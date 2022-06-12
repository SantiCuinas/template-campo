using System.Collections.Generic;
using DAL;
using Services;

namespace BLL
{
    public class UserManager
    {
        public List<User> getUsuarios()
        {
            var UserDao = new UserDAO();
            return UserDao.SelectAll();
        }

        public List<Familia> GetFamilias()
        {
            var UserDao = new UserDAO();
            return UserDao.getAllFamilia();
        }

        public void addUser(User user)
        {
            var UserDao = new UserDAO();
            UserDao.AddUser(user);
        }

        public void deleteUser(string userId)
        {
            var UserDao = new UserDAO();
            UserDao.DeleteUser(userId);
        }

        public void updateUser(User user)
        {
            var UserDao = new UserDAO();
            UserDao.UpdateUser(user);
        }

        public void resetIntentos(string username)
        {

        }

        public List<Rol> getRoles()
        {
            var UserDao = new UserDAO();
            return UserDao.getAllRoles();
        }
    }
}
