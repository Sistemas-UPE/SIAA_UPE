using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIAA_UPE.MODELO.entidades
{
    public partial class FD_SIA_DOCENTE
    {
        private string nDocente;
        public string NDocente
        {
            get
            {
                return this.DP_SIA_PERSONA.nombre + " " + this.DP_SIA_PERSONA.aPaterno + " " + this.DP_SIA_PERSONA.aMaterno;
            }

            set
            {
                nDocente = value;
            }
        }
    }
}

