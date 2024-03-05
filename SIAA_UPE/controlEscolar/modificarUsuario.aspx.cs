using SIAA_UPE.CONTROL;
using SIAA_UPE.MODELO.entidades;
using System;

namespace SIAA_UPE.contolEscolar
{
    public partial class grupoUsuario : System.Web.UI.Page
    {
        ctrlAlumno ctrlAl = new ctrlAlumno();
        ctrlGrupo ctrlGo = new ctrlGrupo();
        static string matricula,nombre;
        protected void Page_Load(object sender, EventArgs e)
        {
            nombre = Session["UserName"] as string;
            lbUserName.Text = nombre;
            if (!IsPostBack)
            {
                ddGrupo.DataSource = ctrlGo.selectAll();
                ddGrupo.DataBind();
                ddSituacion.DataSource = ctrlAl.selectSituacion();
                ddSituacion.DataBind();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (btnBuscar.Text.Equals("Buscar"))
            {
                try
                {
                    matricula = txtMatricula.Text.Substring(4);
                    FD_SIA_ALUMNO alumno = ctrlAl.alumno(matricula);
                    txtMatricula.Text = alumno.NAlumno;
                    this.divSerch.Visible = false;
                    this.divEditar.Visible = true;
                    this.ddGrupo.SelectedValue = alumno.idGrupo;
                    this.ddSituacion.SelectedValue = alumno.idSituacionActual;
                    lbDtl.Text = (alumno.NAlumno + " su situacion actual es: " + alumno.CT_SIA_SITUACIONACTUAL.detalle).ToUpper();
                    txtNombre.Text = alumno.DP_SIA_PERSONA.nombre;
                    txtAPaterno.Text = alumno.DP_SIA_PERSONA.aPaterno;
                    txtAMaterno.Text = alumno.DP_SIA_PERSONA.aMaterno;
                    txtPass.Text = alumno.password;
                    btnBuscar.Text = "Actualizar";
                }
                catch
                {
                    txtMatricula.Text = "Por favor revise su información";
                }
            }
            else
            {
                FD_SIA_ALUMNO alumno = ctrlAl.alumno(matricula);
                alumno.idGrupo = ddGrupo.SelectedValue;
                alumno.idSituacionActual = ddSituacion.SelectedValue;
                alumno.password = txtPass.Text;
                alumno.DP_SIA_PERSONA.nombre= txtNombre.Text.ToUpper();
                alumno.DP_SIA_PERSONA.aPaterno= txtAPaterno.Text.ToUpper();
                alumno.DP_SIA_PERSONA.aMaterno= txtAMaterno.Text.ToUpper();
                ctrlAl.update(alumno);
                Response.Redirect("modificarUsuario.aspx");
            }
        }
    }
}