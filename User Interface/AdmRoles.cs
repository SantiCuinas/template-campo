using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BLL;
using Services;

namespace User_Interface
{
    public partial class AdmRoles : Form
    {
        private UserManager userMngr;
        private List<Rol> roles;
        private Rol selectedRol;
        private RolManager rolMngr;

        public AdmRoles()
        {
            InitializeComponent();
            userMngr = new UserManager();
            rolMngr = new RolManager();

            lbRoles.DisplayMember = "name";
            lbRoles.ValueMember = "id";

            clbChildren.DisplayMember = "name";
            clbChildren.ValueMember = "id";
        }
        private void refreshRolesList()
        {
            roles = userMngr.getRoles();
            lbRoles.Items.Clear();
            foreach (var rol in roles)
            {
                lbRoles.Items.Add(rol);
                clbChildren.Items.Add(rol);
            }
        }

        private void refreshChildrenList()
        {
            clbChildren.Items.Clear();
            var index = 0;
            foreach (var rol in roles)
            {
                if (rol.id != selectedRol?.id)
                {
                    clbChildren.Items.Add(rol);

                    if (selectedRol?.GetType().Name == "Familia")
                    {
                        var familila = (Familia)selectedRol;
                        if (familila.patentes.Find(x => x.id == rol.id) != null)
                        {
                            clbChildren.SetItemChecked(index, true);

                        }
                    }
                    index++;
                }

            }
        }

        private void refreshDatosRol()
        {
            cbTipo.SelectedIndex = selectedRol?.GetType()?.Name == "Familia" ? 0 : 1;
            clbChildren.Enabled = selectedRol?.GetType()?.Name == "Familia";
            tbName.Text = selectedRol?.name;
            refreshChildrenList();
        }

        private void AdmRoles_Load(object sender, EventArgs e)
        {
            refreshRolesList();
        }

        private void lbRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedRol = (Rol)lbRoles.SelectedItem;
            refreshDatosRol();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            rolMngr.deleteRol(selectedRol);
            refreshRolesList();
            refreshDatosRol();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form1 = new Home();
            form1.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cbTipo.SelectedIndex == 0)
            {

                var rolList = new List<Rol>();
                foreach (var child in clbChildren.CheckedItems)
                {
                    var rol = (Rol)child;
                    rolList.Add(rol);
                }
                var newRol = new Familia() { id = Guid.NewGuid().ToString(), name = tbName.Text, patentes = rolList };
                rolMngr.addRol(newRol);
                selectedRol = newRol;
            }
            else
            {
                var newRol = new Patente() { id = Guid.NewGuid().ToString(), name = tbName.Text };
                rolMngr.addRol(newRol);
                selectedRol = newRol;
            }
            refreshRolesList();
            refreshDatosRol();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cbTipo.SelectedIndex == 0)
            {

                try
                {
                    var rolList = new List<Rol>();
                    foreach (var child in clbChildren.CheckedItems)
                    {
                        var rol = (Rol)child;
                        if (rol.tienePermiso(selectedRol.name)) throw new Exception();
                        rolList.Add(rol);
                    }
                    var newRol = new Familia() { id = selectedRol.id, name = tbName.Text, patentes = rolList };
                    rolMngr.deleteRol(selectedRol);
                    rolMngr.addRol(newRol);
                    selectedRol = newRol;
                }
                catch (Exception)
                {
                    MessageBox.Show(Session.idioma.textos.Find(x => x.id == "MSG_02".ToString())?.texto, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                var newRol = new Patente() { id = selectedRol.id, name = tbName.Text };
                rolMngr.deleteRol(selectedRol);
                rolMngr.addRol(newRol);
                selectedRol = newRol;
            }
            refreshRolesList();
            refreshDatosRol();
        }

        private void cbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            clbChildren.Enabled = cbTipo.SelectedIndex == 0;
        }
    }
}
