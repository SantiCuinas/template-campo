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

            comboBox1.DisplayMember = "nombre";
            comboBox1.ValueMember = "id";
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
            var idiomaMngr = new IdiomaManager();
            var idiomas = idiomaMngr.getIdiomas();
            foreach (var idioma in idiomas)
            {
                comboBox1.Items.Add(idioma);
            }
            comboBox1.SelectedIndex = Session.selected;
            var selected = (Idioma)comboBox1.SelectedItem;
            Session.selectedIdioma = selected.id;
            var x = Session.GetInstance();
            idiomaMngr.cambiarIdioma(Session.selectedIdioma, this);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selected = (Idioma)comboBox1.SelectedItem;
            Session.selectedIdioma = selected.id;
            Session.selected = comboBox1.SelectedIndex;
            var idiomaMngr = new IdiomaManager();
            idiomaMngr.cambiarIdioma(Session.selectedIdioma, this);
        }
    }
}
