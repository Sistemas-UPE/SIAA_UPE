<%@ Page Title="" Language="C#" MasterPageFile="~/base.Master" AutoEventWireup="true" CodeBehind="consultaRecursamiento.aspx.cs" Inherits="SIAA_UPE.controlEscolar.consultaRecursamiento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID = "body" runat="server">
    <center ">
        <h1>Administrar recursamientos</h1>

        <asp:GridView ID="gv" runat="server" BackColor="White" onrowcommand="roud" BorderColor="#336666" BorderStyle="None" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" AutoGenerateColumns="False">
           <Columns>
                <asp:BoundField DataField="idRecursamiento" HeaderText="FOLIO" ReadOnly="True" SortExpression="idRecursamiento" />
                <asp:BoundField DataField="Matricula" HeaderText="MATRICULA" ReadOnly="True" SortExpression="Matricula" />
                <asp:BoundField DataField="NAlumno" HeaderText="ESTUDIANTE" ReadOnly="True" SortExpression="NAlumno" />
                <asp:BoundField DataField="Asignatura" HeaderText="ASIGNATURA" ReadOnly="True" SortExpression="Asignatura" />
                <asp:BoundField DataField="CuotaL" HeaderText="CUOTA" SortExpression="CuotaL" />
                <asp:TemplateField HeaderText="Validar Recurse">
                <ItemTemplate>
                    <asp:ImageButton runat="server" CommandName="aplicado" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"  ImageUrl="~/src/img/ico/aceptado.png"></asp:ImageButton>
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
    <div id="divToast" visible="false" runat="server" class="toast fadeInDown"><asp:Label ID="lbToast" runat="server" Text="Label"></asp:Label></div>
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