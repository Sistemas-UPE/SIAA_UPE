using SIAA_UPE.CONTROL;
using SIAA_UPE.MODELO.entidades;
using System;

namespace SIAA_UPE.contolEscolar
{
    public partial class modificarUsuario : System.Web.UI.Page
    {
        ctrlAlumno ctrlAl = new ctrlAlumno();
        ctrlAsignatura ctrlA = new ctrlAsignatura();
        static FD_SIA_ALUMNO alumno = new FD_SIA_ALUMNO();
        static string M,matricula,nombre;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                nombre = Session["UserName"] as string;
                lbUserName.Text = nombre;
            }
            
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if(btnBuscar.Text.Equals("Buscar"))
            {
                try
                {
                    M = txtMatricula.Text;
                    matricula = M.Substring(4);
                    alumno = ctrlAl.alumno(matricula);
                    txtMatricula.Text = alumno.NAlumno + " CON MATRICULA: " + M;
                    ddMaterias.DataSource = ctrlA.selectByPE(alumno.CT_SIA_GRUPO.idPE);
                    ddMaterias.DataBind();
                    ddMaterias.Visible = true;
                    btnBuscar.Text = "Asignar recursamiento";
                }
                    catch
                {
                    txtMatricula.Text = "Por favor revise su información";
                }
            }
            else
            {
                RG_SIA_RECURSAMIENTOS rec = new RG_SIA_RECURSAMIENTOS();
                rec.idAlumno = alumno.idAlumno;
                rec.idAsignatura = ddMaterias.SelectedValue;
                rec.cuota = 0;
                rec.estado = 0;
                ctrlAl.recursamiento(rec);
                Response.Redirect("recursamientos.aspx");
            }
        }
    }
}