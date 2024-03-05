using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using SIAA_UPE.CONTROL;
using SIAA_UPE.MODELO.entidades;

namespace SIAA_UPE.admin
{
    public partial class gfpCaja : System.Web.UI.Page
    {
        static string matricula="";
        ctrlAlumno ctrlAl = new ctrlAlumno();
        static FD_SIA_ALUMNO alumno = new FD_SIA_ALUMNO();
        RG_SIA_GREFERENCIA referencia = new RG_SIA_GREFERENCIA();

        int idP;

        protected void Page_Load(object sender, EventArgs e)
        {
            lbUserName.Text = Session["UserName"] as string;
        }

        protected void btnX_Click(object sender, EventArgs e)
        {
            string currentPage = this.Page.Request.AppRelativeCurrentExecutionFilePath;
            Response.Redirect(currentPage);
        }

        protected void btn_Ficha(object sender, EventArgs e)
        {
            var btn = (ImageButton)sender;
            try
            {
                switch (btn.ID)
                {
                    case "btn01":
                        idP = 0;
                        break;
                    case "btn02":
                        idP = 1;
                        break;
                    case "btn03":
                        idP = 2;
                        break;
                    case "btn04":
                        idP = 3;
                        break;
                    case "btn05":
                        idP = 4;
                        break;
                    case "btn06":
                        idP = 5;
                        break;
                    case "btn07":
                        idP = 6;
                        break;
                    case "btn08":
                        idP = 7;
                        break;
                    case "btn09":
                        idP = 8;
                        break;
                    case "btn10":
                        idP = 9;
                        break;
                    case "btn11":
                        idP = 10;
                        break;
                    case "btn12":
                        idP = 11;
                        break;
                    case "btn13":
                        idP = 12;
                        break;
                    case "btn14":
                        idP = 13;
                        break;
                    case "btn15":
                        idP = 14;
                        break;
                    case "btn16":
                        idP = 15;
                        break;
                    case "btn17":
                        idP = 16;
                        break;
                    case "btn18":
                        idP = 17;
                        break;
                    case "btn19":
                        idP = 18;
                        break;
                    case "btn20":
                        idP = 19;
                        break;
                    case "btn21":
                        idP = 20;
                        break;
                    case "btn22":
                        idP = 21;
                        break;
                    case "btn23":
                        idP = 22;
                        break;
                    case "btn24":
                        idP = 23;
                        break;
                    case "btn25":
                        idP = 24;
                        break;                    
                }
                Session["idPago"] = idP;
                Session["idNameAlumno"] = alumno.NAlumno;
                Session["idNameAlumno"] = alumno.idAlumno;
                string url = "/nTiket.aspx";
                string script = "window.open('" + url + "', '_blank', 'menubar=no,directories=no,location=no,resizable=yes,scrollbars=yes,status=yes,width=500,height=500');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "open_window", script, true);

            }
            catch (Exception ex)
            {
                string a = ex.Message;
            }

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            lbAlumno.Visible = true;
            matricula = txtMatricula.Text.Substring(4);
            alumno = ctrlAl.alumno(matricula);
            if(alumno!=null)
            {
                if(alumno.idSituacionActual.Equals("1         "))
                {
                    divUser.Visible = false;
                    divMenu.Visible = true;
                    lbAlumno.Text = "Esta a punto de generar una ficha para " + txtMatricula.Text + " | " + alumno.NAlumno;
                }
                else
                {
                    lbAlumno.Text = "El alumno "+ alumno.NAlumno+" con matrícula " + txtMatricula.Text +" presenta una situación de "+alumno.CT_SIA_SITUACIONACTUAL.detalle+", diríjase al área de coordinación académica para solicitar una aclaración.";
                }
            }
            else
            {
                lbAlumno.Text = "No se encontró registro con dicha matricula, por favor revise que la información sea correcta, de continuar con el problema póngase en contacto con el área de sistemas.";
            }
        }
    }
}