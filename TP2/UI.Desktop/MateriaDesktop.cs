using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;

namespace UI.Desktop
{
    public partial class MateriaDesktop : ApplicationForm
    {
        public MateriaDesktop()
        {
            InitializeComponent();
        }

        public MateriaDesktop(ModoForm modo):this()
        {
            this.Modo = modo;
            this.CargarCombo();
        }

        public MateriaDesktop(int id, ModoForm modo):this()
        {
            this.Modo = modo;
            MateriaLogic matLogic = new MateriaLogic();
            this.MateriaActual = matLogic.GetOne(id);
            this.CargarCombo();
            this.MapearDeDatos();
        }

        private Materia _materiaActual;
        public Materia MateriaActual
        {
            get { return _materiaActual; }
            set { _materiaActual = value; }
        }

        public override void MapearDeDatos()
        {
            this.txtId.Text = this.MateriaActual.Id.ToString();
            this.txtDescripcion.Text = this.MateriaActual.DescMateria;
            this.cmbPlanes.SelectedItem = this.MateriaActual.IdPlan;
            this.txtHorasSemanales.Text = this.MateriaActual.HorasSemanales.ToString();
            this.txtHorasTotales.Text = this.MateriaActual.HorasTotales.ToString();

            switch (this.Modo)  //texto del boton Aceptar y del winForm
            {
                case ModoForm.Alta:
                    this.Text = "Alta de Materia";
                    this.btnAceptar.Text = "Guardar";
                    break;

                case ModoForm.Modificacion:
                    this.Text = "Modificación de Materia";
                    this.btnAceptar.Text = "Guardar";
                    break;

                case ModoForm.Baja:
                    this.Text = "Baja de Materia";
                    this.btnAceptar.Text = "Eliminar";
                    break;

                case ModoForm.Consulta:
                    this.Text = "Consulta de Materia";
                    this.btnAceptar.Text = "Aceptar";
                    break;
            }
        }

        public override void MapearADatos()
        {
            if (this.Modo == ModoForm.Alta)
            {
                MateriaActual = new Materia();
                MateriaActual.State = BusinessEntity.States.New;
            }
            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                MateriaActual.DescMateria = this.txtDescripcion.Text.Trim();
                MateriaActual.IdPlan = (int)this.cmbPlanes.SelectedValue;
                MateriaActual.HorasSemanales = Convert.ToInt32(this.txtHorasSemanales.Text.Trim()); 
                MateriaActual.HorasTotales = Convert.ToInt32(this.txtHorasTotales.Text.Trim());

                if (this.Modo == ModoForm.Modificacion)
                {
                    MateriaActual.Id = Convert.ToInt16(this.txtId.Text);
                    MateriaActual.State = BusinessEntity.States.Modified;
                }
            }
            if (this.Modo == ModoForm.Baja)
            {
                MateriaActual.State = BusinessEntity.States.Deleted;
            }
        }

        public void CargarCombo()
        {
            cmbPlanes.DataSource = new PlanLogic().GetAll();
        }
        public override void GuardarCambios()
        {
            MateriaLogic matLogic = new MateriaLogic();
            if (this.Modo == ModoForm.Alta)
            {
                Materia matNueva = new Materia();
                this.MateriaActual = matNueva;
            }
            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                this.MapearADatos();
                matLogic.Save(this.MateriaActual);
            }
            else if (this.Modo == ModoForm.Baja)
            {
                try
                {
                    matLogic.Delete(MateriaActual.Id);
                }
                catch (Exception e)
                {
                    this.Notificar(this.Text, e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public override bool Validar()
        {
            string mensaje = "";

            if (String.IsNullOrEmpty(this.txtDescripcion.Text.Trim()))
            {
                mensaje += "- Complete el campo Descripción.\n";
            }
            if (this.cmbPlanes.SelectedIndex == -1) //.Text.Trim()))
            {
                mensaje += "- Seleccione un plan.\n";
            }
            if (String.IsNullOrEmpty(this.txtHorasSemanales.Text.Trim()))
            {
                mensaje += "- Complete el campo Horas semanales.\n";
            }
            if (String.IsNullOrEmpty(this.txtHorasTotales.Text.Trim()))
            {
                mensaje += "- Complete el campo Horas totales.\n";
            }
            if (mensaje.Length == 0)
            {
                return true;
            }
            else
            {
                this.Notificar("Advertencia", mensaje, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public override void Notificar(string titulo, string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, titulo, botones, icono);
        }
        public override void Notificar(string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            this.Notificar(this.Text, mensaje, botones, icono);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.Validar())
            {
                try
                {
                    this.GuardarCambios();
                    this.Close();
                }
                catch (Exception ex)
                {
                    this.Notificar(this.Text, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
