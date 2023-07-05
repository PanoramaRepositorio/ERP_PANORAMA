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
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Modulos.Maestros.Otros;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.DiseñoInteriores.Maestros
{
    public partial class frmManProductoEditKira : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<CProductoAsociado> mLista = new List<CProductoAsociado>();
        public List<CProductoComponente> mListaComponentes = new List<CProductoComponente>();

        public List<ProductoBE> lstProducto;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        int _IdProducto = 0;

        public int IdProducto
        {
            get { return _IdProducto; }
            set { _IdProducto = value; }
        }

        string _CodigoProveedor = "";

        public string CodigoProveedor
        {
            get { return _CodigoProveedor; }
            set { _CodigoProveedor = value; }
        }

        int IdProductoFoto = 0;
        int? IdProductoArmado = null;

        #endregion

        #region "Eventos"

        public frmManProductoEditKira()
        {
            InitializeComponent();
        }

        private void frmManProductoEditKira_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboUnidadMedida, new UnidadMedidaBL().ListaTodosActivo(Parametros.intEmpresaId), "Abreviatura", "IdUnidadMedida", true);
            BSUtils.LoaderLook(cboProcedencia, new ProcedenciaBL().ListaTodosActivo(Parametros.intEmpresaId), "DescProcedencia", "IdProcedencia", true);
            BSUtils.LoaderLook(cboMaterial, new MaterialBL().ListaTodosActivo(Parametros.intEmpresaId), "DescMaterial", "IdMaterial", true);
            BSUtils.LoaderLook(cboMaterial2, new MaterialBL().ListaTodosActivo(Parametros.intEmpresaId), "DescMaterial", "IdMaterial", true);
            BSUtils.LoaderLook(cboMarca, new MarcaBL().ListaTodosActivo(Parametros.intEmpresaId), "DescMarca", "IdMarca", true);
            BSUtils.LoaderLook(cboFamilia, new FamiliaProductoBL().ListaTodosActivo(Parametros.intEmpresaId), "DescFamiliaProducto", "IdFamiliaProducto", true);
            BSUtils.LoaderLook(cboLinea, new LineaProductoBL().ListaTodosActivo(Parametros.intEmpresaId), "DescLineaProducto", "IdLineaProducto", true);
            BSUtils.LoaderLook(cboTipoProducto, new TablaElementoBL().ListaTodosActivoPorTabla(Parametros.intEmpresaId,Parametros.intTblTipoProducto), "DescTablaElemento", "IdTablaElemento", true);
            //BSUtils.LoaderLook(cboSubTipoServicio, new TablaElementoBL().ListaTodosActivoPorTabla(Parametros.intEmpresaId, Parametros.intTblSubTipoProducto), "DescTablaElemento", "IdTablaElemento", true);

            txtTipoCambioMayorista.EditValue = Parametros.dmlTCMayorista;
            txtTipoCambioMinorista.EditValue = Parametros.dmlTCMinorista;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Producto - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Producto - Modificar";

                ProductoBE objE_Producto = new ProductoBE();
                objE_Producto = new ProductoBL().Selecciona(Parametros.intEmpresaId, Parametros.intTiendaId, CodigoProveedor);
                txtCodigoProveedor.Text = objE_Producto.CodigoProveedor;
                txtCodigoPanorama.Text = objE_Producto.CodigoPanorama;
                txtNombreProducto.Text = objE_Producto.NombreProducto;
                cboUnidadMedida.EditValue = objE_Producto.IdUnidadMedida;
                txtDescripcion.Text = objE_Producto.Descripcion;
                cboProcedencia.EditValue = objE_Producto.IdProcedencia;
                cboMaterial.EditValue = objE_Producto.IdMaterial;
                cboMaterial2.EditValue = objE_Producto.IdMaterial2;
                cboMarca.EditValue = objE_Producto.IdMarca;
                txtCodigoPanorama.Text = objE_Producto.CodigoBarra;
                txtPeso.EditValue = objE_Producto.Peso;
                txtMedida.Text = objE_Producto.Medida;

                txtMedidaIh.EditValue = objE_Producto.MedidaInternaAltura;
                txtMedidaIw.EditValue=objE_Producto.MedidaInternaAncho ;
                txtMedidaIp.EditValue =objE_Producto.MedidaInternaProfundidad;
                txtMedidaEh.EditValue = objE_Producto.MedidaExternaAltura;
                txtMedidaEw.EditValue = objE_Producto.MedidaExternaAncho;
                txtMedidaEp.EditValue = objE_Producto.MedidaExternaProfundidad ;
                txtPesoBruto.EditValue = objE_Producto.PesoNeto ;
                txtPesoNeto.EditValue = objE_Producto.PesoBruto;

                cboFamilia.EditValue = objE_Producto.IdFamiliaProducto;//add
                cboLinea.EditValue = objE_Producto.IdLineaProducto;
                cboSubLinea.EditValue = objE_Producto.IdSubLineaProducto;
                cboModelo.EditValue = objE_Producto.IdModeloProducto;
                txtObservaciones.Text = objE_Producto.Observacion;
                chkEscala.Checked = objE_Producto.FlagEscala;
                chkDestacado.Checked = objE_Producto.FlagDestacado;
                chkRecomendado.Checked = objE_Producto.FlagRecomendado;
                chkObsequio.Checked = objE_Producto.FlagObsequio;
                chkNacional.Checked = objE_Producto.FlagNacional;
                txtDescuento.EditValue = objE_Producto.Descuento;
                txtPrecioAB.EditValue = objE_Producto.PrecioAB;
                txtPrecioCD.EditValue = objE_Producto.PrecioCD;
                txtCodigoBarra.Text = objE_Producto.CodigoBarra;
                IdProductoArmado = objE_Producto.IdProductoArmado;
                chkCompuesto.Checked = objE_Producto.FlagCompuesto;
                chkActivo.Checked = objE_Producto.FlagEstado;
                cboTipoProducto.EditValue = objE_Producto.IdTipoProducto;
                cboSubTipoProducto.EditValue = objE_Producto.IdSubTipoProducto;

                txtColeccion.EditValue = objE_Producto.Coleccion;

                if (objE_Producto.Imagen != null)
                {
                    this.picImage.Image = new FuncionBase().Bytes2Image((byte[])objE_Producto.Imagen);
                }
                else
                { this.picImage.Image = ErpPanorama.Presentation.Properties.Resources.noImage; }

                //Producto Foto

                List<ProductoFotoBE> mListaProductoFoto = null;
                mListaProductoFoto = new ProductoFotoBL().ListaTodosActivo(IdProducto);

                foreach (var item in mListaProductoFoto)
	            {
                    IdProductoFoto = item.IdProductoFoto;
                    txtRutaFrontal.Text = item.Frontal;
                    txtRutaLateral.Text = item.Lateral;
                    txtRutaTrasera.Text = item.Trasera;
	            } 
              
                //Producto Armado
                if (IdProductoArmado != null)
                {
                    ProductoBE objE_ProductoArmado = new ProductoBE();
                    objE_ProductoArmado = new ProductoBL().SeleccionaIDTodos(Convert.ToInt32(IdProductoArmado));

                    IdProductoArmado = objE_ProductoArmado.IdProducto;
                    txtCodigoProvArmado.Text = objE_ProductoArmado.CodigoProveedor;
                    txtUnidadMedidaArm.Text = objE_ProductoArmado.Abreviatura;
                    txtNombreProdArmado.Text = objE_ProductoArmado.NombreProducto;
                    txtPrecioABArm.EditValue = objE_ProductoArmado.PrecioAB;
                    txtPrecioCDArm.EditValue = objE_ProductoArmado.PrecioCD;
                    txtPrecioABMayoristaArm.EditValue = objE_ProductoArmado.PrecioAB * Convert.ToDecimal(Parametros.dmlTCMayorista);
                    if (objE_ProductoArmado.FlagNacional == true)
                        txtPrecioCDMinoristaArm.EditValue = objE_ProductoArmado.PrecioCD * Convert.ToDecimal(Parametros.dmlTCMayorista);
                    else
                        txtPrecioCDMinoristaArm.EditValue = objE_ProductoArmado.PrecioCD * Convert.ToDecimal(Parametros.dmlTCMinorista);
                    txtDescuentoArm.EditValue = objE_ProductoArmado.Descuento;
                }

                //Cargar Producto Asociado
                CargarProductoAsociado();

                //Cargar Producto Componente
                CargarProductoComponente();

                //Deshabilitar productos
                CargarPefilEditor();
            }           
            txtCodigoProveedor.Select();
        }

        private void cboLinea_EditValueChanged(object sender, EventArgs e)
        {
            if (cboLinea.EditValue != null)
            {
                BSUtils.LoaderLook(cboSubLinea, new SubLineaProductoBL().ListaTodosActivo(Parametros.intEmpresaId, Convert.ToInt32(cboLinea.EditValue.ToString())), "DescSubLineaProducto", "IdSubLineaProducto", true);
            }
        }

        private void cboSubLinea_EditValueChanged(object sender, EventArgs e)
        {
            if (cboSubLinea.EditValue != null)
            {
                BSUtils.LoaderLook(cboModelo, new ModeloProductoBL().ListaTodosActivo(Parametros.intEmpresaId, Convert.ToInt32(cboLinea.EditValue.ToString()), Convert.ToInt32(cboSubLinea.EditValue.ToString())), "DescModeloProducto", "IdModeloProducto", true);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Jpg File|*.Jpg|Jpeg File|*.Jpeg|Png File|*.Png |Gif File|*.Gif|All|*.*";
            openFile.ShowDialog();

            if (openFile.FileName.Length != 0)
            {
                FileInfo fi;
                Decimal mxKb = Parametros.dmlTamanioImagen;//Convert.ToDecimal(100);
                Decimal acKb;

                fi = new FileInfo(openFile.FileName);
                acKb = Convert.ToDecimal(fi.Length) / 1024;
                if (fi.Length > (mxKb * 1024))
                {
                    XtraMessageBox.Show(openFile.FileName + " Tamaño Máximo: " + mxKb.ToString() + " Kb. Tamaño Actual: " + acKb.ToString("###,##0.00") + " Kb.", "Importar Imagenes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    this.picImage.Image = Image.FromFile(openFile.FileName);
                }
            }
        }

        private void txtDescuento_EditValueChanged(object sender, EventArgs e)
        {
            CalcularDescuentosAB(Convert.ToDecimal(txtPrecioAB.EditValue), Convert.ToDecimal(txtDescuento.EditValue));
            CalcularDescuentosCD(Convert.ToDecimal(txtPrecioCD.EditValue), Convert.ToDecimal(txtDescuento.EditValue));
        }


        private void txtPrecioAB_EditValueChanged(object sender, EventArgs e)
        {
            CalcularDescuentosAB(Convert.ToDecimal(txtPrecioAB.EditValue), Convert.ToDecimal(txtDescuento.EditValue));
        }

        private void txtPrecioCD_EditValueChanged(object sender, EventArgs e)
        {
            CalcularDescuentosCD(Convert.ToDecimal(txtPrecioCD.EditValue), Convert.ToDecimal(txtDescuento.EditValue));
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            this.picImage.Image = ErpPanorama.Presentation.Properties.Resources.noImage;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    ProductoBL objBL_Producto = new ProductoBL();
                    ProductoBE objE_Producto = new ProductoBE();

                    objE_Producto.IdProducto = IdProducto;
                    objE_Producto.CodigoProveedor = txtCodigoProveedor.Text;
                    objE_Producto.CodigoPanorama = txtCodigoPanorama.Text;
                    objE_Producto.IdUnidadMedida = Convert.ToInt32(cboUnidadMedida.EditValue);
                    objE_Producto.IdFamiliaProducto = Convert.ToInt32(cboFamilia.EditValue);
                    objE_Producto.IdLineaProducto = Convert.ToInt32(cboLinea.EditValue);
                    objE_Producto.IdSubLineaProducto = Convert.ToInt32(cboSubLinea.EditValue);
                    objE_Producto.IdModeloProducto = Convert.ToInt32(cboModelo.EditValue);
                    objE_Producto.IdMaterial = Convert.ToInt32(cboMaterial.EditValue);
                    objE_Producto.IdMaterial2 = Convert.ToInt32(cboMaterial2.EditValue);
                    objE_Producto.IdMarca = Convert.ToInt32(cboMarca.EditValue);
                    objE_Producto.IdProcedencia = Convert.ToInt32(cboProcedencia.EditValue);
                    objE_Producto.NombreProducto = txtNombreProducto.Text;
                    objE_Producto.Descripcion = txtDescripcion.Text;
                    objE_Producto.Peso = Convert.ToDecimal(txtPeso.EditValue);
                    objE_Producto.Medida = txtMedida.Text;

                    objE_Producto.Coleccion = txtColeccion.Text;

                    objE_Producto.MedidaInternaAltura = Convert.ToDecimal(txtMedidaIh.EditValue);
                    objE_Producto.MedidaInternaAncho = Convert.ToDecimal(txtMedidaIw.EditValue);
                    objE_Producto.MedidaInternaProfundidad = Convert.ToDecimal(txtMedidaIp.EditValue);

                    objE_Producto.MedidaExternaAltura = Convert.ToDecimal(txtMedidaEh.EditValue);
                    objE_Producto.MedidaExternaAncho = Convert.ToDecimal(txtMedidaEw.EditValue);
                    objE_Producto.MedidaExternaProfundidad = Convert.ToDecimal(txtMedidaEp.EditValue);

                    objE_Producto.PesoBruto = Convert.ToDecimal(txtPesoBruto.EditValue);
                    objE_Producto.PesoNeto = Convert.ToDecimal(txtPesoNeto.EditValue);

                    objE_Producto.CodigoBarra = txtCodigoBarra.Text;
                    objE_Producto.Imagen = new FuncionBase().Image2Bytes(this.picImage.Image);
                    objE_Producto.Descuento = Convert.ToDecimal(txtDescuento.EditValue);
                    objE_Producto.PrecioAB = Convert.ToDecimal(txtPrecioAB.EditValue);
                    objE_Producto.PrecioCD = Convert.ToDecimal(txtPrecioCD.EditValue);
                    objE_Producto.FlagCompuesto = chkCompuesto.Checked;
                    objE_Producto.FlagEscala = chkEscala.Checked;
                    objE_Producto.FlagDestacado = chkDestacado.Checked;
                    objE_Producto.FlagRecomendado = chkRecomendado.Checked;
                    objE_Producto.FlagObsequio = chkObsequio.Checked;
                    objE_Producto.FlagNacional = chkNacional.Checked;
                    objE_Producto.IdProductoArmado = IdProductoArmado;
                    objE_Producto.Observacion = txtObservaciones.Text;
                    objE_Producto.Fecha = Parametros.dtFechaHoraServidor;
                    objE_Producto.IdTipoProducto = Convert.ToInt32(cboTipoProducto.EditValue);
                    objE_Producto.IdSubTipoProducto = Convert.ToInt32(cboSubTipoProducto.EditValue);
                    objE_Producto.FlagEstado =chkActivo.Checked;//true;
                    objE_Producto.Usuario = Parametros.strUsuarioLogin;
                    objE_Producto.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objE_Producto.IdEmpresa = Parametros.intEmpresaId;

                    //Fotografías del producto
                    ProductoFotoBE objE_ProductoFoto = new ProductoFotoBE();
                    objE_ProductoFoto.IdProductoFoto = IdProductoFoto;
                    objE_ProductoFoto.IdProducto = IdProducto;
                    objE_ProductoFoto.Frontal = txtRutaFrontal.Text;
                    objE_ProductoFoto.Lateral = txtRutaLateral.Text;
                    objE_ProductoFoto.Trasera = txtRutaTrasera.Text;
                    objE_ProductoFoto.FlagEstado = true;
                    objE_ProductoFoto.Usuario = Parametros.strUsuarioLogin;
                    objE_ProductoFoto.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objE_ProductoFoto.IdEmpresa = Parametros.intEmpresaId;

                    //Producto Asociado
                    List<ProductoAsociadoBE> lstProductoAsociado = new List<ProductoAsociadoBE>();

                    foreach (var item in mLista)
                    {
                        ProductoAsociadoBE objE_ProductoAsociado = new ProductoAsociadoBE();
                        objE_ProductoAsociado.IdProductoAsociado = item.IdProductoAsociado;
                        objE_ProductoAsociado.IdProducto = item.IdProducto;
                        objE_ProductoAsociado.CodigoProveedor = item.CodigoProveedor;
                        objE_ProductoAsociado.NombreProducto = item.NombreProducto;
                        objE_ProductoAsociado.Abreviatura = item.Abreviatura;
                        objE_ProductoAsociado.Cantidad = item.Cantidad;
                        objE_ProductoAsociado.Precio = item.Precio;
                        objE_ProductoAsociado.Descuento = item.Descuento;
                        objE_ProductoAsociado.IdProductoReferencia = item.IdProductoReferencia;
                        objE_ProductoAsociado.FlagEstado = true;
                        objE_ProductoAsociado.TipoOper = item.TipoOper;
                        objE_ProductoAsociado.Usuario = Parametros.strUsuarioLogin;
                        objE_ProductoAsociado.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        lstProductoAsociado.Add(objE_ProductoAsociado);
                    }

                    if (pOperacion == Operacion.Nuevo)
                    {
                        objBL_Producto.Inserta(objE_Producto, objE_ProductoFoto);
                    }
                    else
                    {
                        objE_ProductoFoto.TipoOper = Convert.ToInt32(Operacion.Nuevo);
                        objBL_Producto.Actualiza(objE_Producto, objE_ProductoFoto);

                        //Asociados
                        ProductoAsociadoBL objBL_ProductoAsociado = new ProductoAsociadoBL();
                        objBL_ProductoAsociado.Inserta(lstProductoAsociado);
                    }



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

        private void btnVerRutaF_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Jpg File|*.Jpg|Jpeg File|*.Jpeg|Png File|*.Png |Gif File|*.Gif|All|*.*";
            openFile.ShowDialog();

            if (openFile.FileName.Length != 0)
            {
                txtRutaFrontal.Text = openFile.FileName.ToString();
            }
        }

        private void btnVerRutaLateral_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Jpg File|*.Jpg|Jpeg File|*.Jpeg|Png File|*.Png |Gif File|*.Gif|All|*.*";
            openFile.ShowDialog();

            if (openFile.FileName.Length != 0)
            {
                txtRutaLateral.Text = openFile.FileName.ToString();
            }
        }

        private void btnVerRutaPosterior_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Jpg File|*.Jpg|Jpeg File|*.Jpeg|Png File|*.Png |Gif File|*.Gif|All|*.*";
            openFile.ShowDialog();

            if (openFile.FileName.Length != 0)
            {
                txtRutaTrasera.Text = openFile.FileName.ToString();
            }
        }

        private void groupControl6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtCodigoProvArmado_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtCodigoProvArmado.Text.Length > 0)
                {
                    frmBusProducto objBusProducto = new frmBusProducto();
                    objBusProducto.pDescripcion = txtCodigoProvArmado.Text.Trim();
                    objBusProducto.ShowDialog();
                    if (objBusProducto.pProductoBE != null)
                    {
                        ProductoBE objE_Producto = null;
                        objE_Producto = new ProductoBL().Selecciona(Parametros.intEmpresaId, Parametros.intTiendaId, objBusProducto.pProductoBE.CodigoProveedor);
                        if (objE_Producto != null)
                        {
                            IdProductoArmado = objE_Producto.IdProducto;
                            txtCodigoProvArmado.Text = objE_Producto.CodigoProveedor;
                            txtUnidadMedidaArm.Text = objE_Producto.Abreviatura;
                            txtNombreProdArmado.Text = objE_Producto.NombreProducto;
                            txtPrecioABArm.EditValue = objE_Producto.PrecioAB;
                            txtPrecioCDArm.EditValue = objE_Producto.PrecioCD;
                            txtPrecioABMayoristaArm.EditValue = objE_Producto.PrecioAB * Convert.ToDecimal(Parametros.dmlTCMayorista);
                            if (objE_Producto.FlagNacional == true)
                                txtPrecioCDMinoristaArm.EditValue = objE_Producto.PrecioCD * Convert.ToDecimal(Parametros.dmlTCMayorista);
                            else
                                txtPrecioCDMinoristaArm.EditValue = objE_Producto.PrecioCD * Convert.ToDecimal(Parametros.dmlTCMinorista);
                            txtDescuentoArm.EditValue = objE_Producto.Descuento;

                            //if (objE_Producto.Imagen != null)
                            //{
                            //    this.picImage.Image = new FuncionBase().Bytes2Image((byte[])objE_Producto.Imagen);
                            //}
                            //else
                            //{ this.picImage.Image = ErpPanorama.Presentation.Properties.Resources.noImage; }

                            //txtDescuento.Focus();

                        }
                        else
                        {
                            XtraMessageBox.Show("El código de producto no existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                }
            }
        }

        private void btnLimpiarArmado_Click(object sender, EventArgs e)
        {
            LimpiarArmado();
        }

        private void cboFamilia_EditValueChanged(object sender, EventArgs e)
        {
            if (cboLinea.EditValue != null)
            {
                BSUtils.LoaderLook(cboLinea, new LineaProductoBL().ListaTodosActivoFamilia(Parametros.intEmpresaId, Convert.ToInt32(cboFamilia.EditValue.ToString())), "DescLineaProducto", "IdLineaProducto", true);
            }
        }


        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //frmManComboPromocionalDetalleEdit movDetalle = new frmManComboPromocionalDetalleEdit();
                //if (movDetalle.ShowDialog() == DialogResult.OK)
                //{
                //    if (movDetalle.oBE != null)
                //    {
                //        if (mLista.Count == 0)
                //        {
                //            gvProductoAsociado.AddNewRow();
                //            gvProductoAsociado.SetRowCellValue(gvProductoAsociado.FocusedRowHandle, "IdEmpresa", movDetalle.oBE.IdEmpresa);
                //            gvProductoAsociado.SetRowCellValue(gvProductoAsociado.FocusedRowHandle, "IdProductoAsociado", 0);
                //            gvProductoAsociado.SetRowCellValue(gvProductoAsociado.FocusedRowHandle, "IdProducto", movDetalle.oBE.IdProducto);
                //            gvProductoAsociado.SetRowCellValue(gvProductoAsociado.FocusedRowHandle, "CodigoProveedor", movDetalle.oBE.CodigoProveedor);
                //            gvProductoAsociado.SetRowCellValue(gvProductoAsociado.FocusedRowHandle, "NombreProducto", movDetalle.oBE.NombreProducto);
                //            gvProductoAsociado.SetRowCellValue(gvProductoAsociado.FocusedRowHandle, "Abreviatura", movDetalle.oBE.Abreviatura);
                //            gvProductoAsociado.SetRowCellValue(gvProductoAsociado.FocusedRowHandle, "Cantidad", movDetalle.oBE.Cantidad);
                //            gvProductoAsociado.SetRowCellValue(gvProductoAsociado.FocusedRowHandle, "Precio", movDetalle.oBE.Precio);
                //            gvProductoAsociado.SetRowCellValue(gvProductoAsociado.FocusedRowHandle, "Descuento", movDetalle.oBE.Descuento);
                //            gvProductoAsociado.SetRowCellValue(gvProductoAsociado.FocusedRowHandle, "IdProductoReferencia", IdProducto);
                //            gvProductoAsociado.SetRowCellValue(gvProductoAsociado.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                //            gvProductoAsociado.UpdateCurrentRow();

                //            CalculaTotales();

                //            //Activar Compuesto
                //            chkCompuesto.Checked = true;

                //            return;

                //        }
                //        if (mLista.Count > 0)
                //        {
                //            var Buscar = mLista.Where(oB => oB.IdProducto == movDetalle.oBE.IdProducto).ToList();
                //            if (Buscar.Count > 0)
                //            {
                //                XtraMessageBox.Show("El código de producto ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //                return;
                //            }
                //            gvProductoAsociado.AddNewRow();
                //            gvProductoAsociado.SetRowCellValue(gvProductoAsociado.FocusedRowHandle, "IdEmpresa", movDetalle.oBE.IdEmpresa);
                //            gvProductoAsociado.SetRowCellValue(gvProductoAsociado.FocusedRowHandle, "IdProductoAsociado", 0);
                //            gvProductoAsociado.SetRowCellValue(gvProductoAsociado.FocusedRowHandle, "IdProducto", movDetalle.oBE.IdProducto);
                //            gvProductoAsociado.SetRowCellValue(gvProductoAsociado.FocusedRowHandle, "CodigoProveedor", movDetalle.oBE.CodigoProveedor);
                //            gvProductoAsociado.SetRowCellValue(gvProductoAsociado.FocusedRowHandle, "NombreProducto", movDetalle.oBE.NombreProducto);
                //            gvProductoAsociado.SetRowCellValue(gvProductoAsociado.FocusedRowHandle, "Abreviatura", movDetalle.oBE.Abreviatura);
                //            gvProductoAsociado.SetRowCellValue(gvProductoAsociado.FocusedRowHandle, "Cantidad", movDetalle.oBE.Cantidad);
                //            gvProductoAsociado.SetRowCellValue(gvProductoAsociado.FocusedRowHandle, "Precio", movDetalle.oBE.Precio);
                //            gvProductoAsociado.SetRowCellValue(gvProductoAsociado.FocusedRowHandle, "Descuento", movDetalle.oBE.Descuento);
                //            gvProductoAsociado.SetRowCellValue(gvProductoAsociado.FocusedRowHandle, "IdProductoReferencia", IdProducto);
                //            gvProductoAsociado.SetRowCellValue(gvProductoAsociado.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                //            gvProductoAsociado.UpdateCurrentRow();

                //            CalculaTotales();

                //        }
                //    }
                //}


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void modificarprecioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (mLista.Count > 0)
            //{
            //    int xposition = 0;
            //    int IdProductoAsociado = Convert.ToInt32(gvProductoAsociado.GetFocusedRowCellValue("IdProductoAsociado"));
            //    int IdProductoReferencia = Convert.ToInt32(gvProductoAsociado.GetFocusedRowCellValue("IdProductoReferencia"));

            //    frmManComboPromocionalDetalleEdit movDetalle = new frmManComboPromocionalDetalleEdit();
            //    //movDetalle.IdProductoReferencia = Convert.ToInt32(gvProductoAsociado.GetFocusedRowCellValue("IdProductoReferencia"));
            //    movDetalle.IdProducto = Convert.ToInt32(gvProductoAsociado.GetFocusedRowCellValue("IdProducto"));
            //    movDetalle.txtCodigo.Text = gvProductoAsociado.GetFocusedRowCellValue("CodigoProveedor").ToString();
            //    movDetalle.txtProducto.Text = gvProductoAsociado.GetFocusedRowCellValue("NombreProducto").ToString();
            //    movDetalle.txtUM.Text = gvProductoAsociado.GetFocusedRowCellValue("Abreviatura").ToString();
            //    movDetalle.txtCantidad.EditValue = Convert.ToInt32(gvProductoAsociado.GetFocusedRowCellValue("Cantidad"));
            //    movDetalle.txtPrecioUnitario.EditValue = Convert.ToDecimal(gvProductoAsociado.GetFocusedRowCellValue("Precio"));
            //    movDetalle.txtDescuento.EditValue = Convert.ToDecimal(gvProductoAsociado.GetFocusedRowCellValue("Descuento"));

            //    if (movDetalle.ShowDialog() == DialogResult.OK)
            //    {
            //        xposition = gvProductoAsociado.FocusedRowHandle;

            //        if (movDetalle.oBE != null)
            //        {
            //            gvProductoAsociado.SetRowCellValue(xposition, "IdEmpresa", movDetalle.oBE.IdEmpresa);
            //            gvProductoAsociado.SetRowCellValue(xposition, "IdProductoAsociado", IdProductoAsociado);
            //            gvProductoAsociado.SetRowCellValue(xposition, "IdProducto", movDetalle.oBE.IdProducto);
            //            gvProductoAsociado.SetRowCellValue(xposition, "CodigoProveedor", movDetalle.oBE.CodigoProveedor);
            //            gvProductoAsociado.SetRowCellValue(xposition, "NombreProducto", movDetalle.oBE.NombreProducto);
            //            gvProductoAsociado.SetRowCellValue(xposition, "Abreviatura", movDetalle.oBE.Abreviatura);
            //            gvProductoAsociado.SetRowCellValue(xposition, "Cantidad", movDetalle.oBE.Cantidad);
            //            gvProductoAsociado.SetRowCellValue(xposition, "Precio", movDetalle.oBE.Precio);
            //            gvProductoAsociado.SetRowCellValue(xposition, "Descuento", movDetalle.oBE.Descuento);
            //            gvProductoAsociado.SetRowCellValue(xposition, "IdProductoReferencia", IdProductoReferencia);
            //            if (pOperacion == Operacion.Modificar && Convert.ToDecimal(gvProductoAsociado.GetFocusedRowCellValue("TipoOper")) == Convert.ToInt32(Operacion.Nuevo))
            //                gvProductoAsociado.SetRowCellValue(xposition, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
            //            else
            //                gvProductoAsociado.SetRowCellValue(xposition, "TipoOper", Convert.ToInt32(Operacion.Modificar));
            //            gvProductoAsociado.UpdateCurrentRow();

            //            CalculaTotales();

            //        }
            //    }
            //}
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (mLista.Count > 0)
                {
                    if (int.Parse(gvProductoAsociado.GetFocusedRowCellValue("IdProducto").ToString()) != 0)
                    {
                        int IdProductoAsociado = 0;
                        if (gvProductoAsociado.GetFocusedRowCellValue("IdProductoAsociado") != null)
                            IdProductoAsociado = int.Parse(gvProductoAsociado.GetFocusedRowCellValue("IdProductoAsociado").ToString());
                        int Item = 0;
                        if (gvProductoAsociado.GetFocusedRowCellValue("Item") != null)
                            Item = int.Parse(gvProductoAsociado.GetFocusedRowCellValue("Item").ToString());
                        ProductoAsociadoBE objBE_ProductoAsociado = new ProductoAsociadoBE();
                        objBE_ProductoAsociado.IdProductoAsociado = IdProductoAsociado;
                        objBE_ProductoAsociado.IdEmpresa = Parametros.intEmpresaId;
                        objBE_ProductoAsociado.Usuario = Parametros.strUsuarioLogin;
                        objBE_ProductoAsociado.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                        ProductoAsociadoBL objBL_ProductoAsociado = new ProductoAsociadoBL();
                        objBL_ProductoAsociado.Elimina(objBE_ProductoAsociado);
                        gvProductoAsociado.DeleteRow(gvProductoAsociado.FocusedRowHandle);
                        gvProductoAsociado.RefreshData();

                    }
                    else
                    {
                        gvProductoAsociado.DeleteRow(gvProductoAsociado.FocusedRowHandle);
                        gvProductoAsociado.RefreshData();
                    }

                    CalculaTotales();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region "Metodos"

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            if (txtCodigoProveedor.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese el Código de Proveedor.\n";
                flag = true;
            }

            if (cboUnidadMedida.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese la Unidad de Medida.\n";
                flag = true;
            }

            if (txtNombreProducto.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese el Nombre del Producto.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstProducto.Where(oB => oB.CodigoProveedor.ToUpper() == txtCodigoProveedor.Text.ToUpper()).ToList();
                if (Buscar.Count > 0)
                {
                    strMensaje = strMensaje + "- El código ya existe.\n";
                    flag = true;
                }
            }

            if (flag)
            {
                XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cursor = Cursors.Default;
            }
            return flag;
        }

        private void CalcularDescuentosAB(decimal dmlPrecioAB, decimal dmlDescuento)
        {
            txtPrecioABDescuento.EditValue = dmlPrecioAB * ((100 - dmlDescuento) / 100);
            txtPrecioABSoles.EditValue = Convert.ToDecimal(txtPrecioAB.EditValue) * Convert.ToDecimal(txtTipoCambioMayorista.EditValue);

            txtPrecioABSolesDescuento.EditValue = Convert.ToDecimal(txtPrecioABSoles.EditValue) * ((100 - dmlDescuento) / 100);
        }

        private void CalcularDescuentosCD(decimal dmlPrecioCD, decimal dmlDescuento)
        {
            txtPrecioCDDescuento.EditValue = dmlPrecioCD * ((100 - dmlDescuento) / 100);
            txtPrecioCDSoles.EditValue = Convert.ToDecimal(txtPrecioCD.EditValue) * Convert.ToDecimal(txtTipoCambioMinorista.EditValue);

            txtPrecioCDSolesDescuento.EditValue = Convert.ToDecimal(txtPrecioCDSoles.EditValue) * ((100 - dmlDescuento) / 100);
        }

        private void LimpiarArmado()
        {
            IdProductoArmado = null;
            txtCodigoProvArmado.Text = "";
            txtUnidadMedidaArm.Text = "";
            txtNombreProdArmado.Text = "";
            txtPrecioABArm.EditValue = 0;
            txtPrecioCDArm.EditValue = 0;
            txtPrecioABMayoristaArm.EditValue = 0;
            txtPrecioCDMinoristaArm.EditValue = 0;
            txtDescuentoArm.EditValue = 0;
        }

        private void CalculaTotales()
        {
            try
            {

                decimal deValorVenta = 0;
                decimal deTotal = 0;

                if (mLista.Count > 0)
                {
                    foreach (var item in mLista)
                    {
                        deValorVenta = item.Precio;
                        deTotal = deTotal + deValorVenta;
                    }

                    txtTotalAsociado.EditValue = Math.Round(deTotal, 2);
                    //chkCompuesto.Checked = true;
                }
                else
                {
                    txtTotalAsociado.EditValue = 0;
                    //chkCompuesto.Checked = false;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarProductoAsociado()
        {
            List<ProductoAsociadoBE> lstTmpProductoAsociado = null;
            lstTmpProductoAsociado = new ProductoAsociadoBL().ListaTodosActivo(IdProducto);

            foreach (ProductoAsociadoBE item in lstTmpProductoAsociado)
            {
                CProductoAsociado objE_ProductoAsociado = new CProductoAsociado();
                objE_ProductoAsociado.IdProducto = item.IdProducto;
                objE_ProductoAsociado.IdProductoAsociado = item.IdProductoAsociado;
                objE_ProductoAsociado.IdProducto = item.IdProducto;
                objE_ProductoAsociado.CodigoProveedor = item.CodigoProveedor;
                objE_ProductoAsociado.NombreProducto = item.NombreProducto;
                objE_ProductoAsociado.Abreviatura = item.Abreviatura;
                objE_ProductoAsociado.Cantidad = item.Cantidad;
                objE_ProductoAsociado.Precio = item.Precio;
                objE_ProductoAsociado.Descuento = item.Descuento;
                objE_ProductoAsociado.IdProductoReferencia = item.IdProductoReferencia;
                objE_ProductoAsociado.TipoOper = item.TipoOper;
                mLista.Add(objE_ProductoAsociado);
            }

            bsListado.DataSource = mLista;
            gcProductoAsociado.DataSource = bsListado;
            gcProductoAsociado.RefreshDataSource();

            CalculaTotales();
        }

        #endregion

        public class CProductoAsociado
        {
            public Int32 IdProductoAsociado { get; set; }
            public Int32 IdProducto { get; set; }
            public String CodigoProveedor { get; set; }
            public String NombreProducto { get; set; }
            public String Abreviatura { get; set; }
            public Int32 Cantidad { get; set; }
            public Decimal Precio { get; set; }
            public Decimal Descuento { get; set; }
            public Int32 IdProductoReferencia { get; set; }
            public Int32 TipoOper { get; set; }

            public CProductoAsociado()
            {

            }
        }

        private void CargarProductoComponente()
        {
            List<ProductoComponenteBE> lstTmpProductoAsociado = null;
            lstTmpProductoAsociado = new ProductoAsociadoBL().ListaTodosActivoComponente(IdProducto);

            foreach (ProductoComponenteBE item in lstTmpProductoAsociado)
            {
                CProductoComponente objE_ProductoComponente = new CProductoComponente();
                objE_ProductoComponente.IdProductoComponente = item.IdProductoComponente;
                objE_ProductoComponente.IdProducto = item.IdProducto;
                objE_ProductoComponente.DescComponente = item.DescComponente;
                objE_ProductoComponente.IdMaterial = item.IdMaterial;
                objE_ProductoComponente.DescMaterial = item.DescMaterial;
                objE_ProductoComponente.IdColor = item.IdColor;
                objE_ProductoComponente.DescColor = item.DescColor;
                objE_ProductoComponente.cAncho = item.cAncho;
                objE_ProductoComponente.cLargo = item.cLargo;
                objE_ProductoComponente.cAlto = item.cAlto;
                objE_ProductoComponente.cProfundidad = item.cProfundidad;
                objE_ProductoComponente.Cantidad = item.Cantidad;
                objE_ProductoComponente.IdUnidadMedida = item.IdUnidadMedida;
                objE_ProductoComponente.DescUnidadMedida = item.DescUnidadMedida;

                objE_ProductoComponente.TipoOper = item.TipoOper;

                mListaComponentes.Add(objE_ProductoComponente);
            }

            bsListado.DataSource = mLista;
            gcProductoAsociado.DataSource = bsListado;
            gcProductoAsociado.RefreshDataSource();

            CalculaTotales();
        }

        public class CProductoComponente
        {
            public Int32 IdProductoComponente { get; set; }
            public Int32 IdProducto { get; set; }
            public String DescComponente { get; set; }

            public Int32 IdMaterial { get; set; }
            public String DescMaterial { get; set; }

            public Int32 IdColor { get; set; }
            public String DescColor { get; set; }

            public Int32 cAncho { get; set; }
            public Int32 cLargo { get; set; }
            public Int32 cAlto { get; set; }
            public Int32 cProfundidad { get; set; }
            public Int32 Cantidad { get; set; }

            public Int32 IdUnidadMedida { get; set; }
            public String DescUnidadMedida { get; set; }
            public Int32 TipoOper { get; set; }

            public CProductoComponente()
            {

            }
        }



        private void chkActivo_CheckedChanged(object sender, EventArgs e)
        {
            //if (chkActivo.Checked == true)
            //{
            //    chkActivo.Text = "Activo";
            //}
        }

        private void CargarPefilEditor()
        {
            if (Parametros.intPerfilId == Parametros.intPerAdministrador || Parametros.intPerfilId == Parametros.intPerJefeAlmacen || Parametros.intPerfilId == Parametros.intPerHelpDesk || 
                Parametros.strUsuarioLogin.ToUpper()=="eesparta".ToUpper() || Parametros.strUsuarioLogin.ToUpper() == "jlquispe".ToUpper() || Parametros.strUsuarioLogin.ToUpper() == "cqueirolo".ToUpper())
            {
                chkActivo.Enabled = true;
                txtCodigoProveedor.Properties.ReadOnly = false;
            }
            else
            {
                chkActivo.Enabled = false;
                txtCodigoProveedor.Properties.ReadOnly = true;
            }
        }

        private void cboTipoProducto_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboTipoProducto.EditValue) == Parametros.intProductoServicio)
            {
                BSUtils.LoaderLook(cboSubTipoProducto, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblSubTipoProducto), "DescTablaElemento", "IdTablaElemento", true);
                cboSubTipoProducto.Visible = true;
                lblServicio.Visible = true;
            }
            else
            {
                cboSubTipoProducto.EditValue = 0;
                cboSubTipoProducto.Visible = false;
                lblServicio.Visible = false;
            }
        }

        private void txtCodigoModelo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if(e.KeyCode == Keys.Enter)
                {
                    ModeloProductoBE objE_Modelo = null;
                    objE_Modelo = new ModeloProductoBL().Selecciona(Parametros.intEmpresaId, Convert.ToInt32(txtCodigoModelo.EditValue));
                    if (objE_Modelo != null)
                    {
                        cboFamilia.EditValue = objE_Modelo.IdFamiliaProducto;
                        cboLinea.EditValue = objE_Modelo.IdLineaProducto;
                        cboSubLinea.EditValue = objE_Modelo.IdSubLineaProducto;
                        cboModelo.EditValue = objE_Modelo.IdModeloProducto;
                    }else
                    {
                        XtraMessageBox.Show("El Código de modelo no existe.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                throw;
            }

        }

        private void textEdit3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               txtMedidaIw.Focus();
            }
        }

        private void txtMedidaIw_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtMedidaIp.Focus();
            }
        }

        private void txtMedidaIp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtMedidaEh.Focus();
            }
        }

        private void txtMedidaEh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtMedidaEw.Focus();
            }
        }

        private void txtMedidaEw_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtMedidaEp.Focus();
            }
        }

        private void txtMedidaEp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               txtPesoNeto.Focus();
            }
        }

        private void txtPesoNeto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPesoBruto.Focus();
            }
        }

        private void txtPesoBruto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboFamilia.Focus();
            }
        }

        private void mnuContextual_Opening(object sender, CancelEventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                frmManProductosComponentes movDetalle = new frmManProductosComponentes();
                movDetalle.Boton = 1;

                if (movDetalle.ShowDialog() == DialogResult.OK)
                {
                    if (movDetalle.oBE != null)
                    {
                        if (mListaComponentes.Count == 0)
                        {
                            gvProductoComponentes.AddNewRow();
                            gvProductoComponentes.SetRowCellValue(gvProductoComponentes.FocusedRowHandle, "IdProductoComponente", movDetalle.oBE.IdProductoComponente);
                            gvProductoComponentes.SetRowCellValue(gvProductoComponentes.FocusedRowHandle, "IdProducto", IdProducto);
                            gvProductoComponentes.SetRowCellValue(gvProductoComponentes.FocusedRowHandle, "DescComponente", movDetalle.oBE.DescComponente);

                            gvProductoComponentes.SetRowCellValue(gvProductoComponentes.FocusedRowHandle, "IdMaterial", movDetalle.oBE.IdMaterial);
                            gvProductoComponentes.SetRowCellValue(gvProductoComponentes.FocusedRowHandle, "DescMaterial", movDetalle.oBE.DescMaterial);

                            gvProductoComponentes.SetRowCellValue(gvProductoComponentes.FocusedRowHandle, "IdColor", movDetalle.oBE.IdColor);
                            gvProductoComponentes.SetRowCellValue(gvProductoComponentes.FocusedRowHandle, "DescColor", movDetalle.oBE.DescColor);

                            gvProductoComponentes.SetRowCellValue(gvProductoComponentes.FocusedRowHandle, "cAncho", movDetalle.oBE.cAncho);
                            gvProductoComponentes.SetRowCellValue(gvProductoComponentes.FocusedRowHandle, "cLargo", movDetalle.oBE.cLargo);
                            gvProductoComponentes.SetRowCellValue(gvProductoComponentes.FocusedRowHandle, "cAlto", movDetalle.oBE.cAlto);
                            gvProductoComponentes.SetRowCellValue(gvProductoComponentes.FocusedRowHandle, "cProfundidad", movDetalle.oBE.cProfundidad);
                            gvProductoComponentes.SetRowCellValue(gvProductoComponentes.FocusedRowHandle, "Cantidad", movDetalle.oBE.Cantidad);

                            gvProductoComponentes.SetRowCellValue(gvProductoComponentes.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            gvProductoComponentes.UpdateCurrentRow();

                            return;
                        }
                        if (mListaComponentes.Count > 0)
                        {
                            gvProductoComponentes.AddNewRow();
                            gvProductoComponentes.SetRowCellValue(gvProductoComponentes.FocusedRowHandle, "IdProductoComponente", movDetalle.oBE.IdProductoComponente);
                            gvProductoComponentes.SetRowCellValue(gvProductoComponentes.FocusedRowHandle, "IdProducto", IdProducto);
                            gvProductoComponentes.SetRowCellValue(gvProductoComponentes.FocusedRowHandle, "DescComponente", movDetalle.oBE.DescComponente);

                            gvProductoComponentes.SetRowCellValue(gvProductoComponentes.FocusedRowHandle, "IdMaterial", movDetalle.oBE.IdMaterial);
                            gvProductoComponentes.SetRowCellValue(gvProductoComponentes.FocusedRowHandle, "DescMaterial", movDetalle.oBE.DescMaterial);

                            gvProductoComponentes.SetRowCellValue(gvProductoComponentes.FocusedRowHandle, "IdColor", movDetalle.oBE.IdColor);
                            gvProductoComponentes.SetRowCellValue(gvProductoComponentes.FocusedRowHandle, "DescColor", movDetalle.oBE.DescColor);

                            gvProductoComponentes.SetRowCellValue(gvProductoComponentes.FocusedRowHandle, "cAncho", movDetalle.oBE.cAncho);
                            gvProductoComponentes.SetRowCellValue(gvProductoComponentes.FocusedRowHandle, "cLargo", movDetalle.oBE.cLargo);
                            gvProductoComponentes.SetRowCellValue(gvProductoComponentes.FocusedRowHandle, "cAlto", movDetalle.oBE.cAlto);
                            gvProductoComponentes.SetRowCellValue(gvProductoComponentes.FocusedRowHandle, "cProfundidad", movDetalle.oBE.cProfundidad);
                            gvProductoComponentes.SetRowCellValue(gvProductoComponentes.FocusedRowHandle, "Cantidad", movDetalle.oBE.Cantidad);
                            gvProductoComponentes.SetRowCellValue(gvProductoComponentes.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            gvProductoComponentes.UpdateCurrentRow();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}