using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SIAA_UPE.CONTROL
{
    public class codificar
    {
        public string llamar(string _codigo, string[] _fecha, string _monto)
        {
            return vCodigo(_codigo, _fecha, _monto);
        }
        private string vCodigo(string _codigo, string[] _fecha, string _monto)
        {
            int ctdr = 1;
            string cadena = _codigo + vFecha(_fecha) + vImporte(_monto) + "2";

            int lgtCad = cadena.Count() - 1;
            int suma = 0;

            for (; lgtCad >= 0; lgtCad--)
            {
                int dt = int.Parse(cadena[lgtCad].ToString());

                if (ctdr == 1)
                {
                    suma = suma + (dt * 11);
                    ctdr++;
                }
                else if (ctdr == 2)
                {
                    suma = suma + (dt * 13);
                    ctdr++;
                }
                else if (ctdr == 3)
                {
                    suma = suma + (dt * 17);
                    ctdr++;
                }
                else if (ctdr == 4)
                {
                    suma = suma + (dt * 19);
                    ctdr++;
                }
                else if (ctdr == 5)
                {
                    suma = suma + (dt * 23);
                    ctdr = 1;
                }

            }
            suma = (suma % 97) + 1;
            string a = suma.ToString();
            if (a.Count() == 1)
            {
                cadena = cadena + "0" + suma;
            }
            else
            {
                cadena = cadena + suma;
            }
            return cadena;
        }
        private string vFecha(string[] _fecha)
        {
            string condensado = "";
            int dia = int.Parse(_fecha[0]);
            int mes = int.Parse(_fecha[1]);
            int ano = int.Parse(_fecha[2]);

            ano = (ano - 2014) * 372;
            mes = (mes - 1) * 31;
            dia = dia - 1;
            condensado = (ano + mes + dia).ToString();

            return condensado;
        }
        private string vImporte(string _monto)
        {
            int ctdr = 1;
            int lgtCad = _monto.Count() - 1;
            int suma = 0;
            for (; lgtCad >= 0; lgtCad--)
            {
                int numericValue;
                bool isNumber = int.TryParse(_monto[lgtCad].ToString(), out numericValue);
                if (isNumber)
                {
                    int dt = int.Parse(_monto[lgtCad].ToString());
                    if (ctdr == 1)
                    {
                        suma = suma + (dt * 7);
                        ctdr++;
                    }
                    else if (ctdr == 2)
                    {
                        suma = suma + (dt * 3);
                        ctdr++;
                    }
                    else
                    {
                        suma = suma + (dt * 1);
                        ctdr = 1;
                    }
                }

            }
            suma = suma % 10;
            return suma.ToString();
        }
        public string matricula(string _dato)
        {
            string dato = _dato;
            string matricula = "";
    
            for (int i = 0; i < dato.Length; i++)
            {
                if (Char.IsNumber((char)dato[i]))
                {
                    matricula = matricula + dato[i];
                }
                if (matricula.Length == 5)
                {
                    i = dato.Length;
                }

            }
            return matricula;
        }

        public string[] fecha()
        {
            string[] f = new string[3];
            int day, month, year, dayMax, weekend = 0;
            string dWeek = "";
            day = DateTime.Today.Day;
            month = DateTime.Today.Month;
            year = DateTime.Today.Year;
            dWeek = DateTime.Today.DayOfWeek.ToString();
            dayMax = DateTime.DaysInMonth(year, month);
            do
            {
                switch (dWeek)
                {
                    case "Monday":
                        day = day + 2;
                        weekend = 0;
                        break;
                    case "Tuesday":
                        day = day + 2;
                        break;
                    case "Wednesday":
                        day = day + 2;
                        break;
                    case "Thursday":
                        day = day + 4;
                        break;
                    case "Friday":
                        day = day + 4;
                        break;
                    default:
                        if (dWeek.Equals("Saturday"))
                        {
                            day = day + 2;
                        }
                        else
                        {
                            day++;
                        }
                        dWeek = "Monday";
                        weekend = 1;
                        break;
                }
            } while (weekend == 1);
            
            if(day <= dayMax)
            {
                f[0] = day.ToString();
                f[1] = month.ToString();
                f[2] = year.ToString();
            }
            else
            {
                day = day - dayMax;
                f[0] = day.ToString();
                if(month!=12)
                {
                    month++;
                    f[1] = month.ToString();
                    f[2] = year.ToString();
                }
                else
                {
                    f[1] = "1";
                    f[2] = year++.ToString();
                }
            }
            return f;
        }

        public string[] fechaEspes(int _d,int _m,int _a)
        {
            string[] f = new string[3];
            int day, month, year, dayMax, weekend = 0;
            string dWeek = "";
            day =_d;
            month = _m;
            year = _a;
            DateTime dateValue = new DateTime(year, month,day);
            dWeek = dateValue.DayOfWeek.ToString();
            dayMax = DateTime.DaysInMonth(year, month);
            do
            {
                switch (dWeek)
                {
                    case "Monday":
                        day = day + 4;
                        weekend = 0;
                        break;
                    case "Tuesday":
                        day = day + 6;
                        break;
                    case "Wednesday":
                        day = day + 6;
                        break;
                    case "Thursday":
                        day = day + 6;
                        break;
                    case "Friday":
                        day = day + 6;
                        break;
                    default:
                        if (dWeek.Equals("Saturday"))
                        {
                            day = day + 2;
                        }
                        else
                        {
                            day++;
                        }
                        dWeek = "Monday";
                        weekend = 1;
                        break;
                }
            } while (weekend == 1);

            if (day <= dayMax)
            {
                f[0] = day.ToString();
                f[1] = month.ToString();
                f[2] = year.ToString();
            }
            else
            {
                day = day - dayMax;
                f[0] = day.ToString();
                if (month != 12)
                {
                    month++;
                    f[1] = month.ToString();
                    f[2] = year.ToString();
                }
                else
                {
                    f[1] = "1";
                    f[2] = year++.ToString();
                }
            }

            return f;

        }
        public bool recargo(int _dia, int _mes)
        {
            int dia = DateTime.Now.Day;
            int mes = DateTime.Now.Month;
            if(dia <= _dia && mes ==_mes)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public string password(string _name,int _folio)
        {
            Random rand = new Random();
            int numero = rand.Next(26);
            char letra = (char)(((int)'A') + numero);
            return letra + _folio +_name.Substring(0,3).ToUpper();


        }
        public string hoy()
        {
            int day = DateTime.Today.Day;
            int month = DateTime.Today.Month;
            int year = DateTime.Today.Year;
            return day+"/"+month+ "/"+year;
        }
        public bool CurpValida(string curp)
        {
            var re = @"^([A-Z][AEIOUX][A-Z]{2}\d{2}(?:0[1-9]|1[0-2])(?:0[1-9]|[12]\d|3[01])[HM](?:AS|B[CS]|C[CLMSH]|D[FG]|G[TR]|HG|JC|M[CNS]|N[ETL]|OC|PL|Q[TR]|S[PLR]|T[CSL]|VZ|YN|ZS)[B-DF-HJ-NP-TV-Z]{3}[A-Z\d])(\d)$";
            Regex rx = new Regex(re, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var validado = rx.IsMatch(curp);

            if (!validado)  //Coincide con el formato general?
                return false;

            //Validar que coincida el dígito verificador
            if (!curp.EndsWith(DigitoVerificador(curp.ToUpper())))
                return false;

            return true; //Validado
        }
        public string DigitoVerificador(string curp17)
        {
            var diccionario = "0123456789ABCDEFGHIJKLMNÑOPQRSTUVWXYZ";
            var suma = 0.0;
            var digito = 0.0;
            for (var i = 0; i < 17; i++)
                suma = suma + diccionario.IndexOf(curp17[i]) * (18 - i);
            digito = 10 - suma % 10;
            if (digito == 10) return "0";
            return digito.ToString();
        }


    }
}
