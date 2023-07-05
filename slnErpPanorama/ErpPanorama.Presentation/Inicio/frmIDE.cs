using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;
using DevExpress.Skins;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.LookAndFeel;
using ErpPanorama.Presentation;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Inicio
{
    public partial class frmIDE : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        Ribbon _ribbon;

        public frmIDE()
        {
            InitializeComponent();
            UserLookAndFeel.Default.SetSkinStyle("Office 2010 Blue");
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Money Twins");
            //DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Pumpkin");
            //DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Dark Side");
        }

        void _ribbon_RibbonClick(string menuCodigo, string ensamblado, string modoCarga, string titulo, string clase)
        {
            try
            {
                Application.DoEvents();
                //Application.EnableVisualStyles();

                if (ensamblado == "")
                {
                    MessageBox.Show("Objeto no implementado en la Base de Datos", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (modoCarga == "1")
                {
                    //if (!FormCheched(titulo))
                    //{
                        Cursor = Cursors.WaitCursor;
                        //RibbonForm f = new RibbonForm();
                        XtraForm f = new XtraForm();
                        //f = (RibbonForm)System.Reflection.Assembly.GetExecutingAssembly().CreateInstance(ensamblado);
                        f = (XtraForm)System.Reflection.Assembly.GetExecutingAssembly().CreateInstance(ensamblado);
                        f.MdiParent = this;
                        f.Text = titulo;
                        f.Tag = ensamblado;
                        f.Show();
                        Cursor = Cursors.Default;
                    //}
                }

                if (modoCarga == "2")
                {
                    //if (!FormCheched(titulo))
                    //{
                        Cursor = Cursors.WaitCursor;
                        //RibbonForm f = new RibbonForm();
                        XtraForm f = new XtraForm();
                        //f = (RibbonForm)System.Reflection.Assembly.GetExecutingAssembly().CreateInstance(ensamblado);
                        f = (XtraForm)System.Reflection.Assembly.GetExecutingAssembly().CreateInstance(ensamblado);
                        f.MdiParent = this;
                        f.Text = titulo;
                        f.Tag = ensamblado;
                        f.WindowState = FormWindowState.Maximized;
                        f.Show();
                        Cursor = Cursors.Default;
                    //}
                }

                if (modoCarga == "9")
                {
                    //if (!FormCheched(titulo))
                    //{
                        Cursor = Cursors.WaitCursor;
                        //RibbonForm f = new RibbonForm();
                        XtraForm f = new XtraForm();
                        //f = (RibbonForm)System.Reflection.Assembly.GetExecutingAssembly().CreateInstance(ensamblado);
                        f = (XtraForm)System.Reflection.Assembly.GetExecutingAssembly().CreateInstance(ensamblado);
                        f.Text = titulo;
                        f.Tag = ensamblado;
                        f.Show();
                        Cursor = Cursors.Default;
                    //}
                }

            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }

        private void frmIDE_Load(object sender, EventArgs e)
        {
            //Cargamos el Login
            decimal qtcventa = 0;
            decimal qtccompra = 0;

            Application.DoEvents();
            frmLogin fLogin = new frmLogin();
            fLogin.Owner = this;
            fLogin.ShowDialog();
            if (fLogin.DialogResult == DialogResult.Yes)
            {
                //Aqui se carga los menus del usuario en el Control Ribbon
                _ribbon = new Ribbon(this.ribbon, new AccesoUsuarioBL().SeleccionaUser(Parametros.intUsuarioId).ToList());
                _ribbon.Fill();
                _ribbon.RibbonClick += new Ribbon.delegateRibbonClick(_ribbon_RibbonClick);

                //Carga el Status Bar
                BarButtonItem stbButtonEmpresa = new DevExpress.XtraBars.BarButtonItem();
                stbButtonEmpresa.Caption = Parametros.strEmpresaNombre;

                BarButtonItem stbButtonTienda = new DevExpress.XtraBars.BarButtonItem();
                stbButtonTienda.Caption = "  TIENDA : " + Parametros.strDescTienda;
                stbButtonTienda.Alignment = BarItemLinkAlignment.Left;

                BarButtonItem stbButtonCaja = new DevExpress.XtraBars.BarButtonItem(); //Add May 15
                stbButtonCaja.Caption = "  CAJA : " + Parametros.strDescCaja;
                stbButtonCaja.Alignment = BarItemLinkAlignment.Left;

                BarButtonItem stbButtonUsuario = new DevExpress.XtraBars.BarButtonItem();
                stbButtonUsuario.Caption = "Usuario: " + Parametros.strUsuarioLogin; // .strUsuarioNombres;
                stbButtonUsuario.Alignment = BarItemLinkAlignment.Right;

                BarButtonItem stbButtonVersion = new DevExpress.XtraBars.BarButtonItem();
                stbButtonVersion.Caption = "Versión: " + Parametros.strVersion.Trim() + " |"   ;
                stbButtonVersion.Alignment = BarItemLinkAlignment.Right;

                TipoCambioBE objE_TipoCambio = null;
                objE_TipoCambio = new TipoCambioBL().Selecciona(Parametros.intEmpresaId, Parametros.dtFechaHoraServidor);
                if (objE_TipoCambio == null)
                {
                }
                else
                {
                    qtccompra = decimal.Parse(objE_TipoCambio.Compra.ToString());
                    qtcventa  = decimal.Parse(objE_TipoCambio.Venta.ToString());
                    // txtTipoCambio.EditValue = decimal.Parse(objE_TipoCambio.Venta.ToString());
                }

                BarButtonItem stbButtontCambio = new DevExpress.XtraBars.BarButtonItem();
                stbButtontCambio.Caption = "T.C. Compra: " + Convert.ToString(qtccompra).Trim() + " Venta: " + Convert.ToString(qtcventa).Trim() + " |";
                stbButtontCambio.Alignment = BarItemLinkAlignment.Right;



                ribbonStatusBar.ItemLinks.Add(stbButtonEmpresa);
                ribbonStatusBar.ItemLinks.Add(stbButtonTienda);
                //if (Parametros.strDescCaja.Length > 0)
                //{
                    ribbonStatusBar.ItemLinks.Add(stbButtonCaja);
                //}
                ribbonStatusBar.ItemLinks.Add(stbButtontCambio);
                ribbonStatusBar.ItemLinks.Add(stbButtonVersion);
                ribbonStatusBar.ItemLinks.Add(stbButtonUsuario);
                

                //Demos la bienvenida a :.............Personal Nuevo si es master Registrar

                //Promoción 2x1 o 3x2
                List<Promocion2x1BE> lst_Promocion = new List<Promocion2x1BE>();
                lst_Promocion = new Promocion2x1BL().ListaVigente(Parametros.intEmpresaId);

                foreach (var item in lst_Promocion)
                {
                    string FormaPago = "" ;
                    string TipoCliente = "";
                    if (item.FlagContado)FormaPago += "Contado ";
                    if (item.FlagContraentrega) FormaPago += "Contraentrega ";
                    if (item.FlagCopagan) FormaPago += "Copagan ";
                    if (item.FlagSeparacion) FormaPago += "Separación ";
                    if (item.FlagCredito) FormaPago += "Crédito ";
                    if (item.FlagClienteFinal) TipoCliente += "C.Final ";
                    if (item.FlagClienteMayorista) TipoCliente += "C.Mayorista ";

                    alertControl1.Show(this, "PROMOCIÓN " + item.Tipo, "Del " + item.FechaInicio.ToShortDateString().ToString() + " Al " + item.FechaFin.ToShortDateString().ToString() + " para " + TipoCliente +" "+ FormaPago +"." );

                    //Promociones activas
                    if (item.Tipo == "2x1") Parametros.bPromocion2x1 = true;
                    if (item.Tipo == "3x2") Parametros.bPromocion3x2 = true;
                    if (item.Tipo == "3x1") Parametros.bPromocion3x1 = true;
                    if (item.Tipo == "4x1") Parametros.bPromocion4x1 = true;

                }

                //Anuncio
                List<AnuncioBE> lst_Anuncio = new List<AnuncioBE>();
                lst_Anuncio = new AnuncioBL().ListaUltimoTipo(Parametros.intAnuncioAlerta);
                foreach (var item in lst_Anuncio)
                {
                    alertControl1.Show(this, item.Titulo, item.DescAnuncio);
                }


                //alertControl1.Show(this, "RESTRICCIONES", "Nó validó para KIRA - ZG - PT y Velas Acrílicas.");
                //alertControl1.Show(this, "CIERRA PUERTAS NAVIDEÑO!", "último día 23 Dic, no te pierdas el gran Cierra Puertas Navideño con grandes descuentos. 50% en todo Navidad y Regular.");
                //alertControl1.Show(this, "Promoción 3X2", "Del Viernes 13 al Domingo 22, sólo paga los 2 productos con precios más altos y el tercero es GRATIS.");
                //alertControl1.Show(this, "Inauguración MegaPlaza", "Gran Inauguración de la tienda MegaPlaza, el sábado 21 de Noviembre");

                //-------------------------------------------------------------------------------------------------------------------------------
                fLogin.Close();
                fLogin.Dispose();


                UsuarioBE obj = new UsuarioBE();
                obj = new UsuarioBL().Selecciona(Parametros.intUsuarioId);
                if (obj.IdPerfil == 7 || obj.IdPerfil == 42)
                {
                    ErpPanorama.Presentation.Modulos.RecursosHumanos.Consultas.FrmAlertaContratos frm1 = new
                    ErpPanorama.Presentation.Modulos.RecursosHumanos.Consultas.FrmAlertaContratos();
                    frm1.ShowDialog();
                }

                //Cumpleaños
                PersonaBE objCe = new PersonaBE();
                PersonaBL objcl = new PersonaBL();

                int cuenta = objcl.ListaCumpleaño().Count;

                if (cuenta > 0)
                { 
                    ErpPanorama.Presentation.Modulos.RecursosHumanos.Consultas.frmConsulltaCumpleaño frm = new ErpPanorama.Presentation.Modulos.RecursosHumanos.Consultas.frmConsulltaCumpleaño();
                    frm.Show();
                }

                //Notas pendientes
                if (Parametros.intPerfilId == Parametros.intPerAsistenteAlmacen || Parametros.intPerfilId == Parametros.intPerSupervisorAlmacenTienda || Parametros.intPerfilId == Parametros.intPerCoordinadorVisualCentral || Parametros.intPerfilId == Parametros.intPerAuxiliarVisual || Parametros.intPerfilId == Parametros.intPerCoordinadorMuestrasVisual)
                {
                    ErpPanorama.Presentation.Modulos.Logistica.Consultas.frmConNotaSalidaPendiente frm = new ErpPanorama.Presentation.Modulos.Logistica.Consultas.frmConNotaSalidaPendiente();
                    frm.Show();
                }

                //Anuncios POP-UP
                List<AnuncioBE> lst_Anuncio2 = null;
                lst_Anuncio2 = new AnuncioBL().ListaUltimoTipo(Parametros.intAnuncioAlertaPopup);
                if (lst_Anuncio2.Count > 0)
                {
                    foreach (var item in lst_Anuncio2)
                    {
                        ErpPanorama.Presentation.Modulos.RecursosHumanos.Consultas.frmConAlertaPopup frm = new Modulos.RecursosHumanos.Consultas.frmConAlertaPopup();
                        frm.Titulo = item.Titulo;
                        frm.Mensaje = item.DescAnuncio;
                        frm.StartPosition = FormStartPosition.CenterScreen;
                        frm.ShowDialog();
                    }
                }


                ///// Solo aparece si el perfil es asistente de almacen
                if (Parametros.intPerfilId == Parametros.intPerAsistenteAlmacen)
                {
                    timer1.Start();
                }
            }
            else
            { Application.Exit(); };
        }

        public bool FormCheched(string titulo)
        {
            bool valor = false;
            foreach (Form form in Application.OpenForms)
            {
                if (form.Text == titulo)
                    valor = true;
                else
                    valor = false;
            }

            return valor;
        }

        private void frmIDE_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void ribbon_Click(object sender, EventArgs e)
        {

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F12) CargarPK();

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void CargarPK()
        {
            if(Parametros.intTiendaId == Parametros.intTiendaUcayali)
            {
                ErpPanorama.Presentation.Modulos.Logistica.Registros.frmRegTrackingPedidoPickingEmbalaje frm = new Modulos.Logistica.Registros.frmRegTrackingPedidoPickingEmbalaje();
                frm.Show();
            }
        }

        private void frmIDE_Shown(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Parametros.intTiendaId
            SolicitudProductoBE objE_SolProdPendientes = null;
            objE_SolProdPendientes = new SolicitudProductoBL().SeleccionaSolProdPendiente(Parametros.intEmpresaId, Parametros.intTiendaId);
            if (objE_SolProdPendientes != null)
            {
          //      alertControl1.Show(this, "PROMOCIÓN " + item.Tipo, "Del " + item.FechaInicio.ToShortDateString().ToString() + " Al " + item.FechaFin.ToShortDateString().ToString() + " para " + TipoCliente + " " + FormaPago + ".");
                alertControl1.Show(this, "SOLICITUD DE PRODUCTO ",  "Tiene ("+ Convert.ToString(objE_SolProdPendientes.SolPendientes) + ")" + " Solicitudes Pendientes por recibir. ");
            }

        }
    }
}