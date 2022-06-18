using System;
using System.Collections.Generic;
using BLL;
using Services;

namespace User_Interface
{
    public partial class AdmUsuarios : FormActualizable
    {
        private UserManager userMngr;
        private List<User> usuarios;
        private List<Familia> roles;
        private User selectedUser;
        private RolManager rolMngr;

        public AdmUsuarios()
        {
            InitializeComponent();

            lbUsuarios.DisplayMember = "name";
            lbUsuarios.ValueMember = "id";

            cbRol.DisplayMember = "name";
            cbRol.ValueMember = "id";

            userMngr = new UserManager();
            rolMngr = new RolManager();

            refreshUserList();
            roles = rolMngr.GetFamilias();
            refreshRolesList();

        }

        private void refreshRolesList()
        {
            cbRol.Items.Clear();
            cbRol.Items.Add(new Familia());
            cbRol.SelectedIndex = 0;
            cbRol.Items.Clear();
            foreach (var rol in roles)
            {
                cbRol.Items.Add(rol);
            }
        }

        private void refreshDatosUsuario()
        {
            lbId.Text = selectedUser?.id ?? "";
            tbName.Text = selectedUser?.name ?? "";
            btDesbloqueo.Enabled = selectedUser.intentosLogin >= 3;
            lbBloqueo.Visible = selectedUser.intentosLogin >= 3;
            int index = 0;
            bool foundFlag = false;
            for (int i = 0; i < cbRol.Items.Count; i++)
            {
                var familia = (Familia)cbRol.Items[i];
                if (familia.id == selectedUser?.rol?.id)
                {
                    index = i;
                    foundFlag = true;
                    break;
                }
            }

            cbRol.SelectedIndex = foundFlag ? index : -1;
        }

        private void refreshUserList()
        {
            usuarios = userMngr.getUsuarios();
            lbUsuarios.Items.Clear();
            foreach (var usuario in usuarios)
            {
                lbUsuarios.Items.Add(usuario);
            }
        }

        private void lbUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedUser = (User)lbUsuarios.SelectedItem;
            refreshRolesList();
            refreshDatosUsuario();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            userMngr.addUser(new User() {id = Guid.NewGuid().ToString(), rol = (Rol)cbRol.SelectedItem, name = tbName.Text, password = CryptographyHelper.hash(tbPass.Text), intentosLogin = 0 });
            refreshUserList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            userMngr.deleteUser(lbId.Text);
            refreshUserList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            userMngr.updateUser(new User() { id = selectedUser.id, rol = (Rol)cbRol.SelectedItem, name = tbName.Text, password = tbPass.Text == "" ? selectedUser.password :  CryptographyHelper.hash(tbPass.Text) , intentosLogin = 0 });
            refreshUserList();
        }

        private void AdmUsuarios_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btDesbloqueo_Click(object sender, EventArgs e)
        {
            userMngr.resetIntentos(selectedUser.name);
            btDesbloqueo.Enabled = false;
            lbBloqueo.Visible = false;
            refreshUserList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form1 = new Home();
            form1.ShowDialog();
            this.Close();
        }
    }
}
