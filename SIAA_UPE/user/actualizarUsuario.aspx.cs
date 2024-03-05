using SIAA_UPE.CONTROL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAA_UPE.user
{
    public partial class updateUser : System.Web.UI.Page
    {
        ctrlPersona ctrlP = new ctrlPersona();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenar();
            }
        }

        /////////////////METODOS LOCALES/////////////////
        private void llenar()
        {
            ddEstado.DataSource = ctrlP.estados();
            ddEstado.DataBind();
            ddEstado.Items.Insert(0, "Seleccione tu estado");
        }
    }
}