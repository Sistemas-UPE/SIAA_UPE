<%@ Page Title="" Language="C#" MasterPageFile="~/base.Master" AutoEventWireup="true" CodeBehind="asignatura.aspx.cs" Inherits="SIAA_UPE.controlEscolar.Asignatura" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>SIAA | Administrar Asignaturas</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="user" runat="server">
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
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <center>

        <h1>ASIGNATURA</h1><br />
        <asp:Label ID="lbERROR" runat="server" />
        <div id="nuevo" runat="server" visible="false">
            <div class="form">
                <asp:TextBox ID="txtID" required="true" runat="server" autocomplete="off"/>
		        <label class="lbl-nombre"><span class="text-nomb">Clave de la Asignatura</span></label>
            </div>
            <div class="form">
                <asp:TextBox ID="txtnMateria" required="true" runat="server" autocomplete="off"/>
		        <label class="lbl-nombre"><span class="text-nomb">Nombre de la Asignatura</span></label>
            </div>
            <div class="form">
                <asp:TextBox ID="txtUnidades" required="true" runat="server" autocomplete="off"/>
		        <label class="lbl-nombre"><span class="text-nomb">Unidades</span></label>
            </div>
            <div class="form">
                <asp:TextBox ID="txtCuatri" required="true" runat="server" autocomplete="off"/>
		        <label class="lbl-nombre"><span class="text-nomb">Cuatrimestre</span></label>
            </div>
            <asp:DropDownList ID="ddPE" runat="server"  CssClass="txt" DataValueField="idPE" DataTextField="nomProEdu" />
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="primary" OnClick="btnGuardar_Click"  />
        </div>

        <div id="buscar" runat="server">
            <fieldset>
            <legend>Consulta</legend>
            <br />
            <div class="form">
                <asp:TextBox ID="txtBusqueda" runat="server"   autocomplete="off"/>
		        <label class="lbl-nombre"><span class="text-nomb">Consultar registros</span></label>
            </div><br />
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar"  CssClass="success" OnClick="btnBuscar_Click" Width="200px"/>
            <asp:Button ID="btnNuevo" runat="server" Text="Nuevo registro"  CssClass="warning" Width="200px" OnClick="btnNuevo_Click"/>


            <span runat="server" visible="false" style="padding:10px;" id="divGV">
                <asp:GridView ID="gvG" runat="server"  Width="90%" AutoGenerateColumns="False" onrowcommand="roud" BackColor="White" BorderColor="#336666" BorderStyle="None" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" >
                    <Columns>
                        <asp:BoundField DataField="idAsignatura" HeaderText="CLAVE" ReadOnly="True" SortExpression="idAsignatura" />
                        <asp:BoundField DataField="nomAsignatura" HeaderText="ASIGNATURA" ReadOnly="True" SortExpression="nomAsignatura" />
                        <asp:BoundField DataField="creditos" HeaderText="UNIDADES" ReadOnly="True" SortExpression="creditos" />
                        <asp:BoundField DataField="cuatrimestre" HeaderText="CUATRIMESTRE" ReadOnly="True" SortExpression="cuatrimestre" />
                        <asp:BoundField DataField="idPE" HeaderText="PLAN DE ESTUDIOS" ReadOnly="True" SortExpression="idPE" />
                        <asp:TemplateField HeaderText="EDITAR">
                            <ItemTemplate>
                                <asp:ImageButton ID="imgEditar" runat="server"  CommandName="editar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" ImageUrl="~/src/img/ico/update.png"  />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ELIMINAR">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgBorrar"  CommandName="eliminar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" ImageUrl="~/src/img/ico/del.png"  OnClientClick="javascript:return confirm('¿Esta seguro que quiere ELIMINAR este registro, podria afectar otros registros?')"/>
                            </ItemTemplate> 
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
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
    <div id="divToast" visible="false" runat="server" class="toast fadeInDown"><asp:Label ID="lbToast" runat="server" Text="Label"></asp:Label></div>
</asp:Content>
