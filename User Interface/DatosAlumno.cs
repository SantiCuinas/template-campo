using System;
using BE;
using BLL;
using Services;

namespace User_Interface
{
    public partial class DatosAlumno : FormActualizable
    {
        private Alumno alumno;
        public DatosAlumno(Alumno alumno)
        {
            InitializeComponent();
            this.alumno = alumno;

            this.controlesList.Add(gbDatos);
            this.controlesList.Add(btnBack);
            this.controlesList.Add(lbName);
            this.controlesList.Add(lbLastname);
            this.controlesList.Add(lbBdate);
            this.controlesList.Add(lbMail);
            this.controlesList.Add(lbAddress);
            this.controlesList.Add(lbRdate);
            this.controlesList.Add(this);

            var idiomaMngr = new IdiomaManager();
            idiomaMngr.cambiarIdioma(Session.selectedIdioma, this);

        }

        private void DatosAlumno_Load(object sender, EventArgs e)
        {
            lbId.Text = alumno.id;
            lbNombre.Text = alumno.nombre;
            lbApellido.Text = alumno.apellido;
            lbFechaN.Text = alumno.fecha_nacimiento;
            lbEmail.Text = alumno.email;
            lbDir.Text = alumno.direccion;
            lbDni.Text = alumno.dni;
            lbFechaA.Text = alumno.fecha_alta;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }
    }
}
