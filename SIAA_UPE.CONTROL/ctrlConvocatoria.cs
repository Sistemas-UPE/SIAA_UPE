using System;
using System.Collections.Generic;
using System.Linq;
using SIAA_UPE.MODELO.entidades;


namespace SIAA_UPE.CONTROL
{
    public class ctrlConvocatoria
    {
        DBDataContext db = new DBDataContext();

        public Boolean insert(CT_SIA_CONVOCATORIA _objeto)
        {
            try
            {
                this.db.CT_SIA_CONVOCATORIA.InsertOnSubmit(_objeto);
                this.db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                string smg = ex.Message;
                return false;
            }
        }
        public Boolean upDate(CT_SIA_CONVOCATORIA _objeto)
        {
            bool respuesta = false;
            try
            {
                CT_SIA_CONVOCATORIA convo = this.db.CT_SIA_CONVOCATORIA.Where(p => p.idConvocatoria == _objeto.idConvocatoria).First();
                convo.mesInicio= _objeto.mesInicio;
                convo.diaInicio= _objeto.diaInicio;
                convo.mesFin = _objeto.mesFin;
                convo.mesFin = _objeto.diaFin;
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
        public Boolean delete(int _id)
        {
            bool respuesta = false;
            try
            {
                CT_SIA_CONVOCATORIA conv = this.db.CT_SIA_CONVOCATORIA.Where(p => p.idConvocatoria == _id).First();
                this.db.CT_SIA_CONVOCATORIA.DeleteOnSubmit(conv);
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
        public CT_SIA_CONVOCATORIA covocatoria()
        {
            try
            {
                List<CT_SIA_CONVOCATORIA> ls = selectRonda();
                CT_SIA_CONVOCATORIA last = ls[ls.Count-1];
                return last;
            }
            catch (Exception e)
            {
                string smg = e.Message;
                return null;
            }
        }
        public CT_SIA_CONVOCATORIA covocatoriaById(int _id)
        {
            try
            {
                return this.db.CT_SIA_CONVOCATORIA.Where(p => p.idConvocatoria==_id).First();
            }
            catch (Exception e)
            {
                string smg = e.Message;
                return null;
            }
        }
        public List<CT_SIA_CONVOCATORIA> selectAll()
        {
            try
            {
                return this.db.CT_SIA_CONVOCATORIA.OrderBy(p => p.ronda).ToList();
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return null;
            }
        }
        public List<CT_SIA_CONVOCATORIA> selectRonda()
        {
            try
            {
                return this.db.CT_SIA_CONVOCATORIA.Where(a=>a.ciclo==DateTime.Today.Year).OrderBy(p => p.ronda).ToList();
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return null;
            }
        }
        public int ultimo()
        {
            return (int)covocatoria().ronda + 1;
        }

    }
}
