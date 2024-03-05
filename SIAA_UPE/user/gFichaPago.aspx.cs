using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using SIAA_UPE.CONTROL;
using SIAA_UPE.MODELO.entidades;

namespace SIAA_UPE.user
{
    public partial class gFichaPago : System.Web.UI.Page
        {
        static string matricula;
        ctrlTipoPago ctrlTP = new ctrlTipoPago();
        ctrlAlumno ctrlAl = new ctrlAlumno();
        ctrlReferencia ctrlR = new ctrlReferencia();
        ctrlPagoRealizado ctrlPagos = new ctrlPagoRealizado();
        codificar code = new codificar();
        FD_SIA_ALUMNO alumno = new FD_SIA_ALUMNO();
        RG_SIA_GREFERENCIA referencia = new RG_SIA_GREFERENCIA();
        CT_SIA_TIPOPAGO tipo = new CT_SIA_TIPOPAGO();
        List<CT_SIA_TIPOPAGO> lisTipo = new List<CT_SIA_TIPOPAGO>();

        int idP;
        string[] fecha;
        string[] hoy = new string[] { DateTime.Today.Day.ToString(), DateTime.Today.Month.ToString(), DateTime.Today.Year.ToString()};
            
        string[] fechaLimite;
        bool des;
        double practicaja, ventanilla;
        int day = DateTime.Today.Day;
        int mont = DateTime.Today.Month;

        protected void Page_Load(object sender, EventArgs e)
        {
            lisTipo = ctrlTP.select();
            fecha = code.fecha();
            ventanilla = double.Parse(lisTipo[25].costo.ToString());
            practicaja = double.Parse(lisTipo[26].costo.ToString());
            try
            {
                matricula = Session["user"] as string;
                des = despresurizado(matricula);
                alumno = ctrlAl.alumno(matricula);
                lbUserName.Text = alumno.NAlumno;
            }
            catch (Exception ex)
            {

                string a = ex.Message;
                Response.Redirect("../login.aspx");

            }
            if (!IsPostBack)
            {
                llenar();
            }
   
        }
        private bool despresurizado(string _matricula)
        {
            bool d=false;
            foreach (char a in _matricula)
            {
                string b = a.ToString();
                if (b.Equals("D"))
                {
                    d =true;
                    break;
                }
                else
                {
                    d= false;
                }
            }
            return d;
        }
        protected void btn_Click(object sender, EventArgs e)
        {
            int a = int.Parse(Session["idPago"].ToString());

            if (!rbPago.SelectedValue.Equals(""))
            {
                this.divConfirmacion.Visible = false;
                this.divFicha.Visible = true;
                btn.Visible = false;
                
                double costo = double.Parse(lbTotalR.Text.Substring(1));

                lbNombre.Text = alumno.NAlumno;
                lbConcepto.Text = lisTipo[a].concepto;
                fechaLimite = fechaString( lisTipo[a].vigenciaFinal);
                lbdias.Text = "3 días";

                if (rbPago.SelectedValue.Equals("ptc"))
                {
                    costo = costo + practicaja;
                }
                else if (rbPago.SelectedValue.Equals("vtn"))
                {
                    costo = costo + ventanilla;
                }

                costo = (Math.Round(costo,2));
                string cCosto = costo.ToString().Split('.')[1];
                if (cCosto.Length != 2)
                {
                    costo = costo + 0.01;
                }
                lbImporte.Text = "$ " + costo;


                if (int.Parse(fecha[2]) <= int.Parse(fechaLimite[2]))
                {
                    if (int.Parse(fecha[1]) <= int.Parse(fechaLimite[1]))
                    {
                        if (int.Parse(fecha[0]) <= int.Parse(fechaLimite[0]))
                        {
                            lbReferencia.Text = code.llamar(agrupar((1 + a).ToString()), fecha, (costo.ToString()).Replace(".", ""));
                        }
                        else
                        {

                            if (day > int.Parse(fechaLimite[0]))
                                lbReferencia.Text = code.llamar(agrupar((1 + a).ToString()), fecha, (costo.ToString()).Replace(".", ""));

                            else
                                lbReferencia.Text = code.llamar(agrupar((1 + a).ToString()), fechaLimite, (costo.ToString()).Replace(".", ""));
                        }
                    }
                    else
                    {
                        lbReferencia.Text = code.llamar(agrupar((1 + a).ToString()), hoy, (costo.ToString()).Replace(".", ""));
                        lbdias.Text = "1 día";
                    }
                }
                
                insertar(a);
                lbError.Text = "";
                lbError.Visible = false;

            }
            else
            {
                lbError.Text = "Porfavor seleccione algun Metodos de pago";
            }

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
                    case "btn26":
                        this.Response.Redirect("~/user/tutoriales.aspx");
                        //Session["UserName"] = lbUserName.Text;

                        break;
            }
                lbConceptoR.Text = lisTipo[idP].concepto;
                lbTotalR.Text = "$ " + monto(idP);
                Session ["idPago"] = idP;
                fechaLimite = fechaString(lisTipo[idP].vigenciaFinal);
                string f = fecha[0] + " / " + fecha[1] + " / " + fecha[2];
                string fM = fechaLimite[0] + " / " + fechaLimite[1] + " / " + fechaLimite[2];

                if (int.Parse(fecha[2]) <= int.Parse(fechaLimite[2]))
                    if (int.Parse(fecha[1]) <= int.Parse(fechaLimite[1]))
                    {
                        if (int.Parse(fecha[0]) <= int.Parse(fechaLimite[0]))
                        {
                            lbFechaR.Text = f;
                            lbFecha.Text = f;
                        }
                        else
                        {
                            if (day > int.Parse(fechaLimite[0]))
                            {
                                lbFechaR.Text = f;
                                lbFecha.Text = f;
                            }
                            else
                            {
                                lbFechaR.Text = fM;
                                lbFecha.Text = fM;
                            }
                        }
                    }
                    else
                    {
                        f= hoy[0] + " / " + hoy[1] + " / " + hoy[2];
                        lbFechaR.Text = f;
                        lbFecha.Text = f;
                    }


            this.idImprimeme.Visible = true;
            }
            catch (Exception ex)
            {
                string a = ex.Message;
            }
        }
        private void llenar()
        {
            mostrarMenu(listaPagosV());
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

            switch (alumno.CT_SIA_GRUPO.CT_SIA_PROEDU.nomProEdu)
            {
                case "INGENIERÍA EN ENERGÍA                             ":
                    carr = "01";
                    break;
                case "INGENIERÍA EN LOGÍSTICA Y TRANSPORTE              ":
                    carr = "02";
                    break;
                case "INGENIERÍA PETROLERA                              ":
                    carr = "03";
                    break;
                case "INGENIERÍA SEGURIDAD PARA LA INDUSTRIA ENERGÉTICA ":
                    carr = "04";
                    break;
                case "MAESTRÍA EN GESTIÓN DEL PETRÓLEO                  ":
                    carr = "05";
                    break;
                default:
                    carr = "00";
                    break;
            }
            

            matr = code.matricula(matricula);
            if (des)
            {
                return pago + carr + matr+7;
            }
            else
            {
                return pago + carr + matr;
            }


        }
        private string monto(int _id)
        {
            double costo = double.Parse(lisTipo[_id].costo.ToString());
            op1.Text = "Pago en ventanilla bancaria $ " + ventanilla;
            op2.Text = "Medios electronicos (Transferencia,Pago en linea, Practi-caja) $ "+practicaja;
            if(recargo(_id))
            {
                double recargo = double.Parse(lisTipo[24].costo.ToString());
                costo = costo + recargo;
                lbT.Text = "Importe total + (RECARGO POR PAGO TARDIO): ";
                lbMsj.Text = "(RECARGO POR PAGO TARDIO)";
            }
            return costo.ToString();
        }
        private void insertar(int _a)
        {
            float l = float.Parse(lbImporte.Text.Substring(1));

            referencia.referencia = long.Parse(lbReferencia.Text);
            referencia.idTipoPago = lisTipo[_a].idTipoPago;
            referencia.fecha = code.hoy();
            referencia.idAlumno = matricula;
            referencia.monto = Math.Round(l,2);
            ctrlR.insert(referencia);
        }
        private void mostrarMenu(List<int> _ls)
        {
            foreach (int id in _ls)
            {
                switch (id)
                {
                    case 1:
                        this.pg01.Visible = true;
                        break;
                    case 2:
                        this.pg02.Visible = true;
                        break;
                    case 3:
                        this.pg03.Visible = true;
                        break;
                    case 4:
                        this.pg04.Visible = true;
                        break;
                    case 5:
                        this.pg05.Visible = true;
                        break;
                    case 6:
                        this.pg06.Visible = true;
                        break;
                    case 7:
                        this.pg07.Visible = true;
                        break;
                    case 8:
                        this.pg08.Visible = true;
                        break;
                    case 9:
                        this.pg09.Visible = true;
                        break;
                    case 10:
                        this.pg10.Visible = true;
                        break;
                    case 11:
                        this.pg11.Visible = true;
                        break;
                    case 12:
                        this.pg12.Visible = true;
                        break;
                    case 13:
                        this.pg13.Visible = true;
                        break;
                    case 14:
                        this.pg14.Visible = true;
                        break;
                    case 15:
                        this.pg15.Visible = true;
                        break;
                    case 16:
                        this.pg16.Visible = true;
                        break;
                    case 17:
                        this.pg17.Visible = true;
                        break;
                    case 18:
                        this.pg18.Visible = true;
                        break;
                    case 19:
                        this.pg19.Visible = true;
                        break;
                    case 20:
                        this.pg20.Visible = true;
                        break;
                    case 21:
                        this.pg21.Visible = true;
                        break;
                    case 22:
                        this.pg22.Visible = true;
                        break;
                    case 23:
                        this.pg23.Visible = true;
                        break;
                    case 24:
                        this.pg24.Visible = true;
                        break;
                    case 25:
                        this.pg25.Visible = true;
                        break;
                }
            }
        }
        private List<int> listaPagosV()
        {
            int day = int.Parse(hoy[0]);
            int month = int.Parse(hoy[1]);
            int year = int.Parse(hoy[2]);
            List<int> ls = new List<int>();

            foreach (CT_SIA_TIPOPAGO tp in lisTipo)
            {
                try
                {
                    List<int> fi = fechaInt(tp.vigenciaInicio);
                    List<int> ff = fechaInt(tp.vigenciaFinal);
                    if(year >= fi[0])
                    {
                        if(month >= fi[1] &&  month <= ff[1])
                        {
                            if(day >= fi[2] && day <= ff[2])
                            {
                                if(tp.grupo==1)
                                    ls.Add(tp.idTipoPago);
                            }
                            else if (tp.recargos.Equals("True "))
                            {
                                ls.Add(tp.idTipoPago);
                            }
                        }
                        else if (tp.recargos.Equals("True "))
                        {
                            ls.Add(tp.idTipoPago);
                        }
                        else if (year<ff[0])
                        {
                            ls.Add(tp.idTipoPago);
                        }
                    }
                }
                catch
                { }
            }
            return ls;
        }
        private List<int> fechaInt(string _fecha)
        {
            List<int> ls = new List<int>();
            ls.Add(int.Parse(_fecha.Substring(0,4)));
            ls.Add(int.Parse(_fecha.Substring(5,2)));
            ls.Add(int.Parse(_fecha.Substring(8,2)));
            return ls;
        }
        private string[] fechaString(string _fecha)
        {
            string[] ls = new string[3];
            ls[2]=_fecha.Substring(0, 4);
            ls[1]=_fecha.Substring(5, 2);
            ls[0]=_fecha.Substring(8, 2);
            return ls;
        }
        private Boolean recargo(int _id)
        {
            try
            {
                fechaLimite = fechaString(lisTipo[_id].vigenciaFinal);
                if (lisTipo[_id].recargos.Equals("True ") && day > int.Parse(fechaLimite[0]))
                {
                    lbT.ForeColor=System.Drawing.Color.DarkRed;
                    lbMsj.ForeColor = System.Drawing.Color.DarkRed;
                    return true;
                }
                else if (lisTipo[_id].recargos.Equals("True ") && mont > int.Parse(fechaLimite[1]))
                {
                    lbT.ForeColor = System.Drawing.Color.DarkRed;
                    lbMsj.ForeColor = System.Drawing.Color.DarkRed;
                    return true;
                }
                else
                {
                    return false;

                }
            }
            catch
            {
                return false;
            }
        }
    }
}