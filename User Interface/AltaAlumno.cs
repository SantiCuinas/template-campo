using System;
using System.Windows.Forms;
using BE;
using BLL;
using Services;

namespace User_Interface
{
    public partial class AltaAlumno : Form
    {
        DataVerificator verificator;
        public AltaAlumno()
        {
            InitializeComponent();
            verificator = new DataVerificator();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var alumnoMngr = new AlumnoManager();
            var alumno = new Alumno()
            {
                id = Guid.NewGuid().ToString(),
                dni = tbDni.Text,
                nombre = txtNombre.Text,
                apellido = txtApellido.Text,
                fecha_nacimiento = txtFechaN.Text,
                email = tbEmail.Text,
                direccion = tbDir.Text,
                fecha_alta = DateTime.UtcNow.ToString("MM-dd-yyyy"),
            };


            var verificationErrors = verificator.CheckAlumno(alumno);
            if (verificationErrors.Count == 0)
            {
                alumnoMngr.altaAlumno(alumno);
                MessageBox.Show(Session.idioma.textos.Find(x => x.id == "MSG_05")?.texto, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string error = Session.idioma.textos.Find(x => x.id == "MSG_04")?.texto + "\r";
                foreach (var err in verificationErrors)
                {
                    error += "- " + Session.idioma.textos.Find(x => x.id == err.ToString())?.texto + "\r";
                }
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
