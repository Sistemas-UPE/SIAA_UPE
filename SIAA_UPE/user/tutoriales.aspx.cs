using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAA_UPE.user
{
    public partial class tutoriales : System.Web.UI.Page
    {
        string nombre = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            nombre = Session["UserName"] as string;
            lbUserName.Text = nombre;
        }
    }
}