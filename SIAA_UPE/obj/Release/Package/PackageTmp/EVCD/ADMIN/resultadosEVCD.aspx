<%@ Page Title="" Language="C#" MasterPageFile="~/base.Master" AutoEventWireup="true" CodeBehind="resultadosEVCD.aspx.cs" Inherits="SIAA_UPE.EVCD.ADMIN.resultadosEVCD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>SIAA | Resultados EVCD</title>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script>
        function imprimirDiv(nombreDiv) {
            var contenido = document.getElementById(nombreDiv).innerHTML;
            var contenidoOriginal = document.body.innerHTML;
            document.body.innerHTML = contenido;
            window.print();
            document.body.innerHTML = contenidoOriginal;
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
<div id="divImprimir">
    <center>
        <h1>Resultados: <a style="color:maroon">Evaluación Docente</a></h1>
        <br />
        <asp:DropDownList ID="ddMT" runat="server" CssClass="txt" DataTextField="nDocente" DataValueField="idDocente" AutoPostBack="True" OnSelectedIndexChanged="ddMT_SelectedIndexChanged" />
        <br /> 
        <asp:Label ID="lbProGral" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="Maroon"/><br /> <br />            
        <asp:GridView ID="gvEVCD" runat="server" Width="100%" AutoGenerateColumns="False"  BackColor="White" BorderColor="#336666" BorderStyle="None" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" >            
            <Columns>
                <asp:BoundField DataField="nDocente" HeaderText="Docente" ReadOnly="True" SortExpression="nDocente" />
                <asp:BoundField DataField="promedioED" HeaderText="Promedio" SortExpression="promedioED" />
            </Columns>
            <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="White" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#487575" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#275353" />
        </asp:GridView>     
        <div id="dvPerfil" runat="server">
            <asp:Label ID="lbCalGral" runat="server" CssClass="lbCritical" Font-Bold="True" Font-Size="XX-Large" ForeColor="Maroon"/>
            <br />
            <asp:Label ID="lbNombre" runat="server" Font-Bold="True" Font-Size="Larger"/>
            <br />
            <asp:Label ID="lbMateria" runat="server" Font-Italic="True" Font-Size="Small"/>
            <br />
        </div>  
        <div id="dvGrid" runat="server">
            <br />
            <div id="dvPre" runat="server" visible="false">
            <asp:GridView ID="gvCalificaciones" runat="server"  BackColor="White" BorderColor="#336666" BorderStyle="None" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" >            
                <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                <RowStyle BackColor="White" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#487575" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#275353" />
            </asp:GridView>     
            <br />
                <div>
                <fieldset>
                <legend><b>CUMPLIMIENTO DE LA PLANIFICACIÓN.</b></legend>  
                    <i class="fi-clipboard"> P1.	¿Cumple con todos los contenidos temáticos de la asignatura durante el cuatrimestre?</i><br />
                    <i class="fi-clipboard"> P2.	¿Promueve las actividades prácticas (laboratorio, taller, visitas de estudio), vinculándolas con la teoría analizada?</i><br />
                    <i class="fi-clipboard"> P3.	¿Asiste regularmente a clase?</i><br />
                    <i class="fi-clipboard"> P4.	¿Cumple adecuadamente su labor de asesoría/tutoría cuando tienes dificultades en la asignatura?</i>
                </fieldset>
                <fieldset>
                <legend><b>PLANIFICACIÓN DE LA ENSEÑANZA Y APRENDIZAJE.</b></legend>  
                    <i class="fi-clipboard"> P5.	¿El/la docente/ dio a conocer objetivos, actividades, contenidos, metodología, bibliografía, sistemas de evaluación, …?</i><br />
                    <i class="fi-clipboard"> P6.	¿Imparte las clases en el horario establecido?</i><br />
                    <i class="fi-clipboard"> P7.	¿Se ajusta al programa de la asignatura presentado al inicio del cuatrimestre?</i><br />
                    <i class="fi-clipboard"> P8.	¿La bibliografía y otras fuentes de información recomendadas en el programa son útiles para el aprendizaje de la asignatura?</i>
                </fieldset>
                <fieldset>
                <legend><b>METODOLOGÍA DOCENTE.</b></legend>  
                    <i class="fi-clipboard"> P9.	¿El/la docente organiza bien las actividades que se realizan en clase?</i><br />
                    <i class="fi-clipboard"> P10.	¿Utiliza diversos recursos didácticos (pizarra, medios audiovisuales, material de apoyo…) que facilitan el aprendizaje?</i><br />
                    <i class="fi-clipboard"> P11.	¿Utiliza diversas técnicas y dinámicas grupales?</i><br />
                    <i class="fi-clipboard"> P12.	¿Fomenta el trabajo individual, en equipos y grupal?</i>
                </fieldset>
                <fieldset>
                <legend><b>COMPETENCIAS DOCENTES DESARROLLADAS<br /> POR EL/LA DOCENTE.</b></legend>  
                    <i class="fi-clipboard"> P13.	¿Explica con claridad y resalta los contenidos importantes?</i><br />
                    <i class="fi-clipboard"> P14.	¿Se interesa por el grado de comprensión de sus explicaciones?</i><br />
                    <i class="fi-clipboard"> P15.	¿Expone ejemplos en los que se ponen en práctica los contenidos de la asignatura?</i><br />
                    <i class="fi-clipboard"> P16.	¿Domina el contenido de la asignatura?</i><br />
                    <i class="fi-clipboard"> P17.	¿Resuelve dudas y retroalimenta cuando es necesario?</i><br />
                    <i class="fi-clipboard"> P18.	¿Fomenta un ambiente agradable y de participación?</i><br />
                    <i class="fi-clipboard"> P19.	¿Fomenta la participación de todos los/as estudiantes y respeta las opiniones individuales?</i><br />
                    <i class="fi-clipboard"> P20.	¿Promueve el análisis, la crítica, la reflexión, la creatividad…?</i><br />
                    <i class="fi-clipboard"> P21.	¿Motiva a los/as estudiantes para que se interesen por la asignatura?</i><br />
                    <i class="fi-clipboard"> P22.	¿Es respetuoso/a en el trato con los/as estudiantes?</i><br />
                    <i class="fi-clipboard"> P23.	¿Trata a todos los/as estudiantes sin distinción de ningún tipo?</i>
                </fieldset>
                <fieldset>
                <legend><b>EVALUACIÓN DE LOS APRENDIZAJES.<br/>SISTEMAS DE EVALUACIÓN.</b></legend>  
                    <i class="fi-clipboard"> P24.	¿El/la docente evalúa mediante diversas evidencias de aprendizaje, utilizando criterios o rúbricas de evaluación?</i><br />
                    <i class="fi-clipboard"> P25.	¿Los criterios y sistemas de evaluación establecidos se aplican adecuadamente?</i><br />
                    <i class="fi-clipboard"> P26.	¿Informa los resultados de la evaluación en cada evidencia y brinda retroalimentación?</i><br />
                    <b>RESULTADOS<br/>EFICACIA</b> <br />
                    <i class="fi-clipboard"> P27.	¿Las actividades desarrolladas (teóricas, prácticas, de trabajo individual, en grupo, …) <br />me han permitido alcanzar los resultados de aprendizaje de la asignatura?</i><br /><br />
                    <b>SATISFACCIÓN DE LOS ESTUDIANTES</b>
                    <i class="fi-clipboard"> P28.	Estoy satisfecho/a con la labor del docente.</i>
                </fieldset>
                <br />
                <fieldset>
                <legend><b>COMENTARIOS</b></legend>  
                <asp:GridView ID="gvComentario" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#ffffff" Font-Bold="True" ForeColor="White" BorderColor="White"/>
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <RowStyle ForeColor="#000066" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>
                <br />
                </fieldset>
                </div>
            </div>
        </div> 
        <button class="success" onclick="imprimirDiv('divImprimir')">Imprimir</button>
    </center>
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="User" runat="server">
    <div>
        <a href="../../home.aspx">Menú</a>
        <div class="dropdown">
            <asp:Label ID="lbUserName" runat="server"/>
            <div class="dropdown-content">
                <a href="../../login.aspx">Salir</a>
            </div>
        </div>
    </div>
</asp:Content>