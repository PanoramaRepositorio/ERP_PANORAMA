using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;
using ErpPanorama.Presentation.Funciones;
using System.Net.Mail;

namespace ErpPanorama.Presentation.Modulos.Ventas.Otros
{
    public partial class frmEnviarPSE : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"
        FacturacionElectronica FacturaE = new FacturacionElectronica();
        List<DocumentoVentaBE> mLista = new List<DocumentoVentaBE>();

        public int Origen = 0; // 0=Envío automático, 1=Manual
        private int TotalProcesados = 0;
        private int TotalEnviados = 0;
        private int TotalErrores = 0;
        private string MensajeError = "";
        #endregion

        #region "Eventos"
        public frmEnviarPSE()
        {
            InitializeComponent();
        }

        private void frmEnviarPSE_Load(object sender, EventArgs e)
        {
            if(Origen == 0)
            {
                CargarEnviar();
                btnEnviar_Click(sender, e);
            }
            else if (Origen == 1)
            {
                CargarEnviar();
            }
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (mLista.Count > 0)
            {
                Cursor = Cursors.WaitCursor;
                this.Text = "Enviar documentos al PSE - Enviando " + mLista.Count + " documentos + " + TotalProcesados + "x10";
                lblMensaje.Text = "Enviando...";

                prgEnvio.Properties.Step = 1;
                prgEnvio.Properties.PercentView = true;
                prgEnvio.Properties.Maximum = mLista.Count;
                prgEnvio.Properties.Minimum = 0;

                foreach (var item in mLista)
                {
                    if (item.IdTipoDocumento == Parametros.intTipoDocBoletaElectronica || item.IdTipoDocumento == Parametros.intTipoDocFacturaElectronica || item.IdTipoDocumento == Parametros.intTipoDocNotaCreditoElectronica)
                    {
                        if (item.IdSituacion != Parametros.intDVAnulado)
                        {
                            if (item.TotalDiferencia < 0) item.TotalDiferencia = item.TotalDiferencia * -1;

                            #region "Diferencia cabecera vs detalle Doc Ven"
                            if (item.TotalDiferencia >= 1)
                            {
                                TotalErrores = TotalErrores + 1;
                                MensajeError = MensajeError + item.IdConTipoComprobantePago + "-" + item.Serie + "-" + item.Numero + " | Diferencia en Cabecera y Detalle" + "<BR/>"; 
                            }
                            else
                            {
                                #region "Envío e Impresión de Comprobante electrónico"
                                if (item.IdTipoDocumento == Parametros.intTipoDocBoletaElectronica || item.IdTipoDocumento == Parametros.intTipoDocFacturaElectronica)
                                {
                                    #region "Grabar"
                                    string MensajeService = FacturaE.GrabarVentaIntegrens(item.IdEmpresa, item.IdDocumentoVenta);
                                    if (MensajeService.ToUpper() != "OK")
                                    {
                                        TotalErrores = TotalErrores + 1;
                                        MensajeError = MensajeError + item.IdConTipoComprobantePago + "-" + item.Serie + "-" + item.Numero + " | "+ MensajeService + "<BR/>"; 
                                    }
                                    else
                                    {
                                        TotalEnviados = TotalEnviados + 1;
                                    }
                                    #endregion
                                }
                                else if (item.IdTipoDocumento == Parametros.intTipoDocNotaCreditoElectronica)
                                {
                                    #region "Grabar"
                                    string MensajeService = FacturaE.GrabarNotaCreditoIntegrens(item.IdEmpresa, item.IdDocumentoVenta);
                                    if (MensajeService.ToUpper() != "OK")
                                    {
                                        TotalErrores = TotalErrores + 1;
                                        MensajeError = MensajeError + item.IdConTipoComprobantePago + "-" + item.Serie + "-" + item.Numero + " | " + MensajeService + "<BR/>"; 
                                    }
                                    else
                                    {
                                        TotalEnviados = TotalEnviados + 1;
                                    }
                                    #endregion
                                }
                                else
                                {
                                    //lblMensaje.Text = "ERROR:NO ES COMPROBANTE ELECTRONICO";
                                }
                                #endregion
                            }
                            #endregion
                        }
                        else
                        {
                            string MensajeService = "";
                            if (item.IdTipoDocumento == Parametros.intTipoDocNotaCreditoElectronica)
                                MensajeService = FacturaE.AnulaNotaCreditoIntegrens(item.IdEmpresa, item.IdDocumentoVenta);
                            else
                                MensajeService = FacturaE.AnulaVentaIntegrens(item.IdEmpresa, item.IdDocumentoVenta);
                        }
                    }
                    else
                    {
                        //lblMensaje.Text = "ERROR:NO ES COMPROBANTE ELECTRONICO";
                    }

                    prgEnvio.PerformStep();
                    prgEnvio.Update();
                }

                TotalProcesados = TotalProcesados + 1;
                lblMensaje.Text = TotalEnviados + " Enviados, " + TotalErrores + " Errores";

                if (TotalProcesados < nudVeces.Value)
                {
                    prgEnvio.EditValue = 0;
                    prgEnvio.Update();
                    CargarEnviar();
                    btnEnviar_Click(sender, e);
                    return;
                }
                else
                {
                    mLista = null;
                    lblMensaje.Text = TotalEnviados + " Enviados, " + TotalErrores + " Errores\nFinalizado!";
                }

                if (TotalErrores > 0)//Enviar al correo
                {
                    EnviarEmailErrorPSE();
                }

                this.Close();

                //lblMensaje.Text = "PROCESO TERMINADO!!!";
                Cursor = Cursors.Default;
            }
            else
            {
                this.Close();
            }
        }

        #endregion

        #region "Métodos"
        private void CargarEnviar()
        {
            mLista = new DocumentoVentaBL().ListaPendientePSE(Parametros.intEmpresaId, 0, Convert.ToDateTime(DateTime.Now.ToShortDateString()), Convert.ToDateTime(DateTime.Now.ToShortDateString()));
            //lblMensaje.Text = mLista.Count.ToString() + " Registros";
        }

        private void EnviarEmailErrorPSE()
        {
            List<PersonaBE> mlistadoReporte = new List<PersonaBE>();
            mlistadoReporte = new PersonaBL().ListaEnviaCorreoErrorPSE();

            foreach (var item in mlistadoReporte)
            {
                string MsgContenido = "";
                MsgContenido += @"<p>Estimado " + item.DescSexo + " " + item.Nombres + ",</p>";
                MsgContenido += @"<p>Este es un cordial recordatorio de que sus comprobantes electrónicos contienen ERRORES. Hasta el momento se encontraron:<h3><b>" + TotalErrores +" FE</b></h3>"+ MensajeError + "</br></br></br>Por favor tratar de solucionar lo más antes posible para evitar problemas con el CLIENTE y con la SUNAT.</p>";
                MsgContenido += @"<p></p>";
                MsgContenido += @"<p>ATTE</p>";
                MsgContenido += @"<p>DBA Panorama</p>";
                MsgContenido += @"<p></p>";
                MsgContenido += @"<p>Este mensaje se envia automaticamente, si usted no desea recibir más correos, por favor envíe un correo a: <a href='mailto:sistemas@panoramhogar.com'>sistemas@panoramahogar.com</a> con el asunto REMOVER.</p>";

                MailMessage msg = new MailMessage();
                msg.To.Add(item.Email);
                //msg.From = new MailAddress("panocoro@gmail.com", "DBA Panorama", System.Text.Encoding.UTF8);
                msg.From = new MailAddress("panoramahogar22@gmail.com", "DBA Panorama", System.Text.Encoding.UTF8);
                msg.Subject = "ERROR DE ENVIO PSE - Panorama Distribuidores";
                msg.SubjectEncoding = System.Text.Encoding.UTF8;
                msg.Body = MsgContenido;//"Este Mensaje Fue enviado Automáticamente, Si usted no desea recibir estos e-mails nuevamente, por favor envíe un correo solicitando ser dado de baja al correo ventas@panoramadistribuidores.com.";
                msg.BodyEncoding = System.Text.Encoding.UTF8;
                msg.IsBodyHtml = true; 
                msg.Priority = MailPriority.Normal;
                //Configuración
                SmtpClient client = new SmtpClient();
                client.Credentials = new System.Net.NetworkCredential("panoramahogar22@gmail.com", "159*ucayali");
                client.Port = 587;
                client.Host = "smtp.gmail.com";//Este es el smtp válido para Gmail
                client.EnableSsl = true; //Esto es para que vaya a través de SSL que es obligatorio con GMail

                try
                {
                    client.Send(msg);
                    //MessageBox.Show("enviado");
                    this.Close();
                    //return true;
                }
                catch (Exception ex)
                {
                    //return false;
                }
            }


        }

        #endregion

    }
}