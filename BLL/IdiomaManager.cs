using System.Windows.Forms;
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

        public void cambiarIdioma(string idiomaId, FormActualizable form)
        {
            var idioma = getIdioma(idiomaId);
            Session.SetIdioma(idioma);
            form.actualizarTextos();
        }
    }
}
