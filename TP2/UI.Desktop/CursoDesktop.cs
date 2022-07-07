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
    public partial class CursoDesktop : ApplicationForm
    {

        private Curso _cursoActual;
        public Curso CursoActual
        {
            get { return _cursoActual; }
            set { _cursoActual = value; }
        }

        public CursoDesktop()
        {
            InitializeComponent();
        }
         public CursoDesktop(ModoForm modo):this () 
        //este constructor servirá para las altas
        {
            this.Modo = modo;
            this.CambiarBotones();
            this.CursoActual = new Curso();
            this.CargarCombos(); 
        }
        public CursoDesktop(int id, ModoForm modo):this()
        {
            this.Modo = modo;
            CursoLogic cursoLogic = new CursoLogic();
            this.CambiarBotones();

            try
            {
                this.CursoActual = cursoLogic.GetOne(id);
                this.CargarCombos();
                this.MapearDeDatos();
            }
            catch (Exception e)
            {
                this.Notificar(e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CargarCombos()
        {
            cbxComisiones.DataSource = new ComisionLogic().GetAll();
            cbxMaterias.DataSource = new MateriaLogic().GetAll();
        }

        public void CambiarBotones()
        {
            //Para cambiar textos de ventanas y botones
            switch (this.Modo)
            {
                case ModoForm.Alta:
                    this.Text = "Alta de curso";
                    this.btnAceptar.Text = "Guardar";
                    break;

                case ModoForm.Modificacion:
                    this.Text = "Modificación de curso";
                    this.btnAceptar.Text = "Guardar";
                    break;

                case ModoForm.Baja:
                    this.Text = "Baja de curso";
                    this.btnAceptar.Text = "Eliminar";
                    this.txtCupo.Enabled = false;
                    this.txtAnio.Enabled = false;
                    this.cbxMaterias.Enabled = false;
                    this.cbxComisiones.Enabled = false;
                    break;

                case ModoForm.Consulta:
                    this.Text = "Consulta de Plan";
                    this.btnAceptar.Text = "Aceptar";
                    break;
            }
        }

        public override void MapearDeDatos()
        {
            this.txtIdCurso.Text = this.CursoActual.Id.ToString();
            this.cbxMaterias.SelectedValue = this.CursoActual.IdMateria;
            this.cbxComisiones.SelectedValue = this.CursoActual.IdComision;
            this.txtCupo.Text = this.CursoActual.Cupo.ToString();
            this.txtAnio.Text = this.CursoActual.AnioCalendario.ToString();

            //seteo del texto del botón Aceptar según Modo del formulario
            switch (this.Modo)
            {
                case ModoForm.Alta:
                    this.Text = "Alta de Curso";
                    this.btnAceptar.Text = "Guardar";
                    break;

                case ModoForm.Modificacion:
                    this.Text = "Modificación de Curso";
                    this.btnAceptar.Text = "Guardar";
                    break;

                case ModoForm.Baja:
                    this.Text = "Baja de Curso";
                    this.btnAceptar.Text = "Eliminar";
                    break;

                case ModoForm.Consulta:
                    this.Text = "Consulta de Curso";
                    this.btnAceptar.Text = "Aceptar";
                    break;
            }
        }
        public override void MapearADatos()
        {
            if (this.Modo == ModoForm.Alta)
            {
                CursoActual = new Curso();
            }
            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                if (this.Modo == ModoForm.Modificacion)
                {
                    CursoActual.Id = Convert.ToInt16(this.txtIdCurso.Text);
                }
                CursoActual.IdMateria = (int)this.cbxMaterias.SelectedValue;
                CursoActual.IdComision = (int)this.cbxComisiones.SelectedValue;
                CursoActual.Cupo = Convert.ToInt32(this.txtCupo.Text.Trim());
                CursoActual.AnioCalendario = Convert.ToInt32(this.txtAnio.Text.Trim());
            }
            switch (this.Modo)
            {
                case ModoForm.Alta:
                    CursoActual.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Modificacion:
                    CursoActual.State = BusinessEntity.States.Modified;
                    break;
                case ModoForm.Baja:
                    CursoActual.State = BusinessEntity.States.Deleted;
                    break;
                case ModoForm.Consulta:
                    CursoActual.State = BusinessEntity.States.Unmodified;
                    break;
            }
        }
        public override void GuardarCambios()
        {
            CursoLogic cursoLogic = new CursoLogic();
            if (this.Modo == ModoForm.Alta)
            {
                Curso cursoNuevo = new Curso();
                this.CursoActual = cursoNuevo;
            }
            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                this.MapearADatos();
                cursoLogic.Save(this.CursoActual);
            }
            else if (this.Modo == ModoForm.Baja)
            {
                try
                {
                    cursoLogic.Delete(CursoActual.Id);
                }
                catch (Exception e)
                {
                    this.Notificar(this.Text, e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public override bool Validar()
        /* método que devuelva si los datos son válidos para poder
        registrar los cambios realizados.*/
        {
            string mensaje = "";

            if (this.cbxComisiones.SelectedIndex == -1) 
            {
                mensaje += "- Debe seleccionar una comisión.\n";
            } 
            if (this.cbxMaterias.SelectedIndex == -1)
            {
                mensaje += "- Debe seleccionar una materia.\n";
            }
            if (String.IsNullOrEmpty(this.txtCupo.Text.Trim()))
            {
                mensaje += "- Complete el campo Cupo.\n";
            }
            if (String.IsNullOrEmpty(this.txtAnio.Text.Trim()))
            {
                mensaje += "- Complete el campo Año.\n";
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
