<%@ Page Title="" Language="C#" MasterPageFile="~/base.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="SIAA_UPE.home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>SIAA | Menu Principal</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <center>
        <h1>Bienvenido a tu panel SIAA</h1>
        <div class="divMenuGrid">
            <div id="btnAlu01" class="divMenuItem" runat="server" visible="false">
                <asp:ImageButton ID="btnPagos" CssClass="btnMenu" runat="server" ImageUrl="~/src/img/element/btn01.png" OnClick="btn"/><br />
                <a for="btnPagos">Generar ficha de Pago</a>
            </div>           
            <div id="btnAlu02" class="divMenuItem" runat="server" visible="false">
                <asp:ImageButton ID="btnConsulta" CssClass="btnMenu" runat="server" ImageUrl="~/src/img/element/btn02.png" OnClick="btn"/><br />
                <a>Consultar Pagos</a>
            </div>
            <div id="btnAlu03" class="divMenuItem" runat="server" visible="false">
                <asp:ImageButton ID="btnEVCD" CssClass="btnMenu" runat="server" ImageUrl="~/src/img/element/btn03.png" OnClick="btn"/><br />
                <a>Evaluacion Docente</a>
            </div>
            <div id="btnAlu04" class="divMenuItem" runat="server" visible="false">
                <asp:ImageButton ID="btnRecursamiento" CssClass="btnMenu" runat="server" ImageUrl="~/src/img/element/btn17.png" OnClick="btn"/><br />
                <a>Evaluacion Docente</a>
            </div>
            <div id="btnAlu05" class="divMenuItem" runat="server" visible="false">
                <asp:ImageButton ID="btnAdeudo" CssClass="btnMenu" runat="server" ImageUrl="~/src/img/element/btn19.png" OnClick="btn"/><br />
                <a>Adeudos</a>
            </div>
            <div id="btnAdmin01" class="divMenuItem" runat="server" visible="false">
                <asp:ImageButton ID="btnAU" CssClass="btnMenu" runat="server" ImageUrl="~/src/img/element/btn04.png" OnClick="btn" /><br />
                <a for="btnPagos">Agregar Usuario</a>
            </div>
            <div id="btnAdmin02" class="divMenuItem" runat="server" visible="false">
                <asp:ImageButton ID="btnCD" CssClass="btnMenu" runat="server" ImageUrl="~/src/img/element/btn05.png" OnClick="btn" /><br />
                <a for="btnPagos">Comprobar Depositos</a>
            </div>
            <div id="btnAdmin03" class="divMenuItem" runat="server" visible="false">
                <asp:ImageButton ID="btnAP" CssClass="btnMenu" runat="server" ImageUrl="~/src/img/element/btn06.png" OnClick="btn" /><br />
                <a for="btnPagos">Administrar Pagos</a>
            </div>
            <div id="btnAdmin04" class="divMenuItem" runat="server" visible="false">
                <asp:ImageButton ID="btnAE" CssClass="btnMenu" runat="server" ImageUrl="~/src/img/element/btn07.png" OnClick="btn" /><br />
                <a for="btnPagos">Administrar EVDC</a>
            </div>
            <div id="btnAdmin05" class="divMenuItem" runat="server" visible="false">
                <asp:ImageButton ID="btnAG" CssClass="btnMenu" runat="server" ImageUrl="~/src/img/element/btn08.png" OnClick="btn" /><br />
                <a for="btnPagos">Administrar Grupos</a>
            </div>
            <div id="btnAdmin06" class="divMenuItem" runat="server" visible="false">
                <asp:ImageButton ID="btnRE" CssClass="btnMenu" runat="server" ImageUrl="~/src/img/element/btn09.png" OnClick="btn" /><br />
                <a for="btnPagos">Resultados EVDC</a>
            </div>
            <div id="btnAdmin07" class="divMenuItem" runat="server" visible="false">
                <asp:ImageButton ID="btnCP" CssClass="btnMenu" runat="server" ImageUrl="~/src/img/element/btn10.png" OnClick="btn" /><br />
                <a for="btnPagos">Consultar pagos</a>
            </div>
            <div id="btnAdmin08" class="divMenuItem" runat="server" visible="false">
                <asp:ImageButton ID="btnGP" CssClass="btnMenu" runat="server" ImageUrl="~/src/img/element/btn01.png" OnClick="btn" /><br />
                <a for="btnPagos">Generar Ficha Alumnos</a>
            </div>
            <div id="btnAdmin09" class="divMenuItem" runat="server" visible="false">
                <asp:ImageButton ID="btnCNI" CssClass="btnMenu" runat="server" ImageUrl="~/src/img/element/btn12.png" OnClick="btn" /><br />
                <a for="btnPagos">Aspirantes</a>
            </div>
            <div id="btnAdmin10" class="divMenuItem" runat="server" visible="false">
                <asp:ImageButton ID="btnREVCD" CssClass="btnMenu" runat="server" ImageUrl="~/src/img/element/btn13.png" OnClick="btn" /><br />
                <a for="btnPagos">Reiniciar EVCD</a>
            </div>
            <div id="btnCE01" class="divMenuItem"  runat="server" visible="false">
                <asp:ImageButton ID="btnEditarAlum" CssClass="btnMenu" runat="server" ImageUrl="~/src/img/element/btn15.png"  OnClick="btn"/><br />
                <a for="btnPagos"><b>Administrar Alumno</b></a>
            </div>
            <div id="btnCE02" class="divMenuItem"  runat="server" visible="false">
                <asp:ImageButton ID="btnRecursamientos" CssClass="btnMenu" runat="server" ImageUrl="~/src/img/element/btn16.png"  OnClick="btn"/><br />
                <a for="btnPagos"><b>Recursamientos</b></a>
            </div>
            <div id="btnCE03" class="divMenuItem"  runat="server" visible="false">
                <asp:ImageButton ID="btnConsultaRecursamiento" CssClass="btnMenu" runat="server" ImageUrl="~/src/img/element/btn16.1.png"  OnClick="btn"/><br />
                <a for="btnPagos"><b>Consulta Recursamientos</b></a>
            </div>
            <div id="btnCE04" class="divMenuItem"  runat="server" visible="false">
                <asp:ImageButton ID="btnAdmAsignatura" CssClass="btnMenu" runat="server" ImageUrl="~/src/img/element/btn18.png"  OnClick="btn"/><br />
                <a for="btnPagos"><b>Asignaturas</b></a>
            </div>
            <div id="btnED" class="divMenuItem"  runat="server" visible="false">
                <asp:ImageButton ID="btnEstatusEVCD" CssClass="btnMenu" runat="server" ImageUrl="~/src/img/element/btn14.png"  OnClick="btn"  OnClientClick="javascript:return confirm('¿Esta a punto de MODIFICAR EL ESTATUS para todos los alumnos de la encuesta para evaluación docente, ¿Está seguro de esto??')"/><br />
                <a for="btnPagos"><b>Estatus EVCD</b></a>
            </div>
        </div>   
            <asp:Label ID="lbError" runat="server" visible="false" Font-Bold="True" Font-Size="X-Large" ForeColor="Maroon"/><br /> <br />            

    </center>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="User" runat="server">
    <div>
        <a href="home.aspx">Menú</a>
        <div class="dropdown">
            <asp:Label ID="lbUserName" runat="server"/>
            <div class="dropdown-content">
                <a href="login.aspx">Salir</a>
            </div>
        </div>
    </div>
</asp:Content>