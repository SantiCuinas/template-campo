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

        public AdmRoles()
        {
            InitializeComponent();
            userMngr = new UserManager();

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
                if (rol.id != selectedRol.id)
                {
                    clbChildren.Items.Add(rol);
                    if (selectedRol.tienePermiso(rol.id))
                    {
                        clbChildren.SetItemChecked(index, true);
                    }
                    index++;
                }
               
            }
        }

        private void refreshDatosRol()
        {
            lbTipo.Text = selectedRol.GetType().Name;
            clbChildren.Enabled = selectedRol.GetType().Name == "Familia";
            tbName.Text = selectedRol.name;
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
    }
}
