using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using SIAA_UPE.CONTROL;
using SIAA_UPE.MODELO.entidades;

namespace SIAA_UPE.EVCD.ADMIN
{
    public partial class adminGrupo : System.Web.UI.Page
    {
        ctrlCarrera ctrlC = new ctrlCarrera();
        ctrlGrupo ctrlG = new ctrlGrupo();
        string nombre = "";
        static List<CT_SIA_GRUPO> lsg = new List<CT_SIA_GRUPO>();
        static CT_SIA_GRUPO lg = new CT_SIA_GRUPO();


        protected void Page_Load(object sender, EventArgs e)
        {
            nombre = Session["UserName"] as string;
            lbUserName.Text = nombre;
        }

        protected void roud(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvG.Rows[index];
            string id = row.Cells[0].Text;
            lg = ctrlG.select(id);
            if (e.CommandName == "editar")
            {
                naRegistro();
                ddCarrera.SelectedValue = lg.idPE;
                txtID.Text = lg.idGrupo;
                txtnNAlumnos.Text = lg.numAlumnos.ToString();
                if(lg.estado==1)
                {
                    cbActivo.Checked = true;
                }
                lbEstado.Text = "Esta en modo de actualización";
                btnGuardar.Text = "ATUALIZAR";
            }
            else if (e.CommandName == "eliminar")
            {
                if (ctrlG.delete(id))
                    this.Page.Response.Write("<script language='JavaScript'>window.alert('Se borro Corectamente ');</script>");
                else
                    this.Page.Response.Write("<script language='JavaScript'>window.alert('Ocurrio un error porfabor intente mas tarde');</script>");
            }
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            this.divGV.Visible=true;
            string serch = txtBusqueda.Text;

            switch(serch)
            {
                case "TODOS":
                    lsg = ctrlG.selectAll();
                    
                    break;
                case "ACTIVOS":
                    lsg = ctrlG.selectG(1);
                    btnDesactivar.Visible = true;
                    btnNuevo.Visible = false;
                    break;

                default:
                    lsg = ctrlG.selectBY(serch);
                    break;
            }
            gvG.DataSource = lsg;
            gvG.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            lg.numAlumnos = int.Parse(txtnNAlumnos.Text);
            lg.idGrupo = txtID.Text;
            lg.idPE = ddCarrera.SelectedValue.ToString();
            lg.periodo = "0";
            if (cbActivo.Checked)
                lg.estado = 1;
            else
                lg.estado = 0;

            if (btnGuardar.Text.Equals("ATUALIZAR"))
            {
                if (ctrlG.Update(lg))
                    this.Page.Response.Write("<script language='JavaScript'>window.alert('Se Actualizo Corectamente.');</script>");

                else
                    this.Page.Response.Write("<script language='JavaScript'>window.alert('Ocurrió un error por favor inténtelo nuevamente, si el error persiste, póngase en contacto con el área de sistemas.');</script>");
            }
            else
            {
                if (ctrlG.insert(lg))
                    this.Page.Response.Write("<script language='JavaScript'>window.alert('Se agrego su registro Corectamente. ');</script>");
                else
                    this.Page.Response.Write("<script language='JavaScript'>window.alert('Ocurrió un error por favor inténtelo nuevamente, si el error persiste, póngase en contacto con el área de sistemas.');</script>");
            }
            Response.Redirect("adminGrupo.aspx");
        }

        protected void btnDesactivar_Click(object sender, EventArgs e)
        {
            if (ctrlG.UpdateActivos(lsg))
                this.Page.Response.Write("<script language='JavaScript'>window.alert('Se actualizarón los datos Corectamente ');</script>");
            else
                this.Page.Response.Write("<script language='JavaScript'>window.alert('Ocurrio un error porfabor intente mas tarde');</script>");
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            naRegistro();
        }
        private void naRegistro()
        {

            this.btnNuevo.Visible = false;
            this.buscar.Visible = false;
            this.nuevo.Visible = true;
            ddCarrera.DataSource = ctrlC.select(0);
            ddCarrera.DataBind();
            ddCarrera.Items.Insert(0, "Seleccione el Programa Educativo al que pertenece");
        }
    }
}