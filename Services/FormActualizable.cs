using System.Collections.Generic;
using System.Windows.Forms;

namespace Services
{
    public class FormActualizable : Form
    {
        public List<Control> controlesList;

        public FormActualizable()
        {
            controlesList = new List<Control>();
            actualizarTextos();
        }

        public void actualizarTextos()
        {
            foreach (Control control in controlesList)
            {
                actualizarControl(Session.idioma.textos.Find(x => x.id == control.Tag?.ToString())?.texto ?? control.Text, control);
            }
        }

        private void actualizarControl(string texto, Control control)
        {
            control.Text = texto;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FormActualizable
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "FormActualizable";
            this.Load += new System.EventHandler(this.FormActualizable_Load);
            this.ResumeLayout(false);

        }

        private void FormActualizable_Load(object sender, System.EventArgs e)
        {

        }
    }
}
