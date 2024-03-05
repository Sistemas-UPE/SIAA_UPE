using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using SIAA_UPE.CONTROL;
using SIAA_UPE.MODELO.entidades;

namespace SIAA_UPE.nIngreso
{
    public partial class aspirantes : System.Web.UI.Page
    {
        codificar code = new codificar();
        ctrlTipoPago ctrlTP = new ctrlTipoPago();
        ctrlCarrera ctrlC = new ctrlCarrera();
        ctrlAspirante ctrlA = new ctrlAspirante();
        ctrlAlumno ctrlAl = new ctrlAlumno();
        ctrlReferencia ctrlR = new ctrlReferencia();
        ctrlPersona ctrlP = new ctrlPersona();
        ctrlTutor ctrlT = new ctrlTutor();
        ctrlConvocatoria ctrlCon = new ctrlConvocatoria();

        DP_SIA_PERSONA tutor = new DP_SIA_PERSONA();
        DP_SIA_PERSONA persona = new DP_SIA_PERSONA();
        DP_SIA_ASPIRANTES aspirante = new DP_SIA_ASPIRANTES();
        DP_SIA_TUTOR t = new DP_SIA_TUTOR();
        DP_SIA_DOMICILIO direc = new DP_SIA_DOMICILIO();
        RG_SIA_GREFERENCIA referencia = new RG_SIA_GREFERENCIA();
        CE_SIA_PROCEDENCIA procedencia = new CE_SIA_PROCEDENCIA();
        private static List<CT_SIA_TIPOPAGO> lisTipo = new List<CT_SIA_TIPOPAGO>();
        CT_SIA_CONVOCATORIA convocatoria = new CT_SIA_CONVOCATORIA();

        private static double comicion, ficha,propedeutico, cuota, inscripcion;
        private static string[] fecha;
        private static string docName,cr,tp;
        private static string host = "ftp://upenergia.edu.mx/SIAUPE/nIngreso/documentos/";
        private static string user = "web.upenergia.edu.mx";
        private static string pass = "Sis73+2021";
        
        private static int c = 0;
        private static int folioN = 0;
        private static string folioT = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                inicio();
            }
        }
        protected void btnValidad_Click(object sender, EventArgs e)

        {
            cuota = ficha;
            string curp = txtCurp.Text;
            if (code.CurpValida(curp))
            {
                this.step1.Visible = false;

                aspirante = ctrlA.sech(curp);
                lbConcepto.Text = lisTipo[5].detalle;
                if (aspirante == null)
                {
                    DP_SIA_ASPIRANTES aspirante = new DP_SIA_ASPIRANTES();
                    llenarDD();
                    folioN = ctrlA.ultimoAspirante() + 1;
                    folioT = folioN.ToString("D4");
                    lbNF.Text = "NUEVA FICHA: F-" + folioT;
                    aspirante.idAspirante = folioN;
                    aspirante.idConvocatoria = c;
                    aspirante.curp = curp;
                    ctrlA.insert(aspirante);
                    this.step2.Visible = true;
                }
                else
                {
                    folioN = aspirante.idAspirante;
                    folioT = folioN.ToString("D4");
                    if (aspirante.idProcedencia != null)
                    {
                        string cm = "";
                        string name = aspirante.DP_SIA_PERSONA.nombre + " " + aspirante.DP_SIA_PERSONA.aPaterno + " " + aspirante.DP_SIA_PERSONA.aMaterno;
                        this.step4.Visible = true;
                        lbCF.Text = folioT;
                        referencia = ctrlR.selectByAspirante("F-" + folioT);
                        lbNombreAspirante.Text = name;
                        cm = "(Ya con comisión bancaria.)"; 
                        lbReferenciaAspirante.Text = referencia.referencia.ToString();
                        lbImporteAspirante.Text = "$ " + referencia.monto + " " + cm;
                        string estado = ctrlR.ConsutarPAceptado(folioN);
                        switch (estado)
                        {
                            case "[FICHA VALIDADA]":
                                lbLeyerCP.Text = "Concepto de pago:";
                                lbConceptoV.Text = "FICHA DE INGRESO";
                                if (ctrlR.ConsutarPAspirante(referencia.idGREFERENCIA).Equals("[FICHA PENDIENTE]"))
                                {
                                    lbEstado.Text = "[FICHA PENDIENTE]";
                                }
                                else
                                {
                                    lbEstado.Text = estado;
                                }
                                break;
                            case "[HAS SIDO ACEPTADO]":
                                lbLeyerCP.Text = "Concepto:";
                                lbConceptoV.Text = "Resultados del Examen de Ingreso.";
                                lbConcepto.Text = lisTipo[3].detalle;
                                cuota = propedeutico;
                                cr = "0" + aspirante.CT_SIA_PROEDU.idAutoriza;
                                tp = "04";
                                divPropedeutico.Visible = true;
                                lbEstado.Text = estado;
                                break;
                            case "[PROPEDEUTICO VALIDADA]":
                                lbLeyerCP.Text = "Concepto:";
                                lbConceptoV.Text = "Resultados del Examen de Ingreso.";
                                lbConcepto.Text = lisTipo[3].detalle;
                                cuota = propedeutico;
                                cr = "0" + aspirante.CT_SIA_PROEDU.idAutoriza;
                                tp = "04";
                                lbEstado.Text = estado;
                                break;
                            case "[INSCRIPCION VALIDADA]":
                                lbEstado.Text = estado;
                                break;
                            default:
                                lbEstado.Text = estado;
                                break;
                        }
                    }
                    else
                    {
                        this.step2.Visible = true;
                        lbNF.Text = "NUEVA FICHA: F-" + folioT;
                        llenarDD();
                    }

                }
            }
            else
            {
                lbError.Text = "CURP INCORRECTO";
            }
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            docName = "F-" + folioT + Path.GetExtension(fuDatos.FileName);
            if (validarFormulario().Equals(""))
            {
                if (Path.GetExtension(fuDatos.FileName).Equals(".zip") || Path.GetExtension(fuDatos.FileName).Equals(".rar"))
                {
                    if (fuDatos.PostedFile.ContentLength < 5357703)
                    {
                        if (cargarDocumentos(fuDatos.PostedFile.InputStream))
                        {
                            this.step3.Visible = true;
                        }
                        else lbErrorFormulario.Text = "EXISTE UN PROBLEMA AL CARGAR TU INFORMACIÓN, VUELVE A INTENTARLO MAS TARDE.";
                    }
                    else lbErrorFormulario.Text = "EL TAMAÑO DEL ARCHIVO SOBREPASA LOS 5 MB PERMITIDOS.";
                }
                else lbErrorFormulario.Text = "SOLAMENTE PUEDE CARGAR ARCHIVOS COMPRIMIDOS CON EXTENSIÓN .ZIP O .RAR";
            }
            else lbErrorFormulario.Text = "POR FAVOR, REVISE SI RESPONDIÓ LAS SIGUIENTES PREGUNTAS : | " + validarFormulario();
        }
        protected void btnPrope_Click(object sender, EventArgs e)
        {
            this.step3.Visible = true;
        }
        protected void btn_Click(object sender, EventArgs e)
        {
            divConfirmacion.Visible = false;
            lbmsjFicha.Text = "Tiene 05 dias habiles para realizar el pago de tu inscripción y poder concluir con tu proceso, conserva tu ficha de pago pago para futura aclaraciones.";
            try
            {
                lbCF.Text = "F-" + folioT;
                double total = cuota;

                total = total + comicion;
                lbImporte.Text = "$ " + total;
                tp = "06";
                lbReferencia.Text = code.llamar(agrupar(cr, tp, folioT), fecha, (total.ToString()).Replace(".", ""));
                lbNombre.Text = txtName.Text + " " + txtLName.Text + " " + txtSName.Text;

                if (divPropedeutico.Visible)
                    insertarReferencia("P-" + folioT);
                else
                    insertarDatos();
            }
            catch (Exception el)
            {
                string smg = el.Message;
                lbmsjFicha.Text = "Tu registro fue realizado, si requieres hacer algún otro movimiento, por favor vuelve a cargar tu navegador";
                lbConcepto.Text = "";
                lbImporte.Text = "";
            }
        }
        protected void btnX_Click(object sender, EventArgs e)
        {
            string currentPage = this.Page.Request.AppRelativeCurrentExecutionFilePath;
            Response.Redirect(currentPage);
            this.step3.Visible = false;
        }

        private void llenarDD()
        {
            ddCarrera.DataSource = ctrlC.selectSinMM();
            ddCarrera.DataBind();
            ddCarrera.Items.Insert(0, "SELECCIONE LA CARRERA QUE SEA DE TU INTERÉS");
            ddEstado.DataSource = ctrlP.estados();
            ddEstado.DataBind();
            ddEstado.Items.Insert(0, "SELECCIONE TU ESTADO");
            ddEstadoT.DataSource = ctrlP.estados();
            ddEstadoT.DataBind();
            ddEstadoT.Items.Insert(0, "SELECCIONE TU ESTADO");
            ddInstituto.DataSource = ctrlAl.instituciones();
            ddInstituto.DataBind();
            ddInstituto.Items.Insert(0, "SELECCIONE TU BACHILLERATO DEL CUAL EGRESAS");
            ddIndigena.DataSource = ctrlA.indigena();
            ddIndigena.DataBind();
            ddIndigena.Items.Insert(0, "A QUÉ COMUNIDAD INDÍGENA PERTENECES");
        }
        private void inicio()
        {
            if (openConv())
            {
                costos();
            }
            else
            {
                txtCurp.Enabled = false;
                btnValidad.Enabled = false;
                lbError.Visible = true;
                lbError.Text = "El proceso de convocatoria para la ronda " + convocatoria.ronda + " a cerrado, pero mantente atento a nuestras redes sociales y página oficial.";
            }
        }
        private void clear()
        {
            tutor = null;
            persona = null;
            aspirante = null;
            t = null;
            direc = null;
            referencia = null;
            procedencia = null;
            lisTipo = null;
            convocatoria = null;

            comicion = 0.0;
            ficha = 0.0;
            propedeutico = 0.0;
            cuota = 0.0;
            fecha = null;
            docName = "";
            cr = "";
            tp = "";
            lbEstado.Text = "";
            host = "";
            user = "";
            pass = "";
            this.divFicha.Visible = true;
        }
        private void costos()
        {
            lisTipo = ctrlTP.select();
            fecha = fechaString(lisTipo[5].vigenciaFinal);
            comicion = double.Parse(lisTipo[25].costo.ToString());
            ficha = double.Parse(lisTipo[5].costo.ToString());
            propedeutico = double.Parse(lisTipo[3].costo.ToString());
            inscripcion = double.Parse(lisTipo[0].costo.ToString());
        }
        private void insertarDatos()
        {
            try
            {
                direc.calle = txtCALLE.Text;
                direc.nInterno = txtNUMEROIN.Text;
                direc.nExterno = txtNUMEROEX.Text;
                direc.cp = int.Parse(txtCP.Text);
                direc.colonia = txtCOLONIA.Text;
                direc.municipio = txtMUNICIPIO.Text;
                direc.Localidad = txtLC.Text;
                direc.idEstado = int.Parse(ddEstado.SelectedValue);

                persona.nombre = txtName.Text;
                persona.aPaterno = txtLName.Text;
                persona.aMaterno = txtSName.Text;
                persona.fNacimiento = DateTime.Parse(txtCalendario.Text);
                persona.RFC = txtRFC.Text;
                persona.edad = int.Parse(txtEdad.Text);
                persona.sexo = rbSexo.SelectedItem.Value;
                if (rbDisca.SelectedItem.Value.Equals("true")) persona.discapacidad = ddDiscapasidad.SelectedValue; else persona.discapacidad = "N/A";
                if (rbIndigena.SelectedItem.Value.Equals("true")) persona.idIndigena = int.Parse(ddIndigena.SelectedItem.Value); else persona.idIndigena = 1;
                persona.eCivil = ddECivil.SelectedValue;
                if (rbHijos.SelectedItem.Value.Equals("true")) persona.hijos = int.Parse(txtHijos.Text); else persona.hijos = 0;
                persona.nTelefonicoCel = txtNTP.Text;
                persona.cElectronico = txtCE.Text;
                persona.CURP = txtCurp.Text;
                persona.ns = txtNSS.Text;
                if (rbSMedico.SelectedItem.Value.Equals("true")) persona.servicioMedico = ddSM.SelectedValue; else persona.servicioMedico = "N/A";
                persona.tipoSangre = ddSangre.SelectedValue;
                if (rbAlergia.SelectedItem.Value.Equals("true")) persona.alergia = txtAlergia.Text; else persona.alergia = "NEGADAS";

                procedencia.idInstitucion = ddInstituto.SelectedValue;
                procedencia.promedio = txtPROMEDIO.Text;
                procedencia.nCedula = ddDocumentoConcluido.SelectedValue;
                procedencia.idTipoDeEstudio = 1;
                procedencia.fEgreso = DateTime.Parse(txtFDI.Text);

                aspirante.idPE = ddCarrera.SelectedValue;
                if (rbBeca.SelectedItem.Value.Equals("true")) aspirante.beca = ddBecas.SelectedValue; else aspirante.beca = "N/A";
                if (ddCarrera.SelectedItem.Value.Equals("MAESTRÍA EN GESTIÓN DE LA INDUSTRIA PETRÓLERA     ")) aspirante.idModalidad = 5; else aspirante.idModalidad = 1;
                aspirante.urlDocumentos = "http://www.upenergia.edu.mx/SIAUPE/documentos/" + docName;

                tutor.nombre = txtNCT.Text;
                tutor.alergia = txtCALLET.Text + ", #" + txtNUMEXT.Text + " - " + txtNUMINT.Text + ", " + txtCOLONIAT.Text + ", " + txtMUNIT.Text;
                tutor.nTelefonicoCel = txtNTPT.Text;
                tutor.discapacidad = ddEstadoT.SelectedItem.Value + ", " + txtCPT.Text;
                t.parentesco = ddParentesco.SelectedValue;
                t.ocupacion = txtOcupacion.Text;

                persona.idDireccion = ctrlP.insertDireccionUltimo(direc);
                t.idPersona = ctrlP.insertUltimo(tutor);
                aspirante.idAspirante = folioN;
                aspirante.idTutor = ctrlT.insertUltimo(t);
                aspirante.idPersona = ctrlP.insertUltimo(persona);
                aspirante.idProcedencia = ctrlA.insertProcedencia(procedencia);
                if (ctrlA.update(aspirante))
                {
                    insertarReferencia(folioT);
                }
                else
                    lbError.Text = "Ocurrio un Error, por favor revise que haya completado todos los registros";

            }
            catch (Exception ex)
            {
                string msj = ex.Message;
                lbError.Text = "Ocurrio un Error, por favor revise que haya completado todos los registros";
            }
        }
        private void insertarReferencia(string _asp)
        {
            float l = float.Parse(lbImporte.Text.Substring(1));
            referencia.idTipoPago = int.Parse(tp);
            referencia.idAlumno = "aspirante";
            referencia.referencia = long.Parse(lbReferencia.Text);
            referencia.fecha = code.hoy();
            referencia.monto = Math.Round(l, 2);
            referencia.descripcion = "F-" + _asp;
            ctrlR.insert(referencia);
            clear();
        }
        private Boolean cargarDocumentos(Stream _file)
        {
            string path = "~/documentos/";
            Directory.CreateDirectory(Server.MapPath(path));

            BinaryReader br = new BinaryReader(_file);
            byte[] bytes = br.ReadBytes((Int32)_file.Length);

            string filePath = path + docName;
            File.WriteAllBytes(Server.MapPath(filePath), bytes);

            byte[] fileContents = null;

            using (StreamReader sourceStream = new StreamReader(Server.MapPath(filePath)))
            {
                fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
                sourceStream.Close();
            }

            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(host + docName);
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential(user, pass);
                request.ContentLength = fileContents.Length;
                request.UsePassive = true;
                request.UseBinary = true;
                request.ServicePoint.ConnectionLimit = fileContents.Length;
                request.EnableSsl = false;
                using (Stream requestStream = request.GetRequestStream())
                {
                    requestStream.Write(fileContents, 0, fileContents.Length);
                    requestStream.Close();
                }
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                response.Close();
                return true;
            }
            catch (WebException ex)
            {
                string m = ex.Message;
                return false;
            }
        }
        private string validarFormulario()
        {
            string error = "";
            if (rbSexo.SelectedItem == null) error = error + "SEXO | ";

            if (rbDisca.SelectedItem == null) error = error + "DISCAPACIDAD | ";
            else if (rbDisca.SelectedItem.Value.Equals("true") && ddDiscapasidad.SelectedIndex == 0) error = error + "DISCAPACIDAD | ";

            if (rbIndigena.SelectedItem == null) error = error + "PROCEDENCIA INDÍGENA | ";
            else if (rbIndigena.SelectedItem.Value.Equals("true") && ddIndigena.SelectedIndex == 0) error = error + "PROCEDENCIA INDÍGENA | ";


            if (rbHijos.SelectedItem == null) error = error + "TIENE HIJOS | ";
            else if (rbHijos.SelectedItem.Value.Equals("true") && txtHijos.Text.Equals("")) error = error + "TIENE HIJOS | ";

            if (rbAlergia.SelectedItem == null) error = error + "ALERGIAS | ";
            else if (rbAlergia.SelectedItem.Value.Equals("true") && txtAlergia.Text.Equals("")) error = error + "ALERGIAS | ";

            if (rbSMedico.SelectedItem == null) error = error + "SERVICIO MÉDICO | ";
            else if (rbSMedico.SelectedItem.Value.Equals("true") && ddSM.SelectedIndex == 0) error = error + "SERVICIO MÉDICO | ";

            if (rbBeca.SelectedItem == null) error = error + "BECA | ";
            else if (rbBeca.SelectedItem.Value.Equals("true") && ddBecas.SelectedIndex == 0) error = error + "BECA | ";

            if (ddECivil.SelectedIndex == 0) error = error + "ESTADO CIVIL | ";
            if (ddEstado.SelectedIndex == 0) error = error + "DATOS PERSONALES - ESTADO | ";
            if (ddEstadoT.SelectedIndex == 0) error = error + "DATOS TUTOR - ESTADO | ";
            if (ddParentesco.SelectedIndex == 0) error = error + "DATOS TUTOR - PARENTESCO | ";
            if (ddSangre.SelectedIndex == 0) error = error + "GRUPO SANGUÍNEO | ";
            if (ddCarrera.SelectedIndex == 0) error = error + "CARRERA DE INTERÉS | ";
            if (ddInstituto.SelectedIndex == 0) error = error + "BACHILLERATO EGRESO | ";
            if (ddDocumentoConcluido.SelectedIndex == 0) error = error + "BACHILLERATO EGRESO - DOCUMENTO| ";
            if (!fuDatos.HasFile) error = error + "CARGA DE DOCUMENTACIÓN | ";

            return error;
        }
        private string agrupar(string _crr, string _tp, string _f)
        {
            string carr = "";

            try
            {
                switch (ddCarrera.SelectedItem.ToString())
                {
                    case "INGENIERÍA EN ENERGÍA                             ":
                        carr = "01";
                        break;
                    case "INGENIERÍA EN LOGÍSTICA Y TRANSPORTE              ":
                        carr = "02";
                        break;
                    case "INGENIERÍA PETROLERA                              ":
                        carr = "03";
                        break;
                    case "INGENIERÍA SEGURIDAD PARA LA INDUSTRIA ENERGÉTICA ":
                        carr = "04";
                        break;
                    case "MAESTRÍA EN GESTIÓN DEL PETRÓLEO                  ":
                        carr = "05";
                        break;
                    default:
                        carr = _crr;
                        break;
                }
            }
            catch (Exception el)
            {
                string msg = el.Message;
                carr = _crr;
            }

            return _tp + carr + _f;
        }
        private string[] fechaString(string _fecha)
        {
            string[] ls = new string[3];
            ls[2] = _fecha.Substring(0, 4);
            ls[1] = _fecha.Substring(5, 2);
            ls[0] = _fecha.Substring(8, 2);
            return ls;
        }
        private bool openConv()
        {
            convocatoria = ctrlCon.covocatoria();
            c = convocatoria.idConvocatoria;
            bool r = false;
            int d = DateTime.Today.Day;
            int m = DateTime.Today.Month;
            int y = DateTime.Today.Year;

            if (y == convocatoria.ciclo)
            {

                if (m <= convocatoria.mesFin)
                {
                    if (d <= convocatoria.diaFin) r = true;

                    else return r = false;
                }
            }
            return r;
        }
        protected void rbDisca_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbDisca.SelectedValue.Equals("true"))
                ddDiscapasidad.Visible = true;
            else
                ddDiscapasidad.Visible = false;
        }
        protected void rbIndigena_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbIndigena.SelectedValue.Equals("true"))
                ddIndigena.Visible = true;
            else
                ddIndigena.Visible = false;
        }
        protected void rbHijos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbHijos.SelectedValue.Equals("true"))
                txtHijos.Visible = true;
            else
                txtHijos.Visible = false;
        }
        protected void rbSMedico_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbSMedico.SelectedValue.Equals("true"))
                ddSM.Visible = true;
            else
                ddSM.Visible = false;
        }
        protected void rbBeca_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbBeca.SelectedValue.Equals("true"))
                ddBecas.Visible = true;
            else
                ddBecas.Visible = false;
        }
        protected void rbAlergia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbAlergia.SelectedValue.Equals("true"))
                divTxt.Visible = true;
            else
                divTxt
                    .Visible = false;
        }


    }
}
