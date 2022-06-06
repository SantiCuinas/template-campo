using System;
using System.Windows.Forms;
using Services;

namespace User_Interface
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Session.CloseSession();
            this.Hide();
            var logInForm = new LogIn();
            logInForm.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _ = Session.user.rol.tienePermiso("ADM_01") ? MessageBox.Show("Tiene permiso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information) : MessageBox.Show("No tiene permiso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
