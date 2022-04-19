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
    public partial class Materias : ApplicationForm
    {
        public Materias()
        {
            InitializeComponent();
            this.dgvMaterias.AutoGenerateColumns = false;
        }

        public void Listar()
        {
            try
            {
                MateriaLogic ml = new MateriaLogic();
                this.dgvMaterias.DataSource = ml.GetAllDataTable();
            }
            catch (Exception e)
            {
                this.Notificar("Se produjo un error al intentar mostrar la lista de materias.", e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Materias_Load(object sender, EventArgs e)
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
            MateriaDesktop formMateria = new MateriaDesktop(ApplicationForm.ModoForm.Alta);
            formMateria.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvMaterias.SelectedRows.Count == 1)
            {
                int ID = (int)this.dgvMaterias.SelectedRows[0].Cells[0].Value;
                    //((Business.Entities.Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem).Id;
                MateriaDesktop formMateria = new MateriaDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                formMateria.ShowDialog();
            }
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvMaterias.SelectedRows.Count == 1)
            {
                int ID = (int)this.dgvMaterias.SelectedRows[0].Cells[0].Value;
                MateriaDesktop formMateria = new MateriaDesktop(ID, ApplicationForm.ModoForm.Baja);
                formMateria.ShowDialog();
            }
            this.Listar();
        }

    }
}
