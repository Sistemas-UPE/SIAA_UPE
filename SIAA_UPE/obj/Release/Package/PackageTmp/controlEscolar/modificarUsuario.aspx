<%@ Page Title="" Language="C#"  MasterPageFile="~/base.Master" AutoEventWireup="true" CodeBehind="modificarUsuario.aspx.cs" Inherits="SIAA_UPE.contolEscolar.grupoUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>SIAA | Grupo Usuario</title>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <center>
        <h1>Administrar alumnos</h1>
        <div class="txt" runat="server" id="divSerch">
            <div class="form">
                <asp:TextBox ID="txtMatricula" required="true" runat="server" autocomplete="off"/>
		        <label class="lbl-nombre"><span class="text-nomb">Buscar por Matricula</span></label>
            </div>
        </div>
        <div id="divEditar" runat="server" Visible="false">
            <asp:Label ID="lbDtl" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="Maroon"/><br /> <br />            
            <div class="form">
                <asp:TextBox ID="txtNombre" runat="server" autocomplete="off"/>
		        <label class="lbl-nombre"><span class="text-nomb">Nombre Completo</span></label>
            </div>            
            <div class="form">
                <asp:TextBox ID="txtAPaterno" runat="server" autocomplete="off"/>
		        <label class="lbl-nombre"><span class="text-nomb">Apellido Paterno</span></label>
            </div>              
            <div class="form">
                <asp:TextBox ID="txtAMaterno" runat="server" autocomplete="off"/>
		        <label class="lbl-nombre"><span class="text-nomb">Apellido Materno</span></label>
            </div>            
            <div class="form">
                <asp:TextBox ID="txtPass" runat="server" autocomplete="off"/>
		        <label class="lbl-nombre"><span class="text-nomb">Contraseña</span></label>
            </div>
            <asp:DropDownList ID="ddGrupo" runat="server"  CssClass="txt" DataValueField="idGrupo" DataTextField="idGrupo" />
            <asp:DropDownList ID="ddSituacion" runat="server" CssClass="txt" DataValueField="idSituacionActual" DataTextField="detalle" />
        </div>
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
