using DAL;
using Services;

namespace BLL
{
    public class IdiomaManager
    {
        public Idioma getIdioma(string idiomaId)
        {
            var idiomaDAO = new IdiomaDAO();
            return idiomaDAO.getIdioma(idiomaId);
        }
    }
}
