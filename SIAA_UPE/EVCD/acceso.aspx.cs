using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SIAA_UPE.CONTROL;
using SIAA_UPE.MODELO.entidades;

namespace SIAA_UPE.EVCD
{
    public partial class acceso : System.Web.UI.Page
    {
        ctrlAlumno ctrlA= new ctrlAlumno();
        ctrlGrupo ctrlG = new ctrlGrupo();
        string carrera, nombre;

        protected void Page_Load(object sender, EventArgs e)
        {
            carrera = Session["user"] as string;
            nombre = Session["UserName"] as string;
            lbUserName.Text = nombre;

            if (!IsPostBack)
            {
                llenar();            
            }
        }
        protected void btnCEv_Click(object sender, EventArgs e)
        {
            Session["idGrupo"] = this.ddlGrupo.SelectedValue;

            this.Response.Redirect("Ev01.aspx");
        }
        private void llenar()
        {
            try
            {
                string c = carrera.Substring(0, 2);
                string cb;
                c = c.ToUpper();
               
                switch (c)
                {
                    case "IP":
                        lbAlerta.Text = "Ing. Petrolera";
                        Session["idCarrera"] = "IP";
                        cb = "IP";
                        break;
                    case "IE":
                        lbAlerta.Text = "Ing. en Energía";
                        Session["idCarrera"] = "IE";
                        cb = "IE";
                        break;
                    case "IL":
                        lbAlerta.Text = "Ing. en Logística y Transporte";
                        Session["idCarrera"] = "ILT";
                        cb = "ILT";
                        break;
                    case "IS":
                        lbAlerta.Text = "Ing. en Seguridad para la Industria Enérgetica";
                        Session["idCarrera"] = "ISIE";
                        cb = "ISIE";
                        break;
                    case "MG":
                        lbAlerta.Text = "MAESTRIA en Gestión del Petróleo";
                        Session["idCarrera"] = "MGP";
                        cb = "MGP";
                        break;
                    default:
                        lbAlerta.Text = "Esto es solo para Administradores";
                        Session["idCarrera"] = "TD";
                        cb = "TD";
                        break;
                }
                if (cb.Equals("TD"))
                {
                    this.ddlGrupo.DataSource = ctrlG.selectG(2);
                    this.ddlGrupo.DataBind();
                    this.ddlGrupo.Items.Insert(0, "Selecciona tu Grupo");
                    this.d2.Visible = true;
                }
                else
                {
                    this.ddlGrupo.DataSource = ctrlG.selectGxC(cb ,1);
                    this.ddlGrupo.DataBind();
                    this.ddlGrupo.Items.Insert(0, "Selecciona tu Grupo");
                    this.d2.Visible = true;
                 
                }
            }
            catch
            {
                //lbAlerta.Text = "Porfavor coloca la informacion completa sin espacios";
                this.ddlGrupo.DataSource = ctrlG.selectG(2);
                this.ddlGrupo.DataBind();
                this.ddlGrupo.Items.Insert(0, "Selecciona tu Grupo");
                this.d2.Visible = true;
            }
        }
    }
}