<%@ Page Title="" Language="C#" MasterPageFile="~/base.Master" AutoEventWireup="true" CodeBehind="cPNI.aspx.cs" Inherits="SIAA_UPE.admin.cPNI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>SIAA | Consulta Depositos</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <center>
        <h1>Consulta alumnos que han pagado</h1>
        <asp:DropDownList ID="ddFiltro" runat="server"  AutoPostBack="true" CssClass="txt"  DataValueField="idTipoPago" DataTextField="concepto" OnSelectedIndexChanged="ddFiltro_SelectedIndexChanged"/>
        <asp:DropDownList ID="ddCarrera" runat="server" AutoPostBack="true" CssClass="txt" DataValueField="idPE" DataTextField="nomProEdu" Visible="false" OnSelectedIndexChanged="ddCarrera_SelectedIndexChanged" />
        <asp:DropDownList ID="ddGrupo" runat="server" AutoPostBack="true" CssClass="txt" DataValueField="idGrupo" DataTextField="idGrupo" Visible="false" OnSelectedIndexChanged="ddGrupo_SelectedIndexChanged">
        <asp:ListItem>Generación</asp:ListItem>
        <asp:ListItem>2016</asp:ListItem>
        <asp:ListItem>2017</asp:ListItem>
        <asp:ListItem>2018</asp:ListItem>
        <asp:ListItem>2019</asp:ListItem>
        <asp:ListItem>2020</asp:ListItem>
        <asp:ListItem>2021</asp:ListItem>
        <asp:ListItem>2022</asp:ListItem>
        </asp:DropDownList>

        <asp:Label ID="nAlu" runat="server" Visible="false"/>
        <asp:GridView ID="gv" runat="server" BackColor="White" BorderColor="#336666" BorderStyle="None" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" >
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