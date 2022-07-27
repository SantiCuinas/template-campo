using System;
using System.Windows.Forms;
using BE;
using BLL;
using Services;

namespace User_Interface
{
    public partial class AltaAlumno : FormActualizable
    {
        DataVerificator verificator;
        public AltaAlumno()
        {
            InitializeComponent();
            verificator = new DataVerificator();

            this.controlesList.Add(lbNombre);
            this.controlesList.Add(lbApellido);
            this.controlesList.Add(lbBdate);
            this.controlesList.Add(lbAddress);
            this.controlesList.Add(btnAdd);
            this.controlesList.Add(btnBack);
            this.controlesList.Add(gbData);
            this.controlesList.Add(this);

            var idiomaMngr = new IdiomaManager();
            idiomaMngr.cambiarIdioma(Session.selectedIdioma, this);
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
                MessageBox.Show(Session.idioma.textos.Find(x => x.id == "MSG_10")?.texto, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void AltaAlumno_Load(object sender, EventArgs e)
        {

        }
    }
}
