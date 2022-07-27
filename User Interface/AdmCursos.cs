using BE;
using BLL;
using Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace User_Interface
{
    public partial class AdmCursos : FormActualizable
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

            this.controlesList.Add(button1);
            this.controlesList.Add(button2);
            this.controlesList.Add(groupBox1);
            this.controlesList.Add(this);

            var idiomaMngr = new IdiomaManager();
            idiomaMngr.cambiarIdioma(Session.selectedIdioma, this);
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
                curso.nombre = curso.nombre + " - (" + curso.listaInscriptos.alumnos.Count + "/" + curso.listaInscriptos.capacidad + ")";
                if (curso.listaEspera.alumnos.Find(x => x.id == alumno.id) != null)
                {
                    curso.nombre = curso.nombre + " - " + Session.idioma.textos.Find(x => x.id == "MSG_09".ToString())?.texto;
                }
                clbCursos.Items.Add(curso);
                if (curso.listaInscriptos.alumnos.Find(x => x.id == alumno.id) != null)
                {
                    clbCursos.SetItemChecked(index, true);
                }
                index++;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            alumno.cursos = new List<Curso>();
            var listCurso = new List<Curso>();
            var esperaFlag = false;
            foreach (Curso curso in clbCursos.CheckedItems)
            {
                var countEspera = curso.listaEspera.alumnos.Count;
                listCurso.Add(curso);
                cursoMngr.AsignarAlumno(alumno, curso);
                if (curso.listaEspera.alumnos.Count > countEspera) esperaFlag = true;
            }

            cursoMngr.UpdateCursos(listCurso, alumno);
            if (esperaFlag) MessageBox.Show(Session.idioma.textos.Find(x => x.id == "MSG_08".ToString())?.texto, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            RefreshCursosList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
