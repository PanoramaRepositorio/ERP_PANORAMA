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
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Modulos.Ventas.Maestros;
using System.Net.Mail;
using System.IO;
using System.Reflection;
using System.Security.Principal;
using DevExpress.XtraGrid.Views.Grid;


namespace ErpPanorama.Presentation.Modulos.Ventas.Reportes
{
    public partial class frmRepClientesNuevosVentasTienda : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"
        List<ReporteCumpleaniosClienteBE> mLista = new List<ReporteCumpleaniosClienteBE>();
        #endregion

        #region "Eventos"
        public frmRepClientesNuevosVentasTienda()
        {
            InitializeComponent();
        }

        private void frmRepClientesNuevosVentasTienda_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            cboMes.EditValue = DateTime.Now.Month;
            BSUtils.LoaderLook(cboTienda, new TiendaBL().ListaTodosCombo(Parametros.intEmpresaId), "DescTienda", "IdTienda", true);
            cboTienda.EditValue = Parametros.intTiendaId;
            txtAnio.Text = Convert.ToString(DateTime.Now.Year);

            if (  Parametros.intPerfilId == Parametros.intPerAdministrador || Parametros.intPerfilId == Parametros.intPerJefeMarketingPublicidad)
            {
               // cboMes.Properties.ReadOnly = false;
               cboTienda.Properties.ReadOnly = false;
            }
            else
            {
              //  cboMes.Properties.ReadOnly = true;
             cboTienda.Properties.ReadOnly = true;
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Cargar();
        }
        #endregion

        #region "Métodos"
        private void Cargar()
        {
            mLista = new ReporteCumpleaniosClienteBL().ListadoClientesNuevos(Convert.ToInt32(cboTienda.EditValue), Convert.ToInt32(cboMes.EditValue), Convert.ToInt32(txtAnio.Text));
            gcReporteCumpleanios.DataSource = mLista;
        }


        #endregion

        private void gvReporteCumpleanios_DoubleClick(object sender, EventArgs e)
        {
            if (gvReporteCumpleanios.RowCount > 0)
            {
                ClienteBE objClientel = new ClienteBE();
                objClientel.IdCliente = int.Parse(gvReporteCumpleanios.GetFocusedRowCellValue("IdCliente").ToString());

                frmManClienteMinoristaEdit objManClientelEdit = new frmManClienteMinoristaEdit();
                objManClientelEdit.pOperacion = frmManClienteMinoristaEdit.Operacion.Modificar;
                objManClientelEdit.IdCliente = objClientel.IdCliente;
                objManClientelEdit.StartPosition = FormStartPosition.CenterParent;
                objManClientelEdit.btnGrabar.Enabled = false;
                objManClientelEdit.ShowDialog();

            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gvReporteCumpleanios_RowStyle(object sender, RowStyleEventArgs e)
        {
            try
            {
                object obj = gvReporteCumpleanios.GetRow(e.RowHandle);
                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    object objNroCorreo = View.GetRowCellValue(e.RowHandle, View.Columns["NroCorreo"]);
                    if (objNroCorreo != null)
                    {
                        gvReporteCumpleanios.Columns["NroCorreo"].AppearanceCell.BackColor = Color.White;
                        gvReporteCumpleanios.Columns["NroCorreo"].AppearanceCell.BackColor2 = Color.White;

                        int NroCorreo =  int.Parse(objNroCorreo.ToString());
                        if (NroCorreo != 0)
                        {
                            gvReporteCumpleanios.Columns["NroCorreo"].AppearanceCell.BackColor = Color.LimeGreen;
                            gvReporteCumpleanios.Columns["NroCorreo"].AppearanceCell.BackColor2 = Color.LimeGreen;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoNuevosClientes"+ cboTienda.Text + "_" + cboMes.Text;
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvReporteCumpleanios.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F8) btnCumpleanios_Click(null, null);

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnCumpleanios_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvReporteCumpleanios.RowCount == 0) return;

                splashScreenManager1.ShowWaitForm();
                int Enviados = 0;
               
                for (int i = 0; i < gvReporteCumpleanios.SelectedRowsCount; i++)
                {
                    int row = gvReporteCumpleanios.GetSelectedRows()[i];
                    int IdCliente = int.Parse(gvReporteCumpleanios.GetRowCellValue(row, "IdCliente").ToString());
                    int IdTipoCliente = int.Parse(gvReporteCumpleanios.GetRowCellValue(row, "IdTipoCliente").ToString());
                    string Email = gvReporteCumpleanios.GetRowCellValue(row, "Email").ToString();
                    string DescCliente = gvReporteCumpleanios.GetRowCellValue(row, "DescCliente").ToString();
                    DateTime FechaNac = DateTime.Parse(gvReporteCumpleanios.GetRowCellValue(row, "FechaNac").ToString());


                    int PeriodoNac = FechaNac.Year;
                    int Anios = Parametros.intPeriodo - PeriodoNac;

                    if (Email.Trim() == "") continue;
                    if (IdTipoCliente == Parametros.intTipClienteMayorista) continue;
                    if (Anios < 15) continue;


                    string NombreCompleto = DescCliente;
                    string FechaCumple = String.Format("{0:MM/dd/yyyy}", FechaNac);

                    string mailserver = "mail.panoramahogar.com";
                    string mailFrom = "enmanuel.cruz@panoramahogar.com";
                    string passwordFrom = "159*Ecruz";
                    string mailDestinatario = Email; //"bapsihospo@vusra.com";//"cruz_11enmanuel@hotmail.com";// "enmanuel.cruz@panoramahogar.com";//Email;
                    int Puerto = 587;
                    bool ssl = true;

                    StringBuilder emailHtml = new StringBuilder(File.ReadAllText("../../Modulos/Ventas/Reportes/PlantillaCumpleaniosCliente.html"));
                    emailHtml.Replace("[NOMBRECOMPLETO]", NombreCompleto);
                    emailHtml.Replace("[FECHACUMPLE]", FechaCumple);


                    //Configuración del Mensaje
                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient(mailserver);
                    //Especificamos el correo desde el que se enviará el Email y el nombre de la persona que lo envía
                    mail.From = new MailAddress(mailFrom, "", Encoding.UTF8);
                    //Aquí ponemos el asunto del correo
                    mail.Subject = "Feliz Cumpleaños " + NombreCompleto;
                    //Aquí ponemos el mensaje que incluirá el correo
                    mail.Body = emailHtml.ToString();// "Prueba de Envío de Correo de Gmail desde CSharp";
                    mail.IsBodyHtml = true;
                    //Especificamos a quien enviaremos el Email, no es necesario que sea Gmail, puede ser cualquier otro proveedor
                    mail.To.Add(mailDestinatario);
                    //Si queremos enviar archivos adjuntos tenemos que especificar la ruta en donde se encuentran
                    mail.Attachments.Add(new Attachment(@"D:\Login.png"));

                    //Configuracion del SMTP
                    SmtpServer.Port = Puerto; //Puerto que utiliza Gmail para sus servicios
                                              //Especificamos las credenciales con las que enviaremos el mail
                    SmtpServer.Credentials = new System.Net.NetworkCredential(mailFrom, passwordFrom);
                    SmtpServer.EnableSsl = ssl;
                    SmtpServer.Send(mail);

                    if (!Insertar_Correo_Enviado(IdCliente, FechaNac))
                    {
                        splashScreenManager1.CloseWaitForm();
                        XtraMessageBox.Show("No se Envio correo al Cliente " + NombreCompleto, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    Enviados += 1;
                }

                splashScreenManager1.CloseWaitForm();
                XtraMessageBox.Show(Enviados + " Correos Enviados !!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Cargar();
            }
            catch (Exception ex)
            {
                splashScreenManager1.CloseWaitForm();
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private bool Insertar_Correo_Enviado(int IdCliente,DateTime Fecha)
        {
            try
            {
                CorreoClienteCumpleanosBE objCorreoClienteCumpleanos = new CorreoClienteCumpleanosBE();
                ReporteCumpleaniosClienteBL objBL_DsctoClienteMayorista = new ReporteCumpleaniosClienteBL();

                objCorreoClienteCumpleanos.IdCorreoClienteCumpleanos = 0;
                objCorreoClienteCumpleanos.IdCliente = IdCliente;
                objCorreoClienteCumpleanos.Fecha = Fecha;
                objCorreoClienteCumpleanos.IdUsuario = Parametros.intUsuarioId;

                objCorreoClienteCumpleanos.Usuario = Parametros.strUsuarioLogin;
                objCorreoClienteCumpleanos.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                objCorreoClienteCumpleanos.IdEmpresa = Parametros.intEmpresaId;

                objBL_DsctoClienteMayorista.Inserta(objCorreoClienteCumpleanos);
                return true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void gcReporteCumpleanios_Click(object sender, EventArgs e)
        {

        }
    }
}