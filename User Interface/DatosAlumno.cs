using System;
using System.Windows.Forms;
using BE;

namespace User_Interface
{
    public partial class DatosAlumno : Form
    {
        private Alumno alumno;
        public DatosAlumno(Alumno alumno)
        {
            InitializeComponent();
            this.alumno = alumno;
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
    }
}
