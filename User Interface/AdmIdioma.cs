using System;
using System.Windows.Forms;
using BLL;
using Services;

namespace User_Interface
{
    public partial class AdmIdioma : FormActualizable
    {
        private IdiomaManager idiomaMngr;
        private Idioma selectedIdioma;
        public AdmIdioma()
        {
            InitializeComponent();
            idiomaMngr = new IdiomaManager();
            this.controlesList.Add(button1);
            this.controlesList.Add(button2);
            this.controlesList.Add(button3);
            this.controlesList.Add(label1);
            this.controlesList.Add(label2);
            this.controlesList.Add(groupBox1);
            this.controlesList.Add(this);

            listBox1.DisplayMember = "nombre";
            listBox1.ValueMember = "id";
            
            this.actualizarTextos();
            updateList();
        }

        private void updateList()
        {
            var idiomas = idiomaMngr.getIdiomas();
            listBox1.Items.Clear();
            foreach (var idioma in idiomas)
            {
                listBox1.Items.Add(idioma);

            }
            button1.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var idiomas = idiomaMngr.getIdiomas();
            idiomaMngr.createIdioma(new Idioma() { id = textBox1.Text, nombre = textBox2.Text });
            updateList();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var admTextos = new AdmTextos(selectedIdioma);
            admTextos.ShowDialog();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedIdioma = (Idioma)listBox1.SelectedItem;
            button1.Enabled = true;
        }

        private void AdmIdioma_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }
    }
}
