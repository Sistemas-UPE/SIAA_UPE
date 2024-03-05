<%@ Page Title="" Language="C#" MasterPageFile="~/base.Master" AutoEventWireup="true" CodeBehind="agregarUsuario.aspx.cs" Inherits="SIAA_UPE.admin.agregarUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>SIAA | Registro Usuario</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <div class="wrapper fadeInDown">
        <div id="formContentLarge">
            <ul>
              <li><a href="../home.aspx">Home</a></li>
              <li style="float:right" class="dropdown">
                  <asp:Label ID="lbNombreF" runat="server" class="dropbtn"/>
                <div class="dropdown-content"> 
                  <a href="../login.aspx">Salir</a>
                </div>
              </li>
            </ul>            
            <h1>Consulta el estado de tus pagos</h1>
            <br />
            <br />   
            <fieldset>

                <asp:DropDownList ID="ddRol" AutoPostBack="true" runat="server" CssClass="txt" DataValueField="idRol" DataTextField="rol" OnSelectedIndexChanged="ddRol_SelectedIndexChanged" required/>

                <div id="divPersona" runat="server" visible="false">
                <h3> Verifique si sus datos son correctos y agregue sus datos faltantes, dicha información solamente será usada para fines del mismo tramite de inscripción. </h3>
                <a><asp:Label ID="lbErrorRe" runat="server" /></a>    
                <fieldset>
                    <legend><b style="color:black; font-size-adjust:15">DATOS PERSONALES</b></legend>
                    <!---------DATOS PERSONALES ----------->

                    <table>
                        <tr>
                            <th width="50%">
                                <asp:TextBox ID="txtName" runat="server" placeholder="NOMBRE COMPLETO" required/>
                                <asp:TextBox ID="txtLName" runat="server" placeholder="APELLIDO PATERNO" required/>
                                <asp:TextBox ID="txtSName" runat="server" placeholder="APELLIDO MATERNO" required/>
                                <asp:TextBox ID="txtCURPR" runat="server" placeholder="CURP" required/><br />
                                <A>FECHA DE NACIMIENTO</A>
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
                                <asp:TextBox ID="txtNTP" runat="server" placeholder="NÚMERO TELEFÓNICO CEL" required/>
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
                                <asp:TextBox ID="txtNSS" runat="server" placeholder="NÚMERO DE SEGURO SOCIAL" required/>
                                <asp:TextBox ID="txtCE" runat="server" placeholder="CORREO ELECTRONICO " required/>
                            </th>

                        </tr>
                    </table>                
                </fieldset>
                </div>
                <div id="divEmpleado" runat="server" visible="false">
                    <fieldset>
                        <legend><b style="color:black; font-size-adjust:15">DATOS EMPLEADO</b></legend>
                        <table>

                            <tr>
                                <th width="50%">
                                    <asp:TextBox ID="txtIdEmpleado" runat="server" placeholder="ID EMPLEADO" required/>
                                    <asp:TextBox ID="txtDepartamento" runat="server" placeholder="DEPARTAMENTO" required/>
                                    <asp:DropDownList CssClass="txt" ID="ddHorario" runat="server" AutoPostBack="True" required>
                                        <asp:ListItem>Seleccione el Horario</asp:ListItem>
                                        <asp:ListItem>7:00 am | 3:00 pm</asp:ListItem>
                                        <asp:ListItem>8:00 am | 4:00 pm</asp:ListItem>
                                        <asp:ListItem>9:00 am | 5:00 pm</asp:ListItem>
                                        <asp:ListItem>10:00 am | 6:00 pm</asp:ListItem>
                                        </asp:DropDownList>                        
                                </th>
                                <th width="50%">
                                    <asp:DropDownList CssClass="txt" ID="ddGradoAcademico" runat="server" required>
                                        <asp:ListItem>Seleccione el nivel de estudio maximo</asp:ListItem>
                                        <asp:ListItem>Primaria</asp:ListItem>
                                        <asp:ListItem>Secundaria</asp:ListItem>
                                        <asp:ListItem>Preparatoria</asp:ListItem>
                                        <asp:ListItem>Licenciatura</asp:ListItem>
                                        <asp:ListItem>Maestria</asp:ListItem>
                                        <asp:ListItem>Doctorado</asp:ListItem>
                                        </asp:DropDownList>
                                    <asp:TextBox ID="txtRFC" runat="server" placeholder="RFC" required/>
                                    <asp:TextBox ID="txtNS" runat="server" placeholder="ESCUELA DE PROCEDENCIA" required/>                            
                                </th>
                            </tr>
                        </table>
                    </fieldset>
                </div>
                <div id="divAlumno" runat="server" visible="false">
                <!---------DATOS ACADEMICOS ----------->
                    <fieldset>
                        <legend><b style="color:black; font-size-adjust:15">DATOS ACADEMICOS</b></legend>
                        <table>

                            <tr>
                                <th width="50%">
                                    <A>NUEVO INGRESO</A>
                                    <asp:TextBox ID="txtID" runat="server" placeholder="MATRICULA" required/>
                                    <asp:DropDownList ID="ddCarrera" runat="server" CssClass="txt" DataValueField="idPE" DataTextField="nomProEdu" required/>
                                    <asp:DropDownList CssClass="txt" ID="ddGrupo" runat="server" required>
                                        <asp:ListItem>Seleccione el grupo</asp:ListItem>
                                        <asp:ListItem>1A</asp:ListItem>
                                        <asp:ListItem>1B</asp:ListItem>
                                    </asp:DropDownList>
                                </th>
                                <th width="50%">
                                    <A>BACHILLERATO EGRESO</A>
                                    <asp:DropDownList CssClass="txt" ID="ddInstituto" runat="server" DataTextField="NomMuni" DataValueField="idInstitucion" AutoPostBack="True" required/>                        
                                    <asp:TextBox ID="txtPROMEDIO" runat="server" placeholder="PROMEDIO FINAL DEL BACHILLERATO" required/>
                                    <A>FECHA DE EGRESO</A>
                                    <asp:TextBox ID="txtFDI"  class="txt" runat="server" TextMode="Date" required/>
                                </th>
                            </tr>
                        </table>
                    </fieldset>

                    <!---------Datos tutor----------->
                    <fieldset>
                        <legend><b style="color:black; font-size-adjust:15">DATOS DEL TUTOR</b></legend>
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
                                </th>
                                <th width="50%">
                                    <asp:TextBox ID="txtNTPT" runat="server" placeholder="NÚMERO TELEFÓNICO " required/>
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

                </div>
                <asp:Button ID="btnGuardar" runat="server" Text="Enviar formulario" Visible="false" OnClick="btnGuardar_Click"/>

             </fieldset>
            <br />
        </div>
    </div>

    <div class="BK" id="idImprimeme" runat="server">
    
    <br />
    <br />
        
    <div class="popCN">
            <br />
            <br />

            <div id="divPrint" >
                <fieldset>
                    <legend>Nuevo Usuario.</legend>  
                    
                    <table>
                        <tr class="medium">
                            <td colspan="4" style="color:aliceblue; text-align:center;"> <b>¡Registro Existoso!</b> </td>
                        </tr>
                        
                        <tr>
                            <td><b>Usuario:</b></td>
                            <td colspan="3"><asp:Label ID="lbUsuario" runat="server" /></td>
                        </tr>                       
                        <tr>
                            
                            <td><b>Contraseña:</b></td>
                            <td colspan="3"><asp:Label ID="lbPassword" runat="server" /></td>
                        </tr>
                    </table>
                    <a>Por favor, tome Captura de pantalla ó imprima esta información ya que será necesaria para el ejercicio dentro de la plataforma.</a>
                </fieldset>
            </div>
            <div class="center">
                <input type="button" title="Imprime tu ficha de pago" value='Imprimir' onclick='javascript:window.print()' />
                <asp:Button ID="btnX" runat="server" Text="Cerrar"  OnClick="btnX_Click"/>
            </div>
        </div>
    </div>

</asp:Content>
