<%@ Page Title="" Language="C#" MasterPageFile="~/base.Master" AutoEventWireup="true" CodeBehind="actualizarUsuario.aspx.cs" Inherits="SIAA_UPE.user.updateUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
            <h1>Corrobora tus datos</h1>
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
                            <asp:TextBox ID="txtNTP" runat="server" placeholder="NÚMERO TELEFÓNICO CEL" required/>
                            <asp:TextBox ID="txtNSS" runat="server" placeholder="NÚMERO DE SEGURO SOCIAL" required/>
                            <asp:TextBox ID="txtCE" runat="server" placeholder="CORREO ELECTRONICO " required/>   
                        </th>
                        
                        <th width="50%">
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
                <legend><b style="color:black; font-size-adjust:15">DATOS DEL TUTOR</b></legend>
                <table>
                    <tr>
                        <th width="50%">
                            <asp:TextBox ID="txtNCT" runat="server" placeholder="NOMBRE" required/>
                            <asp:TextBox ID="txtAPP" runat="server" placeholder="APELLIDO PATERNO" required/>
                            <asp:TextBox ID="txtAPM" runat="server" placeholder="APELLIDO MATERNO" required/>
                            <asp:TextBox ID="txtNTPT" runat="server" placeholder="NÚMERO TELEFÓNICO " required/>     
                        </th>
                    </tr>
                </table>
            </fieldset>
            <br />
            <br />
        </div>
    </div>

</asp:Content>
