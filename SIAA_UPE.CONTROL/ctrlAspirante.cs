using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIAA_UPE.MODELO.entidades;


namespace SIAA_UPE.CONTROL
{
    public class ctrlAspirante
    {
        DBDataContext db = new DBDataContext();
        RG_SIA_GREFERENCIA referencia = new RG_SIA_GREFERENCIA();
        ctrlReferencia ctrlR = new ctrlReferencia();

        public bool insert(DP_SIA_ASPIRANTES _ASPIRRANTE)
        {
            try
            {
                this.db.DP_SIA_ASPIRANTES.InsertOnSubmit(_ASPIRRANTE);
                this.db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                string smg = ex.Message;
                return false;
            }
        }

        public bool update(DP_SIA_ASPIRANTES _ASPIRANTE)
        {
            try
            {
                DP_SIA_ASPIRANTES aspi = this.db.DP_SIA_ASPIRANTES.Where(p => p.idAspirante == _ASPIRANTE.idAspirante).FirstOrDefault<DP_SIA_ASPIRANTES>();
                aspi.idTutor = _ASPIRANTE.idTutor;
                aspi.idPersona = _ASPIRANTE.idPersona;
                aspi.idProcedencia = _ASPIRANTE.idProcedencia;
                aspi.idPE = _ASPIRANTE.idPE;
                aspi.urlDocumentos = _ASPIRANTE.urlDocumentos;
                aspi.beca = _ASPIRANTE.beca;
                aspi.idModalidad = _ASPIRANTE.idModalidad;

                this.db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                string smg = ex.Message;
                return false;
            }
        }

        public int insertProcedencia(CE_SIA_PROCEDENCIA _procedencia)
        {
            try
            {
                this.db.CE_SIA_PROCEDENCIA.InsertOnSubmit(_procedencia);
                this.db.SubmitChanges();

                CE_SIA_PROCEDENCIA pro = this.db.CE_SIA_PROCEDENCIA.ToList().Last();

                return pro.idProcedencia;
            }
            catch (Exception ex)
            {
                string smg = ex.Message;
                return 0;
            }
        }

        public int ultimoAspirante()
        {
            try
            {
                DP_SIA_ASPIRANTES aspirante =  this.db.DP_SIA_ASPIRANTES.ToList().Last();
                return aspirante.idAspirante;
            }
            catch (Exception e)
            {
                string smg = e.Message;
                return 0;
            }
        }
        public DP_SIA_ASPIRANTES sech(string _curp)
        {
            try
            {
                DP_SIA_ASPIRANTES aspirante = db.DP_SIA_ASPIRANTES.Where(p => p.curp == _curp).First();
                return aspirante;
            }
            catch (Exception e)
            {
                string smg = e.Message;
                return null;
            }
        }
        
        public DP_SIA_ASPIRANTES aspirantebyfolio(int _id)
        {
            try
            {
                DP_SIA_ASPIRANTES aspirante = db.DP_SIA_ASPIRANTES.Where(p => p.idAspirante == _id).First();
                return aspirante;
            }
            catch (Exception e)
            {
                string smg = e.Message;
                return null;
            }

        }

        public List<CT_SIA_INDIGENA> indigena()
        {
            List<CT_SIA_INDIGENA> ins = new List<CT_SIA_INDIGENA>();
            try
            {
                ins = db.CT_SIA_INDIGENA.Where(p => p.idIndigena!=1).ToList();
                return ins;
            }
            catch
            {
                return null;
            }
        }

        public List<DP_SIA_ASPIRANTES> select()
        {
            try
            {
                return db.DP_SIA_ASPIRANTES.Where(p => p.curp != null).ToList();
            }
            catch
            {
                return null;
            }
        }

        public List<nuevoIngreso> nuevoIng()
        {
            List<nuevoIngreso> lni = new List<nuevoIngreso>();
            List<DP_SIA_ASPIRANTES> aspirantes = select();

            foreach (var item in aspirantes)
            {
                try
                {

                    string folio = "F-" + item.idAspirante.ToString("D4");
                    nuevoIngreso ni = new nuevoIngreso();
                    referencia = ctrlR.selectByAspirante(folio);
                    string fp = ctrlR.ConsutarPAspirante(referencia.idGREFERENCIA);

                    ni.APaterno = item.DP_SIA_PERSONA.aPaterno;
                    ni.AMaterno = item.DP_SIA_PERSONA.aMaterno;
                    ni.Nombre = item.DP_SIA_PERSONA.nombre;
                    ni.Curp = item.DP_SIA_PERSONA.CURP;
                    ni.Correo = item.DP_SIA_PERSONA.cElectronico;
                    ni.Folio = folio;
                    ni.Carrera = item.CT_SIA_PROEDU.nomProEdu;
                    ni.ClvCarrera = item.idPE;
                    ni.Telefono = item.DP_SIA_PERSONA.nTelefonicoCel;
                    ni.PagoFicha = fp;
                    ni.PagoPropedeutico = "[A definir]";
                    ni.Estatus = (int)item.idModalidad;

                    if (validar(item.DP_SIA_PERSONA.CURP))
                    {
                        lni.Add(ni);
                    }
                    else
                    {
                        if (!lni[(lni.Count) - 1].Curp.Equals(item.DP_SIA_PERSONA.CURP))
                        {
                            lni.Add(ni);
                        }
                    }
                }
                catch(Exception el)
                { string msg = el.Message; }
            }

            return lni;
        }

        private Boolean validar(string _curp)
        {
            try
            {
                List<DP_SIA_ASPIRANTES> aspira = db.DP_SIA_ASPIRANTES.Where(p => p.DP_SIA_PERSONA.CURP == _curp).ToList();
                if(aspira.Count==1)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public List<dtlAspirantes> detalle(string _curp)
        {
            List<dtlAspirantes> lsa = new List<dtlAspirantes>();

            try
            {
                DP_SIA_ASPIRANTES aspirante = db.DP_SIA_ASPIRANTES.Where(p => p.DP_SIA_PERSONA.CURP == _curp).First();

                dtlAspirantes a =llenarDetalle(aspirante);
                lsa.Add(a);
                return lsa;
            }
            catch (Exception e)
            {
                string smg = e.Message;
                return null;
            }
        }

        private dtlAspirantes llenarDetalle(DP_SIA_ASPIRANTES _apirante)
        {
            
            dtlAspirantes a = new dtlAspirantes();
            a.CarreraInteres = _apirante.CT_SIA_PROEDU.nomProEdu;
            a.NCompleto = _apirante.NAlumno;
            a.Direccion = _apirante.DP_SIA_PERSONA.DP_SIA_DOMICILIO.calle 
                +" "+ _apirante.DP_SIA_PERSONA.DP_SIA_DOMICILIO.nExterno 
                + " - " + _apirante.DP_SIA_PERSONA.DP_SIA_DOMICILIO.nInterno 
                + " " + _apirante.DP_SIA_PERSONA.DP_SIA_DOMICILIO.colonia 
                + " " + _apirante.DP_SIA_PERSONA.DP_SIA_DOMICILIO.municipio 
                + " " + _apirante.DP_SIA_PERSONA.DP_SIA_DOMICILIO.CT_SIA_ESTADO.nomEstado 
                + " " + _apirante.DP_SIA_PERSONA.DP_SIA_DOMICILIO.cp;
            a.Telefono = _apirante.DP_SIA_PERSONA.nTelefonicoCel;
            a.Correo = _apirante.DP_SIA_PERSONA.cElectronico;
            a.Rfc = _apirante.DP_SIA_PERSONA.RFC;
            a.FechaNa = _apirante.DP_SIA_PERSONA.fNacimiento.ToString();
            a.Genero = _apirante.DP_SIA_PERSONA.sexo;
            a.Tiposangre = _apirante.DP_SIA_PERSONA.tipoSangre;
            a.Curp = _apirante.DP_SIA_PERSONA.CURP;
            a.Edad = _apirante.DP_SIA_PERSONA.edad.ToString();
            a.EstadoCivil = _apirante.DP_SIA_PERSONA.eCivil;
            a.Nhijos = _apirante.DP_SIA_PERSONA.hijos + " hijo(s)";
            a.SMedico = _apirante.DP_SIA_PERSONA.servicioMedico;
            a.Nseguro = _apirante.DP_SIA_PERSONA.ns;
            a.Discapasidad = _apirante.DP_SIA_PERSONA.discapacidad;
            a.Indigena = _apirante.DP_SIA_PERSONA.CT_SIA_INDIGENA.dialecto;
            a.Bachillerato = _apirante.CE_SIA_PROCEDENCIA.DP_SIA_INSTITUCION.nombre;
            a.Municipio = _apirante.CE_SIA_PROCEDENCIA.DP_SIA_INSTITUCION.DP_SIA_DOMICILIO.municipio;
            a.FechaConclu = _apirante.CE_SIA_PROCEDENCIA.fEgreso.ToString();
            a.PromedioF = _apirante.CE_SIA_PROCEDENCIA.promedio;
            a.Documento = _apirante.CE_SIA_PROCEDENCIA.nCedula;
            a.Beca = _apirante.beca;
            a.NCompletoTutor = _apirante.DP_SIA_TUTOR.DP_SIA_PERSONA.nombre + " "+
                _apirante.DP_SIA_TUTOR.DP_SIA_PERSONA.aPaterno + " " +
                _apirante.DP_SIA_TUTOR.DP_SIA_PERSONA.aMaterno;
            a.Ocupacion = _apirante.DP_SIA_TUTOR.ocupacion;
            a.Parentesco = _apirante.DP_SIA_TUTOR.parentesco;
            a.DireccionTutor = _apirante.DP_SIA_TUTOR.DP_SIA_PERSONA.alergia+" "+ _apirante.DP_SIA_TUTOR.DP_SIA_PERSONA.discapacidad;
            a.Telefonotutor = _apirante.DP_SIA_TUTOR.DP_SIA_PERSONA.nTelefonicoCel;
            a.Url = _apirante.urlDocumentos;
            return a;
        }

        public void aAceptado(int _id)
        {
            try
            {
                DP_SIA_ASPIRANTES aspirante = db.DP_SIA_ASPIRANTES.Where(p => p.idAspirante == _id).First();
                aspirante.idModalidad = aspirante.idModalidad+1;
                this.db.SubmitChanges();
            }
            catch (Exception e)
            {
                string smg = e.Message;
            }
        }
    }
}   
