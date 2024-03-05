<%@ Page Title="" Language="C#" MasterPageFile="~/base.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="SIAA_UPE.user.home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><asp:Label ID="lbTipoUsuario" runat="server" /></title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
      <div class="wrapper fadeInDown">
        <div id="formContentLarge">
            <ul>
              <li><a href="#home">Home</a></li>
              <li style="float:right" class="dropdown">
                  <asp:Label ID="lbNombre" runat="server" class="dropbtn"/>
                <div class="dropdown-content">
                  <a href="../login.aspx">Salir</a>
                </div>
              </li>
            </ul>
            
            <h1>Bienvenido a tu panel SIAA</h1>

            <fieldset>
        <!--Etiqueta legend-->
                <legend>Menu de opciones</legend>
                <table>
                    <tr>
                        <td class="divMenuItem">
                            <div >
                                <asp:ImageButton ID="btnPagos" CssClass="btnMenu" runat="server" ImageUrl="~/src/img/element/ud_card.svg" OnClick="btnPagos_Click" ImageAlign="Middle" /><br />
                                <a for="btnPagos">Generar ficha de Pago</a>
                            </div>
                        </td>
                        <%--<td class="divMenu">
                            <div >
                                <asp:ImageButton ID="btnOtrosPagos" CssClass="btnMenu" runat="server" ImageUrl="~/src/img/element/undraw_credit_card_re_blml.svg" OnClick="btnOtrosPagos_Click"/><br />
                                <a>Otros Pagos</a>
                            </div>
                        </td>--%>
                        <td class="divMenuItem">
                            <div>
                                <asp:ImageButton ID="btnConsulta" CssClass="btnMenu" runat="server" ImageUrl="~/src/img/element/undraw_search_re_x5gq.svg" OnClick="btnConsulta_Click"/><br />
                                <a>Consultar Pagos</a>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="divMenuItem">
                            <div>
                                <asp:ImageButton ID="btnEVCD" CssClass="btnMenu" runat="server" ImageUrl="~/src/img/element/undraw_online_resume_re_ru7s.svg" OnClick="btnEVCD_Click"/><br />
                                <a>Evaluacion Docente</a>
                            </div>
                        </td>
                    </tr>
                </table>
            </fieldset>
            <br />
            </div>
          </div>
</asp:Content>
