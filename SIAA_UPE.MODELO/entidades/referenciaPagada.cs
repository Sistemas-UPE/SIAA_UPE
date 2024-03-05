using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIAA_UPE.MODELO.entidades
{
    public class referenciaPagada
    {
        private int folio;
        private string tipoPago;
        private string fehaSolicitud;
        private string estatus;
        private string fechaConfirmacion;

        public int Folio { get => folio; set => folio = value; }
        public string TipoPago { get => tipoPago; set => tipoPago = value; }
        public string FehaSolicitud { get => fehaSolicitud; set => fehaSolicitud = value; }
        public string Estatus { get => estatus; set => estatus = value; }
        public string FechaConfirmacion { get => fechaConfirmacion; set => fechaConfirmacion = value; }
    }
}
