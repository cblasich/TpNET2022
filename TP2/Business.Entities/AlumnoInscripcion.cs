﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class AlumnoInscripcion : BusinessEntity
    {

        private int _idInscripcion;
        private int _idAlumno;   
        private int _idCurso;
        private string _condicion;
        private int _nota;

        public int IdInscripcion
        {
            get { return _idInscripcion; }
            set { _idInscripcion = value; }
        }

        public int IdAlumno
        {
            get { return _idAlumno; }
            set { _idAlumno = value; }
        }

        public int IdCurso
        {
            get { return _idCurso; }
            set { _idCurso = value; }
        }

        public string Condicion
        {
            get { return _condicion; }
            set { _condicion = value; }
        }

        public int Nota
        {
            get { return _nota; }
            set { _nota = value; }
        }
    }
}
