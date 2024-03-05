using System;
using System.Collections.Generic;
using SIAA_UPE.CONTROL;
using SIAA_UPE.MODELO.entidades;

namespace SIAA_UPE.admin
{
    public partial class nTiket : System.Web.UI.Page
    {
        CT_SIA_TIPOPAGO lisTipo = new CT_SIA_TIPOPAGO();
        ctrlTipoPago ctrlTP = new ctrlTipoPago();
        double practicaja, ventanilla;



        protected void Page_Load(object sender, EventArgs e)
        {
            int idP = int.Parse(Session["idPago"] as string);
            llenar(idP);
        }
        private void llenar(int _idP)
        {
            lisTipo = ctrlTP.selectByID(_idP);
            lbFechaR.Text = DateTime.Today.ToString();
            lbConceptoR.Text =lisTipo.concepto;

        }
    }
}