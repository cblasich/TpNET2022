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
    public class DocenteCursoAdapter : Adapter
    {
        public List<DocenteCurso> GetAll()
        {
            List<DocenteCurso> docentesCursos = new List<DocenteCurso>();

            try
            {
                this.OpenConnection();

                SqlCommand cmdDocentesCursos = new SqlCommand("select * from docentes_cursos", SqlConn);

                SqlDataReader drDocentesCursos = cmdDocentesCursos.ExecuteReader();

                while (drDocentesCursos.Read()) //Mientras haya filas para leer...
                {
                    DocenteCurso docenteCurso = new DocenteCurso();

                    if ((int)drDocentesCursos["id_dictado"] > 0)
                    {
                        // Ahora copiamos los datos de la fila al objeto:
                        docenteCurso.Id = (int)drDocentesCursos["id_dictado"];
                        docenteCurso.IdCurso = (int)drDocentesCursos["id_curso"];
                        docenteCurso.IdDocente = (int)drDocentesCursos["id_docente"];
                        docenteCurso.Cargo = (int)drDocentesCursos["cargo"];
                    }
                    // Agregamos el objeto con datos a la lista que devolveremos
                    docentesCursos.Add(docenteCurso);
                }
                //Cerramos el DataReader
                drDocentesCursos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al intentar recuperar la lista de docentes de cursos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                //Cerramos la conexion a la BD
                this.CloseConnection();
            }

            // Devolvemos el objeto:
            return docentesCursos;
        }

        public DocenteCurso GetOne(int ID)
        {
            DocenteCurso docenteCurso = new DocenteCurso();

            try
            {
                this.OpenConnection();
                SqlCommand cmdDocentesCursos = new SqlCommand("select * from docentes_cursos where id_dictado = @id", SqlConn);
                cmdDocentesCursos.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drDocentesCursos = cmdDocentesCursos.ExecuteReader();
                if (drDocentesCursos.Read())
                {
                    docenteCurso.Id = (int)drDocentesCursos["id_dictado"];
                    docenteCurso.IdCurso = (int)drDocentesCursos["id_curso"];
                    docenteCurso.IdDocente = (int)drDocentesCursos["id_docente"];
                    docenteCurso.Cargo = (int)drDocentesCursos["cargo"];
                }

                drDocentesCursos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al intentar recuperar datos del docente de curso.", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return docenteCurso;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                //Creamos la sentencia SQL y asignamos un valor al parametro
                SqlCommand cmdDelete = new SqlCommand("DELETE docentes_cursos where id_curso=@id", this.SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                //Ejecutamos la sentencia SQL
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al intentar eliminar docente de curso.", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(DocenteCurso docenteCurso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE docentes_cursos SET id_curso = @id_curso, " +
                "id_docente = @id_docente, cargo = @cargo " +
                "WHERE id_dictado = @id", SqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = docenteCurso.Id;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = docenteCurso.IdCurso;
                cmdSave.Parameters.Add("@id_docente", SqlDbType.Int).Value = docenteCurso.IdDocente;
                cmdSave.Parameters.Add("@cargo", SqlDbType.Int).Value = docenteCurso.Cargo;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al intentar modificar datos del docente de curso.", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(DocenteCurso docenteCurso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand("INSERT INTO docentes_cursos(id_curso,id_docente,cargo) " +
                "VALUES(@id_curso, @id_docente, @cargo) " +
                "select @@identity", //linea para recuperar el ID que asigno el Sql automaticamente
                SqlConn);

                cmdInsert.Parameters.Add("@id_curso", SqlDbType.Int).Value = docenteCurso.IdCurso;
                cmdInsert.Parameters.Add("@id_docente", SqlDbType.Int).Value = docenteCurso.IdDocente;
                cmdInsert.Parameters.Add("@cargo", SqlDbType.Int).Value = docenteCurso.Cargo;
                docenteCurso.Id = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());  //Asi se obtiene el ID que asigno la BD automaticamente.
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al intentar crear docente de curso.", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(DocenteCurso docenteCurso)
        {
            if (docenteCurso.State == BusinessEntity.States.Deleted)
            {
                this.Delete(docenteCurso.Id);
            }
            else if (docenteCurso.State == BusinessEntity.States.New)
            {
                this.Insert(docenteCurso);
            }
            else if (docenteCurso.State == BusinessEntity.States.Modified)
            {
                this.Update(docenteCurso);
            }
            docenteCurso.State = BusinessEntity.States.Unmodified;
        }

    }
}
