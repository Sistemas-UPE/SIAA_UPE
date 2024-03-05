using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIAA_UPE.MODELO.entidades
{
    public class decodifica
    {
        private string matricula;
        private string nombreC;
        private string concepto;
        private string referencia;
        private string importe;
        private string fecha;
        private string sucursal;

        public string Matricula { get => matricula; set => matricula = value; }
        public string NombreC { get => nombreC; set => nombreC = value; }
        public string Concepto { get => concepto; set => concepto = value; }
        public string Referencia { get => referencia; set => referencia = value; }
        public string Importe { get => importe; set => importe = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public string Sucursal { get => sucursal; set => sucursal = value; }
    }
}
