using System.Text.RegularExpressions;

namespace SIAA_UPE.MODELO.entidades
{
    public partial class DP_SIA_ASPIRANTES
    {
        private string nAlumno;
        public string NAlumno
        {
            get
            {
                try
                {
                    return Regex.Replace(this.DP_SIA_PERSONA.nombre, @"\s", "") + " " + Regex.Replace(this.DP_SIA_PERSONA.aPaterno, @"\s", "") + " " + Regex.Replace(this.DP_SIA_PERSONA.aMaterno, @"\s", "");
                }
                catch
                {
                    return this.DP_SIA_PERSONA.nombre;
                }
            }

            set
            {
                nAlumno = value;
            }
        }
    }
}
