using SIAA_UPE.CONTROL;
using SIAA_UPE.MODELO.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace SIAA_UPE.user
{
    public partial class adeudos : System.Web.UI.Page
    {
        ctrlAlumno ctrlAl = new ctrlAlumno();
        ctrlAdeudos ctrlAd = new ctrlAdeudos();
        ctrlTipoPago ctrlTP = new ctrlTipoPago();
        ctrlReferencia ctrlR = new ctrlReferencia();
        static CT_SIA_TIPOPAGO tp = new CT_SIA_TIPOPAGO();
        static List<RG_SIA_RECURSAMIENTOS> lsRecurse = new List<RG_SIA_RECURSAMIENTOS>();
        RG_SIA_GREFERENCIA referencia = new RG_SIA_GREFERENCIA();
        static RG_SIA_RECURSAMIENTOS recurse = new RG_SIA_RECURSAMIENTOS();
        static FD_SIA_ALUMNO alumno = new FD_SIA_ALUMNO();
        codificar code = new codificar();
        static string[] fecha;
        bool des;

        static string nombre, matricula;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                nombre = Session["UserName"] as string;
                matricula = Session["user"] as string;
                des = despresurizado(matricula);

                lbUserName.Text = nombre;
                inicio(); 
            }
                       
        }
        protected void roud(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvG.Rows[index];
             int id = int.Parse(row.Cells[0].Text);
            recurse = ctrlAd.recursamiento(id);
            if(recurse.estado==100)
            {

            }else
            {
                fichaRecurse(recurse);
            }
        }

        private void inicio()
        {
            alumno = ctrlAl.alumno(matricula);
            lbNombre.Text = alumno.NAlumno;
            fecha = code.fecha();
            lsRecurse = ctrlAl.listRecursamientobyAlumno(matricula);
            gvG.DataSource = lsRecurse;
            gvG.DataBind();
        }
        private void fichaRecurse(RG_SIA_RECURSAMIENTOS _recurse)
        {
            int idR = _recurse.idRecursamiento;
            referencia = ctrlR.selectByAspirante(idR.ToString());
            this.ficha.Visible = true;
            if (referencia==null)
            {
                double mt = mTotal(16);
                lbConcepto.Text = "Pago de recursamiento intensivo por la asignatura de: "+_recurse.Asignatura;
                lbImporte.Text = "$ " + mt;
                lbReferencia.Text = code.llamar(agrupar("16"), fecha, (mt.ToString()).Replace(".", ""));
                insertarReferencia(_recurse.idRecursamiento.ToString(),16);
            }
            else
            {
                lbConcepto.Text = "Pago de recursamiento intensivo por la asignatura de: " + _recurse.Asignatura;
                lbImporte.Text = "$ " + referencia.monto;
                lbReferencia.Text = referencia.referencia.ToString();
            }
        }
        private void insertarReferencia(string _descri, int _tp)
        {
            RG_SIA_GREFERENCIA referencia = new RG_SIA_GREFERENCIA();

            float l = float.Parse(lbImporte.Text.Substring(1));
            referencia.idTipoPago = _tp;
            referencia.idAlumno = matricula;
            referencia.referencia = long.Parse(lbReferencia.Text);
            referencia.fecha = code.hoy();
            referencia.monto = Math.Round(l, 2);
            referencia.descripcion = _descri;
            ctrlR.insert(referencia);
        }
        private string agrupar(string _id)
        {
            string pago, carr, matr;
            if (_id.Count() != 2)
            {
                pago = 0 + _id;
            }
            else
            {
                pago = _id;
            }

            try
            {
                switch (alumno.CT_SIA_GRUPO.CT_SIA_PROEDU.idPE)
                {
                    case "IE   ":
                        carr = "01";
                        break;
                    case "ILT  ":
                        carr = "02";
                        break;
                    case "IP   ":
                        carr = "03";
                        break;
                    case "ISIE ":
                        carr = "04";
                        break;
                    case "MGP  ":
                        carr = "05";
                        break;
                    default:
                        carr = "00";
                        break;
                }
                matr = code.matricula(matricula);
                if (des)
                {
                    return pago + carr + matr + 7;
                }
                else
                {
                    return pago + carr + matr;
                }
            }
            catch (Exception el)
            {
                string msg = el.Message;
                return "0000";
            }

        }
        private bool despresurizado(string _matricula)
        {
            bool d = false;
            foreach (char a in _matricula)
            {
                string b = a.ToString();
                if (b.Equals("D"))
                {
                    d = true;
                    break;
                }
                else
                {
                    d = false;
                }
            }
            return d;
        }
        private double mTotal(int _id)
        {
            double monto = ctrlTP.montoByID(_id);
            string cCosto = monto.ToString().Split('.')[1];
            if (cCosto.Length != 2)
            {
                monto = monto + 0.01;
            }
            return monto;

        }
    }
}