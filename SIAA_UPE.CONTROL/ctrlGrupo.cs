using System;
using System.Collections.Generic;
using System.Linq;
using SIAA_UPE.MODELO.entidades;


namespace SIAA_UPE.CONTROL
{
    public class ctrlGrupo
    {
        DBDataContext db = new DBDataContext();
        public List<CT_SIA_GRUPO> selectAll()
        {
            try
            {
                return this.db.CT_SIA_GRUPO.ToList();
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return null;
            }
        }

        public List<CT_SIA_GRUPO> selectGxC(string _id, int _estado)
        {
            try
            {
                List<CT_SIA_GRUPO> lsGp = this.db.CT_SIA_GRUPO.Where(p => p.idPE == _id && p.estado == _estado || p.estado == 2).ToList();
                return lsGp;
            }

            catch (Exception e)
            {
                string msg = e.Message;
                return null;
            }
        }

        public List<CT_SIA_GRUPO> selectGC(string _id, string _carrera)
        {
            try
            {
                List<CT_SIA_GRUPO> lsGp = this.db.CT_SIA_GRUPO.Where(p => p.idPE == _id && p.idPE ==_carrera  && p.estado == 1).ToList();
                return lsGp;
            }

            catch (Exception e)
            {
                string msg = e.Message;
                return null;
            }
        }

        public List<CT_SIA_GRUPO> selectG(int _estado)
        {
            try
            {
                List<CT_SIA_GRUPO> lsGp = this.db.CT_SIA_GRUPO.Where(p => p.estado == _estado).ToList();
                return lsGp;
            }

            catch (Exception e)
            {
                string msg = e.Message;
                return null;
            }
        }



        public Boolean insert(CT_SIA_GRUPO _GP)
        {
            Boolean respuesta = false;
            try
            {
                this.db.CT_SIA_GRUPO.InsertOnSubmit(_GP);
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
        public Boolean Update(CT_SIA_GRUPO _gp)
        {
            bool respuesta = false;
            try
            {
                CT_SIA_GRUPO gp = this.db.CT_SIA_GRUPO.Where(p => p.idGrupo == _gp.idGrupo).FirstOrDefault<CT_SIA_GRUPO>();
                gp.idPE = _gp.idPE;
                gp.idGrupo = _gp.idGrupo;
                gp.numAlumnos = _gp.numAlumnos;
                gp.periodo = _gp.periodo;
                gp.estado = _gp.estado;
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
        public Boolean UpdateActivos(List<CT_SIA_GRUPO> _gp)
        {
            bool respuesta = false;
            try
            {
                foreach (var item in _gp)
                {
                    CT_SIA_GRUPO gp = this.db.CT_SIA_GRUPO.Where(p => p.idGrupo == item.idGrupo).First();
                    gp.estado = 0;
                    this.db.SubmitChanges();
                }
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
                CT_SIA_GRUPO cat = this.db.CT_SIA_GRUPO.Where(p => p.idGrupo == _id).FirstOrDefault<CT_SIA_GRUPO>();
                this.db.CT_SIA_GRUPO.DeleteOnSubmit(cat);
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
        public CT_SIA_GRUPO select(string _id)
        {
            try
            {

                CT_SIA_GRUPO lsMT = this.db.CT_SIA_GRUPO.Where(p => p.idGrupo == _id).FirstOrDefault();
                return lsMT;
            }
            catch (Exception ex)
            {
                string smg = ex.Message;

                return null;
            }
        }
        public List<CT_SIA_GRUPO> selectBY(string _browse)
        {
            try
            {
            List<CT_SIA_GRUPO> m = this.db.CT_SIA_GRUPO.Where(p => p.idGrupo.Contains(_browse)).ToList();
                return m;
            }
            catch (Exception ex)
            {
                string smg = ex.Message;

                return null;
            }
        }
        public List<CT_SIA_GRUPO> selectPeriodo(string _periodo)
        {
            try
            {
                List<CT_SIA_GRUPO> m = this.db.CT_SIA_GRUPO.Where(p => p.periodo == _periodo).ToList();
                return m;
            }
            catch (Exception ex)
            {
                string smg = ex.Message;

                return null;
            }
        }

    }
}
