using System.Collections.Generic;
using System.Windows.Forms;

namespace Services
{
    public class FormActualizable : Form
    {
        protected List<Control> controles;

        public FormActualizable()
        {
            controles = new List<Control>();
        }

        public void actualizarTextos()
        {
            foreach (Control control in this.Controls)
            {
                control.Text = Session.idioma.textos.Find(x => x.id == control.Tag?.ToString())?.texto ?? control.Text;
            }
        }
    }
}
