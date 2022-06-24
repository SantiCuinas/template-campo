using System;
using System.Collections.Generic;
using System.Windows.Forms;
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

            this.controlesList.Add(btnBack);
            this.controlesList.Add(btnBorrar);
            this.controlesList.Add(btnCreate);
            this.controlesList.Add(btnUpdate);
            this.controlesList.Add(btDesbloqueo);
            this.controlesList.Add(lbPass);
            this.controlesList.Add(lbName);
            this.controlesList.Add(lbBloqueo);
            this.controlesList.Add(lbRol);
            this.controlesList.Add(gbDatos);
            this.controlesList.Add(this);

            var idiomaMngr = new IdiomaManager();
            idiomaMngr.cambiarIdioma(Session.selectedIdioma, this);

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

        private void refreshTreeView(Familia familia)
        {
            treeView1.Nodes.Clear();
            treeView1.Nodes.Add(familia.name);
            foreach (var child in familia.patentes)
            {
                addChild(child, treeView1.Nodes[0]);
            }
        }

        private void addChild(Rol rol, TreeNode node)
        {
            node.Nodes.Add(rol.name);
            var index = node.Nodes.Count - 1;
            if (rol.GetType().Name == "Familia")
            {
                var familia = (Familia)rol;

                foreach (var child in familia.patentes)
                {
                    addChild(child, node.Nodes[index]);
                }
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
            refreshTreeView((Familia)selectedUser.rol);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var newUser = new User() { id = Guid.NewGuid().ToString(), rol = (Rol)cbRol.SelectedItem, name = tbName.Text, password = CryptographyHelper.hash(tbPass.Text), intentosLogin = 0 };
            userMngr.addUser(newUser);
            refreshUserList();
            refreshTreeView((Familia)newUser.rol);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            userMngr.deleteUser(lbId.Text);
            refreshUserList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var newUser = new User() { id = selectedUser.id, rol = (Rol)cbRol.SelectedItem, name = tbName.Text, password = tbPass.Text == "" ? selectedUser.password : CryptographyHelper.hash(tbPass.Text), intentosLogin = 0 };
            userMngr.updateUser(newUser);
            refreshUserList();
            refreshTreeView((Familia)newUser.rol);
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
            this.Close();
        }
    }
}
