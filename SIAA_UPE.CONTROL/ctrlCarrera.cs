using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIAA_UPE.MODELO.entidades;

namespace SIAA_UPE.CONTROL
{
    public class ctrlCarrera
    {
        DBDataContext db = new DBDataContext();
        public List<CT_SIA_PROEDU> select(int _id)
        {
            try
            {
                return this.db.CT_SIA_PROEDU.Where(i => i.ciclo != _id).ToList();
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return null;
            }
        }
        public List<CT_SIA_PROEDU> selectSinMM()
        {
            try
            {
                return this.db.CT_SIA_PROEDU.Where(i => i.ciclo != 0 && i.ciclo !=6).ToList();
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return null;
            }
        }

        public CT_SIA_PROEDU selectByID(int _id)
        {
            try
            {
                return this.db.CT_SIA_PROEDU.Where(i => i.idAutoriza== _id).First();
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return this.db.CT_SIA_PROEDU.Where(i => i.idAutoriza == 6).First(); ;
            }
        }
    }
}
