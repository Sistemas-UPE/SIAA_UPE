<%@ Page Title="" Language="C#" MasterPageFile="~/base.Master" AutoEventWireup="true" CodeBehind="tiket.aspx.cs" Inherits="SIAA_UPE.admin.gFPago" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>SIAA | Tiket</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <div class="tiket">
        <fieldset>
                    <i>Estas a punto de generar una ficha de con los siguientes conceptos: </i><br />
                    <br />
                        <asp:TextBox ID="txtMatricula" runat="server" placeholder="Matricula" />
                    <br />
                    <table>
                        <tr class="medium">
                            <td colspan="2">  &nbsp; </td>
                        </tr>
                        <tr>
                            <td><b>Concepto :</b></td>
                            <td><asp:Label ID="lbConceptoR" runat="server" /></td>
                        </tr>
                        <tr>
                            <td><b>Método de pago (Se cobrará una comisión):</b></td>
                            <td><asp:RadioButtonList ID="rbPago" runat="server" >
                                <asp:ListItem id="op1"  Value="vtn"/>
                                <asp:ListItem id="op2" Value="ptc"/>
                            </asp:RadioButtonList>
                        </tr>
                        <tr>
                            <td><b><asp:Label ID="lbT" runat="server" >Importe total:</asp:Label></b></td>
                            <td ><asp:Label ID="lbTotalR" runat="server" /></td>
                        </tr>
                        <tr>
                            <td><b>Pagarse antes del:</b></td>
                            <td><asp:Label ID="lbFechaR" runat="server" /></td>
                        </tr>
                    </table>
                </fieldset>
    </div>
    <button onclick="printAndClose()">Imprimir y cerrar ventana</button>

<script>
function printAndClose() {
  window.print();
  window.onfocus = function () {
    setTimeout(function () {
      window.close();
    }, 500);
  };
}
</script>
    <div id="divTiket" visible="false" runat="server" >
        <br />
        <fieldset class="tiket">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/src/img/tiket.png"  Width="90%"/>
            <legend><asp:Label ID="lbCF" runat="server" /></legend>
                <p>Ya realizaste tu registro para la solicitud de ficha, mismos que serán revisados y validados, por favor, vuelve más tarde para revisar tu estatus.</p>
                    <table>
                        <tr class="medium"><td colspan="4">&nbsp;</td>
                        </tr>
                        <tr>
                            <td><b>Convenio Bancomer-CIE:</b></td>
                            <td>1839594</td>
                        </tr>
                        <tr>
                            <td><b>Referencia:</b></td>
                            <td><asp:Label ID="lbReferenciaAspirante" runat="server" /></td>
                        </tr>
                       
                        <tr>
                            <td><b>Importe total:</b></td>
                            <td><asp:Label ID="lbImporteAspirante" runat="server" /></td>
                        </tr>
                        <tr>
                            <td><b>Nombre del Interesado:</b></td>
                            <td><asp:Label ID="lbNombreAspirante" runat="server" /></td>
                        </tr>
                        <tr>
                            <td><b><asp:Label ID="lbLeyerCP" runat="server" /></b></td>
                            <td><asp:Label ID="lbConceptoV" runat="server" /></td>
                        </tr>
                        <tr>
                            <td><b>Estatus:</b></td>
                            <td><asp:Label ID="lbEstado" runat="server" CssClass="red"/></td>
                        </tr>
                    </table>

                    <br />
                    <input id="btnImp" type="button" title="Imprime tu ficha de pago" value='Imprimir' onclick='javascript:window.print()' />

         </fieldset>
        <br />
    </div>
</asp:Content>
