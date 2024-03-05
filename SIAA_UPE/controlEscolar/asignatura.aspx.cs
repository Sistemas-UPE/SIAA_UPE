using SIAA_UPE.CONTROL;
using SIAA_UPE.MODELO.entidades;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace SIAA_UPE.controlEscolar
{
    public partial class Asignatura : System.Web.UI.Page
    {
        ctrlCarrera ctrlC = new ctrlCarrera();
        ctrlAsignatura ctrlA = new ctrlAsignatura();
        CA_SIA_ASIGNATURA m = new CA_SIA_ASIGNATURA();
        List<CA_SIA_ASIGNATURA> asignaturas = new List<CA_SIA_ASIGNATURA>();
        static string id, nombre, msg, color;
        protected void Page_Load(object sender, EventArgs e)
        {
            nombre = Session["UserName"] as string;
            lbUserName.Text = nombre;
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            this.divGV.Visible = true;
            this.divToast.Visible = false;
            string serch = txtBusqueda.Text;

            switch (serch)
            {
                case "TODOS":
                    asignaturas = ctrlA.selectAll();

                    break;

                default:
                    asignaturas = ctrlA.selectBY(serch);
                    break;
            }
            gvG.DataSource = asignaturas;
            gvG.DataBind();
        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            llenarDrop();
            this.nuevo.Visible = true;
            this.buscar.Visible = false;
            this.divToast.Visible = false;
        }
        protected void roud(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvG.Rows[index];
            id = row.Cells[0].Text;
            if (e.CommandName == "editar")
            {
                m = ctrlA.selectByID(id);
                txtID.Text = m.idAsignatura;
                txtnMateria.Text = m.nomAsignatura;
                txtUnidades.Text = m.creditos.ToString();
                txtCuatri.Text = m.cuatrimestre.ToString();
                ddPE.SelectedValue = m.idPE;
                this.nuevo.Visible = true;
                this.buscar.Visible = false;
                btnGuardar.Text = "ACTUALIZAR";
                lbERROR.Text = "Se encuentra en estado de edicion";
            }
            else if (e.CommandName == "eliminar")
            {
                bool correcto = ctrlA.delete(id);
                if (correcto)
                {
                    msg = "La información se eliminó de forma exitosa.";
                    color = "rgba(255, 165, 0, 0.7)";
                }
                else
                {
                    msg = "Ocurrió un error, favor de intentarlo mas tarde.";
                    color = "rgba(166, 32, 67, 0.7)";
                }
                toast(color,msg);
            }


        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                color = "rgba(0, 128, 0, 0.7)";
                if (btnGuardar.Text.Equals("ACTUALIZAR"))
                {
                    msg = "La información se actualizo correctamente.";
                    ctrlA.Update(cargar(),id);
                }
                else
                {
                    msg = "La información se guardó correctamente.";
                    ctrlA.insert(cargar());
                }
            }
            catch
            {
                msg = "Ocurrió un error, favor de intentarlo mas tarde.";
                color = "rgba(166, 32, 67, 0.7)";
            }
            toast(color, msg);
            this.nuevo.Visible = false;
            this.buscar.Visible = true;
        }

        private CA_SIA_ASIGNATURA cargar()
        {
            m.idAsignatura = txtID.Text;
            m.nomAsignatura = txtnMateria.Text;
            m.creditos = int.Parse(txtUnidades.Text);
            m.cuatrimestre = int.Parse(txtCuatri.Text);
            m.idPE = ddPE.SelectedValue;
            return m;
        }

        private void llenarDrop()
        {
            this.ddPE.DataSource = ctrlC.select(0);
            this.ddPE.DataBind();
            this.ddPE.Items.Insert(0, "Selecciona el plan de estudios que pertenece la materia");
        }
        private void toast(string _color,string _msg)
        {
            lbToast.Text = _msg;
            this.divToast.Style.Add("background-color", _color);
            this.divToast.Visible = true;
        }
        
    }
}