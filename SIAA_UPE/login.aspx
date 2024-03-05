<%@ Page Title="" Language="C#" MasterPageFile="~/base.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="SIAA_UPE.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>SIAA | Inicio de Sesión</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="login">
        <h1>Sistema de Integración Académico y Administrativo de la UPE</h1><br />
        <img src="src/img/logo/upe.png" alt="User Icon" /><br />
        <span class="form">
            <asp:TextBox ID="txtUser" runat="server" required="true" autocomplete="off"/>
		    <label class="lbl-nombre"><span class="text-nomb">Usuario</span></label>
        </span>
        <span class="form">
            <asp:TextBox ID="txtpass" runat="server" required="true" autocomplete="off" TextMode="Password"/>
		    <label class="lbl-nombre"><span class="text-nomb">Contraseña</span></label>
        </span>
        <br />
        <asp:Button ID="btnLogin" runat="server" Text="Acceder" CssClass="primary" OnClick="btnLogin_Click"/>

    </div>
    <div id="divToast" visible="false" runat="server" class="toast fadeInDown"><asp:Label ID="lbToast" runat="server" Text="Label"></asp:Label></div>
</asp:Content>
