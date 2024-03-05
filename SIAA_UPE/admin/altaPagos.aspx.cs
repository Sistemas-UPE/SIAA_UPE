using System;
using System.Collections.Generic;
using System.IO;
using SIAA_UPE.CONTROL;
using SIAA_UPE.MODELO.entidades;


namespace SIAA_UPE.admin
{
    public partial class altaPagos : System.Web.UI.Page
    {
        codificar code = new codificar();
        decodificar dec = new decodificar();
        ctrlReferencia ctrlRef = new ctrlReferencia();
        ctrlPagoRealizado ctrlPagos = new ctrlPagoRealizado();
        ctrlAspirante ctrlA = new ctrlAspirante();
        ctrlAlumno ctrlAL = new ctrlAlumno();
        RG_SIA_GREFERENCIA refe = new RG_SIA_GREFERENCIA();
        static List<decodifica> lista = new List<decodifica>();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void UploadButton_Click(object sender, EventArgs e)
        {
            llenar();
            if (lista.Count!=0)
            {
                this.gv.DataSource = lista;
                this.gv.DataBind();
            }
        }

        private List<decodifica> llenar()
        {
            StreamReader reader = new StreamReader(FileUploadControl.FileContent);
            lista = dec.decAspirantes(reader);
            reader.DiscardBufferedData();
            reader.Close();
            return lista;
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
           
        }
    }
}