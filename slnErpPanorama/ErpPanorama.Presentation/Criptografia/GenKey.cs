using System;
using System.Collections.Generic;
using System.Text;

namespace ErpPanorama.Presentation.Criptografia
{
    public class GenKey
    {
        public string LicenceKey(string applicationName)
        {
            int longitud = applicationName.Length;
            int valorEntrada = 0;

            for (int i = 0; i < longitud - 1; i++)
            {
                //valorEntrada += Asc(usuario.Substring(I, 1))
                valorEntrada += ASCIIEncoding.ASCII.GetBytes(applicationName.Substring(i, 1))[0];

            }

            valorEntrada = valorEntrada /= longitud;

            int valorBase = valorEntrada * longitud;
            string key = "";


            string valor = "";
            string g = "";
            g = (valorBase + (123 * 10000)).ToString();
            valor = Int32.Parse(g, System.Globalization.NumberStyles.HexNumber).ToString();
            key += valor.Substring(valor.Length - 6, 6);

            g = (valorBase + (98 * 12500)).ToString();
            valor = Int32.Parse(g, System.Globalization.NumberStyles.HexNumber).ToString();
            key += "-" + valor.Substring(0, 6);

            g = (valorBase + (77 * 15000)).ToString();
            valor = Int32.Parse(g, System.Globalization.NumberStyles.HexNumber).ToString();
            key += "-" + valor.Substring(valor.Length - 6, 6);

            g = (valorBase + (121 * 17500)).ToString();
            valor = Int32.Parse(g, System.Globalization.NumberStyles.HexNumber).ToString();
            key += "-" + valor.Substring(0, 6);

            g = (valorBase + (55 * 20000)).ToString();
            valor = Int32.Parse(g, System.Globalization.NumberStyles.HexNumber).ToString();
            key += "-" + valor.Substring(valor.Length - 6, 6);


            g = (valorBase + (134 * 22500)).ToString();
            valor = Int32.Parse(g, System.Globalization.NumberStyles.HexNumber).ToString();
            key += "-" + valor.Substring(0, 6);


            g = (valorBase + (63 * 25000)).ToString();
            valor = Int32.Parse(g, System.Globalization.NumberStyles.HexNumber).ToString();
            key += "-" + valor.Substring(valor.Length - 6, 6);

            g = (valorBase + (117 * 27500)).ToString();
            valor = Int32.Parse(g, System.Globalization.NumberStyles.HexNumber).ToString();
            key += "-" + valor.Substring(0, 6);

            return key;
        }
    }
}
