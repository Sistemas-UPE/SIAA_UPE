using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIAA_UPE.MODELO.entidades
{
    public partial class CA_SIA_DTLAD
    {
        private string nDocente;
        private string nAsignatura;
        private string nAD;


        public string NDocente 
        {
            get
            {
                return this.FD_SIA_DOCENTE.DP_SIA_PERSONA.nombre + " " + this.FD_SIA_DOCENTE.DP_SIA_PERSONA.aPaterno + " " + this.FD_SIA_DOCENTE.DP_SIA_PERSONA.aMaterno;
            }

            set
            {
                nDocente = value;
            }
        }
        public string NAsignatura 
        {
            get
            {
                return this.CA_SIA_ASIGNATURA.nomAsignatura;
            }
            set 
            {
                nAsignatura = value;
            } 
        }

        public string NAD 
        {
            get
            {
                return this.FD_SIA_DOCENTE.DP_SIA_PERSONA.nombre + " " + this.FD_SIA_DOCENTE.DP_SIA_PERSONA.aPaterno + " " + this.FD_SIA_DOCENTE.DP_SIA_PERSONA.aMaterno+ " | "+ this.CA_SIA_ASIGNATURA.nomAsignatura;
            }

            set
            {
                nDocente = value;
            }
        }
    }
}
