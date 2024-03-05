<%@ Page Title="" Language="C#" MasterPageFile="~/base.Master" AutoEventWireup="true" CodeBehind="conceptosPagos.aspx.cs" Inherits="SIAA_UPE.admin.conceptosPagos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>SIAA | Conceptos pagos</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <center>
    <asp:Label ID="lbFolio" runat="server" Visible="false"/>
    <h1>Tabulador de costos</h1>
    <div id="divEditar" runat="server" visible="false">              
        <div class="Conten">
            <span class="form">
                <asp:TextBox ID="lbConcepto" runat="server" required="true" autocomplete="off"/>
		        <label class="lbl-nombre"><span class="text-nomb">Concepto</span></label>
            </span>
            <span class="form">
                <asp:TextBox ID="txtCosto" runat="server" required="true" autocomplete="off"/>
		        <label class="lbl-nombre"><span class="text-nomb">Costo</span></label>
            </span>
            <span class="form">
                <asp:TextBox ID="txtVigenciaIn" TextMode="Date"  runat="server" required="true" autocomplete="off"/>
		        <label class="lbl-nombre"><span class="text-nomb">Vigencia Inicio</span></label>
            </span>
            <span class="form">
                <asp:TextBox ID="txtVigenciaFin" TextMode="Date"  runat="server" required="true" autocomplete="off"/>
		        <label class="lbl-nombre"><span class="text-nomb">Vigencia Final</span></label>
            </span>

            <div><asp:CheckBox ID="cbRecargo" runat="server" Text="Recargo" /></div>
            <asp:Button ID="btnGuardar" runat="server" Text="Terminar edicion" CssClass="primary" OnClick="btnGuardar_Click"/>
        </div>   
    </div>
    
        <asp:GridView ID="gvPagos" runat="server" CssClass="Conten" AutoGenerateColumns="False" onrowcommand="roud" BackColor="White" BorderColor="#336666" BorderStyle="None" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" >
            <Columns>
                <asp:BoundField DataField="idTipoPago" HeaderText="ID" ReadOnly="True" SortExpression="idTipoPago" />
                <asp:BoundField DataField="concepto" HeaderText="CONCEPTO" ReadOnly="True" SortExpression="concepto" />
                <asp:BoundField DataField="costo" HeaderText="COSTO" SortExpression="costo" />
                <asp:BoundField DataField="vigenciaInicio" HeaderText="VIGENCIA INICIO" SortExpression="vigenciaInicio" />
                <asp:BoundField DataField="vigenciaFinal" HeaderText="VIGENCIA FINAL" SortExpression="vigenciaFinal" />
                <asp:BoundField DataField="recargos" HeaderText="RECARGO" SortExpression="recargos" />
                <asp:TemplateField HeaderText="ACTUALIZAR" ShowHeader="False" FooterStyle-Wrap="False" HeaderStyle-Wrap="False">
                    <ItemTemplate>
                        <asp:ImageButton runat="server" CommandName="editar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" ImageUrl="~/src/img/ico/update.png"></asp:ImageButton>
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