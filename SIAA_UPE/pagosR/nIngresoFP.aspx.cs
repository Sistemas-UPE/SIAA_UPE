using System;
using System.IO;
using System.Web;
using System.Linq;
using SIAA_UPE.CONTROL;
using SIAA_UPE.MODELO.entidades;


namespace SIAA_UPE.pagosR
{
    public partial class fichaPago : System.Web.UI.Page
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
        DP_SIA_PERSONA persona = new DP_SIA_PERSONA();

        string msj = "";
        static int folio, idPersona;
        bool r;
        protected void Page_Load(object sender, EventArgs e)
        {
            folio = ctrlA.ultimoAspirante();
            if (!IsPostBack)
            {
                llenar();
            }
            this.idImprimeme.Visible = false;
            r= code.recargo(1, 1);
            //r = false;
        }
        protected void btn_Click(object sender, EventArgs e)
        {
            string[] fecha = code.fecha();
            int a = ddCarrera.SelectedIndex;
            int b = ddMpago.SelectedIndex;
            if (a!=0 && b!=0)
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
                    lbConcepto.Text = txtPago.Text;
                    lbNombre.Text = txtNombre.Text;
                    lbReferencia.Text = code.llamar(agrupar(), fecha, monto().Replace(".", ""));
                    lbMsj.Text = msj;
                    LbFolioImp.Text = lbFolio.Text;
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
            Response.Redirect("~/pagosR/nIngresoFP.aspx");
        }
        private void insertar()
        {
            referencia.referencia = long.Parse(lbReferencia.Text);
            referencia.idTipoPago = 6;
            referencia.fecha = code.hoy();
            iReferencia(referencia);

            persona.idDireccion = 1;
            persona.nombre = txtNombre.Text;
            persona.aPaterno = "";
            persona.aMaterno = "";
            persona.CURP = txtCURP.Text;
            ctrlP.insert(persona);
            
            idPersona = ctrlP.selectCURP(txtCURP.Text);

            aspirante.idPersona = idPersona;
            aspirante.idPE = ddCarrera.SelectedValue;
            aspirante.idModalidad = 1;
            ctrlA.insert(aspirante);

            //ar.idAspirante = folio + 1;
            //ar.idGREFERENCIA = ctrlR.UltimoRefe();
            //ctrlA.insertAR(ar);
        }
        private void iReferencia(RG_SIA_GREFERENCIA r)
        {
            ctrlR.insert(r);
        }
        private void llenar()
        {
            
            tipo = ctrlTP.selectByID(6);
            lbFolio.Text = "F - "+(folio+1).ToString("D4");
            txtPago.Text = "TP-00" + tipo.idTipoPago+" | " + tipo.detalle;
            ddCarrera.DataSource = ctrlC.selectSinMM();
            ddCarrera.DataBind();
            ddCarrera.Items.Insert(0, "Seleccione la carrera que sea de tu interés");
        }
        private string agrupar()
        {
            string carr, folio;
            if (ddCarrera.SelectedValue.Count() != 2)
            {
                carr = idCarrera(ddCarrera.SelectedValue.ToString());
            }
            else
            {
                carr = ddCarrera.SelectedValue;
            }

            folio= lbFolio.Text.Substring(4);

            return 6 + carr + folio;
        }
        private string idCarrera( string _ID)
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
            
            tpago = ctrlTP.selectByID(6);
            costo = double.Parse(tpago.costo.ToString());
            if(r)
            {
                costo = costo + 119.31;
            }
                if (ddMpago.SelectedItem.ToString().Equals("Medios electronicos (Transferencia,Pago en linea, Practi-caja)"))
            {
                costo = costo + 7.99;
                msj = " (Comisión bancaria de $ 7.99 pesos.)";
            }
            else if(ddMpago.SelectedItem.ToString().Equals("Pago en ventanilla bancaria"))
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
                string desi = cCosto.Substring(id+1);
                if(desi.Length!=1)
                    return cCosto;
                else
                    return cCosto + "0";
            }
                

        }
        protected void btnValidar_Click(object sender, EventArgs e)
        {

            if (code.CurpValida(txtCURP.Text))
            {
                idPersona = ctrlP.selectCURP(txtCURP.Text);
                if (idPersona!=0)
                {
                    txtCURP.Enabled = false;
                    int idR = 0;
                    lbEnca.Text = " | Consulta tu ficha";
                    txtCURP.Text ="F - " + idR.ToString("D4");
                    lbFolio.Text = txtCURP.Text;

                    btnValidar.Visible = false;
                    btnReImp.Visible = true;
                }
                else
                {
                    lbEnca.Text = " | Genera tu ficha";
                    lbError.Text = "";

                    this.divStep1.Visible = false;
                    this.divFolio.Visible = true;
                    this.divStep2.Visible = true;
                }
            }
            else
            {
                lbError.Text = "El CURP es incorecto";
            }

        }
        protected void btnReImp_Click(object sender, EventArgs e)
        {
            //int fol = int.Parse(txtCURP.Text.Substring(4));
            ////ar = ctrlA.aspirantebyID(fol);
            ////DTL_SIA_ASPIRANTE_GREFERENCIA arL = new DTL_SIA_ASPIRANTE_GREFERENCIA();

            ////string idCarr = idCarrera(ar.DP_SIA_ASPIRANTES.idPE);
            ////String[] ele = System.Text.RegularExpressions.Regex.Split(ar.RG_SIA_GREFERENCIA.fecha, "/");
            ////string[] fecha = code.fechaEspes(int.Parse(ele[0]), int.Parse(ele[1]), int.Parse(ele[2]));
            //lbImporte.Text = "$ " + monto();
            ////lbFecha.Text = fecha[0] + " / " + fecha[1] + " / " + fecha[2];
            ////lbConcepto.Text = "TP-006 | " + ar.RG_SIA_GREFERENCIA.CT_SIA_TIPOPAGO.detalle;
            //lbNombre.Text = txtNombre.Text;
            ////string r = code.llamar(6 + idCarr + fol, fecha, monto().Replace(".", ""));
            //lbReferencia.Text = r;
            //lbMsj.Text = msj;
            //LbFolioImp.Text = lbFolio.Text;
            ////int a = ctrlR.selectByReferencia(long.Parse(r));

            //if(a==0)
            //{
            //    referencia.referencia = long.Parse(lbReferencia.Text);
            //    referencia.idTipoPago = 6;
            //    referencia.fecha = code.hoy();
            //    iReferencia(referencia);
            //    //arL.idAspirante = fol;
            //    //arL.idGREFERENCIA = ctrlR.UltimoRefe();
            //    //ctrlA.insertAR(arL);
            //}

            //this.idImprimeme.Visible = true;
        }
    }

}