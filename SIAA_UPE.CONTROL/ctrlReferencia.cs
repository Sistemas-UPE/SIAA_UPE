using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIAA_UPE.MODELO.entidades;

namespace SIAA_UPE.CONTROL
{
    public class ctrlReferencia
    {
        DBDataContext db = new DBDataContext();
        RG_SIA_GREFERENCIA referencia = new RG_SIA_GREFERENCIA();



        public Boolean insert(RG_SIA_GREFERENCIA _referencia)
        {
            Boolean respuesta = false;
            try
            {
                this.db.RG_SIA_GREFERENCIA.InsertOnSubmit(_referencia);
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

        public int selectByReferencia(long _referencia)
        {
            try
            {
                referencia = this.db.RG_SIA_GREFERENCIA.Where(i => i.referencia == _referencia).First();
                return referencia.idGREFERENCIA;
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return 0;
            }
        }

        public int UltimoRefe()
        {
            try
            {
                RG_SIA_GREFERENCIA referencia = this.db.RG_SIA_GREFERENCIA.ToList().Last();
                return referencia.idGREFERENCIA;
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return 0;
            }
        }

        public RG_SIA_GREFERENCIA selectByR(long _referencia)
        {
            try
            {
                return this.db.RG_SIA_GREFERENCIA.Where(i => i.referencia == _referencia).First();
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return null;
            }
        }


        public RG_SIA_GREFERENCIA selectByAspirante(string _folio)
        {
            try
            {
                return this.db.RG_SIA_GREFERENCIA.Where(i => i.descripcion == _folio).First();
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return null;
            }
        }

        public string  ConsutarPAspirante(int _idreferencia)
        { 
            try
            {
                RG_SIA_PAGOSREALIZADOS_ALUM pagado = db.RG_SIA_PAGOSREALIZADOS_ALUM.Where(i => i.idGREFERENCIA== _idreferencia).ToList().First();
                
                if (pagado != null)
                {
                    return "[FICHA VALIDADA]";
                }
                else
                {
                    return "[FICHA PENDIENTE]";
                }   
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return "[FICHA PENDIENTE]";
            }
        }

        public string ConsutarPAceptado(int _id)
        {
            try
            {
                DP_SIA_ASPIRANTES aspirante = db.DP_SIA_ASPIRANTES.Where(i => i.idAspirante== _id).First();

                string msj = "";
                switch (aspirante.idModalidad)
                {
                    case 1:
                        msj= "[FICHA VALIDADA]";
                        break;
                    case 2:
                        msj= "[HAS SIDO ACEPTADO]";
                        break;
                    case 3:
                        msj= "[PROPEDEUTICO VALIDADA]";
                        break;
                    case 4:
                        msj= "[INSCRIPCION VALIDADA]";
                        break;
                    default:
                        msj= "[PENDIENTE]";
                        break;
                }

                return msj;
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return "[FICHA PENDIENTE]";
            }
        }



        public List<referenciaPagada> ConsutarPagos(string _id)
        {
            List<referenciaPagada> lrp = new List<referenciaPagada>();
            ctrlPagoRealizado pagos = new ctrlPagoRealizado();
            try
            {
                List<RG_SIA_GREFERENCIA> lr = db.RG_SIA_GREFERENCIA.Where(i => i.idAlumno == _id).ToList();

                foreach (RG_SIA_GREFERENCIA item in lr)
                {
                    referenciaPagada rp = new referenciaPagada();
                    RG_SIA_PAGOSREALIZADOS Pagado = pagos.selectByID(item.idGREFERENCIA);

                    rp.Folio = item.idGREFERENCIA;
                    rp.TipoPago = item.CT_SIA_TIPOPAGO.concepto;
                    rp.FehaSolicitud = item.fecha;
                    if (Pagado != null)
                    {
                        rp.Estatus = "Pago Validado";
                        rp.FechaConfirmacion = Pagado.fechaAplicada.ToString();
                    }
                    else
                    {
                        rp.Estatus = "Pago Sin validar";
                        rp.FechaConfirmacion = "-";
                    }
                    lrp.Add(rp);
                }

                return lrp;
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return null;
            }
        }
    }
}
