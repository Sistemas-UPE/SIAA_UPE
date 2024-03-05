using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using SIAA_UPE.CONTROL;
using SIAA_UPE.MODELO.entidades;

namespace SIAA_UPE
{
    public partial class home : System.Web.UI.Page
    {
        static string matricula, permiso;
        static bool ed;
        ctrlAlumno ctrlAl = new ctrlAlumno();
        ctrlDocente ctrlDoc = new ctrlDocente();
        ctrlEmpleado ctrlEmp = new ctrlEmpleado();
        ctrlEVDOC ctrlED = new ctrlEVDOC();
        ctrlTipoPago ctrlp = new ctrlTipoPago();
        codificar code = new codificar();
        FD_SIA_ALUMNO alumno = new FD_SIA_ALUMNO();
        FD_SIA_EMPLEADO empleado = new FD_SIA_EMPLEADO();
        FD_SIA_DOCENTE docente = new FD_SIA_DOCENTE();

        protected void Page_Load(object sender, EventArgs e)
        {
            ed = ctrlED.evcdEstatus();
            btnEVCDColor(ed);
            try
            {
                matricula = Session["user"] as string;
                permiso = Session["permiso"] as string;
                
                mostrarMenu(permiso);
            }
            catch (Exception ex)
            {

                string a = ex.Message;
                Response.Redirect("login.aspx");

            }
        }
        protected void btn(object sender, EventArgs e)
        {
            Session["matricula"] = matricula;
            var btn = (ImageButton)sender;
            try
            {
                switch (btn.ID)
                {
                    case "btnPagos":
                        Response.Redirect("~/user/gFichaPago.aspx");
                        break;
                    case "btnConsulta":
                        Response.Redirect("~/user/consultaPagos.aspx");
                        break;
                    case "btnAdeudo":
                        Response.Redirect("~/user/adeudos.aspx");
                        break;
                    case "btnEVCD":
                        Session["carrera"] = alumno.idAlumno;
                        this.Response.Redirect("~/EVCD/acceso.aspx");
                        break;
                    case "btnAU":
                        this.Response.Redirect("~/admin/agregarUsuario.aspx");
                        break;
                    case "btnCD":
                        this.Response.Redirect("~/admin/comprobarDepositos.aspx");
                        break;
                    case "btnAP":
                        this.Response.Redirect("~/admin/conceptosPagos.aspx");
                        break;
                    case "btnGP":
                        this.Response.Redirect("~/admin/gfpCaja.aspx");
                        break;
                    case "btnCP":
                        this.Response.Redirect("~/admin/cPNI.aspx");
                        break;
                    case "btnAE":
                        this.Response.Redirect("~/controlEscolar/asignacionDocente.aspx");
                        break;
                    case "btnAG":
                        this.Response.Redirect("~/controlEscolar/adminGrupo.aspx");
                        break;
                    case "btnRE":
                        this.Response.Redirect("~/EVCD/ADMIN/resultadosEVCD.aspx");
                        break;
                    case "btnCNI":
                        this.Response.Redirect("~/nIngreso/consultaAspirantes.aspx");
                        break;
                    case "btnREVCD":
                        this.Response.Redirect("~/EVCD/ADMIN/reiniciarEVCD.aspx");
                        break;
                    case "btnEstatusEVCD":
                        if (ed)
                        {
                            if (ctrlED.updateevcdEstatus(0))
                                this.Page.Response.Write("<script language='JavaScript'>window.alert('La encuesta ahora esta deshabilitada.');</script>");

                            else
                                this.Page.Response.Write("<script language='JavaScript'>window.alert('Ocurrió un error, por favor, inténtelo mas tarde..');</script>");
                        }
                        else
                        {
                            if (ctrlED.updateevcdEstatus(1))
                                this.Page.Response.Write("<script language='JavaScript'>window.alert('La encuesta ahora está disponible.');</script>");

                            else
                                this.Page.Response.Write("<script language='JavaScript'>window.alert('Ocurrió un error, por favor, inténtelo mas tarde..');</script>");
                        }
                        Response.Redirect("home.aspx");
                        break;
                    case "btnEditarAlum":
                        this.Response.Redirect("~/controlEscolar/modificarUsuario.aspx");
                        break;
                    case "btnRecursamientos":
                        this.Response.Redirect("~/controlEscolar/recursamientos.aspx");
                        break;
                    case "btnConsultaRecursamiento":
                        this.Response.Redirect("~/controlEscolar/consultaRecursamiento.aspx");
                        break;
                    case "btnAdmAsignatura":
                        this.Response.Redirect("~/controlEscolar/asignatura.aspx");
                        break;

                }
            }
            catch (Exception ex)
            {
                string a = ex.Message;
            }

        }
        private void mostrarMenu(string _permiso)
        {
            switch (_permiso)
            {
                case "Administrador  ":
                    this.btnAdmin01.Visible = true;
                    this.btnAdmin02.Visible = true;
                    this.btnAdmin03.Visible = true;
                    this.btnAdmin04.Visible = true;
                    this.btnAdmin05.Visible = true;
                    this.btnAdmin06.Visible = true;
                    this.btnAdmin07.Visible = true;
                    this.btnAdmin08.Visible = true;
                    this.btnAdmin09.Visible = true;
                    this.btnAdmin10.Visible = true;
                    this.btnAlu01.Visible = true;
                    this.btnAlu02.Visible = true;
                    this.btnAlu03.Visible = true;
                    this.btnAlu04.Visible = true;
                    this.btnED.Visible = true;
                    this.btnCE01.Visible = true;
                    this.btnCE02.Visible = true;
                    this.btnCE03.Visible = true;
                    this.btnCE04.Visible = true;
                    
                    empleado = ctrlEmp.empleado(matricula);
                    lbUserName.Text = empleado.DP_SIA_PERSONA.nombre;
                    break;
                case "Finanzas       ":
                    empleado = ctrlEmp.empleado(matricula);
                    lbUserName.Text = empleado.DP_SIA_PERSONA.nombre;
                    this.btnAdmin02.Visible = true;
                    this.btnAdmin03.Visible = true;
                    this.btnAdmin07.Visible = true;
                    this.btnAdmin08.Visible = true;
                    this.btnAdmin09.Visible = true;
                    this.btnCE03.Visible = true;
                    break;
                case "Academia       ":
                    empleado = ctrlEmp.empleado(matricula);
                    lbUserName.Text = empleado.DP_SIA_PERSONA.nombre;
                    this.btnAdmin04.Visible = true;
                    this.btnAdmin05.Visible = true;
                    this.btnAdmin06.Visible = true;
                    this.btnAdmin10.Visible = true;
                    this.btnCE01.Visible = true;
                    this.btnCE02.Visible = true;
                    this.btnCE03.Visible = true;
                    this.btnCE04.Visible = true;
                    this.btnED.Visible = true;
                    break;
                case "SE             ":
                    empleado = ctrlEmp.empleado(matricula);
                    lbUserName.Text = empleado.DP_SIA_PERSONA.nombre;
                    this.btnAdmin09.Visible = true;
                    break;
                case "Docente        ":
                    docente = ctrlDoc.docente(matricula);
                    lbUserName.Text = docente.NDocente;
                    break;
                case "Alumno":
                    alumnoAccion();
                    break;
                default:
                    lbUserName.Text = "error";
                    lbError.Visible = true;
                    lbError.Text = "TU SESIÓN ACTUALMENTE ESTÁ SUSPENDIDA, POR FAVOR PONTE EN CONTACTO CON EL ADMINISTRADOR DEL SISTEMA.";
                    break;
            }
                Session["UserName"] = lbUserName.Text;
        }
        private void btnEVCDColor(bool _ed)
        {
            if (_ed)
                this.btnED.Style.Add("background","green");
            else
                this.btnED.Style.Add("background","red");
        }
        private void alumnoAccion()
        {
            alumno = ctrlAl.alumno(matricula);
            lbUserName.Text = alumno.NAlumno;
            int lsR = ctrlAl.numRecursamientobyAlumno(alumno.idAlumno);
            if(lsR!=0)
            {
                if (ctrlp.vigente(16))
                {
                    this.btnAlu05.Visible = true;
                }
                else
                {
                 lbError.Text = "TU SESIÓN ACTUALMENTE ESTÁ SUSPENDIDA, POR FAVOR PONTE EN CONTACTO CON EL ADMINISTRADOR DEL SISTEMA.";
                }
            }
            else
            { 
                this.btnAlu02.Visible = true;
                this.btnAlu01.Visible = true;
                if (ed)
                    this.btnAlu03.Visible = true;
                else
                    this.btnAlu03.Visible = false;
            }
        }
    }
}