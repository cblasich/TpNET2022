using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class AlumnoInscripcionLogic : BusinessLogic
    {
        private AlumnoInscripcionAdapter _alumnoInscripcionData;
        public AlumnoInscripcionAdapter AlumnoInscripcionData
        {
            get { return _alumnoInscripcionData; }
            set { _alumnoInscripcionData = value; }
        }

        public AlumnoInscripcionLogic()
        {
            AlumnoInscripcionData = new AlumnoInscripcionAdapter();
        }

        public List<AlumnoInscripcion> GetAll()
        {
            try
            {
                return AlumnoInscripcionData.GetAll();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de inscripciones de alumnos", Ex);
                throw ExcepcionManejada;
            }
        }

        public AlumnoInscripcion GetOne(int id)
        {
            return AlumnoInscripcionData.GetOne(id);
        }

        public void Delete(int id)
        {
            AlumnoInscripcionData.Delete(id);
        }

        public void Save(AlumnoInscripcion alumnoInscripcion)
        {
            AlumnoInscripcionData.Save(alumnoInscripcion);
        }
    }
}
