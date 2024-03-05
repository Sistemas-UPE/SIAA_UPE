using System.Text.RegularExpressions;


namespace SIAA_UPE.MODELO.entidades
{
    partial class RG_SIA_PAGOSREALIZADOS
    {
        private string matricula;
        private string nombre;
        private string tipo;
        public string Matricula
        {
            get
            {
                try
                {
                    return Regex.Replace(this.RG_SIA_GREFERENCIA.FD_SIA_ALUMNO.generacion + this.RG_SIA_GREFERENCIA.FD_SIA_ALUMNO.idAlumno, @"\s", "").ToUpper();
                }
                catch
                {
                    return "-";
                }
            }

            set
            {
                nombre = value;
            }
        }
        public string Nombre
        {
            get
            {
                try
                {
                    return this.RG_SIA_GREFERENCIA.FD_SIA_ALUMNO.NAlumno;
                }
                catch
                {
                    return this.RG_SIA_GREFERENCIA.FD_SIA_ALUMNO.DP_SIA_PERSONA.nombre;
                }
            }

            set
            {
                nombre = value;
            }
        }
        public string Tipo
        {
            get
            {
                try
                {
                    return this.RG_SIA_GREFERENCIA.CT_SIA_TIPOPAGO.concepto;
                }
                catch
                {
                    return this.RG_SIA_GREFERENCIA.CT_SIA_TIPOPAGO.concepto;
                }
            }

            set
            {
                tipo = value;
            }
        }

    }
}
