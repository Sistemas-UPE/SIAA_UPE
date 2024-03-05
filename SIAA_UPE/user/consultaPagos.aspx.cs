using System;
using System.Collections.Generic;
using SIAA_UPE.CONTROL;
using SIAA_UPE.MODELO.entidades;



namespace SIAA_UPE.user
{
    public partial class consultaPagos : System.Web.UI.Page
    {
        ctrlReferencia ctrlRef = new ctrlReferencia();
        static string matricula,nombre;
        FD_SIA_ALUMNO alumno = new FD_SIA_ALUMNO();
        ctrlAlumno ctrlAl = new ctrlAlumno();
        List<referenciaPagada> rp = new List<referenciaPagada>();

        protected void Page_Load(object sender, EventArgs e)
        {
            matricula = Session["user"] as string;
            nombre = Session["UserName"] as string;
            lbUserName.Text = nombre;
            if (!IsPostBack)
            {
                llenar();
            }
        }
        private void llenar()
        {
            rp = ctrlRef.ConsutarPagos(matricula);
            if(rp.Count!=0)
            {
                gvPagos.DataSource =rp;
                gvPagos.DataBind();
            }
            else
            {
                lbAlerta.Text= "Aun no has generado ninguna referencia. =)";
            }
        }
    }
}