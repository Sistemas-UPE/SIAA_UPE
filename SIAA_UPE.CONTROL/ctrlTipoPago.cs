using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIAA_UPE.MODELO.entidades;

namespace SIAA_UPE.CONTROL
{
    public class ctrlTipoPago
    {
        DBDataContext db = new DBDataContext();
        public Boolean insert(CT_SIA_TIPOPAGO _tipoPago)
        {
            Boolean respuesta = false;
            try
            {
                this.db.CT_SIA_TIPOPAGO.InsertOnSubmit(_tipoPago);
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
        public Boolean Update(CT_SIA_TIPOPAGO _tipoPago)
        {
            bool respuesta = false;
            try
            {
                CT_SIA_TIPOPAGO tipoPago = this.db.CT_SIA_TIPOPAGO.Where(p => p.idTipoPago == _tipoPago.idTipoPago).FirstOrDefault< CT_SIA_TIPOPAGO> ();

                tipoPago.costo = _tipoPago.costo;
                tipoPago.vigenciaInicio = _tipoPago.vigenciaInicio;
                tipoPago.vigenciaFinal = _tipoPago.vigenciaFinal;
                tipoPago.recargos= _tipoPago.recargos;
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
        public List<CT_SIA_TIPOPAGO> select()
        {
            try
            {
                return this.db.CT_SIA_TIPOPAGO.ToList();
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return null;
            }
        }
        public CT_SIA_TIPOPAGO selectByID(int _id)
        {
            try
            {
                return db.CT_SIA_TIPOPAGO.Where(i=> i.idTipoPago ==_id).First();
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return null;
            }
        }
        public double montoByID(int _id)
        {
            try
            {
                CT_SIA_TIPOPAGO pago = db.CT_SIA_TIPOPAGO.Where(i => i.idTipoPago == _id).First();
                CT_SIA_TIPOPAGO recargo = db.CT_SIA_TIPOPAGO.Where(i => i.idTipoPago == 26).First();
                double p = double.Parse(pago.costo.ToString());
                double r = double.Parse(recargo.costo.ToString());

                return r + p;
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return 0.0;
            }
        }
        public List<CT_SIA_TIPOPAGO> selectByGrupo(int _id)
        {
            try
            {
                return db.CT_SIA_TIPOPAGO.Where(i => i.grupo == _id).ToList();
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return null;
            }
        }
        public bool vigente(int _id)
        {
            bool vg = false;
            try
            {
                CT_SIA_TIPOPAGO pago = db.CT_SIA_TIPOPAGO.Where(i => i.idTipoPago == _id).First();

                DateTime vI = DateTime.ParseExact(pago.vigenciaInicio, "yyyy-MM-dd", null);
                DateTime vF = DateTime.ParseExact(pago.vigenciaFinal, "yyyy-MM-dd", null);
                DateTime hoy = DateTime.Today;

                bool estaDentroDelRango = (hoy >= vI) && (hoy <= vF);

                if (estaDentroDelRango)
                {
                    vg = true;
                }
                else
                {
                    vg = false;
                }

                return vg;
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return vg;
            }
        }
    }
}
