using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIAA_UPE.MODELO.entidades
{
    public partial class DP_SIA_INSTITUCION
    {
        private string nomMuni;

        public string NomMuni
        {
            get
            {
                return nombre+ " ( " + this.DP_SIA_DOMICILIO.municipio + " ) ";
            }
            set{nomMuni = value;}
        }
    }
}
