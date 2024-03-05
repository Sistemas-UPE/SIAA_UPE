using SIAA_UPE.MODELO.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIAA_UPE.CONTROL
{
    public class ctrlTutor
    {
        DBDataContext db = new DBDataContext();
        DP_SIA_TUTOR persona = new DP_SIA_TUTOR();
        public int insertUltimo(DP_SIA_TUTOR _tutor)
        {
            try
            {
                this.db.DP_SIA_TUTOR.InsertOnSubmit(_tutor);
                this.db.SubmitChanges();
                DP_SIA_TUTOR t = this.db.DP_SIA_TUTOR.ToList().Last();
                return t.idTutor;
            }
            catch (Exception ex)
            {
                string smg = ex.Message;
                return 0;
            }
        }
    }
}
