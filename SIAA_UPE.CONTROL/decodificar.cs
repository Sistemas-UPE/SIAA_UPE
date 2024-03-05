using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using SIAA_UPE.MODELO.entidades;

namespace SIAA_UPE.CONTROL
{
    public class decodificar
    {
        ctrlTipoPago ctlPago = new ctrlTipoPago();
        ctrlCarrera ctrlCarrera = new ctrlCarrera();
        ctrlAlumno ctrlAlumno = new ctrlAlumno();
        ctrlAspirante crtlAspirant = new ctrlAspirante();
        ctrlReferencia ctrlRef = new ctrlReferencia();



        public string txt(string _string)
        {
            string retorno="";
            foreach(char caracter in _string.ToCharArray())
            {
                if (!char.IsDigit(caracter)||caracter != 'D')
                    retorno = retorno + caracter;
            }
            return retorno;
        }
        public List<decodifica> decAspirantes(StreamReader _reader)
        {
            List<decodifica> ls = new List<decodifica>();
            decodifica dec = new decodifica();
            List<string> lsrd = lsread(_reader);


            for (int i = 0; lsrd.Count > i; i++)
            {
                dec = lsDesc(lsrd[i]);
                long refer = long.Parse(dec.Referencia);
                dec.Referencia = refer.ToString();
                List<string> lsr = matricula(dec.Referencia);
                dec.Concepto = lsr[0];


                try
                {
                    if (lsr[3].Equals("caja"))
                    {
                        dec.Matricula = "CAJA";
                        dec.NombreC = "CAJA";
                    }

                    else if(lsr[0].Equals("Examen de Ingreso Nivel Licenciatura                                                                                    "))
                    {
                        int folio = int.Parse(lsr[3]);
                        dec.Matricula = "F - " + folio.ToString("D4");
                        DP_SIA_ASPIRANTES aspirant = crtlAspirant.aspirantebyfolio(folio);
                        dec.NombreC = aspirant.DP_SIA_PERSONA.nombre;
                    }
                    else if (lsr[0].Equals("Inscripción a Curso Propedéutico                                                                                        "))
                    {
                        int folio = int.Parse(lsr[3]);
                        dec.Matricula = "A - " + folio.ToString("D4");
                        DP_SIA_ASPIRANTES aspirant = crtlAspirant.aspirantebyfolio(folio);
                        dec.NombreC = aspirant.DP_SIA_PERSONA.nombre;
                    }
                    else
                    {
                        dec.Matricula = (lsr[4] + lsr[1] + lsr[3]).Replace(" ", string.Empty);
                        FD_SIA_ALUMNO alumno = ctrlAlumno.alumno((lsr[1] + lsr[3]).Replace(" ", string.Empty));
                        if(alumno==null)
                        {
                            dec.Matricula = (lsr[4] + lsr[1]+'D' + lsr[3]).Replace(" ", string.Empty);
                            alumno = ctrlAlumno.alumno((lsr[1]+ 'D' + lsr[3]).Replace(" ", string.Empty));
                        }
                        dec.NombreC = alumno.DP_SIA_PERSONA.nombre + " " + alumno.DP_SIA_PERSONA.aPaterno + " " + alumno.DP_SIA_PERSONA.aMaterno;
                    }
                }
                catch
                {
                    dec.NombreC = "Error Matricula";
                }
                ls.Add(dec);
            }

            return ls;


        }

        public List<decodifica> decArchivo(StreamReader _reader)
        {
            List<decodifica> ls = new List<decodifica>();
            decodifica dec = new decodifica();
            List<string> lsrd = lsread(_reader);


            for (int i=0;lsrd.Count>i;i++ )
            {
                dec = lsDesc(lsrd[i]);
                int refer = int.Parse(dec.Referencia);
                dec.Referencia = refer.ToString();
                List<string> lsr = matricula(dec.Referencia);
                dec.Concepto = lsr[0];

                try
                {
                    dec.Matricula = (lsr[4] +lsr[1] + lsr[3]).Replace(" ",string.Empty);
                    FD_SIA_ALUMNO alumno = ctrlAlumno.alumno((lsr[1] + lsr[3]).Replace(" ", string.Empty));
                    dec.NombreC = alumno.DP_SIA_PERSONA.nombre+" "+ alumno.DP_SIA_PERSONA.aPaterno+" "+ alumno.DP_SIA_PERSONA.aMaterno;
                }
                catch
                {
                        dec.NombreC = "Error Matricula";
                }
                ls.Add(dec);
            }

            return ls;
        }

        public List<decodifica> decAlumnoBR(StreamReader _reader)
        {
            List<decodifica> ls = new List<decodifica>();
            decodifica dec = new decodifica();
            string idAl = "";
            List<string> lsrd = lsread(_reader);

            foreach (var item in lsrd)
            {
                try
                {
                    List<string> lsr = new List<string>();
                    //DTL_SIA_ALUMNO_REFERENCIA alumnoReferencia = ctrlRef.selectBR(long.Parse(dec.Referencia));
                    dec = lsDesc(item);

                    if (isIncription(dec.Referencia))
                    {
                        lsr = folio(dec.Referencia);
                        idAl = lsr[5];
                    }
                    else
                    {
                        lsr = matricula(dec.Referencia);
                        idAl=(lsr[1] + lsr[3]).Replace(" ", string.Empty);
                    }

                    dec.Concepto = lsr[0];

                
                    dec.Matricula = (lsr[4] + lsr[1] + lsr[3]).Replace(" ", string.Empty);
                    FD_SIA_ALUMNO alumno = ctrlAlumno.alumno(idAl);
                    dec.NombreC = alumno.DP_SIA_PERSONA.nombre + " " + alumno.DP_SIA_PERSONA.aPaterno + " " + alumno.DP_SIA_PERSONA.aMaterno;
                }
                catch
                {
                    dec.NombreC = "Error Matricula";
                }
                ls.Add(dec);
            }

            return ls;
        }

        public List<decodifica> decoFile(StreamReader _reader)
        {
            List<decodifica> ls = new List<decodifica>();
            List<string> lsrd = lsread(_reader);
            decodifica dec = new decodifica();

            foreach (var item in lsrd)
            {
                try
                {
                    List<string> lsr = new List<string>();
                    dec = lsDesc(item);
                    RG_SIA_GREFERENCIA referencia = ctrlRef.selectByR(long.Parse(dec.Referencia));
                    dec.IdR = referencia.idGREFERENCIA;
                    dec.Concepto = referencia.CT_SIA_TIPOPAGO.concepto;
                    switch (referencia.idAlumno){
                        case "aspirante ":
                            DP_SIA_ASPIRANTES aspirante = crtlAspirant.aspirantebyfolio(int.Parse(referencia.descripcion.Substring(2)));
                            dec.NombreC = aspirante.NAlumno;
                            dec.Matricula = referencia.descripcion;
                            dec.Descripcion = referencia.descripcion;
                            break;
                        default:
                            if (referencia.descripcion != null) dec.Descripcion = referencia.descripcion;
                            dec.NombreC = referencia.FD_SIA_ALUMNO.NAlumno;
                            dec.Matricula = (referencia.FD_SIA_ALUMNO.generacion + referencia.idAlumno).Replace(" ", string.Empty);
                            break;
                    }
                }
                catch
                {
                    dec.NombreC = "Error Matricula";
                }
                ls.Add(dec);
            }

            return ls;
        }


        public int tipoPago(string _dato)
        {
            int ndato = _dato.Length;

            int tp=0;

            if (ndato <= 13)
            {
                switch (ndato)
                {
                    case 13:
                        tp = int.Parse(_dato.Substring(0, 2));
                        break;
                    case 12:
                        tp = int.Parse(_dato[0].ToString());
                        break;
                }
               
            }
            else if (ndato != 17)
            {
                tp = int.Parse(_dato[0].ToString());
            }
            else
            {
                tp = int.Parse(_dato.Substring(0, 2));
            }
            return tp;
        }
        public decodifica lsDesc(string _cadena)
        {

            decodifica dec = new decodifica();
            long referencia = long.Parse(_cadena.Substring(7, 20));

            dec.Referencia = referencia.ToString();
            dec.Importe = _cadena.Substring(98, 7);
            double a = double.Parse(dec.Importe);
            dec.Importe = "$ "+a.ToString();
            dec.Fecha = _cadena.Substring(114, 10);
            dec.Sucursal = _cadena.Substring(124, 10);

            return dec;
        }
        public List<string> lsread(StreamReader _reader)
        {
            List<string> ls = new List<string>();
            bool registro = true;

            for (;registro;)
            {
                string cadena = _reader.ReadLine();
                try
                {
                    if (cadena.Length == 141)
                    {
                        ls.Add(cadena);
                    }

                }
                catch
                {
                    registro = false;
                }
            }

            return ls;
        }
        private List<string> matricula(string _dato)
        {
            List<string> separado = new List<string>();
            string clave = "";
            int ndato = _dato.Length;
            int con, car,m = 0;
            int p = int.Parse(_dato[0].ToString());
            int i = int.Parse(_dato[1].ToString());
            int l = int.Parse(_dato[2].ToString());
            
            if (ndato<=13)
            {
                switch (ndato)
                {
                    case 13:
                        if(p!=1)
                            m = int.Parse(_dato[0].ToString());
                        else
                            m = int.Parse(_dato.Substring(0, 2));
                        break;
                    case 12:
                        m = int.Parse(_dato[0].ToString());
                        break;
                }
                con = m;
                car = 6;
                clave = "caja";
                m =0;
            }
            else if (ndato!=17)
            {
                con = int.Parse(_dato[0].ToString());
                car = int.Parse(_dato.Substring(1, 2));
                clave = _dato.Substring(3, ndato - 11);
                m = generacion(int.Parse(_dato.Substring(3, 2)));
            }
            else
            {
                con = int.Parse(_dato.Substring(0, 2));
                car = int.Parse(_dato.Substring(2, 2));
                clave = _dato.Substring(4, ndato - 12);
                m = generacion(int.Parse(_dato.Substring(4, 2)));
            }

            CT_SIA_PROEDU proedu = ctrlCarrera.selectByID(car);
            CT_SIA_TIPOPAGO tipo = ctlPago.selectByID(con);
            try
            {
                separado.Add(tipo.concepto);
                if(proedu.idPE.Equals("MGP  "))
                    separado.Add("M");
                else
                    separado.Add(proedu.idPE);
                separado.Add(proedu.nomProEdu);
                separado.Add(clave);
                separado.Add(m.ToString());
                return separado;
            }catch
            {
                return separado;
            }
        }
        private List<string> folio(string _dato)
        {
            List<string> separado = new List<string>();
            int ndato = _dato.Length;

            string folio = _dato.Substring(3, ndato - 11);

            int con = int.Parse(_dato[0].ToString());
            int car = int.Parse(_dato.Substring(1, 2));
            CT_SIA_PROEDU proedu = ctrlCarrera.selectByID(car);
            CT_SIA_TIPOPAGO tipo = ctlPago.selectByID(con);
            
            try
            {
                folio = (proedu.idPE + "11" + folio).Replace(" ", string.Empty);
                FD_SIA_ALUMNO alumno = ctrlAlumno.alumno(folio);
                separado.Add(tipo.concepto);
                separado.Add(proedu.idPE);
                separado.Add(proedu.nomProEdu);
                separado.Add(alumno.promedio.ToString());
                separado.Add("2022");
                separado.Add(folio);
                return separado;
            }
            catch
            {
                return separado;
            }
        }
        private Boolean isIncription(string _dato)
        {
            string a = _dato[0].ToString();
            if (a.Equals("1"))
            {
                a = _dato[1].ToString();
                if (a.Equals("0"))
                {
                    a = _dato[2].ToString();
                    if (!a.Equals("0"))
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }
            else
                return false;
        }
        private int generacion(int _generacion)
        {
            int gene = 0;
            switch (_generacion)
            {
                case 5:
                    gene = 2017;
                    break;
                case 6:
                    gene = 2018;
                    break;
                case 7:
                    gene = 2018;
                    break;
                case 8:
                    gene = 2019;
                    break;
                case 9:
                    gene = 2020;
                    break;
                case 10:
                    gene = 2021;
                    break;
                default:
                    gene =2022;
                    break;
            }
            return gene;

        }
    }
}
