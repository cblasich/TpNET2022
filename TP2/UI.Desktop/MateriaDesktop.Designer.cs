namespace UI.Desktop
{
    partial class MateriaDesktop
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
            this.tlMateriaDesktop = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtHorasSemanales = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.cmbPlanes = new System.Windows.Forms.ComboBox();
            this.txtHorasTotales = new System.Windows.Forms.TextBox();
            this.tlMateriaDesktop.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlMateriaDesktop
            // 
            this.tlMateriaDesktop.ColumnCount = 4;
            this.tlMateriaDesktop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlMateriaDesktop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlMateriaDesktop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlMateriaDesktop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlMateriaDesktop.Controls.Add(this.label1, 0, 0);
            this.tlMateriaDesktop.Controls.Add(this.label2, 0, 1);
            this.tlMateriaDesktop.Controls.Add(this.label3, 2, 0);
            this.tlMateriaDesktop.Controls.Add(this.label4, 2, 1);
            this.tlMateriaDesktop.Controls.Add(this.txtId, 1, 0);
            this.tlMateriaDesktop.Controls.Add(this.txtDescripcion, 1, 1);
            this.tlMateriaDesktop.Controls.Add(this.txtHorasSemanales, 3, 0);
            this.tlMateriaDesktop.Controls.Add(this.label5, 0, 2);
            this.tlMateriaDesktop.Controls.Add(this.btnAceptar, 2, 3);
            this.tlMateriaDesktop.Controls.Add(this.btnCancelar, 3, 3);
            this.tlMateriaDesktop.Controls.Add(this.cmbPlanes, 1, 2);
            this.tlMateriaDesktop.Controls.Add(this.txtHorasTotales, 3, 1);
            this.tlMateriaDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlMateriaDesktop.Location = new System.Drawing.Point(0, 0);
            this.tlMateriaDesktop.Name = "tlMateriaDesktop";
            this.tlMateriaDesktop.RowCount = 4;
            this.tlMateriaDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlMateriaDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlMateriaDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlMateriaDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlMateriaDesktop.Size = new System.Drawing.Size(457, 125);
            this.tlMateriaDesktop.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Descripción";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(218, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Hs semanales";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(218, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Hs totales";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(91, 3);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(100, 22);
            this.txtId.TabIndex = 4;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(91, 31);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(100, 22);
            this.txtDescripcion.TabIndex = 5;
            // 
            // txtHorasSemanales
            // 
            this.txtHorasSemanales.Location = new System.Drawing.Point(321, 3);
            this.txtHorasSemanales.Name = "txtHorasSemanales";
            this.txtHorasSemanales.Size = new System.Drawing.Size(100, 22);
            this.txtHorasSemanales.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "Plan";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(218, 89);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 33);
            this.btnAceptar.TabIndex = 8;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(321, 89);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(76, 33);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // cmbPlanes
            // 
            this.cmbPlanes.DisplayMember = "DescPlan";
            this.cmbPlanes.FormattingEnabled = true;
            this.cmbPlanes.Location = new System.Drawing.Point(91, 59);
            this.cmbPlanes.Name = "cmbPlanes";
            this.cmbPlanes.Size = new System.Drawing.Size(121, 24);
            this.cmbPlanes.TabIndex = 10;
            this.cmbPlanes.ValueMember = "Id";
            // 
            // txtHorasTotales
            // 
            this.txtHorasTotales.Location = new System.Drawing.Point(321, 31);
            this.txtHorasTotales.Name = "txtHorasTotales";
            this.txtHorasTotales.Size = new System.Drawing.Size(100, 22);
            this.txtHorasTotales.TabIndex = 11;
            // 
            // MateriaDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 125);
            this.Controls.Add(this.tlMateriaDesktop);
            this.Name = "MateriaDesktop";
            this.Text = "MateriaDesktop";
            this.tlMateriaDesktop.ResumeLayout(false);
            this.tlMateriaDesktop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlMateriaDesktop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtHorasSemanales;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ComboBox cmbPlanes;
        private System.Windows.Forms.TextBox txtHorasTotales;
    }
}