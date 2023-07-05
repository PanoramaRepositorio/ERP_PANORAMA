using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Security.Principal;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.Ventas.Otros
{
    public partial class frmModificaPrecioDescuento : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public decimal PrecioUnitario { get; set; }
        public decimal Descuento { get; set; }
        public int IdProducto = 0;
        public int IdPedido = 0;
        private string UsuarioAutoriza = "";
        public bool Nuevo = false;
        public string Origen = "";
        public int IdLineaProducto { get; set; } = 0;


        #endregion

        #region "Eventos"
        public frmModificaPrecioDescuento()
        {
            InitializeComponent();
        }

        private void frmModificaPrecioDescuento_Load(object sender, EventArgs e)
        {

            ////Agregado en campaña 2019
            ////Navidad
            //if (IdLineaProducto == 10 || IdLineaProducto == 16 || IdLineaProducto == 17 || IdLineaProducto == 18 || IdLineaProducto == 19 || IdLineaProducto == 20 || IdLineaProducto == 21 || IdLineaProducto == 22)
            //{
            //    //optSieteCinco.Enabled = true;
            //    //optDiez.Enabled = true;
            //}
            //else
            //{
            //    optSieteCinco.Enabled = false;
            //    optDiez.Enabled = false;
            //}

            //nav 1-10
            //Reg 1-5

            if (!Nuevo)
            {
                XtraMessageBox.Show("Si el descuento es Mayor a Cero tiene que volver a Buscar y  seleccionar el producto, caso contrario continuar\nEsto se debe a que UD. está modificando un descuento que sufrió varios cambios, el descuento actual puede variar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            txtPrecio.EditValue = PrecioUnitario;
            txtPorDesc.EditValue = Descuento;
            ActivaControles(false);
   //         txtPrecio.ReadOnly = true;
          //   txtPorDesc.ReadOnly = true;
            //if (Descuento >= 60)
            //{
            //    btnAutoriza.Enabled = false;
            //    XtraMessageBox.Show("No se puede aplicar descuento adicional a productos con descuentos mayor a 60!, Consulte con su Administrador.",this.Text,MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //if (Convert.ToDecimal(txtPorDesc.Text) > 50)
            //{
            //    XtraMessageBox.Show("No puede aplicar descuentos mayores al 50%", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return;
            //}

            //add 25 May

            if (txtMotivo.Text.Trim().Length < 3)
            {
                XtraMessageBox.Show("Por favor ingresar el motivo de descuento.",this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            TempDescuentoVentaProductoBL objBL_TempDescuento = new TempDescuentoVentaProductoBL();
            TempDescuentoVentaProductoBE objTempDescuento = new TempDescuentoVentaProductoBE();

            objTempDescuento.IdTienda = Parametros.intTiendaId;
            objTempDescuento.IdProducto = IdProducto;
            objTempDescuento.PrecioUnitario = PrecioUnitario;
            objTempDescuento.PrecioVenta = Convert.ToDecimal(txtPrecio.Text) * ((100 - Convert.ToDecimal(txtPorDesc.Text)) / 100); //Convert.ToDecimal(txtPrecio.EditValue);
            objTempDescuento.DescuentoAnterior = Descuento;
            objTempDescuento.Descuento = Convert.ToDecimal(txtPorDesc.EditValue);
            objTempDescuento.Operacion = "INSERT";
            objTempDescuento.Fecha = DateTime.Now;
            objTempDescuento.UsuarioAutoriza = UsuarioAutoriza;
            objTempDescuento.IdPedido = IdPedido;
            objTempDescuento.Motivo = txtMotivo.Text;
            objTempDescuento.Observacion = "Modificado por escala de Dscto[2,5,10]%" + Origen;
            objTempDescuento.FlagEstado = true;
            objTempDescuento.Usuario = Parametros.strUsuarioLogin;
            objTempDescuento.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
            objTempDescuento.IdEmpresa = Parametros.intEmpresaId;

            objBL_TempDescuento.Inserta(objTempDescuento);

            PrecioUnitario = Convert.ToDecimal(txtPrecio.EditValue);
            Descuento = Convert.ToDecimal(txtPorDesc.EditValue);

            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAutoriza_Click(object sender, EventArgs e)
        {
            frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
            frmAutoriza.StartPosition = FormStartPosition.CenterParent;
            frmAutoriza.ShowDialog();

            if (frmAutoriza.Edita && frmAutoriza.FlagMaster)
            {
                 if (frmAutoriza.Usuario == "master"  || frmAutoriza.Usuario == "ltapia"  || frmAutoriza.Usuario == "rtapia" || 
                    frmAutoriza.Usuario == "dhuaman" || frmAutoriza.Usuario == "aflores" || frmAutoriza.Usuario == "jlquispe" || frmAutoriza.IdPerfil == Parametros.intPerAdministrador || 
                    Parametros.intPerfilId == Parametros.intPerHelpDesk || frmAutoriza.Usuario == "kconcha" || frmAutoriza.Usuario == "focampo" ||
                    frmAutoriza.IdPerfil == Parametros.intPerAdministradorTienda )
                {
                    txtPrecio.Enabled = true;
                    txtPorDesc.Enabled = true;
                }
                else
                {
                    txtPrecio.Enabled = false;
                    txtPorDesc.Enabled = false;
                    BloquearDescuentoProducto();
                }

                UsuarioAutoriza = frmAutoriza.Usuario;

                ActivaControles(true);
                txtPrecio.Focus();
            }
        }

        private void optDosCinco_CheckedChanged(object sender, EventArgs e)
        {
            txtPorDesc.EditValue = Descuento + Convert.ToDecimal(2.5);
        }

        private void optSieteCinco_CheckedChanged(object sender, EventArgs e)
        {
            txtPorDesc.EditValue = Descuento + Convert.ToDecimal(7.5);
        }

        private void optDiez_CheckedChanged(object sender, EventArgs e)
        {
            txtPorDesc.EditValue = Descuento + Convert.ToDecimal(10);
        }

        private void optCinco_CheckedChanged(object sender, EventArgs e)
        {
            txtPorDesc.EditValue = Descuento + Convert.ToDecimal(5);
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                txtPorDesc.Select();
                txtPorDesc.SelectAll();
                //txtPorDesc.EditValue = (1 - (Convert.ToDecimal(txtPrecio.EditValue) / PrecioUnitario)) * 100;
            }
        }

        private void optTrece_CheckedChanged(object sender, EventArgs e)
        {
            txtPorDesc.EditValue = Descuento + Convert.ToDecimal(13);
        }

        private void txtPorDesc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
 
                    e.Handled = true;
                    SendKeys.Send("{TAB}");
     
            }
        }

        private void txtMotivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        #endregion

        #region "Metodos"

        private void ActivaControles(bool value)
        {
            //txtPrecio.Enabled = false;
            //txtPorDesc.Enabled = value;
            btnAceptar.Enabled = value;
            gboDescuento.Enabled = value;
        }

        private void BloquearDescuentoProducto()
        {
            ProductoBE objE_Producto = null;
            objE_Producto = new ProductoBL().SeleccionaIdProductoInventario(IdProducto);
            if (objE_Producto != null)
            {
                if (objE_Producto.FlagNacional == true)
                {
                    optDosCinco.Visible = true;
                    optCinco.Visible = true;
                    optSieteCinco.Visible = false;
                    optDiez.Visible = false;
                }else if (Descuento == 0)
                {
                    optDosCinco.Visible = true;
                    optCinco.Visible = true;
                    optSieteCinco.Visible = true;
                    optDiez.Visible = true;
                }
                else if (Descuento > 0 && Descuento <= 5)
                {
                    optDosCinco.Visible = true;
                    optCinco.Visible = false;
                    optSieteCinco.Visible = false;
                    optDiez.Visible = false;
                }
                else
                {
                    optDosCinco.Visible = false;
                    optCinco.Visible = false;
                    optSieteCinco.Visible = false;
                    optDiez.Visible = false;
                }

                if (Parametros.intPerfilId == Parametros.intPerSupervisorVentasPiso && Parametros.intTiendaId == Parametros.intTiendaUcayali)
                {
                    optDosCinco.Visible = true;
                    optCinco.Visible = true;
                    optSieteCinco.Visible = true;
                    optDiez.Visible = true;
                }

           }
        }

        #endregion


    }
}