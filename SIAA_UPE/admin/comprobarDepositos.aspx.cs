using System;
using System.Collections.Generic;
using System.IO;
using SIAA_UPE.CONTROL;
using SIAA_UPE.MODELO.entidades;

namespace SIAA_UPE.admin
{
    public partial class comprobarDepositos : System.Web.UI.Page
    {
        static List<decodifica> lista = new List<decodifica>();
        static decodificar dec = new decodificar();
        ctrlPagoRealizado ctrlPagos = new ctrlPagoRealizado();
        string nombre, msg, color;

        protected void Page_Load(object sender, EventArgs e)
        {
            nombre = Session["UserName"] as string;
            lbUserName.Text = nombre;
        }

        protected void btnComprobar_Click(object sender, EventArgs e){
            if(btnComprobar.Text.Equals("COMPROBAR")){
                llenar();
                if (lista.Count != 0){
                    this.gv.DataSource = lista;
                    this.gv.DataBind();
                    btnComprobar.Text = "GUARDAR";
                    this.fcFile.Visible = false;
                }
            }
            else{
                try{
                    int s = 0;
                    bool p;
                    foreach (var item in lista)
                    {
                        if (item.Matricula.Substring(0, 1).Equals("F")){
                            if (ctrlPagos.selectByReferenciaAL(item.IdR))p = false;
                            else{
                                RG_SIA_PAGOSREALIZADOS_ALUM pgrAspi = new RG_SIA_PAGOSREALIZADOS_ALUM();
                                pgrAspi.idGREFERENCIA = item.IdR;
                                pgrAspi.fechaAplicada = fechaHoy();
                                pgrAspi.folio = "PA-" + (item.IdR).ToString();
                                p = ctrlPagos.inserASp(pgrAspi);
                            }
                        }
                        else{
                            if (ctrlPagos.selectByReferencia(item.IdR))p = false;
                            else {
                                if(ctrlPagos.selectIsRecursamiento(item.IdR))
                                {
                                    ctrlPagos.recursePagado(int.Parse(item.Descripcion));
                                    p = true;
                                }
                                else
                                {
                                    RG_SIA_PAGOSREALIZADOS pgr = new RG_SIA_PAGOSREALIZADOS();
                                    pgr.idGREFERENCIA = item.IdR;
                                    pgr.fechaAplicada = fechaHoy();
                                    pgr.folio = "PA-" + (item.IdR).ToString();
                                    p = ctrlPagos.inser(pgr);
                                }
                            }
                        }
                        if (p) { s++; }
                    }
                    if (s == 0){
                        msg = "La informacion ya fue cargada con Anterioridad.";
                        color = "rgba(255, 165, 0, 0.7)";
                    }
                    else{
                        msg = "Información Cargada correctamente.";
                        color = "rgba(0, 128, 0, 0.7)";
                    }
                    toast(color, msg);
                }
                catch{
                    msg = "Ocurrió un error, Favor de Intentar más tarde.";
                    color = "rgba(166, 32, 67, 0.7)";
                }
            }
        }
        private List<decodifica> llenar()
        {
            StreamReader reader = new StreamReader(fcFile.FileContent);
            lista = dec.decoFile(reader);
            reader.DiscardBufferedData();
            reader.Close();
            return lista;
        }
        private DateTime fechaHoy()
        {
            string dia = DateTime.Now.Day.ToString();
            string mes = DateTime.Now.Month.ToString();
            string anio = DateTime.Now.Year.ToString();
            return DateTime.Parse(anio + "-" + mes + "-" + dia);
        }
        private void toast(string _color, string _msg)
        {
            lbToast.Text = _msg;
            this.divToast.Style.Add("background-color", _color);
            this.divToast.Visible = true;
        }

    }
}