using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SIAA_UPE.CONTROL;
using SIAA_UPE.MODELO.entidades;


namespace SIAA_UPE.EVCD.ADMIN
{
    public partial class resultadosEVCD : System.Web.UI.Page
    {
        ctrlEVDOC ctrl = new ctrlEVDOC();
        ctrlDocente ctrlD = new ctrlDocente();
        string nombre = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            nombre = Session["UserName"] as string;
            lbUserName.Text = nombre;
            if (!IsPostBack)
            {
                this.llenarDrop();
            }
            dvPerfil.Visible = false;
            dvPre.Visible = false;

        }
        protected void ddMT_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<mM> mm = ctrl.Promedio(ddMT.SelectedValue);

            gvCalificaciones.DataSource = mm;
            gvCalificaciones.DataBind();

            gvComentario.DataSource= ctrl.Comentarios(ddMT.SelectedValue);
            gvComentario.DataBind();
            dvPerfil.Visible = true;
            double promedio = ctrl.prom(ddMT.SelectedValue);
            lbCalGral.Text = promedio.ToString();            
            lbNombre.Text = ddMT.SelectedItem.Text;
            lbMateria.Text = ctrl.selecMM_BY(ddMT.SelectedValue);
            if(ddMT.SelectedIndex != 0)
            {
                gvEVCD.Visible = false;
                dvPre.Visible = true;
                lbProGral.Visible = false;
                try
                {
                    bool up = ctrl.Update(ddMT.SelectedValue, decimal.Parse(lbCalGral.Text));
                }
                catch (Exception _ex)
                {
                    string msj = _ex.Message;
                }
            }
            else
            {
                gvEVCD.Visible = true;
                dvPre.Visible = false;
                dvPerfil.Visible = false;
                lbProGral.Visible = true;

            }
        }

        private void llenarDrop()
        {

            this.ddMT.DataSource = ctrlD.selectEVCD();
            this.ddMT.DataBind();
            this.ddMT.Items.Insert(0, "Selecciona un Profesor");
            this.gvEVCD.DataSource = ctrlD.selectEVCD();
            this.gvEVCD.DataBind();
            lbProGral.Text = "Promedio General: " + ctrl.pGral().ToString();


        }

        private void ActualizarPromedios()
        {
            List<FD_SIA_DOCENTE> lsMtro = ctrlD.selectAll();
            double pro = (double)lsMtro[0].promedioED;
            if(pro==0.0)
            {
                for (int i = 0; i < lsMtro.Count; i++)
                {
                    try
                    {
                        string id = lsMtro[i].idDocente;
                        double promedio = ctrl.prom(id);
                        ctrlD.upPromedio(promedio, id);
                    }
                    catch (Exception ex)
                    {
                        string msj = ex.Message;
                    }
                }
            }
        }
    }
}