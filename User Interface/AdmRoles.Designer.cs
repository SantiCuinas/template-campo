namespace User_Interface
{
    partial class AdmRoles
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
            this.clbChildren = new System.Windows.Forms.CheckedListBox();
            this.lbRoles = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbNombre = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lbTipo = new System.Windows.Forms.Label();
            this.lbHijos = new System.Windows.Forms.Label();
            this.gbData = new System.Windows.Forms.GroupBox();
            this.cbTipo = new System.Windows.Forms.ComboBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.gbData.SuspendLayout();
            this.SuspendLayout();
            // 
            // clbChildren
            // 
            this.clbChildren.FormattingEnabled = true;
            this.clbChildren.Location = new System.Drawing.Point(9, 122);
            this.clbChildren.Name = "clbChildren";
            this.clbChildren.Size = new System.Drawing.Size(292, 94);
            this.clbChildren.TabIndex = 0;
            // 
            // lbRoles
            // 
            this.lbRoles.FormattingEnabled = true;
            this.lbRoles.Location = new System.Drawing.Point(12, 28);
            this.lbRoles.Name = "lbRoles";
            this.lbRoles.Size = new System.Drawing.Size(120, 277);
            this.lbRoles.TabIndex = 1;
            this.lbRoles.SelectedIndexChanged += new System.EventHandler(this.lbRoles_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Roles";
            // 
            // lbNombre
            // 
            this.lbNombre.AutoSize = true;
            this.lbNombre.Location = new System.Drawing.Point(6, 16);
            this.lbNombre.Name = "lbNombre";
            this.lbNombre.Size = new System.Drawing.Size(44, 13);
            this.lbNombre.TabIndex = 3;
            this.lbNombre.Tag = "LB_04";
            this.lbNombre.Text = "Nombre";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(9, 32);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(292, 20);
            this.tbName.TabIndex = 4;
            // 
            // lbTipo
            // 
            this.lbTipo.AutoSize = true;
            this.lbTipo.Location = new System.Drawing.Point(6, 61);
            this.lbTipo.Name = "lbTipo";
            this.lbTipo.Size = new System.Drawing.Size(28, 13);
            this.lbTipo.TabIndex = 5;
            this.lbTipo.Tag = "LB_13";
            this.lbTipo.Text = "Tipo";
            // 
            // lbHijos
            // 
            this.lbHijos.AutoSize = true;
            this.lbHijos.Location = new System.Drawing.Point(6, 106);
            this.lbHijos.Name = "lbHijos";
            this.lbHijos.Size = new System.Drawing.Size(30, 13);
            this.lbHijos.TabIndex = 7;
            this.lbHijos.Tag = "LB_14";
            this.lbHijos.Text = "Hijos";
            // 
            // gbData
            // 
            this.gbData.Controls.Add(this.cbTipo);
            this.gbData.Controls.Add(this.btnDelete);
            this.gbData.Controls.Add(this.btnUpdate);
            this.gbData.Controls.Add(this.lbNombre);
            this.gbData.Controls.Add(this.btnCreate);
            this.gbData.Controls.Add(this.lbHijos);
            this.gbData.Controls.Add(this.clbChildren);
            this.gbData.Controls.Add(this.tbName);
            this.gbData.Controls.Add(this.lbTipo);
            this.gbData.Location = new System.Drawing.Point(153, 12);
            this.gbData.Name = "gbData";
            this.gbData.Size = new System.Drawing.Size(314, 293);
            this.gbData.TabIndex = 8;
            this.gbData.TabStop = false;
            this.gbData.Tag = "GB_05";
            this.gbData.Text = "Datos rol";
            this.gbData.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // cbTipo
            // 
            this.cbTipo.FormattingEnabled = true;
            this.cbTipo.Items.AddRange(new object[] {
            "familia",
            "patente"});
            this.cbTipo.Location = new System.Drawing.Point(9, 77);
            this.cbTipo.Name = "cbTipo";
            this.cbTipo.Size = new System.Drawing.Size(121, 21);
            this.cbTipo.TabIndex = 12;
            this.cbTipo.SelectedIndexChanged += new System.EventHandler(this.cbTipo_SelectedIndexChanged);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(226, 264);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Tag = "BTN_12";
            this.btnDelete.Text = "Borrar";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(117, 264);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 10;
            this.btnUpdate.Tag = "BTN_11";
            this.btnUpdate.Text = "Actualizar";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(8, 264);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 9;
            this.btnCreate.Tag = "BTN_10";
            this.btnCreate.Text = "Agregar";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(12, 323);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 12;
            this.btnBack.Tag = "BTN_09";
            this.btnBack.Text = "Volver";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.button4_Click);
            // 
            // AdmRoles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 354);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.gbData);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbRoles);
            this.Name = "AdmRoles";
            this.Tag = "BTN_03";
            this.Text = "AdmRoles";
            this.Load += new System.EventHandler(this.AdmRoles_Load);
            this.gbData.ResumeLayout(false);
            this.gbData.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox clbChildren;
        private System.Windows.Forms.ListBox lbRoles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbNombre;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lbTipo;
        private System.Windows.Forms.Label lbHijos;
        private System.Windows.Forms.GroupBox gbData;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.ComboBox cbTipo;
    }
}