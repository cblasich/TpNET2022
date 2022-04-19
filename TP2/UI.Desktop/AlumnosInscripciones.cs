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

namespace UI.Desktop
{
    public partial class AlumnosInscripciones : ApplicationForm
    {
        public AlumnosInscripciones()
        {
            InitializeComponent();
            this.dgvAlumnosInscripciones.AutoGenerateColumns = false;
        }

        public void Listar()
        {
            try
            {
                AlumnoInscripcionLogic aiL = new AlumnoInscripcionLogic();
                this.dgvAlumnosInscripciones.DataSource = aiL.GetAll();
            }
            catch (Exception e)
            {
                this.Notificar("Se produjo un error al intentar mostrar la lista de inscripciones de alumnos.", e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AlumnosInscripciones_Load(object sender, EventArgs e)
        {
            Listar();
        }
 
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            AlumnoInscripcionDesktop formAlumnoInscripcion = new AlumnoInscripcionDesktop(ApplicationForm.ModoForm.Alta);
            formAlumnoInscripcion.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if(this.dgvAlumnosInscripciones.SelectedRows.Count == 1)
            {
                int id = ((Business.Entities.AlumnoInscripcion)this.dgvAlumnosInscripciones.SelectedRows[0].DataBoundItem).Id;
                AlumnoInscripcionDesktop formAlumnoInscripcion = new AlumnoInscripcionDesktop(id,ApplicationForm.ModoForm.Modificacion);
                formAlumnoInscripcion.ShowDialog();
                this.Listar();
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvAlumnosInscripciones.SelectedRows.Count == 1)
            {
                int id = ((Business.Entities.AlumnoInscripcion)this.dgvAlumnosInscripciones.SelectedRows[0].DataBoundItem).Id;
                AlumnoInscripcionDesktop formAlumnoInscripcion = new AlumnoInscripcionDesktop(id, ApplicationForm.ModoForm.Baja);
                formAlumnoInscripcion.ShowDialog();
                this.Listar();
            }
        }
    }
}
