using System.Collections.Generic;
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

        public List<Idioma> getIdiomas()
        {
            var idiomaDAO = new IdiomaDAO();
            return idiomaDAO.getIdiomas();
        }

        public void createIdioma(Idioma idioma)
        {
            var idiomaDAO = new IdiomaDAO();
            idiomaDAO.createIdioma(idioma);
        }

        public void updateTexto(string idiomaId, string textoId, string texto)
        {
            var idiomaDAO = new IdiomaDAO();
            idiomaDAO.updateTexto(idiomaId, textoId, texto);
        }

    }
}
