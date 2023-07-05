using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Data;
using System.Drawing;
using System.Resources;
using System.Reflection;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.ComercioExterior.Maestros
{
    public partial class frmManProveedorEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<ProveedorBE> lstProveedor;
        public List<CProveedorCuentas> mLista = new List<CProveedorCuentas>();
        public int vRefresca = 0;
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public ProveedorBE pProveedorBE { get; set; }

        int _IdProveedor = 0;

        public int IdProveedor
        {
            get { return _IdProveedor; }
            set { _IdProveedor = value; }
        }
        private int IdPais = 9589;
        public int IdProveedor1 = 0;
        //public string DocProveedor = "";
        //public string NomProveedor = "";
        public int IdProveedor2 { get; set; }
        public string DocProveedor { get; set; }
        public string NomProveedor { get; set; }
        #endregion

        #region "Eventos"

        public frmManProveedorEdit()
        {
            InitializeComponent();
        }

        private void frmManProveedorEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboDocumento, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblTipoDocCliente), "DescTablaElemento", "IdTablaElemento", true);
            cboDocumento.EditValue = Parametros.intTipoDocumentoRUC;
            BSUtils.LoaderLook(cboBancoSoles, new BancoBL().ListaTodosActivo(Parametros.intEmpresaId), "DescBanco", "IdBanco", true);
            BSUtils.LoaderLook(cboBancoDolares, new BancoBL().ListaTodosActivo(Parametros.intEmpresaId), "DescBanco", "IdBanco", true);

            BSUtils.LoaderLook(cboPais, new PaisBL().ListaTodosActivo(Parametros.intEmpresaId), "DescPais", "IdPais", true);
            cboPais.EditValue = 9589;

            BSUtils.LoaderLook(cboFrecuenciaPago, CargarFormaPago(), "Descripcion", "Id", true);
            BSUtils.LoaderLook(cboDiaSemana, CargarDiaSemana(), "Descripcion", "Id", true);

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Proveedor - Nuevo";
                rbNacional.Checked = true;
                //txtDescPais.Text = "PERU";
                txtNumeroDocumento.Select();
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Proveedor - Modificar";
                txtDescripcion.Text = pProveedorBE.DescProveedor.Trim();

                ProveedorBE objE_Proveedor = new ProveedorBE();
                objE_Proveedor = new ProveedorBL().Selecciona(IdProveedor);

                //txtDescPais.Text = objE_Proveedor.DescPais;
                IdPais = objE_Proveedor.IdPais;
                cboPais.EditValue = objE_Proveedor.IdPais;
                cboDocumento.EditValue = objE_Proveedor.IdTipoDocumento;
                txtNumeroDocumento.Text = objE_Proveedor.NumeroDocumento;
                txtDescripcion.Text = objE_Proveedor.DescProveedor;
                txtDiasCredito.EditValue = objE_Proveedor.DiasCredito;
                txtDireccion.Text = objE_Proveedor.Direccion;
                txtDireccionTienda.Text = objE_Proveedor.DireccionTienda;
                txtContacto.Text = objE_Proveedor.Contacto;
                txtContactoCredito.Text = objE_Proveedor.ContactoCredito;
                txtEmail.Text = objE_Proveedor.Email;
                txtEmail2.Text = objE_Proveedor.Email2;
                txtTelefono.Text = objE_Proveedor.Telefono;
                txtCelular.Text = objE_Proveedor.Celular;
                cboBancoSoles.EditValue = objE_Proveedor.IdBanco;
                cboBancoDolares.EditValue = objE_Proveedor.IdBancoDolares;
                txtCuentaSoles.Text = objE_Proveedor.CuentaBancoSoles;
                txtCuentaDolares.Text = objE_Proveedor.CuentaBancoDolares;
                txtCCISoles.Text = objE_Proveedor.CCISoles;
                txtCCIDolares.Text = objE_Proveedor.CCIDolares;
                txtBancoIntermediario.Text = objE_Proveedor.BancoIntermediario;
                txtBancoPagador.Text = objE_Proveedor.BancoPagador;
                txtSwiftIntermediario.Text = objE_Proveedor.CodigoSwiftIntermediario;
                txtSwiftPagador.Text = objE_Proveedor.CodigoSwiftPagador;
                txtDireccionIntermediario.Text = objE_Proveedor.DireccionIntermediario;
                txtDireccionPagador.Text = objE_Proveedor.DireccionPagador;
                txtObservacion.Text = objE_Proveedor.Observacion;
                txtAcuerdos.Text = objE_Proveedor.Acuerdos;
                cboFrecuenciaPago.EditValue = objE_Proveedor.TipoPago;
                deFechaPago.EditValue =  objE_Proveedor.FechaPago;

                if (objE_Proveedor.Procedencia==1)
                {
                    rbNacional.Checked = true;
                }
                else if (objE_Proveedor.Procedencia == 2)
                {
                    rbExtrnajero.Checked = true;
                    gcBeneficiario.Enabled = true;
                }
                cboPais.EditValue = objE_Proveedor.IdPais;
                txtBenefNombre.Text = objE_Proveedor.BeneficiarioNombre;
                txtBenefDireccion.Text = objE_Proveedor.BeneficiarioDireccion;
                txtBenefAbono.Text  = objE_Proveedor.BeneficiarioAbono;
                txtBenefPais.Text = objE_Proveedor.BeneficiarioPais;

                txtBancoSwift.Text= objE_Proveedor.BancoSwift;
                txtBancoNombre.Text= objE_Proveedor.BancoNombre;
                txtBancoDireccion.Text = objE_Proveedor.BancoDireccion;
                txtBancoPais.Text= objE_Proveedor.BancoPais;
                txtBancoCiudad.Text = objE_Proveedor.BancoCiudad;
                chkCredito.Checked = Convert.ToBoolean(objE_Proveedor.PCredito);
                if (Convert.ToInt32(cboFrecuenciaPago.EditValue)==7)
                {
                    cboDiaSemana.EditValue = objE_Proveedor.DiaSemMes;
                }else
                {
                    txtDiaPago.EditValue = objE_Proveedor.DiaSemMes;
                }
                txtDescripcion.Select();
            }

            //Cargar Bancos
            CargarCuentasBancos();


        }

        private void CargarCuentasBancos()
        {
            List<CuentaBancoBE> lstTmpProductoAsociado = null;
            lstTmpProductoAsociado = new CuentaBancoBL().ListaTodosActivoProveedor(IdProveedor);

            foreach (CuentaBancoBE item in lstTmpProductoAsociado)
            {
                CProveedorCuentas objE_CuentasBancos = new CProveedorCuentas();
                objE_CuentasBancos.IdCuentaBancoProveedor = item.IdCuentaBancoProveedor;
                objE_CuentasBancos.IdProveedor = item.IdProveedor;
                objE_CuentasBancos.IdBanco = item.IdBanco;
                objE_CuentasBancos.DescBanco = item.DescBanco;
                objE_CuentasBancos.IdMoneda = item.IdMoneda;
                objE_CuentasBancos.DescMoneda = item.DescMoneda;
                objE_CuentasBancos.Cuenta = item.NumeroCuenta;
                objE_CuentasBancos.cci = item.CCI;
                objE_CuentasBancos.IdTipoCuenta = item.IdTipoCuenta;
                objE_CuentasBancos.DescTipoCuenta = item.DescTipoCuenta;
                objE_CuentasBancos.TipoOper = item.TipoOper;
                mLista.Add(objE_CuentasBancos);
            }

            bsListado.DataSource = mLista;
            gcProveedorCuentas.DataSource = bsListado;
            gcProveedorCuentas.RefreshDataSource();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                int vProcedencia = 1;

                if (rbNacional.Checked)
                {
                    vProcedencia = 1;
                }
                 else if(rbExtrnajero.Checked)
                 {
                    vProcedencia = 2;
                }

                if (!ValidarIngreso())
                {
                    ProveedorBL objBL_Proveedor = new ProveedorBL();

                    ProveedorBE objProveedor = new ProveedorBE();
                    objProveedor.IdProveedor = IdProveedor;
                    objProveedor.DescProveedor = txtDescripcion.Text.Trim();
                    objProveedor.IdPais = Convert.ToInt32(cboPais.EditValue);//IdPais;
                    //objProveedor.DescPais = txtDescPais.Text;
                    objProveedor.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                    objProveedor.NumeroDocumento = txtNumeroDocumento.Text.Trim();
                    objProveedor.DescProveedor = txtDescripcion.Text.Trim();
                    objProveedor.Direccion = txtDireccion.Text.Trim();
                    objProveedor.DireccionTienda = txtDireccionTienda.Text;
                    objProveedor.Contacto = txtContacto.Text;
                    objProveedor.ContactoCredito = txtContactoCredito.Text;
                    objProveedor.Email = txtEmail.Text;
                    objProveedor.Email2 = txtEmail2.Text;
                    objProveedor.Telefono = txtTelefono.Text;
                    objProveedor.Celular = txtCelular.Text;
                    objProveedor.IdBanco = Convert.ToInt32(cboBancoSoles.EditValue);
                    objProveedor.IdBancoDolares = Convert.ToInt32(cboBancoDolares.EditValue);
                    objProveedor.CuentaBancoSoles = txtCuentaSoles.Text;
                    objProveedor.CuentaBancoDolares = txtCuentaDolares.Text;
                    objProveedor.CCISoles = txtCCISoles.Text;
                    objProveedor.CCIDolares = txtCCIDolares.Text;
                    objProveedor.IdProveedorReferencia = 0;
                    objProveedor.DiasCredito = Convert.ToInt32(txtDiasCredito.EditValue);
                    objProveedor.BancoIntermediario = txtBancoIntermediario.Text;
                    objProveedor.BancoPagador = txtBancoPagador.Text;
                    objProveedor.CodigoSwiftIntermediario = txtSwiftIntermediario.Text;
                    objProveedor.CodigoSwiftPagador = txtSwiftPagador.Text;
                    objProveedor.DireccionIntermediario = txtDireccionIntermediario.Text;
                    objProveedor.DireccionPagador = txtDireccionPagador.Text;
                    objProveedor.Observacion = txtObservacion.Text;
                    objProveedor.Acuerdos = txtAcuerdos.Text.Trim();
                    objProveedor.TipoPago = Convert.ToInt32(cboFrecuenciaPago.EditValue);
                    objProveedor.DiaSemMes = Convert.ToInt32(cboFrecuenciaPago.EditValue) == 7 ? Convert.ToInt32(cboDiaSemana.EditValue) : Convert.ToInt32(txtDiaPago.EditValue); //Convert.ToInt32(txtDiaPago.EditValue);
                    objProveedor.FechaPago = deFechaPago.Text ==""?(DateTime?)null:Convert.ToDateTime(deFechaPago.DateTime.ToShortDateString());
                    objProveedor.FlagEstado = true;
                    objProveedor.Usuario = Parametros.strUsuarioLogin;
                    objProveedor.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objProveedor.IdEmpresa = Parametros.intEmpresaId;
                    // Ultimos ingresos
                    objProveedor.Procedencia = vProcedencia;
                    objProveedor.BeneficiarioNombre = txtBenefNombre.Text;
                    objProveedor.BeneficiarioAbono = txtBenefAbono.Text;
                    objProveedor.BeneficiarioDireccion = txtBenefDireccion.Text;
                    objProveedor.BeneficiarioPais = txtBenefPais.Text;

                    objProveedor.BancoSwift = txtBancoSwift.Text;
                    objProveedor.BancoNombre = txtBancoNombre.Text;
                    objProveedor.BancoDireccion = txtBancoDireccion.Text;
                    objProveedor.BancoPais = txtBancoPais.Text;
                    objProveedor.BancoCiudad = txtBancoCiudad.Text;
                    objProveedor.PCredito = Convert.ToBoolean(chkCredito.Checked);

                    //IdPedido == 0 ? (int?)null : IdPedido;

                    if (pOperacion == Operacion.Nuevo)
                        IdProveedor1 = objBL_Proveedor.Inserta(objProveedor);
                    else
                        objBL_Proveedor.Actualiza(objProveedor);

                    IdProveedor2 = IdProveedor1;
                    DocProveedor = txtNumeroDocumento.Text.Trim();
                    NomProveedor = txtDescripcion.Text.Trim();

                    //Cuenta Banco Proveedor
                    List<CuentaBancoBE> lstCuentaBcoProveedor = new List<CuentaBancoBE>();
                    foreach (var item in mLista)
                    {
                        CuentaBancoBE objE_CuentaBancoProveedor = new CuentaBancoBE();
                        objE_CuentaBancoProveedor.IdCuentaBancoProveedor = item.IdCuentaBancoProveedor;
                        objE_CuentaBancoProveedor.IdProveedor = pOperacion == Operacion.Nuevo ? IdProveedor1 : IdProveedor;
                        objE_CuentaBancoProveedor.IdBanco = item.IdBanco;
                        objE_CuentaBancoProveedor.DescBanco = item.DescBanco;
                        objE_CuentaBancoProveedor.IdMoneda = item.IdMoneda;
                        objE_CuentaBancoProveedor.DescMoneda = item.DescMoneda;
                        objE_CuentaBancoProveedor.NumeroCuenta = item.Cuenta;
                        objE_CuentaBancoProveedor.CCI = item.cci;
                        objE_CuentaBancoProveedor.IdTipoCuenta = item.IdTipoCuenta;
                        objE_CuentaBancoProveedor.DescTipoCuenta = item.DescTipoCuenta;
                        objE_CuentaBancoProveedor.TipoOper = item.TipoOper == 0 ? 1 : item.TipoOper;  
                        objE_CuentaBancoProveedor.FlagEstado = true;  
                        lstCuentaBcoProveedor.Add(objE_CuentaBancoProveedor);
                    }

                    CuentaBancoBL objBL_CuentaBancoProveedor = new CuentaBancoBL();
                    if (pOperacion == Operacion.Nuevo)
                    {
                        //Cuenta banco proveedor
                        objBL_CuentaBancoProveedor.InsertaCuentaBancoProveedor(lstCuentaBcoProveedor);
                    }
                    else
                        objBL_CuentaBancoProveedor.InsertaCuentaBancoProveedor(lstCuentaBcoProveedor);

                    vRefresca = 1;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            vRefresca = 0;
            this.Close();
        }

        private void cboPais_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboPais.EditValue) == 9589)
            {
                cboBancoSoles.Properties.ReadOnly = false;
                cboBancoDolares.Properties.ReadOnly = false;
                txtCuentaSoles.Properties.ReadOnly = false;
                txtCuentaDolares.Properties.ReadOnly = false;
                txtCCISoles.Properties.ReadOnly = false;
                txtCCIDolares.Properties.ReadOnly = false;


                gpcIntermediario.Enabled = false;
                gpcPagador.Enabled = false;

                gcBeneficiario.Enabled = false;
            }
            else
            {
                cboBancoSoles.Properties.ReadOnly = true;
                cboBancoDolares.Properties.ReadOnly = true;
                txtCuentaSoles.Properties.ReadOnly = true;
                txtCuentaDolares.Properties.ReadOnly = true;
                txtCCISoles.Properties.ReadOnly = true;
                txtCCIDolares.Properties.ReadOnly = true;

                gpcIntermediario.Enabled = true;
                gpcPagador.Enabled = true;

                gcBeneficiario.Enabled = true;
            }
        }

        private void cboPais_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void cboDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtNumeroDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtDiasCredito_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtDireccionTienda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtContacto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtContactoCredito_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtEmail2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void cboBancoSoles_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtCuentaSoles_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtCCISoles_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void cboBancoDolares_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtCuentaDolares_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtCCIDolares_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtBancoIntermediario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtSwiftIntermediario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtDireccionIntermediario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtBancoPagador_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtSwiftPagador_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtDireccionPagador_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        #endregion

        #region "Metodos"

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            if (txtDescripcion.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese la descripción.\n";
                flag = true;
            }

            if (txtDescripcion.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese la descripción.\n";
                flag = true;
            }


            if (pOperacion == Operacion.Nuevo)
            {
                if (Convert.ToInt32(cboPais.EditValue)== 9589)
                {
                    ProveedorBE objE_Proveedor = null;
                    objE_Proveedor = new ProveedorBL().SeleccionaNumero(txtNumeroDocumento.Text);

                    if (objE_Proveedor != null)
                    {
                        strMensaje = strMensaje + "- El Proveedor ya existe.\n";
                        flag = true;
                    }
                }


                var Buscar = lstProveedor.Where(oB => oB.DescProveedor.ToUpper() == txtDescripcion.Text.ToUpper()).ToList();
                if (Buscar.Count > 0)
                {
                    strMensaje = strMensaje + "- El Proveedor ya existe.\n";
                    flag = true;
                }


            }
            else //modificar
            {
                if (Convert.ToInt32(cboPais.EditValue) == 9589)
                {
                    ProveedorBE objE_Proveedor = null;
                    objE_Proveedor = new ProveedorBL().SeleccionaNumero(txtNumeroDocumento.Text);

                    if (objE_Proveedor != null)
                    {
                        if (objE_Proveedor.IdProveedor != IdProveedor)
                        {
                            strMensaje = strMensaje + "- El Proveedor ya existe.\n";
                            flag = true;
                        }
                        else
                        {
                            flag = false;
                        }
                    }
                }
            }

            if (flag)
            {
                XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cursor = Cursors.Default;
            }
            return flag;
        }

        private DataTable CargarFormaPago()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", Type.GetType("System.Int32"));
            dt.Columns.Add("Descripcion", Type.GetType("System.String"));
            DataRow dr;
            dr = dt.NewRow();
            dr["Id"] = 0;
            dr["Descripcion"] = "NINGUNO";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 1;
            dr["Descripcion"] = "DIARIO";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 7;
            dr["Descripcion"] = "SEMANAL";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 15;
            dr["Descripcion"] = "QUINCENAL";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 30;
            dr["Descripcion"] = "MENSUAL";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 50;
            dr["Descripcion"] = "FECHA FIJA";
            dt.Rows.Add(dr);
            return dt;
        }

        private DataTable CargarDiaSemana()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", Type.GetType("System.Int32"));
            dt.Columns.Add("Descripcion", Type.GetType("System.String"));
            DataRow dr;
            dr = dt.NewRow();
            dr["Id"] = 0;
            dr["Descripcion"] = "Lunes";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 1;
            dr["Descripcion"] = "Martes";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 2;
            dr["Descripcion"] = "Miércoles";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 3;
            dr["Descripcion"] = "Jueves";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 4;
            dr["Descripcion"] = "Viernes";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 5;
            dr["Descripcion"] = "Sábado";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 6;
            dr["Descripcion"] = "Domingo";
            dt.Rows.Add(dr);
            return dt;
        }
        #endregion

        private void cboFrecuenciaPago_EditValueChanged(object sender, EventArgs e)
        {
            int IdFrecuencia = Convert.ToInt32(cboFrecuenciaPago.EditValue);
            switch (IdFrecuencia)
            {
                case 0:
                    //Ninguno
                    txtDiaPago.Visible = false;
                    cboDiaSemana.Visible = false;
                    deFechaPago.Visible = false;
                    break;
                case 1:
                    //Diario
                    txtDiaPago.Visible = false;
                    cboDiaSemana.Visible = false;
                    deFechaPago.Visible = false;
                    break;
                case 7:
                    //Semanal
                    txtDiaPago.Visible = false;
                    cboDiaSemana.Visible = true;
                    deFechaPago.Visible = false;
                    break;
                case 15:
                    //Quincenal
                    txtDiaPago.Visible = true;
                    cboDiaSemana.Visible = false;
                    deFechaPago.Visible = false;
                    break;
                case 30:
                    //Mensual
                    txtDiaPago.Visible = true;
                    cboDiaSemana.Visible = false;
                    deFechaPago.Visible = false;
                    break;
                case 50:
                    //Fecha Fija
                    txtDiaPago.Visible = false;
                    cboDiaSemana.Visible = false;
                    deFechaPago.Visible = true;
                    break;
                default:
                    //0
                    break;
            }
        }

        public class CProveedorCuentas
        {
            public Int32 IdCuentaBancoProveedor { get; set; }
            public Int32 IdProveedor { get; set; }
            public Int32 IdBanco { get; set; }
            public string DescBanco { get; set; }
            public Int32 IdMoneda { get; set; }
            public string DescMoneda { get; set; }
            public String Cuenta { get; set; }
            public String cci { get; set; }

            public Int32 IdTipoCuenta { get; set; }
            public string DescTipoCuenta { get; set; }
            public Int32 TipoOper { get; set; }

            public CProveedorCuentas()
            {

            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                frmProveedorCuenta movDetalle = new frmProveedorCuenta();
                movDetalle.Boton=1;

                if (movDetalle.ShowDialog() == DialogResult.OK)
                {
                    if (movDetalle.oBE != null)
                    {
                        if (mLista.Count == 0)
                        {
                            gvProveedorCuentas.AddNewRow();
                            gvProveedorCuentas.SetRowCellValue(gvProveedorCuentas.FocusedRowHandle, "IdCuentaBancoProveedor", movDetalle.oBE.IdCuentaBancoProveedor);
                            gvProveedorCuentas.SetRowCellValue(gvProveedorCuentas.FocusedRowHandle, "IdProveedor", IdProveedor);
                            gvProveedorCuentas.SetRowCellValue(gvProveedorCuentas.FocusedRowHandle, "IdBanco", movDetalle.oBE.IdBanco);
                            gvProveedorCuentas.SetRowCellValue(gvProveedorCuentas.FocusedRowHandle, "DescBanco", movDetalle.oBE.DescBanco);
                            gvProveedorCuentas.SetRowCellValue(gvProveedorCuentas.FocusedRowHandle, "IdMoneda", movDetalle.oBE.IdMoneda);
                            gvProveedorCuentas.SetRowCellValue(gvProveedorCuentas.FocusedRowHandle, "DescMoneda", movDetalle.oBE.DescMoneda);
                            gvProveedorCuentas.SetRowCellValue(gvProveedorCuentas.FocusedRowHandle, "Cuenta", movDetalle.oBE.Cuenta);
                            gvProveedorCuentas.SetRowCellValue(gvProveedorCuentas.FocusedRowHandle, "cci", movDetalle.oBE.cci);
                            gvProveedorCuentas.SetRowCellValue(gvProveedorCuentas.FocusedRowHandle, "IdTipoCuenta", movDetalle.oBE.IdTipoCuenta);
                            gvProveedorCuentas.SetRowCellValue(gvProveedorCuentas.FocusedRowHandle, "DescTipoCuenta", movDetalle.oBE.DescTipoCuenta);
                            gvProveedorCuentas.SetRowCellValue(gvProveedorCuentas.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            gvProveedorCuentas.UpdateCurrentRow();

                            return;
                        }
                        if (mLista.Count > 0)
                        {
                            //var Buscar = mLista.Where(oB => oB.IdProducto == movDetalle.oBE.IdProducto).ToList();
                            //if (Buscar.Count > 0)
                            //{
                            //    XtraMessageBox.Show("El código de producto ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //    return;
                            //}
                            gvProveedorCuentas.AddNewRow();
                            gvProveedorCuentas.SetRowCellValue(gvProveedorCuentas.FocusedRowHandle, "IdCuentaBancoProveedor", movDetalle.oBE.IdCuentaBancoProveedor);
                            gvProveedorCuentas.SetRowCellValue(gvProveedorCuentas.FocusedRowHandle, "IdProveedor", IdProveedor);
                            gvProveedorCuentas.SetRowCellValue(gvProveedorCuentas.FocusedRowHandle, "IdBanco", movDetalle.oBE.IdBanco);
                            gvProveedorCuentas.SetRowCellValue(gvProveedorCuentas.FocusedRowHandle, "DescBanco", movDetalle.oBE.DescBanco);
                            gvProveedorCuentas.SetRowCellValue(gvProveedorCuentas.FocusedRowHandle, "IdMoneda", movDetalle.oBE.IdMoneda);
                            gvProveedorCuentas.SetRowCellValue(gvProveedorCuentas.FocusedRowHandle, "DescMoneda", movDetalle.oBE.DescMoneda);
                            gvProveedorCuentas.SetRowCellValue(gvProveedorCuentas.FocusedRowHandle, "Cuenta", movDetalle.oBE.Cuenta);
                            gvProveedorCuentas.SetRowCellValue(gvProveedorCuentas.FocusedRowHandle, "cci", movDetalle.oBE.cci);
                            gvProveedorCuentas.SetRowCellValue(gvProveedorCuentas.FocusedRowHandle, "IdTipoCuenta", movDetalle.oBE.IdTipoCuenta);
                            gvProveedorCuentas.SetRowCellValue(gvProveedorCuentas.FocusedRowHandle, "DescTipoCuenta", movDetalle.oBE.DescTipoCuenta);
                            gvProveedorCuentas.SetRowCellValue(gvProveedorCuentas.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            gvProveedorCuentas.UpdateCurrentRow();

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (mLista.Count > 0)
                {
                    if (int.Parse(gvProveedorCuentas.GetFocusedRowCellValue("IdProveedor").ToString()) != 0)
                    {
                        int IdCuentaBancoProveedor = 0;
                        if (gvProveedorCuentas.GetFocusedRowCellValue("IdCuentaBancoProveedor") != null)
                            IdCuentaBancoProveedor = int.Parse(gvProveedorCuentas.GetFocusedRowCellValue("IdCuentaBancoProveedor").ToString());

                        int Item = 0;
                        if (gvProveedorCuentas.GetFocusedRowCellValue("Item") != null)
                            Item = int.Parse(gvProveedorCuentas.GetFocusedRowCellValue("Item").ToString());

                        CuentaBancoBE objBE_CtaBcoProveedor = new CuentaBancoBE();
                        objBE_CtaBcoProveedor.IdCuentaBancoProveedor = IdCuentaBancoProveedor;
                        //objBE_ProductoAsociado.IdEmpresa = Parametros.intEmpresaId;
                        //objBE_ProductoAsociado.Usuario = Parametros.strUsuarioLogin;
                        //objBE_ProductoAsociado.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                        CuentaBancoBL objBL_CuentaBanco = new CuentaBancoBL();
                        objBL_CuentaBanco.EliminaCuentaBancoProvee(objBE_CtaBcoProveedor);
                        gvProveedorCuentas.DeleteRow(gvProveedorCuentas.FocusedRowHandle);
                        gvProveedorCuentas.RefreshData();
                    }
                    else
                    {
                        gvProveedorCuentas.DeleteRow(gvProveedorCuentas.FocusedRowHandle);
                        gvProveedorCuentas.RefreshData();
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (mLista.Count > 0)
            {
                int xposition = 0;
                int IdProductoAsociado = Convert.ToInt32(gvProveedorCuentas.GetFocusedRowCellValue("IdProductoAsociado"));
                int IdProductoReferencia = Convert.ToInt32(gvProveedorCuentas.GetFocusedRowCellValue("IdProductoReferencia"));

                frmProveedorCuenta movDetalle = new frmProveedorCuenta();
                movDetalle.Boton = 2;
                movDetalle.IdProveedor = Convert.ToInt32(gvProveedorCuentas.GetFocusedRowCellValue("IdProveedor"));
                movDetalle.IdCuentaBancoProveedor = Convert.ToInt32(gvProveedorCuentas.GetFocusedRowCellValue("IdCuentaBancoProveedor"));

                movDetalle.IdBanco = Convert.ToInt32(gvProveedorCuentas.GetFocusedRowCellValue("IdBanco"));
                //movDetalle.cboBanco.EditValue = gvProveedorCuentas.GetFocusedRowCellValue("IdBanco").ToString();

                movDetalle.IdMoneda = Convert.ToInt32(gvProveedorCuentas.GetFocusedRowCellValue("IdMoneda"));
                //movDetalle.cboMoneda.EditValue = gvProveedorCuentas.GetFocusedRowCellValue("IdMoneda").ToString();

                movDetalle.IdTipoCuenta = Convert.ToInt32(gvProveedorCuentas.GetFocusedRowCellValue("IdTipoCuenta"));
                //movDetalle.cboTipoCuenta.EditValue = gvProveedorCuentas.GetFocusedRowCellValue("IdTipoCuenta").ToString();

                movDetalle.txtCuenta.Text= gvProveedorCuentas.GetFocusedRowCellValue("Cuenta").ToString();
                movDetalle.txtCCI.Text = gvProveedorCuentas.GetFocusedRowCellValue("cci").ToString();

                if (movDetalle.ShowDialog() == DialogResult.OK)
                {
                    xposition = gvProveedorCuentas.FocusedRowHandle;

                    if (movDetalle.oBE != null)
                    {
                        gvProveedorCuentas.SetRowCellValue(xposition, "IdCuentaBancoProveedor", movDetalle.oBE.IdCuentaBancoProveedor);
                        gvProveedorCuentas.SetRowCellValue(xposition, "IdProveedor", IdProveedor);
                        gvProveedorCuentas.SetRowCellValue(xposition, "IdBanco", movDetalle.oBE.IdBanco);
                        gvProveedorCuentas.SetRowCellValue(xposition, "DescBanco", movDetalle.oBE.DescBanco);
                        gvProveedorCuentas.SetRowCellValue(xposition, "IdMoneda", movDetalle.oBE.IdMoneda);
                        gvProveedorCuentas.SetRowCellValue(xposition, "DescMoneda", movDetalle.oBE.DescMoneda);

                        gvProveedorCuentas.SetRowCellValue(xposition, "IdTipoCuenta", movDetalle.oBE.IdTipoCuenta);
                        gvProveedorCuentas.SetRowCellValue(xposition, "DescTipoCuenta", movDetalle.oBE.DescTipoCuenta);

                        gvProveedorCuentas.SetRowCellValue(xposition, "Cuenta", movDetalle.oBE.Cuenta);
                        gvProveedorCuentas.SetRowCellValue(xposition, "cci", movDetalle.oBE.cci);

                        if (pOperacion == Operacion.Modificar && Convert.ToDecimal(gvProveedorCuentas.GetFocusedRowCellValue("TipoOper")) == Convert.ToInt32(Operacion.Nuevo))
                            gvProveedorCuentas.SetRowCellValue(xposition, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                        else
                            gvProveedorCuentas.SetRowCellValue(xposition, "TipoOper", Convert.ToInt32(Operacion.Modificar));
                        gvProveedorCuentas.UpdateCurrentRow();
                    }
                }
            }
        }

        private void rbExtrnajero_Click(object sender, EventArgs e)
        {
            if (rbNacional.Checked)
            {
                cboPais.Enabled = false;
                cboPais.EditValue = 9589;
            }
            else if(rbExtrnajero.Checked)
            {
                cboPais.Enabled = true;
                cboPais.EditValue = 9589;
                cboPais.Select();
            }
        }

        private void rbNacional_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNacional.Checked)
            {
                cboPais.Enabled = false;
                cboPais.EditValue = 9589;

                txtBenefNombre.Text = "";
                txtBenefAbono.Text = "";
                txtBenefDireccion.Text = "";
                txtBenefPais.Text = "";

                txtBancoNombre.Text = "";
                txtBancoDireccion.Text = "";
                txtBancoCiudad.Text = "";
                txtBancoSwift.Text = "";
                txtBancoPais.Text = "";

                txtNumeroDocumento.Select();
            }
            else if (rbExtrnajero.Checked)
            {
                cboPais.Enabled = true;
 //               cboPais.EditValue = 9589;




                cboPais.Select();
            }
        }

        private void rbExtrnajero_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNacional.Checked)
            {
                cboPais.Enabled = false;
                cboPais.EditValue = 9589;
            }
            else if (rbExtrnajero.Checked)
            {
                cboPais.Enabled = true;
                cboPais.EditValue = 9589;
                cboPais.Select();
            }
        }

        private void txtBenefNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtBenefAbono.Focus();
            }
        }

        private void txtBenefAbono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtBenefDireccion.Focus();
            }
        }

        private void txtBenefDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtBenefPais.Focus();
            }
        }

        private void txtBenefPais_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtBancoSwift.Focus();
            }
        }

        private void txtBancoSwift_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtBancoNombre.Focus();
            }
        }

        private void txtBancoNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtBancoDireccion.Focus();
            }
        }

        private void txtBancoDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtBancoPais.Focus();
            }
        }

        private void txtBancoPais_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtBancoCiudad.Focus();
            }
        }

        private void txtBancoCiudad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtObservacion.Focus();
            }
        }

        private void chkCredito_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCredito.Checked)
            { chkCredito.Font = new Font(chkCredito.Font, FontStyle.Bold); }
            else
            { chkCredito.Font = new Font(chkCredito.Font, FontStyle.Regular); }
        }
    }
}