using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BE;
using BLL;

namespace User_Interface
{
    public partial class AdmCursos : Form
    {
        private Alumno alumno;
        private CursoManager cursoMngr;
        public AdmCursos(Alumno alumno)
        {
            InitializeComponent();
            this.alumno = alumno;
            this.cursoMngr = new CursoManager();
            clbCursos.DisplayMember = "nombre";
            clbCursos.ValueMember = "id";
        }

        private void AdmCursos_Load(object sender, EventArgs e)
        {
            RefreshCursosList();
        }

        private void RefreshCursosList()
        {
            clbCursos.Items.Clear();
            var index = 0;
            var cursos = cursoMngr.GetCursos();
            foreach (var curso in cursos)
            {
                clbCursos.Items.Add(curso);
                if (alumno.cursos.Find(x => x.id == curso.id) != null)
                {
                    clbCursos.SetItemChecked(index, true);
                }
                index++;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            alumno.cursos = new List<Curso>();
            foreach (var curso in clbCursos.CheckedItems)
            {
                alumno.cursos.Add((Curso)curso);
            }
            cursoMngr.UpdateCursos(alumno);
            RefreshCursosList();
        }
    }
}
