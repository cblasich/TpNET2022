using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Business.Entities;

namespace Data.Database
{
    public class AlumnoInscripcionAdapter : Adapter
    {
        public List<AlumnoInscripcion> GetAll()
        {
            List<AlumnoInscripcion> alumnosInscripciones = new List<AlumnoInscripcion>();

            try
            {
                this.OpenConnection();

                SqlCommand cmdAlumnosInscripciones = new SqlCommand("select * from alumnos_inscripciones", SqlConn);

                SqlDataReader drAlumnosInscripciones = cmdAlumnosInscripciones.ExecuteReader();

                while (drAlumnosInscripciones.Read()) //Mientras haya filas para leer...
                {
                    AlumnoInscripcion alumnoInscripcion = new AlumnoInscripcion();
                   
                    if ((int)drAlumnosInscripciones["id_inscripcion"] > 0)
                    {  
                        // Ahora copiamos los datos de la fila al objeto:
                        alumnoInscripcion.Id = (int)drAlumnosInscripciones["id_inscripcion"];
                        alumnoInscripcion.IdAlumno = (int)drAlumnosInscripciones["id_alumno"];
                        alumnoInscripcion.IdCurso = (int)drAlumnosInscripciones["id_curso"];
                        alumnoInscripcion.Condicion = (string)drAlumnosInscripciones["condicion"];
                        alumnoInscripcion.Nota = (int)drAlumnosInscripciones["nota"];
                    }

                   alumnosInscripciones.Add(alumnoInscripcion);
                }
                //Cerramos el DataReader
                drAlumnosInscripciones.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al intentar recuperar la lista de alumnos inscripciones", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();  //Cerramos la conexion a la BD
            }
            return alumnosInscripciones;  // Devolvemos el objeto:
        }

        public AlumnoInscripcion GetOne(int ID)
        {
            AlumnoInscripcion alumnoInscripcion = new AlumnoInscripcion();

            try
            {
                this.OpenConnection();
                SqlCommand cmdAlumnosInscripciones = new SqlCommand("select * from alumnos_inscripciones where id_inscripcion = @id", SqlConn);
                cmdAlumnosInscripciones.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drAlumnosInscripciones = cmdAlumnosInscripciones.ExecuteReader();
                if (drAlumnosInscripciones.Read())
                {
                    alumnoInscripcion.Id = (int)drAlumnosInscripciones["id_inscripcion"];
                    alumnoInscripcion.IdAlumno = (int)drAlumnosInscripciones["id_alumno"];
                    alumnoInscripcion.IdCurso = (int)drAlumnosInscripciones["id_curso"];
                    alumnoInscripcion.Condicion = (string)drAlumnosInscripciones["condicion"];
                    alumnoInscripcion.Nota = (int)drAlumnosInscripciones["nota"];
                }
                drAlumnosInscripciones.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al intentar recuperar datos de la inscripcion del alumno.", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return alumnoInscripcion;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                //Creamos la sentencia SQL y asignamos un valor al parametro
                SqlCommand cmdDelete = new SqlCommand("DELETE alumnos_inscripciones where id_inscripcion=@id", this.SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                //Ejecutamos la sentencia SQL
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al intentar eliminar inscripcion de alumno.", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(AlumnoInscripcion alumnoInscripcion)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE alumnos_inscripciones SET id_alumno = @id_alumno, " +
                "id_curso = @id_curso, condicion = @condicion, nota = @nota " +
                "WHERE id_inscripcion = @id", SqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = alumnoInscripcion.Id;
                cmdSave.Parameters.Add("@id_alumno", SqlDbType.Int).Value = alumnoInscripcion.IdAlumno;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = alumnoInscripcion.IdCurso;
                cmdSave.Parameters.Add("@condicion", SqlDbType.VarChar, 50).Value = alumnoInscripcion.Condicion;
                cmdSave.Parameters.Add("@nota", SqlDbType.Int).Value = alumnoInscripcion.Nota;

                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al intentar modificar datos de la inscripcion de alumno.", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(AlumnoInscripcion alumnoInscripcion)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand("INSERT INTO alumnos_inscripciones(id_alumno,id_curso,condicion,nota) " +
                "VALUES(@id_alumno, @id_curso, @condicion,@nota) " +
                "select @@identity", //linea para recuperar el ID que asigno el Sql automaticamente
                SqlConn);

                cmdInsert.Parameters.Add("@id_alumno", SqlDbType.Int).Value = alumnoInscripcion.IdAlumno;
                cmdInsert.Parameters.Add("@id_curso", SqlDbType.Int).Value = alumnoInscripcion.IdCurso;
                cmdInsert.Parameters.Add("@condicion", SqlDbType.VarChar, 50).Value = alumnoInscripcion.Condicion;
                cmdInsert.Parameters.Add("@nota", SqlDbType.Int).Value = alumnoInscripcion.Nota;

                alumnoInscripcion.Id = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());  //Asi se obtiene el ID que asigno la BD automaticamente.
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al intentar crear inscripción de alumno.", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(AlumnoInscripcion alumnoInscripcion)
        {
            if (alumnoInscripcion.State == BusinessEntity.States.Deleted)
            {
                this.Delete(alumnoInscripcion.Id);
            }
            else if (alumnoInscripcion.State == BusinessEntity.States.New)
            {
                this.Insert(alumnoInscripcion);
            }
            else if (alumnoInscripcion.State == BusinessEntity.States.Modified)
            {
                this.Update(alumnoInscripcion);
            }
            alumnoInscripcion.State = BusinessEntity.States.Unmodified;
        }
    }
}
