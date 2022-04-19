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
    public partial class DocenteCursoDesktop : ApplicationForm
    {
        private DocenteCurso _docenteCursoActual;
        public DocenteCurso DocenteCursoActual
        {
            get { return _docenteCursoActual; }
            set { _docenteCursoActual = value; }
        }

        public DocenteCursoDesktop()
        {
            InitializeComponent();
        }

        public DocenteCursoDesktop(ModoForm modo):this () //para altas
        {
            this.Modo = modo;
        }
 
        public DocenteCursoDesktop(int id, ModoForm modo):this()
        {
            this.Modo = modo;
            DocenteCursoLogic docCurLogic = new DocenteCursoLogic();
            this.DocenteCursoActual = docCurLogic.GetOne(id);
            this.MapearDeDatos();
        }
        
        public override void MapearDeDatos()
        {
            this.txtIdDictado.Text = this.DocenteCursoActual.Id.ToString();
            this.cmbCursos.SelectedItem = this.DocenteCursoActual.IdCurso;
            this.cmbDocentes.SelectedItem = this.DocenteCursoActual.IdDocente;
            this.cmbCargos.SelectedItem = this.DocenteCursoActual.Cargo;

            switch (this.Modo)  //texto del boton Aceptar y del winForm
            {
                case ModoForm.Alta:
                    this.Text = "Alta de Dictado";
                    this.btnAceptar.Text = "Guardar";
                    break;

                case ModoForm.Modificacion:
                    this.Text = "Modificación de Dictado";
                    this.btnAceptar.Text = "Guardar";
                    break;

                case ModoForm.Baja:
                    this.Text = "Baja de Dictado";
                    this.btnAceptar.Text = "Eliminar";
                    break;

                case ModoForm.Consulta:
                    this.Text = "Consulta de Dictado";
                    this.btnAceptar.Text = "Aceptar";
                    break;
            }

        }

        public override void MapearADatos()
        {
            if (this.Modo == ModoForm.Alta)
            {
                DocenteCursoActual = new DocenteCurso();
                DocenteCursoActual.State = BusinessEntity.States.New;
            }
            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                DocenteCursoActual.IdCurso = (int)this.cmbCursos.SelectedValue;
                DocenteCursoActual.IdDocente = (int)this.cmbDocentes.SelectedValue;
                DocenteCursoActual.Cargo = (int)this.cmbCargos.SelectedValue;

                if (this.Modo == ModoForm.Modificacion)
                {
                    DocenteCursoActual.Id = Convert.ToInt16(this.txtIdDictado.Text);
                    DocenteCursoActual.State = BusinessEntity.States.Modified;
                }
            }
            if (this.Modo == ModoForm.Baja)
            {
                DocenteCursoActual.State = BusinessEntity.States.Deleted;
            }
        }

        public override bool Validar()
        {
            string mensaje = "";
            
            if (this.cmbCursos.SelectedIndex == -1) 
            {
                mensaje += "- Seleccione un curso.\n";
            }
            if (this.cmbDocentes.SelectedIndex == -1) 
            {
                mensaje += "- Seleccione un docente.\n";
            }
            if (this.cmbCargos.SelectedIndex == -1) 
            {
                mensaje += "- Seleccione un cargo.\n";
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

        public override void GuardarCambios()
        {
            DocenteCursoLogic docCurLogic = new DocenteCursoLogic();
            if (this.Modo == ModoForm.Alta)
            {
                DocenteCurso docCurNuevo = new DocenteCurso();
                this.DocenteCursoActual = docCurNuevo;
            }
            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                try
                {
                    this.MapearADatos();
                    docCurLogic.Save(this.DocenteCursoActual);
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
                    docCurLogic.Delete(DocenteCursoActual.Id);
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
