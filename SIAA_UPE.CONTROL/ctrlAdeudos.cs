using SIAA_UPE.MODELO.entidades;
using System;
using System.Linq;

namespace SIAA_UPE.CONTROL
{
    public class ctrlAdeudos
    {
        DBDataContext db = new DBDataContext();
        public RG_SIA_RECURSAMIENTOS recursamiento(int _id)
        {
            try
            {
                return this.db.RG_SIA_RECURSAMIENTOS.Where(p => p.idRecursamiento == _id).First();
            }
            catch (Exception e)
            {
                string smg = e.Message;
                return null;
            }
        }
        public Boolean delete(int _id)
        {
            bool respuesta = false;
            try
            {
                RG_SIA_RECURSAMIENTOS rec = this.db.RG_SIA_RECURSAMIENTOS.Where(p => p.idRecursamiento == _id).First();
                this.db.RG_SIA_RECURSAMIENTOS.DeleteOnSubmit(rec);
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
    }
}
