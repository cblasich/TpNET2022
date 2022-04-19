using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;
using System.Data;
using System.Data.SqlClient;

namespace Business.Logic
{
    public class MateriaLogic : BusinessLogic
    {
        private MateriaAdapter _materiaData;
        public MateriaAdapter MateriaData
        {
            get { return _materiaData; }
            set { _materiaData = value; }
        }
        public MateriaLogic()
        {
            MateriaData = new MateriaAdapter();
        }
        public Materia GetOne(int id)
        {
            return MateriaData.GetOne(id);
        }

        public DataTable GetAllDataTable()
        {
            try
            {
                return MateriaData.GetAllDataTable();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar la lista de materias.", Ex);
                throw ExcepcionManejada;
            }
        }

        public List<Materia> GetAll()
        {
            try
            {
                return MateriaData.GetAll();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar la lista de materias.", Ex);
                throw ExcepcionManejada;
            }
        }

        public void Save(Materia materia)
        {
            MateriaData.Save(materia);
        }
        public void Delete(int id)
        {
            MateriaData.Delete(id);
        }

    }
}
