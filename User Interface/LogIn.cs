using System;
using System.Windows.Forms;
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
            if (logManager.log(txtUser.Text, txtPass.Text))
            {
                var form1 = new Form1();
                form1.ShowDialog();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrecta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
