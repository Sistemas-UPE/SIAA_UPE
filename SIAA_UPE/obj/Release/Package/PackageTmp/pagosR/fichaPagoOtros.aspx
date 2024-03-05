<%@ Page Title="" Language="C#" MasterPageFile="~/base.Master" AutoEventWireup="true" CodeBehind="fichaPagoOtros.aspx.cs" Inherits="SIAA_UPE.pagosR.fichaPagoOtros" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>SIAA | Ficha de Pago</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="divPop" >
        <br />
        <asp:TextBox ID="txtNombre" runat="server" placeholder="Nombre Completo"/>
        <asp:TextBox ID="txt" runat="server" placeholder="Matricula | Folio"/>
        <asp:DropDownList ID="ddCarrera" runat="server" CssClass="txt" DataValueField="idPE" DataTextField="nomProEdu" />
        <asp:DropDownList ID="ddTPago" runat="server" AutoPostBack="true" CssClass="txt" DataValueField="idTipoPago" DataTextField="detalle" OnSelectedIndexChanged="ddTPago_SelectedIndexChanged" />
        <div id="divMas" runat="server" visible="false">
            <asp:TextBox ID="txtMas" runat="server"  placeholder="Numero de pagos a realizar" />
        </div>
        <asp:DropDownList ID="ddMpago" runat="server" CssClass="txt" ><asp:ListItem>Seleccione su forma de pago</asp:ListItem><asp:ListItem>Medios electronicos (Transferencia,Pago en linea, Practi-caja)</asp:ListItem><asp:ListItem>Pago en ventanilla bancaria</asp:ListItem></asp:DropDownList>
        <br />
        <a><asp:Label ID="lbError" runat="server" /></a><br />
        <asp:Button ID="btn" runat="server" Text="Generar ficha" OnClick="btn_Click" />
    </div>

    <div class="BK" id="idImprimeme" runat="server">

        <div class="popCN">
            <div id="divPrint" >
                <img src="../src/img/logo/upe.png" class="logo" />
                <fieldset>
                    <legend>Ficha de Pago.</legend>  
                    <i> Las Referencias son personales e intransferibles.</i><br />
                    <i> Cuota establecida en UMAS; Ultima actualizacíon de la UMA el 01/02/2021.</i><br />
                    <table>
                        <tr class="medium">
                            <td colspan="4">  &nbsp; </td>
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
                            <td colspan="3"><asp:Label ID="lbNombre" runat="server" /></td>
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
                <asp:Button ID="btnImprimir" runat="server" Text="Imprimir" />
                <asp:Button ID="btnX" runat="server" Text="Cerrar"  OnClick="btnX_Click" />
            </div>
        </div>
    </div>

   

</asp:Content>
