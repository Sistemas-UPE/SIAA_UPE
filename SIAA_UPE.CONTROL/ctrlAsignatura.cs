using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIAA_UPE.MODELO.entidades;


namespace SIAA_UPE.CONTROL
{
    public class ctrlAsignatura
    {
        DBDataContext db = new DBDataContext();
        public Boolean insert(CA_SIA_ASIGNATURA _data)
        {
            Boolean respuesta = false;
            try
            {
                this.db.CA_SIA_ASIGNATURA.InsertOnSubmit(_data);
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
        public Boolean Update(CA_SIA_ASIGNATURA _data,string _id)
        {
            bool respuesta = false;
            try
            {
                CA_SIA_ASIGNATURA gp = this.db.CA_SIA_ASIGNATURA.Where(p => p.idAsignatura == _id).First();
                gp.nomAsignatura = _data.nomAsignatura;
                gp.creditos = _data.creditos;
                gp.cuatrimestre = _data.cuatrimestre;
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
        public List<CA_SIA_ASIGNATURA> selectAll()
        {
            try
            {
                return this.db.CA_SIA_ASIGNATURA.OrderBy(p => p.nomAsignatura).ToList();
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return null;
            }
        }
        public List<CA_SIA_ASIGNATURA> selectByPE(string _idPE)
        {
            List<CA_SIA_ASIGNATURA> ins = new List<CA_SIA_ASIGNATURA>();
            try
            {
                ins = db.CA_SIA_ASIGNATURA.Where(p => p.idPE == _idPE).ToList();
                return ins;
            }
            catch
            {
                return null;
            }
        }
        public CA_SIA_ASIGNATURA selectByID(string _id)
        {
            try
            {
               return db.CA_SIA_ASIGNATURA.Where(p => p.idAsignatura == _id).Single();
            }
            catch
            {
                return null;
            }
        }
        public List<CA_SIA_ASIGNATURA> selectBY(string _browse)
        {
            try
            {
                List<CA_SIA_ASIGNATURA> m = this.db.CA_SIA_ASIGNATURA.Where(p => p.nomAsignatura.Contains(_browse)).ToList();
                return m;
            }
            catch (Exception ex)
            {
                string smg = ex.Message;

                return null;
            }
        }
        public Boolean delete(string _id)
        {
            bool respuesta = false;
            try
            {
                CA_SIA_ASIGNATURA cat = this.db.CA_SIA_ASIGNATURA.Where(p => p.idAsignatura == _id).Single();
                this.db.CA_SIA_ASIGNATURA.DeleteOnSubmit(cat);
                this.db.SubmitChanges();
                respuesta = true;
            }
            catch (Exception ex)
            {
                string smg = ex.Message;
                respuesta = false;
            }
            return respuesta;
        }
    }
}
