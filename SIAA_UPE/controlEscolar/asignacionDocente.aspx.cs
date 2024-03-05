using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using SIAA_UPE.CONTROL;
using SIAA_UPE.MODELO.entidades;

namespace SIAA_UPE.EVCD.ADMIN
{
    public partial class adminEvaluacion : System.Web.UI.Page
    {
        ctrlCarrera ctrlC = new ctrlCarrera();
        ctrlAsignatura ctrlA = new ctrlAsignatura();
        ctrlDocente ctrlD = new ctrlDocente();
        ctrlGrupo ctrlG = new ctrlGrupo();
        ctrlDTLAD ctrlAD = new ctrlDTLAD();
        static CA_SIA_DTLAD dtlad = new CA_SIA_DTLAD();
        List <CA_SIA_DTLAD> dtladl = new List<CA_SIA_DTLAD>();
        string nombre = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            nombre = Session["UserName"] as string;
            lbUserName.Text = nombre;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            dtlad.idDocente = ddDocente.SelectedValue;
            dtlad.idAsignatura= ddAsignatura.SelectedValue;
            dtlad.idGrupo= ddCua.SelectedValue;
            if(btnGuardar.Text.Equals("Actualizar"))
            {
                if (ctrlAD.Update(dtlad))
                    this.Page.Response.Write("<script language='JavaScript'>window.alert('Se Actualizo Corectamente.');</script>");
                
                else
                    this.Page.Response.Write("<script language='JavaScript'>window.alert('Ocurrió un error por favor inténtelo nuevamente, si el error persiste, póngase en contacto con el área de sistemas.');</script>");
            }
            else
            {
                if(ctrlAD.insert(dtlad))
                    this.Page.Response.Write("<script language='JavaScript'>window.alert('Se agrego su registro Corectamente. ');</script>");
                else
                    this.Page.Response.Write("<script language='JavaScript'>window.alert('Ocurrió un error por favor inténtelo nuevamente, si el error persiste, póngase en contacto con el área de sistemas.');</script>");
            }
            Response.Redirect("adminEvaluacion.aspx");
        }

      
        protected void roud(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvAE.Rows[index];
            int id = int.Parse( row.Cells[0].Text);
            dtlad = ctrlAD.selecAD(id);
            if (e.CommandName == "editar")
            {
                naRegistro();
                ddDocente.SelectedValue=dtlad.idDocente;
                ddAsignatura.SelectedValue=dtlad.idAsignatura;
                ddCarrera.SelectedValue=dtlad.CT_SIA_GRUPO.idPE;
                ddCua.SelectedValue=dtlad.idGrupo;
                btnGuardar.Text = "Actualizar";
                lbEstado.Text = "Esta en modo de actualización";
            }
            else if (e.CommandName == "eliminar")
            {
                if (ctrlAD.delete(id))
                    this.Page.Response.Write("<script language='JavaScript'>window.alert('Se borro Corectamente ');</script>");
                else
                    this.Page.Response.Write("<script language='JavaScript'>window.alert('Ocurrio un error porfabor intente mas tarde');</script>");
            }
        }
        private void naRegistro()
        {
            this.btnNuevo.Visible = false;
            this.buscar.Visible = false;
            this.nuevo.Visible = true;
            this.ddCarrera.DataSource = ctrlC.select(0);
            this.ddCarrera.DataBind();
            this.ddCarrera.Items.Insert(0, "Selecciona el plan de estudios que pertenece la materia");
            this.ddAsignatura.DataSource = ctrlA.selectAll();
            this.ddAsignatura.DataBind();
            this.ddAsignatura.Items.Insert(0, "Selecciona la Asignatura");
            this.ddDocente.DataSource = ctrlD.selectAll();
            this.ddDocente.DataBind();
            this.ddDocente.Items.Insert(0, "Selecciona al Docente");
            this.ddCua.Items.Insert(0, "Seleccione Un grupo");
            this.ddCua.DataSource = ctrlG.selectAll();
            this.ddCua.DataBind();
        }
        protected void ddCarrera_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ddCua.DataSource = ctrlG.selectGxC(ddCarrera.SelectedValue, 1);
            this.ddCua.DataBind();
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            this.divGV.Visible = true;
            string serch = txtBusqueda.Text;
            if (serch.Equals("TODOS"))
            {
                dtladl = ctrlAD.selectALL();
                this.gvAE.DataSource = dtladl;
            }
            else
            {
                dtladl = ctrlAD.selectBY(serch);
                this.gvAE.DataSource = dtladl;
            }
            this.gvAE.DataBind();
        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            naRegistro();
        }
    }
}