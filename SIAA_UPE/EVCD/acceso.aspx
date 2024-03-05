<%@ Page Title="" Language="C#" MasterPageFile="~/base.Master" AutoEventWireup="true" CodeBehind="acceso.aspx.cs" Inherits="SIAA_UPE.EVCD.acceso" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>SIA | Evaluacion Docentes 2024</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="login">
        <center>
            <h2 class="active"> Evaluacion a Docentes</h2>
            <img src="../src/img/logo/upe.png" id="icon" alt="User Icon" />
                <br />
            <asp:Label ID="lbAlerta" runat="server" CssClass="red"/>
            <br />
            <div id="d2" runat="server">
                <asp:DropDownList ID="ddlGrupo" runat="server"   CssClass="txt" Width="90%" DataTextField="idGrupo" DataValueField="idGrupo"/>
                <br />
                <asp:Button ID="btnCEv" runat="server" Text="Comenzar Evaluación " Width="90%" CssClass="primary" OnClick="btnCEv_Click" />
            </div>        
        </center>
    </div>

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