using SIAA_UPE.CONTROL;
using SIAA_UPE.MODELO.entidades;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace SIAA_UPE.nIngreso
{
    public partial class consultaAspirantes : System.Web.UI.Page
    {
        List<nuevoIngreso> ni = new List<nuevoIngreso>();
        int ie = 0, ilt = 0, ip = 0, isie = 0, ieP = 0, iltP = 0, ipP = 0, isieP = 0;
        ctrlAspirante ctrl= new ctrlAspirante();

        string nombre = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            nombre = Session["UserName"] as string;
            lbUserName.Text = nombre;
            if (!IsPostBack)
                llenar();
        }
        private void llenar()
        {
            ni = ctrl.nuevoIng();
            if (ni.Count != 0)
            {
                
                gvPagos.DataSource = ni;
                gvPagos.DataBind();
                lbAspTotal.Text = ": "+ni.Count;
                lbAspPagado.Text = ": " + pagados(ni);
                lbIE.Text = ": "+ ieP+" / " + ie;
                lbIP.Text = ": " + ipP + " / " + ip;
                lbILT.Text = ": "+ iltP + " / " + ilt;
                lbISIE.Text = ": " + isieP + " / " + isie;
            }
            else
            {
                lbAlerta.Text = "Aun no has generado ninguna referencia. =)";
                lbAlerta.Visible = true;
            }
        }

        protected void roud(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvPagos.Rows[index];
            string id = row.Cells[3].Text;
            switch (e.CommandName)
            {
                case "detalles":
                    lbAlerta.Text = "FOLIO: "+row.Cells[5].Text;
                    dvAspirante.DataSource = ctrl.detalle(id);
                    dvAspirante.DataBind();
                    gvPagos.Visible = false;
                    btnTodos.Visible = true;
                    dvAspirante.Visible = true;
                    lbAlerta.Visible = true;
                    break;
                case "aceptado":
                    ctrl.aAceptado(int.Parse(row.Cells[5].Text.Substring(2)));
                    this.Page.Response.Write("<script language='JavaScript'>window.alert('Se actualizo corectamente ');</script>");
                    Response.Redirect("http://upenergia.edu.mx/SIAUPE/nIngreso/consultaAspirantes.aspx");
                    break;
            }
        }

        protected void btnTodos_Click(object sender, EventArgs e)
        {
            gvPagos.Visible = true;
            dvAspirante.Visible = false;
            btnTodos.Visible = false;
            lbAlerta.Visible = false;
        }
        int pagados(List<nuevoIngreso>  _ni)
        {
            int contar = 0;
            int itm = 0;
            foreach (var item in _ni)
            {
                switch (item.ClvCarrera)
                {
                    case "IE   ":
                        ie++;
                            break;
                    case "IP   ":
                        ip++;
                        break;
                    case "ISIE ":
                        isie++;
                        break;
                    case "ILT  ":
                        ilt++;
                        break;
                }
                if (item.PagoFicha.Equals("[FICHA VALIDADA]"))
                {
                    switch (item.ClvCarrera)
                    {
                        case "IE   ":
                            ieP++;
                            break;
                        case "IP   ":
                            ipP++;
                            break;
                        case "ISIE ":
                            isieP++;
                            break;
                        case "ILT  ":
                            iltP++;
                            break;

                    }
                    switch(item.Estatus)
                    {
                        case 1:
                            gvPagos.Rows[itm].BackColor = System.Drawing.Color.Gold;
                            break;
                        case 2:
                            gvPagos.Rows[itm].BackColor = System.Drawing.Color.BurlyWood;
                            break;
                        case 3:
                            gvPagos.Rows[itm].BackColor = System.Drawing.Color.SeaGreen;
                            break;
                        case 4:
                            gvPagos.Rows[itm].BackColor = System.Drawing.Color.MediumAquamarine;
                            break;
                        default:
                            gvPagos.Rows[itm].BackColor = System.Drawing.Color.Firebrick;
                            break;

                    }
                    contar++;
                }
                itm++;
            }

            return contar;
        }
    }
}