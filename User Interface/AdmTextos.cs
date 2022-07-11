using System;
using System.Windows.Forms;
using BLL;
using Services;

namespace User_Interface
{
    public partial class AdmTextos : FormActualizable
    {
        Idioma idioma;
        IdiomaManager idiomaMngr;
        private Texto selectedTexto;

        public AdmTextos(Idioma idioma)
        {
            InitializeComponent();
            this.idioma = idioma;
            this.idiomaMngr = new IdiomaManager();

            listBox1.DisplayMember = "IdTexto";
            listBox1.ValueMember = "id";

            this.controlesList.Add(button1);
            this.controlesList.Add(button2);
            this.controlesList.Add(this);

            this.actualizarTextos();
        }

        private void updateList()
        {
            idioma = idiomaMngr.getIdioma(idioma.id);
            listBox1.Items.Clear();
            foreach (var texto in idioma.textos)
            {
                listBox1.Items.Add(texto);
            }
            button1.Enabled = false;
        }

        private void AdmTextos_Load(object sender, EventArgs e)
        {
            updateList();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedTexto = (Texto)listBox1.SelectedItem;
            textBox1.Text = selectedTexto.texto;
            button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            idiomaMngr.updateTexto(selectedTexto.idioma_id, selectedTexto.id, textBox1.Text);
            updateList();
            this.actualizarTextos();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }
    }
}
