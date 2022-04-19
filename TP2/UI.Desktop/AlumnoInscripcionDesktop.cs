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
    public partial class AlumnoInscripcionDesktop : ApplicationForm
    {
        private AlumnoInscripcion _alumnoInscripcionActual;
        public AlumnoInscripcion AlumnoInscripcionActual
        {
            get { return _alumnoInscripcionActual; }
            set { _alumnoInscripcionActual = value; }
        }

        public AlumnoInscripcionDesktop()
        {
            InitializeComponent();
        }

        public AlumnoInscripcionDesktop(ModoForm modo):this () //para altas
        {
            this.Modo = modo;
        }

        public AlumnoInscripcionDesktop(int id, ModoForm modo):this()
        {
            this.Modo = modo;
            AlumnoInscripcionLogic aluInsLogic = new AlumnoInscripcionLogic();
            this.AlumnoInscripcionActual = aluInsLogic.GetOne(id);
            this.MapearDeDatos();
        }

        public override void MapearDeDatos()
        {
            this.txtIdInscripcion.Text = this.AlumnoInscripcionActual.Id.ToString();
            this.cmbCursos.SelectedItem = this.AlumnoInscripcionActual.IdCurso;
            this.cmbAlumnos.SelectedItem = this.AlumnoInscripcionActual.IdAlumno;
            this.txtCondicion.Text = this.AlumnoInscripcionActual.Condicion.ToString();
            this.txtNota.Text = this.AlumnoInscripcionActual.Nota.ToString();

            switch (this.Modo)  //texto del boton Aceptar y del winForm
            {
                case ModoForm.Alta:
                    this.Text = "Alta de Inscripción";
                    this.btnAceptar.Text = "Guardar";
                    break;

                case ModoForm.Modificacion:
                    this.Text = "Modificación de Inscripción";
                    this.btnAceptar.Text = "Guardar";
                    break;

                case ModoForm.Baja:
                    this.Text = "Baja de Inscripción";
                    this.btnAceptar.Text = "Eliminar";
                    break;

                case ModoForm.Consulta:
                    this.Text = "Consulta de Inscripción";
                    this.btnAceptar.Text = "Aceptar";
                    break;
            }
        }

        public override void MapearADatos()
        {
            if (this.Modo == ModoForm.Alta)
            {
                AlumnoInscripcionActual = new AlumnoInscripcion();
                AlumnoInscripcionActual.State = BusinessEntity.States.New;
            }
            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                AlumnoInscripcionActual.IdCurso = (int)this.cmbCursos.SelectedValue;
                AlumnoInscripcionActual.IdAlumno = (int)this.cmbAlumnos.SelectedValue;
                AlumnoInscripcionActual.Condicion = this.txtCondicion.Text.Trim();
                AlumnoInscripcionActual.Nota = Convert.ToInt32(this.txtNota.Text.Trim());


                if (this.Modo == ModoForm.Modificacion)
                {
                    AlumnoInscripcionActual.Id = Convert.ToInt16(this.txtIdInscripcion.Text);
                    AlumnoInscripcionActual.State = BusinessEntity.States.Modified;
                }
            }
            if (this.Modo == ModoForm.Baja)
            {
                AlumnoInscripcionActual.State = BusinessEntity.States.Deleted;
            }
        }

        public override bool Validar()
        {
            string mensaje = "";

            if (this.cmbCursos.SelectedIndex == -1) //.Text.Trim()))
            {
                mensaje += "- Seleccione un curso.\n";
            }
            if (this.cmbAlumnos.SelectedIndex == -1) //.Text.Trim()))
            {
                mensaje += "- Seleccione un alumno.\n";
            }
            if (String.IsNullOrEmpty(this.txtCondicion.Text.Trim()))
            {
                mensaje += "- Complete el campo Condición.\n";
            }
            if (String.IsNullOrEmpty(this.txtNota.Text.Trim()))
            {
                mensaje += "- Complete el campo Nota.\n";
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

        /*
         * En el método GuardarCambios debemos utilizar el método MapearADatos y
            luego crearemos una nueva instancia de la clase UsuarioLogic y
            llamaremos al método Save de esa instancia pasándole por parámetro
            UsuarioActual.
         */
        public override void GuardarCambios()
        {
            AlumnoInscripcionLogic aluInsLogic = new AlumnoInscripcionLogic();
            if (this.Modo == ModoForm.Alta)
            {
                AlumnoInscripcion aluInsNueva = new AlumnoInscripcion();
                this.AlumnoInscripcionActual = aluInsNueva;
            }
            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                try
                {
                    this.MapearADatos();
                    aluInsLogic.Save(this.AlumnoInscripcionActual);
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
                    aluInsLogic.Delete(AlumnoInscripcionActual.Id);
                }
                catch (Exception e)
                {
                    this.Notificar(this.Text, e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
