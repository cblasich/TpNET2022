namespace UI.Desktop
{
    partial class DocentesCursos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DocentesCursos));
            this.tscDocentesCursos = new System.Windows.Forms.ToolStripContainer();
            this.tsDocentesCursos = new System.Windows.Forms.ToolStrip();
            this.tsbNuevo = new System.Windows.Forms.ToolStripButton();
            this.tsbEditar = new System.Windows.Forms.ToolStripButton();
            this.tsbEliminar = new System.Windows.Forms.ToolStripButton();
            this.tlDocentesCursos = new System.Windows.Forms.TableLayoutPanel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.cargo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdDocente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdCurso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdDictado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDocentesCursos = new System.Windows.Forms.DataGridView();
            this.tscDocentesCursos.ContentPanel.SuspendLayout();
            this.tscDocentesCursos.TopToolStripPanel.SuspendLayout();
            this.tscDocentesCursos.SuspendLayout();
            this.tsDocentesCursos.SuspendLayout();
            this.tlDocentesCursos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocentesCursos)).BeginInit();
            this.SuspendLayout();
            // 
            // tscDocentesCursos
            // 
            // 
            // tscDocentesCursos.ContentPanel
            // 
            this.tscDocentesCursos.ContentPanel.Controls.Add(this.tlDocentesCursos);
            this.tscDocentesCursos.ContentPanel.Size = new System.Drawing.Size(504, 217);
            this.tscDocentesCursos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tscDocentesCursos.Location = new System.Drawing.Point(0, 0);
            this.tscDocentesCursos.Name = "tscDocentesCursos";
            this.tscDocentesCursos.Size = new System.Drawing.Size(504, 244);
            this.tscDocentesCursos.TabIndex = 0;
            this.tscDocentesCursos.Text = "toolStripContainer1";
            // 
            // tscDocentesCursos.TopToolStripPanel
            // 
            this.tscDocentesCursos.TopToolStripPanel.Controls.Add(this.tsDocentesCursos);
            // 
            // tsDocentesCursos
            // 
            this.tsDocentesCursos.Dock = System.Windows.Forms.DockStyle.None;
            this.tsDocentesCursos.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsDocentesCursos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNuevo,
            this.tsbEditar,
            this.tsbEliminar});
            this.tsDocentesCursos.Location = new System.Drawing.Point(3, 0);
            this.tsDocentesCursos.Name = "tsDocentesCursos";
            this.tsDocentesCursos.Size = new System.Drawing.Size(84, 27);
            this.tsDocentesCursos.TabIndex = 0;
            // 
            // tsbNuevo
            // 
            this.tsbNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNuevo.Image = ((System.Drawing.Image)(resources.GetObject("tsbNuevo.Image")));
            this.tsbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNuevo.Name = "tsbNuevo";
            this.tsbNuevo.Size = new System.Drawing.Size(24, 24);
            this.tsbNuevo.Text = "toolStripButton1";
            this.tsbNuevo.ToolTipText = "Nuevo";
            this.tsbNuevo.Click += new System.EventHandler(this.tsbNuevo_Click);
            // 
            // tsbEditar
            // 
            this.tsbEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEditar.Image = ((System.Drawing.Image)(resources.GetObject("tsbEditar.Image")));
            this.tsbEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEditar.Name = "tsbEditar";
            this.tsbEditar.Size = new System.Drawing.Size(24, 24);
            this.tsbEditar.Text = "toolStripButton2";
            this.tsbEditar.ToolTipText = "Editar";
            this.tsbEditar.Click += new System.EventHandler(this.tsbEditar_Click);
            // 
            // tsbEliminar
            // 
            this.tsbEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEliminar.Image = ((System.Drawing.Image)(resources.GetObject("tsbEliminar.Image")));
            this.tsbEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEliminar.Name = "tsbEliminar";
            this.tsbEliminar.Size = new System.Drawing.Size(24, 24);
            this.tsbEliminar.Text = "toolStripButton3";
            this.tsbEliminar.ToolTipText = "Eliminar";
            this.tsbEliminar.Click += new System.EventHandler(this.tsbEliminar_Click);
            // 
            // tlDocentesCursos
            // 
            this.tlDocentesCursos.ColumnCount = 2;
            this.tlDocentesCursos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlDocentesCursos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlDocentesCursos.Controls.Add(this.dgvDocentesCursos, 0, 0);
            this.tlDocentesCursos.Controls.Add(this.btnActualizar, 0, 1);
            this.tlDocentesCursos.Controls.Add(this.btnSalir, 1, 1);
            this.tlDocentesCursos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlDocentesCursos.Location = new System.Drawing.Point(0, 0);
            this.tlDocentesCursos.Name = "tlDocentesCursos";
            this.tlDocentesCursos.RowCount = 2;
            this.tlDocentesCursos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlDocentesCursos.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlDocentesCursos.Size = new System.Drawing.Size(504, 217);
            this.tlDocentesCursos.TabIndex = 0;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(426, 184);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 30);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.Location = new System.Drawing.Point(340, 184);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(80, 30);
            this.btnActualizar.TabIndex = 1;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // cargo
            // 
            this.cargo.DataPropertyName = "Cargo";
            this.cargo.HeaderText = "Cargo";
            this.cargo.Name = "cargo";
            this.cargo.ReadOnly = true;
            // 
            // IdDocente
            // 
            this.IdDocente.DataPropertyName = "IdDocente";
            this.IdDocente.HeaderText = "Id Docente";
            this.IdDocente.Name = "IdDocente";
            this.IdDocente.ReadOnly = true;
            // 
            // IdCurso
            // 
            this.IdCurso.DataPropertyName = "IdCurso";
            this.IdCurso.HeaderText = "Id Curso";
            this.IdCurso.Name = "IdCurso";
            this.IdCurso.ReadOnly = true;
            // 
            // IdDictado
            // 
            this.IdDictado.DataPropertyName = "IdDictado";
            this.IdDictado.HeaderText = "ID Dictado";
            this.IdDictado.Name = "IdDictado";
            this.IdDictado.ReadOnly = true;
            // 
            // dgvDocentesCursos
            // 
            this.dgvDocentesCursos.AllowUserToAddRows = false;
            this.dgvDocentesCursos.AllowUserToDeleteRows = false;
            this.dgvDocentesCursos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocentesCursos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdDictado,
            this.IdCurso,
            this.IdDocente,
            this.cargo});
            this.tlDocentesCursos.SetColumnSpan(this.dgvDocentesCursos, 2);
            this.dgvDocentesCursos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDocentesCursos.Location = new System.Drawing.Point(3, 3);
            this.dgvDocentesCursos.MultiSelect = false;
            this.dgvDocentesCursos.Name = "dgvDocentesCursos";
            this.dgvDocentesCursos.ReadOnly = true;
            this.dgvDocentesCursos.RowTemplate.Height = 24;
            this.dgvDocentesCursos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDocentesCursos.Size = new System.Drawing.Size(498, 175);
            this.dgvDocentesCursos.TabIndex = 0;
            // 
            // DocentesCursos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 244);
            this.Controls.Add(this.tscDocentesCursos);
            this.Name = "DocentesCursos";
            this.Text = "DocentesCursos";
            this.Load += new System.EventHandler(this.DocentesCursos_Load);
            this.tscDocentesCursos.ContentPanel.ResumeLayout(false);
            this.tscDocentesCursos.TopToolStripPanel.ResumeLayout(false);
            this.tscDocentesCursos.TopToolStripPanel.PerformLayout();
            this.tscDocentesCursos.ResumeLayout(false);
            this.tscDocentesCursos.PerformLayout();
            this.tsDocentesCursos.ResumeLayout(false);
            this.tsDocentesCursos.PerformLayout();
            this.tlDocentesCursos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocentesCursos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer tscDocentesCursos;
        private System.Windows.Forms.ToolStrip tsDocentesCursos;
        private System.Windows.Forms.ToolStripButton tsbNuevo;
        private System.Windows.Forms.ToolStripButton tsbEditar;
        private System.Windows.Forms.ToolStripButton tsbEliminar;
        private System.Windows.Forms.TableLayoutPanel tlDocentesCursos;
        private System.Windows.Forms.DataGridView dgvDocentesCursos;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdDictado;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdCurso;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdDocente;
        private System.Windows.Forms.DataGridViewTextBoxColumn cargo;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnSalir;
    }
}