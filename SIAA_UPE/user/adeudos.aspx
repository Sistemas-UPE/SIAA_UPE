<%@ Page Title="" Language="C#" MasterPageFile="~/base.Master" AutoEventWireup="true" CodeBehind="adeudos.aspx.cs" Inherits="SIAA_UPE.user.adeudos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>SIAA | Adeudos</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="user" runat="server">
    <div>
        <a href="../home.aspx">Menú</a>
        <div class="dropdown">
            <asp:Label ID="lbUserName" runat="server"/>
            <div class="dropdown-content">
                <a href="../login.aspx">Salir</a>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
        <h1>Adeudos registrados</h1>
    <span runat="server"  style="padding:10px;" id="divGV">
        <asp:GridView ID="gvG" runat="server"  Width="90%" AutoGenerateColumns="False" onrowcommand="roud" BackColor="White" BorderColor="#336666" BorderStyle="None" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" >
            <Columns>
            <asp:BoundField DataField="idRecursamiento" HeaderText="FOLIO" ReadOnly="True" SortExpression="idRecursamiento" />
            <asp:BoundField DataField="Asignatura" HeaderText="ASIGNATURA" ReadOnly="True" SortExpression="Asignatura" />
            <asp:BoundField DataField="CuotaL" HeaderText="CUOTA" ReadOnly="True" SortExpression="CuotaL" />
            <asp:BoundField DataField="EstatusL" HeaderText="ESTATUS" ReadOnly="True" SortExpression="EstatusL" />
            <asp:TemplateField HeaderText="Generar ficha">
                <ItemTemplate>
                    <asp:ImageButton runat="server" CommandName="recurse" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"  ImageUrl="~/src/img/ico/recurse.png"></asp:ImageButton>
                </ItemTemplate>
            </asp:TemplateField>
            </Columns>
            <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
            <RowStyle BackColor="White" ForeColor="#333333" HorizontalAlign="Center" VerticalAlign="Middle" />
            <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#487575" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#275353" />
        </asp:GridView>                
    </span>
    <div class="fichaFondo" id="ficha" runat="server"  visible ="false">
        <div class="popCN" runat="server" >
            <br />
            <br />
            <div id="divPrint">
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
                <center>
                    <button class="success" onclick="imprimirDiv('divPrint')">Imprimir</button>    
                </center>
            </div>
        </div>
   </div>
</asp:Content>
