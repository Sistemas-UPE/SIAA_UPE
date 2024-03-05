using System;
using System.Collections.Generic;
using SIAA_UPE.CONTROL;
using SIAA_UPE.MODELO.entidades;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Runtime.InteropServices;
using System.IO;

namespace SIAA_UPE.admin
{
    public partial class cPNI : System.Web.UI.Page
    {
        
        ctrlAspirante ctrlA = new ctrlAspirante();
        ctrlGrupo ctrlG = new ctrlGrupo();
        ctrlAlumno ctrlAl = new ctrlAlumno();
        ctrlTipoPago ctrlTP = new ctrlTipoPago();
        ctrlCarrera ctrlC = new ctrlCarrera();
        ctrlPagoRealizado ctrPR = new ctrlPagoRealizado();
        decodificar ctrD = new decodificar();
        List<string> lista = new List<string>();
        List<RG_SIA_PAGOSREALIZADOS> pr = new List<RG_SIA_PAGOSREALIZADOS>();
        string nombre = "";


        protected void Page_Load(object sender, EventArgs e)
        {
            nombre = Session["UserName"] as string;
            lbUserName.Text = nombre;
            if (!IsPostBack)
            {
                llenar();
            }
        }
        private void llenar()
        {
           
            this.ddFiltro.DataSource = ctrlTP.selectByGrupo(1);
            this.ddCarrera.DataSource = ctrlC.select(0);
            this.ddFiltro.DataBind();
            this.ddCarrera.DataBind();

            this.ddFiltro.Items.Insert(0, "Seleccione Los tipos de pago a consultar");
            this.ddCarrera.Items.Insert(0, "Filtrar por plan de estudios");

            nAlu.Text = lista.Count.ToString();
            gridPagos();
        }

        protected void ddFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddFiltro.SelectedIndex == 0)
            {
                gridPagos();
                this.ddCarrera.Visible = false;
                this.ddGrupo.Visible = false;
            }
            else
            {
                gridPagos(int.Parse(ddFiltro.SelectedValue.ToString()));
                this.ddCarrera.Visible = true;
            }
        }

        protected void ddCarrera_SelectedIndexChanged(object sender, EventArgs e)
        {
            gridPagos(ddCarrera.SelectedValue.ToString(),int.Parse(ddFiltro.SelectedValue));
            this.ddGrupo.Visible = true;
        }

        protected void ddGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            gridPagos(ddCarrera.SelectedValue.ToString(), int.Parse(ddFiltro.SelectedValue),int.Parse(ddGrupo.SelectedItem.ToString()));

        }
        private void gridPagos()
        {
            pr = ctrPR.select();
            this.gv.DataSource = pr;
            this.gv.DataBind();
            nAlu.Text = pr.Count.ToString();
        }
        private void gridPagos(int _id)
        {
            try
            {
                pr = ctrPR.selectByTipo(_id);
                this.gv.DataSource = pr;
                this.gv.DataBind();
            }
            catch
            {
                this.gv.DataSource = pr;
                this.gv.DataBind();
            }
            nAlu.Text = pr.Count.ToString();
        }
        private void gridPagos(string _id, int _tp)
        {
            try
            {
                pr = ctrPR.selectByCarrera(_id, _tp);
                this.gv.DataSource = pr;
                this.gv.DataBind();
            }
            catch
            {
                this.gv.DataSource = pr;
                this.gv.DataBind();
            }
            nAlu.Text = pr.Count.ToString();
        }
        private void gridPagos(string _id, int _tp, int _gen)
        {
            try
            {
                pr = ctrPR.selectByGrupo(_id, _tp, _gen);
                this.gv.DataSource = pr;
                this.gv.DataBind();
            }
            catch
            {
                this.gv.DataSource = pr;
                this.gv.DataBind();
            }
            nAlu.Text = pr.Count.ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                ExcelPackage excel = new ExcelPackage();

                var workSheet = excel.Workbook.Worksheets.Add("Reporte001");

                workSheet.TabColor = System.Drawing.Color.Black;
                workSheet.DefaultRowHeight = 12;
                workSheet.Row(1).Height = 20;
                workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                workSheet.Row(1).Style.Font.Bold = true;
                workSheet.Cells[1, 1].Value = "FOLIO";
                workSheet.Cells[1, 2].Value = "MATRICULA";
                workSheet.Cells[1, 3].Value = "NOMBRE";
                workSheet.Cells[1, 4].Value = "TIPO";
                workSheet.Cells[1, 5].Value = "FECHA APLICADA";


                int ct = 2;
                int x = gv.Rows.Count;
                for (int iRow = 0; iRow < x; iRow++)
                {

                    workSheet.Cells[ct, 1].Value = gv.Rows[iRow].Cells[3].Text;
                    workSheet.Cells[ct, 2].Value = gv.Rows[iRow].Cells[4].Text;
                    workSheet.Cells[ct, 3].Value = gv.Rows[iRow].Cells[5].Text;
                    workSheet.Cells[ct, 4].Value = gv.Rows[iRow].Cells[6].Text;
                    workSheet.Cells[ct, 5].Value = gv.Rows[iRow].Cells[2].Text;
                    ct++;
                }
                workSheet.Column(1).AutoFit();
                workSheet.Column(2).AutoFit();
                workSheet.Column(3).AutoFit();
                workSheet.Column(4).AutoFit();
                workSheet.Column(5).AutoFit();
                int m= DateTime.Today.Month;
                int d= DateTime.Today.Day;
                int y= DateTime.Today.Year;

                 DateTime date1 = new DateTime(y,m,d);

                string p_strPath = "~//Reportes//" + date1.ToString("MM-dd-yyyy") + ".xlsx";

                if (File.Exists(p_strPath))
                    File.Delete(p_strPath);
                FileStream objFileStrm = File.Create(p_strPath);
                objFileStrm.Close();

                File.WriteAllBytes(p_strPath, excel.GetAsByteArray());
                excel.Dispose();
                Console.ReadKey();

            }
            catch(Exception ea) 
            {
                string m = ea.ToString();
            }
        }
    }
}                                                                                              