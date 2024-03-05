using System;
using SIAA_UPE.CONTROL;
using SIAA_UPE.MODELO.entidades;

namespace SIAA_UPE.pagosR
{
    public partial class propedeuticoFP : System.Web.UI.Page
    {

        codificar code = new codificar();
        ctrlTipoPago ctrlTP = new ctrlTipoPago();
        ctrlCarrera ctrlC = new ctrlCarrera();
        ctrlAspirante ctrlA = new ctrlAspirante();
        ctrlReferencia ctrlR = new ctrlReferencia();
        ctrlPersona ctrlP = new ctrlPersona();

        CT_SIA_TIPOPAGO tipo = new CT_SIA_TIPOPAGO();
        DP_SIA_ASPIRANTES aspirante = new DP_SIA_ASPIRANTES();
        //DTL_SIA_ASPIRANTE_GREFERENCIA ar = new DTL_SIA_ASPIRANTE_GREFERENCIA();
        RG_SIA_GREFERENCIA referencia = new RG_SIA_GREFERENCIA();
 
       
        string msj = "";
        static int pago = 4;

        bool r;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.idImprimeme.Visible = false;
            r = code.recargo(12, 8);
            aspirante = ctrlP.aceptado(txtCURP.Text);

            //r = false;
        }
        protected void btnValidar_Click(object sender, EventArgs e)
        {

            if (code.CurpValida(txtCURP.Text))
            {
                lbNombre.Text = txtNombre.Text;
                if (aspirante != null)
                {
                    this.divStep1.Visible = false;
                    this.divStep2.Visible = true;
                }
                else
                {
                    lbEnca.Text = "Error";
                    lbError.Text = "Tenemos un problema con tu registro por favor comunícate el área de servicios escolares";
                }
            }
            else
            {
                lbError.Text = "El CURP es incorecto";
            }

        }
        protected void btn_Click(object sender, EventArgs e)
        {
            string n = aspirante.DP_SIA_PERSONA.nombre;
            string[] fecha = code.fecha();
            int b = ddMpago.SelectedIndex;
            if ( b != 0)
            {
                lbError.Text = "";
                try
                {
                    if (r)
                    {
                        lbImporte.Text = "$ " + monto() + "\n (RECARGO POR PAGO)";
                    }
                    else
                    {
                        lbImporte.Text = "$ " + monto();
                    }
                    lbImporte.Text = "$ " + monto();
                    lbFecha.Text = fecha[0] + " / " + fecha[1] + " / " + fecha[2];
                    lbConcepto.Text = "Inscripción a Curso Propedéutico";
                    lbNomb.Text = txtNombre.Text;
                    lbReferencia.Text = code.llamar(agrupar(), fecha, monto().Replace(".", ""));
                    lbMsj.Text = msj;
                    LbFolioImp.Text = "A-"+aspirante.idAspirante;
                    this.idImprimeme.Visible = true;

                    insertar();
                }
                catch (Exception ex)
                {
                    string x = ex.Message;
                    lbError.Text = "Revise su información";
                }
            }
            else
            {
                lbError.Text = "Por favor, selecciona la carrera que sea de tu interés, así como la forma de pago que más te acomode.";
            }
        }
        protected void btnX_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/pagosR/propedeuticoFP.aspx");
        }
        private void insertar()
        {
            referencia.referencia = long.Parse(lbReferencia.Text);
            referencia.idTipoPago = pago;
            referencia.fecha = code.hoy();
            iReferencia(referencia);

            //ar.idAspirante = aspirante.idAspirante;
            //ar.idGREFERENCIA = ctrlR.UltimoRefe();
            //ctrlA.insertAR(ar);
        }
        private void iReferencia(RG_SIA_GREFERENCIA r)
        {
            ctrlR.insert(r);
        }
     
        private string agrupar()
        {
            string carr, folio;
            carr = idCarrera(aspirante.idPE);
            folio = aspirante.idAspirante.ToString();

            return pago + carr + folio;
        }
        private string idCarrera(string _ID)
        {
            switch (_ID)
            {
                case "IE   ":
                    return "01";
                case "ILT  ":
                    return "02";
                case "IP   ":
                    return "03";
                case "ISIE ":
                    return "04";

                case "MGP  ":
                    return "05";
                default:
                    return "00";
            }
        }
        private string monto()
        {
            CT_SIA_TIPOPAGO tpago = new CT_SIA_TIPOPAGO();

            double costo = 0.0;

            tpago = ctrlTP.selectByID(pago);
            costo = double.Parse(tpago.costo.ToString());
            if (r)
            {
                costo = costo + 119.31;
            }
            if (ddMpago.SelectedItem.ToString().Equals("Medios electronicos (Transferencia,Pago en linea, Practi-caja)"))
            {
                costo = costo + 7.99;
                msj = " (Comisión bancaria de $ 7.99 pesos.)";
            }
            else if (ddMpago.SelectedItem.ToString().Equals("Pago en ventanilla bancaria"))
            {
                costo = costo + 22.36;
                msj = " (Comisión bancaria de $ 22.36 pesos.)";
            }

            string cCosto = costo.ToString();
            if (costo % 1 == 0)
                return cCosto + ".00";
            else
            {
                int id = cCosto.IndexOf(".");
                string desi = cCosto.Substring(id + 1);
                if (desi.Length != 1)
                    return cCosto;
                else
                    return cCosto + "0";
            }


        }
        
    }
}