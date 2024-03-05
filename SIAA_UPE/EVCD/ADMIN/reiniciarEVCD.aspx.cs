using System;
using SIAA_UPE.CONTROL;

using SIAA_UPE.MODELO.entidades;
using System.Collections.Generic;

namespace SIAA_UPE.EVCD.ADMIN
{
    public partial class reiniciarEVCD : System.Web.UI.Page
    {
        ctrlEVDOC ctrlED = new ctrlEVDOC();
        static List<ED_SIA_EVDOC> ltEVCD = new List<ED_SIA_EVDOC>();
        static List<CA_SIA_DTLAD> ltDA = new List<CA_SIA_DTLAD>();
        string nombre = "";


        protected void Page_Load(object sender, EventArgs e)
        {
            ltEVCD = ctrlED.selecEV_All();
            ltDA = ctrlED.selecDA_All();
            int cED = ltEVCD.Count;
            int cDA = ltDA.Count;

            if(cED!=0)
                lbED.Text = "El sistema cuenta con [" +cED+ "] respuestas registradas.";
            else
                lbED.Text = "El sistema No cuenta con respuestas registradas.";
            if (cDA != 0)
                lbRD.Text = "El sistema cuenta con [" + cDA + "] Docentes asignados a alguna materia.";
            else
                lbRD.Text = "El sistema No cuenta con respuestas registradas.";
            nombre = Session["UserName"] as string;
            lbUserName.Text = nombre;
        }

        protected void btnDeleteR_Click(object sender, EventArgs e)
        {
            if(ctrlED.deleteAll(ltEVCD))
                this.Page.Response.Write("<script language='JavaScript'>window.alert('Se borro Corectamente ');</script>");
            else
                this.Page.Response.Write("<script language='JavaScript'>window.alert('Ocurrio un error porfabor intente mas tarde');</script>");
        }

        protected void btnDeleteD_Click(object sender, EventArgs e)
        {
            if (ctrlED.deleteAllRela(ltDA))
                this.Page.Response.Write("<script language='JavaScript'>window.alert('Se borro Corectamente ');</script>");
            else
                this.Page.Response.Write("<script language='JavaScript'>window.alert('Ocurrio un error porfabor intente mas tarde');</script>");
        }
    }
}