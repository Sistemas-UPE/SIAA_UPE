using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SIAA_UPE.CONTROL;
using SIAA_UPE.MODELO.entidades;

namespace SIAA_UPE.EVCD
{
    public partial class Ev01 : System.Web.UI.Page
    {
        ctrlDTLAD ctrlAD = new ctrlDTLAD();
        ctrlEVDOC ctrlEV = new ctrlEVDOC();
        CA_SIA_DTLAD ad = new CA_SIA_DTLAD();
        ED_SIA_EVDOC ev = new ED_SIA_EVDOC();

        string idPE, idGR,nombre;
        protected void Page_Load(object sender, EventArgs e)
        {

            idPE = (string)Session["idCarrera"];
            idGR = (string)Session["idGrupo"];
            nombre = Session["UserName"] as string;
            if(nombre!=null)
                lbUserName.Text = nombre;
            else
                this.Response.Redirect("~/login.aspx");

            if (!IsPostBack)
            {
                lbGrupo.Text = idGR;

                this.ddDocente.DataSource = ctrlAD.selectDxG(idGR);
                this.ddDocente.DataBind();
                this.ddDocente.Items.Insert(0, "Selecciona a un Docente");
            }
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            ED_SIA_EVDOC v = this.llena();
            string x = "";
            int y = 0;
            if (ev.p01 == 0)
            {
                y++;
                x = " - 1";
            }
            if (ev.p02 == 0)
            {
                y++;
                x = x + " - 2";
            }
            if (ev.p03 == 0)
            {
                y++;
                x = x + " - 3";
            }
            if (ev.p03 == 0)
            {
                y++;
                x = x + " - 3";
            }
            if (ev.p04 == 0)
            {
                y++;
                x = x + " - 4";
            }
            if (ev.p05 == 0)
            {
                y++;
                x = x + " - 5";
            }
            if (ev.p06 == 0)
            {
                y++;
                x = x + " - 6";
            }
            if (ev.p07 == 0)
            {
                y++;
                x = x + " - 7";
            }
            if (ev.p08 == 0)
            {
                y++;
                x = x + " - 8";
            }
            if (ev.p09 == 0)
            {
                y++;
                x = x + " - 9";
            }
            if (ev.p10 == 0)
            {
                y++;
                x = x + " - 10";
            }
            if (ev.p11 == 0)
            {
                y++;
                x = x + " - 11";
            }
            if (ev.p12 == 0)
            {
                y++;
                x = x + " - 12";
            }
            if (ev.p13 == 0)
            {
                y++;
                x = x + " - 13";
            }
            if (ev.p14 == 0)
            {
                y++;
                x = x + " - 14";
            }
            if (ev.p15 == 0)
            {
                y++;
                x = x + " - 15";
            }
            if (ev.p16 == 0)
            {
                y++;
                x = x + " - 16";
            }
            if (ev.p17 == 0)
            {
                y++;
                x = x + " - 17";
            }
            if (ev.p18 == 0)
            {
                y++;
                x = x + " - 18";
            }
            if (ev.p19 == 0)
            {
                y++;
                x = x + " - 19";
            }
            if (ev.p20 == 0)
            {
                y++;
                x = x + " - 20";
            }
            if (ev.p21 == 0)
            {
                y++;
                x = x + " - 21";
            }
            if (ev.p22 == 0)
            {
                y++;
                x = x + " - 22";
            }
            if (ev.p23 == 0)
            {
                y++;
                x = x + " - 23";
            }
            if (ev.p24 == 0)
            {
                y++;
                x = x + " - 24";
            }
            if (ev.p25 == 0)
            {
                y++;
                x = x + " - 25";
            }
            if (ev.p26 == 0)
            {
                y++;
                x = x + " - 26";
            }
            if (ev.p27 == 0)
            {
                y++;
                x = x + " - 27";
            }
            if (ev.p28 == 0)
            {
                y++;
                x = x + " - 28";
            }
            if (y == 0)
            {
                try
                {
                    Boolean inset = ctrlEV.insertEva(v);

                    if (ddDocente.Items.Count == 2)
                    {
                        lbMsg.Text = "La evaluación se guardó con éxito: <br/> Has evaluado a todos tus docentes, Agradecemos tu tiempo, excelente Día.  :D";

                    }
                    else
                    {
                        lbMsg.Text = "La evaluación se guardó con éxito";
                    }
                    divPCon.Visible = true;

                }
                catch
                {
                }

            }
            else
            {
                lbEstado.Text = "Por favor contesta las siguientes preguntas: <br /> " + x + " -";
            }
        }

        protected void btnpop_Click(object sender, EventArgs e)
        {
            this.divPop.Visible = false;
        }
        protected void btnDivCon_Click(object sender, EventArgs e)
        {
            limpiarForm();
            ddDocente.Items.Remove(ddDocente.SelectedItem);

            if (ddDocente.Items.Count == 1)
            {
                this.Response.Redirect("acceso.aspx");
            }
        }
        private ED_SIA_EVDOC llena()
        {
            try
            {
                ad = ctrlAD.selecAD(int.Parse(this.ddDocente.SelectedValue));
                ev.idDtlMM = ad.idDtlAD;
            }
            catch { }
            //P1

            if (rb011.Checked)
            {
                ev.p01 = 1;
            }
            else if (rb012.Checked)
            {
                ev.p01 = 2;
            }
            else if (rb013.Checked)
            {
                ev.p01 = 3;
            }
            else if (rb014.Checked)
            {
                ev.p01 = 4;
            }
            else if (rb015.Checked)
            {
                ev.p01 = 5;
            }

            //P2
            if (rb021.Checked)
            {
                ev.p02 = 1;
            }
            else if (rb022.Checked)
            {
                ev.p02 = 2;
            }
            else if (rb023.Checked)
            {
                ev.p02 = 3;
            }
            else if (rb024.Checked)
            {
                ev.p02 = 4;
            }
            else if (rb025.Checked)
            {
                ev.p02 = 5;
            }
            //P3
            if (rb031.Checked)
            {
                ev.p03 = 1;
            }
            else if (rb032.Checked)
            {
                ev.p03 = 2;
            }
            else if (rb033.Checked)
            {
                ev.p03 = 3;
            }
            else if (rb034.Checked)
            {
                ev.p03 = 4;
            }
            else if (rb035.Checked)
            {
                ev.p03 = 5;
            }
            //P4
            if (rb041.Checked)
            {
                ev.p04 = 1;
            }
            else if (rb042.Checked)
            {
                ev.p04 = 2;
            }
            else if (rb043.Checked)
            {
                ev.p04 = 3;
            }
            else if (rb044.Checked)
            {
                ev.p04 = 4;
            }
            else if (rb045.Checked)
            {
                ev.p04 = 5;
            }
            //P05
            if (rb051.Checked)
            {
                ev.p05 = 1;
            }
            else if (rb052.Checked)
            {
                ev.p05 = 2;
            }
            else if (rb053.Checked)
            {
                ev.p05 = 3;
            }
            else if (rb054.Checked)
            {
                ev.p05 = 4;
            }
            else if (rb055.Checked)
            {
                ev.p05 = 5;
            }
            //P06
            if (rb061.Checked)
            {
                ev.p06 = 1;
            }
            else if (rb062.Checked)
            {
                ev.p06 = 2;
            }
            else if (rb063.Checked)
            {
                ev.p06 = 3;
            }
            else if (rb064.Checked)
            {
                ev.p06 = 4;
            }
            else if (rb065.Checked)
            {
                ev.p06 = 5;
            }
            //P07
            if (rb071.Checked)
            {
                ev.p07 = 1;
            }
            else if (rb072.Checked)
            {
                ev.p07 = 2;
            }
            else if (rb073.Checked)
            {
                ev.p07 = 3;
            }
            else if (rb074.Checked)
            {
                ev.p07 = 4;
            }
            else if (rb075.Checked)
            {
                ev.p07 = 5;
            }

            //P08
            if (rb081.Checked)
            {
                ev.p08 = 1;
            }
            else if (rb082.Checked)
            {
                ev.p08 = 2;
            }
            else if (rb083.Checked)
            {
                ev.p08 = 3;
            }
            else if (rb084.Checked)
            {
                ev.p08 = 4;
            }
            else if (rb085.Checked)
            {
                ev.p08 = 5;
            }

            //P09
            if (rb091.Checked)
            {
                ev.p09 = 1;
            }
            else if (rb092.Checked)
            {
                ev.p09 = 2;
            }
            else if (rb093.Checked)
            {
                ev.p09 = 3;
            }
            else if (rb094.Checked)
            {
                ev.p09 = 4;
            }
            else if (rb095.Checked)
            {
                ev.p09 = 5;
            }

            //P10
            if (rb101.Checked)
            {
                ev.p10 = 1;
            }
            else if (rb102.Checked)
            {
                ev.p10 = 2;
            }
            else if (rb103.Checked)
            {
                ev.p10 = 3;
            }
            else if (rb104.Checked)
            {
                ev.p10 = 4;
            }
            else if (rb105.Checked)
            {
                ev.p10 = 5;
            }
            //P11
            if (rb111.Checked)
            {
                ev.p11 = 1;
            }
            else if (rb112.Checked)
            {
                ev.p11 = 2;
            }
            else if (rb113.Checked)
            {
                ev.p11 = 3;
            }
            else if (rb114.Checked)
            {
                ev.p11 = 4;
            }
            else if (rb115.Checked)
            {
                ev.p11 = 5;
            }
            //P12
            if (rb121.Checked)
            {
                ev.p12 = 1;
            }
            else if (rb122.Checked)
            {
                ev.p12 = 2;
            }
            else if (rb123.Checked)
            {
                ev.p12 = 3;
            }
            else if (rb124.Checked)
            {
                ev.p12 = 4;
            }
            else if (rb125.Checked)
            {
                ev.p12 = 5;
            }

            //P13
            if (rb131.Checked)
            {
                ev.p13 = 1;
            }
            else if (rb132.Checked)
            {
                ev.p13 = 2;
            }
            else if (rb133.Checked)
            {
                ev.p13 = 3;
            }
            else if (rb134.Checked)
            {
                ev.p13 = 4;
            }
            else if (rb135.Checked)
            {
                ev.p13 = 5;
            }

            //P14
            if (rb141.Checked)
            {
                ev.p14 = 1;
            }
            else if (rb142.Checked)
            {
                ev.p14 = 2;
            }
            else if (rb143.Checked)
            {
                ev.p14 = 3;
            }
            else if (rb144.Checked)
            {
                ev.p14 = 4;
            }
            else if (rb145.Checked)
            {
                ev.p14 = 5;
            }

            //P15
            if (rb151.Checked)
            {
                ev.p15 = 1;
            }
            else if (rb152.Checked)
            {
                ev.p15 = 2;
            }
            else if (rb153.Checked)
            {
                ev.p15 = 3;
            }
            else if (rb154.Checked)
            {
                ev.p15 = 4;
            }
            else if (rb155.Checked)
            {
                ev.p15 = 5;
            }

            //P16
            if (rb161.Checked)
            {
                ev.p16 = 1;
            }
            else if (rb162.Checked)
            {
                ev.p16 = 2;
            }
            else if (rb163.Checked)
            {
                ev.p16 = 3;
            }
            else if (rb164.Checked)
            {
                ev.p16 = 4;
            }
            else if (rb165.Checked)
            {
                ev.p16 = 5;
            }

            //P17
            if (rb171.Checked)
            {
                ev.p17 = 1;
            }
            else if (rb172.Checked)
            {
                ev.p17 = 2;
            }
            else if (rb173.Checked)
            {
                ev.p17 = 3;
            }
            else if (rb174.Checked)
            {
                ev.p17 = 4;
            }
            else if (rb175.Checked)
            {
                ev.p17 = 5;
            }
            //P18
            if (rb181.Checked)
            {
                ev.p18 = 1;
            }
            else if (rb182.Checked)
            {
                ev.p18 = 2;
            }
            else if (rb183.Checked)
            {
                ev.p18 = 3;
            }
            else if (rb184.Checked)
            {
                ev.p18 = 4;
            }
            else if (rb185.Checked)
            {
                ev.p18 = 5;
            }

            //P19
            if (rb191.Checked)
            {
                ev.p19 = 1;
            }
            else if (rb192.Checked)
            {
                ev.p19 = 2;
            }
            else if (rb193.Checked)
            {
                ev.p19 = 3;
            }
            else if (rb194.Checked)
            {
                ev.p19 = 4;
            }
            else if (rb195.Checked)
            {
                ev.p19 = 5;
            }

            //P20
            if (rb201.Checked)
            {
                ev.p20 = 1;
            }
            else if (rb202.Checked)
            {
                ev.p20 = 2;
            }
            else if (rb203.Checked)
            {
                ev.p20 = 3;
            }
            else if (rb204.Checked)
            {
                ev.p20 = 4;
            }
            else if (rb205.Checked)
            {
                ev.p20 = 5;
            }

            //P21
            if (rb211.Checked)
            {
                ev.p21 = 1;
            }
            else if (rb212.Checked)
            {
                ev.p21 = 2;
            }
            else if (rb213.Checked)
            {
                ev.p21 = 3;
            }
            else if (rb214.Checked)
            {
                ev.p21 = 4;
            }
            else if (rb215.Checked)
            {
                ev.p21 = 5;
            }
            //P22
            if (rb221.Checked)
            {
                ev.p22 = 1;
            }
            else if (rb222.Checked)
            {
                ev.p22 = 2;
            }
            else if (rb223.Checked)
            {
                ev.p22 = 3;
            }
            else if (rb224.Checked)
            {
                ev.p22 = 4;
            }
            else if (rb225.Checked)
            {
                ev.p22 = 5;
            }

            //P23
            if (rb231.Checked)
            {
                ev.p23 = 1;
            }
            else if (rb232.Checked)
            {
                ev.p23 = 2;
            }
            else if (rb233.Checked)
            {
                ev.p23 = 3;
            }
            else if (rb234.Checked)
            {
                ev.p23 = 4;
            }
            else if (rb235.Checked)
            {
                ev.p23 = 5;
            }

            //P24
            if (rb241.Checked)
            {
                ev.p24 = 1;
            }
            else if (rb242.Checked)
            {
                ev.p24 = 2;
            }
            else if (rb243.Checked)
            {
                ev.p24 = 3;
            }
            else if (rb244.Checked)
            {
                ev.p24 = 4;
            }
            else if (rb245.Checked)
            {
                ev.p24 = 5;
            }

            //P25
            if (rb251.Checked)
            {
                ev.p25 = 1;
            }
            else if (rb252.Checked)
            {
                ev.p25 = 2;
            }
            else if (rb253.Checked)
            {
                ev.p25 = 3;
            }
            else if (rb254.Checked)
            {
                ev.p25 = 4;
            }
            else if (rb255.Checked)
            {
                ev.p25 = 5;
            }

            //P26
            if (rb261.Checked)
            {
                ev.p26 = 1;
            }
            else if (rb262.Checked)
            {
                ev.p26 = 2;
            }
            else if (rb263.Checked)
            {
                ev.p26 = 3;
            }
            else if (rb264.Checked)
            {
                ev.p26 = 4;
            }
            else if (rb265.Checked)
            {
                ev.p26 = 5;
            }

            //P27
            if (rb271.Checked)
            {
                ev.p27 = 1;
            }
            else if (rb272.Checked)
            {
                ev.p27 = 2;
            }
            else if (rb273.Checked)
            {
                ev.p27 = 3;
            }
            else if (rb274.Checked)
            {
                ev.p27 = 4;
            }
            else if (rb275.Checked)
            {
                ev.p27 = 5;
            }

            //P28
            if (rb281.Checked)
            {
                ev.p28 = 1;
            }
            else if (rb282.Checked)
            {
                ev.p28 = 2;
            }
            else if (rb283.Checked)
            {
                ev.p28 = 3;
            }
            else if (rb284.Checked)
            {
                ev.p28 = 4;
            }
            else if (rb285.Checked)
            {
                ev.p28 = 5;
            }
            ev.coment = txtComentario.Text;
            return ev;
        }

        protected void ddDocente_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ad = ctrlAD.selecAD(int.Parse(this.ddDocente.SelectedValue));
                lbNDocente.Text = ad.FD_SIA_DOCENTE.NDocente;
                lbMateria.Text = ad.CA_SIA_ASIGNATURA.nomAsignatura;
            }
            catch
            {
                lbNDocente.Text = "";
                lbMateria.Text = "";
            }
        }

        private void limpiarForm()
        {
            rb011.Checked = false;
            rb012.Checked = false;
            rb013.Checked = false;
            rb014.Checked = false;
            rb015.Checked = false;
            rb021.Checked = false;
            rb022.Checked = false;
            rb023.Checked = false;
            rb024.Checked = false;
            rb025.Checked = false;
            rb031.Checked = false;
            rb032.Checked = false;
            rb033.Checked = false;
            rb034.Checked = false;
            rb035.Checked = false;
            rb041.Checked = false;
            rb042.Checked = false;
            rb043.Checked = false;
            rb044.Checked = false;
            rb045.Checked = false;
            rb051.Checked = false;
            rb052.Checked = false;
            rb053.Checked = false;
            rb054.Checked = false;
            rb055.Checked = false;
            rb061.Checked = false;
            rb062.Checked = false;
            rb063.Checked = false;
            rb064.Checked = false;
            rb065.Checked = false;
            rb071.Checked = false;
            rb072.Checked = false;
            rb073.Checked = false;
            rb074.Checked = false;
            rb075.Checked = false;
            rb081.Checked = false;
            rb082.Checked = false;
            rb083.Checked = false;
            rb084.Checked = false;
            rb085.Checked = false;
            rb091.Checked = false;
            rb092.Checked = false;
            rb093.Checked = false;
            rb094.Checked = false;
            rb095.Checked = false;
            rb101.Checked = false;
            rb102.Checked = false;
            rb103.Checked = false;
            rb104.Checked = false;
            rb105.Checked = false;
            rb111.Checked = false;
            rb112.Checked = false;
            rb113.Checked = false;
            rb114.Checked = false;
            rb115.Checked = false;
            rb121.Checked = false;
            rb122.Checked = false;
            rb123.Checked = false;
            rb124.Checked = false;
            rb125.Checked = false;
            rb131.Checked = false;
            rb132.Checked = false;
            rb133.Checked = false;
            rb134.Checked = false;
            rb135.Checked = false;
            rb141.Checked = false;
            rb142.Checked = false;
            rb143.Checked = false;
            rb144.Checked = false;
            rb145.Checked = false;
            rb151.Checked = false;
            rb152.Checked = false;
            rb153.Checked = false;
            rb154.Checked = false;
            rb155.Checked = false;
            rb161.Checked = false;
            rb162.Checked = false;
            rb163.Checked = false;
            rb164.Checked = false;
            rb165.Checked = false;
            rb171.Checked = false;
            rb172.Checked = false;
            rb173.Checked = false;
            rb174.Checked = false;
            rb175.Checked = false;
            rb181.Checked = false;
            rb182.Checked = false;
            rb183.Checked = false;
            rb184.Checked = false;
            rb185.Checked = false;
            rb191.Checked = false;
            rb192.Checked = false;
            rb193.Checked = false;
            rb194.Checked = false;
            rb195.Checked = false;
            rb201.Checked = false;
            rb202.Checked = false;
            rb203.Checked = false;
            rb204.Checked = false;
            rb205.Checked = false;
            rb211.Checked = false;
            rb212.Checked = false;
            rb213.Checked = false;
            rb214.Checked = false;
            rb215.Checked = false;
            rb221.Checked = false;
            rb222.Checked = false;
            rb223.Checked = false;
            rb224.Checked = false;
            rb225.Checked = false;
            rb231.Checked = false;
            rb232.Checked = false;
            rb233.Checked = false;
            rb234.Checked = false;
            rb235.Checked = false;
            rb241.Checked = false;
            rb242.Checked = false;
            rb243.Checked = false;
            rb244.Checked = false;
            rb245.Checked = false;
            rb251.Checked = false;
            rb252.Checked = false;
            rb253.Checked = false;
            rb254.Checked = false;
            rb255.Checked = false;
            rb261.Checked = false;
            rb262.Checked = false;
            rb263.Checked = false;
            rb264.Checked = false;
            rb265.Checked = false;
            rb271.Checked = false;
            rb272.Checked = false;
            rb273.Checked = false;
            rb274.Checked = false;
            rb275.Checked = false;
            rb281.Checked = false;
            rb282.Checked = false;
            rb283.Checked = false;
            rb284.Checked = false;
            rb285.Checked = false;
            lbEstado.Text = "";
            lbMateria.Text = "";
            lbNDocente.Text = "";
            txtComentario.Text = "";

        }
    }
}