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
    public partial class ModuloUsuarioDesktop : ApplicationForm
    {
        private ModuloUsuario _moduloUsuarioActual;
        public ModuloUsuario ModuloUsuarioActual
        {
            get { return _moduloUsuarioActual; }
            set { _moduloUsuarioActual = value; }
        }
        public ModuloUsuarioDesktop()
        {
            InitializeComponent();
        }
        public ModuloUsuarioDesktop(ModoForm modo) : this()
        {
            this.Modo = modo;
            this.CargarCombos(); 
        }
        public ModuloUsuarioDesktop(int id, ModoForm modo):this()
        {
            this.Modo = modo;
            try
            {
                ModuloUsuarioLogic modUsuLogic = new ModuloUsuarioLogic();
                this.ModuloUsuarioActual = modUsuLogic.GetOne(id);
                this.MapearDeDatos(); 
            }
            catch (Exception e)
            {
                this.Notificar(this.Text, e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CargarCombos()
        {
            cbxModulos.DataSource = new ModuloLogic().GetAll();
            cbxUsuarios.DataSource = new UsuarioLogic().GetAll();
        }

        public override void MapearDeDatos()
        {
            this.txtId.Text = this.ModuloUsuarioActual.Id.ToString();
            this.cbxModulos.SelectedValue = (int)this.ModuloUsuarioActual.IdModulo;
            this.cbxUsuarios.SelectedValue = (int)this.ModuloUsuarioActual.IdUsuario;
            this.chkAlta.Checked = this.ModuloUsuarioActual.PermiteAlta;
            this.chkBaja.Checked = this.ModuloUsuarioActual.PermiteBaja;
            this.chkModificacion.Checked = this.ModuloUsuarioActual.PermiteModificacion;
            this.chkConsulta.Checked = this.ModuloUsuarioActual.PermiteConsulta;

            //seteo del texto del botón Aceptar según Modo del formulario
            switch (this.Modo)
            {
                case ModoForm.Alta:
                    this.Text = "Alta de Módulo Usuario";
                    this.Name = "Alta de Módulo Usuario";
                    this.btnAceptar.Text = "Guardar";
                    break;

                case ModoForm.Modificacion:
                    this.Text = "Modificación de Módulo Usuario";
                    this.btnAceptar.Text = "Guardar";
                    break;

                case ModoForm.Baja:
                    this.Text = "Baja de Módulo Usuario";
                    this.btnAceptar.Text = "Eliminar";
                    break;

                case ModoForm.Consulta:
                    this.Text = "Consulta de Módulo Usuario";
                    this.btnAceptar.Text = "Aceptar";
                    break;
            }
        }
        public override void MapearADatos()
        {
            if (this.Modo == ModoForm.Alta)
            {
                ModuloUsuarioActual = new ModuloUsuario();
            }
            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                if (this.Modo == ModoForm.Modificacion)
                {
                    ModuloUsuarioActual.Id = Convert.ToInt16(this.txtId.Text);
                }
                ModuloUsuarioActual.IdModulo = (int)cbxModulos.SelectedIndex;
                ModuloUsuarioActual.IdUsuario = (int)cbxUsuarios.SelectedIndex;
                ModuloUsuarioActual.PermiteAlta = this.chkAlta.Checked;
                ModuloUsuarioActual.PermiteBaja = this.chkBaja.Checked;
                ModuloUsuarioActual.PermiteModificacion = this.chkModificacion.Checked;
                ModuloUsuarioActual.PermiteConsulta = this.chkConsulta.Checked;
            }
            switch (this.Modo)
            {
                case ModoForm.Alta:
                    ModuloUsuarioActual.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Modificacion:
                    ModuloUsuarioActual.State = BusinessEntity.States.Modified;
                    break;
                case ModoForm.Baja:
                    ModuloUsuarioActual.State = BusinessEntity.States.Deleted;
                    break;
                case ModoForm.Consulta:
                    ModuloUsuarioActual.State = BusinessEntity.States.Unmodified;
                    break;
            }
        }
        public override void GuardarCambios()
        {
            ModuloUsuarioLogic modUsuLogic = new ModuloUsuarioLogic();
            if (this.Modo == ModoForm.Alta)
            {
                ModuloUsuario modUsuNuevo = new ModuloUsuario();
                this.ModuloUsuarioActual = modUsuNuevo;
            }
            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                try
                {
                    this.MapearADatos();
                    modUsuLogic.Save(this.ModuloUsuarioActual);
                }
                catch (Exception e)
                {
                    this.Notificar(this.Text, e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (this.Modo == ModoForm.Baja)
            {
                try
                {
                    modUsuLogic.Delete(ModuloUsuarioActual.Id);
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
          
            if (this.cbxModulos.SelectedIndex == -1) 
            {
                mensaje += "- Debe seleccionar un módulo.\n";
            }
            if (this.cbxUsuarios.SelectedIndex == -1)
            {
                mensaje += "- Debe seleccionar un usuario.\n";
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
            if (this.Validar()) this.GuardarCambios();
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
