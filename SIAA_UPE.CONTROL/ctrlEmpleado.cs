using System;
using System.Collections.Generic;
using System.Linq;
using SIAA_UPE.MODELO.entidades;

namespace SIAA_UPE.CONTROL
{
    public class ctrlEmpleado
    {
        DBDataContext db = new DBDataContext();
        public Boolean insert(FD_SIA_EMPLEADO _empleado)
        {
            Boolean respuesta = false;
            try
            {
                this.db.FD_SIA_EMPLEADO.InsertOnSubmit(_empleado);
                this.db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                string smg = ex.Message;
                respuesta = false;
            }
            return respuesta;
        }
        public Boolean upDate(FD_SIA_EMPLEADO _empleado)
        {
            bool respuesta = false;
            try
            {
                FD_SIA_EMPLEADO empleado = this.db.FD_SIA_EMPLEADO.Where(p => p.idEmpleado == _empleado.idEmpleado).First();
                empleado.idPersona = _empleado.idPersona;
                empleado.area= _empleado.area;
                empleado.departamento= _empleado.departamento;
                empleado.idRol= _empleado.idRol;
                empleado.horario= _empleado.horario;
                empleado.gAcademico= _empleado.gAcademico;
                empleado.password= _empleado.password;
                empleado.RFC= _empleado.RFC;
                empleado.NS= _empleado.NS;
                this.db.SubmitChanges();
                respuesta = true;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                respuesta = false;
            }
            return respuesta;
        }
        public Boolean delete(string _id)
        {
            bool respuesta = false;
            try
            {
                FD_SIA_EMPLEADO doc = this.db.FD_SIA_EMPLEADO.Where(p => p.idEmpleado == _id).First();
                this.db.FD_SIA_EMPLEADO.DeleteOnSubmit(doc);
                this.db.SubmitChanges();
                respuesta = true;
            }
            catch (Exception ex)
            {
                string msj = ex.Message;
                respuesta = false;
            }
            return respuesta;
        }
        public List<FD_SIA_EMPLEADO> selectAll()
        {
            try
            {
                return this.db.FD_SIA_EMPLEADO.OrderBy(p => p.DP_SIA_PERSONA.nombre).ToList();
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return null;
            }
        }
        public FD_SIA_EMPLEADO empleado(string _matricula)
        {
            try
            {
                return this.db.FD_SIA_EMPLEADO.Where(p => p.idEmpleado == _matricula).First();
            }
            catch (Exception e)
            {
                string smg = e.Message;
                return null;
            }
        }
    }
}
