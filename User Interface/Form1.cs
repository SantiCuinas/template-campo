using System;
using System.Windows.Forms;
using Services;

namespace User_Interface
{
    public partial class Form1 : FormActualizable
    {
        public Form1()
        {
            InitializeComponent();
            this.controles.Add(button1);
            this.controles.Add(button2);
            this.controles.Add(label1);
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.actualizarTextos();
        }
    }
}
