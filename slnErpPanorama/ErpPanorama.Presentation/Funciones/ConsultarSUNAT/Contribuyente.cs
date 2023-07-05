using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Net;
using System.IO;
using System.Web;
using System.Text.RegularExpressions;

namespace ErpPanorama.Presentation.Funciones.ConsultarSUNAT
{
    public class Contribuyente
    {
        public enum Resul
        {
            Ok = 0,
            NoResul = 1,
            ErrorCapcha = 2,
            Error = 3,
        }
        private Resul state;
        private string _RazonSocial;
        private string _Ruc;
        private string _Direccion;
        private string _Estado;
        private string _Habido;

        private CookieContainer myCookie;

        public Image GetCapcha { get { return ReadCapcha(); } }
        public string RazonSocial { get { return _RazonSocial; } }
        public string Ruc { get { return _Ruc; } }
        public string Direccion { get { return _Direccion; } }
        public string Estado { get { return _Estado; } }
        public string Habido { get { return _Habido; } }
        public Resul GetResul { get { return state; } }

        public Contribuyente()
        {
            try
            {

                myCookie = null;
                myCookie = new CookieContainer();
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
                ReadCapcha();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Boolean ValidarCertificado(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        //Aqui obtenemos el captcha
        private Image ReadCapcha()
        {
            try
            {
                //----------------- add by Ederman
                if (AccesoInternet() == false)
                {
                    return ErpPanorama.Presentation.Properties.Resources.noImage;
                }
                ///------------
          

                System.Net.ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(ValidarCertificado);
                //Esta es la direccion que les pase en el grupo de facebook para obtener el captcha
                
                HttpWebRequest myWebRequest = (HttpWebRequest)WebRequest.Create("http://e-consultaruc.sunat.gob.pe/cl-ti-itmrconsruc/captcha?accion=image&magic=2");
                //HttpWebRequest myWebRequest = (HttpWebRequest)WebRequest.Create("http://ww1.sunat.gob.pe/cl-ti-itmrconsruc/captcha?accion=image&magic=2");
                //HttpWebRequest myWebRequest = (HttpWebRequest)WebRequest.Create("http://www.sunat.gob.pe/cl-ti-itmrconsruc/captcha?accion=image&nmagic=");

                myWebRequest.CookieContainer = myCookie;
                myWebRequest.Proxy = null;

                myWebRequest.Credentials = CredentialCache.DefaultCredentials;
                HttpWebResponse myWebResponse = (HttpWebResponse)myWebRequest.GetResponse();
                Stream myImgStream = myWebResponse.GetResponseStream();
                return Image.FromStream(myImgStream);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void GetInfo(string numDni, string ImgCapcha)
        {
            string xRazSoc = ""; string xEst = ""; string xCon = ""; string xDir = ""; string xAg = ""; string xHab = "";
            try
            {
                //A este link le pasamos los datos , RUC y valor del captcha
                //string myUrl = String.Format("http://ww1.sunat.gob.pe/cl-ti-itmrconsruc/jcrS00Alias?accion=consPorRuc&nroRuc={0}&codigo={1}",
                string myUrl = String.Format("http://e-consultaruc.sunat.gob.pe/cl-ti-itmrconsruc/jcrS00Alias?accion=consPorRuc&nroRuc={0}&codigo={1}",
                                        numDni, ImgCapcha);
                HttpWebRequest myWebRequest = (HttpWebRequest)WebRequest.Create(myUrl);
                myWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:23.0) Gecko/20100101 Firefox/23.0";
                myWebRequest.CookieContainer = myCookie;
                myWebRequest.Credentials = CredentialCache.DefaultCredentials;
                myWebRequest.Proxy = null;
                HttpWebResponse myHttpWebResponse = (HttpWebResponse)myWebRequest.GetResponse();
                Stream myStream = myHttpWebResponse.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myStream);
                //Leemos los datos
                string xDat = HttpUtility.HtmlDecode(myStreamReader.ReadToEnd());
                if (xDat.Length <= 635)
                {
                    return;
                }
                string[] tabla;
                xDat = xDat.Replace("     ", " ");
                xDat = xDat.Replace("    ", " ");
                xDat = xDat.Replace("   ", " ");
                xDat = xDat.Replace("  ", " ");
                xDat = xDat.Replace("( ", "(");
                xDat = xDat.Replace(" )", ")");
                //Lo convertimos a tabla o mejor dicho a un arreglo de string como se ve declarado arriba
                tabla = Regex.Split(xDat, "<td class");
                //separamos el arreglo que hasta ese momento tenia 1 solo item , y lo dividimos por la etiqueta tdclass
                //Esto lo hice porque cuando es persona el ruc empieza con 1 
                //y tiene un resultado distinto a cuando es empresa ...
                if (numDni.StartsWith("1"))
                {
                    //hacemos el parseo 
                    tabla[1] = tabla[1].Replace("=\"bg\" colspan=3>" + numDni + " - ", "");
                    tabla[1] = tabla[1].Replace("</td>\r\n </tr>\r\n <tr>\r\n ", "");
                    tabla[12] = tabla[12].Replace("=\"bg\" colspan=1>", "");
                    tabla[12] = tabla[12].Replace("</td>\r\n ", "");
                    tabla[15] = tabla[15].Replace("=\"bg\" colspan=3>\r\n \r\n ", "");
                    tabla[15] = tabla[15].Replace("\r\n \r\n </td> \r\n </tr> \r\n <tr>\r\n ", "");
                    tabla[17] = tabla[17].Replace("=\"bg\" colspan=3>", "");
                    tabla[17] = tabla[17].Replace("</td>\r\n </tr>\r\n<!-- SE COMENTO POR INDICACION DEL PASE PAS20134EA20000207 -->\r\n<!-- <tr> -->\r\n<!-- ", "");
                    xRazSoc = (string)tabla[1];
                    xEst = (string)tabla[12];
                    xHab = (string)tabla[15];
                    xDir = (string)tabla[17];
                }
                else if (numDni.StartsWith("2"))
                {//Empresa
                    tabla[1] = tabla[1].Replace("=\"bg\" colspan=3>" + numDni + " - ", "");
                    tabla[1] = tabla[1].Replace("</td>\r\n </tr>\r\n <tr>\r\n ", "");
                    tabla[10] = tabla[10].Replace("=\"bg\" colspan=1>", "");
                    tabla[10] = tabla[10].Replace("</td>\r\n ", "");
                    tabla[13] = tabla[13].Replace("=\"bg\" colspan=3>\r\n \r\n ", "");
                    tabla[13] = tabla[13].Replace("\r\n \r\n </td> \r\n </tr> \r\n <tr>\r\n ", "");
                    tabla[15] = tabla[15].Replace("=\"bg\" colspan=3>", "");
                    tabla[15] = tabla[15].Replace("</td>\r\n </tr>\r\n<!-- SE COMENTO POR INDICACION DEL PASE PAS20134EA20000207 -->\r\n<!-- <tr> -->\r\n<!-- ", "");
                    xRazSoc = (string)tabla[1];
                    xEst = (string)tabla[10];
                    xHab = (string)tabla[13];
                    xDir = (string)tabla[15];
                }
                //los resultados
                //Como ven en el arreglo se pueden obtener mas datos pero yaa pues el parseo lo hacen uds...
                _RazonSocial = xRazSoc;
                _Direccion = xDir;
                _Estado = xEst;
                _Habido = xHab;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Verificar acceso add
        private bool AccesoInternet()       
        {
            try
            {
                if (Parametros.bConsultaSunat)
                {
                    //System.Net.IPHostEntry host = System.Net.Dns.GetHostEntry("http://ww1.sunat.gob.pe/cl-ti-itmrconsruc/captcha?accion=image&magic=2");
                    System.Net.IPHostEntry host = System.Net.Dns.GetHostEntry("www.sunat.gob.pe");
                    return true;
                }
                return false;

            }
            catch (Exception es)
            {
                return false;
            }
        }


    }
}
