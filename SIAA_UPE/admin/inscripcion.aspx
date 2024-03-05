<%@ Page Title="" Language="C#" MasterPageFile="~/base.Master" AutoEventWireup="true" CodeBehind="inscripcion.aspx.cs" Inherits="SIAA_UPE.admin.inscripcion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>SIAA | Inscripción Nuevo Ingreso</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="divPop"  id="imprimir" runat="server">
        <br />
        <fieldset>
            <h2 class="active"> REGISTRO </h2>
            
            <div id="divStep1" runat="server">
                <h4> Por favor Ingrese su nombre y CURP para validar sus datos.</h4>
                <asp:TextBox ID="txtNombre" runat="server" placeholder="Nombre Completo" required/><br />
                <asp:TextBox ID="txtCURP" runat="server" placeholder="CURP" required/><br />    
                <a><asp:Label ID="lbError" runat="server" /></a><br />
                <asp:Button ID="btnValidar" runat="server" Text="VALIDAR" OnClick="btnValidar_Click" />            
            </div>
            
            <div id="divStep2" runat="server" visible="false">
            <h3> Verifique si sus datos son correctos y agregue sus datos faltantes, dicha información solamente será usada para fines del mismo tramite de inscripción. </h3>
                            
            <fieldset>
                <legend><b style="color:black; font-size-adjust:15">DATOS PERSONALES</b></legend>
                <!---------DATOS PERSONALES ----------->

                <table>
                    <tr>
                        <th width="50%">
                            <asp:TextBox ID="txtName" runat="server" placeholder="NOMBRE COMPLETO" Enabled="false"/>
                            
                            <asp:TextBox ID="txtCE" runat="server" placeholder="CORREO ELECTRONICO " required/>
                            <legend>FECHA DE NACIMIENTO</legend>
                            <asp:TextBox ID="txtCalendario" class="txt"  placeholder="Fecha de nacimieto" runat="server" TextMode="Date" required/>
                            <table>
                            <tr>
                                <th class="auto-style1" width="50%">SEXO</th>
                                <th width="50%">
                                <asp:RadioButtonList ID="rbSexo" runat="server">
                                    <asp:ListItem Text="M" Value="true" />
                                    <asp:ListItem Text="F" Value="false" />
                                </asp:RadioButtonList>
                                </th>
                            </tr>
                            <tr>
                                <th  width="50%"">SUFRE DE ALGUNA DISCAPACIDAD</th>
                                <th  width="50%">
                                <asp:RadioButtonList ID="rbDisca" runat="server">
                                    <asp:ListItem Text="SI" Value="true" />
                                    <asp:ListItem Text="NO" Value="false" />
                                </asp:RadioButtonList>
                                </th>
                            </tr>
                                <tr>
                                <th class="auto-style1"  width="50%">ES DE PROCEDENCIA INDÍGENA</th>
                                <th  width="50%">
                                <asp:RadioButtonList ID="rbIndigena" runat="server">
                                    <asp:ListItem Text="SI" Value="true" />
                                    <asp:ListItem Text="NO" Value="false" />
                                </asp:RadioButtonList>
                                </th>
                            </tr>
                            </table>
                        </th>
                        
                        <th width="50%">
                            <asp:TextBox ID="txtNTP" runat="server" placeholder="NÚMERO TELEFÓNICO" required/>
                            <asp:TextBox ID="txtCALLE" runat="server" placeholder="CALLE" required/>
                            <table>
                                <tr>
                                    <th><asp:TextBox ID="txtNUMEROEX" runat="server" placeholder="# EXT"/></th>
                                    <th><asp:TextBox ID="txtNUMEROIN" runat="server" placeholder="# INT"/></th>
                                    <th><asp:TextBox ID="txtCP" runat="server" placeholder="C.P." /></th>
                                </tr>
                            </table>
                            <asp:TextBox ID="txtCOLONIA" runat="server" placeholder="COLONIA" required/>
                            <asp:TextBox ID="txtMUNICIPIO" runat="server" placeholder="MUNICIPIO" required/>
                            <asp:TextBox ID="txtLC" runat="server" placeholder="LOCALIDAD" required/>
                            <asp:DropDownList ID="ddEstado" runat="server" CssClass="txt" DataValueField="idEstado" DataTextField="nomEstado" required/>
                        </th>

                    </tr>
                </table>                
            </fieldset>

            <fieldset>
                <legend><b style="color:black; font-size-adjust:15">DATOS ACADEMICOS</b></legend>
                    <!---------DATOS ACADEMICOS ----------->
                <table>

                    <tr>
                        <th width="50%">
                            <asp:TextBox ID="txtMATRICULA" runat="server" placeholder="MATRICULA" Enabled="false"/>
                            <asp:DropDownList ID="ddCarrera" runat="server" CssClass="txt" DataValueField="idPE" DataTextField="nomProEdu" required/>
                            <asp:TextBox ID="txtGRUPO" runat="server" placeholder="GRUPO"/>
                        </th>
                        <th width="50%">
                            <asp:TextBox ID="txtPROMEDIO" runat="server" placeholder="PROMEDIO FINAL DEL BACHILLERATO" required/>
                            <asp:TextBox ID="txtFDI" runat="server" placeholder="FECHA DE INGRESO" Enabled="false" required/>
                            <asp:TextBox ID="txtNDSS" runat="server" placeholder="NUMERO DE SEGURO SOCIAL" required/>
                            <asp:TextBox ID="txtEDP" runat="server" placeholder="ESCUELA DE PROCEDENCIA" required/>                            
                        </th>
                    </tr>
                </table>
            </fieldset>

            <fieldset>
                <legend><b style="color:black; font-size-adjust:15">DATOS DEL TUTOR</b></legend>
                    <!--------- ----------->
                 <table>

                    <tr>
                        <th width="50%">
                            <asp:TextBox ID="txtNCT" runat="server" placeholder="NOMBRE" required/>
                            <asp:TextBox ID="txtAPP" runat="server" placeholder="APELLIDO PATERNO" required/>
                            <asp:TextBox ID="txtAPM" runat="server" placeholder="APELLIDO MATERNO" required/>
                             <legend>FECHA DE NACIMIENTO</legend>
                            <asp:TextBox ID="txtFechaNaT" class="txt" runat="server" TextMode="Date"/>
                            <table>
                                <tr>
                                    <th  width="50%">SEXO</th>
                                    <th>
                                    <asp:RadioButtonList ID="rbsexot" runat="server">
                                        <asp:ListItem Text="M" Value="true" />
                                        <asp:ListItem Text="F" Value="false" />
                                    </asp:RadioButtonList>
                                    </th>
                                </tr>
                                <tr>
                                    <th  width="50%">SUFRE DE ALGUNA DISCAPACIDAD</th>
                                    <th >
                                    <asp:RadioButtonList ID="rdDisT" runat="server">
                                        <asp:ListItem Text="SI" Value="true" />
                                        <asp:ListItem Text="NO" Value="false" />
                                    </asp:RadioButtonList>
                                    </th>
                                </tr>
                            </table>
                            <asp:TextBox ID="txtCORREOT" runat="server" placeholder="CORREO ELECTRONICO " required/>
                            <asp:TextBox ID="txtNTPT" runat="server" placeholder="NÚMERO TELEFÓNICO " required/>
                        </th>
                        <th width="50%">
                            <asp:TextBox ID="txtNTFT" runat="server" placeholder="NÚMERO TELEFÓNICO FIJO "/>
                            <asp:TextBox ID="txtCALLET" runat="server" placeholder="CALLE"/>
                            <table>
                                <tr>
                                    <th><asp:TextBox ID="txtNUMEXT" runat="server" placeholder="# EXT"/></th>
                                    <th><asp:TextBox ID="txtNUMINT" runat="server" placeholder="# INT"/></th>
                                    <th><asp:TextBox ID="txtCPT" runat="server" placeholder="C.P." /></th>
                                </tr>
                            </table>
                            <asp:TextBox ID="txtCOLONIAT" runat="server" placeholder="COLONIA"/>
                            <asp:TextBox ID="txtMUNIT" runat="server" placeholder="MUNICIPIO"/>
                            <asp:TextBox ID="txtLOCT" runat="server" placeholder="LOCALIDAD"/>
                            <asp:DropDownList ID="ddEstadoT" runat="server" CssClass="txt" DataValueField="idEstado" DataTextField="nomEstado" required/>                          
                    </tr>
                </table>
            </fieldset>
            <fieldset>
                <legend><b style="color:black; font-size-adjust:15">DATOS PARA PAGO</b></legend>
                Gracias por validar tu registro de inscripción, ahora selecciona tu forma de pago, recuerda que solo dispones de 2 días hábiles para hacer tu deposito. <br /> Mantente atento al grupo de WhatsApp para más detalles.</p>
                <asp:DropDownList ID="ddMpago" runat="server" CssClass="txt" ><asp:ListItem>Seleccione su forma de pago</asp:ListItem><asp:ListItem>Medios electronicos (Transferencia,Pago en linea, Practi-caja)</asp:ListItem><asp:ListItem>Pago en ventanilla bancaria</asp:ListItem></asp:DropDownList>
                <br />
            </fieldset>
            <asp:Button ID="btnGuardar" runat="server" Text="Enviar formulario y generar ficha de pago" OnClick="btnGuardar_Click"  />
            </div>
            
         </fieldset>
        <br />
    </div>


    <div class="BK" id="idImprimeme" runat="server">
    
    <br />
    <br />
        
    <div class="popCN">
            <br />
            <br />

            <div id="divPrint" >
                <img src="../src/img/logo/upe.png" class="logo" />
                <fieldset>
                    <legend>Ficha de Pago.</legend>  
                    <i> Las Referencias son personales e intransferibles.</i><br />
                    <i> Cuota establecida en UMAS; Ultima actualizacíon de la UMA el 01/02/2022.</i><br />
                    <table>
                        <tr class="medium">
                            <td colspan="4" style="color:aliceblue; text-align:center;"> <b>FOLIO: <asp:Label ID="LbFolioImp" runat="server" />&nbsp; </b> </td>
                        </tr>
                        <tr>
                            <td><b>Convenio Bancomer-CIE:</b></td>
                            <td colspan="3">1839594</td>
                        </tr>
                        <tr>
                            <td><b>Referencia:</b></td>
                            <td colspan="3"><asp:Label ID="lbReferencia" runat="server" /></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td colspan="3"><asp:Label ID="lbMsj" runat="server" /></td>
                        </tr>
                        <tr>                            
                            <td><b>Importe total:</b></td>
                            <td colspan="3"><asp:Label ID="lbImporte" runat="server" /></td>
                        </tr>
                        <tr>
                            <td><b>Nombre del Interesado:</b></td>
                            <td colspan="3"><asp:Label ID="lbNomb" runat="server" /></td>
                        </tr>
                        <tr>
                            <td><b>Concepto de pago:</b></td>
                            <td colspan="3"><asp:Label ID="lbConcepto" runat="server" /></td>
                        </tr>
                        <tr>
                            <td><b>Pagarse antes del:</b></td>
                            <td colspan="3"><asp:Label ID="lbFecha" runat="server" /></td>
                        </tr>
                    </table>
                    <a> Sólo vas a contar con 2 días para realizar tu pago correspondiente, después de haber generado tu Referencia Bancaria, verifica la fecha límite para dicho pago (puedes regresar y generar una nueva referencia).</a>
                </fieldset>
            </div>
            <div class="center">
                <input type="button" title="Imprime tu ficha de pago" value='Imprimir' onclick='javascript:window.print()' />
                <asp:Button ID="btnX" runat="server" Text="Cerrar"  OnClick="btnX_Click"/>
            </div>
        </div>
    </div>

</asp:Content>
