<%@ Page Title="" Language="C#" MasterPageFile="~/base.Master" AutoEventWireup="true" CodeBehind="consultaPagos.aspx.cs" Inherits="SIAA_UPE.user.consultaPagos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>SIAA | Consulta de pagos</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <center>
        <h1>Consulta el estado de tus pagos</h1>
        <br />
        <asp:Label ID="lbAlerta" runat="server"  />
        <asp:GridView ID="gvPagos" CssClass="Conten" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#336666" BorderStyle="None" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" >
            <Columns>
                <asp:BoundField DataField="folio" HeaderText="FOLIO" ReadOnly="True" SortExpression="folio" />
                <asp:BoundField DataField="tipoPago" HeaderText="CONCEPTO" ReadOnly="True" SortExpression="tipoPago" />
                <asp:BoundField DataField="fehaSolicitud" HeaderText="FECHA DE SOLICITUD" SortExpression="fehaSolicitud" />
                <asp:BoundField DataField="estatus" HeaderText="ESTATUS" SortExpression="estatus" />
                <asp:BoundField DataField="fechaConfirmacion" HeaderText="FECHA DE CONFIRMACIÓN" SortExpression="fechaConfirmacion" />
            </Columns>
            <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="White" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#487575" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#275353" />
        </asp:GridView>

    </center>
            
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="User" runat="server">
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

 

