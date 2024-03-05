using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIAA_UPE.MODELO.entidades
{
    partial class RG_SIA_RECURSAMIENTOS
    {
        private string nAlumno, asignatura, matricula, cuotaL, estatusL;
        public string NAlumno
        {
            get
            {
                return this.FD_SIA_ALUMNO.DP_SIA_PERSONA.nombre + " " + this.FD_SIA_ALUMNO.DP_SIA_PERSONA.aPaterno + " " + this.FD_SIA_ALUMNO.DP_SIA_PERSONA.aMaterno;
            }

            set
            {
                nAlumno = value;
            }
        }
        public string Asignatura
        {
            get
            {
                return this.CA_SIA_ASIGNATURA.nomAsignatura;
            }

            set
            {
                asignatura = value;
            }
        }
        public string Matricula
        {
            get
            {
                return FD_SIA_ALUMNO.generacion + idAlumno;
            }

            set
            {
                matricula = value;
            }
        }
        public string CuotaL
        {
            get
            {
                if (cuota == 0) 
                { 
                    return "PENDIENTE";
                }
                else
                {
                    return "PAGADO";
                }
            }

            set
            {
                cuotaL = value;
            }
        }
        public string EstatusL
        {
            get
            {
                if (estado == 0 || estado == 100)
                { 
                    return "PENDIENTE";
                }
                else
                {
                    return "APLICADO";
                }
            }

            set
            {
                estatusL = value;
            }
        }

    }
}
