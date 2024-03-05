using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIAA_UPE.MODELO.entidades;

namespace SIAA_UPE.CONTROL
{
    public class ctrlPersona
    {
        DBDataContext db = new DBDataContext();
        DP_SIA_PERSONA persona = new DP_SIA_PERSONA();
        DP_SIA_ASPIRANTES aspirante = new DP_SIA_ASPIRANTES();


        public Boolean insert(DP_SIA_PERSONA _PERSONA)
        {
            try
            {
                this.db.DP_SIA_PERSONA.InsertOnSubmit(_PERSONA);
                this.db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                string smg = ex.Message;
                return false;
            }
        }
        public int insertUltimo(DP_SIA_PERSONA _PERSONA)
        {
            try
            {
                this.db.DP_SIA_PERSONA.InsertOnSubmit(_PERSONA);
                this.db.SubmitChanges();
                DP_SIA_PERSONA persona = this.db.DP_SIA_PERSONA.ToList().Last();
                return persona.idPersona;
            }
            catch (Exception ex)
            {
                string smg = ex.Message;
                return 0;
            }
        }

        public int selectCURP(string _curp)
        {
            try
            {
                persona = this.db.DP_SIA_PERSONA.Where(i => i.CURP == _curp).First();

                return persona.idPersona;
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return 0;
            }
        }
        
        public DP_SIA_ASPIRANTES aceptado(string _curp)
        {
            try
            {
                aspirante = this.db.DP_SIA_ASPIRANTES.Where(i => i.DP_SIA_PERSONA.CURP == _curp && i.idModalidad == 3).First();
                return aspirante;
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return null;
            }
        }

        public Boolean updatePersona(DP_SIA_PERSONA _persona)
        {
            try
            {
                persona = this.db.DP_SIA_PERSONA.Where(i => i.idPersona == _persona.idPersona).First();
                persona.cElectronico = _persona.cElectronico;
                persona.fNacimiento = _persona.fNacimiento;
                persona.sexo = _persona.sexo;
                persona.discapacidad = _persona.discapacidad;
                persona.nTelefonicoCel = _persona.nTelefonicoCel;
                persona.DP_SIA_DOMICILIO.calle = _persona.DP_SIA_DOMICILIO.calle;
                persona.DP_SIA_DOMICILIO.colonia = _persona.DP_SIA_DOMICILIO.colonia;
                persona.DP_SIA_DOMICILIO.municipio = _persona.DP_SIA_DOMICILIO.municipio;
                persona.DP_SIA_DOMICILIO.Localidad = _persona.DP_SIA_DOMICILIO.Localidad;
                persona.DP_SIA_DOMICILIO.idEstado = _persona.DP_SIA_DOMICILIO.idEstado;

                db.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return false;
            }
        }
        public List<CT_SIA_ESTADO> estados()
        {
            try
            {
                return this.db.CT_SIA_ESTADO.OrderBy(p => p.nomEstado).ToList();
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return null;
            }
        }
        public int Ultimodir()
        {
            try
            {
                DP_SIA_DOMICILIO direccion = this.db.DP_SIA_DOMICILIO.ToList().Last();
                return direccion.idDireccion;
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return 0;
            }
        }
        public int Ultimo()
        {
            try
            {
                DP_SIA_PERSONA persona = this.db.DP_SIA_PERSONA.ToList().Last();
                return persona.idPersona;
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return 0;
            }
        }

        public Boolean insertDireccion(DP_SIA_DOMICILIO _domi)
        {
            try
            {
                this.db.DP_SIA_DOMICILIO.InsertOnSubmit(_domi);
                this.db.SubmitChanges();

                return true;
            }
            catch (Exception ex)
            {
                string smg = ex.Message;
                return false;
            }
        }
        public int insertDireccionUltimo(DP_SIA_DOMICILIO _domi)
        {
            try
            {
                this.db.DP_SIA_DOMICILIO.InsertOnSubmit(_domi);
                this.db.SubmitChanges();
                DP_SIA_DOMICILIO direccion = this.db.DP_SIA_DOMICILIO.ToList().Last();
                return direccion.idDireccion;
            }
            catch (Exception ex)
            {
                string smg = ex.Message;
                return 0;
            }
        }
        public int inserttutor(DP_SIA_TUTOR _tutor)
        {
            try
            {
                this.db.DP_SIA_TUTOR.InsertOnSubmit(_tutor);
                this.db.SubmitChanges();
                DP_SIA_TUTOR tutor = this.db.DP_SIA_TUTOR.ToList().Last();
                return tutor.idTutor;
            }
            catch (Exception ex)
            {
                string smg = ex.Message;
                return 0;
            }
        }
    }
}
