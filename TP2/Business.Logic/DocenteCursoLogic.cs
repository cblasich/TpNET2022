using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class DocenteCursoLogic : BusinessLogic
    {
        private DocenteCursoAdapter _docenteCursoData;
        public DocenteCursoAdapter DocenteCursoData
        {
            get { return _docenteCursoData; }
            set { _docenteCursoData = value; }
        }

        public DocenteCursoLogic()
        {
            DocenteCursoData = new DocenteCursoAdapter();
        }

        public List<DocenteCurso> GetAll()
        {
            try
            {
                return DocenteCursoData.GetAll();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de docentes de cursos.", Ex);
                throw ExcepcionManejada;
            }
        }

        public DocenteCurso GetOne(int id)
        {
            return DocenteCursoData.GetOne(id);
        }

        public void Delete(int id)
        {
            DocenteCursoData.Delete(id);
        }

        public void Save(DocenteCurso docenteCurso)
        {
            DocenteCursoData.Save(docenteCurso);
        }
    }
}
