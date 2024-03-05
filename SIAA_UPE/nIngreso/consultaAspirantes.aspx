<%@ Page Title="" Language="C#" MasterPageFile="~/base.Master" AutoEventWireup="true" CodeBehind="consultaAspirantes.aspx.cs" Inherits="SIAA_UPE.nIngreso.consultaAspirantes" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>SIAA | Consulta Nuevo Ingreso</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <center>
        <h1>Consulta de aspirantes al nuevo ciclo escolar</h1>
        <div style="padding:20px"  ><hr /></div>
        <asp:Label ID="lbAlerta" runat="server" CssClass="red" Visible="false" /><br />
        <a>Total de aspirantes registrados</a>
        <asp:Label ID="lbAspTotal" runat="server" CssClass="red" /><br />
        <a>Total de aspirantes validados</a>
        <asp:Label ID="lbAspPagado" runat="server" CssClass="red" />
        <div style="padding:20px"  ><hr /></div>
            
        <a>Total Ingeniería en Energía</a>
        <asp:Label ID="lbIE" runat="server" CssClass="red" /><br />
        <a>Total Ingeniería Petrolera</a>
        <asp:Label ID="lbIP" runat="server" CssClass="red" /><br />
        <a>Total Ingeniería en Seguridad para la Industria Energética</a>
        <asp:Label ID="lbISIE" runat="server" CssClass="red" /><br />
        <a>Total Ingeniería en Logística y Transporte</a>
        <asp:Label ID="lbILT" runat="server" CssClass="red" />

        <div style="padding:20px"  ><hr /></div>

        <asp:GridView ID="gvPagos" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#336666" BorderStyle="None" BorderWidth="3px" CellPadding="4" GridLines="Horizontal"  onrowcommand="roud">
            <Columns>
                <asp:BoundField DataField="APaterno" HeaderText="A Paterno" ReadOnly="True" SortExpression="APaterno" />
                <asp:BoundField DataField="AMaterno" HeaderText="A Materno" ReadOnly="True" SortExpression="AMaterno" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                <asp:BoundField DataField="Curp" HeaderText="CURP" SortExpression="Curp" />
                <asp:BoundField DataField="Correo" HeaderText="Correo Electronico" SortExpression="Correo" />
                <asp:BoundField DataField="Folio" HeaderText="Folio" SortExpression="Folio" />
                <asp:BoundField DataField="Carrera" HeaderText="Carrera" SortExpression="Carrera" />
                <asp:BoundField DataField="ClvCarrera" HeaderText="Clave" SortExpression="ClvCarrera" />
                <asp:BoundField DataField="Telefono" HeaderText="Numero Telefonico" SortExpression="Telefono" />
                <asp:BoundField DataField="PagoFicha" HeaderText="Pago de Ficha" SortExpression="PagoFicha" />
                <asp:BoundField DataField="PagoPropedeutico" HeaderText="Pago de Propedeutico" SortExpression="PagoPropedeutico" />
                <asp:TemplateField HeaderText="Detalles" ShowHeader="False" FooterStyle-Wrap="False" HeaderStyle-Wrap="False">
                    <ItemTemplate>
                        <asp:ImageButton runat="server" CommandName="detalles" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" ImageUrl="~/src/img/ico/history.png"></asp:ImageButton>
                        <asp:ImageButton runat="server" CommandName="aceptado" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" ImageUrl="~/src/img/ico/aceptado.png"></asp:ImageButton>
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

        <asp:DetailsView ID="dvAspirante" runat="server" Height="50px" Width="80%" AutoGenerateRows="False" >
            <Fields>
                <asp:BoundField DataField="" ReadOnly="True" HeaderText="Datos Personales" HeaderStyle-ForeColor="White" HeaderStyle-BorderColor="Black" HeaderStyle-BackColor="#336666" ItemStyle-BackColor="#336666"/>
                <asp:BoundField DataField="NCompleto" HeaderText="Nombre" SortExpression="NCompleto" />
                <asp:BoundField DataField="Direccion" HeaderText="Domicilio" SortExpression="Direccion" />
                <asp:BoundField DataField="Telefono" HeaderText="Teléfono" SortExpression="Telefono" />
                <asp:BoundField DataField="Correo" HeaderText="Correo Personal" SortExpression="Correo" />
                <asp:BoundField DataField="Rfc" HeaderText="RFC" SortExpression="Rfc" />
                <asp:BoundField DataField="FechaNa" HeaderText="Fecha de nacimiento" SortExpression="FechaNa" />
                <asp:BoundField DataField="Genero" HeaderText="Sexo" SortExpression="Genero" />
                <asp:BoundField DataField="Tiposangre" HeaderText="Tipo de sangre" SortExpression="Tiposangre" />
                <asp:BoundField DataField="Curp" HeaderText="CURP" SortExpression="Curp" />
                <asp:BoundField DataField="Edad" HeaderText="Edad" SortExpression="Edad" />
                <asp:BoundField DataField="EstadoCivil" HeaderText="Estado civil" SortExpression="EstadoCivil" />
                <asp:BoundField DataField="Nhijos" HeaderText="Hijos" SortExpression="Nhijos" />
                <asp:BoundField DataField="SMedico" HeaderText="Servicio médico" SortExpression="SMedico" />
                <asp:BoundField DataField="Nseguro" HeaderText="Número de seguro" SortExpression="Nseguro" />
                <asp:BoundField DataField="Discapasidad" HeaderText="Discapacidad" SortExpression="Discapasidad" />
                <asp:BoundField DataField="Indigena" HeaderText="Procedencia Indígena" SortExpression="Indigena" />
                <asp:BoundField DataField="Url" HeaderText="Documentos cargados" SortExpression="Url" />
                <asp:BoundField DataField="" ReadOnly="True" HeaderText="Datos Académicos" HeaderStyle-ForeColor="White" HeaderStyle-BorderColor="Black" HeaderStyle-BackColor="#336666" ItemStyle-BackColor="#336666"/>
                <asp:BoundField DataField="CarreraInteres" HeaderText="Carrera" ReadOnly="True" SortExpression="CarreraInteres" />
                <asp:BoundField DataField="Bachillerato" HeaderText="Institución de procedencia" SortExpression="Bachillerato" />
                <asp:BoundField DataField="Municipio" HeaderText="Municipio de la Institución" SortExpression="Municipio" />
                <asp:BoundField DataField="FechaConclu" HeaderText="Fecha de Egreso" SortExpression="FechaConclu" />
                <asp:BoundField DataField="Documento" HeaderText="Documento Obtnido" SortExpression="Documento" />
                <asp:BoundField DataField="Beca" HeaderText="Beca" SortExpression="Beca" />
                <asp:BoundField DataField="" ReadOnly="True" HeaderText="Datos del tutor" HeaderStyle-ForeColor="White" HeaderStyle-BorderColor="Black" HeaderStyle-BackColor="#336666" ItemStyle-BackColor="#336666"/>
                <asp:BoundField DataField="NCompletoTutor" HeaderText="Nombre" SortExpression="NCompletoTutor" />
                <asp:BoundField DataField="Parentesco" HeaderText="Parentesco" SortExpression="Ocupacion" />
                <asp:BoundField DataField="Ocupacion" HeaderText="Ocupación" SortExpression="Ocupacion" />
                <asp:BoundField DataField="DireccionTutor" HeaderText="Dirección" SortExpression="DireccionTutor" />
                <asp:BoundField DataField="Telefonotutor" HeaderText="Teléfono" SortExpression="Telefonotutor" />
            </Fields>
        </asp:DetailsView>
        <br />
        <asp:Button ID="btnTodos" runat="server" Text="Todos los registros" Visible="false" CssClass="primary" OnClick="btnTodos_Click" />
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