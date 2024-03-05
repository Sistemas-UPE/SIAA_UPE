using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIAA_UPE.MODELO.entidades
{
    public class nuevoIngreso
    {
        private string aPaterno;
        private string aMaterno;
        private string nombre;
        private string curp;
        private string correo;
        private string folio;
        private string carrera;
        private string clvCarrera;
        private string telefono;
        private string pagoFicha;
        private string pagoPropedeutico;
        private int estatus;

        public string APaterno { get => aPaterno; set => aPaterno = value; }
        public string AMaterno { get => aMaterno; set => aMaterno = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Curp { get => curp; set => curp = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Folio { get => folio; set => folio = value; }
        public string Carrera { get => carrera; set => carrera = value; }
        public string ClvCarrera { get => clvCarrera; set => clvCarrera = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string PagoFicha { get => pagoFicha; set => pagoFicha = value; }
        public string PagoPropedeutico { get => pagoPropedeutico; set => pagoPropedeutico = value; }
        public int Estatus              { get => estatus;           set => estatus = value; }
    }
}
