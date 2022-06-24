namespace User_Interface
{
    partial class AltaAlumno
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
            this.lbNombre = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lbApellido = new System.Windows.Forms.Label();
            this.lbAddress = new System.Windows.Forms.Label();
            this.lbBdate = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtFechaN = new System.Windows.Forms.TextBox();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.tbDir = new System.Windows.Forms.TextBox();
            this.tbDni = new System.Windows.Forms.TextBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.gbData = new System.Windows.Forms.GroupBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.gbData.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbNombre
            // 
            this.lbNombre.AutoSize = true;
            this.lbNombre.Location = new System.Drawing.Point(15, 31);
            this.lbNombre.Name = "lbNombre";
            this.lbNombre.Size = new System.Drawing.Size(47, 13);
            this.lbNombre.TabIndex = 18;
            this.lbNombre.Tag = "LB_07";
            this.lbNombre.Text = "Nombre:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(15, 306);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(29, 13);
            this.label14.TabIndex = 28;
            this.label14.Text = "DNI:";
            // 
            // lbApellido
            // 
            this.lbApellido.AutoSize = true;
            this.lbApellido.Location = new System.Drawing.Point(15, 86);
            this.lbApellido.Name = "lbApellido";
            this.lbApellido.Size = new System.Drawing.Size(47, 13);
            this.lbApellido.TabIndex = 20;
            this.lbApellido.Tag = "LB_08";
            this.lbApellido.Text = "Apellido:";
            // 
            // lbAddress
            // 
            this.lbAddress.AutoSize = true;
            this.lbAddress.Location = new System.Drawing.Point(15, 251);
            this.lbAddress.Name = "lbAddress";
            this.lbAddress.Size = new System.Drawing.Size(55, 13);
            this.lbAddress.TabIndex = 26;
            this.lbAddress.Tag = "LB_11";
            this.lbAddress.Text = "Dirección:";
            // 
            // lbBdate
            // 
            this.lbBdate.AutoSize = true;
            this.lbBdate.Location = new System.Drawing.Point(15, 141);
            this.lbBdate.Name = "lbBdate";
            this.lbBdate.Size = new System.Drawing.Size(109, 13);
            this.lbBdate.TabIndex = 22;
            this.lbBdate.Tag = "LB_09";
            this.lbBdate.Text = "Fecha de nacimiento:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 196);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "Email:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(18, 47);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(231, 20);
            this.txtNombre.TabIndex = 29;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(18, 102);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(231, 20);
            this.txtApellido.TabIndex = 30;
            // 
            // txtFechaN
            // 
            this.txtFechaN.Location = new System.Drawing.Point(18, 157);
            this.txtFechaN.Name = "txtFechaN";
            this.txtFechaN.Size = new System.Drawing.Size(231, 20);
            this.txtFechaN.TabIndex = 31;
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(18, 212);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(231, 20);
            this.tbEmail.TabIndex = 32;
            // 
            // tbDir
            // 
            this.tbDir.Location = new System.Drawing.Point(18, 267);
            this.tbDir.Name = "tbDir";
            this.tbDir.Size = new System.Drawing.Size(231, 20);
            this.tbDir.TabIndex = 33;
            // 
            // tbDni
            // 
            this.tbDni.Location = new System.Drawing.Point(18, 322);
            this.tbDni.Name = "tbDni";
            this.tbDni.Size = new System.Drawing.Size(231, 20);
            this.tbDni.TabIndex = 34;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(155, 408);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(132, 23);
            this.btnBack.TabIndex = 35;
            this.btnBack.Tag = "BTN_10";
            this.btnBack.Text = "button1";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.button1_Click);
            // 
            // gbData
            // 
            this.gbData.Controls.Add(this.lbNombre);
            this.gbData.Controls.Add(this.label10);
            this.gbData.Controls.Add(this.tbDni);
            this.gbData.Controls.Add(this.lbBdate);
            this.gbData.Controls.Add(this.tbDir);
            this.gbData.Controls.Add(this.lbAddress);
            this.gbData.Controls.Add(this.tbEmail);
            this.gbData.Controls.Add(this.lbApellido);
            this.gbData.Controls.Add(this.txtFechaN);
            this.gbData.Controls.Add(this.label14);
            this.gbData.Controls.Add(this.txtApellido);
            this.gbData.Controls.Add(this.txtNombre);
            this.gbData.Location = new System.Drawing.Point(15, 24);
            this.gbData.Name = "gbData";
            this.gbData.Size = new System.Drawing.Size(272, 367);
            this.gbData.TabIndex = 37;
            this.gbData.TabStop = false;
            this.gbData.Tag = "GB_04";
            this.gbData.Text = "groupBox2";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(15, 408);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(132, 23);
            this.btnAdd.TabIndex = 36;
            this.btnAdd.Tag = "BTN_09";
            this.btnAdd.Text = "button2";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.button2_Click);
            // 
            // AltaAlumno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 455);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.gbData);
            this.Controls.Add(this.btnBack);
            this.Name = "AltaAlumno";
            this.Tag = "FRM_02";
            this.Text = "AltaAlumno";
            this.Load += new System.EventHandler(this.AltaAlumno_Load);
            this.gbData.ResumeLayout(false);
            this.gbData.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lbNombre;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lbApellido;
        private System.Windows.Forms.Label lbAddress;
        private System.Windows.Forms.Label lbBdate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtFechaN;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.TextBox tbDir;
        private System.Windows.Forms.TextBox tbDni;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.GroupBox gbData;
        private System.Windows.Forms.Button btnAdd;
    }
}