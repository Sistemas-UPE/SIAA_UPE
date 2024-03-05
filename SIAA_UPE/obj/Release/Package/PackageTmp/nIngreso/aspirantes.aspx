<%@ Page Title="" Language="C#" MasterPageFile="~/base.Master" AutoEventWireup="true" CodeBehind="aspirantes.aspx.cs" Inherits="SIAA_UPE.nIngreso.aspirantes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>SIAA | Ficha de nuevo ingreso</title>
    <script  src="../src/js/contador.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <p>Tiempo restante: <span id="contador">10:00</span></p>
    <div runat="server" id="step1" visible="true">
        <div class="login">
            <h1>Sistema de Integración Académico y Administrativo de la UPE</h1>
            <img src="../src/img/logo/upe.png" id="icon" alt="User Icon" />
            <h3>Por favor, ingresa tu CURP para comenzar o continuar tu proceso de nuevo ingreso</h3>
            <asp:Label ID="lbError" runat="server" Visible="false" CssClass="txt" ForeColor="#990000" /><br />
            <div class="form">
                <asp:TextBox ID="txtCurp" runat="server" required="true" autocomplete="off" />
		        <label class="lbl-nombre"><span class="text-nomb">CURP</span></label>
            </div><br />
            <asp:Button ID="btnValidad" runat="server" CssClass="primary" Text="Comenzar con el proceso " OnClick="btnValidad_Click" />
        </div>
    </div>
      
    <center>
    <div  id="step2" runat="server" visible="false" style="width:90%">
        <fieldset>
            <legend><asp:Label ID="lbNF" runat="server" /></legend> 
            <fieldset>
                <legend>DATOS PERSONALES</legend>
                <!---------DATOS PERSONALES ----------->
                <div class="formulario">
                    <div class="fcont">
                        <div class="form">
                            <asp:TextBox ID="txtName" runat="server" required="true" maxlength="80" autocomplete="off"/>
	                        <label class="lbl-nombre"><span class="text-nomb">NOMBRE (S)</span></label>
                        </div><br />
                        <div class="form">
                            <asp:TextBox ID="txtLName" runat="server" required="true"  maxlength="20" autocomplete="off"/>
	                        <label class="lbl-nombre"><span class="text-nomb">APELLIDO PATERNO</span></label>
                        </div><br />
                        <div class="form">
                            <asp:TextBox ID="txtSName" runat="server" required="true" maxlength="20" autocomplete="off"/>
	                        <label class="lbl-nombre"><span class="text-nomb">APELLIDO MATERNO</span></label>
                        </div><br />
                        <div class="form">
                            <asp:TextBox ID="txtRFC" runat="server" required="true" maxlength="20" autocomplete="off"/>
		                    <label class="lbl-nombre"><span class="text-nomb">RFC</span></label>
                        </div>
                        <h3>¿No sabes cuál es tu RFC? <a href="https://www.mi-rfc.com.mx/consulta-rfc-homoclave" target="_blank">Consúltalo aquí</a></h3><br />
                        <fieldset>
                            <legend>FECHA DE NACIMIENTO</legend>
                            <asp:TextBox required="TRUE" ID="txtCalendario" class="txt"  runat="server" TextMode="Date" />
                        </fieldset>
                        <asp:TextBox required="TRUE" ID="txtEdad" runat="server" placeholder="¿CUÁL ES SU EDAD?"  type="number" CssClass="txt"   maxlength="3"/><br/>
                        <asp:DropDownList CssClass="txt" ID="ddECivil" runat="server">
                                        <asp:ListItem>ESTADO CIVIL</asp:ListItem>
                                        <asp:ListItem>SOLTERÍA</asp:ListItem>
                                        <asp:ListItem>MATRIMONIO</asp:ListItem>
                                        <asp:ListItem>DIVORCIO</asp:ListItem>
                                        <asp:ListItem>SEPARACIÓN EN PROCESO JUDICIAL</asp:ListItem>
                                        <asp:ListItem>VIUDEZ</asp:ListItem>
                                        <asp:ListItem>CONCUBINATO</asp:ListItem>
                                    </asp:DropDownList>
                        <table style="width:100%">
                            <tr>
                                <th >SEXO&nbsp;</th>
                                <th >
                                    <asp:RadioButtonList ID="rbSexo" runat="server">
                                        <asp:ListItem Text="MUJER" Value="mujer" />
                                        <asp:ListItem Text="HOMBRE" Value="hombre" />
                                    </asp:RadioButtonList>
                                </th>
                            </tr>
                            <tr>
                                <th  >SUFRE DE ALGUNA DISCAPACIDAD</th>
                                <th  >
                                <asp:RadioButtonList ID="rbDisca" runat="server" AutoPostBack ="true" OnSelectedIndexChanged="rbDisca_SelectedIndexChanged">
                                    <asp:ListItem Text="SI" Value="true" />
                                    <asp:ListItem Text="NO" Value="false" />
                                </asp:RadioButtonList>
                                </th>
                            </tr>
                            <tr>
                                <th colspan="2">
                                    <asp:DropDownList CssClass="txt" ID="ddDiscapasidad" runat="server" visible="false">
                                        <asp:ListItem>POR FAVOR INDIQUE CUAL SU TIPO DE DISCAPASIDAD</asp:ListItem>
                                        <asp:ListItem>DISCAPACIDAD FÍSICA</asp:ListItem>
                                        <asp:ListItem>DISCAPACIDAD INTELECTUAL</asp:ListItem>
                                        <asp:ListItem>DISCAPACIDAD MENTAL</asp:ListItem>
                                        <asp:ListItem>DISCAPACIDAD PSICOSOCIAL</asp:ListItem>
                                        <asp:ListItem>DISCAPACIDAD MÚLTIPLE</asp:ListItem>
                                        <asp:ListItem>DISCAPACIDAD SENSORIAL</asp:ListItem>
                                        <asp:ListItem>DISCAPACIDAD AUDITIVA</asp:ListItem>
                                        <asp:ListItem>DISCAPACIDAD VISUAL</asp:ListItem>
                                    </asp:DropDownList>
                                </th>
                            </tr>
                            <tr>
                                <th >ES DE PROCEDENCIA INDÍGENA</th>
                                <th >
                                <asp:RadioButtonList ID="rbIndigena" runat="server" AutoPostBack ="true" OnSelectedIndexChanged="rbIndigena_SelectedIndexChanged" >
                                    <asp:ListItem Text="SI" Value="true" />
                                    <asp:ListItem Text="NO" Value="false" />
                                </asp:RadioButtonList>
                                </th>
                            </tr>
                            <tr>
                                <th colspan="2">
                                    <asp:DropDownList ID="ddIndigena" runat="server" Visible="false" CssClass="txt" DataValueField="idIndigena" DataTextField="dialecto" />
                                </th>
                            </tr>
                            <tr>
                                <th class="auto-style1"  width="50%">¿TIENES DESCENDENCIA?</th>
                                <th  width="50%">
                                <asp:RadioButtonList ID="rbHijos" runat="server" AutoPostBack ="true" OnSelectedIndexChanged="rbHijos_SelectedIndexChanged" >
                                    <asp:ListItem Text="SI" Value="true" />
                                    <asp:ListItem Text="NO" Value="false" />
                                </asp:RadioButtonList>
                                </th>
                            </tr>
                            <tr>
                                <th colspan="2"">
                                    <asp:TextBox required="TRUE" ID="txtHijos" runat="server" Visible="false" placeholder="¿INDICA EL NÚMERO DE DESCENDIENTES?"   maxlength="2"  type="number" CssClass="txt"/>
                                </th>
                            </tr>

                        </table>
                    </div>
                    <div class="fcont">                                
                        <div class="form">
                            <asp:TextBox ID="txtCALLE" runat="server" required="true" maxlength="40" autocomplete="off"/>
	                        <label class="lbl-nombre"><span class="text-nomb">CALLE</span></label>
                        </div><br />

                        <table>
                            <tr>
                                <th>
                                    <div class="form">
                                        <asp:TextBox ID="txtNUMEROEX" runat="server" required="true" maxlength="5" autocomplete="off"/>
	                                    <label class="lbl-nombre"><span class="text-nomb"># EXT</span></label>
                                    </div>
                                </th>
                                <th>
                                    <div class="form">
                                        <asp:TextBox ID="txtNUMEROIN" runat="server" required="true" maxlength="5" autocomplete="off"/>
	                                    <label class="lbl-nombre"><span class="text-nomb"># INT</span></label>
                                    </div>
                                </th>
                                <th>
                                    <div class="form">
                                        <asp:TextBox ID="txtCP" runat="server" required="true" maxlength="6" autocomplete="off" type="number" />
	                                    <label class="lbl-nombre"><span class="text-nomb"># C.P.</span></label>
                                    </div>
                                </th>
                            </tr>
                        </table>
                        <div class="form">
                            <asp:TextBox ID="txtCOLONIA" runat="server" required="true" maxlength="40" autocomplete="off"/>
	                        <label class="lbl-nombre"><span class="text-nomb">COLONIA</span></label>
                        </div><br />
                        <div class="form">
                            <asp:TextBox ID="txtMUNICIPIO" runat="server" required="true"  maxlength="40" autocomplete="off"/>
	                        <label class="lbl-nombre"><span class="text-nomb">MUNICIPIO</span></label>
                        </div><br />
                        <div class="form">
                            <asp:TextBox ID="txtLC" runat="server" required="true" maxlength="40" autocomplete="off"/>
	                        <label class="lbl-nombre"><span class="text-nomb">LOCALIDAD</span></label>
                        </div><br />
                        <asp:DropDownList ID="ddEstado" runat="server" CssClass="txt" DataValueField="idEstado" DataTextField="nomEstado" />

                        <div class="form">
                            <asp:TextBox ID="txtNTP" runat="server" required="true" maxlength="12" autocomplete="off"/>
	                        <label class="lbl-nombre"><span class="text-nomb">NÚMERO TELÉFONICO CEL</span></label>
                        </div><br />
                        <div class="form">
                            <asp:TextBox ID="txtCE" runat="server" required="true"  maxlength="40" autocomplete="off"/>
	                        <label class="lbl-nombre"><span class="text-nomb">CORREO ELECTRONICO</span></label>
                        </div><br />
                        <div class="form">
                            <asp:TextBox ID="txtNSS" runat="server" required="true" maxlength="13" autocomplete="off"/>
	                        <label class="lbl-nombre"><span class="text-nomb">NÚMERO DE SEGURO SOCIAL</span></label>
                        </div>
                        <table  style="width:100%">
                            <tr>
                                <th >¿CUENTA CON SERVICIO MÉDICO?</th>
                                <th >
                                <asp:RadioButtonList ID="rbSMedico" runat="server" AutoPostBack ="true" OnSelectedIndexChanged="rbSMedico_SelectedIndexChanged" >
                                    <asp:ListItem Text="SI" Value="true" />
                                    <asp:ListItem Text="NO" Value="false" />
                                </asp:RadioButtonList>
                                </th>
                            </tr>
                            <tr>
                                <th colspan="2"">
                                    <asp:DropDownList CssClass="txt" ID="ddSM" runat="server" visible="false">
                                        <asp:ListItem>POR FAVOR INDIQUE SU SERVICIO MÉDICO</asp:ListItem>
                                        <asp:ListItem>IMSS</asp:ListItem>
                                        <asp:ListItem>ISSSTE</asp:ListItem>
                                        <asp:ListItem>PEMEX</asp:ListItem>
                                        <asp:ListItem>SEDENA</asp:ListItem>
                                        <asp:ListItem>SEMAR</asp:ListItem>
                                        <asp:ListItem>SPS       </asp:ListItem>
                                        <asp:ListItem>SEGURO POPULAR </asp:ListItem>
                                    </asp:DropDownList>
                                </th>
                            </tr>
                        </table>
                        <asp:DropDownList CssClass="txt" ID="ddSangre" runat="server">
                            <asp:ListItem>POR FAVOR INDIQUE SU GRUPO SANGUÍNEO</asp:ListItem>
                            <asp:ListItem>A+</asp:ListItem>
                            <asp:ListItem>A-</asp:ListItem>
                            <asp:ListItem>B+</asp:ListItem>
                            <asp:ListItem>B-</asp:ListItem>
                            <asp:ListItem>AB+</asp:ListItem>
                            <asp:ListItem>AB-</asp:ListItem>
                            <asp:ListItem>O+</asp:ListItem>
                            <asp:ListItem>O-</asp:ListItem>
                        </asp:DropDownList>

                        <table  style="width:100%">
                            <tr>
                                    <th >¿PADECE ALGUNA ALERGIA?</th>
                                    <th >
                                    <asp:RadioButtonList ID="rbAlergia" runat="server" AutoPostBack ="true" OnSelectedIndexChanged="rbAlergia_SelectedIndexChanged" >
                                        <asp:ListItem Text="SI" Value="true" />
                                        <asp:ListItem Text="NO" Value="false" />
                                    </asp:RadioButtonList>
                                    </th>
                            </tr>
                            <tr>
                                <th colspan="2"">
                                    <div class="form" ID="divTxt" runat="server" Visible="false">
                                        <asp:TextBox ID="txtAlergia" runat="server" required="true"  maxlength="100" autocomplete="off"/>
	                                    <label class="lbl-nombre"><span class="text-nomb">En menos de 100 palabras indica tu alergia</span></label>
                                    </div>
                                </th>
                            </tr>
                        </table>
                    </div>

                </div>

            </fieldset>


            <fieldset>
                <legend>DATOS ACADÉMICOS</legend>

                <div class="formulario">
                    <div class="fcont">
                        <h2>NUEVO INGRESO</h2>
                        <asp:DropDownList ID="ddCarrera" runat="server" CssClass="txt" DataValueField="idPE" DataTextField="nomProEdu"/><br />
                        <table  style="width:100%">
                            <tr>
                            <th  width="50%"">¿TIENES BECA?</th>
                            <th  width="50%">
                            <asp:RadioButtonList ID="rbBeca" runat="server" AutoPostBack ="true" OnSelectedIndexChanged="rbBeca_SelectedIndexChanged" >
                                <asp:ListItem Text="SI" Value="true" />
                                <asp:ListItem Text="NO" Value="false" />
                            </asp:RadioButtonList>
                            </th>
                        </tr>
                        <tr>
                            <th colspan="2">
                                <asp:DropDownList CssClass="txt" ID="ddBecas" runat="server" visible="false">
                                    <asp:ListItem>POR FAVOR INDIQUE SU BECA</asp:ListItem>
                                    <asp:ListItem>BECA INDÍGENA</asp:ListItem>
                                    <asp:ListItem>BECA LÍDERES DEL MAÑANA</asp:ListItem>
                                    <asp:ListItem>BECA PROBEMEX</asp:ListItem>
                                    <asp:ListItem>BECA TELMEX</asp:ListItem>
                                    <asp:ListItem>BECAS AMLO</asp:ListItem>
                                    <asp:ListItem>BECAS BANAMEX</asp:ListItem>
                                    <asp:ListItem>BECAS BANCOMER</asp:ListItem>
                                    <asp:ListItem>BECAS CONACYT</asp:ListItem>
                                    <asp:ListItem>BECAS CONAFE</asp:ListItem>
                                    <asp:ListItem>BECAS DE MOVILIDAD INTERNACIONAL</asp:ListItem>
                                    <asp:ListItem>BECAS EDUCAFIN</asp:ListItem>
                                    <asp:ListItem>BECAS ELISA ACUÑA</asp:ListItem>
                                    <asp:ListItem>BECAS FUNDACIÓN CARLOS SLIM</asp:ListItem>
                                    <asp:ListItem>BECAS IMJUVE</asp:ListItem>
                                    <asp:ListItem>BECAS ISSFAM</asp:ListItem>
                                    <asp:ListItem>BECAS NACIONALES CONACYT</asp:ListItem>
                                    <asp:ListItem>BECAS OEA</asp:ListItem>
                                    <asp:ListItem>BECAS SEC</asp:ListItem>
                                    <asp:ListItem>BECAS SEDENA</asp:ListItem>
                                    <asp:ListItem>BECAS SEMS</asp:ListItem>
                                    <asp:ListItem>BECAS SEP</asp:ListItem>
                                    <asp:ListItem>BECAS SEP PRONABES</asp:ListItem>
                                    <asp:ListItem>BECAS SEP MEDIA SUPERIOR</asp:ListItem>

                                </asp:DropDownList>
                            </th>
                        </tr>
                        </table>
                    </div>
                    <div class="fcont">
                        <h2>PROCEDENCIA</h2>
                        <asp:DropDownList CssClass="txt" ID="ddInstituto" runat="server" DataTextField="NomMuni" DataValueField="idInstitucion" />                        
                        <div class="form">
                            <asp:TextBox ID="txtPROMEDIO" runat="server" required="true" autocomplete="off" maxlength="4"/>
		                    <label class="lbl-nombre"><span class="text-nomb">PROMEDIO FINAL DEL BACHILLERATO</span></label>
                        </div><br />
                        <asp:DropDownList CssClass="txt" ID="ddDocumentoConcluido" runat="server">
                            <asp:ListItem>POR FAVOR INDIQUE EL DOCUMENTO QUE RECIBIÓ</asp:ListItem>
                            <asp:ListItem>CERTIFICADO</asp:ListItem>
                            <asp:ListItem>CONSTANCIA</asp:ListItem>
                            <asp:ListItem>DIPLOMA</asp:ListItem>
                        </asp:DropDownList><br />
                        <fieldset>
                            <legend>FECHA DE EGRESO</legend>
                            <asp:TextBox required="TRUE" ID="txtFDI"  class="txt" runat="server" TextMode="Date" />
                        </fieldset>

                    </div>
                </div>
            </fieldset>

                    <!---------Datos tutor----------->
            <fieldset>
                <legend>DATOS DE LA PERSONA TUTORA</legend>
                <div class="formulario">

                        <div class="fcont">
                            <div class="form">
                                <asp:TextBox ID="txtNCT" runat="server" required="true" autocomplete="off" maxlength="80"/>
		                        <label class="lbl-nombre"><span class="text-nomb">NOMBRE COMPLETO</span></label>
                            </div>
                            <asp:DropDownList CssClass="txt" ID="ddParentesco" runat="server" >
                                <asp:ListItem>POR FAVOR INDIQUE EL PARENTESCO</asp:ListItem>
                                <asp:ListItem>PADRE</asp:ListItem>
                                <asp:ListItem>MADRE</asp:ListItem>
                                <asp:ListItem>TUTOR</asp:ListItem>
                                <asp:ListItem>PAREJA</asp:ListItem>
                            </asp:DropDownList>
                            <div class="form">
                                <asp:TextBox ID="txtNTPT" runat="server" required="true" autocomplete="off" maxlength="12" type="number"/>
		                        <label class="lbl-nombre"><span class="text-nomb">NÚMERO TELEFÓNICO </span></label>
                            </div>
                            <div class="form">
                                <asp:TextBox ID="txtOcupacion" runat="server" required="true" autocomplete="off" maxlength="100"/>
		                        <label class="lbl-nombre"><span class="text-nomb">OCUPACIÓN</span></label>
                            </div>
                        </div>
                        <div class="fcont">
                            <div class="form">
                                <asp:TextBox ID="txtCALLET" runat="server" required="true" autocomplete="off" maxlength="40"/>
		                        <label class="lbl-nombre"><span class="text-nomb">CALLE</span></label>
                            </div>

                            <table>
                                <tr>
                                    <th>
                                        <div class="form">
                                            <asp:TextBox ID="txtNUMEXT" runat="server" required="true" maxlength="5" autocomplete="off"/>
	                                        <label class="lbl-nombre"><span class="text-nomb"># EXT</span></label>
                                        </div>
                                    </th>
                                    <th>
                                        <div class="form">
                                            <asp:TextBox ID="txtNUMINT" runat="server" required="true" maxlength="5" autocomplete="off"/>
	                                        <label class="lbl-nombre"><span class="text-nomb"># INT</span></label>
                                        </div>
                                    </th>
                                    <th>
                                        <div class="form">
                                            <asp:TextBox ID="txtCPT" runat="server" required="true" maxlength="6" autocomplete="off" type="number" />
	                                        <label class="lbl-nombre"><span class="text-nomb"># C.P.</span></label>
                                        </div>
                                    </th>
                                </tr>
                            </table>
                            
                            <div class="form">
                                <asp:TextBox ID="txtCOLONIAT" runat="server" required="true" autocomplete="off" maxlength="40"/>
		                        <label class="lbl-nombre"><span class="text-nomb">COLONIA</span></label>
                            </div>
                            <div class="form">
                                <asp:TextBox ID="txtMUNIT" runat="server" required="true" autocomplete="off" maxlength="40"/>
		                        <label class="lbl-nombre"><span class="text-nomb">MUNICIPIO</span></label>
                            </div>
                            <asp:DropDownList ID="ddEstadoT" runat="server" CssClass="txt" DataValueField="idEstado" DataTextField="nomEstado"/>           
                    </div>
                </div>
            </fieldset>

            <fieldset>
                <legend>CARGA DE DOCUMENTACIÓN</legend>
                <p class="txt">Por favor, adjunte la siguiente documentación enlistada, debe ser comprimida en formato .ZIP o .RAR (El archivo a cargar no debe pasar los 5 MB)</p><br />
                <img src="../src/img/TABALA.png" style="position:center;width:70%">
                <asp:FileUpload CssClass="txt" ID="fuDatos" runat="server"  />
            </fieldset>

                <br /><br /><a><asp:Label ID="lbErrorFormulario" runat="server" /></a> <br /><br />           
                <asp:Button ID="btnGuardar" runat="server" CssClass="success" Text="Enviar formulario" OnClick="btnGuardar_Click"/>
         </fieldset>
    </div>
    </center>

    <div class="fichaFondo" id="step3" runat="server"  visible ="false">
        <div class="popCN" >
            <center>
            <div class="center" id="divConfirmacion"  runat="server">
                <p class="txt">
                    <strong>Apreciable Aspirante,</strong><br /><br />
                    Es importante que sepas que toda la información proporcionada será utilizada exclusivamente para el trámite de inscripción de ficha. No se compartirá con terceros ni se utilizará con otros fines. Tu privacidad es nuestra prioridad.<br />
                    Si tienes alguna pregunta o inquietud, no dudes en contactarnos.<br /> 
                    Agradecemos tu colaboración y confianza.</p>
                    <h2>¡Te damos la bienvenida al proceso de inscripción de ficha!</h2><br /><br />
                <asp:Button ID="btn" CssClass="success" runat="server" Text="ESTOY DEACUERDO Y DESEO CONTINUAR." OnClick="btn_Click"/>
                 <button class="danger"  title="TU INFORMACIÓN NO SE GUARDARÁ Y VOLVERÁS AL INICIO" value='NO ESTOY DEACUERDO' onclick='javascript:location.reload()'>NO ESTOY DEACUERDO</button>
            </div>
            <br />
            <div id="divFicha" runat="server" visible="false">
                <img src="../src/img/logo/upe.png" class="logo" />
                 
                    <i> Las Referencias son personales e intransferibles.</i><br />
                    <i> Cuota establecida en UMAS; Ultima actualizacíon de la UMA el 01/02/2024.</i><br />
                    <table>
                        <tr class="medium">
                            <td colspan="4">  &nbsp; </td>
                        </tr>
                        <tr>
                            <td><b>Convenio Bancomer-CIE:</b></td>
                            <td colspan="3">1839594</td>
                        </tr>
                        <tr>
                            <td class="auto-style1"><b>Referencia:</b></td>
                            <td colspan="3" class="auto-style1"><asp:Label ID="lbReferencia" runat="server" /></td>
                        </tr>
                       
                        <tr>
                            <td><b>Importe total:</b></td>
                            <td colspan="3"><asp:Label ID="lbImporte" runat="server" /></td>
                        </tr>
                        <tr>
                            <td><b>Nombre del Interesado:</b></td>
                            <td colspan="3"><asp:Label ID="lbNombre" runat="server" /></td>
                        </tr>
                        <tr>
                            <td><b>Concepto de pago:</b></td>
                            <td colspan="3"><asp:Label ID="lbConcepto" runat="server" /></td>
                        </tr>
                       
                    </table>
                    
                    <a><asp:Label ID="lbmsjFicha" runat="server"  /></a><br />
                    <div class="center">
                        <button class="success" onclick="imprimirDiv('body_step3')">Imprimir</button>
                    </div>
            </div>
            </center>
        </div>
   </div>
    <div  id="step4" runat="server" visible="false"  >
            <fieldset>
                <legend>FUISTE REGISTRADO CON EL FOLIO: <asp:Label ID="lbCF" runat="server" /></legend>
                <center>
                    <p class="txt">Ya realizaste tu registro para la solicitud de ficha, mismos que serán revisados y validados, por favor, vuelve más tarde para revisar tu estatus.</p>
            
                        <table>
                            <tr class="medium"><td colspan="4">&nbsp;</td>
                            </tr>
                            <tr>
                                <td><b>Convenio Bancomer-CIE:</b></td>
                                <td colspan="3">1839594</td>
                            </tr>
                            <tr>
                                <td class="auto-style1"><b>Referencia:</b></td>
                                <td colspan="3" class="auto-style1"><asp:Label ID="lbReferenciaAspirante" runat="server" /></td>
                            </tr>
                       
                            <tr>
                                <td><b>Importe total:</b></td>
                                <td colspan="3"><asp:Label ID="lbImporteAspirante" runat="server" /></td>
                            </tr>
                            <tr>
                                <td><b>Nombre del Interesado:</b></td>
                                <td colspan="3"><asp:Label ID="lbNombreAspirante" runat="server" /></td>
                            </tr>
                            <tr>
                                <td><b><asp:Label ID="lbLeyerCP" runat="server" /></b></td>
                                <td colspan="3"><asp:Label ID="lbConceptoV" runat="server" /></td>
                            </tr>
                            <tr>
                                <td><b>Estatus:</b></td>
                                <td colspan="3"><asp:Label ID="lbEstado" runat="server" CssClass="red"/></td>
                            </tr>
                        </table>

                        <br />
                        <button class="success" title="Reimprime tu ficha de pago" onclick="imprimirDiv('body_step4')">Imprimir</button>

                        <div   id="divPropedeutico" runat="server" visible="false" style="align-content:center;">
                            <p class="txt">Genial, ya puedes generar tu ficha para aplicar el curso propedéutico en la UPE, estas a unos pasos mas de ser un #AtlanteUPE  </p>
                            <asp:Button ID="btnPropedeutico" runat="server" CssClass="primary" Text="Generar ficha" OnClick="btnPrope_Click"/>
                        </div>
                </center>
             </fieldset>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>
</asp:Content>