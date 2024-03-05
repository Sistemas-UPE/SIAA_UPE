<%@ Page Title="" Language="C#" MasterPageFile="~/base.Master" AutoEventWireup="true" CodeBehind="Ev01.aspx.cs" Inherits="SIAA_UPE.EVCD.Ev01" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>SIA | Evaluacion Docentes 2024</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <center>
        <br />
        <div class="dR"><asp:Label ID="lbGrupo" runat="server" class="red"></asp:Label></div>
        <br />
        <span class="txt">Por favor contesta cada una de las preguntas según consideres, siendo 5 la calificación más alta y 1 la más baja. 
            Si lo deseas, puedes dejar un comentario, solo se directo y respetuoso con tus palabras, no debe de ser mayor 200 
            caracteres.</span>
        <div class="dC">
            <asp:DropDownList CssClass="txt" ID="ddDocente" runat="server" DataTextField="NAD" DataValueField="idDtlAD" AutoPostBack="True" OnSelectedIndexChanged="ddDocente_SelectedIndexChanged"/>
            <br />
            <br />

            <asp:Label ID="lbNDocente" runat="server" CssClass="red"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="lbMateria" runat="server" CssClass="red"></asp:Label>
            <br />
            <br />
        </div>
        <div class="dTablas">
            <table>
                <tr>
                    <th colspan="7"  >PLANIFICACIÓN DE LA ENSEÑANZA Y APRENDIZAJE</th>
                </tr>
                <tr class="tiny">
                    <th>No.</th>
                    <th>Reactivo</th>
                    <th>1</th>
                    <th>2</th>
                    <th>3</th>
                    <th>4</th>
                    <th>5</th>
                </tr>
                <tr>
                    <td>1</td>
                    <td style="text-align:left">El/la docente/ dio a conocer objetivos, actividades, contenidos, metodología, bibliografía,  sistemas de evaluación,…</td>
                    <td><asp:RadioButton ID="rb011" runat="server" GroupName="p1" /></td>
                    <td><asp:RadioButton ID="rb012" runat="server" GroupName="p1" /></td>
                    <td><asp:RadioButton ID="rb013" runat="server" GroupName="p1" /></td>
                    <td><asp:RadioButton ID="rb014" runat="server" GroupName="p1" /></td>
                    <td><asp:RadioButton ID="rb015" runat="server" GroupName="p1" /></td>

                </tr>
                <tr>
                    <td>2</td>
                    <td style="text-align:left">Imparte las clases en el horario establecido.</td>
                    <td><asp:RadioButton ID="rb021" runat="server" GroupName="p2" /></td>
                    <td><asp:RadioButton ID="rb022" runat="server" GroupName="p2" /></td>
                    <td><asp:RadioButton ID="rb023" runat="server" GroupName="p2" /></td>
                    <td><asp:RadioButton ID="rb024" runat="server" GroupName="p2" /></td>
                    <td><asp:RadioButton ID="rb025" runat="server" GroupName="p2" /></td>
                </tr>
                <tr>
                    <td>3</td>
                    <td style="text-align:left">Asiste regularmente a clase.</td>
                    <td><asp:RadioButton ID="rb031" runat="server" GroupName="p3" /></td>
                    <td><asp:RadioButton ID="rb032" runat="server" GroupName="p3" /></td>
                    <td><asp:RadioButton ID="rb033" runat="server" GroupName="p3" /></td>
                    <td><asp:RadioButton ID="rb034" runat="server" GroupName="p3" /></td>
                    <td><asp:RadioButton ID="rb035" runat="server" GroupName="p3" /></td>
                </tr>
                <tr>
                    <td>4</td>
                    <td style="text-align:left">Cumple adecuadamente su labor de asesoría/tutoría cuando tienes dificultades en la asignatura.</td>
                    <td><asp:RadioButton ID="rb041" runat="server" GroupName="p4" /></td>
                    <td><asp:RadioButton ID="rb042" runat="server" GroupName="p4" /></td>
                    <td><asp:RadioButton ID="rb043" runat="server" GroupName="p4" /></td>
                    <td><asp:RadioButton ID="rb044" runat="server" GroupName="p4" /></td>
                    <td><asp:RadioButton ID="rb045" runat="server" GroupName="p4" /></td>
                </tr>
            </table>
            <br />
            <table>
                <tr>
                    <th colspan="7" >CUMPLIMIENTO DE LA PLANEIFICACIÓN</th>
                </tr>
                <tr class="yllw">
                    <th>No.</th>
                    <th>Reactivo</th>
                    <th>1</th>
                    <th>2</th>
                    <th>3</th>
                    <th>4</th>
                    <th>5</th>
                </tr>
                <tr>
                    <td>5</td>
                    <td  style="text-align:left">Cumple con todos los contenidos temáticos de la asignatura durante el cuatrimestre</td>
                    <td><asp:RadioButton ID="rb051" runat="server" GroupName="p5" /></td>
                    <td><asp:RadioButton ID="rb052" runat="server" GroupName="p5" /></td>
                    <td><asp:RadioButton ID="rb053" runat="server" GroupName="p5" /></td>
                    <td><asp:RadioButton ID="rb054" runat="server" GroupName="p5" /></td>
                    <td><asp:RadioButton ID="rb055" runat="server" GroupName="p5" /></td>
                </tr>
                <tr>
                    <td>6</td>
                    <td style="text-align:left">Promueve las actividades prácticas (laboratorio, taller, visitas de estudio), vinculándolas con la teoría analizada.</td>
                    <td><asp:RadioButton ID="rb061" runat="server" GroupName="p6" /></td>
                    <td><asp:RadioButton ID="rb062" runat="server" GroupName="p6" /></td>
                    <td><asp:RadioButton ID="rb063" runat="server" GroupName="p6" /></td>
                    <td><asp:RadioButton ID="rb064" runat="server" GroupName="p6" /></td>
                    <td><asp:RadioButton ID="rb065" runat="server" GroupName="p6" /></td>
                </tr>
                <tr>
                    <td >7</td>
                    <td  style="text-align:left">Se ajusta al programa de la asignatura presentado al inicio del cuatrimestre.</td>
                    <td><asp:RadioButton ID="rb071" runat="server" GroupName="p7" /></td>
                    <td><asp:RadioButton ID="rb072" runat="server" GroupName="p7" /></td>
                    <td><asp:RadioButton ID="rb073" runat="server" GroupName="p7" /></td>
                    <td><asp:RadioButton ID="rb074" runat="server" GroupName="p7" /></td>
                    <td><asp:RadioButton ID="rb075" runat="server" GroupName="p7" /></td>
                </tr>
                <tr>
                    <td >8</td>
                    <td style="text-align:left">La bibliografía y otras fuentes de información recomendadas en el programa son útiles para el aprendizaje de la asignatura.</td>
                    <td><asp:RadioButton ID="rb081" runat="server" GroupName="p8" /></td>
                    <td><asp:RadioButton ID="rb082" runat="server" GroupName="p8" /></td>
                    <td><asp:RadioButton ID="rb083" runat="server" GroupName="p8" /></td>
                    <td><asp:RadioButton ID="rb084" runat="server" GroupName="p8" /></td>
                    <td><asp:RadioButton ID="rb085" runat="server" GroupName="p8" /></td>
                </tr>
            </table>
            <br />
            <table>
                <tr>
                    <th colspan="7" >METODOLOGÍA DOCENTE</th>
                </tr>
                <tr class="medium">
                    <th>No.</th>
                    <th>Reactivo</th>
                    <th>1</th>
                    <th>2</th>
                    <th>3</th>
                    <th>4</th>
                    <th>5</th>
                </tr>
                <tr>
                    <td>9</td>
                    <td style="text-align:left">El/la docente organiza bien las actividades que se realizan en clase.</td>
                    <td><asp:RadioButton ID="rb091" runat="server" GroupName="p9" /></td>
                    <td><asp:RadioButton ID="rb092" runat="server" GroupName="p9" /></td>
                    <td><asp:RadioButton ID="rb093" runat="server" GroupName="p9" /></td>
                    <td><asp:RadioButton ID="rb094" runat="server" GroupName="p9" /></td>
                    <td><asp:RadioButton ID="rb095" runat="server" GroupName="p9" /></td>
                </tr>

                <tr>
                    <td>10</td>
                    <td style="text-align:left">Utiliza diversos recursos didácticos (pizarra, medios audiovisuales, material de apoyo…) que facilitan el aprendizaje.</td>
                    <td><asp:RadioButton ID="rb101" runat="server" GroupName="p10" /></td>
                    <td><asp:RadioButton ID="rb102" runat="server" GroupName="p10" /></td>
                    <td><asp:RadioButton ID="rb103" runat="server" GroupName="p10" /></td>
                    <td><asp:RadioButton ID="rb104" runat="server" GroupName="p10" /></td>
                    <td><asp:RadioButton ID="rb105" runat="server" GroupName="p10" /></td>
                </tr>
                <tr>
                    <td>11</td>
                    <td style="text-align:left">Utiliza diversas técnicas y dinámicas grupales.</td>
                    <td><asp:RadioButton ID="rb111" runat="server" GroupName="p11" /></td>
                    <td><asp:RadioButton ID="rb112" runat="server" GroupName="p11" /></td>
                    <td><asp:RadioButton ID="rb113" runat="server" GroupName="p11" /></td>
                    <td><asp:RadioButton ID="rb114" runat="server" GroupName="p11" /></td>
                    <td><asp:RadioButton ID="rb115" runat="server" GroupName="p11" /></td>
                </tr>
                <tr>
                    <td>12</td>
                    <td style="text-align:left">Fomenta el trabajo individual, en equipos y grupal.</td>
                    <td><asp:RadioButton ID="rb121" runat="server" GroupName="p12" /></td>
                    <td><asp:RadioButton ID="rb122" runat="server" GroupName="p12" /></td>
                    <td><asp:RadioButton ID="rb123" runat="server" GroupName="p12" /></td>
                    <td><asp:RadioButton ID="rb124" runat="server" GroupName="p12" /></td>
                    <td><asp:RadioButton ID="rb125" runat="server" GroupName="p12" /></td>
                </tr>
            </table>
            <br />
            <table>
                <tr>
                    <th colspan="7" >COMPETENCIAS DOCENTES DESARROLLADAS POR EL/LA DOCENTE</th>
                </tr>
                <tr class="pro">
                    <th>No.</th>
                    <th>Reactivo</th>
                    <th>1</th>
                    <th>2</th>
                    <th>3</th>
                    <th>4</th>
                    <th>5</th>
                </tr>
                <tr>
                    <td>13</td>
                    <td style="text-align:left">Explica con claridad y resalta los contenidos importantes.</td>
                    <td><asp:RadioButton ID="rb131" runat="server" GroupName="p13" /></td>
                    <td><asp:RadioButton ID="rb132" runat="server" GroupName="p13" /></td>
                    <td><asp:RadioButton ID="rb133" runat="server" GroupName="p13" /></td>
                    <td><asp:RadioButton ID="rb134" runat="server" GroupName="p13" /></td>
                    <td><asp:RadioButton ID="rb135" runat="server" GroupName="p13" /></td>      
                </tr>
                <tr>
                    <td >14</td>
                    <td style="text-align:left">Se interesa por el grado de comprensión de sus explicaciones.</td>
                    <td><asp:RadioButton ID="rb141" runat="server" GroupName="p14" /></td>
                    <td><asp:RadioButton ID="rb142" runat="server" GroupName="p14" /></td>
                    <td><asp:RadioButton ID="rb143" runat="server" GroupName="p14" /></td>
                    <td><asp:RadioButton ID="rb144" runat="server" GroupName="p14" /></td>
                    <td><asp:RadioButton ID="rb145" runat="server" GroupName="p14" /></td>         
                </tr>
                <tr>
                    <td >15</td>
                    <td style="text-align:left">Expone ejemplos en los que se ponen en práctica los contenidos de la asignatura.</td>
                    <td><asp:RadioButton ID="rb151" runat="server" GroupName="p15" /></td>
                    <td><asp:RadioButton ID="rb152" runat="server" GroupName="p15" /></td>
                    <td><asp:RadioButton ID="rb153" runat="server" GroupName="p15" /></td>
                    <td><asp:RadioButton ID="rb154" runat="server" GroupName="p15" /></td>
                    <td><asp:RadioButton ID="rb155" runat="server" GroupName="p15" /></td>  
                </tr>
                <tr>
                    <td >16</td>
                    <td style="text-align:left">Domina el contenido de la asignatura.</td>
                    <td><asp:RadioButton ID="rb161" runat="server" GroupName="p16" /></td>
                    <td><asp:RadioButton ID="rb162" runat="server" GroupName="p16" /></td>
                    <td><asp:RadioButton ID="rb163" runat="server" GroupName="p16" /></td>
                    <td><asp:RadioButton ID="rb164" runat="server" GroupName="p16" /></td>
                    <td><asp:RadioButton ID="rb165" runat="server" GroupName="p16" /></td>  
                </tr>
                <tr>
                    <td>17</td>
                    <td style="text-align:left">Resuelve dudas y retroalimenta cuando es necesario.</td>
                    <td><asp:RadioButton ID="rb171" runat="server" GroupName="p17" /></td>
                    <td><asp:RadioButton ID="rb172" runat="server" GroupName="p17" /></td>
                    <td><asp:RadioButton ID="rb173" runat="server" GroupName="p17" /></td>
                    <td><asp:RadioButton ID="rb174" runat="server" GroupName="p17" /></td>
                    <td><asp:RadioButton ID="rb175" runat="server" GroupName="p17" /></td> 
                </tr>
                <tr>
                    <td>18</td>
                    <td style="text-align:left">Fomenta un ambiente agradable y de participación.</td>
                    <td><asp:RadioButton ID="rb181" runat="server" GroupName="p18" /></td>
                    <td><asp:RadioButton ID="rb182" runat="server" GroupName="p18" /></td>
                    <td><asp:RadioButton ID="rb183" runat="server" GroupName="p18" /></td>
                    <td><asp:RadioButton ID="rb184" runat="server" GroupName="p18" /></td>
                    <td><asp:RadioButton ID="rb185" runat="server" GroupName="p18" /></td> 
                </tr>
                <tr>
                    <td>19</td>
                    <td style="text-align:left">Fomenta la participación de todos los/as estudiantes y respeta las opiniones individuales.</td>
                    <td><asp:RadioButton ID="rb191" runat="server" GroupName="p19" /></td>
                    <td><asp:RadioButton ID="rb192" runat="server" GroupName="p19" /></td>
                    <td><asp:RadioButton ID="rb193" runat="server" GroupName="p19" /></td>
                    <td><asp:RadioButton ID="rb194" runat="server" GroupName="p19" /></td>
                    <td><asp:RadioButton ID="rb195" runat="server" GroupName="p19" /></td> 
                </tr>
                <tr>
                    <td>20</td>
                    <td style="text-align:left">Promueve el análisis, la crítica, la reflexión, la creatividad…</td>
                    <td><asp:RadioButton ID="rb201" runat="server" GroupName="p20" /></td>
                    <td><asp:RadioButton ID="rb202" runat="server" GroupName="p20" /></td>
                    <td><asp:RadioButton ID="rb203" runat="server" GroupName="p20" /></td>
                    <td><asp:RadioButton ID="rb204" runat="server" GroupName="p20" /></td>
                    <td><asp:RadioButton ID="rb205" runat="server" GroupName="p20" /></td>
                </tr>
                <tr>
                    <td>21</td>
                    <td style="text-align:left">Motiva a los/as estudiantes para que se interesen por la asignatura.</td>
                    <td><asp:RadioButton ID="rb211" runat="server" GroupName="p21" /></td>
                    <td><asp:RadioButton ID="rb212" runat="server" GroupName="p21" /></td>
                    <td><asp:RadioButton ID="rb213" runat="server" GroupName="p21" /></td>
                    <td><asp:RadioButton ID="rb214" runat="server" GroupName="p21" /></td>
                    <td><asp:RadioButton ID="rb215" runat="server" GroupName="p21" /></td>

                </tr>
                <tr>
                    <td>22</td>
                    <td style="text-align:left">Es respetuoso/a en el trato con los/as estudiantes.</td>
                    <td><asp:RadioButton ID="rb221" runat="server" GroupName="p22" /></td>
                    <td><asp:RadioButton ID="rb222" runat="server" GroupName="p22" /></td>
                    <td><asp:RadioButton ID="rb223" runat="server" GroupName="p22" /></td>
                    <td><asp:RadioButton ID="rb224" runat="server" GroupName="p22" /></td>
                    <td><asp:RadioButton ID="rb225" runat="server" GroupName="p22" /></td>
                </tr>
                <tr>
                    <td>23</td>
                    <td style="text-align:left">Trata a todos los/as estudiantes sin distinción de ningún tipo.</td>
                    <td><asp:RadioButton ID="rb231" runat="server" GroupName="p23" /></td>
                    <td><asp:RadioButton ID="rb232" runat="server" GroupName="p23" /></td>
                    <td><asp:RadioButton ID="rb233" runat="server" GroupName="p23" /></td>
                    <td><asp:RadioButton ID="rb234" runat="server" GroupName="p23" /></td>
                    <td><asp:RadioButton ID="rb235" runat="server" GroupName="p23" /></td>
                </tr>
            </table>
            <br />
            <table>
                <tr>
                    <th colspan="7" >EVALUACIÓN DE LOS APRENDIZAJES<br />SISTEMAS DE EVALUACIÓN</th>
                </tr>
                <tr class="purple">
                    <th>No.</th>
                    <th>Reactivo</th>
                    <th>1</th>
                    <th>2</th>
                    <th>3</th>
                    <th>4</th>
                    <th>5</th>
                </tr>
                <tr>
                    <td>24</td>
                    <td style="text-align:left">El/la docente evalúa mediante diversas evidencias de aprendizaje, utilizando criterios o rúbricas de evaluación.</td>
                    <td><asp:RadioButton ID="rb241" runat="server" GroupName="p24" /></td>
                    <td><asp:RadioButton ID="rb242" runat="server" GroupName="p24" /></td>
                    <td><asp:RadioButton ID="rb243" runat="server" GroupName="p24" /></td>
                    <td><asp:RadioButton ID="rb244" runat="server" GroupName="p24" /></td>
                    <td><asp:RadioButton ID="rb245" runat="server" GroupName="p24" /></td>
                </tr>
                <tr>
                    <td>25</td>
                    <td style="text-align:left">Los criterios y sistemas de evaluación establecidos se aplican adecuadamente.</td>
                    <td><asp:RadioButton ID="rb251" runat="server" GroupName="p25" /></td>
                    <td><asp:RadioButton ID="rb252" runat="server" GroupName="p25" /></td>
                    <td><asp:RadioButton ID="rb253" runat="server" GroupName="p25" /></td>
                    <td><asp:RadioButton ID="rb254" runat="server" GroupName="p25" /></td>
                    <td><asp:RadioButton ID="rb255" runat="server" GroupName="p25" /></td>

                </tr>
                <tr>
                    <td>26</td>
                    <td style="text-align:left">Informa los resultados de la evaluación en cada evidencia y brinda retroalimentación.</td>
                    <td><asp:RadioButton ID="rb261" runat="server" GroupName="p26" /></td>
                    <td><asp:RadioButton ID="rb262" runat="server" GroupName="p26" /></td>
                    <td><asp:RadioButton ID="rb263" runat="server" GroupName="p26" /></td>
                    <td><asp:RadioButton ID="rb264" runat="server" GroupName="p26" /></td>
                    <td><asp:RadioButton ID="rb265" runat="server" GroupName="p26" /></td>
                </tr>
            </table>
            <br />
            <table>
                <tr>
                    <th colspan="7" class ="cat">RESULTADOS<br />EFICACIA</th>
                </tr>
                <tr class="nub">
                    <th>No.</th>
                    <th>Reactivo</th>
                    <th>1</th>
                    <th>2</th>
                    <th>3</th>
                    <th>4</th>
                    <th>5</th>
                </tr>

                <tr>
                    <td>27</td>
                    <td style="text-align:left">Las actividades desarrolladas (teóricas, prácticas, de trabajo individual, en grupo,…) me han permitido alcanzar los resultados de aprendizaje de la asignatura.</td>
                    <td><asp:RadioButton ID="rb271" runat="server" GroupName="p27" /></td>
                    <td><asp:RadioButton ID="rb272" runat="server" GroupName="p27" /></td>
                    <td><asp:RadioButton ID="rb273" runat="server" GroupName="p27" /></td>
                    <td><asp:RadioButton ID="rb274" runat="server" GroupName="p27" /></td>
                    <td><asp:RadioButton ID="rb275" runat="server" GroupName="p27" /></td>
                </tr>
            </table>
            <br />
            <table>
                <tr>
                    <th colspan="7" >SATISFACCIÓN DE LOS ESTUDIANTES</th>
                </tr>
                <tr  class="pasto">
                    <th>No.</th>
                    <th>Reactivo</th>
                    <th>1</th>
                    <th>2</th>
                    <th>3</th>
                    <th>4</th>
                    <th>5</th>
                </tr>

                <tr>
                    <td style="width:25px">28</td>
                    <td style="text-align:left">Estoy satisfecho/a con la labor del docente.</td>
                    <td style="width:25px"><asp:RadioButton ID="rb281" runat="server" GroupName="p28" /></td>
                    <td style="width:25px"><asp:RadioButton ID="rb282" runat="server" GroupName="p28" /></td>
                    <td style="width:25px"><asp:RadioButton ID="rb283" runat="server" GroupName="p28" /></td>
                    <td style="width:25px"><asp:RadioButton ID="rb284" runat="server" GroupName="p28" /></td>
                    <td style="width:25px"><asp:RadioButton ID="rb285" runat="server" GroupName="p28" /></td>
                </tr>
            </table>
        </div>
        <br />
        <div class="dC">
        <div class="form">
            <asp:TextBox ID="txtComentario" runat="server" autocomplete="off" />
		    <label class="lbl-nombre"><span class="text-nomb">Comentarios (No mayor a 200 caracteres).</span></label>
        </div>
        <br />
        <asp:Label ID="lbEstado" runat="server" CssClass="red"/>
        <br />
        <br />
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="success" OnClick="btnGuardar_Click" />
        <br />
        </div>
        <br />  
    </center>        
    <div id="divPop" class="fichaFondo" runat="server"> 
        <div class="popCN">
            <p class="txt">Buen día, estas por comenzar la evaluación a tus docentes, por favor lee atentamente cada pregunta y contéstala no por cómo “te caiga el profesor”, sino por las competencias y habilidades de cada uno, esto nos ayudara a saber cómo se desempeñan tus maestros y de ser necesario trabajar en las debilidades que esta prueba arroje. <br/><br/>Agradecemos mucho tu apoyo y cooperación :D</p>
            <br />
            <br />
            <asp:Button ID="btnpop" runat="server" Text="Comenzar con la evaluación" CssClass="primary" OnClick="btnpop_Click"/>
        </div>
    </div>

    <div id="divPCon" class="fichaFondo" runat="server" visible="false"> 
        <div class="popCN">
            <br />
            <br />
            <asp:Label ID="lbMsg" runat="server" CssClass="txt"></asp:Label>
            <asp:Button ID="btnDivCon" runat="server" Text="Entendido" CssClass="success" OnClick="btnDivCon_Click" />
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