namespace UI.Desktop
{
    partial class AlumnoInscripcionDesktop
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
            this.tlAlumnoInscripcionDesktop = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIdInscripcion = new System.Windows.Forms.TextBox();
            this.lblCurso = new System.Windows.Forms.Label();
            this.cmbCursos = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbAlumnos = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCondicion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNota = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tlAlumnoInscripcionDesktop.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlAlumnoInscripcionDesktop
            // 
            this.tlAlumnoInscripcionDesktop.ColumnCount = 3;
            this.tlAlumnoInscripcionDesktop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlAlumnoInscripcionDesktop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlAlumnoInscripcionDesktop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlAlumnoInscripcionDesktop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlAlumnoInscripcionDesktop.Controls.Add(this.label1, 0, 0);
            this.tlAlumnoInscripcionDesktop.Controls.Add(this.txtIdInscripcion, 1, 0);
            this.tlAlumnoInscripcionDesktop.Controls.Add(this.lblCurso, 0, 1);
            this.tlAlumnoInscripcionDesktop.Controls.Add(this.cmbCursos, 1, 1);
            this.tlAlumnoInscripcionDesktop.Controls.Add(this.label2, 0, 2);
            this.tlAlumnoInscripcionDesktop.Controls.Add(this.cmbAlumnos, 1, 2);
            this.tlAlumnoInscripcionDesktop.Controls.Add(this.label3, 0, 3);
            this.tlAlumnoInscripcionDesktop.Controls.Add(this.txtCondicion, 1, 3);
            this.tlAlumnoInscripcionDesktop.Controls.Add(this.label4, 0, 4);
            this.tlAlumnoInscripcionDesktop.Controls.Add(this.txtNota, 1, 4);
            this.tlAlumnoInscripcionDesktop.Controls.Add(this.btnAceptar, 1, 5);
            this.tlAlumnoInscripcionDesktop.Controls.Add(this.btnCancelar, 2, 5);
            this.tlAlumnoInscripcionDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlAlumnoInscripcionDesktop.Location = new System.Drawing.Point(0, 0);
            this.tlAlumnoInscripcionDesktop.Name = "tlAlumnoInscripcionDesktop";
            this.tlAlumnoInscripcionDesktop.RowCount = 6;
            this.tlAlumnoInscripcionDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlAlumnoInscripcionDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlAlumnoInscripcionDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlAlumnoInscripcionDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlAlumnoInscripcionDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlAlumnoInscripcionDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlAlumnoInscripcionDesktop.Size = new System.Drawing.Size(494, 196);
            this.tlAlumnoInscripcionDesktop.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID Inscripcion";
            // 
            // txtIdInscripcion
            // 
            this.txtIdInscripcion.Location = new System.Drawing.Point(101, 3);
            this.txtIdInscripcion.Name = "txtIdInscripcion";
            this.txtIdInscripcion.ReadOnly = true;
            this.txtIdInscripcion.Size = new System.Drawing.Size(136, 22);
            this.txtIdInscripcion.TabIndex = 2;
            // 
            // lblCurso
            // 
            this.lblCurso.AutoSize = true;
            this.lblCurso.Location = new System.Drawing.Point(3, 28);
            this.lblCurso.Name = "lblCurso";
            this.lblCurso.Size = new System.Drawing.Size(45, 17);
            this.lblCurso.TabIndex = 7;
            this.lblCurso.Text = "Curso";
            // 
            // cmbCursos
            // 
            this.cmbCursos.FormattingEnabled = true;
            this.cmbCursos.Location = new System.Drawing.Point(101, 31);
            this.cmbCursos.Name = "cmbCursos";
            this.cmbCursos.Size = new System.Drawing.Size(304, 24);
            this.cmbCursos.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Alumno";
            // 
            // cmbAlumnos
            // 
            this.cmbAlumnos.FormattingEnabled = true;
            this.cmbAlumnos.Location = new System.Drawing.Point(101, 61);
            this.cmbAlumnos.Name = "cmbAlumnos";
            this.cmbAlumnos.Size = new System.Drawing.Size(304, 24);
            this.cmbAlumnos.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Condición";
            // 
            // txtCondicion
            // 
            this.txtCondicion.Location = new System.Drawing.Point(101, 91);
            this.txtCondicion.Name = "txtCondicion";
            this.txtCondicion.Size = new System.Drawing.Size(114, 22);
            this.txtCondicion.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Nota";
            // 
            // txtNota
            // 
            this.txtNota.Location = new System.Drawing.Point(101, 119);
            this.txtNota.Name = "txtNota";
            this.txtNota.Size = new System.Drawing.Size(114, 22);
            this.txtNota.TabIndex = 6;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.Location = new System.Drawing.Point(330, 159);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 34);
            this.btnAceptar.TabIndex = 10;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancelar.Location = new System.Drawing.Point(411, 159);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 34);
            this.btnCancelar.TabIndex = 14;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // AlumnoInscripcionDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 196);
            this.Controls.Add(this.tlAlumnoInscripcionDesktop);
            this.Name = "AlumnoInscripcionDesktop";
            this.Text = "AlumnoInscripcionDesktop";
            this.tlAlumnoInscripcionDesktop.ResumeLayout(false);
            this.tlAlumnoInscripcionDesktop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlAlumnoInscripcionDesktop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIdInscripcion;
        private System.Windows.Forms.TextBox txtCondicion;
        private System.Windows.Forms.TextBox txtNota;
        private System.Windows.Forms.Label lblCurso;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.ComboBox cmbAlumnos;
        private System.Windows.Forms.ComboBox cmbCursos;
        private System.Windows.Forms.Button btnCancelar;
    }
}