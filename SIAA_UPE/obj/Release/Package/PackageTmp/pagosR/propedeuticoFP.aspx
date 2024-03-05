<%@ Page Title="" Language="C#" MasterPageFile="~/base.Master" AutoEventWireup="true" CodeBehind="propedeuticoFP.aspx.cs" Inherits="SIAA_UPE.pagosR.propedeuticoFP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>SIAA | Ficha de Pago Propedeutico</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
        <div class="divPop"  id="imprimir" runat="server">
        <br />
        <fieldset>
            <legend><b style="color:black; font-size-adjust:15">Módulo de inscripción a propedéutico </b><asp:Label ID="lbEnca" runat="server" ForeColor="Maroon" Font-Bold="True" /></legend> 
            <asp:RequiredFieldValidator ID="RFVuser" runat="server" ErrorMessage="Por favor, coloca tu nombre en el campo" ControlToValidate="txtNombre" ForeColor="Red"/><br />
            <asp:RequiredFieldValidator ID="RFVcurp" runat="server" ErrorMessage="Por favor, coloca curp en el campo" ControlToValidate="txtCURP" ForeColor="Red"/><br />
            
            <div id="divStep1" runat="server">
                <asp:TextBox ID="txtNombre" runat="server" placeholder="Nombre Completo"/><br />
                <asp:TextBox ID="txtCURP" runat="server" placeholder="CURP"/><br />    
                <a><asp:Label ID="lbError" runat="server" /></a><br />
                <asp:Button ID="btnValidar" runat="server" Text="VALIDAR" OnClick="btnValidar_Click" />            
            </div>
            
            <div id="divStep2" runat="server" visible="false">
                <p>Bienvenido <asp:Label ID="lbNombre" runat="server"  Font-Bold="True" ForeColor="Maroon" />, <br /> Gracias por validar tu registro al curso propedéutico, el siguiente paso será, imprimir tu ficha de pago, recuerda que solo dispones de 5 días hábiles para hacer tu deposito. <br /> Mantente atento al grupo de WhatsApp para más detalles.</p>
                <asp:DropDownList ID="ddMpago" runat="server" CssClass="txt" ><asp:ListItem>Seleccione su forma de pago</asp:ListItem><asp:ListItem>Medios electronicos (Transferencia,Pago en linea, Practi-caja)</asp:ListItem><asp:ListItem>Pago en ventanilla bancaria</asp:ListItem></asp:DropDownList>
                <br />
                <asp:Button ID="btn" runat="server" Text="GENERAR FICHA" OnClick="btn_Click" />
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
                    <a> Sólo vas a contar con 5 días para realizar tu pago correspondiente, después de haber generado tu Referencia Bancaria, verifica la fecha límite para dicho pago (puedes regresar y generar una nueva referencia).</a>
                </fieldset>
            </div>
            <div class="center">
                <input type="button" title="Imprime tu ficha de pago" value='Imprimir' onclick='javascript:window.print()' />
                <asp:Button ID="btnX" runat="server" Text="Cerrar"  OnClick="btnX_Click"/>
            </div>
        </div>
    </div>

</asp:Content>
