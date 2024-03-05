using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIAA_UPE.CONTROL
{
    public class pcd_log
    {

   
        private string cTexHex(string _tex)
        {

            byte[] bytes = Encoding.ASCII.GetBytes(_tex);
            string hexadecimal = BitConverter.ToString(bytes);
            // Remover los guiones de la cadena hexadecimal
            //hexadecimal = hexadecimal.Replace("-", "");
            // Mostrar el resultado
            return hexadecimal;
        }


        private string dHexTex(string _tex)
        {

            // Convertir la cadena hexadecimal a un arreglo de bytes usando el método ToByteArray
            byte[] bytes = ToByteArray(_tex);

            // Convertir el arreglo de bytes a un texto usando la codificación ASCII
            string texto = Encoding.ASCII.GetString(bytes);

            // Mostrar el resultado
            return texto;
        }


        private int cHexDeci(string _text)
        {
            int nDecimal = int.Parse(_text, System.Globalization.NumberStyles.HexNumber);
            return nDecimal;
        }



        public static byte[] ToByteArray(string hex)
        {
            int length = hex.Length;
            byte[] bytes = new byte[length / 2];
            for (int i = 0; i < length; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }




    }
}
