<%@ Page Title="" Language="C#" MasterPageFile="~/base.Master" AutoEventWireup="true" CodeBehind="gfpCaja.aspx.cs" Inherits="SIAA_UPE.admin.gfpCaja" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>SIAA | Ficha de Pago Caja</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div runat="server" id="divUser" >
        <div class="form">
            <asp:TextBox ID="txtMatricula" runat="server" autocomplete="off"/>
		    <label class="lbl-nombre"><span class="text-nomb">Matricula</span></label>
        </div>
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="success" OnClick="btnBuscar_Click" />
    </div>
    <div>
        <asp:Label ID="lbAlumno" runat="server" Visible="false"/><br />
    </div>
    <div runat="server" id="divMenu" visible="false" class="divMenuGrid">

        <div id="pg01" class="divMenuItem" runat="server" >
            <asp:ImageButton ID="btn01" CssClass="btnMenu" runat="server" ImageUrl="~/src/img/element/btn_gf01.png" OnClick="btn_Ficha" /><br />
            <a for="btnPagos">Inscripción Nivel Licenciatura</a>
        </div>
        <div id="pg02" class="divMenuItem" runat="server" >
            <asp:ImageButton ID="btn02" CssClass="btnMenu" runat="server" ImageUrl="~/src/img/element/btn_gf02.png" OnClick="btn_Ficha" /><br />
            <a for="btnPagos">Inscripción a Curso de Preparación TOEFL</a>
        </div>
        <div id="pg03" class="divMenuItem" runat="server" >
            <asp:ImageButton ID="btn03" CssClass="btnMenu" runat="server" ImageUrl="~/src/img/element/btn_gf03.png" OnClick="btn_Ficha" /><br />
            <a>Inscripción y Reinscripción Nivel Posgrado</a>
        </div>
        <div id="pg04" class="divMenuItem" runat="server" >
            <asp:ImageButton ID="btn04" CssClass="btnMenu" runat="server" ImageUrl="~/src/img/element/btn_gf04.png" OnClick="btn_Ficha" /><br />
            <a>Inscripción a Curso Propedéutico</a>
        </div>
        <div id="pg05" class="divMenuItem" runat="server" >
            <asp:ImageButton ID="btn05" CssClass="btnMenu" runat="server" ImageUrl="~/src/img/element/btn_gf05.png" OnClick="btn_Ficha" /><br />
            <a for="btnPagos">	Reinscripción Nivel Licenciatura</a>
        </div>
        <div id="pg06" class="divMenuItem" runat="server" >
            <asp:ImageButton ID="btn06" CssClass="btnMenu" runat="server" ImageUrl="~/src/img/element/btn_gf06.png" OnClick="btn_Ficha" /><br />
            <a>Examen de Ingreso Nivel Licenciatura</a>
        </div>
        <div id="pg07" class="divMenuItem" runat="server" >
            <asp:ImageButton ID="btn07" CssClass="btnMenu" runat="server" ImageUrl="~/src/img/element/btn_gf07.png" OnClick="btn_Ficha" /><br />
            <a>Examen de Ingreso Nivel Posgrado</a>
        </div>
        <div id="pg08" class="divMenuItem" runat="server" >
            <asp:ImageButton ID="btn08" CssClass="btnMenu" runat="server" ImageUrl="~/src/img/element/btn_gf08.png" OnClick="btn_Ficha" /><br />
            <a>Examen TOEFL</a>
        </div>
        <div id="pg09" class="divMenuItem" runat="server" >
            <asp:ImageButton ID="btn09" CssClass="btnMenu" runat="server" ImageUrl="~/src/img/element/btn_gf09.png" OnClick="btn_Ficha" /><br />
            <a for="btn09">Constancia Escolar</a>
        </div>
        <div id="pg10" class="divMenuItem" runat="server"  OnClick="btn_Ficha">
            <asp:ImageButton ID="btn10" CssClass="btnMenu" runat="server" ImageUrl="~/src/img/element/btn_gf10.png" OnClick="btn_Ficha" /><br />
            <a for="pg10">	Historial Académico</a>
        </div>
        <div id="pg11" class="divMenuItem" runat="server" >
            <asp:ImageButton ID="btn11" CssClass="btnMenu" runat="server" ImageUrl="~/src/img/element/btn_gf11.png" OnClick="btn_Ficha" /><br />
                <a for="pg11"> Certificado Parcial de Estudios</a>
        </div>
        <div id="pg12" class="divMenuItem" runat="server" >
            <asp:ImageButton ID="btn12" CssClass="btnMenu" runat="server" ImageUrl="~/src/img/element/btn_gf12.png"  OnClick="btn_Ficha"/><br />
            <a>Titulación</a>
        </div>
        <div id="pg13" class="divMenuItem" runat="server" >
            <asp:ImageButton ID="btn13" CssClass="btnMenu" runat="server" ImageUrl="~/src/img/element/btn_gf13.png" OnClick="btn_Ficha" /><br />
            <a>Protocolo de Titulación</a>
        </div>
        <div id="pg14" class="divMenuItem" runat="server" >
            <asp:ImageButton ID="btn14" CssClass="btnMenu" runat="server" ImageUrl="~/src/img/element/btn_gf14.png" OnClick="btn_Ficha" /><br />
            <a>Validación Electrónica de Título Profesional MMS</a>
        </div>
        <div id="pg15" class="divMenuItem" runat="server" >
            <asp:ImageButton ID="btn15" CssClass="btnMenu" runat="server" ImageUrl="~/src/img/element/btn_gf15.png" OnClick="btn_Ficha" /><br />
            <a>Expedición de Registro Estatal</a>
        </div>
        <div id="pg16" class="divMenuItem" runat="server" >
            <asp:ImageButton ID="btn16" CssClass="btnMenu" runat="server" ImageUrl="~/src/img/element/btn_gf16.png" OnClick="btn_Ficha" /><br />
            <a for="btnPagos">	Recursamiento Intensivo</a>
        </div>
        <div id="pg17" class="divMenuItem" runat="server" >
            <asp:ImageButton ID="btn17" CssClass="btnMenu" runat="server" ImageUrl="~/src/img/element/btn_gf17.png" OnClick="btn_Ficha" /><br />
            <a>Equivalencia por competencia</a>
        </div>
        <div id="pg18" class="divMenuItem" runat="server" >
            <asp:ImageButton ID="btn18" CssClass="btnMenu" runat="server" ImageUrl="~/src/img/element/btn_gf18.png" OnClick="btn_Ficha" /><br />
            <a>Revalidación de Estudios</a>
        </div>
        <div id="pg19" class="divMenuItem" runat="server" >
            <asp:ImageButton ID="btn19" CssClass="btnMenu" runat="server" ImageUrl="~/src/img/element/btn_gf19.png" OnClick="btn_Ficha" /><br />
            <a>Reposición de Credencial</a>
        </div>
        <div id="pg20" class="divMenuItem" runat="server" >
            <asp:ImageButton ID="btn20" CssClass="btnMenu" runat="server" ImageUrl="~/src/img/element/btn_gf20.png" OnClick="btn_Ficha" /><br />
            <a>Acreditación de Competencias</a>
        </div>
        <div id="pg21" class="divMenuItem" runat="server" >
            <asp:ImageButton ID="btn21" CssClass="btnMenu" runat="server" ImageUrl="~/src/img/element/btn_gf21.png" ImageAlign="Middle" OnClick="btn_Ficha"  /><br />
            <a for="btnPagos">Evaluación de Recuperación de Evidencias</a>
        </div>
        <div id="pg22" class="divMenuItem" runat="server" >
            <asp:ImageButton ID="btn22" CssClass="btnMenu" runat="server" ImageUrl="~/src/img/element/btn_gf22.png" OnClick="btn_Ficha" /><br />
            <a>Cursos de Educación Continua Básico</a>
        </div>
        <div id="pg23" class="divMenuItem" runat="server" >
            <asp:ImageButton ID="btn23" CssClass="btnMenu" runat="server" ImageUrl="~/src/img/element/btn_gf23.png" OnClick="btn_Ficha" /><br />
            <a>Estándar de Competencia Laboral Nivel 2</a>
        </div>
        <div id="pg24" class="divMenuItem" runat="server" >
            <asp:ImageButton ID="btn24" CssClass="btnMenu" runat="server" ImageUrl="~/src/img/element/btn_gf24.png" OnClick="btn_Ficha" /><br />
            <a>Tramite para Emisión de Certificado Est. de Competencia Nivel 2</a>
        </div>
        <div id="pg25" class="divMenuItem" runat="server" >
            <asp:ImageButton ID="btn25" CssClass="btnMenu" runat="server" ImageUrl="~/src/img/element/btn_gf25.png" OnClick="btn_Ficha" /><br />
            <a>Cuota por Pago Extemporáneo </a>
        </div>
        <div id="pg26" class="divMenuItem" runat="server">
            <asp:ImageButton ID="btn26" CssClass="btnMenu" runat="server" ImageUrl="~/src/img/element/btn_gf26.png" OnClick="btn_Ficha" /><br />
            <a>Tutoriales</a>
        </div>
    </div>
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
