using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;
using DevExpress.XtraEditors;
using ErpPanorama.Presentation.Criptografia;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;
using System.Net.NetworkInformation;//Add may 2015
using System.Security.Principal; //add 08 jun 2015
using System.Net; //add 08 jun 2015
using System.IO;//add 18 julio 2018

using DevExpress.LookAndFeel;

namespace ErpPanorama.Presentation.Inicio
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"
        private UsuarioBE objE_Usuario = null;
        public string vNomPc = "";
        #endregion

        #region "Eventos"

        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
          labelControl6.Text = "Versión ERP " + Parametros.strVersion;
            if (Parametros.CurrentCulture.Length>0)
            {
                XtraMessageBox.Show("Pueda que cierta funcionalidad del sistema trabaje inadecuadamente\nPor la configuración Regional: " + Parametros.CurrentCulture + "\nPor favor comunicarse con Sistemas.","Configuración Regional");
                Application.Exit();
            }

            try
            {
                CargarControles();
                //VerificarMac();
                CargarDiasFestivos();

                txtUsuario.Select();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {

        }

        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnIngresar.Focus();
            }
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtContraseña.Focus();
            }
        }

        private void cboEmpresa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar ==(Char)Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        #endregion

        #region "Metodos"

        private void CargarControles()
        {
            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaCombo(), "RazonSocial", "IdEmpresa", true);
            cboEmpresa.EditValue = Parametros.intIdPanoramaDistribuidores;
            txtUsuario.Focus();
        }

        private void btnIngresar_Click(object sender, EventArgs e)


        
        {
            try
            {
                if (string.IsNullOrEmpty(cboEmpresa.Text))
                {
                    XtraMessageBox.Show("Seleccione la empresa", "Inicio Sesión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cboEmpresa.Focus();
                    return;
                }
                if (txtUsuario.Text.Trim().Length == 0)
                {
                    XtraMessageBox.Show("Ingrese el usuario.", "Inicio Sesión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtUsuario.Focus();
                    return;
                }
                if (txtContraseña.Text.Trim().Length == 0)
                {
                    XtraMessageBox.Show("Ingrese la contraseña.", "Inicio Sesión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtContraseña.Focus();
                    return;
                }

                Encrypt objCrypto = new Encrypt(Encrypt.CryptoProvider.Rijndael);
                objCrypto.Key = Parametros.Key;
                objCrypto.IV = Parametros.IV;

                string _password = objCrypto.CifrarCadena(txtContraseña.Text.ToString());
                //UsuarioBE objE_Usuario = new UsuarioBL().LogOnUser(txtUsuario.Text.ToString().Trim(), _password);

                objE_Usuario = new UsuarioBL().LogOnUser(txtUsuario.Text.ToString().Trim(), _password);
                if (objE_Usuario != null)
                {
                   // if (txtUsuario.Text.Trim().ToLower() != "master" && txtUsuario.Text.Trim().ToLower() != "ltapia")//(!objE_Usuario.FlagMaster)
                   //{
                   //     if (int.Parse(cboEmpresa.EditValue.ToString()) != objE_Usuario.IdEmpresa)
                   //     {
                   //         XtraMessageBox.Show("El usuario no tiene acceso para la empresa seleccionada.", "Inicio Sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   //         return;
                   //     }
                   // }

                    Parametros.intPerfilId = objE_Usuario.IdPerfil;
                    Parametros.strNomPerfil = objE_Usuario.DescPerfil;
                    Parametros.intEmpresaId = int.Parse(cboEmpresa.EditValue.ToString());
                    Parametros.strEmpresaNombre = cboEmpresa.Text;
                    Parametros.intUsuarioId = objE_Usuario.IdUser;
                    Parametros.strUsuarioLogin = objE_Usuario.Usuario;
                    Parametros.strUsuarioNombres = objE_Usuario.Descripcion;
                    Parametros.intPersonaId = objE_Usuario.IdPersona;
                    Parametros.intTiendaId = objE_Usuario.IdTienda;
                    Parametros.strDescTienda = objE_Usuario.DescTienda;
                    Parametros.strDB = objE_Usuario.DB;
                    //Parametros.intCajaId = objE_Usuario.IdCaja;
                    //Parametros.strDescCaja = objE_Usuario.DescCaja;

                    EmpresaBE objEmpresa = null;
                    objEmpresa = new EmpresaBL().Selecciona(Convert.ToInt32(cboEmpresa.EditValue));
                    Parametros.strEmpresaRuc = objEmpresa.Ruc;

                    //Capa Logica
                    ErpPanorama.BusinessLogic.Parametros.intEmpresaId = int.Parse(cboEmpresa.EditValue.ToString()); //add
                    ErpPanorama.BusinessLogic.Parametros.intTiendaId = objE_Usuario.IdTienda; //add

                    //Verificar si es CAJA  --** Agregar configuración por Usuario o Por Equipo **---  //Add May 05 2015 
                    VerificarHostname();//add 160616
                    VerificarMac();


                    //Obtenemos todos los permisos del usuario logueado
                    Parametros.pListaPermisoAcceso = new AccesoUsuarioBL().SeleccionaPermisoAcceso(objE_Usuario.Usuario, objE_Usuario.IdPerfil).ToList();

                    //Obtenemos todo el Personal Registrado
                    Parametros.pListaPersonal = new PersonaBL().ListaTodos(Parametros.intEmpresaId, 0);

                    //Obtenemos el descuento Cliente Final
                    Parametros.pListaDescuentoClienteFinal = new DescuentoClienteFinalBL().ListaTodosActivo(Parametros.intEmpresaId);

                    //TipoCambioBE objTipoCambio = null;
                    //objTipoCambio = new TipoCambioBL().Selecciona(Parametros.intEmpresaId, Parametros.dtFechaHoraServidor);
                    //if (objTipoCambio != null)
                    //{
                    //    Parametros.dmlTCMayorista = Convert.ToDouble(objTipoCambio.Venta);
                    //}

                    bool bolFlag = false;
                    decimal tcCambioDia = 0;
                    TipoCambioBE objE_TipoCambio = null;
                    objE_TipoCambio = new TipoCambioBL().Selecciona(13, DateTime.Today.Date);
                    if (objE_TipoCambio == null)
                    {
                        XtraMessageBox.Show("Falta ingresar Tipo de Cambio del Día", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        bolFlag = true;
                    }
                    else
                    {
                        tcCambioDia = decimal.Parse(objE_TipoCambio.Venta.ToString());
                    }

                    //Obtenemos el tipo de cambio de Variables
                    VariablesBE objVariables = null;
                    objVariables = new VariablesBL().Selecciona(Parametros.intEmpresaId);
                    if (objVariables != null)
                    {
                        Parametros.dmlTCMayorista = Convert.ToDouble(tcCambioDia); // Convert.ToDouble(objVariables.TipoCambioMayorista);
                        Parametros.dmlTCMayoristaInterna = Convert.ToDouble(objVariables.TipoCambioMayorista);
                        Parametros.dmlTCMinorista = Convert.ToDouble(objVariables.TipoCambioMinorista);//add
                        Parametros.dmlTCMinoristaNacional = Convert.ToDouble(objVariables.TipoCambioMinoristaNacional);//para productos KIRA

                        //BusinessLogic
                        ErpPanorama.BusinessLogic.Parametros.dmlTCMayorista = Convert.ToDouble(tcCambioDia); //Convert.ToDouble(objVariables.TipoCambioMayorista);
                        ErpPanorama.BusinessLogic.Parametros.dmlTCMayoristaInterna = Convert.ToDouble(objVariables.TipoCambioMayorista);
                        ErpPanorama.BusinessLogic.Parametros.dmlTCMinorista = Convert.ToDouble(objVariables.TipoCambioMinorista);
                        ErpPanorama.BusinessLogic.Parametros.dmlTCMinoristaNacional = Convert.ToDouble(objVariables.TipoCambioMinoristaNacional);
                    }
                    // Parametros.dmlTCMinorista

                    //Configurar los almacenes
                    if (objE_Usuario.IdEmpresa == Parametros.intPanoraramaDistribuidores && objE_Usuario.IdTienda == Parametros.intTiendaUcayali) //Tienda Principal
                    {
                        if (vNomPc == "UCAGER02")
                        {
                            Parametros.intAlmCentralUcayali = 25;
                            Parametros.intAlmTienda = 25;
                            ErpPanorama.BusinessLogic.Parametros.intAlmCentral = 25;
                            //ErpPanorama.BusinessLogic.Parametros.intTiendaId;
                        }
                        else
                        {
                            Parametros.intAlmCentralUcayali = 1;
                            Parametros.intAlmTienda = 2;
                            ErpPanorama.BusinessLogic.Parametros.intAlmCentral = 1;
                        //ErpPanorama.BusinessLogic.Parametros.intTiendaId;
                    }

                }

                    if (objE_Usuario.IdEmpresa == Parametros.intPanoraramaDistribuidores && objE_Usuario.IdTienda == Parametros.intTiendaAndahuaylas) //Tienda Andahuaylas
                    {
                        Parametros.intAlmCentralUcayali = 5;
                        Parametros.intAlmTienda = 5;
                        ErpPanorama.BusinessLogic.Parametros.intAlmCentral = 5;
                    }

                    if (objE_Usuario.IdEmpresa == Parametros.intCoronaImportadores && objE_Usuario.IdTienda == Parametros.intTiendaKonceptos) //Tienda Konceptos
                    {
                        Parametros.intAlmCentralUcayali = 7;
                        Parametros.intAlmTienda = 7;
                        ErpPanorama.BusinessLogic.Parametros.intAlmCentral = 7;
                    }

                    if (objE_Usuario.IdEmpresa == Parametros.intPanoraramaDistribuidores && objE_Usuario.IdTienda == Parametros.intTiendaPrescott) //Tienda Prescott
                    {
                        Parametros.intAlmCentralUcayali = 15;
                        Parametros.intAlmTienda = 15;
                        ErpPanorama.BusinessLogic.Parametros.intAlmCentral = 15;
                    }

                    if (objE_Usuario.IdEmpresa == Parametros.intPanoraramaDistribuidores && objE_Usuario.IdTienda == Parametros.intTiendaAviacion) //Tienda Aviación
                    {
                        Parametros.intAlmCentralUcayali = 17;
                        Parametros.intAlmTienda = 17;
                        ErpPanorama.BusinessLogic.Parametros.intAlmCentral = 17;
                    }

                    if (objE_Usuario.IdEmpresa == Parametros.intPanoraramaDistribuidores && objE_Usuario.IdTienda == Parametros.intTiendaMegaplaza) //Tienda MegaPlaza
                    {
                        Parametros.intAlmCentralUcayali = 18;
                        Parametros.intAlmTienda = 18;
                        ErpPanorama.BusinessLogic.Parametros.intAlmCentral = 18;
                    }

                    if (objE_Usuario.IdEmpresa == Parametros.intPanoraramaDistribuidores && objE_Usuario.IdTienda == Parametros.intTiendaAviacion2) //Tienda Aviación 2
                    {
                        Parametros.intAlmCentralUcayali = 23;
                        Parametros.intAlmTienda = 23;
                        ErpPanorama.BusinessLogic.Parametros.intAlmCentral = 23;
                    }

                    if (objE_Usuario.IdEmpresa == Parametros.intPanoraramaDistribuidores && objE_Usuario.IdTienda == Parametros.intTiendaSanMiguel) //Tienda San Miguel
                    {
                        Parametros.intAlmCentralUcayali = 24;
                        Parametros.intAlmTienda = 24;
                        ErpPanorama.BusinessLogic.Parametros.intAlmCentral = 24;
                    }

                    //Carga de Parametros
                    List<ParametroBE> lstParametros = new List<ParametroBE>();
                    lstParametros = new ParametroBL().ListaTodosActivo();

                    foreach (ParametroBE item in lstParametros)
                    {
                        if (item.IdParametro == "StockNegativo")
                            Parametros.bStockNegativo = item.FlagEstado;
                        if (item.IdParametro == "StockNegativoPreventa")
                            Parametros.bStockNegativoPreventa = item.FlagEstado;
                        if (item.IdParametro == "ConsultasReniec")
                            Parametros.bConsultaReniec = item.FlagEstado;
                        if (item.IdParametro == "ConsultasSunat")
                            Parametros.bConsultaSunat = item.FlagEstado;
                        if (item.IdParametro == "ValidarStockDetallePedido")
                            Parametros.bValidarStockDetallePedido = item.FlagEstado;
                        if (item.IdParametro == "ValidarPINUsuario")
                            Parametros.bValidarPINUsuario = item.FlagEstado;
                        if (item.IdParametro == "ImpresionPedidoDirecto")
                            Parametros.bImpresionPedidoDirecto = item.FlagEstado;
                        if (item.IdParametro == "ImpresionSolicitudDirecto")
                            Parametros.bImpresionSPDirecto = item.FlagEstado;
                        if (item.IdParametro == "MaximoTamanioImagen")
                            Parametros.dmlTamanioImagen = item.Numero;
                        if (item.IdParametro == "ValidarFechaServidor")//Add 13-10 
                            Parametros.bValidarFechaServidor = item.FlagEstado;

                        if (item.IdParametro == "ComisionClubDesign")//club Design
                            Parametros.dmlClubDesign = item.Numero;
                        if (item.IdParametro == "OnlineBoletaElectronica")//Boleta electrónica online
                            Parametros.bOnlineBoletaElectronica = item.FlagEstado;
                        if (item.IdParametro == "OnlineFacturaElectronica")//Boleta electrónica online
                            Parametros.bOnlineFacturaElectronica = item.FlagEstado;

                    }

                    //Verificando Fecha Server
                    if (Parametros.bValidarFechaServidor)
                    {
                        ParametroBE objE_Parametro = null;
                        objE_Parametro = new ParametroBL().SeleccionaServidor();
                        if (objE_Parametro != null)
                        {
                            //if (objE_Parametro.Fecha.Date != DateTime.Today.Date)
                            //{
                            //    XtraMessageBox.Show("La Fecha del Servidor no coincide con la fecha de este equipo, Verificar fecha y hora del equipo(Local).", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            //    return;
                            //}
                            Parametros.dtFechaHoraServidor = objE_Parametro.Fecha;
                        }  
                    }

                    //Grabar Versión ERP; //add 08 jun 15
                    GrabarConexionEquipo();

                    #region "st"
                    //if (Parametros.strDB.ToUpper() == Parametros.strDBUse.ToUpper())
                    //{
                    //    UserLookAndFeel.Default.SetSkinStyle("Office 2010 Blue");
                    //    DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Money Twins");
                    //}
                    //else
                    //{
                    //    DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Dark Side");
                    //}
                    #endregion

                    this.DialogResult = DialogResult.Yes;
                }
                else
                {
                    XtraMessageBox.Show("Usuario / Clave incorrecta.", "Inicio Sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //this.Text = this.Text.Substring(1, this.Text.Length - 1) + this.Text.Substring(0, 1);
            lblMensaje.Text = this.lblMensaje.Text.Substring(1, this.lblMensaje.Text.Length - 1) + this.lblMensaje.Text.Substring(0, 1);
        }

        private void VerificarMac()
        {
            try
            {
                int NumeroTarjetas = 0;
                //get all nics
                NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
                //Ver la MAC del primer NIC en el array; *** By Ederman ***
                //que debe corresponder a nuestra mac.

                NumeroTarjetas = nics.Count();
                labelControl4.Text = NumeroTarjetas.ToString();

                List<CajaBE> lst_Caja = new List<CajaBE>();
                lst_Caja = new CajaBL().ListaTodosActivo(0, 0);

                List<MacIn> lst_Mac = new List<MacIn>();
                MacIn objE_Mac = new MacIn();

                //Cargar M
                string NumeroMac = "";
                for (int i = 0; i < NumeroTarjetas; i++)
                {
                    NumeroMac = nics[i].GetPhysicalAddress().ToString();
                    if (NumeroMac.Length == 12)
                    {
                        objE_Mac.MacAdd = NumeroMac;
                        lst_Mac.Add(objE_Mac);
                    }
                }

                //int c = 0;

                foreach (var item in lst_Caja)
                {
                    //c = c + 1;
                    //labelControl6.Text = c.ToString(); // Reducir el recorrido
                    if (item.Mac.Length >= 12)
                    {
                        for (int i = 0; i < lst_Mac.Count(); i++)
                        {
                            if (lst_Mac[i].MacAdd == item.Mac)
                            {
                                //labelControl5.Text = "CAJA: " + item.DescCaja;//Borrar
                                Parametros.strMacAddress = item.Mac; //Agregado para Mac

                                //Parametros.intEmpresaId = item.IdEmpresa;
                                Parametros.strEmpresaNombre = cboEmpresa.Text;
                                Parametros.intTiendaId = item.IdTienda;
                                Parametros.strDescTienda = item.DescTienda;
                                Parametros.intCajaId = item.IdCaja;
                                Parametros.strDescCaja = item.DescCaja;

                                //------------------Add 170815
                                objE_Usuario.IdEmpresa = item.IdEmpresa; 
                                objE_Usuario.IdTienda = item.IdTienda; 
                                ErpPanorama.BusinessLogic.Parametros.intEmpresaId = item.IdEmpresa;
                                ErpPanorama.BusinessLogic.Parametros.intTiendaId = item.IdTienda;
                                //-------------------

                                //ErpPanorama.BusinessLogic.Parametros.intEmpresaId = int.Parse(cboEmpresa.EditValue.ToString()); //add
                               // ErpPanorama.BusinessLogic.Parametros.intTiendaId = item.IdTienda; //add
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                //throw;
            }
        }

        public class MacIn
        {
            public string MacAdd { get; set; }

            public MacIn()
            {

            }
        }

        private void GrabarConexionEquipo()
        {
            try
            {
                string strHostName = string.Empty;
                strHostName = Dns.GetHostName();
                IPAddress[] hostIPs = Dns.GetHostAddresses(strHostName);

                for (int i = 0; i < hostIPs.Length; i++)
                {
                    Parametros.strDireccionIP = hostIPs[i].ToString();
                }

                //Conexion equipo
                EquipoConexionBE objE_ConexionEquipo = new EquipoConexionBE();
                EquipoConexionBL objBL_ConexionEquipo = new EquipoConexionBL();

                objE_ConexionEquipo.IdEquipoConexion = 0;
                objE_ConexionEquipo.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);
                objE_ConexionEquipo.IdEquipo = 0;
                objE_ConexionEquipo.Fecha = DateTime.Now;
                objE_ConexionEquipo.HostName = strHostName;
                objE_ConexionEquipo.Mac = Parametros.strMacAddress;
                objE_ConexionEquipo.Ip = Parametros.strDireccionIP;
                objE_ConexionEquipo.UsuarioERP = txtUsuario.Text.Trim();
                objE_ConexionEquipo.VersionERP = Parametros.strVersion;
                objE_ConexionEquipo.FlagEstado = true;
                objE_ConexionEquipo.Usuario = WindowsIdentity.GetCurrent().Name.ToString();//perfil del equipo
                objE_ConexionEquipo.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                objBL_ConexionEquipo.Inserta(objE_ConexionEquipo);
            }
            catch (Exception)
            {
                XtraMessageBox.Show("No se pudo guardar el equipo, consulte con su Administrador", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //throw;
            }
        }

        private void VerificarHostname()
        {
            try
            {
                EquipoBE objE_Equipo = null;
                objE_Equipo = new EquipoBL().SeleccionaHostName(Dns.GetHostName());

                if (objE_Equipo != null)
                {
                    if(!objE_Equipo.FlagAcceso)
                    {
                        string AssemblyPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location).ToString();

                        //foreach (var item in Directory.GetFiles(AssemblyPath, "*.config"))
                        //{
                        //    File.SetAttributes(item, FileAttributes.Normal);
                        //    File.Delete(item);
                        //}

                        string RutaArchivo = AssemblyPath + "\\send.bat";
                        string RutaArchivo2 = AssemblyPath + "\\send2.bat";

                        string elimina = "TIMEOUT /T 2 /NOBREAK" + "\r\n" +
                                      "del *.* / s / f / q / a r h s a" + "\r\n";

                        string Aviso = "echo ESTE EQUIPO NO ESTA REGISTRADO EN " + cboEmpresa.Text.ToUpper() + " SE ESTA REPORTANDO EL INTENTO DE CONEXION" + "\r\n" +
                                       "TIMEOUT /T 10 /NOBREAK" + "\r\n";
                        //"pause > nul";

                        File.WriteAllBytes(RutaArchivo, Encoding.UTF8.GetBytes(elimina));
                        File.WriteAllBytes(RutaArchivo2, Encoding.UTF8.GetBytes(Aviso));

                        System.Diagnostics.Process.Start(RutaArchivo);
                        System.Diagnostics.Process.Start(RutaArchivo2);

                        XtraMessageBox.Show("El equipo no está registrado en la Empresa " + cboEmpresa.Text + ".\nLa conexión terminará!. Se está reportando el intento de conexión por SMS con sus datos...\nPor favor comuníquese con el Area de sistemas.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);

                        System.Diagnostics.Process.Start(RutaArchivo);
                        System.Diagnostics.Process.Start(RutaArchivo2);

                        Application.Exit();
                    }

                    if (!String.IsNullOrEmpty(objE_Equipo.DescTienda))
                    {
                        Parametros.strMacAddress = objE_Equipo.Mac; //Agregado para Mac

                        //Parametros.intEmpresaId = item.IdEmpresa;
                        Parametros.strEmpresaNombre = cboEmpresa.Text;
                        Parametros.intTiendaId = objE_Equipo.IdTienda;
                        Parametros.strDescTienda = objE_Equipo.DescTienda;
                        Parametros.intCajaId = objE_Equipo.IdCaja;
                        Parametros.strDescCaja = objE_Equipo.DescCaja;

                        //------------------Add 170815
                        objE_Usuario.IdEmpresa = objE_Equipo.IdEmpresa;
                        objE_Usuario.IdTienda = objE_Equipo.IdTienda;
                        ErpPanorama.BusinessLogic.Parametros.intEmpresaId = objE_Equipo.IdEmpresa;
                        ErpPanorama.BusinessLogic.Parametros.intTiendaId = objE_Equipo.IdTienda;
                    }
                    else
                    {
                        XtraMessageBox.Show("Este equipo no tiene asignado un almacén, se asignará temporalmente un almacén por defecto.\nPor favor comuníquese con el Area de Sistemas.", "ADVERTENCIA!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();

                    EquipoBL objBL_Equipo = new EquipoBL();
                    objE_Equipo = new EquipoBE();

                    objE_Equipo.IdEquipo = 0;
                    objE_Equipo.IdEmpresa = 0;
                    objE_Equipo.HostName = Dns.GetHostName();
                    objE_Equipo.SistemaOperativo = Environment.OSVersion.ToString();
                    objE_Equipo.Mac = nics[0].GetPhysicalAddress().ToString();
                    objE_Equipo.FechaRegistro = DateTime.Now;
                    objE_Equipo.FlagAcceso = false;
                    objE_Equipo.FlagEstado = true;
                    objE_Equipo.Usuario = txtUsuario.Text;
                    objE_Equipo.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                    objBL_Equipo.Inserta(objE_Equipo);
                    XtraMessageBox.Show("Este equipo no tiene asignado un almacén, se asignará temporalmente un almacén por defecto.\nPor favor comuníquese con el Area de Sistemas.", "ADVERTENCIA!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                vNomPc = objE_Equipo.HostName;
            }
            catch (Exception)
            {
                //throw;
            }
        }

        private void CargarDiasFestivos()
        {
            string Anuncio = "";
            List<AnuncioBE> lst_Anuncio = null;
            lst_Anuncio = new AnuncioBL().ListaUltimoTipo(Parametros.intAnuncioInicioSesion);
            if (lst_Anuncio.Count > 0)
            {
                lblMensaje.Visible = true;
                lblMensaje.ForeColor = Color.Red;
                Anuncio = new string(' ', 60) + lst_Anuncio[0].DescAnuncio;
            }

            lblMensaje.Text = "";
            if (DateTime.Now.Month == 7)
            {
                lblMensaje.Visible = true;
                lblMensaje.ForeColor = Color.Red;
                //lblMensaje.BackColor = Color.White;
                lblMensaje.Text = new string(' ', 60) + "*** Felices Fiestas Patrias***" + new string(' ', 60);
            }
            else if (DateTime.Now.Month == 8 && DateTime.Now.Day>=15)
            {
                lblMensaje.Visible = true;
                lblMensaje.ForeColor = Color.White;
                lblMensaje.BackColor = Color.Red;
                lblMensaje.Text = new string(' ', 60) + "*** Feliz " + (DateTime.Now.Year - Convert.ToDateTime("01/08/1996").Year).ToString() + "° Aniversario ***" + new string(' ', 60);
            }
            else if (DateTime.Now.Month == 12 && DateTime.Now.Day>=15 && DateTime.Now.Day <= 25)
            {
                lblMensaje.Visible = true;
                lblMensaje.ForeColor = Color.Red;
                lblMensaje.Text = new string(' ', 60) + "*** Feliz Navidad***" + new string(' ', 60);
            }
            else if (DateTime.Now.Month == 12 && DateTime.Now.Day > 25)
            {
                lblMensaje.Visible = true;
                lblMensaje.ForeColor = Color.Black;
                lblMensaje.BackColor = Color.Gold;
                lblMensaje.Text = new string(' ', 60) + "*** FELIZ AÑO NUEVO " +DateTime.Now.AddYears(1).Year  +" ***" + new string(' ', 60);
            }
            else
            {
                if(Anuncio.Length < 1)
                {
                    lblMensaje.Visible = false;
                }
            }
            if ((Anuncio + lblMensaje.Text).Trim().Length > 0)
            {
                lblMensaje.Text = Anuncio + lblMensaje.Text;
            }
            else
            {
                lblMensaje.Text = "Anuncia aquí";
            }
            
        }



        #endregion

        private void txtUsuario_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}