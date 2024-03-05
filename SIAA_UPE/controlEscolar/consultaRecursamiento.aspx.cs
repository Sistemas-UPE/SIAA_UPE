using SIAA_UPE.CONTROL;
using SIAA_UPE.MODELO.entidades;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace SIAA_UPE.controlEscolar
{
    public partial class consultaRecursamiento : System.Web.UI.Page
    {
        ctrlAlumno ctrlAl = new ctrlAlumno();
        List<RG_SIA_RECURSAMIENTOS> pr = new List<RG_SIA_RECURSAMIENTOS>();
        ctrlAdeudos ctrlAd = new ctrlAdeudos();
        static string nombre, msg, color;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                nombre = Session["UserName"] as string;
                lbUserName.Text = nombre;
                pr = ctrlAl.listRecursamiento();
                this.gv.DataSource = pr;
                this.gv.DataBind();
            }
        }
        protected void roud(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gv.Rows[index];
            int id = int.Parse(row.Cells[0].Text);
            if(row.Cells[4].Text.Equals("PENDIENTE"))
            {
                msg = "No puede validar el adeudo si el alumno aun no a cubierto la cuota.";
                color = "rgba(255, 165, 0, 0.7)";
            }
            else
            {
                if (ctrlAd.delete(id))
                {
                    msg = "Se ha eliminado el adeudo al estudiante.";
                    color = "rgba(0, 128, 0, 0.7)";
                }
                else
                {
                    msg = "Ocurrió un error, Favor de Intentar más tarde.";
                    color = "rgba(166, 32, 67, 0.7)";
                }
            }
            toast(color, msg);
        }
        private void toast(string _color, string _msg)
        {
            lbToast.Text = _msg;
            this.divToast.Style.Add("background-color", _color);
            this.divToast.Visible = true;
        }

    }
}