using System;
using SIAA_UPE.CONTROL;
using SIAA_UPE.MODELO.entidades;

namespace SIAA_UPE.user
{
    public partial class home : System.Web.UI.Page
    {
        static string matricula;
        ctrlAlumno ctrlAl = new ctrlAlumno();
        codificar code = new codificar();
        FD_SIA_ALUMNO alumno = new FD_SIA_ALUMNO();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                matricula = Session["user"] as string;
                alumno = ctrlAl.alumno(matricula);
                lbNombre.Text = alumno.NAlumno;
            }
            catch (Exception ex)
            {

                string a = ex.Message;
                Response.Redirect("../login.aspx");

            }

        }

        protected void btnPagos_Click(object sender, EventArgs e)
        {
            Session["matricula"] = matricula;
            Response.Redirect("gFichaPago.aspx");
        }

        protected void btnOtrosPagos_Click(object sender, EventArgs e)
        {
            Session["matricula"] = matricula;
            Response.Redirect("gFichaPagosOtros.aspx");
        }

        protected void btnConsulta_Click(object sender, EventArgs e)
        {
            Session["matricula"] = matricula;
            Response.Redirect("consultaPagos.aspx");
        }
        protected void btnEVCD_Click(object sender, EventArgs e)
        {
            Session["carrera"] = alumno.idAlumno;
            this.Response.Redirect("../EVCD/acceso.aspx");
        }
    }
}