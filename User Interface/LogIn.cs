using System;
using System.Windows.Forms;
using BLL;
using Services;

namespace User_Interface
{
    public partial class LogIn : Form
    {
        private LogManager logManager;

        public LogIn()
        {
            InitializeComponent();
            logManager = new LogManager();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            try
            {
                if (logManager.log(txtUser.Text, txtPass.Text))
                {
                    this.Hide();
                    var form1 = new Home();
                    form1.ShowDialog();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrecta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (UsuarioBloqueadoException)
            {
                MessageBox.Show("El usuario ha sido bloqueado. Comuniquese con el administrador de sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
