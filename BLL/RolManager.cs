using DAL;
using Services;

namespace BLL
{
    public class RolManager
    {
        public void deleteRol(Rol rol)
        {
            var RolDao = new RolDAO();
            RolDao.DeleteRol(rol);
        }

        public void addRol(Rol rol)
        {
            var RolDao = new RolDAO();
            RolDao.AddRol(rol);
        }
    }
}
