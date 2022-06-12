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
            this.controlesList.Add(groupBox1);
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
            //var idiomaMngr = new IdiomaManager();
            //idiomaMngr.cambiarIdioma("ENG", this);
            this.actualizarTextos();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idiomaMngr = new IdiomaManager();
            idiomaMngr.cambiarIdioma(comboBox1.SelectedItem.ToString(), this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Session.user.rol.tienePermiso("ADM_01"))
            {
                this.Hide();
                var admUsuariosForm = new AdmUsuarios();
                admUsuariosForm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show(Session.idioma.textos.Find(x => x.id == "MSG_01".ToString())?.texto, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Session.user.rol.tienePermiso("ADM_01"))
            {
                this.Hide();
                var admRolesForm = new AdmRoles();
                admRolesForm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show(Session.idioma.textos.Find(x => x.id == "MSG_01".ToString())?.texto, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
