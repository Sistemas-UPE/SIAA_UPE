<%@ Page Title="" Language="C#" MasterPageFile="~/base.Master" AutoEventWireup="true" CodeBehind="fichaPago.aspx.cs" Inherits="SIAA_UPE.pagosR.fichaPago1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <asp:FileUpload CssClass="txt" ID="fuDatos" runat="server" Font-Bold="True" SkinID="he" TabIndex="5" ToolTip="sd"  />
    <br />
    <asp:Label id="UploadStatusLabel" runat="server" ForeColor="White" />             
    <br />
    <asp:Button ID="btnGuardar" runat="server" Text="Enviar formulario" OnClick="btnGuardar_Click"/>
    <asp:Button ID="btnDescargas" runat="server" Text="Descargar" OnClick="btnDescargas_Click" />
</asp:Content>