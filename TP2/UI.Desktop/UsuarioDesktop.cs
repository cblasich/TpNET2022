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
using Util;


namespace UI.Desktop
{
    public partial class UsuarioDesktop : ApplicationForm
    {
        private Usuario _usuarioActual;
        public Usuario UsuarioActual
        {
            get { return _usuarioActual; }
            set { _usuarioActual = value; }
        }

        private Persona _personaActual;
        public Persona PersonaActual
        {
            get { return _personaActual; }
            set { _personaActual = value; }
        }
        public UsuarioDesktop()
        {
            InitializeComponent();
            this.txtClave.PasswordChar = '*';
            this.txtConfirmarClave.PasswordChar = '*';

        }
        public UsuarioDesktop(ModoForm modo) : this()
        //este constructor servirá para las altas
        {
            this.Modo = modo;
        }

        public UsuarioDesktop(int id, ModoForm modo):this()
        {
            this.Modo = modo;
            try
            {
                UsuarioLogic usuLogic = new UsuarioLogic();
                //Recupero el usuario
                this.UsuarioActual = usuLogic.GetOne(id);
                this.MapearDeDatos(); 

                /*Enumeradores.TiposPersonas tipoPersona = new PersonaLogic().GetOnePorPersona(UsuarioActual.IdPersona).TipoPersona;
                if (tipoPersona == Enumeradores.TiposPersonas.Administrador)
                {
                    //Cargo la grilla de permisos
                    dgvPermisos.AutoGenerateColumns = false;
                    dgvPermisos.DataSource = new ModuloUsuarioLogic().GetAllTabla(this.Usuario.Id);
                }*/
            }
            catch (Exception e)
            {
                this.Notificar(this.Text, e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public override void MapearADatos()
        {
            if (this.Modo == ModoForm.Alta)
            {
                UsuarioActual = new Usuario();
                PersonaActual = new Persona();
            }
            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                if (this.Modo == ModoForm.Modificacion) {
                    
                    UsuarioActual.Id = Convert.ToInt16(this.txtId.Text.Trim());
                    PersonaActual.Id = UsuarioActual.IdPersona;
                }
                UsuarioActual.NombreUsuario = this.txtUsuario.Text.Trim();
                UsuarioActual.Habilitado = this.chkHabilitado.Checked;
                UsuarioActual.Clave = this.txtClave.Text.Trim();
                PersonaActual.Nombre = this.txtNombre.Text.Trim();
                PersonaActual.Apellido = this.txtApellido.Text.Trim();
                PersonaActual.Email = this.txtEmail.Text.Trim();
            }

            switch (this.Modo)
            {
                case ModoForm.Alta:
                    UsuarioActual.State = BusinessEntity.States.New;
                    PersonaActual.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Modificacion:
                    UsuarioActual.State = BusinessEntity.States.Modified;
                    PersonaActual.State = BusinessEntity.States.Modified;
                    break;
                case ModoForm.Baja:
                    UsuarioActual.State = BusinessEntity.States.Deleted;
                    PersonaActual.State = BusinessEntity.States.Deleted;
                    break;
                case ModoForm.Consulta:
                    UsuarioActual.State = BusinessEntity.States.Unmodified;
                    PersonaActual.State = BusinessEntity.States.Unmodified;
                    break;
            }
        }
        public override void MapearDeDatos()
        {
            PersonaLogic pl = new PersonaLogic();
            Persona p = null;

            try {
                //Recupero persona correspondiente al usuario logueado
                p = pl.GetOnePorPersona(this.UsuarioActual.IdPersona);
                
                //Copio datos al formulario
                this.txtId.Text = UsuarioActual.Id.ToString();
                this.txtUsuario.Text = UsuarioActual.NombreUsuario;
                this.txtClave.Text = UsuarioActual.Clave.ToString();
                this.txtConfirmarClave.Text = UsuarioActual.Clave;
                this.chkHabilitado.Checked = this.UsuarioActual.Habilitado;
                this.txtNombre.Text = p.Nombre.ToString();
                this.txtApellido.Text = p.Apellido.ToString();
                this.txtEmail.Text = p.Email.ToString();
            }
            catch(Exception ex)
            {
                this.Notificar("Se produjo un error.", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //seteo del texto del botón Aceptar según Modo del formulario
            switch (this.Modo)
            {
                case ModoForm.Alta:
                    this.Text = "Alta de Usuario";
                    this.btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Modificacion:
                    this.Text = "Modificación de Usuario";
                    this.btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Baja:
                    this.Text = "Baja de Usuario";
                    this.btnAceptar.Text = "Eliminar";
                    break;
                case ModoForm.Consulta:
                    this.Text = "Consulta de Usuario";
                    this.btnAceptar.Text = "Aceptar";
                    break;
            }
        }
        public override void GuardarCambios() {
        /* método que se encargará de invocar al método correspondiente 
        de la capa de negocio según sea el ModoForm en que se encuentre el formulario*/
        
            UsuarioLogic usuLogic = new UsuarioLogic();
            PersonaLogic perLogic = new PersonaLogic();

            if (this.Modo == ModoForm.Alta) {

                Usuario usuNuevo = new Usuario();
                this.UsuarioActual = usuNuevo;
                Persona perNueva = new Persona();
                this.PersonaActual = perNueva;
            } 
            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion) {
                
                this.MapearADatos();
                perLogic.Save(this.PersonaActual);
                this.UsuarioActual.IdPersona = this.PersonaActual.Id;
                usuLogic.Save(this.UsuarioActual);
                
                //UsuarioActual.IdPersona = new PersonaLogic().GetOnePorLegajo(legajo).Id;
            } 
            else if (this.Modo == ModoForm.Baja) {
                try {
                    usuLogic.Delete(UsuarioActual.Id);
                }
                catch (Exception e) {
                    this.Notificar(this.Text, e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public override bool Validar() 
        /* devuelve V si los datos son válidos */
        {
            string mensaje = "";
            
                if (String.IsNullOrEmpty(this.txtNombre.Text.Trim()))
                {
                    mensaje += "- Complete el campo Nombre.\n";
                }
                if (String.IsNullOrEmpty(this.txtApellido.Text.Trim()))
                {
                    mensaje += "- Complete el campo Apellido.\n";
                }
                if (String.IsNullOrEmpty(this.txtEmail.Text))
                {
                    mensaje += "- Complete el email\n";
                }
                if (!Validaciones.ValidarEmail(this.txtEmail.Text))
                {
                    mensaje += "- El email ingresado no es válido\n";
                }
                if (String.IsNullOrEmpty(this.txtUsuario.Text.Trim()))
                {
                    mensaje += "- Complete el campo Usuario.\n";
                }
                if (String.IsNullOrEmpty(this.txtClave.Text))
                {
                    mensaje += "- Complete el campo Clave.\n";
                }
                if (String.IsNullOrEmpty(this.txtConfirmarClave.Text))
                {
                    mensaje += "- Complete el campo Confirmar clave.\n";
                }
                if (this.txtClave.Text != this.txtConfirmarClave.Text)
                {
                    mensaje += "- Los campos Clave y Confirmar clave no coinciden.\n";
                }
                if (this.txtClave.Text.Length < 8)
                {
                    mensaje += "- La clave debe tener al menos 8 caracteres.\n";
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
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.Validar()) {
                try {
                    this.GuardarCambios();
                    this.Close();
                }
                catch (Exception ex) {
                    this.Notificar(this.Text, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UsuarioDesktop_Load(object sender, EventArgs e)
        {

        }
        //private void chkExistePersona_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chkExistePersona.Checked)
        //    {
        //        txtNombre.Enabled = false;
        //        txtApellido.Enabled = false;
        //        txtEmail.Enabled = false;
        //        txtDireccion.Enabled = false;
        //        txtTelefono.Enabled = false;
        //        dtpFechaNacimiento.Enabled = false;
        //        cmbPlanes.Enabled = false;
        //        cmbTiposPersona.Enabled = false;
        //    }
        //    else
        //    {
        //        txtNombre.Enabled = true;
        //        txtEmail.Enabled = true;
        //        dtpFechaNacimiento.Enabled = true;
        //        cmbPlanes.Enabled = true;
        //        txtApellido.Enabled = true;
        //        txtDireccion.Enabled = true;
        //        txtTelefono.Enabled = true;
        //        cmbTiposPersona.Enabled = true;
        //    }
        //}
    }
}
