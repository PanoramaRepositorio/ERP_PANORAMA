using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Security.Principal;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Columns;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Modulos.Ventas.Maestros;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.Ventas.Registros
{
    public partial class frmRegNovioRegaloLista : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"


        public List<CNovioRegaloDetalle> mListaNovioRegaloDetalleOrigen = new List<CNovioRegaloDetalle>();
        public List<DescuentoClienteFinalBE> mListaDescuentoClienteFinal = new List<DescuentoClienteFinalBE>();
        public List<DescuentoClienteMayoristaBE> mListaDescuentoClienteMayorista = new List<DescuentoClienteMayoristaBE>();
        public List<NovioRegaloDetalleBE> lstNovioRegaloDetalle2 = new List<NovioRegaloDetalleBE>();
        public List<int> lProductoNovios = new List<int>();

        public NovioRegaloDetalleBE oBE;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        int _IdNovioRegalo = 0;

        public int IdNovioRegalo
        {
            get { return _IdNovioRegalo; }
            set { _IdNovioRegalo = value; }
        }

        public bool bNuevo = true;

        private int IdNovio = 0;
        private int IdNovia = 0;
        private int IdTipoCliente = 0;
        private int IdClasificacionCliente = 0;
        private int? IdDis_ProyectoServicio;

        #endregion

        #region "Eventos"

        public frmRegNovioRegaloLista()
        {
            InitializeComponent();
        }

        private void frmRegNovioRegaloLista_Load(object sender, EventArgs e)
        {
            deFecha.EditValue = DateTime.Now;
            BSUtils.LoaderLook(cboDocumento, new ModuloDocumentoBL().ListaTodosActivo(Parametros.intModVentas, 0), "CodTipoDocumento", "IdTipoDocumento", true);
            cboDocumento.EditValue = Parametros.intTipoDocNovioRegalo;
            BSUtils.LoaderLook(cboVendedor, new PersonaBL().SeleccionaVendedor(Parametros.intEmpresaId), "ApeNom", "IdPersona", true);
            cboVendedor.EditValue = Parametros.intPersonaId;
            BSUtils.LoaderLook(cboVendedor2, new PersonaBL().SeleccionaVendedor(Parametros.intEmpresaId), "ApeNom", "IdPersona", true);
            cboVendedor2.EditValue = 0;
            BSUtils.LoaderLook(cboMoneda, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblMoneda), "DescTablaElemento", "IdTablaElemento", true);
            cboMoneda.EditValue = Parametros.intSoles;
            //BSUtils.LoaderLook(cboSituacion, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblSituacionNovioRegaloVenta), "DescTablaElemento", "IdTablaElemento", true);
            //cboSituacion.EditValue = Parametros.intPFGenerado;

            CargarDescuentoClienteFinal();
            CargarDescuentoClienteMayorista();

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Lista de Novios - Nuevo";

                //ObtenerCorrelativo();

            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Lista de Novios - Modificar";

                NovioRegaloBE objE_NovioRegalo = null;
                objE_NovioRegalo = new NovioRegaloBL().Selecciona(IdNovioRegalo);

                IdNovioRegalo = objE_NovioRegalo.IdNovioRegalo;
                //cboDocumento.EditValue = objE_NovioRegalo.IdTipoDocumento;
                txtNumero.Text = objE_NovioRegalo.Numero;
                deFecha.EditValue = objE_NovioRegalo.Fecha;
                deFechaBoda.EditValue = objE_NovioRegalo.FechaBoda;
                cboVendedor.EditValue = objE_NovioRegalo.IdVendedor;
                cboVendedor2.EditValue = objE_NovioRegalo.IdAsesor;
                IdNovia = objE_NovioRegalo.IdNovia;
                txtDniNovia.Text = objE_NovioRegalo.DniNovia;
                txtDescNovia.Text = objE_NovioRegalo.DescNovia;
                IdNovio = objE_NovioRegalo.IdNovio;
                txtDniNovio.Text = objE_NovioRegalo.DniNovio;
                txtDescNovio.Text = objE_NovioRegalo.DescNovio;
                txtTelefono.Text = objE_NovioRegalo.Telefono;
                txtCelular.Text = objE_NovioRegalo.Celular;
                txtCelular2.Text = objE_NovioRegalo.Celular2;
                txtEmail.Text = objE_NovioRegalo.Email;
                txtEmail2.Text = objE_NovioRegalo.Email2;
                txtDireccion.Text = objE_NovioRegalo.Direccion;
                txtObservaciones.Text = objE_NovioRegalo.Observacion;
            }

            txtDniNovia.Focus();
            CargaNovioRegaloDetalle();
        }

        private void btnBuscarNovia_Click(object sender, EventArgs e)
        {
            try
            {
                frmBusCliente frm = new frmBusCliente();
                frm.pFlagMultiSelect = false;
                frm.ShowDialog();
                if (frm.pClienteBE != null)
                {
                    IdNovia = frm.pClienteBE.IdCliente;
                    txtDniNovia.Text = frm.pClienteBE.NumeroDocumento;
                    txtDescNovia.Text = frm.pClienteBE.DescCliente;
                    //txtDireccion.Text = frm.pClienteBE.AbrevDomicilio + " " + frm.pClienteBE.Direccion;
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscarNovio_Click(object sender, EventArgs e)
        {
            try
            {
                frmBusCliente frm = new frmBusCliente();
                frm.pFlagMultiSelect = false;
                frm.ShowDialog();
                if (frm.pClienteBE != null)
                {
                    IdNovio = frm.pClienteBE.IdCliente;
                    txtDniNovio.Text = frm.pClienteBE.NumeroDocumento;
                    txtDescNovio.Text = frm.pClienteBE.DescCliente;
                    //txtDireccion.Text = frm.pClienteBE.AbrevDomicilio + " " + frm.pClienteBE.Direccion;
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnNuevoNovia_Click(object sender, EventArgs e)
        {
            try
            {
                frmManClienteMinoristaEdit objManCliente = new frmManClienteMinoristaEdit();
                //objManClientel.lstCliente = mLista;
                objManCliente.pOperacion = frmManClienteMinoristaEdit.Operacion.Nuevo;
                objManCliente.IdCliente = 0;
                objManCliente.StartPosition = FormStartPosition.CenterParent;
                if (objManCliente.ShowDialog() == DialogResult.OK)
                {
                    txtDniNovia.Text = objManCliente.NumeroDocumento;
                    txtDescNovia.Text = objManCliente.DescCliente;
                    //txtDireccion.Text = objManCliente.AbrevDocimicilio + ' ' + objManCliente.Direccion;

                    ClienteBE objE_Cliente = null;
                    objE_Cliente = new ClienteBL().SeleccionaNumero(Parametros.intIdPanoramaDistribuidores, objManCliente.NumeroDocumento);
                    if (objE_Cliente != null)
                    {
                        IdNovia = objE_Cliente.IdCliente;
                    }
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnNuevoNovio_Click(object sender, EventArgs e)
        {
            try
            {
                frmManClienteMinoristaEdit objManCliente = new frmManClienteMinoristaEdit();
                //objManClientel.lstCliente = mLista;
                objManCliente.pOperacion = frmManClienteMinoristaEdit.Operacion.Nuevo;
                objManCliente.IdCliente = 0;
                objManCliente.StartPosition = FormStartPosition.CenterParent;
                if (objManCliente.ShowDialog() == DialogResult.OK)
                {
                    txtDniNovio.Text = objManCliente.NumeroDocumento;
                    txtDescNovio.Text = objManCliente.DescCliente;
                    //txtDireccion.Text = objManCliente.AbrevDocimicilio + ' ' + objManCliente.Direccion;

                    ClienteBE objE_Cliente = null;
                    objE_Cliente = new ClienteBL().SeleccionaNumero(Parametros.intIdPanoramaDistribuidores, objManCliente.NumeroDocumento);
                    if (objE_Cliente != null)
                    {
                        IdNovio = objE_Cliente.IdCliente;
                    }
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDniNovia.Text.Trim() == "")
                {
                    XtraMessageBox.Show("Seleccionar un cliente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                frmRegNovioRegaloDetalleEdit movDetalle = new frmRegNovioRegaloDetalleEdit();
                int i = 0;
                if (mListaNovioRegaloDetalleOrigen.Count > 0)
                    i = mListaNovioRegaloDetalleOrigen.Max(ob => Convert.ToInt32(ob.Item));
                movDetalle.intCorrelativo = Convert.ToInt32(i) + 1;
                movDetalle.IdTipoCliente = Parametros.intTipClienteFinal;
                movDetalle.IdClasificacionCliente = Parametros.intClasico;
                movDetalle.IdMoneda = Parametros.intSoles;
                if (movDetalle.ShowDialog() == DialogResult.OK)
                {
                    if (movDetalle.oBE != null)
                    {
                        if (mListaNovioRegaloDetalleOrigen.Count == 0)
                        {
                            gvNovioRegaloDetalle.AddNewRow();
                            gvNovioRegaloDetalle.SetRowCellValue(gvNovioRegaloDetalle.FocusedRowHandle, "IdEmpresa", movDetalle.oBE.IdEmpresa);
                            gvNovioRegaloDetalle.SetRowCellValue(gvNovioRegaloDetalle.FocusedRowHandle, "IdNovioRegalo", movDetalle.oBE.IdNovioRegalo);
                            gvNovioRegaloDetalle.SetRowCellValue(gvNovioRegaloDetalle.FocusedRowHandle, "IdNovioRegaloDetalle", movDetalle.oBE.IdNovioRegaloDetalle);
                            gvNovioRegaloDetalle.SetRowCellValue(gvNovioRegaloDetalle.FocusedRowHandle, "Item", movDetalle.oBE.Item);
                            gvNovioRegaloDetalle.SetRowCellValue(gvNovioRegaloDetalle.FocusedRowHandle, "IdProducto", movDetalle.oBE.IdProducto);
                            gvNovioRegaloDetalle.SetRowCellValue(gvNovioRegaloDetalle.FocusedRowHandle, "CodigoProveedor", movDetalle.oBE.CodigoProveedor);
                            gvNovioRegaloDetalle.SetRowCellValue(gvNovioRegaloDetalle.FocusedRowHandle, "NombreProducto", movDetalle.oBE.NombreProducto);
                            gvNovioRegaloDetalle.SetRowCellValue(gvNovioRegaloDetalle.FocusedRowHandle, "Abreviatura", movDetalle.oBE.Abreviatura);
                            gvNovioRegaloDetalle.SetRowCellValue(gvNovioRegaloDetalle.FocusedRowHandle, "Cantidad", movDetalle.oBE.Cantidad);
                            gvNovioRegaloDetalle.SetRowCellValue(gvNovioRegaloDetalle.FocusedRowHandle, "PrecioUnitario", movDetalle.oBE.PrecioUnitario);
                            gvNovioRegaloDetalle.SetRowCellValue(gvNovioRegaloDetalle.FocusedRowHandle, "PorcentajeDescuento", movDetalle.oBE.PorcentajeDescuento);
                            gvNovioRegaloDetalle.SetRowCellValue(gvNovioRegaloDetalle.FocusedRowHandle, "Descuento", movDetalle.oBE.Descuento);
                            gvNovioRegaloDetalle.SetRowCellValue(gvNovioRegaloDetalle.FocusedRowHandle, "PrecioVenta", movDetalle.oBE.PrecioVenta);
                            gvNovioRegaloDetalle.SetRowCellValue(gvNovioRegaloDetalle.FocusedRowHandle, "ValorVenta", movDetalle.oBE.ValorVenta);
                            gvNovioRegaloDetalle.SetRowCellValue(gvNovioRegaloDetalle.FocusedRowHandle, "Observacion", movDetalle.oBE.Observacion);
                            gvNovioRegaloDetalle.SetRowCellValue(gvNovioRegaloDetalle.FocusedRowHandle, "IdLineaProducto", movDetalle.oBE.IdLineaProducto);
                            gvNovioRegaloDetalle.SetRowCellValue(gvNovioRegaloDetalle.FocusedRowHandle, "FlagComprado", movDetalle.oBE.FlagComprado);
                            gvNovioRegaloDetalle.SetRowCellValue(gvNovioRegaloDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            gvNovioRegaloDetalle.UpdateCurrentRow();

                            bNuevo = movDetalle.bNuevo;

                            CalculaTotales();

                            //btnNuevo.Focus();

                            return;

                        }
                        if (mListaNovioRegaloDetalleOrigen.Count > 0)
                        {
                            var Buscar = mListaNovioRegaloDetalleOrigen.Where(oB => oB.IdProducto == movDetalle.oBE.IdProducto).ToList();
                            if (Buscar.Count > 0)
                            {
                                XtraMessageBox.Show("El código de producto ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            gvNovioRegaloDetalle.AddNewRow();
                            gvNovioRegaloDetalle.SetRowCellValue(gvNovioRegaloDetalle.FocusedRowHandle, "IdEmpresa", movDetalle.oBE.IdEmpresa);
                            gvNovioRegaloDetalle.SetRowCellValue(gvNovioRegaloDetalle.FocusedRowHandle, "IdNovioRegalo", movDetalle.oBE.IdNovioRegalo);
                            gvNovioRegaloDetalle.SetRowCellValue(gvNovioRegaloDetalle.FocusedRowHandle, "IdNovioRegaloDetalle", movDetalle.oBE.IdNovioRegaloDetalle);
                            gvNovioRegaloDetalle.SetRowCellValue(gvNovioRegaloDetalle.FocusedRowHandle, "Item", movDetalle.oBE.Item);
                            gvNovioRegaloDetalle.SetRowCellValue(gvNovioRegaloDetalle.FocusedRowHandle, "IdProducto", movDetalle.oBE.IdProducto);
                            gvNovioRegaloDetalle.SetRowCellValue(gvNovioRegaloDetalle.FocusedRowHandle, "CodigoProveedor", movDetalle.oBE.CodigoProveedor);
                            gvNovioRegaloDetalle.SetRowCellValue(gvNovioRegaloDetalle.FocusedRowHandle, "NombreProducto", movDetalle.oBE.NombreProducto);
                            gvNovioRegaloDetalle.SetRowCellValue(gvNovioRegaloDetalle.FocusedRowHandle, "Abreviatura", movDetalle.oBE.Abreviatura);
                            gvNovioRegaloDetalle.SetRowCellValue(gvNovioRegaloDetalle.FocusedRowHandle, "Cantidad", movDetalle.oBE.Cantidad);
                            gvNovioRegaloDetalle.SetRowCellValue(gvNovioRegaloDetalle.FocusedRowHandle, "PrecioUnitario", movDetalle.oBE.PrecioUnitario);
                            gvNovioRegaloDetalle.SetRowCellValue(gvNovioRegaloDetalle.FocusedRowHandle, "PorcentajeDescuento", movDetalle.oBE.PorcentajeDescuento);
                            gvNovioRegaloDetalle.SetRowCellValue(gvNovioRegaloDetalle.FocusedRowHandle, "Descuento", movDetalle.oBE.Descuento);
                            gvNovioRegaloDetalle.SetRowCellValue(gvNovioRegaloDetalle.FocusedRowHandle, "PrecioVenta", movDetalle.oBE.PrecioVenta);
                            gvNovioRegaloDetalle.SetRowCellValue(gvNovioRegaloDetalle.FocusedRowHandle, "ValorVenta", movDetalle.oBE.ValorVenta);
                            gvNovioRegaloDetalle.SetRowCellValue(gvNovioRegaloDetalle.FocusedRowHandle, "Observacion", movDetalle.oBE.Observacion);
                            gvNovioRegaloDetalle.SetRowCellValue(gvNovioRegaloDetalle.FocusedRowHandle, "IdLineaProducto", movDetalle.oBE.IdLineaProducto);
                            gvNovioRegaloDetalle.SetRowCellValue(gvNovioRegaloDetalle.FocusedRowHandle, "FlagComprado", movDetalle.oBE.FlagComprado);
                            gvNovioRegaloDetalle.SetRowCellValue(gvNovioRegaloDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            gvNovioRegaloDetalle.UpdateCurrentRow();

                            bNuevo = movDetalle.bNuevo;

                            CalculaTotales();

                            //btnNuevo.Focus();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (mListaNovioRegaloDetalleOrigen.Count > 0)
            {
                int xposition = 0;

                frmRegNovioRegaloDetalleEdit movDetalle = new frmRegNovioRegaloDetalleEdit();
                movDetalle.IdTipoCliente = IdTipoCliente;
                movDetalle.IdClasificacionCliente = IdClasificacionCliente;
                movDetalle.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
                movDetalle.IdNovioRegalo = Convert.ToInt32(gvNovioRegaloDetalle.GetFocusedRowCellValue("IdNovioRegalo"));
                movDetalle.IdNovioRegaloDetalle = Convert.ToInt32(gvNovioRegaloDetalle.GetFocusedRowCellValue("IdNovioRegaloDetalle"));
                movDetalle.intCorrelativo = Convert.ToInt32(gvNovioRegaloDetalle.GetFocusedRowCellValue("Item"));
                movDetalle.IdProducto = Convert.ToInt32(gvNovioRegaloDetalle.GetFocusedRowCellValue("IdProducto"));
                movDetalle.IdLineaProducto = Convert.ToInt32(gvNovioRegaloDetalle.GetFocusedRowCellValue("IdLineaProducto"));
                movDetalle.txtCodigo.Text = gvNovioRegaloDetalle.GetFocusedRowCellValue("CodigoProveedor").ToString();
                movDetalle.txtProducto.Text = gvNovioRegaloDetalle.GetFocusedRowCellValue("NombreProducto").ToString();
                movDetalle.txtUM.Text = gvNovioRegaloDetalle.GetFocusedRowCellValue("Abreviatura").ToString();
                movDetalle.txtCantidad.EditValue = Convert.ToInt32(gvNovioRegaloDetalle.GetFocusedRowCellValue("Cantidad"));
                movDetalle.txtPrecioUnitario.EditValue = Convert.ToDecimal(gvNovioRegaloDetalle.GetFocusedRowCellValue("PrecioUnitario"));
                movDetalle.txtDescuento.EditValue = Convert.ToDecimal(gvNovioRegaloDetalle.GetFocusedRowCellValue("PorcentajeDescuento"));
                movDetalle.txtPrecioVenta.EditValue = Convert.ToDecimal(gvNovioRegaloDetalle.GetFocusedRowCellValue("PrecioVenta"));
                movDetalle.txtValorVenta.EditValue = Convert.ToDecimal(gvNovioRegaloDetalle.GetFocusedRowCellValue("ValorVenta"));
                movDetalle.txtObservacion.Text = gvNovioRegaloDetalle.GetFocusedRowCellValue("Observacion").ToString();
                movDetalle.chkComprado.Checked = bool.Parse(gvNovioRegaloDetalle.GetFocusedRowCellValue("FlagComprado").ToString());

                if (movDetalle.ShowDialog() == DialogResult.OK)
                {
                    xposition = gvNovioRegaloDetalle.FocusedRowHandle;

                    if (movDetalle.oBE != null)
                    {
                        gvNovioRegaloDetalle.SetRowCellValue(xposition, "IdEmpresa", movDetalle.oBE.IdEmpresa);
                        gvNovioRegaloDetalle.SetRowCellValue(xposition, "IdNovioRegalo", movDetalle.oBE.IdNovioRegalo);
                        gvNovioRegaloDetalle.SetRowCellValue(xposition, "IdNovioRegaloDetalle", movDetalle.oBE.IdNovioRegaloDetalle);
                        gvNovioRegaloDetalle.SetRowCellValue(xposition, "Item", movDetalle.oBE.Item);
                        gvNovioRegaloDetalle.SetRowCellValue(xposition, "IdProducto", movDetalle.oBE.IdProducto);
                        gvNovioRegaloDetalle.SetRowCellValue(xposition, "CodigoProveedor", movDetalle.oBE.CodigoProveedor);
                        gvNovioRegaloDetalle.SetRowCellValue(xposition, "NombreProducto", movDetalle.oBE.NombreProducto);
                        gvNovioRegaloDetalle.SetRowCellValue(xposition, "Abreviatura", movDetalle.oBE.Abreviatura);
                        gvNovioRegaloDetalle.SetRowCellValue(xposition, "Cantidad", movDetalle.oBE.Cantidad);
                        gvNovioRegaloDetalle.SetRowCellValue(xposition, "PrecioUnitario", movDetalle.oBE.PrecioUnitario);
                        gvNovioRegaloDetalle.SetRowCellValue(xposition, "PorcentajeDescuento", movDetalle.oBE.PorcentajeDescuento);
                        gvNovioRegaloDetalle.SetRowCellValue(xposition, "Descuento", movDetalle.oBE.Descuento);
                        gvNovioRegaloDetalle.SetRowCellValue(xposition, "PrecioVenta", movDetalle.oBE.PrecioVenta);
                        gvNovioRegaloDetalle.SetRowCellValue(xposition, "ValorVenta", movDetalle.oBE.ValorVenta);
                        gvNovioRegaloDetalle.SetRowCellValue(xposition, "Observacion", movDetalle.oBE.Observacion);
                        gvNovioRegaloDetalle.SetRowCellValue(xposition, "FlagComprado", movDetalle.oBE.FlagComprado);
                        gvNovioRegaloDetalle.SetRowCellValue(xposition, "IdLineaProducto", movDetalle.oBE.IdLineaProducto);
                        gvNovioRegaloDetalle.SetRowCellValue(xposition, "TipoOper", Convert.ToInt32(Operacion.Modificar));
                        gvNovioRegaloDetalle.UpdateCurrentRow();

                        bNuevo = movDetalle.bNuevo;

                        CalculaTotales();

                        //btnNuevo.Focus();
                    }
                }
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int IdNovioRegaloDetalle = 0;
                if (gvNovioRegaloDetalle.GetFocusedRowCellValue("IdNovioRegaloDetalle") != null)
                    IdNovioRegaloDetalle = int.Parse(gvNovioRegaloDetalle.GetFocusedRowCellValue("IdNovioRegaloDetalle").ToString());
                int Item = 0;
                if (gvNovioRegaloDetalle.GetFocusedRowCellValue("Item") != null)
                    Item = int.Parse(gvNovioRegaloDetalle.GetFocusedRowCellValue("Item").ToString());
                NovioRegaloDetalleBE objBE_NovioRegaloDetalle = new NovioRegaloDetalleBE();
                objBE_NovioRegaloDetalle.IdNovioRegaloDetalle = IdNovioRegaloDetalle;
                objBE_NovioRegaloDetalle.IdEmpresa = Parametros.intEmpresaId;
                objBE_NovioRegaloDetalle.Usuario = Parametros.strUsuarioLogin;
                objBE_NovioRegaloDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                NovioRegaloDetalleBL objBL_NovioRegaloDetalle = new NovioRegaloDetalleBL();
                objBL_NovioRegaloDetalle.Elimina(objBE_NovioRegaloDetalle);
                gvNovioRegaloDetalle.DeleteRow(gvNovioRegaloDetalle.FocusedRowHandle);
                gvNovioRegaloDetalle.RefreshData();

                //RegeneraItem
                int i = 0;
                int cuenta = 0;
                foreach (var item in mListaNovioRegaloDetalleOrigen)
                {
                    item.Item = Convert.ToByte(cuenta + 1);
                    cuenta++;
                    i++;
                }

                CalculaTotales();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsmMenuAgregar_Click(object sender, EventArgs e)
        {
            this.nuevoToolStripMenuItem_Click(sender, e);
        }

        private void tsmMenuEliminar_Click(object sender, EventArgs e)
        {
            this.eliminarToolStripMenuItem_Click(sender, e);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.nuevoToolStripMenuItem_Click(sender, e);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            this.eliminarToolStripMenuItem_Click(sender, e);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                CalculaTotales();

                if (!ValidarIngreso())
                {
                    NovioRegaloBL objBL_NovioRegalo = new NovioRegaloBL();
                    NovioRegaloBE objNovioRegalo = new NovioRegaloBE();

                    objNovioRegalo.IdNovioRegalo = IdNovioRegalo;
                    objNovioRegalo.IdTienda = Parametros.intTiendaId;
                    objNovioRegalo.Periodo = Parametros.intPeriodo;
                    //objNovioRegalo.Mes = deFechaBoda.DateTime.Month;
                    objNovioRegalo.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                    objNovioRegalo.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objNovioRegalo.Numero = txtNumero.Text;
                    objNovioRegalo.FechaBoda = Convert.ToDateTime(deFechaBoda.DateTime.ToShortDateString());
                    objNovioRegalo.IdNovia = IdNovia;
                    objNovioRegalo.IdNovio = IdNovio;
                    objNovioRegalo.Telefono = txtTelefono.Text;
                    objNovioRegalo.Celular = txtCelular.Text;
                    objNovioRegalo.Direccion = txtDireccion.Text;
                    objNovioRegalo.Email = txtEmail.Text;
                    objNovioRegalo.Email2 = txtEmail2.Text;
                    objNovioRegalo.Direccion = txtDireccion.Text;
                    objNovioRegalo.Observacion = txtObservaciones.Text;
                    objNovioRegalo.Direccion = txtDireccion.Text;
                    objNovioRegalo.IdVendedor = Convert.ToInt32(cboVendedor.EditValue);
                    objNovioRegalo.IdAsesor = Convert.ToInt32(cboVendedor2.EditValue);
                    objNovioRegalo.FlagEstado = true;
                    objNovioRegalo.Usuario = Parametros.strUsuarioLogin;
                    objNovioRegalo.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objNovioRegalo.IdEmpresa = Parametros.intEmpresaId;


                    //Documento Vneta Detalle
                    List<NovioRegaloDetalleBE> lstNovioRegaloDetalle = new List<NovioRegaloDetalleBE>();

                    foreach (var item in mListaNovioRegaloDetalleOrigen)
                    {
                        if (item.FlagComprar)
                        {
                            int IdProd = lProductoNovios.Find(x=>x == item.IdProducto) ;
                            if (IdProd == 0)
                            {
                                NovioRegaloDetalleBE objE_NovioRegaloDetalle = new NovioRegaloDetalleBE();
                                objE_NovioRegaloDetalle.IdEmpresa = item.IdEmpresa;
                                objE_NovioRegaloDetalle.IdNovioRegalo = item.IdNovioRegalo;
                                objE_NovioRegaloDetalle.IdNovioRegaloDetalle = item.IdNovioRegaloDetalle;
                                objE_NovioRegaloDetalle.Item = item.Item;
                                objE_NovioRegaloDetalle.IdProducto = item.IdProducto;
                                objE_NovioRegaloDetalle.CodigoProveedor = item.CodigoProveedor;
                                objE_NovioRegaloDetalle.NombreProducto = item.NombreProducto;
                                objE_NovioRegaloDetalle.Abreviatura = item.Abreviatura;

                                int cantidad = item.CantidadSaldo;
                                //if (item.CantidadStock< item.CantidadSaldo)
                                //    cantidad= item.CantidadStock; 

                                objE_NovioRegaloDetalle.Cantidad = cantidad;
                                objE_NovioRegaloDetalle.PrecioUnitario = item.PrecioUnitario;
                                objE_NovioRegaloDetalle.PorcentajeDescuento = item.PorcentajeDescuento;
                                objE_NovioRegaloDetalle.Descuento = item.Descuento;
                                objE_NovioRegaloDetalle.PrecioVenta = item.PrecioVenta;
                                objE_NovioRegaloDetalle.ValorVenta = item.ValorVenta;
                                objE_NovioRegaloDetalle.Observacion = item.Observacion;
                                objE_NovioRegaloDetalle.FlagComprado = item.FlagComprado;
                                objE_NovioRegaloDetalle.FlagEstado = true;
                                objE_NovioRegaloDetalle.TipoOper = item.TipoOper;
                                lstNovioRegaloDetalle2.Add(objE_NovioRegaloDetalle);
                            }
                        }
                    }

                    if (pOperacion == Operacion.Nuevo)
                    {
                        //ObtenerCorrelativo();
                        objNovioRegalo.Numero = txtNumero.Text;
                        //objBL_NovioRegalo.Inserta(objNovioRegalo, lstNovioRegaloDetalle);
                    }
                    else
                    {
                        //objBL_NovioRegalo.Actualiza(objNovioRegalo, lstNovioRegaloDetalle);
                    }

                    this.DialogResult = DialogResult.OK;
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
            this.Close();
        }

        private void txtTotal_EditValueChanged(object sender, EventArgs e)
        {
            //CalculaTotales();
        }

        private void establecerdescuentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Parametros.strUsuarioLogin == "master" || Parametros.intPerfilId == Parametros.intPerAdministrador || Parametros.strUsuarioLogin == "rcastañeda" || Parametros.strUsuarioLogin == "jzanabria" || Parametros.strUsuarioLogin == "dhuaman")
            {
                frmEstablecerDescuento objDescuento = new frmEstablecerDescuento();
                objDescuento.StartPosition = FormStartPosition.CenterParent;
                if (objDescuento.ShowDialog() == DialogResult.OK)
                {
                    for (int i = 0; i < gvNovioRegaloDetalle.SelectedRowsCount; i++)
                    {
                        decimal decDescuento = 0;
                        decimal decPrecioVenta = 0;
                        decimal decValorVenta = 0;

                        int row = gvNovioRegaloDetalle.GetSelectedRows()[i];
                        decDescuento = decimal.Parse(objDescuento.Descuento.ToString());
                        gvNovioRegaloDetalle.SetRowCellValue(row, "PorcentajeDescuento", decDescuento);

                        decPrecioVenta = decimal.Parse(gvNovioRegaloDetalle.GetRowCellValue(row, "PrecioUnitario").ToString()) * ((100 - decDescuento) / 100);
                        decValorVenta = Math.Round(decPrecioVenta, 2) * decimal.Parse(gvNovioRegaloDetalle.GetRowCellValue(row, "Cantidad").ToString());
                        gvNovioRegaloDetalle.SetRowCellValue(row, "PrecioVenta", decPrecioVenta);
                        gvNovioRegaloDetalle.SetRowCellValue(row, "ValorVenta", decValorVenta);

                    }
                }

                gvNovioRegaloDetalle.RefreshData();

                CalculaTotales();
            }
            else
            {
                XtraMessageBox.Show("Ud. no tiene los permisos para esta operación", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void btnEditarNovia_Click(object sender, EventArgs e)
        {
            if (IdNovia > 0)
            {
                ClienteBE objClientel = new ClienteBE();
                objClientel.IdCliente = IdNovia;

                frmManClienteMinoristaEdit objManClientelEdit = new frmManClienteMinoristaEdit();
                objManClientelEdit.pOperacion = frmManClienteMinoristaEdit.Operacion.Modificar;
                objManClientelEdit.IdCliente = objClientel.IdCliente;
                objManClientelEdit.StartPosition = FormStartPosition.CenterParent;
                objManClientelEdit.ShowDialog();

                objClientel = new ClienteBL().Selecciona(Parametros.intEmpresaId, IdNovia);
                txtDniNovia.Text = objClientel.NumeroDocumento;
                txtDescNovia.Text = objClientel.DescCliente;
            }
            else
            {
                MessageBox.Show("No se pudo editar");
            }
        }

        private void btnEditarNovio_Click(object sender, EventArgs e)
        {
            if (IdNovio > 0)
            {
                ClienteBE objClientel = new ClienteBE();
                objClientel.IdCliente = IdNovio;

                frmManClienteMinoristaEdit objManClientelEdit = new frmManClienteMinoristaEdit();
                objManClientelEdit.pOperacion = frmManClienteMinoristaEdit.Operacion.Modificar;
                objManClientelEdit.IdCliente = objClientel.IdCliente;
                objManClientelEdit.StartPosition = FormStartPosition.CenterParent;
                objManClientelEdit.ShowDialog();

                txtDniNovio.Text = objClientel.NumeroDocumento;
                txtDescNovio.Text = objClientel.DescCliente;
            }
            else
            {
                MessageBox.Show("No se pudo editar");
            }
        }

        #endregion

        #region "Metodos"

        private void CargarDescuentoClienteFinal()
        {
            mListaDescuentoClienteFinal = new DescuentoClienteFinalBL().ListaTodosActivo(Parametros.intEmpresaId);
        }

        private void CargarDescuentoClienteMayorista()
        {
            mListaDescuentoClienteMayorista = new DescuentoClienteMayoristaBL().ListaTodosActivo(Parametros.intEmpresaId, 0, 0);
        }

        private void CalcularValoresGrilla(int IdMoneda)
        {
            try
            {
                if (gvNovioRegaloDetalle.RowCount > 0)
                {
                    if (IdMoneda == Parametros.intSoles)
                    {
                        int posicion = 0;
                        foreach (var item in mListaNovioRegaloDetalleOrigen)
                        {
                            decimal decPrecioUnitario = 0;
                            decimal decPorcentajeDescuento = 0;
                            decimal decPrecioVenta = 0;
                            decimal decValorVenta = 0;
                            if (IdTipoCliente == Parametros.intTipClienteMayorista)
                            {
                                decPrecioUnitario = decimal.Parse(gvNovioRegaloDetalle.GetRowCellValue(posicion, gvNovioRegaloDetalle.Columns["PrecioUnitario"]).ToString()) * decimal.Parse(Parametros.dmlTCMayorista.ToString());
                                decPorcentajeDescuento = decimal.Parse(gvNovioRegaloDetalle.GetRowCellValue(posicion, gvNovioRegaloDetalle.Columns["PorcentajeDescuento"]).ToString());
                                decPrecioVenta = decPrecioUnitario * ((100 - decPorcentajeDescuento) / 100);
                                decValorVenta = decimal.Parse(gvNovioRegaloDetalle.GetRowCellValue(posicion, gvNovioRegaloDetalle.Columns["Cantidad"]).ToString()) * Math.Round(decPrecioVenta, 2);
                            }
                            else
                            {
                                decPrecioUnitario = decimal.Parse(gvNovioRegaloDetalle.GetRowCellValue(posicion, gvNovioRegaloDetalle.Columns["PrecioUnitario"]).ToString()) * decimal.Parse(Parametros.dmlTCMinorista.ToString());
                                decPorcentajeDescuento = decimal.Parse(gvNovioRegaloDetalle.GetRowCellValue(posicion, gvNovioRegaloDetalle.Columns["PorcentajeDescuento"]).ToString());
                                decPrecioVenta = decPrecioUnitario * ((100 - decPorcentajeDescuento) / 100);
                                decValorVenta = decimal.Parse(gvNovioRegaloDetalle.GetRowCellValue(posicion, gvNovioRegaloDetalle.Columns["Cantidad"]).ToString()) * Math.Round(decPrecioVenta, 2);
                            }

                            gvNovioRegaloDetalle.SetRowCellValue(posicion, gvNovioRegaloDetalle.Columns["PrecioUnitario"], decPrecioUnitario);
                            gvNovioRegaloDetalle.SetRowCellValue(posicion, gvNovioRegaloDetalle.Columns["PrecioVenta"], decPrecioVenta);
                            gvNovioRegaloDetalle.SetRowCellValue(posicion, gvNovioRegaloDetalle.Columns["ValorVenta"], decValorVenta);
                            posicion++;
                        }
                    }
                    else
                    {
                        int posicion = 0;
                        foreach (var item in mListaNovioRegaloDetalleOrigen)
                        {
                            decimal decPrecioUnitario = 0;
                            decimal decPorcentajeDescuento = 0;
                            decimal decPrecioVenta = 0;
                            decimal decValorVenta = 0;
                            if (IdTipoCliente == Parametros.intTipClienteMayorista)
                            {
                                decPrecioUnitario = decimal.Parse(gvNovioRegaloDetalle.GetRowCellValue(posicion, gvNovioRegaloDetalle.Columns["PrecioUnitario"]).ToString()) / decimal.Parse(Parametros.dmlTCMayorista.ToString());
                                decPorcentajeDescuento = decimal.Parse(gvNovioRegaloDetalle.GetRowCellValue(posicion, gvNovioRegaloDetalle.Columns["PorcentajeDescuento"]).ToString());
                                decPrecioVenta = decPrecioUnitario * ((100 - decPorcentajeDescuento) / 100);
                                decValorVenta = decimal.Parse(gvNovioRegaloDetalle.GetRowCellValue(posicion, gvNovioRegaloDetalle.Columns["Cantidad"]).ToString()) * Math.Round(decPrecioVenta, 2);
                            }
                            else
                            {
                                decPrecioUnitario = decimal.Parse(gvNovioRegaloDetalle.GetRowCellValue(posicion, gvNovioRegaloDetalle.Columns["PrecioUnitario"]).ToString()) / decimal.Parse(Parametros.dmlTCMinorista.ToString());
                                decPorcentajeDescuento = decimal.Parse(gvNovioRegaloDetalle.GetRowCellValue(posicion, gvNovioRegaloDetalle.Columns["PorcentajeDescuento"]).ToString());
                                decPrecioVenta = decPrecioUnitario * ((100 - decPorcentajeDescuento) / 100);
                                decValorVenta = decimal.Parse(gvNovioRegaloDetalle.GetRowCellValue(posicion, gvNovioRegaloDetalle.Columns["Cantidad"]).ToString()) * Math.Round(decPrecioVenta, 2);

                            }
                            gvNovioRegaloDetalle.SetRowCellValue(posicion, gvNovioRegaloDetalle.Columns["PrecioUnitario"], decPrecioUnitario);
                            gvNovioRegaloDetalle.SetRowCellValue(posicion, gvNovioRegaloDetalle.Columns["PrecioVenta"], decPrecioVenta);
                            gvNovioRegaloDetalle.SetRowCellValue(posicion, gvNovioRegaloDetalle.Columns["ValorVenta"], decValorVenta);
                            posicion++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ObtenerCorrelativo()
        {
            try
            {
                List<NumeracionDocumentoBE> mListaNumero = new List<NumeracionDocumentoBE>();
                string sNumero = "";
                string sSerie = "";
                mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoPeriodo(Parametros.intEmpresaId, Parametros.intTipoDocNovioRegalo, Parametros.intPeriodo);
                if (mListaNumero.Count > 0)
                {
                    sNumero = FuncionBase.AgregarCaracter((mListaNumero[0].Numero + 1).ToString(), "0", 6);
                    sSerie = FuncionBase.AgregarCaracter((mListaNumero[0].Serie).ToString(), "0", 3);
                }
                txtNumero.Text = sNumero;
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            if (deFechaBoda.Text == "")
            {
                strMensaje = strMensaje + "- Seleccionar una Fecha de Boda válida.\n";
                flag = true;
            }

            if (IdNovia == 0)
            {
                strMensaje = strMensaje + "- Seleccionar una Novia válido.\n";
                flag = true;
            }

            if (IdNovio == 0)
            {
                strMensaje = strMensaje + "- Seleccionar una Novio válido.\n";
                flag = true;
            }

            if (cboDocumento.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Seleccionar el tipo de documento.\n";
                flag = true;
            }

            if (cboVendedor.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Seleccionar un vendedor.\n";
                flag = true;
            }

            if (mListaNovioRegaloDetalleOrigen.Count == 0)
            {
                strMensaje = strMensaje + "- Nos se puede generar la NovioRegalo, mientra no haya productos.\n";
                flag = true;
            }

            if (flag)
            {
                XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cursor = Cursors.Default;
            }
            return flag;
        }

        private void CalculaTotales()
        {
            ////try
            ////{
            ////    decimal deImpuesto = 0;
            ////    decimal deValorVenta = 0;
            ////    decimal deSubTotal = 0;
            ////    decimal deTotal = 0;
            ////    int intTotalCantidad = 0;

            ////    if (mListaNovioRegaloDetalleOrigen.Count > 0)
            ////    {
            ////        foreach (var item in mListaNovioRegaloDetalleOrigen)
            ////        {
            ////            intTotalCantidad = intTotalCantidad + item.Cantidad;
            ////            deValorVenta = item.ValorVenta;
            ////            deTotal = deTotal + deValorVenta;
            ////        }

            ////        txtTotal.EditValue = Math.Round(deTotal, 2);
            ////        deSubTotal = deTotal / decimal.Parse(Parametros.dblIGV.ToString());
            ////        txtSubTotal.EditValue = deSubTotal;
            ////        deImpuesto = deTotal - deSubTotal;
            ////        txtImpuesto.EditValue = Math.Round(deImpuesto, 2);
            ////        txtTotalCantidad.EditValue = intTotalCantidad;

            ////    }
            ////    else
            ////    {
            ////        txtTotalCantidad.EditValue = 0;
            ////        txtSubTotal.EditValue = 0;
            ////        txtImpuesto.EditValue = 0;
            ////        txtTotal.EditValue = 0;
            ////    }
            ////}
            ////catch (Exception ex)
            ////{
            ////    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            ////}
        }

        private void ColumRowFocus(string searchText, string Column)
        {
            // obtaining the focused view 
            ColumnView View = (ColumnView)gcNovioRegaloDetalle.FocusedView;
            // obtaining the column bound to the Country field 
            GridColumn column = View.Columns[Column];
            if (column != null)
            {
                // locating the row 
                int rhFound = View.LocateByDisplayText(gvNovioRegaloDetalle.FocusedRowHandle + 1, column, searchText);
                // focusing the cell 
                if (rhFound != 0)
                {
                    View.FocusedRowHandle = rhFound;
                    View.FocusedColumn = column;
                }
            }

        }

        private void ColumRowFocusCantidad(string searchText, string Column)
        {
            // obtaining the focused view 
            ColumnView View = (ColumnView)gcNovioRegaloDetalle.FocusedView;
            // obtaining the column bound to the Country field 
            GridColumn column = View.Columns[Column];
            GridColumn columnbus = View.Columns["Cantidad"];
            if (column != null)
            {
                // locating the row 
                int rhFound = View.LocateByDisplayText(gvNovioRegaloDetalle.FocusedRowHandle + 1, column, searchText);
                // focusing the cell 
                if (rhFound != 0)
                {
                    View.FocusedRowHandle = rhFound;
                    View.FocusedColumn = columnbus;
                }
            }
        }

        private void CargaNovioRegaloDetalle()
        {
            int IdAlmTienda = Parametros.intAlmTienda;
            if (IdAlmTienda == Parametros.intAlmTiendaUcayali)
            {
                IdAlmTienda = Parametros.intAlmCentralUcayali;
            }
            List<NovioRegaloDetalleBE> lstTmpNovioRegaloDetalle = null;
            lstTmpNovioRegaloDetalle = new NovioRegaloDetalleBL().ListaTodosActivo(IdNovioRegalo, IdAlmTienda);

            foreach (NovioRegaloDetalleBE item in lstTmpNovioRegaloDetalle)
            {
                CNovioRegaloDetalle objE_NovioRegaloDetalle = new CNovioRegaloDetalle();
                objE_NovioRegaloDetalle.IdEmpresa = item.IdEmpresa;
                objE_NovioRegaloDetalle.IdNovioRegalo = item.IdNovioRegalo;
                objE_NovioRegaloDetalle.IdNovioRegaloDetalle = item.IdNovioRegaloDetalle;
                objE_NovioRegaloDetalle.Item = item.Item;
                objE_NovioRegaloDetalle.IdProducto = item.IdProducto;
                objE_NovioRegaloDetalle.CodigoProveedor = item.CodigoProveedor;
                objE_NovioRegaloDetalle.NombreProducto = item.NombreProducto;
                objE_NovioRegaloDetalle.Abreviatura = item.Abreviatura;
                objE_NovioRegaloDetalle.Cantidad = item.Cantidad;
                objE_NovioRegaloDetalle.CantidadStock = item.CantidadStock;
                objE_NovioRegaloDetalle.CantidadCompra = item.CantidadCompra;
                objE_NovioRegaloDetalle.CantidadSaldo = item.CantidadSaldo;
                objE_NovioRegaloDetalle.PrecioUnitario = item.PrecioUnitario;
                objE_NovioRegaloDetalle.PorcentajeDescuento = item.PorcentajeDescuento;
                objE_NovioRegaloDetalle.Descuento = item.Descuento;
                objE_NovioRegaloDetalle.PrecioVenta = item.PrecioVenta;
                objE_NovioRegaloDetalle.ValorVenta = item.ValorVenta;
                objE_NovioRegaloDetalle.Observacion = item.Observacion;
                objE_NovioRegaloDetalle.FlagComprado = item.FlagComprado;
                objE_NovioRegaloDetalle.FlagComprar = false;
                objE_NovioRegaloDetalle.PorcentajeDescuentoInicial = 0;
                objE_NovioRegaloDetalle.IdLineaProducto = 0;
                objE_NovioRegaloDetalle.TipoOper = item.TipoOper;
                mListaNovioRegaloDetalleOrigen.Add(objE_NovioRegaloDetalle);
            }

            bsListado.DataSource = mListaNovioRegaloDetalleOrigen;
            gcNovioRegaloDetalle.DataSource = bsListado;
            gcNovioRegaloDetalle.RefreshDataSource();
        }

        #endregion

        public class CNovioRegaloDetalle
        {
            public Int32 IdEmpresa { get; set; }
            public Int32 IdNovioRegalo { get; set; }
            public Int32 IdNovioRegaloDetalle { get; set; }
            public Int32 Item { get; set; }
            public Int32 IdProducto { get; set; }
            public String CodigoProveedor { get; set; }
            public String NombreProducto { get; set; }
            public String Abreviatura { get; set; }
            public Int32 Cantidad { get; set; }
            public Int32 CantidadStock { get; set; }
            public Int32 CantidadCompra { get; set; }
            public Int32 CantidadSaldo { get; set; }
            public Decimal PrecioUnitario { get; set; }
            public Decimal PorcentajeDescuento { get; set; }
            public Decimal Descuento { get; set; }
            public Decimal PrecioVenta { get; set; }
            public Decimal ValorVenta { get; set; }
            public String Observacion { get; set; }
            public Boolean FlagComprado { get; set; }
            public Boolean FlagComprar { get; set; }
            public Int32 Stock { get; set; }
            public Decimal PorcentajeDescuentoInicial { get; set; }
            public Int32 IdLineaProducto { get; set; }
            public Int32 TipoOper { get; set; }

            public CNovioRegaloDetalle()
            {

            }
        }

        private void gvNovioRegaloDetalle_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            try
            {
                if (gvNovioRegaloDetalle.RowCount > 0)
                {
                    //DataRow dr;
                    //dr = gvPromocionTemporalDetalle.GetDataRow(e.FocusedRowHandle);
                    int IdProducto = 0;
                    IdProducto = int.Parse(gvNovioRegaloDetalle.GetFocusedRowCellValue("IdProducto").ToString());

                    //IdProducto = int.Parse(dr["IdProducto"].ToString());

                    ProductoBE objE_Producto = null;
                    objE_Producto = new ProductoBL().SeleccionaImagen(Parametros.intIdPanoramaDistribuidores, IdProducto);

                    if (objE_Producto.Imagen != null)
                    {
                        this.picImage.Image = new FuncionBase().Bytes2Image((byte[])objE_Producto.Imagen);
                    }
                    else
                    { this.picImage.Image = ErpPanorama.Presentation.Properties.Resources.noImage; }
                }
            }
            catch (Exception)
            {
                //throw;
            }
        }
       
    }
}