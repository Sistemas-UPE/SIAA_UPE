using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using SIAA_UPE.MODELO.entidades;
namespace SIAA_UPE.CONTROL
{
    public class ctrlPagoRealizado
    {
        DBDataContext db = new DBDataContext();
        ctrlReferencia ctrlRef = new ctrlReferencia();
        decodificar dc = new decodificar();

        public Boolean inser(RG_SIA_PAGOSREALIZADOS _referencia)
        {
            Boolean respuesta = false;
            try
            {
                this.db.RG_SIA_PAGOSREALIZADOS.InsertOnSubmit(_referencia);
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
        public Boolean inserASp(RG_SIA_PAGOSREALIZADOS_ALUM _referencia)
        {
            Boolean respuesta = false;
            try
            {
                this.db.RG_SIA_PAGOSREALIZADOS_ALUM.InsertOnSubmit(_referencia);
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
        public List<RG_SIA_PAGOSREALIZADOS> select()
        {
            try
            {
                return this.db.RG_SIA_PAGOSREALIZADOS.ToList();
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return null;
            }
        }
        public List<RG_SIA_PAGOSREALIZADOS> selectByTipo(int _id)
        {
            try
            {
                return this.db.RG_SIA_PAGOSREALIZADOS.OrderBy(i => i.fechaAplicada).Where(i => i.RG_SIA_GREFERENCIA.idTipoPago == _id).ToList();
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return null;
            }
        }
        public List<RG_SIA_PAGOSREALIZADOS> selectByCarrera(string _id, int _tp)
        {
            try
            {
                return this.db.RG_SIA_PAGOSREALIZADOS.OrderBy(i => i.fechaAplicada).Where(i => i.RG_SIA_GREFERENCIA.FD_SIA_ALUMNO.CT_SIA_GRUPO.CT_SIA_PROEDU.idPE == _id && i.RG_SIA_GREFERENCIA.idTipoPago == _tp).ToList();
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return null;
            }
        }
        public List<RG_SIA_PAGOSREALIZADOS> selectByGrupo(string _id, int _tp , int _gen)
        {
            try
            {
                return this.db.RG_SIA_PAGOSREALIZADOS.OrderBy(i => i.fechaAplicada).Where(i => i.RG_SIA_GREFERENCIA.FD_SIA_ALUMNO.CT_SIA_GRUPO.CT_SIA_PROEDU.idPE == _id && i.RG_SIA_GREFERENCIA.idTipoPago == _tp && i.RG_SIA_GREFERENCIA.FD_SIA_ALUMNO.generacion == _gen).ToList();
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return null;
            }
        }
        public Boolean selectByReferencia(int _id)
        {
            try
            {
                RG_SIA_PAGOSREALIZADOS pago =this.db.RG_SIA_PAGOSREALIZADOS.Where(i => i.idGREFERENCIA == _id).First();

                if (pago != null)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return false;
            }
        }
        public RG_SIA_PAGOSREALIZADOS selectByID(int _id)
        {
            try
            {
                return this.db.RG_SIA_PAGOSREALIZADOS.Where(i => i.idGREFERENCIA == _id).First();
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return null;
            }
        }
        public Boolean selectByReferenciaAL(int _id)
        {
            try
            {
                RG_SIA_PAGOSREALIZADOS_ALUM pago = this.db.RG_SIA_PAGOSREALIZADOS_ALUM.Where(i => i.idGREFERENCIA == _id).First();

                if (pago != null)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return false;
            }
        }
        public Boolean selectIsRecursamiento(int _id)
        {
            try
            {
                RG_SIA_GREFERENCIA referencia = this.db.RG_SIA_GREFERENCIA.Where(i => i.idGREFERENCIA == _id).First();
                if(referencia.idTipoPago==16)return true;
                else return false;
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return false;
            }
        }
        public Boolean recursePagado(int _id)
        {
            try
            {
                RG_SIA_RECURSAMIENTOS r =db.RG_SIA_RECURSAMIENTOS.Where(p => p.idRecursamiento == _id).FirstOrDefault();
                r.cuota = 1;
                this.db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public int ultimoPago()
        {
            try
            {
                List<RG_SIA_PAGOSREALIZADOS> aspirante = this.db.RG_SIA_PAGOSREALIZADOS.ToList();
                int largo = aspirante.Count;
                return aspirante[largo - 1].idPagoRealizado;
            }
            catch (Exception e)
            {
                string smg = e.Message;
                return 0;
            }
        }
        public int ultimoPagoAL()
        {
            try
            {
                List<RG_SIA_PAGOSREALIZADOS_ALUM> aspirante = this.db.RG_SIA_PAGOSREALIZADOS_ALUM.ToList();
                int largo = aspirante.Count;
                return aspirante[largo - 1].idPagoRealizadoAlu;
            }
            catch (Exception e)
            {
                string smg = e.Message;
                return 0;
            }
        }
    }
}
