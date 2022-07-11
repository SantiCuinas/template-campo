using System;
using System.Windows.Forms;
using BLL;
using Services;

namespace User_Interface
{
    public partial class Home : FormActualizable
    {
        public Home()
        {
            InitializeComponent();
            this.controlesList.Add(button1);
            this.controlesList.Add(button2);
            this.controlesList.Add(button3);
            this.controlesList.Add(button4);
            this.controlesList.Add(groupBox1);
            this.controlesList.Add(btnAlta);
            this.controlesList.Add(btnCursos);
            this.controlesList.Add(btnVerDatos);
            this.controlesList.Add(gbEA);
            this.controlesList.Add(this);


            comboBox1.DisplayMember = "nombre";
            comboBox1.ValueMember = "id";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Session.CloseSession();
            this.Hide();
            var logInForm = new LogIn();
            logInForm.ShowDialog();
            this.Close();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            this.actualizarTextos();
            var idiomaMngr = new IdiomaManager();
            var idiomas = idiomaMngr.getIdiomas();
            foreach (var idioma in idiomas)
            {
                comboBox1.Items.Add(idioma);
            }
            comboBox1.SelectedIndex = Session.selected;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selected = (Idioma)comboBox1.SelectedItem;

            Session.selectedIdioma = selected.id;
            Session.selected = comboBox1.SelectedIndex;
            var idiomaMngr = new IdiomaManager();
            idiomaMngr.cambiarIdioma(Session.selectedIdioma, this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Session.user.rol.tienePermiso("ADM01"))
            {
                var admUsuariosForm = new AdmUsuarios();
                admUsuariosForm.ShowDialog();
            }
            else
            {
                MessageBox.Show(Session.idioma.textos.Find(x => x.id == "MSG_01".ToString())?.texto, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Session.user.rol.tienePermiso("ADM02"))
            {
                var admRolesForm = new AdmRoles();
                admRolesForm.ShowDialog();
            }
            else
            {
                MessageBox.Show(Session.idioma.textos.Find(x => x.id == "MSG_01".ToString())?.texto, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Session.user.rol.tienePermiso("EA01"))
            {
                var alumnoMngr = new AlumnoManager();
                var alumno = alumnoMngr.verificarDatos(tbDniVerificar.Text);

                if (alumno == null)
                {
                    MessageBox.Show(Session.idioma.textos.Find(x => x.id == "MSG_03".ToString())?.texto, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    var datosAlumno = new DatosAlumno(alumno);
                    datosAlumno.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show(Session.idioma.textos.Find(x => x.id == "MSG_01".ToString())?.texto, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (Session.user.rol.tienePermiso("EA02"))
            {
                var altaAlumno = new AltaAlumno();
                altaAlumno.ShowDialog();
            }
            else
            {
                MessageBox.Show(Session.idioma.textos.Find(x => x.id == "MSG_01".ToString())?.texto, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (Session.user.rol.tienePermiso("EA03"))
            {
                var alumnoMngr = new AlumnoManager();
                var alumno = alumnoMngr.verificarDatos(tbDniVerificar.Text);

                if (alumno == null)
                {
                    MessageBox.Show(Session.idioma.textos.Find(x => x.id == "MSG_03".ToString())?.texto, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    var admCusos = new AdmCursos(alumno);
                    admCusos.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show(Session.idioma.textos.Find(x => x.id == "MSG_01".ToString())?.texto, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (Session.user.rol.tienePermiso("ADM03"))
            {
                var admIdiomasForm = new AdmIdioma();
                admIdiomasForm.ShowDialog();
            }
            else
            {
                MessageBox.Show(Session.idioma.textos.Find(x => x.id == "MSG_01".ToString())?.texto, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
