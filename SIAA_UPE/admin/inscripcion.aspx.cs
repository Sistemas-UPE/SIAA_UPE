using System;
using System.Text.RegularExpressions;
using SIAA_UPE.CONTROL;
using SIAA_UPE.MODELO.entidades;

namespace SIAA_UPE.admin
{
    public partial class inscripcion : System.Web.UI.Page
    {
        codificar code = new codificar();
        ctrlTipoPago ctrlTP = new ctrlTipoPago();
        ctrlCarrera ctrlC = new ctrlCarrera();
        ctrlReferencia ctrlR = new ctrlReferencia();
        ctrlPersona ctrlP = new ctrlPersona();
        ctrlAlumno ctrlAl = new ctrlAlumno();

        CT_SIA_TIPOPAGO tipo = new CT_SIA_TIPOPAGO();
        DP_SIA_ASPIRANTES aspirante = new DP_SIA_ASPIRANTES();
        RG_SIA_GREFERENCIA referencia = new RG_SIA_GREFERENCIA();
        DP_SIA_PERSONA persona, tutor = new DP_SIA_PERSONA();
        FD_SIA_ALUMNO alumno = new FD_SIA_ALUMNO();
        DP_SIA_DOMICILIO dirTutor = new DP_SIA_DOMICILIO();
        DP_SIA_DOMICILIO direc = new DP_SIA_DOMICILIO();
        DP_SIA_TUTOR t = new DP_SIA_TUTOR();
        //DTL_SIA_ALUMNO_REFERENCIA alr = new DTL_SIA_ALUMNO_REFERENCIA();

        string msj = "";
        static int pago = 1;

        bool r;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenar();
            }
            aspirante = ctrlP.aceptado(txtCURP.Text);

            this.idImprimeme.Visible = false;
            r = code.recargo(11, 9);

        }
        protected void btnValidar_Click(object sender, EventArgs e)
        {
            
                int idPer = aspirante.DP_SIA_PERSONA.idPersona;
                alumno = ctrlAl.selecAlumno(idPer);
                try
                {
                    //alr = ctrlAl.selecAlumnoXReferencia(alumno.idAlumno);
                }
                catch (Exception ex)
                {
                //alr = null;
                string x = ex.Message;
                }
                if (code.CurpValida(txtCURP.Text))
                {
                    if (aspirante != null)
                    {
                        //if (alr != null)
                        //{
                        //    LlenarFicha();
                        //}
                        //else
                        //{
                        //    this.divStep1.Visible = false;
                        //    this.divStep2.Visible = true;
                        //    txtName.Text = aspirante.DP_SIA_PERSONA.nombre;
                        //    txtMATRICULA.Text = "POR ASIGNAR";
                        //    txtFDI.Text = DateTime.Today.ToString();
                        //}
                    }
                    else
                    {
                        lbError.Text = "Tenemos un problema con tu registro por favor comunícate el área de servicios escolares";
                    }

                }
                else
                {
                    lbError.Text = "El CURP es incorecto";
                }
        }
        private void LlenarFicha()
        {
            //alr = ctrlAl.selecAlumnoXReferencia(alumno.idAlumno);
            if (false)
            {

            }
            else
            {
                string n = aspirante.DP_SIA_PERSONA.nombre;
                string[] fecha = code.fecha();
                int b = ddMpago.SelectedIndex;
                if (b != 0)
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
                        lbFecha.Text = fecha[0]  + " / " + fecha[1] + " / " + fecha[2];
                        lbConcepto.Text = "Inscripción Nivel Licenciatura";
                        lbNomb.Text = txtNombre.Text;
                        lbReferencia.Text = code.llamar(agrupar(), fecha, monto().Replace(".", ""));
                        lbMsj.Text = msj;
                        LbFolioImp.Text = txtMATRICULA.Text;
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
                    lbError.Text = "Por favor, selecciona la forma de pago que más te acomode.";
                }
            }
        }
        protected void btnX_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/admin/inscripcion.aspx");
        }
        private void insertar()
        {
            //DTL_SIA_ALUMNO_REFERENCIA alrOF = new DTL_SIA_ALUMNO_REFERENCIA();

            string mts = Regex.Replace((aspirante.idPE + 11 + aspirante.idAspirante), @"\s", "");

            referencia.referencia = long.Parse(lbReferencia.Text);
            referencia.idTipoPago = pago;
            referencia.fecha = code.hoy();
            iReferencia(referencia);

            //alrOF.idAlumno = mts;
            //alrOF.idGREFERENCIA = ctrlR.UltimoRefe();
            //ctrlAl.insertDTL(alrOF);
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
        private void llenar()
        {
            ddCarrera.DataSource = ctrlC.selectSinMM();
            ddCarrera.DataBind();
            ddCarrera.Items.Insert(0, "Seleccione la carrera que sea de tu interés");
            ddEstado.DataSource = ctrlP.estados();
            ddEstado.DataBind();
            ddEstado.Items.Insert(0, "Seleccione tu estado");
            ddEstadoT.DataSource = ctrlP.estados();
            ddEstadoT.DataBind();
            ddEstadoT.Items.Insert(0, "Seleccione tu estado");
        }


        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            persona = aspirante.DP_SIA_PERSONA;

            persona.cElectronico = txtCE.Text;
            persona.fNacimiento = DateTime.Parse(txtCalendario.Text);
            persona.sexo = rbSexo.SelectedItem.Value;
            persona.discapacidad = rbDisca.SelectedItem.Value;
            persona.nTelefonicoCel = txtNTP.Text;
            direc.calle = txtCALLE.Text;
            direc.colonia = txtCOLONIA.Text;
            direc.municipio = txtMUNICIPIO.Text;
            direc.Localidad = txtLC.Text;
            direc.cp = int.Parse(txtCP.Text);
            direc.nExterno = txtNUMEROEX.Text;
            direc.nInterno = txtNUMEROIN.Text;
            direc.idEstado = int.Parse(ddEstado.SelectedValue);
            if (persona.idDireccion == 1)
            {
                ctrlP.insertDireccion(direc);
                persona.idDireccion = ctrlP.Ultimodir();
            }

            ctrlP.updatePersona(persona);
            string mtri = Regex.Replace((aspirante.idPE + 11 + aspirante.idAspirante), @"\s", "");
            string grupo = Regex.Replace((aspirante.idPE + "01" + "A"), @"\s", "");

            alumno.idAlumno = mtri;
            alumno.idPersona = persona.idPersona;
            alumno.idGrupo = grupo;
            alumno.generacion = 11;
            alumno.fIngreso = DateTime.Parse(txtFDI.Text);
            alumno.idSituacionActual = "1";
            alumno.password = "-";
            alumno.pInd = rbIndigena.SelectedItem.Value;
            alumno.generacion = 11;

            tutor.nombre = txtNCT.Text;
            tutor.aPaterno = txtAPP.Text;
            tutor.aMaterno = txtAPM.Text;
            tutor.cElectronico = txtCORREOT.Text;
            tutor.fNacimiento = DateTime.Parse(txtFechaNaT.Text);
            tutor.sexo = rbsexot.SelectedItem.Value;
            tutor.discapacidad = rdDisT.SelectedItem.Value;
            tutor.nTelefonicoCel = txtNTPT.Text;
            dirTutor.calle = txtCALLET.Text;
            dirTutor.colonia = txtCOLONIAT.Text;
            dirTutor.municipio = txtMUNIT.Text;
            dirTutor.Localidad = txtLOCT.Text;
            dirTutor.idEstado = int.Parse(ddEstadoT.SelectedValue);
            dirTutor.cp = int.Parse(txtCPT.Text);
            dirTutor.nExterno = txtNUMEXT.Text;
            dirTutor.nInterno = txtNUMINT.Text;
            t.idPersona = ctrlP.Ultimo();
            if (alumno.idTutor == null)
            {
                ctrlP.insertDireccion(dirTutor);
                tutor.idDireccion = ctrlP.Ultimodir();
                ctrlP.insert(tutor);
                alumno.idTutor = ctrlP.inserttutor(t);
                alumno.intEVCD = 3;
                alumno.idModalidad = 1;
                alumno.nSeguro = txtPROMEDIO.Text;
                ctrlAl.insertAlumno(alumno);
            }
            LlenarFicha();
        }
    }
}