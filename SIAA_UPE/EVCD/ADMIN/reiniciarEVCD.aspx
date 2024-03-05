<%@ Page Title="" Language="C#" MasterPageFile="~/base.Master" AutoEventWireup="true" CodeBehind="reiniciarEVCD.aspx.cs" Inherits="SIAA_UPE.EVCD.ADMIN.reiniciarEVCD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>SIAA | LIMPIAR EVCD</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
     <center>
        <h1>Reiniciar evaluacion docente</h1><br />
        <asp:Label ID="lbED" runat="server" ForeColor="Maroon" Font-Bold="True" /><br />
        <asp:Label ID="lbRD" runat="server" ForeColor="Maroon" Font-Bold="True" /><br />
        <br />
        <asp:Button ID="btnDeleteR" runat="server" CssClass="danger" Width="90%" Text="Eliminar los resultados de la evaluación." OnClick="btnDeleteR_Click" OnClientClick="javascript:return confirm('¿Esta seguro que quiere ELIMINAR este registro, podria afectar otros registros?')"/><br />
        <asp:Button ID="btnDeleteD" runat="server" CssClass="danger" Width="90%" Text="Eliminar las relaciones entre docentes y asignaturas." OnClick="btnDeleteD_Click" OnClientClick="javascript:return confirm('¿Esta seguro que quiere ELIMINAR este registro, podria afectar otros registros?')"/><br />
    </center>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="User" runat="server">
    <div>
        <a href="../../home.aspx">Menú</a>
        <div class="dropdown">
            <asp:Label ID="lbUserName" runat="server"/>
            <div class="dropdown-content">
                <a href="../../login.aspx">Salir</a>
            </div>
        </div>
    </div>
</asp:Content>
