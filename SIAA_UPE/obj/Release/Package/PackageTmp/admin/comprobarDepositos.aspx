<%@ Page Title="" Language="C#" MasterPageFile="~/base.Master" AutoEventWireup="true" CodeBehind="comprobarDepositos.aspx.cs" Inherits="SIAA_UPE.admin.comprobarDepositos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>SIAA | Comprobar depositos</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="Conten">          
        <h1>Consulta de Pagos</h1>
        <asp:FileUpload id="fcFile" runat="server" CssClass="txt" />
        <center>
            <asp:GridView ID="gv" runat="server">
                <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                <RowStyle BackColor="White" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#487575" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#275353" />
            </asp:GridView>
        </center>
        <asp:Button runat="server" id="btnComprobar" text="COMPROBAR" CssClass="primary" OnClick="btnComprobar_Click"  />
     </div>
    <div id="divToast" visible="false" runat="server" class="toast fadeInDown"><asp:Label ID="lbToast" runat="server" Text="Label"></asp:Label></div>
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