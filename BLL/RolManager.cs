using System.Collections.Generic;
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

        public Rol getRolForUser(string rolId)
        {
            var RolDao = new RolDAO();
            return RolDao.getFamilia(rolId);
        }
        public List<Rol> getRoles()
        {
            var rolDao = new RolDAO();
            return rolDao.getAllRoles();
        }
        public List<Familia> GetFamilias()
        {
            var rolDao = new RolDAO();
            return rolDao.getAllFamilia();
        }
    }
}
