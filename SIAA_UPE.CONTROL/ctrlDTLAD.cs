using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIAA_UPE.MODELO.entidades;


namespace SIAA_UPE.CONTROL
{

    public class ctrlDTLAD
    {
        DBDataContext db = new DBDataContext();

        public Boolean insert(CA_SIA_DTLAD _DTLAD)
        {
            Boolean respuesta = false;
            try
            {
                this.db.CA_SIA_DTLAD.InsertOnSubmit(_DTLAD);
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
        public Boolean Update(CA_SIA_DTLAD _ad)
        { 
            bool respuesta = false;
            try
            {
                CA_SIA_DTLAD ad = db.CA_SIA_DTLAD.Where(p => p.idDtlAD == _ad.idDtlAD).First();
                ad.idGrupo = _ad.idGrupo;
                ad.idAsignatura = _ad.idAsignatura;
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
        public Boolean delete(int _id)
        {
            bool respuesta = false;
            try
            {
                CA_SIA_DTLAD ad = this.db.CA_SIA_DTLAD.Where(p => p.idDtlAD == _id).First();
                this.db.CA_SIA_DTLAD.DeleteOnSubmit(ad);
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
        public List<CA_SIA_DTLAD> selectDxG(string _idG)
        {
            try
            {
                List<CA_SIA_DTLAD> lsMM = this.db.CA_SIA_DTLAD.Where(p => p.idGrupo == _idG).ToList();
                //for (int a = 0; a < lsMM.Count; a++)
                //{
                //    if (lsMM[a].FD_SIA_DOCENTE.perfil.Contains("INGLÉS"))
                //    {
                //        lsMM.RemoveAt(a);
                //    }
                //}

                return lsMM;
            }
            catch (Exception ex)
            {
                string smg = ex.Message;
                return null;
            }
        }
        public List<CA_SIA_DTLAD> selectDxid(string _id)
        {
            try
            {
                List<CA_SIA_DTLAD> lsMM = this.db.CA_SIA_DTLAD.Where(p => p.idDocente == _id).ToList();
                return lsMM;
            }
            catch (Exception ex)
            {
                string smg = ex.Message;
                return null;
            }
        }
        public List<CA_SIA_DTLAD> selectALL()
        {
            try
            {
                List<CA_SIA_DTLAD> lsMM = this.db.CA_SIA_DTLAD.ToList();

                return lsMM;
            }
            catch (Exception ex)
            {
                string smg = ex.Message;
                return null;
            }
        }
        public CA_SIA_DTLAD selecAD(int _id)
        {
            try
            {
                CA_SIA_DTLAD ad = this.db.CA_SIA_DTLAD.Where(p => p.idDtlAD == _id).First();

                return ad;
            }
            catch (Exception ex)
            {
                string smg = ex.Message;
                return null;
            }
        }
        public List<CA_SIA_DTLAD> selectBY(string _browse)
        {
            try
            {
                List<CA_SIA_DTLAD> ad = this.db.CA_SIA_DTLAD.Where(p => p.CA_SIA_ASIGNATURA.nomAsignatura.Contains(_browse)|| p.FD_SIA_DOCENTE.DP_SIA_PERSONA.nombre.Contains(_browse)|| p.idGrupo.Contains(_browse)).ToList();
                return ad;
            }
            catch (Exception ex)
            {
                string smg = ex.Message;

                return null;
            }
        }

    }
}