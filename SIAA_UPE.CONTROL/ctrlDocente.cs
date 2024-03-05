using System;
using System.Collections.Generic;
using System.Linq;
using SIAA_UPE.MODELO.entidades;


namespace SIAA_UPE.CONTROL
{
    public class ctrlDocente
    {
        DBDataContext db = new DBDataContext();
        ctrlDTLAD ctrlAD = new ctrlDTLAD();

        public Boolean insert(FD_SIA_DOCENTE _mtro)
        {
            Boolean respuesta = false;
            try
            {
                this.db.FD_SIA_DOCENTE.InsertOnSubmit(_mtro);
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
        public Boolean upDate(FD_SIA_DOCENTE _mtro)
        {
            bool respuesta = false;
            try
            {
                FD_SIA_DOCENTE mtro = this.db.FD_SIA_DOCENTE.Where(p => p.idDocente== _mtro.idDocente).First();
                mtro.idPersona = _mtro.idPersona;
                mtro.hAsignadas = _mtro.hAsignadas;
                mtro.perfil = _mtro.perfil;
                mtro.promedioED = _mtro.promedioED;
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
        public Boolean upPromedio(double _promedio, string _id)
        {
            bool respuesta = false;
            try
            {
                FD_SIA_DOCENTE mtro = this.db.FD_SIA_DOCENTE.Where(p => p.idDocente == _id).First();
                mtro.promedioED = (decimal)_promedio;
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
        public Boolean delete(string _id)
        {
            bool respuesta = false;
            try
            {
                FD_SIA_DOCENTE doc = this.db.FD_SIA_DOCENTE.Where(p => p.idDocente== _id).First();
                this.db.FD_SIA_DOCENTE.DeleteOnSubmit(doc);
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
        public FD_SIA_DOCENTE docente(string _matricula)
        {
            try
            {
                return this.db.FD_SIA_DOCENTE.Where(p => p.idDocente == _matricula).First();
            }
            catch (Exception e)
            {
                string smg = e.Message;
                return null;
            }
        }

        public List<FD_SIA_DOCENTE> selectAll()
        {
            try
            {
                return this.db.FD_SIA_DOCENTE.OrderBy(p => p.DP_SIA_PERSONA.nombre).ToList();
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return null;
            }
        }

        public List<FD_SIA_DOCENTE> selectEVCD()
        {
            List<int> lBorrar = new List<int>();
            try
            {
                List < FD_SIA_DOCENTE > lD= db.FD_SIA_DOCENTE.OrderBy(p => p.DP_SIA_PERSONA.nombre).ToList();

                int cont = lD.Count;
                for (int z = 0; z < cont; z++)
                {
                    string idD = lD[z].idDocente;
                    List<CA_SIA_DTLAD> lAD = ctrlAD.selectDxid(idD);
                    if (lAD.Count == 0)
                    {
                        lBorrar.Add(z);
                    }
                }
                int a = lBorrar.Count-1;
                for (;a >= 0; a--)
                {
                    lD.RemoveAt(lBorrar[a]);
                }


                return lD;
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return null;
            }
        }
    }
}
