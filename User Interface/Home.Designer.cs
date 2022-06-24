namespace User_Interface
{
    partial class Home
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
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.tbDniVerificar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnVerDatos = new System.Windows.Forms.Button();
            this.btnAlta = new System.Windows.Forms.Button();
            this.btnCursos = new System.Windows.Forms.Button();
            this.gbEA = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.gbEA.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 237);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(194, 23);
            this.button1.TabIndex = 0;
            this.button1.Tag = "BTN_01";
            this.button1.Text = "Log Out";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "ESP",
            "ENG"});
            this.comboBox1.Location = new System.Drawing.Point(417, 239);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(65, 21);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.Text = "ENG";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(115, 21);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(240, 23);
            this.button2.TabIndex = 6;
            this.button2.Tag = "BTN_02";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Location = new System.Drawing.Point(12, 124);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(470, 94);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "GB_01";
            this.groupBox1.Text = "groupBox1";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(115, 50);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(240, 23);
            this.button3.TabIndex = 7;
            this.button3.Tag = "BTN_03";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // tbDniVerificar
            // 
            this.tbDniVerificar.Location = new System.Drawing.Point(11, 38);
            this.tbDniVerificar.Name = "tbDniVerificar";
            this.tbDniVerificar.Size = new System.Drawing.Size(447, 20);
            this.tbDniVerificar.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "DNI";
            // 
            // btnVerDatos
            // 
            this.btnVerDatos.Location = new System.Drawing.Point(11, 64);
            this.btnVerDatos.Name = "btnVerDatos";
            this.btnVerDatos.Size = new System.Drawing.Size(145, 23);
            this.btnVerDatos.TabIndex = 10;
            this.btnVerDatos.Tag = "BTN_04";
            this.btnVerDatos.Text = "Verificar Datos";
            this.btnVerDatos.UseVisualStyleBackColor = true;
            this.btnVerDatos.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnAlta
            // 
            this.btnAlta.Location = new System.Drawing.Point(162, 64);
            this.btnAlta.Name = "btnAlta";
            this.btnAlta.Size = new System.Drawing.Size(145, 23);
            this.btnAlta.TabIndex = 11;
            this.btnAlta.Tag = "BTN_06";
            this.btnAlta.Text = "Dar de alta";
            this.btnAlta.UseVisualStyleBackColor = true;
            this.btnAlta.Click += new System.EventHandler(this.button5_Click);
            // 
            // btnCursos
            // 
            this.btnCursos.Location = new System.Drawing.Point(313, 64);
            this.btnCursos.Name = "btnCursos";
            this.btnCursos.Size = new System.Drawing.Size(145, 23);
            this.btnCursos.TabIndex = 12;
            this.btnCursos.Tag = "BTN_07";
            this.btnCursos.Text = "Cursos";
            this.btnCursos.UseVisualStyleBackColor = true;
            this.btnCursos.Click += new System.EventHandler(this.button6_Click);
            // 
            // gbEA
            // 
            this.gbEA.Controls.Add(this.btnCursos);
            this.gbEA.Controls.Add(this.tbDniVerificar);
            this.gbEA.Controls.Add(this.btnAlta);
            this.gbEA.Controls.Add(this.label1);
            this.gbEA.Controls.Add(this.btnVerDatos);
            this.gbEA.Location = new System.Drawing.Point(12, 18);
            this.gbEA.Name = "gbEA";
            this.gbEA.Size = new System.Drawing.Size(470, 100);
            this.gbEA.TabIndex = 13;
            this.gbEA.TabStop = false;
            this.gbEA.Tag = "GB_02";
            this.gbEA.Text = "groupBox2";
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 272);
            this.Controls.Add(this.gbEA);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.Name = "Home";
            this.Tag = "FRM_01";
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.gbEA.ResumeLayout(false);
            this.gbEA.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox tbDniVerificar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnVerDatos;
        private System.Windows.Forms.Button btnAlta;
        private System.Windows.Forms.Button btnCursos;
        private System.Windows.Forms.GroupBox gbEA;
    }
}