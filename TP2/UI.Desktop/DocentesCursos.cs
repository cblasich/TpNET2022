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
    public partial class DocentesCursos : ApplicationForm
    {
        public DocentesCursos()
        {
            InitializeComponent();
            this.dgvDocentesCursos.AutoGenerateColumns = false;
        }

        public void Listar()
        {
            try
            {
                DocenteCursoLogic dcL = new DocenteCursoLogic();
                this.dgvDocentesCursos.DataSource = dcL.GetAll();
            }
            catch (Exception e)
            {
                this.Notificar("Se produjo un error al intentar mostrar la lista de docentes cursos.", e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DocentesCursos_Load(object sender, EventArgs e)
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
            DocenteCursoDesktop formDocenteCurso = new DocenteCursoDesktop(ApplicationForm.ModoForm.Alta);
            formDocenteCurso.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if(this.dgvDocentesCursos.SelectedRows.Count == 1)
            {
                int id = ((Business.Entities.DocenteCurso)this.dgvDocentesCursos.SelectedRows[0].DataBoundItem).Id;
                DocenteCursoDesktop formDocenteCurso = new DocenteCursoDesktop(id,ApplicationForm.ModoForm.Modificacion);
                formDocenteCurso.ShowDialog();
                this.Listar();
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvDocentesCursos.SelectedRows.Count == 1)
            {
                int id = ((Business.Entities.DocenteCurso)this.dgvDocentesCursos.SelectedRows[0].DataBoundItem).Id;
                DocenteCursoDesktop formDocenteCurso = new DocenteCursoDesktop(id, ApplicationForm.ModoForm.Baja);
                formDocenteCurso.ShowDialog();
                this.Listar();
            }
        }

    }
}
