<%@ Page Title="" Language="C#" MasterPageFile="~/base.Master" AutoEventWireup="true" CodeBehind="convocatoria.aspx.cs" Inherits="SIAA_UPE.nIngreso.convocatoria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>SIAA | Convocatoria Nuevo Ingreso</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <center>
            
            <h1>Apertura de convocatorias</h1>


            <div id="update" runat="server" >
                <fieldset>
                <legend><b style="color:black; font-size-adjust:15">Actualizacion de fechas</b></legend>
                <table>
                    <tr>

                        <th width="50%">
                            <a>Dia y Mes en que comenzara la convocatoria</a><br />
                            <asp:TextBox ID="txtDiaIn" runat="server" placeholder="Dia"   type="number" CssClass="txt"/>
                            <asp:TextBox ID="txtMesIn" runat="server" placeholder="Mes"  maxlength="12"  type="number" CssClass="txt"/>
                        </th>
                        <th width="50%">
                            <a>Dia y Mes en que finalizara la convocatoria</a><br />
                            <asp:TextBox ID="txtDiaFi" runat="server" placeholder="Dia" type="number" CssClass="txt"/>
                            <asp:TextBox ID="txtMesFi" runat="server" placeholder="Mes"  maxlength="12"  type="number" CssClass="txt"/>
                        </th>                            
                    </tr>
                </table>
                <br />
                <asp:Button ID="btnUpdate" runat="server" CssClass="primary" Text="Guardar" OnClick="btnUpdate_Click" />
                <br />
                </fieldset>

                <div style="padding:20px"  ><hr /></div>
            </div>


            <asp:GridView ID="gvConbocatorias" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#336666" BorderStyle="None" BorderWidth="3px" CellPadding="4" GridLines="Horizontal"  onrowcommand="roud" >
                <Columns>
                    <asp:BoundField DataField="idConvocatoria" HeaderText="ID" ReadOnly="True" SortExpression="idConvocatoria" />
                    <asp:BoundField DataField="ciclo" HeaderText="CICLO" ReadOnly="True" SortExpression="ciclo" />
                    <asp:BoundField DataField="diaInicio" HeaderText="(D) INICIO DE" SortExpression="diaInicio" >
                    <ItemStyle BackColor="#CCFF99" BorderColor="#33CC33" BorderStyle="Double" Font-Bold="True" ForeColor="#990033" HorizontalAlign="Left" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="mesInicio" HeaderText="CONVOCATORIA (M)" SortExpression="mesInicio" >
                    <ItemStyle BackColor="#CCFF99" BorderColor="#33CC33" BorderStyle="Double" Font-Bold="True" ForeColor="#990033" HorizontalAlign="Left" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="diaFin" HeaderText="(D) FIN DE" SortExpression="diaFin" >
                        <ItemStyle BackColor="#ff9999" BorderColor="#ff3300" BorderStyle="Double" Font-Bold="True" ForeColor="#990033" HorizontalAlign="Left" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="mesFin" HeaderText="CONVOCATORIA (M)" SortExpression="mesFin" >
                        <ItemStyle BackColor="#ff9999" BorderColor="#ff3300" BorderStyle="Double" Font-Bold="True" ForeColor="#990033" HorizontalAlign="Left" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ronda" HeaderText="RONDA" SortExpression="ronda" />
                    <asp:TemplateField HeaderText="MODIFICAR" ShowHeader="False" FooterStyle-Wrap="False" HeaderStyle-Wrap="False">
                        <ItemTemplate>
                            <asp:ImageButton runat="server" CommandName="actualizar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" ImageUrl="~/src/img/ico/update.png"/>
                            <asp:ImageButton runat="server" CommandName="eliminar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" ImageUrl="~/src/img/ico/del.png" OnClientClick="javascript:return confirm('¿Esta seguro que quiere ELIMINAR este registro, podria afectar otros registros?')"/>

                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EditRowStyle   />
                <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White"   />
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