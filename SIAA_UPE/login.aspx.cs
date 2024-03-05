using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using SIAA_UPE.CONTROL;


namespace SIAA_UPE
{
    public partial class login : System.Web.UI.Page
    {
        sesion ctrl = new sesion();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            lbToast.Text = "Información incorrecta, por favor revisar su información (Usuario | Contraseña) y volverlo a intentar.";
            this.divToast.Style.Add("background-color", "rgba(166, 32, 67, 0.7)");

            string user = txtUser.Text;
            if (user.Length >= 11)
            {
                user = user.Substring(4);
            }
            string permiso = ctrl.login(user, txtpass.Text);

            if (!permiso.Equals("Sin registro"))
            {
                Session["user"] = user;
                Session["permiso"] = permiso;
                Response.Redirect("home.aspx");
            }
            else
                this.divToast.Visible = true; 
            
        }
    }
}