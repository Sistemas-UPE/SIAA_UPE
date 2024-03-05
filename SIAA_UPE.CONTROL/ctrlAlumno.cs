using System;
using System.Collections.Generic;
using System.Linq;
using SIAA_UPE.MODELO.entidades;

namespace SIAA_UPE.CONTROL
{
    public class ctrlAlumno
    {
        DBDataContext db = new DBDataContext();

        public string intentos(string _us, string _ps)
        {
            string msj = "Lo sentimos, no te quedan mas intentos";
            int intentos = 0;
            try
            {
                FD_SIA_ALUMNO alu = this.db.FD_SIA_ALUMNO.Where(p => p.idAlumno == _us && p.password == _ps).First();
                intentos = (int)alu.intEVCD;
                switch (alu.idSituacionActual)
                {
                    case "1         ":
                        if (intentos > 0)
                        {
                            intentos++;
                            alu.intEVCD = intentos;
                            this.db.SubmitChanges();
                            msj = "1";
                        }
                        else
                        {
                            msj = "Lo sentimos, no te quedan mas intentos";
                        }
                        break;
                }
            }
            catch (Exception e)
            {
                string smg = e.Message;
                msj = "Usuario o contraseña incorrecta: ";

            }
            return msj;

        }
        public bool update(FD_SIA_ALUMNO _alumno)
        {
            try
            {
                FD_SIA_ALUMNO alumno = this.db.FD_SIA_ALUMNO.Where(p => p.idAlumno == _alumno.idAlumno).First();
                alumno.idSituacionActual = _alumno.idSituacionActual;
                alumno.password = _alumno.password;
                alumno.idGrupo = _alumno.idGrupo;
                this.db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                string smg = ex.Message;
                return false;
            }

        }

        public FD_SIA_ALUMNO alumno(string _matricula)
        {
            try
            {
                return this.db.FD_SIA_ALUMNO.Where(p => p.idAlumno == _matricula).First();
            }
            catch (Exception e)
            {
                string smg = e.Message;
                return null;
            }
        }
        public FD_SIA_ALUMNO alumnoXnombre(string _nombre)
        {
            try
            {
                return this.db.FD_SIA_ALUMNO.Where(p => p.DP_SIA_PERSONA.nombre == _nombre).First();
            }
            catch (Exception e)
            {
                string smg = e.Message;
                return null;
            }
        }

        public FD_SIA_ALUMNO selecAlumno(int _idPersona)
        {

            try
            {
                FD_SIA_ALUMNO lsAlumno = db.FD_SIA_ALUMNO.Where(p => p.idPersona == _idPersona).First();
                return lsAlumno;
            }
            catch (Exception ex)
            {
                string smg = ex.Message;

                return null;
            }
        }

        public Boolean insertAlumno(FD_SIA_ALUMNO _ALUMNO)
        {
            try
            {
                this.db.FD_SIA_ALUMNO.InsertOnSubmit(_ALUMNO);
                this.db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                string smg = ex.Message;
                return false;
            }
        }

        //public Boolean insertDTL(DTL_SIA_ALUMNO_REFERENCIA _DTL)
        //{
        //    Boolean respuesta = false;
        //    try
        //    {
        //        this.db.DTL_SIA_ALUMNO_REFERENCIA.InsertOnSubmit(_DTL);
        //        this.db.SubmitChanges();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        string smg = ex.Message;
        //        respuesta = false;
        //    }
        //    return respuesta;
        //}

        //public List<string> fichaPagada(int _idPago)
        //{
        //    List<string> pagos = new List<string>();
        //    List<RG_SIA_PAGOSREALIZADOS_ALUM> pagado = db.RG_SIA_PAGOSREALIZADOS_ALUM.Where(p => p.RG_SIA_GREFERENCIA.idTipoPago == _idPago).ToList();
        //    DTL_SIA_ALUMNO_REFERENCIA ar = new DTL_SIA_ALUMNO_REFERENCIA();
        //    string cadena = "";
        //    foreach (var Nombres in pagado)
        //    {
        //        try
        //        {
        //            ar = db.DTL_SIA_ALUMNO_REFERENCIA.Where(p => p.idGREFERENCIA == Nombres.idGREFERENCIA).First();
        //            cadena = ar.FD_SIA_ALUMNO.generacion + ar.FD_SIA_ALUMNO.idAlumno + " | " + (ar.FD_SIA_ALUMNO.NAlumno).ToUpper();
        //        }
        //        catch
        //        {
        //            cadena = "Error";
        //        }
        //        pagos.Add(cadena);
        //    }
        //    pagos = pagos.OrderBy(pago => pago).ToList();
        //    return pagos;
        //}

        //public List<string> fichaPagada(int _idPago, int _carrera)
        //{
        //    List<string> pagos = new List<string>();
        //    List<RG_SIA_PAGOSREALIZADOS_ALUM> pagado = db.RG_SIA_PAGOSREALIZADOS_ALUM.Where(p => p.RG_SIA_GREFERENCIA.idTipoPago == _idPago).ToList();
        //    //DTL_SIA_ALUMNO_REFERENCIA ar = new DTL_SIA_ALUMNO_REFERENCIA();
        //    string cadena = "";
        //    foreach (var Nombres in pagado)
        //    {
        //        try
        //        {
        //            ar = db.DTL_SIA_ALUMNO_REFERENCIA.Where(p => p.idGREFERENCIA == Nombres.idGREFERENCIA).First();
        //            cadena = ar.FD_SIA_ALUMNO.generacion + ar.FD_SIA_ALUMNO.idAlumno + " | " + (ar.FD_SIA_ALUMNO.NAlumno).ToUpper();
        //        }
        //        catch
        //        {
        //            cadena = "Error";
        //        }
        //        pagos.Add(cadena);
        //    }
        //    pagos = pagos.OrderBy(pago => pago).ToList();
        //    return pagos;
        //}

        //public DTL_SIA_ALUMNO_REFERENCIA selecAlumnoXReferencia(string _idalumno)
        //{
        //    try
        //    {
        //        DTL_SIA_ALUMNO_REFERENCIA lsAlumnoR = db.DTL_SIA_ALUMNO_REFERENCIA.Where(p => p.idAlumno == _idalumno).First();
        //        RG_SIA_GREFERENCIA referencia = db.RG_SIA_GREFERENCIA.Where(p => p.idGREFERENCIA == lsAlumnoR.idGREFERENCIA && p.idTipoPago == 1).First();
        //        if (referencia != null)
        //        {
        //            return lsAlumnoR;
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string smg = ex.Message;

        //        return null;
        //    }
        //}
        public List<DP_SIA_INSTITUCION> instituciones()
        {
            List<DP_SIA_INSTITUCION> ins = new List<DP_SIA_INSTITUCION>();
            try
            {
                ins = db.DP_SIA_INSTITUCION.Where(p => p.clave == "1").ToList();
                return ins;
            }
            catch
            {
                return null;
            }
        }
        public List<CT_SIA_SITUACIONACTUAL> selectSituacion()
        {
            try
            {
                return db.CT_SIA_SITUACIONACTUAL.ToList(); ;
            }
            catch
            {
                return null;
            }

        }

        public string carrera(string _matricula)
        {
            string matricula = _matricula;
            matricula = matricula.Substring(4,2);

           switch(matricula)
            {
                case "IE":
                    matricula= "IE";
                    break;
                case "IP":
                    matricula = "IP";
                    break;
                case "IL":
                    matricula = "ILT";
                    break;
                case "IS":
                    matricula = "ISIE";
                    break;
            }
            return matricula;
        }

        public bool recursamiento(RG_SIA_RECURSAMIENTOS _recursamiento)
        {
            try
            {
                this.db.RG_SIA_RECURSAMIENTOS.InsertOnSubmit(_recursamiento);
                this.db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                string smg = ex.Message;
                return false;
            }

        }
        public List<RG_SIA_RECURSAMIENTOS> listRecursamiento()
        {
            try
            {
                return db.RG_SIA_RECURSAMIENTOS.ToList(); ;
            }
            catch
            {
                return null;
            }
        }
        public List<RG_SIA_RECURSAMIENTOS> listRecursamientobyAlumno(string _matricula)
        {
            try
            {
                return db.RG_SIA_RECURSAMIENTOS.Where(p => p.idAlumno == _matricula).ToList();
            }
            catch
            {
                return null;
            }
        }
        public int numRecursamientobyAlumno(string _matricula)
        {
            try
            {
                List<RG_SIA_RECURSAMIENTOS> rc= db.RG_SIA_RECURSAMIENTOS.Where(p => p.idAlumno == _matricula).ToList();
                return rc.Count;
            }
            catch
            {
                return 0;
            }
        }
    }
}
