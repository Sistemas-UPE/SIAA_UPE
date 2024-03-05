using System;
using System.Web;
using System.Web.UI.WebControls;
using SIAA_UPE.CONTROL;
using SIAA_UPE.MODELO.entidades;

namespace SIAA_UPE.admin
{
    public partial class conceptosPagos : System.Web.UI.Page
    {
        ctrlTipoPago ctrlTP = new ctrlTipoPago();
        CT_SIA_TIPOPAGO tp = new CT_SIA_TIPOPAGO();
        int idPago = 0;
        string nombre = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenar();
                nombre = Session["UserName"] as string;
                lbUserName.Text = nombre;
            }
        }
        private void llenar()
        {
            gvPagos.DataSource = ctrlTP.select();
            gvPagos.DataBind();
            txtVigenciaFin.Visible = true;
            txtVigenciaIn.Visible = true;
        }
        protected void roud(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvPagos.Rows[index];
            idPago = int.Parse(row.Cells[0].Text);
            if (e.CommandName == "editar")
            {
                this.divEditar.Visible = true;
                lbFolio.Text = row.Cells[0].Text;
                string valorCodificado = row.Cells[1].Text;
                string valorDecodificado = HttpUtility.HtmlDecode(valorCodificado);
                lbConcepto.Text = valorDecodificado;
                txtCosto.Text = row.Cells[2].Text;
                if(row.Cells[1].Text.Equals("Medios electronicos (Transferencia,Pago en linea, Practi-caja)                                                          ") || row.Cells[1].Text.Equals("Pago en ventanilla bancaria                                                                                             "))
                {
                    txtVigenciaFin.Visible = false;
                    txtVigenciaIn.Visible = false;
                }
            }
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string currentPage = this.Page.Request.AppRelativeCurrentExecutionFilePath;
            tp = ctrlTP.selectByID(int.Parse(lbFolio.Text));
            tp.costo = decimal.Parse(txtCosto.Text);
            tp.vigenciaInicio = txtVigenciaIn.Text;
            tp.vigenciaFinal = txtVigenciaFin.Text;
            tp.recargos = cbRecargo.Checked.ToString();
            ctrlTP.Update(tp);
            this.divEditar.Visible = false;

            Response.Redirect(currentPage);

        }
    }
}