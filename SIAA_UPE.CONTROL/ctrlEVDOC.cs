using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIAA_UPE.MODELO.entidades;

namespace SIAA_UPE.CONTROL
{
    public class ctrlEVDOC
    {
        DBDataContext db = new DBDataContext();
        ctrlDocente ctrlD = new ctrlDocente();

        public Boolean insertEva(ED_SIA_EVDOC _evdc)
        {
            try
            {
                this.db.ED_SIA_EVDOC.InsertOnSubmit(_evdc);
                this.db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<ED_SIA_EVDOC> selecEV_All()
        {
            try
            {

                List<ED_SIA_EVDOC> lsEV = this.db.ED_SIA_EVDOC.ToList();
                return lsEV;
            }
            catch (Exception ex)
            {
                string smg = ex.Message;

                return null;
            }
        }
        public List<CA_SIA_DTLAD> selecDA_All()
        {
            try
            {

                List<CA_SIA_DTLAD> lsEV = this.db.CA_SIA_DTLAD.ToList();
                return lsEV;
            }
            catch (Exception ex)
            {
                string smg = ex.Message;

                return null;
            }
        }
        public List<ED_SIA_EVDOC> selecEV_BY(string _id)
        {
            try
            {

                List<ED_SIA_EVDOC> lsEV = this.db.ED_SIA_EVDOC.Where(p => p.CA_SIA_DTLAD.idDocente == _id).ToList();
                return lsEV;
            }
            catch (Exception ex)
            {
                string smg = ex.Message;

                return null;
            }
        }
        public List<mM> llenaGrid(string _id)
        {
            List<mM> lsMm = new List<mM>();
            mM mm = new mM();
            List<ED_SIA_EVDOC> lsEV = db.ED_SIA_EVDOC.Where(x => x.CA_SIA_DTLAD.idDocente == _id).ToList();
            int cont = lsEV.Count;
            cont = cont - 1;
            for (int z = 0; z <= cont; z++)
            {
                mm.P01 = lsEV[z].p01;
                mm.P02 = lsEV[z].p02;
                mm.P03 = lsEV[z].p03;
                mm.P04 = lsEV[z].p04;
                mm.P05 = lsEV[z].p05;
                mm.P06 = lsEV[z].p06;
                mm.P07 = lsEV[z].p07;
                mm.P08 = lsEV[z].p08;
                mm.P09 = lsEV[z].p09;
                mm.P10 = lsEV[z].p10;
                mm.P11 = lsEV[z].p11;
                mm.P12 = lsEV[z].p12;
                mm.P13 = lsEV[z].p13;
                mm.P14 = lsEV[z].p14;
                mm.P15 = lsEV[z].p15;
                mm.P16 = lsEV[z].p16;
                mm.P17 = lsEV[z].p17;
                mm.P18 = lsEV[z].p18;
                mm.P19 = lsEV[z].p19;
                mm.P20 = lsEV[z].p20;
                mm.P21 = lsEV[z].p21;
                mm.P22 = lsEV[z].p22;
                mm.P23 = lsEV[z].p23;
                mm.P24 = lsEV[z].p24;
                mm.P25 = lsEV[z].p25;
                mm.P26 = lsEV[z].p26;
                mm.P27 = lsEV[z].p27;
                mm.P28 = lsEV[z].p28;
                lsMm.Add(mm);
            }
            return lsMm;
        }
        public List<mM> Promedio(string _id)
        {
            List<mM> lsMm = new List<mM>();
            mM mm = new mM();
            List<ED_SIA_EVDOC> lsEV = db.ED_SIA_EVDOC.Where(x => x.CA_SIA_DTLAD.idDocente == _id).ToList();
            int cont = lsEV.Count;
            double p1 = 0.0, p2 = 0.0, p3 = 0.0, p4 = 0.0, p5 = 0.0, p6 = 0.0, p7 = 0.0, p8 = 0.0, p9 = 0.0, p10 = 0.0, p11 = 0.0, p12 = 0.0, p13 = 0.0, p14 = 0.0, p15 = 0.0, p16 = 0.0, p17 = 0.0, p18 = 0.0, p19 = 0.0, p20 = 0.0, p21 = 0.0, p22 = 0.0, p23 = 0.0, p24 = 0.0, p25 = 0.0, p26 = 0.0, p27 = 0.0, p28 = 0.0;
            //double p_1=0.0, p2=0.0, p3=0.0, p4=0.0, p5=0.0, p6=0.0, p7=0.0, p8=0.0, p9=0.0, p10=0.0,p11=0.0, p12=0.0, p13=0.0,p14=0.0, p15=0.0, p16 = 0.0, p17 = 0.0, p18 = 0.0, p19 = 0.0, p20 = 0.0, p21 = 0.0, p22 = 0.0, p23 = 0.0, p24 = 0.0, p25 = 0.0, p26 = 0.0, p27 = 0.0, p28 = 0.0;

            for (int z = 0; z < cont; z++)
            {
                p1 = p1 + lsEV[z].p01;
                p2 = p2 + lsEV[z].p02;
                p3 = p3 + lsEV[z].p03;
                p4 = p4 + lsEV[z].p04;
                p5 = p5 + lsEV[z].p05;
                p6 = p6 + lsEV[z].p06;
                p7 = p7 + lsEV[z].p07;
                p8 = p8 + lsEV[z].p08;
                p9 = p9 + lsEV[z].p09;
                p10 = p10 + lsEV[z].p10;
                p11 = p11 + lsEV[z].p11;
                p12 = p12 + lsEV[z].p12;
                p13 = p13 + lsEV[z].p13;
                p14 = p14 + lsEV[z].p14;
                p15 = p15 + lsEV[z].p15;
                p16 = p16 + lsEV[z].p16;
                p17 = p17 + lsEV[z].p17;
                p18 = p18 + lsEV[z].p18;
                p19 = p19 + lsEV[z].p19;
                p20 = p20 + lsEV[z].p20;
                p21 = p21 + lsEV[z].p21;
                p22 = p22 + lsEV[z].p22;
                p23 = p23 + lsEV[z].p23;
                p24 = p24 + lsEV[z].p24;
                p25 = p25 + lsEV[z].p25;
                p26 = p26 + lsEV[z].p26;
                p27 = p27 + lsEV[z].p27;
                p28 = p28 + lsEV[z].p28;
            }
            mm.P01 = Math.Round(p1 / cont, 1, MidpointRounding.AwayFromZero);
            mm.P02 = Math.Round(p2 / cont, 1, MidpointRounding.AwayFromZero);
            mm.P03 = Math.Round(p3 / cont, 1, MidpointRounding.AwayFromZero);
            mm.P04 = Math.Round(p4 / cont, 1, MidpointRounding.AwayFromZero);
            mm.P05 = Math.Round(p5 / cont, 1, MidpointRounding.AwayFromZero);
            mm.P06 = Math.Round(p6 / cont, 1, MidpointRounding.AwayFromZero);
            mm.P07 = Math.Round(p7 / cont, 1, MidpointRounding.AwayFromZero);
            mm.P08 = Math.Round(p8 / cont, 1, MidpointRounding.AwayFromZero);
            mm.P09 = Math.Round(p9 / cont, 1, MidpointRounding.AwayFromZero);
            mm.P10 = Math.Round(p10 / cont, 1, MidpointRounding.AwayFromZero);
            mm.P11 = Math.Round(p11 / cont, 1, MidpointRounding.AwayFromZero);
            mm.P12 = Math.Round(p12 / cont, 1, MidpointRounding.AwayFromZero);
            mm.P13 = Math.Round(p13 / cont, 1, MidpointRounding.AwayFromZero);
            mm.P14 = Math.Round(p14 / cont, 1, MidpointRounding.AwayFromZero);
            mm.P15 = Math.Round(p15 / cont, 1, MidpointRounding.AwayFromZero);
            mm.P16 = Math.Round(p16 / cont, 1, MidpointRounding.AwayFromZero);
            mm.P17 = Math.Round(p17 / cont, 1, MidpointRounding.AwayFromZero);
            mm.P18 = Math.Round(p18 / cont, 1, MidpointRounding.AwayFromZero);
            mm.P19 = Math.Round(p19 / cont, 1, MidpointRounding.AwayFromZero);
            mm.P20 = Math.Round(p20 / cont, 1, MidpointRounding.AwayFromZero);
            mm.P21 = Math.Round(p21 / cont, 1, MidpointRounding.AwayFromZero);
            mm.P22 = Math.Round(p22 / cont, 1, MidpointRounding.AwayFromZero);
            mm.P23 = Math.Round(p23 / cont, 1, MidpointRounding.AwayFromZero);
            mm.P24 = Math.Round(p24 / cont, 1, MidpointRounding.AwayFromZero);
            mm.P25 = Math.Round(p25 / cont, 1, MidpointRounding.AwayFromZero);
            mm.P26 = Math.Round(p26 / cont, 1, MidpointRounding.AwayFromZero);
            mm.P27 = Math.Round(p27 / cont, 1, MidpointRounding.AwayFromZero);
            mm.P28 = Math.Round(p28 / cont, 1, MidpointRounding.AwayFromZero);
            lsMm.Add(mm);
            return lsMm;
        }
        public List<string> Comentarios(string _id)
        {
            List<ED_SIA_EVDOC> lsEV = db.ED_SIA_EVDOC.Where(x => x.CA_SIA_DTLAD.idDocente == _id).ToList();
            int cont = lsEV.Count;
            List<string> lComent = new List<string>();
            int a = 1;

            for (int z = 0; z < cont; z++)
            {
                if (lsEV[z].coment.Contains("Comentarios (No mayor a 200 caracteres).") || lsEV[z].coment.Contains("                                                                                                                                                                                                        "))
                {
                }
                else
                {
                    lComent.Add(a + ".- " + lsEV[z].coment + ".");
                    a = a + 1;
                }
            }
            return lComent;
        }
        public String selecMM_BY(string _id)
        {
            string materias = "-- ";
            try
            {

                List<CA_SIA_DTLAD> lsDT = this.db.CA_SIA_DTLAD.Where(p => p.idDocente == _id).ToList();
                int cont = lsDT.Count;
                cont = cont - 1;
                for (int z = 0; z <= cont; z++)
                {
                    materias = materias + lsDT[z].NAsignatura + " (" + lsDT[z].idGrupo + ") " + " -- ";
                }
                return materias;
            }
            catch (Exception ex)
            {
                string smg = ex.Message;

                return null;
            }
        }
        public Double prom(string _id)
        {
            Double p = 0.0;
            List<mM> lsP = this.Promedio(_id);

            p = lsP[0].P01 + lsP[0].P02 + lsP[0].P03 + lsP[0].P04 + lsP[0].P05 + lsP[0].P06 + lsP[0].P07 + lsP[0].P08 + lsP[0].P09 + lsP[0].P10 + lsP[0].P11 + lsP[0].P12 + lsP[0].P13 + lsP[0].P14 + lsP[0].P15 + lsP[0].P16 + lsP[0].P17 + lsP[0].P18 + lsP[0].P19 + lsP[0].P20 + lsP[0].P21 + lsP[0].P22 + lsP[0].P23 + lsP[0].P24 + lsP[0].P25 + lsP[0].P26 + lsP[0].P27 + lsP[0].P28;
            p = Math.Round(p / 28, 1, MidpointRounding.AwayFromZero);

            return p;
        }
        public bool Update(string _idMaestro, decimal _promedio)
        {
            bool respuesta = false;
            try
            {
                FD_SIA_DOCENTE mae = this.db.FD_SIA_DOCENTE.Where(p => p.idDocente == _idMaestro).First();
                mae.promedioED = _promedio;
                this.db.SubmitChanges();
                respuesta = true;
            }
            catch (Exception _ex)
            {
                string msj = _ex.Message;
                respuesta = false;
            }
            return respuesta;
        }
        public double pGral()
        {
            double gral = 0;
            double total = 0;
            List<FD_SIA_DOCENTE> lsM = ctrlD.selectEVCD();
            int cont = lsM.Count;

            for (int z = 0; z < cont; z++)
            {
                gral = gral + (double)lsM[z].promedioED;
            }
            total = Math.Round(gral / cont, 2, MidpointRounding.AwayFromZero);

            return total;

        }

        public List<mM> ppp()
        {
            List<mM> lsMm = new List<mM>();
            mM mm = new mM();
            List<ED_SIA_EVDOC> lsEV = db.ED_SIA_EVDOC.ToList();
            int cont = lsEV.Count;
            cont = cont - 1;
            double p1 = 0.0, p2 = 0.0, p3 = 0.0, p4 = 0.0, p5 = 0.0, p6 = 0.0, p7 = 0.0, p8 = 0.0, p9 = 0.0, p10 = 0.0, p11 = 0.0, p12 = 0.0, p13 = 0.0, p14 = 0.0, p15 = 0.0, p16 = 0.0, p17 = 0.0, p18 = 0.0, p19 = 0.0, p20 = 0.0, p21 = 0.0, p22 = 0.0, p23 = 0.0, p24 = 0.0, p25 = 0.0, p26 = 0.0, p27 = 0.0, p28 = 0.0;

            for (int z = 0; z <= cont; z++)
            {
                p1 = p1 + lsEV[z].p01;
                p2 = p2 + lsEV[z].p02;
                p3 = p3 + lsEV[z].p03;
                p4 = p4 + lsEV[z].p04;
                p5 = p5 + lsEV[z].p05;
                p6 = p6 + lsEV[z].p06;
                p7 = p7 + lsEV[z].p07;
                p8 = p8 + lsEV[z].p08;
                p9 = p9 + lsEV[z].p09;
                p10 = p10 + lsEV[z].p10;
                p11 = p11 + lsEV[z].p11;
                p12 = p12 + lsEV[z].p12;
                p13 = p13 + lsEV[z].p13;
                p14 = p14 + lsEV[z].p14;
                p15 = p15 + lsEV[z].p15;
                p16 = p16 + lsEV[z].p16;
                p17 = p17 + lsEV[z].p17;
                p18 = p18 + lsEV[z].p18;
                p19 = p19 + lsEV[z].p19;
                p20 = p20 + lsEV[z].p20;
                p21 = p21 + lsEV[z].p21;
                p22 = p22 + lsEV[z].p22;
                p23 = p23 + lsEV[z].p23;
                p24 = p24 + lsEV[z].p24;
                p25 = p25 + lsEV[z].p25;
                p26 = p26 + lsEV[z].p26;
                p27 = p27 + lsEV[z].p27;
                p28 = p28 + lsEV[z].p28;
            }
            cont = cont + 1;
            mm.P01 = Math.Round(p1 / cont, 1, MidpointRounding.AwayFromZero);
            mm.P02 = Math.Round(p2 / cont, 1, MidpointRounding.AwayFromZero);
            mm.P03 = Math.Round(p3 / cont, 1, MidpointRounding.AwayFromZero);
            mm.P04 = Math.Round(p4 / cont, 1, MidpointRounding.AwayFromZero);
            mm.P05 = Math.Round(p5 / cont, 1, MidpointRounding.AwayFromZero);
            mm.P06 = Math.Round(p6 / cont, 1, MidpointRounding.AwayFromZero);
            mm.P07 = Math.Round(p7 / cont, 1, MidpointRounding.AwayFromZero);
            mm.P08 = Math.Round(p8 / cont, 1, MidpointRounding.AwayFromZero);
            mm.P09 = Math.Round(p9 / cont, 1, MidpointRounding.AwayFromZero);
            mm.P10 = Math.Round(p10 / cont, 1, MidpointRounding.AwayFromZero);
            mm.P11 = Math.Round(p11 / cont, 1, MidpointRounding.AwayFromZero);
            mm.P12 = Math.Round(p12 / cont, 1, MidpointRounding.AwayFromZero);
            mm.P13 = Math.Round(p13 / cont, 1, MidpointRounding.AwayFromZero);
            mm.P14 = Math.Round(p14 / cont, 1, MidpointRounding.AwayFromZero);
            mm.P15 = Math.Round(p15 / cont, 1, MidpointRounding.AwayFromZero);
            mm.P16 = Math.Round(p16 / cont, 1, MidpointRounding.AwayFromZero);
            mm.P17 = Math.Round(p17 / cont, 1, MidpointRounding.AwayFromZero);
            mm.P18 = Math.Round(p18 / cont, 1, MidpointRounding.AwayFromZero);
            mm.P19 = Math.Round(p19 / cont, 1, MidpointRounding.AwayFromZero);
            mm.P20 = Math.Round(p20 / cont, 1, MidpointRounding.AwayFromZero);
            mm.P21 = Math.Round(p21 / cont, 1, MidpointRounding.AwayFromZero);
            mm.P22 = Math.Round(p22 / cont, 1, MidpointRounding.AwayFromZero);
            mm.P23 = Math.Round(p23 / cont, 1, MidpointRounding.AwayFromZero);
            mm.P24 = Math.Round(p24 / cont, 1, MidpointRounding.AwayFromZero);
            mm.P25 = Math.Round(p25 / cont, 1, MidpointRounding.AwayFromZero);
            mm.P26 = Math.Round(p26 / cont, 1, MidpointRounding.AwayFromZero);
            mm.P27 = Math.Round(p27 / cont, 1, MidpointRounding.AwayFromZero);
            mm.P28 = Math.Round(p28 / cont, 1, MidpointRounding.AwayFromZero);
            lsMm.Add(mm);
            return lsMm;
        }

        public Boolean deleteAll(List<ED_SIA_EVDOC> _ls)
        {
            bool respuesta = false;
            try
            {
                
                this.db.ED_SIA_EVDOC.DeleteAllOnSubmit(_ls);
                this.db.SubmitChanges();

                respuesta = true;
            }
            catch (Exception ex)
            {
                string msj = ex.Message;

                respuesta = false;
            }
            return respuesta;
        }
        public Boolean deleteAllRela(List<CA_SIA_DTLAD> _ls)
        {
            bool respuesta = false;
            try
            {

                this.db.CA_SIA_DTLAD.DeleteAllOnSubmit(_ls);
                this.db.SubmitChanges();
                BorrarCalDoc();
                respuesta = true;
            }
            catch (Exception ex)
            {
                string msj = ex.Message;

                respuesta = false;
            }
            return respuesta;
        }

        public Boolean evcdEstatus()
        {
            try
            {
                CA_SIA_ASIGNATURA evdc = db.CA_SIA_ASIGNATURA.Where(x => x.idAsignatura == "EVCD").FirstOrDefault();
                if(evdc.creditos==1)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                string smg = ex.Message;

                return false;
            }
        }
        public bool updateevcdEstatus(int _status)
        {
            bool respuesta = false;
            try
            {
                CA_SIA_ASIGNATURA evdc = db.CA_SIA_ASIGNATURA.Where(x => x.idAsignatura == "EVCD").FirstOrDefault();
                evdc.creditos = _status;
                this.db.SubmitChanges();
                respuesta = true;
            }
            catch (Exception _ex)
            {
                string msj = _ex.Message;
                respuesta = false;
            }
            return respuesta;
        }

        private void BorrarCalDoc()
        {
            try
            {
                List<FD_SIA_DOCENTE> lsDC = db.FD_SIA_DOCENTE.ToList();

                for (int i = 0; i < lsDC.Count; i++)
                {
                    lsDC[i].promedioED = 0;
                }
                this.db.SubmitChanges();

            }
            catch (Exception _ex)
            {
                string msj = _ex.Message;
            }   
        }

    }
}
