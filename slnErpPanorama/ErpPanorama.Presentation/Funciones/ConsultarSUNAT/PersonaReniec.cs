using System;
using System.Drawing;
using System.Net;
using System.IO;
using System.Web;
using System.Collections.Generic;

namespace ErpPanorama.Presentation.Funciones.ConsultarSUNAT
{
    public class PersonaReniec
    {
        public enum Resul
        {
            /// <summary>
            /// Se encontro la persona
            /// </summary>
            Ok = 0,
            /// <summary>
            /// No se encontro la persona
            /// </summary>
            NoResul = 1,
            /// <summary>
            /// la imagen capcha no es valida
            /// </summary>
            ErrorCapcha = 2, 
            /// <summary>
            /// Error no especificado
            /// </summary>
            Error=3,
        }

        private Resul state; 
        private string _Nombres;
        private string _ApePaterno;
        private string _ApeMaterno;
        private CookieContainer myCookie;

        #region Propiedades

        /// <summary>
        /// Devuelve la imagen para el reto capcha
        /// </summary>
        public Image GetCapcha { get { return ReadCapcha(); } }

        /// <summary>
        /// Si no Hubo error en la lectura de datos devuelve los nombres 
        /// de la persona caso contrario devuelve ""
        /// </summary>
        public string Nombres { get { return _Nombres; } }

        /// <summary>
        /// Si no Hubo error en la lectura de datos devuelve el Apellido Paterno
        /// de la persona caso contrario devuelve ""
        public string ApePaterno { get { return _ApePaterno; } }

        /// <summary>
        /// Si no Hubo error en la lectura de datos devuelve el Apellido Materno
        /// de la persona caso contrario devuelve ""
        public string ApeMaterno { get { return _ApeMaterno; } }

        /// <summary>
        /// Devuelve el resultado de la busqueda de DNI
        /// </summary>
        public Resul GetResul { get { return state; } }

        #endregion

        #region Constructor

        public PersonaReniec()
        {
            try
            {
                myCookie = null; 
                myCookie = new CookieContainer();

                //Permitir SSL
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;

                ReadCapcha();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        /// <summary>
        /// Carga la imagen Capcha
        /// </summary>
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


                HttpWebRequest myWebRequest = (HttpWebRequest)WebRequest.Create("https://cel.reniec.gob.pe/valreg/codigo.do");

                myWebRequest.CookieContainer = myCookie;

                myWebRequest.Proxy = null;

                myWebRequest.Credentials = CredentialCache.DefaultCredentials;

                HttpWebResponse myWebResponse = (HttpWebResponse)myWebRequest.GetResponse();

                Stream myImgStream = myWebResponse.GetResponseStream();

                //myWebResponse.Close();

                return Image.FromStream(myImgStream);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Inicia la carga de los datos de la persona 
        /// </summary>
        /// <param name="numDni"></param>
        /// <param name="ImgCapcha"></param>
        public void GetInfo(string numDni, string ImgCapcha)
        {
            try
            {
                string myUrl = String.Format("https://cel.reniec.gob.pe/valreg/valreg.do?accion=buscar&nuDni={0}&imagen={1}",
                                        numDni, ImgCapcha);

                HttpWebRequest myWebRequest = (HttpWebRequest)WebRequest.Create(myUrl);
                myWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:23.0) Gecko/20100101 Firefox/23.0";//esto creo que lo puse por gusto :/
                myWebRequest.CookieContainer = myCookie;
                myWebRequest.Credentials = CredentialCache.DefaultCredentials;
                myWebRequest.Proxy = null;

                HttpWebResponse myHttpWebResponse = (HttpWebResponse)myWebRequest.GetResponse();

                Stream myStream = myHttpWebResponse.GetResponseStream();

                StreamReader myStreamReader = new StreamReader(myStream);

                string _WebSource = HttpUtility.HtmlDecode(myStreamReader.ReadToEnd());

                string[] _split = _WebSource.Split(new char[] { '<', '>', '\n', '\r' });
                
                List<string> _resul = new List<string>();

                //quitamos todos los caracteres nulos
                for (int i = 0; i < _split.Length; i++)
                {
                    if (!string.IsNullOrEmpty(_split[i].Trim()))
                        _resul.Add(_split[i].Trim());
                }

                // Anlizando la el arreglo "_resul" llegamos a la siguiente conclusion
                // 
                // _resul.Count == 217 cuando nos equivocamos en el captcha
                // _resul.Count == 232 cuando todo salio ok
                // _resul.Count == 222 cuando no existe el DNI
                //

                switch (_resul.Count)
                {
                    case 217:
                        state = Resul.ErrorCapcha;
                        break;
                    case 232:
                        state = Resul.Ok;
                        break;
                    case 222:
                        state = Resul.NoResul;
                        break;
                    default:
                        state = Resul.Error;
                        break;
                }

                if (state == Resul.Ok)
                {
                    this._Nombres = _resul[185];
                    this._ApePaterno = _resul[186];
                    this._ApeMaterno = _resul[187];
                }

                myHttpWebResponse.Close();   
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool AccesoInternet()
        {
            try
            {
                if (Parametros.bConsultaReniec)
                {
                    //System.Net.IPHostEntry host = System.Net.Dns.GetHostEntry("https://cel.reniec.gob.pe/valreg/codigo.do");
                    System.Net.IPHostEntry host = System.Net.Dns.GetHostEntry("www.reniec.gob.pe");
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
