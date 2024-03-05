using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SIAA_UPE.CONTROL;
using SIAA_UPE.MODELO.entidades;

namespace SIAA_UPE.pagosR
{
    public partial class fichaPagoOtros : System.Web.UI.Page
    {

        ctrlTipoPago ctrlTP = new ctrlTipoPago();
        ctrlCarrera ctrlC = new ctrlCarrera();
        ctrlGrupo ctrlG = new ctrlGrupo();
        codificar code = new codificar();
        string msj = "";
        bool r;

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect("~/login.aspx");
            if (!IsPostBack)
            {
                llenar();
                r= code.recargo(5, 9);
            }
            this.idImprimeme.Visible = false;
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            string[] fecha = code.fecha();
            try
            {
                if(txt.Text.Equals(""))
                {
                    lbError.Text = "Por favor coloque su matrícula o su folio";
                }
                else
                {

                    if (r)
                    {
                        lbImporte.Text = "$ " + monto() + "\n (RECARGO POR PAGO EXTEMPORANEO)";
                    }
                    else
                    {
                        lbImporte.Text = "$ " + monto();
                    }
                    lbFecha.Text = fecha[0] + " / " + fecha[1] + " / " + fecha[2];
                    lbConcepto.Text = ddTPago.SelectedItem.ToString();
                    lbNombre.Text = txtNombre.Text;
                    lbReferencia.Text = code.llamar(agrupar(), fecha, monto().Replace(".", ""));
                    lbMsj.Text = msj;
                    this.idImprimeme.Visible = true;
                }

            }
            catch(Exception ex)
            {
                string a = ex.Message;
                lbError.Text = "Revise su información";
            }
        }
        protected void btnX_Click(object sender, EventArgs e)
        {
            this.idImprimeme.Visible = false;
        }

        private void llenar()
        {
            ddTPago.DataSource = ctrlTP.selectByGrupo(2);
            ddTPago.DataBind();
            ddCarrera.DataSource = ctrlC.select(0);
            ddCarrera.DataBind();
            ddTPago.Items.Insert(0, "Seleccione el tipo de pago");
            ddCarrera.Items.Insert(0, "Seleccione la carrera");
        }
        private string agrupar()
        {
            string carr, pago, matr = "";
            if (ddTPago.SelectedValue.Count() != 2)
            {
                pago = 0 + ddTPago.SelectedValue;
            }
            else
            {
                pago = ddTPago.SelectedValue;
            }
            if (ddCarrera.SelectedValue.Count() != 2)
            {
                switch(ddCarrera.SelectedValue.ToString())
                {
                    case "IE   ":
                    carr = "01";
                        break;
                    case "ILT  ":
                    carr = "02";
                        break;
                    case "IP   ":
                    carr = "03";
                        break;
                    case "ISIE ":
                    carr = "04";
                        break;
                    case "MGP  ":
                    carr = "05";
                        break;
                    default:
                        carr = "00";
                        break;
                }
            }
            else
            {
                carr = ddCarrera.SelectedValue;
            }

            matr = code.matricula(txt.Text);

            return pago + carr + matr;
        }
        private string monto()
        {
            CT_SIA_TIPOPAGO tpago = new CT_SIA_TIPOPAGO();
            double costo = 0.0;
            string mas = txtMas.Text;
            tpago = ctrlTP.selectByID(int.Parse(ddTPago.SelectedValue));
            costo = double.Parse(tpago.costo.ToString());
            if(!mas.Equals(""))
            {
                
                if (r || ddTPago.SelectedItem.ToString().Equals("RECURSAMIENTO                                                                                                           "))
                {
                    costo = costo + 111.13;
                }
                costo = costo * int.Parse(mas);
            }
            if(ddMpago.SelectedItem.ToString().Equals("Medios electronicos (Transferencia,Pago en linea, Practi-caja)"))
            {
                costo = costo + 7.99;
                msj = " (Comisión bancaria de $ 7.99 pesos.)";
            }
            else if(ddMpago.SelectedItem.ToString().Equals("Pago en ventanilla bancaria"))
            {
                costo = costo + 22.36;
                msj = " (Comisión bancaria de $ 22.36 pesos.)";
            }
            
            if(costo%1==0)
                return costo.ToString()+".00";
            else
                return costo.ToString();

        }

        protected void ddTPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.divMas.Visible = true;
        }
    }

}