﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class CursoAdapter: Adapter
    {
        public List<Curso> GetAll()
        {
            //instanciamos el objeto lista a retornar
            List<Curso> cursos = new List<Curso>();

            try
            {
                //abrimos la conexion a la base de datos con el metodo que creamos antes
                this.OpenConnection();

                /* Creamos un objeto SqlCommand que sera la sentencia SQL
                 que vamos a ejecutar contra la base de datos
                 (los datos de la BD curso, contraseña, servidor, etc.
                 estan en el connection string */

                SqlCommand cmdCursos = new SqlCommand("select * from cursos cu " +
	                                                  "inner join materias ma ON cu.id_materia = ma.id_materia " +
	                                                  "inner join comisiones co ON cu.id_comision = co.id_comision", SqlConn);

                /* instanciamos un objeto DataReader que sera 
                 el que recuperara los datos de la BD */

                SqlDataReader drCursos = cmdCursos.ExecuteReader();

                /* Read() lee una fila de las devueltas por el comando sql,
                 carga los datos en drCursos para poder accederlos,
                 devuelve verdadero mientras haya podido leer datos
                 y avanza a la fila siguiente para el proximo read. */

                while (drCursos.Read())
                {
                    /* Creamos un objeto Curso de la capa de entidades para copiar
                     los datos de la fila del DataReader al objeto de entidades.*/

                    Curso curso = new Curso();

                    // Ahora copiamos los datos de la fila al objeto:

                    curso.Id = (int)drCursos["id_curso"];
                    curso.Cupo = (int)drCursos["cupo"];
                    curso.IdMateria = (int)drCursos["id_materia"];
                    curso.IdComision = (int)drCursos["id_comision"];
                    curso.AnioCalendario = (int)drCursos["anio_calendario"];

                    // Agregamos el objeto con datos a la lista que devolveremos
                    cursos.Add(curso);
                }
                drCursos.Close(); //Cerramos el DataReader
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al intentar recuperar la lista de cursos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();  //Cerramos la conexion a la BD
            }
            return cursos; // Devolvemos el objeto
        }

        public DataTable GetAllDataTable()
        {
            DataTable dtCursos = new DataTable();   //id_curso , id_materia, is_comision
            try
            { 
                this.OpenConnection();
                SqlCommand cmdCursos = new SqlCommand("select * from cursos cu inner join materias m on cu.id_materia = m.id_materia " +
                                                      "inner join comision co on cu.id_comision = co.id_comision", SqlConn);
                SqlDataAdapter daCursos = new SqlDataAdapter(cmdCursos);
                daCursos.Fill(dtCursos);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al intentar recuperar la lista de cursos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                //Cerramos la conexion a la BD
                this.CloseConnection();
            }
            return dtCursos;
        }

        public Curso GetOne(int ID)
        {
            Curso curso = new Curso();

            try
            {
                this.OpenConnection();
                SqlCommand cmdCursos = new SqlCommand("select * from cursos where id_curso = @id", SqlConn);
                cmdCursos.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drCursos = cmdCursos.ExecuteReader();
                if (drCursos.Read())
                {
                    curso.Id = (int)drCursos["id_curso"];
                    curso.Cupo = (int)drCursos["cupo"];
                    curso.IdMateria = (int)drCursos["id_materia"];
                    curso.IdComision = (int)drCursos["id_comision"];
                    curso.AnioCalendario = (int)drCursos["anio_calendario"];
                }

                drCursos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos del curso.", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return curso;
        }

        public void Delete(int ID)
        {
            try
            {
                //Abrimos conexion
                this.OpenConnection();

                //Creamos la sentencia SQL y asignamos un valor al parametro
                SqlCommand cmdDelete = new SqlCommand("delete cursos where id_curso=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                //Ejecutamos la sentencia SQL
                cmdDelete.ExecuteNonQuery();
            }
            catch (SqlException sqlEx)
            {
                Exception ExcepcionManejada = new Exception("El curso indicado tiene docentes_cursos vinculados. Primero debe eliminarlos.", sqlEx);
                throw ExcepcionManejada;
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al intentar eliminar curso.", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(Curso curso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE cursos SET id_materia = @id_materia, id_comision = @id_comision, " +
                "anio_calendario = @anio_calendario, cupo = @cupo " +
                "WHERE id_curso = @id", SqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = curso.Id;
                cmdSave.Parameters.Add("id_materia", SqlDbType.Int).Value = curso.IdMateria;
                cmdSave.Parameters.Add("id_comision", SqlDbType.Int).Value = curso.IdComision;
                cmdSave.Parameters.Add("anio_calendario", SqlDbType.Int).Value = curso.AnioCalendario;
                cmdSave.Parameters.Add("@cupo", SqlDbType.VarChar, 50).Value = curso.Cupo;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al intentar modificar datos del curso.", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(Curso curso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("INSERT INTO cursos(id_materia, id_comision, anio_calendario, cupo) " +
                "VALUES(@id_materia, @id_comision, @anio_calendario, @cupo) " +
                "select @@identity", //linea para recuperar el ID que asigno el Sql automaticamente
                SqlConn);

                cmdSave.Parameters.Add("id_materia", SqlDbType.Int).Value = curso.IdMateria;
                cmdSave.Parameters.Add("id_comision", SqlDbType.Int).Value = curso.IdComision;
                cmdSave.Parameters.Add("anio_calendario", SqlDbType.Int).Value = curso.AnioCalendario;
                cmdSave.Parameters.Add("@cupo", SqlDbType.Int).Value = curso.Cupo;
                curso.Id = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
                //Asi se obtiene el ID que asigno la BD automaticamente.
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al intentar crear curso.", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Curso curso)
        {
            if (curso.State == BusinessEntity.States.Deleted)
            {
                this.Delete(curso.Id);
            }
            else if (curso.State == BusinessEntity.States.New)
            {
                this.Insert(curso);
            }
            else if (curso.State == BusinessEntity.States.Modified)
            {
                this.Update(curso);
            }
            curso.State = BusinessEntity.States.Unmodified;
        }
    }
} //solo estoy probando con cupo, despues agregar lo que falta
