using System;
using System.Windows.Forms;
using BLL;
using Services;

namespace User_Interface
{
    public partial class LogIn : FormActualizable
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
                    MessageBox.Show(Session.idioma.textos.Find(x => x.id == "MSG_07")?.texto, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (UsuarioBloqueadoException)
            {
                MessageBox.Show(Session.idioma.textos.Find(x => x.id == "MSG_06")?.texto, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void LogIn_Load(object sender, EventArgs e)
        {
            this.controlesList.Add(lbPass);
            this.controlesList.Add(lbUser);
            this.controlesList.Add(btnLogIn);
            comboBox1.SelectedIndex = Session.selected;
            Session.selectedIdioma = comboBox1.SelectedItem.ToString();
            var idiomaMngr = new IdiomaManager();
            idiomaMngr.cambiarIdioma(Session.selectedIdioma, this);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session.selectedIdioma = comboBox1.SelectedItem.ToString();
            Session.selected = comboBox1.SelectedIndex;
            var idiomaMngr = new IdiomaManager();
            idiomaMngr.cambiarIdioma(Session.selectedIdioma, this);
        }
    }
}
