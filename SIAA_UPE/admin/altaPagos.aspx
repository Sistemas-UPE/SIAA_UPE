<%@ Page Title="" Language="C#" MasterPageFile="~/base.Master" AutoEventWireup="true" CodeBehind="altaPagos.aspx.cs" Inherits="SIAA_UPE.admin.altaPagos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>SIAA | Comprobar pagos</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="wrapperLarge">
        <div id="formContentLarge">
            <br /><br />
            <asp:FileUpload id="FileUploadControl" runat="server" CssClass="txt" />
            <br /><br />
            <asp:Button runat="server" id="UploadButton" text="COMPROBAR" onclick="UploadButton_Click" />
            <asp:Button runat="server" id="btnGuardar" text="Guardar" OnClick="btnGuardar_Click"/>
            <br /><br />
            <asp:GridView ID="gv" runat="server">
                <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                <RowStyle BackColor="White" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#487575" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#275353" />
            </asp:GridView>
        </div>
    </div>
</asp:Content>
