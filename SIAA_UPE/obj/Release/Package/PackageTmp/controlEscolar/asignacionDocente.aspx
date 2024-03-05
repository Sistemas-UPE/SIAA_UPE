<%@ Page Title="" Language="C#" MasterPageFile="~/base.Master" AutoEventWireup="true" CodeBehind="asignacionDocente.aspx.cs" Inherits="SIAA_UPE.EVCD.ADMIN.adminEvaluacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>SIAA | Administrar Relación Docente Asignatura</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <center>
            <h1>Relación Docente - Asignatura</h1>
        <div id="nuevo" runat="server" visible="false">
            <fieldset>
                <legend>Nuevo Registro</legend>
                <asp:Label ID="lbEstado" runat="server" ForeColor="Maroon" Font-Bold="True" /> <br />

                <asp:DropDownList ID="ddCarrera" runat="server" CssClass="txt" DataValueField="idPE" DataTextField="nomProEdu"  AutoPostBack="true" OnSelectedIndexChanged="ddCarrera_SelectedIndexChanged" />
                <asp:DropDownList CssClass="txt" ID="ddCua" runat="server" DataTextField="idGrupo" DataValueField="idGrupo" AutoPostBack="True" />
                <asp:DropDownList CssClass="txt" ID="ddAsignatura" runat="server" DataTextField="nomAsignatura" DataValueField="idAsignatura" AutoPostBack="True" />
                <asp:DropDownList CssClass="txt" ID="ddDocente" runat="server" DataTextField="NDocente" DataValueField="idDocente" AutoPostBack="True"/>
                  
                <asp:Label ID="lbErrores" runat="server" CssClass="red"/><br />
                <br />
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar"  CssClass="primary" OnClick="btnGuardar_Click" /><br />
            
            </fieldset>
        </div>
        <div id="buscar" runat="server">
            <fieldset>
                <legend>Consulta</legend>
                        <div class="form">
                            <asp:TextBox ID="txtBusqueda" runat="server" required="true" autocomplete="off"/>
		                    <label class="lbl-nombre"><span class="text-nomb">Consultar registros</span></label>
                        </div>
                        <asp:Button ID="btnBuscar" runat="server" Text="Buscar"  CssClass="success" OnClick="btnBuscar_Click" Width="200px"/>
                        <asp:Button ID="btnNuevo" runat="server" Text="Nuevo registro"  CssClass="warning" Width="200px" OnClick="btnNuevo_Click"/><br />
                <asp:Label ID="lbERROR" runat="server" ForeColor="Maroon" Font-Bold="True" /> <br />
                <span runat="server" visible="false"  id="divGV">
                    <asp:GridView ID="gvAE" runat="server" Width="90%" AutoGenerateColumns="False" onrowcommand="roud" BackColor="White" BorderColor="#336666" BorderStyle="None" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" >
                            <Columns>
                            <asp:BoundField DataField="idDtlAD" HeaderText="FOLIO" SortExpression="idDtlAD" />
                            <asp:BoundField DataField="NDocente" HeaderText="DOCENTE" SortExpression="NDocente" />
                            <asp:BoundField DataField="nAsignatura" HeaderText="ASIGNATURA" SortExpression="NAsignatura" />
                            <asp:BoundField DataField="idGrupo" HeaderText="GRUPO" ReadOnly="True" SortExpression="idGrupo" />
                            <asp:TemplateField HeaderText="EDITAR" ShowHeader="False" FooterStyle-Wrap="False" HeaderStyle-Wrap="False">
                                <ItemTemplate>
                                    <asp:ImageButton runat="server" CommandName="editar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" ImageUrl="~/src/img/ico/update.png"></asp:ImageButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ELIMINAR">
                                <ItemTemplate>
                                    <asp:ImageButton runat="server" CommandName="eliminar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"  ImageUrl="~/src/img/ico/del.png" OnClientClick="javascript:return confirm('¿Esta seguro que quiere ELIMINAR este registro, podria afectar otros registros?')"></asp:ImageButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            </Columns>
                            <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                            <RowStyle BackColor="White" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F7F7F7" />
                            <SortedAscendingHeaderStyle BackColor="#487575" />
                            <SortedDescendingCellStyle BackColor="#E5E5E5" />
                            <SortedDescendingHeaderStyle BackColor="#275353" />
                    </asp:GridView>
                </span>

            </fieldset>
        </div>
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