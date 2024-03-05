<%@ Page Title="mU" Language="C#" MasterPageFile="~/base.master" AutoEventWireup="true" CodeBehind="recursamientos.aspx.cs" Inherits="SIAA_UPE.contolEscolar.modificarUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <title>SIAA | Modificar Usuario</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <center>
        <h1>Asignar recursamiento a alumno</h1><br />
        <asp:Label ID="lbDtl" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="Maroon"/><br />             

        <div class="txt" runat="server" id="divSerch">
            <div class="form">
                <asp:TextBox ID="txtMatricula" required="true" runat="server" autocomplete="off"/>
		        <label class="lbl-nombre"><span class="text-nomb">Buscar por Matricula</span></label>
            </div>
        </div>
        <asp:DropDownList ID="ddMaterias" runat="server"  CssClass="txt" Visible="false" DataValueField="idAsignatura" DataTextField="nomAsignatura" />

        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="success" OnClick="btnBuscar_Click" />
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