namespace User_Interface
{
    partial class AdmUsuarios
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.lbRol = new System.Windows.Forms.Label();
            this.lbId = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.cbRol = new System.Windows.Forms.ComboBox();
            this.gbDatos = new System.Windows.Forms.GroupBox();
            this.lbBloqueo = new System.Windows.Forms.Label();
            this.btDesbloqueo = new System.Windows.Forms.Button();
            this.tbPass = new System.Windows.Forms.TextBox();
            this.lbPass = new System.Windows.Forms.Label();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.lbUsuarios = new System.Windows.Forms.ListBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.gbDatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(6, 63);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(44, 13);
            this.lbName.TabIndex = 1;
            this.lbName.Tag = "LB_04";
            this.lbName.Text = "Nombre";
            // 
            // lbRol
            // 
            this.lbRol.AutoSize = true;
            this.lbRol.Location = new System.Drawing.Point(6, 117);
            this.lbRol.Name = "lbRol";
            this.lbRol.Size = new System.Drawing.Size(23, 13);
            this.lbRol.TabIndex = 2;
            this.lbRol.Tag = "LB_06";
            this.lbRol.Text = "Rol";
            // 
            // lbId
            // 
            this.lbId.AutoSize = true;
            this.lbId.Location = new System.Drawing.Point(6, 35);
            this.lbId.Name = "lbId";
            this.lbId.Size = new System.Drawing.Size(0, 13);
            this.lbId.TabIndex = 3;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(6, 79);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(126, 20);
            this.tbName.TabIndex = 4;
            // 
            // cbRol
            // 
            this.cbRol.FormattingEnabled = true;
            this.cbRol.Location = new System.Drawing.Point(6, 133);
            this.cbRol.Name = "cbRol";
            this.cbRol.Size = new System.Drawing.Size(126, 21);
            this.cbRol.TabIndex = 5;
            // 
            // gbDatos
            // 
            this.gbDatos.Controls.Add(this.lbBloqueo);
            this.gbDatos.Controls.Add(this.btDesbloqueo);
            this.gbDatos.Controls.Add(this.tbPass);
            this.gbDatos.Controls.Add(this.lbPass);
            this.gbDatos.Controls.Add(this.btnBorrar);
            this.gbDatos.Controls.Add(this.btnUpdate);
            this.gbDatos.Controls.Add(this.btnCreate);
            this.gbDatos.Controls.Add(this.cbRol);
            this.gbDatos.Controls.Add(this.label1);
            this.gbDatos.Controls.Add(this.tbName);
            this.gbDatos.Controls.Add(this.lbName);
            this.gbDatos.Controls.Add(this.lbId);
            this.gbDatos.Controls.Add(this.lbRol);
            this.gbDatos.Location = new System.Drawing.Point(199, 12);
            this.gbDatos.Name = "gbDatos";
            this.gbDatos.Size = new System.Drawing.Size(316, 251);
            this.gbDatos.TabIndex = 6;
            this.gbDatos.TabStop = false;
            this.gbDatos.Tag = "GB_03";
            this.gbDatos.Text = "Datos del usuario";
            this.gbDatos.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // lbBloqueo
            // 
            this.lbBloqueo.AutoSize = true;
            this.lbBloqueo.ForeColor = System.Drawing.Color.Red;
            this.lbBloqueo.Location = new System.Drawing.Point(9, 194);
            this.lbBloqueo.Name = "lbBloqueo";
            this.lbBloqueo.Size = new System.Drawing.Size(129, 13);
            this.lbBloqueo.TabIndex = 12;
            this.lbBloqueo.Tag = "LB_03";
            this.lbBloqueo.Text = "El usuario esta bloqueado";
            this.lbBloqueo.Visible = false;
            // 
            // btDesbloqueo
            // 
            this.btDesbloqueo.Enabled = false;
            this.btDesbloqueo.Location = new System.Drawing.Point(170, 131);
            this.btDesbloqueo.Name = "btDesbloqueo";
            this.btDesbloqueo.Size = new System.Drawing.Size(123, 23);
            this.btDesbloqueo.TabIndex = 11;
            this.btDesbloqueo.Tag = "BTN_13";
            this.btDesbloqueo.Text = "Desbloquear";
            this.btDesbloqueo.UseVisualStyleBackColor = true;
            this.btDesbloqueo.Click += new System.EventHandler(this.btDesbloqueo_Click);
            // 
            // tbPass
            // 
            this.tbPass.Location = new System.Drawing.Point(167, 79);
            this.tbPass.Name = "tbPass";
            this.tbPass.Size = new System.Drawing.Size(126, 20);
            this.tbPass.TabIndex = 10;
            // 
            // lbPass
            // 
            this.lbPass.AutoSize = true;
            this.lbPass.Location = new System.Drawing.Point(167, 63);
            this.lbPass.Name = "lbPass";
            this.lbPass.Size = new System.Drawing.Size(96, 13);
            this.lbPass.TabIndex = 9;
            this.lbPass.Tag = "LB_05";
            this.lbPass.Text = "Nueva Contraseña";
            // 
            // btnBorrar
            // 
            this.btnBorrar.Location = new System.Drawing.Point(230, 222);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(75, 23);
            this.btnBorrar.TabIndex = 8;
            this.btnBorrar.Tag = "BTN_12";
            this.btnBorrar.Text = "Borrar";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(121, 222);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 7;
            this.btnUpdate.Tag = "BTN_11";
            this.btnUpdate.Text = "Actualizar";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(12, 222);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 6;
            this.btnCreate.Tag = "BTN_10";
            this.btnCreate.Text = "Agregar";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbUsuarios
            // 
            this.lbUsuarios.FormattingEnabled = true;
            this.lbUsuarios.Location = new System.Drawing.Point(12, 12);
            this.lbUsuarios.Name = "lbUsuarios";
            this.lbUsuarios.Size = new System.Drawing.Size(181, 251);
            this.lbUsuarios.TabIndex = 7;
            this.lbUsuarios.SelectedIndexChanged += new System.EventHandler(this.lbUsuarios_SelectedIndexChanged);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(12, 283);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 9;
            this.btnBack.Tag = "BTN_09";
            this.btnBack.Text = "Volver";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.button4_Click);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(521, 12);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(181, 251);
            this.treeView1.TabIndex = 10;
            // 
            // AdmUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 318);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lbUsuarios);
            this.Controls.Add(this.gbDatos);
            this.Name = "AdmUsuarios";
            this.Tag = "BTN_02";
            this.Text = "AdmUsuarios";
            this.Load += new System.EventHandler(this.AdmUsuarios_Load);
            this.gbDatos.ResumeLayout(false);
            this.gbDatos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbRol;
        private System.Windows.Forms.Label lbId;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.ComboBox cbRol;
        private System.Windows.Forms.GroupBox gbDatos;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.ListBox lbUsuarios;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.TextBox tbPass;
        private System.Windows.Forms.Label lbPass;
        private System.Windows.Forms.Button btDesbloqueo;
        private System.Windows.Forms.Label lbBloqueo;
        private System.Windows.Forms.TreeView treeView1;
    }
}