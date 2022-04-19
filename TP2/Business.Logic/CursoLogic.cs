using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;
using System.Data;

namespace Business.Logic
{
    public class CursoLogic: BusinessLogic
    {
        private CursoAdapter _cursoData;
        public CursoAdapter CursoData
        {
            get { return _cursoData; }
            set { _cursoData = value; }
        }
        public CursoLogic()
        {
            CursoData = new CursoAdapter();
        }
        public List<Curso> GetAll()
        {
            try
            {
                return CursoData.GetAll();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar la lista de cursos.", Ex);
                throw ExcepcionManejada;
            }

        }
        public DataTable GetAllDataTable()
        {
            try
            {
                return CursoData.GetAllDataTable();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar la lista de cursos.", Ex);
                throw ExcepcionManejada;
            }
        }

        public Curso GetOne(int id)
        {
            return CursoData.GetOne(id);
        }
        public void Save(Curso curso)
        {
            CursoData.Save(curso);
        }
        public void Delete(int id)
        {
            CursoData.Delete(id);
        }
    }
}
