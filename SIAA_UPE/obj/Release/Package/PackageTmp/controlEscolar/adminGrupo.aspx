<%@ Page Title="" Language="C#" MasterPageFile="~/base.Master" AutoEventWireup="true" CodeBehind="adminGrupo.aspx.cs" Inherits="SIAA_UPE.EVCD.ADMIN.adminGrupo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>SIAA | Administrar Grupos</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <center>
        <h1>Administrar - Grupo</h1>
        <div id="nuevo" runat="server" visible="false">
            <fieldset>
                <legend>Nuevo Registro</legend>
                <asp:Label ID="lbEstado" runat="server" ForeColor="Maroon" Font-Bold="True" /> <br />

            <asp:DropDownList ID="ddCarrera" runat="server" CssClass="txt" DataValueField="idPE" DataTextField="nomProEdu" />
            <div class="form">
                <asp:TextBox ID="txtID" runat="server" required="true" autocomplete="off"/>
		        <label class="lbl-nombre"><span class="text-nomb">clave del grupo</span></label>
            </div>
            <div class="form">
                <asp:TextBox ID="txtnNAlumnos" runat="server" required="true" type="number" autocomplete="off"/>
		        <label class="lbl-nombre"><span class="text-nomb">Numero total de alumnos</span></label>
            </div><br />
			<label>Estatus:</label>
            <asp:CheckBox ID="cbActivo" runat="server" /><br /><br />

                  
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="primary" OnClick="btnGuardar_Click" /><br />
            <asp:Label ID="lbErrores" runat="server" ForeColor="Maroon" Font-Bold="True" /> 
            
            </fieldset>
        </div>
        <div id="buscar" runat="server">
            <fieldset>
            <legend>Consulta</legend>
            <br />
            <div class="form">
                <asp:TextBox ID="txtBusqueda" runat="server" required="true"  autocomplete="off"/>
		        <label class="lbl-nombre"><span class="text-nomb">Consultar registros</span></label>
            </div><br />
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar"  CssClass="success" OnClick="btnBuscar_Click" Width="200px"/>
            <asp:Button ID="btnNuevo" runat="server" Text="Nuevo registro"  CssClass="warning" Width="200px" OnClick="btnNuevo_Click"/>
            <asp:Button ID="btnDesactivar" Visible ="false" runat="server" CssClass="danger" Text="Desactivar todos" Width="200px" OnClick="btnDesactivar_Click" /><br />

            <asp:Label ID="lbERROR" runat="server" CssClass="red" />

            <span runat="server" visible="false" style="padding:10px;" id="divGV">
                <asp:GridView ID="gvG" runat="server"  Width="90%" AutoGenerateColumns="False" onrowcommand="roud" BackColor="White" BorderColor="#336666" BorderStyle="None" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" >
                    <Columns>
                    <asp:BoundField DataField="idGrupo" HeaderText="GRUPO" ReadOnly="True" SortExpression="idGrupo" />
                    <asp:BoundField DataField="periodo" HeaderText="CUATRIMESTRE" SortExpression="periodo" />
                    <asp:BoundField DataField="estado" HeaderText="ESTADO" SortExpression="estado" />
                    <asp:BoundField DataField="numAlumnos" HeaderText="INTEGRANTES" SortExpression="numAlumnos" />
                    <asp:TemplateField HeaderText="EDITAR" ShowHeader="False" FooterStyle-Wrap="False" HeaderStyle-Wrap="False">
                        <ItemTemplate>
                            <asp:ImageButton runat="server" CommandName="editar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" ImageUrl="~/src/img/ico/update.png" ></asp:ImageButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ELIMINAR">
                        <ItemTemplate>
                            <asp:ImageButton runat="server" CommandName="eliminar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"  ImageUrl="~/src/img/ico/del.png" OnClientClick="javascript:return confirm('¿Esta seguro que quiere ELIMINAR este registro, podria afectar otros registros?')"></asp:ImageButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    </Columns>
                    <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                    <RowStyle BackColor="White" ForeColor="#333333" HorizontalAlign="Center" VerticalAlign="Middle" />
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