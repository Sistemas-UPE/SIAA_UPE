using SIAA_UPE.CONTROL;
using SIAA_UPE.MODELO.entidades;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
namespace SIAA_UPE.nIngreso
{
    public partial class convocatoria : System.Web.UI.Page
    {
        string nombre = "";
        ctrlConvocatoria ctrl = new ctrlConvocatoria();
        CT_SIA_CONVOCATORIA conv = new CT_SIA_CONVOCATORIA();
        static private int id = 0;
      
        protected void Page_Load(object sender, EventArgs e)
        {
            nombre = Session["nombre"] as string;
            //lbNombre.Text = nombre;
            if (!IsPostBack)
                llenar();
        }
        private void llenar()
        {
            gvConbocatorias.DataSource = ctrl.selectAll();
            gvConbocatorias.DataBind();       
        }
        protected void roud(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvConbocatorias.Rows[index];
            id = int.Parse(row.Cells[0].Text);
            switch (e.CommandName)
            {
                case "actualizar":
                    conv = ctrl.covocatoriaById(id);
                    txtDiaFi.Text = conv.diaFin.ToString();
                    txtMesFi.Text = conv.mesFin.ToString();
                    txtDiaIn.Text = conv.diaInicio.ToString();
                    txtMesIn.Text = conv.mesInicio.ToString();
                    btnUpdate.Text = "Actualizar";

                    break;
                case "eliminar":
                    
                    Boolean estado = ctrl.delete(id); ;

                    if (estado)
                        this.Page.Response.Write("<script language='JavaScript'>window.alert('Se borro Corectamente ');</script>");
                    else
                        this.Page.Response.Write("<script language='JavaScript'>window.alert('Ocurrio un error porfabor intente mas tarde');</script>");

                    break;

            }
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            conv.diaInicio = int.Parse(txtDiaIn.Text);
            conv.diaFin = int.Parse(txtDiaFi.Text);
            conv.mesInicio = int.Parse(txtMesIn.Text);
            conv.mesFin = int.Parse(txtMesFi.Text);

            if (btnUpdate.Text.Equals("Actualizar"))
            {
                conv.idConvocatoria =id;
                ctrl.upDate(conv);
            }
            else
            {
                conv.ciclo = DateTime.Now.Year;
                conv.ronda = ctrl.ultimo();
                ctrl.insert(conv);
            }

            Response.Redirect("http://upenergia.edu.mx/SIAUPE/nIngreso/convocatoria.aspx");
        }
    }
}