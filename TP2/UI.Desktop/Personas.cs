using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;
using Util;

namespace UI.Desktop
{
    public partial class Personas : ApplicationForm
    {
        public Personas()
        {
            InitializeComponent();
            this.dgvPersonas.AutoGenerateColumns = false;
        }

        protected virtual void Listar()
        {  
            try
            {
                PersonaLogic pl = new PersonaLogic();
                this.dgvPersonas.DataSource = pl.GetAllDataTable();
            }
            catch (Exception e)
            {
                this.Notificar("Se produjo un error al intentar mostrar la lista de personas.", e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Personas_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            PersonaDesktop formPersona = new PersonaDesktop(ApplicationForm.ModoForm.Alta);
            formPersona.ShowDialog();
            this.Listar();  
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvPersonas.SelectedRows.Count == 1)
            {
                int ID = (int)this.dgvPersonas.SelectedRows[0].Cells[0].Value;
                PersonaDesktop formPersona = new PersonaDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                formPersona.ShowDialog();
            }
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvPersonas.SelectedRows.Count == 1)
            {
                int ID = (int)this.dgvPersonas.SelectedRows[0].Cells[0].Value;
                PersonaDesktop formPersona = new PersonaDesktop(ID, ApplicationForm.ModoForm.Baja);
                formPersona.ShowDialog();
            }
            this.Listar();
        }

        private void dgvPersonas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvPersonas.Columns[e.ColumnIndex].Name == "tipoPersona")
            { 
               Util.Enumeradores.TiposPersonas enumValue = (Util.Enumeradores.TiposPersonas)e.Value ;
               switch(enumValue) 
               {
                   case Enumeradores.TiposPersonas.Administrador:
                        e.Value = "Administrador";
                        break;
                   case Enumeradores.TiposPersonas.Alumno:
                        e.Value = "Alumno";
                        break;
                   case Enumeradores.TiposPersonas.Docente:
                        e.Value = "Docente";
                        break;
               }  
             }
        }

    }
}
