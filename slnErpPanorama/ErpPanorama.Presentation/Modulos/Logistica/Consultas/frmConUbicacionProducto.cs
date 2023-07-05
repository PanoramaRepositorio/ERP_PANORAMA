using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Modulos.Logistica.Otros;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Funciones;

namespace ErpPanorama.Presentation.Modulos.Logistica.Consultas
{
    public partial class frmConUbicacionProducto : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<StockBE> mListaStock = new List<StockBE>();
        private List<BultoBE> mLista = new List<BultoBE>();
        private List<UbicacionProductoBE> mListaUbicacion = new List<UbicacionProductoBE>();
        private List<UbicacionProductoBE> mListaUbicacionProducto = new List<UbicacionProductoBE>();

        private int IdProducto = 0;
        
        #endregion

        #region "Eventos"

        public frmConUbicacionProducto()
        {
            InitializeComponent();
        }

        private void frmConUbicacionProducto_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 260;
            txtCodigo.Focus();
        }

        private void toolstpRefrescar_Click(object sender, EventArgs e)
        {
            CargarBusqueda();
        }

        private void toolstpSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCodigo_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    CargarBusqueda();

                
            //    //return;


            //    //ProductoBE objE_Producto = null;
            //    //objE_Producto = new ProductoBL().SeleccionaParteCodigo(Parametros.intEmpresaId, txtCodigo.Text.Trim());
            //    //if (objE_Producto != null)
            //    //{
            //    //    IdProducto = objE_Producto.IdProducto;
            //    //    txtCodigo.Text = objE_Producto.CodigoProveedor;
            //    //    txtNombreProducto.Text = objE_Producto.NombreProducto;

            //    //    Cargar();
            //    //    CalcularCantidadBultos();

            //    //    List<StockBE> lstStock = null;
            //    //    lstStock = new StockBL().ListaProducto(Parametros.intEmpresaId, Parametros.intTiendaId, Parametros.intAlmCentralUcayali, IdProducto);
            //    //    //if (lstStock.Count > 0)
            //    //    //{
            //    //    //    txtStockTotal.EditValue = lstStock[0].Cantidad;
            //    //    //}
            //    //    //else
            //    //    //{
            //    //    //    txtStockTotal.EditValue = 0;
            //    //    //}



            //    //    CargarUbicaciones();
            //    //    CargarStockAlmacenes(); 

            //    //    if (chkActivarFoto.Checked == true)
            //    //    {
            //    //        CargarFoto();
            //    //    }

            //    //}
            //    //else
            //    //{
            //    //    txtCantidadBultos.EditValue = 0;
            //    //    XtraMessageBox.Show("El código de producto no existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    //}
            //}
        }

        private void txtUbicacion_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarUbicacionesProductos(txtUbicacion.Text);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void gcUbicacion_DoubleClick(object sender, EventArgs e)
        {
            stbUbicacion.SelectedTabPage = this.xtraTabPage1;

            if (mListaUbicacionProducto.Count > 0)
            {
                string CodigoProveedor = "";
                CodigoProveedor = gvUbicacion.GetFocusedRowCellValue("CodigoProveedor").ToString();
                ProductoBE objE_Producto = null;
                objE_Producto = new ProductoBL().Selecciona(Parametros.intEmpresaId, Parametros.intTiendaId,CodigoProveedor);
                if (objE_Producto != null)
                {
                    IdProducto = objE_Producto.IdProducto;
                    txtCodigo.Text = objE_Producto.CodigoProveedor;
                    txtNombreProducto.Text = objE_Producto.NombreProducto;

                    Cargar();
                    CalcularCantidadBultos();

                    List<StockBE> lstStock = null;
                    lstStock = new StockBL().ListaProducto(Parametros.intEmpresaId, Parametros.intTiendaId, Parametros.intAlmCentralUcayali, IdProducto);
                    if (lstStock.Count > 0)
                    {
                        txtStockBultos.EditValue = lstStock[0].Cantidad;
                    }
                    else
                    {
                        txtStockBultos.EditValue = 0;
                    }

                    CargarUbicaciones();
                    CargarStockAlmacenes();//Add

                    if (chkActivarFoto.Checked == true)
                    {
                        CargarFoto();
                    }

                }
                else
                {
                    XtraMessageBox.Show("El código de producto no existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void mnuSelText_Click(object sender, EventArgs e)
        {
            stbUbicacion.SelectedTabPage = this.xtraTabPage1;//f5
            txtCodigo.Focus();
            txtCodigo.SelectAll();
        }

        private void mnuSelTextUbicacion_Click(object sender, EventArgs e)
        {
            stbUbicacion.SelectedTabPage = this.xtraTabPage2;//f6
            txtUbicacion.Focus();
            txtUbicacion.SelectAll();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F1) Buscar();
            if (keyData == Keys.F7) optCodigo.Checked = true;
            if (keyData == Keys.F8) optHangTag.Checked = true;

            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new BultoBL().ListaRecepcionados(Parametros.intEmpresaId, IdProducto);
            gcBulto.DataSource = mLista;
        }

        private void CargarUbicaciones()
        {
            mListaUbicacion = new UbicacionProductoBL().ListaCodigo(Parametros.intEmpresaId, 0,0, IdProducto);
            gcProducto.DataSource = mListaUbicacion;
        }

        private void CargarUbicacionesProductos(string DescUbicacion)
        {
            mListaUbicacionProducto = new UbicacionProductoBL().ListaUbicacion(Parametros.intEmpresaId, Parametros.intTiendaId, Parametros.intAlmCentralUcayali, DescUbicacion);
            gcUbicacion.DataSource = mListaUbicacionProducto;
        }

        private void CargarStockAlmacenes()
        {
            mListaStock = new StockBL().ListaProducto(Parametros.intEmpresaId, Parametros.intTiendaId, 0, Convert.ToInt32(IdProducto));
            gcStock.DataSource = mListaStock;
        }

        private void CargarFoto()
        {
            if (IdProducto > 0)
            {
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

        private void CalcularCantidadBultos()
        {
            if (mLista.Count > 0)
            {
                txtCantidadBultos.EditValue = mLista.Count;
                txtStockBultos.EditValue = 0;
                foreach (var item in mLista)
                {
                    txtStockBultos.EditValue = Convert.ToInt32(txtStockBultos.EditValue) + item.Cantidad;
                }
                
            }
            else
            {
                txtCantidadBultos.EditValue = 0;
                txtStockBultos.EditValue = 0;
            }
        }

        private void CargarBusqueda()
        {

            if (txtCodigo.Text.Length > 0)
            {
                if (optCodigo.Checked)
                {
                    #region "Buscar por Código"
                    
                    int Resultado = 0;
                    Resultado = new ProductoBL().SeleccionaBusquedaCount(txtCodigo.Text.Trim());

                    if (Resultado == 0)
                    {
                        XtraMessageBox.Show("El código de producto no existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtCodigo.SelectAll();
                        return;
                    }

                    if (Resultado == 1)
                    {
                        lblMensaje.Text = "";
                        ProductoBE objE_Producto = null;
                        objE_Producto = new ProductoBL().SeleccionaParteCodigo(Parametros.intEmpresaId, txtCodigo.Text.Trim());
                        if (objE_Producto != null)
                        {
                            IdProducto = objE_Producto.IdProducto;
                            txtCodigo.Text = objE_Producto.CodigoProveedor;
                            txtNombreProducto.Text = objE_Producto.NombreProducto;

                            Cargar();
                            CalcularCantidadBultos();

                            List<StockBE> lstStock = null;
                            lstStock = new StockBL().ListaProducto(Parametros.intEmpresaId, Parametros.intTiendaId, Parametros.intAlmCentralUcayali, IdProducto);

                            CargarUbicaciones();
                            CargarStockAlmacenes();

                            if (chkActivarFoto.Checked == true)
                            {
                                CargarFoto();
                            }

                        }
                        else
                        {
                            txtCantidadBultos.EditValue = 0;
                            XtraMessageBox.Show("El código de producto no existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        frmBusProducto objBusProducto = new frmBusProducto();
                        objBusProducto.pDescripcion = txtCodigo.Text.Trim();
                        objBusProducto.ShowDialog();
                        if (objBusProducto.pProductoBE != null)
                        {
                            IdProducto = objBusProducto.pProductoBE.IdProducto;
                            txtCodigo.Text = objBusProducto.pProductoBE.CodigoProveedor;
                            txtNombreProducto.Text = objBusProducto.pProductoBE.NombreProducto;

                            Cargar();
                            CalcularCantidadBultos();

                            List<StockBE> lstStock = null;
                            lstStock = new StockBL().ListaProducto(Parametros.intEmpresaId, Parametros.intTiendaId, Parametros.intAlmCentralUcayali, IdProducto);

                            CargarUbicaciones();
                            CargarStockAlmacenes();

                            if (chkActivarFoto.Checked == true)
                            {
                                CargarFoto();
                            }
                        }
                    }
                    #endregion
                }

                //HangTag
                if (optHangTag.Checked)
                {
                    lblMensaje.Text = "";
                    ProductoBE objE_Producto = null; //ADD
                    if (txtCodigo.Text.Trim().Length > 6)
                        objE_Producto = new ProductoBL().SeleccionaCodigoBarraInventario(txtCodigo.Text.Trim()); //Codigo de Barras de Importación
                    else
                        objE_Producto = new ProductoBL().SeleccionaIDTodos(Convert.ToInt32(txtCodigo.Text.Trim()));

                    if (objE_Producto != null)
                    {
                        IdProducto = objE_Producto.IdProducto;
                        txtCodigo.Text = objE_Producto.CodigoProveedor;
                        txtNombreProducto.Text = objE_Producto.NombreProducto;

                        Cargar();
                        CalcularCantidadBultos();

                        List<StockBE> lstStock = null;
                        lstStock = new StockBL().ListaProducto(Parametros.intEmpresaId, Parametros.intTiendaId, Parametros.intAlmCentralUcayali, IdProducto);
                        //if (lstStock.Count > 0)
                        //{
                        //    txtStockTotal.EditValue = lstStock[0].Cantidad;
                        //}
                        //else
                        //{
                        //    txtStockTotal.EditValue = 0;
                        //}

                        CargarUbicaciones();
                        CargarStockAlmacenes();

                        if (chkActivarFoto.Checked == true)
                        {
                            CargarFoto();
                        }
                        
                    }
                    else
                    {
                        txtCantidadBultos.EditValue = 0;
                        lblMensaje.Text = "El código de Barra no está registrado";
                        //XtraMessageBox.Show("El código de producto no existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }   

                }
                //txtNombreProducto.Select();
                txtCodigo.SelectAll();
            }
        }

        private void Buscar()
        {
            try
            {
                frmBusProducto frm = new frmBusProducto();
                frm.pFlagMultiSelect = false;
                frm.ShowDialog();
                if (frm.pProductoBE != null)
                {
                    lblMensaje.Text = "";
                    ProductoBE objE_Producto = null;
                    objE_Producto = new ProductoBL().SeleccionaIDTodos(/*Parametros.intEmpresaId,*/ frm.pProductoBE.IdProducto);
                    if (objE_Producto != null)
                    {
                        IdProducto = objE_Producto.IdProducto;
                        txtCodigo.Text = objE_Producto.CodigoProveedor;
                        txtNombreProducto.Text = objE_Producto.NombreProducto;

                        Cargar();
                        CalcularCantidadBultos();

                        List<StockBE> lstStock = null;
                        lstStock = new StockBL().ListaProducto(Parametros.intEmpresaId, Parametros.intTiendaId, Parametros.intAlmCentralUcayali, IdProducto);
                        //if (lstStock.Count > 0)
                        //{
                        //    txtStockTotal.EditValue = lstStock[0].Cantidad;
                        //}
                        //else
                        //{
                        //    txtStockTotal.EditValue = 0;
                        //}

                        CargarUbicaciones();
                        CargarStockAlmacenes();

                        if (chkActivarFoto.Checked == true)
                        {
                            CargarFoto();
                        }

                    }
                    else
                    {
                        txtCantidadBultos.EditValue = 0;
                        XtraMessageBox.Show("El código de producto no existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }  


                    //Original
                    /*IdProducto = frm.pProductoBE.IdProducto;
                    txtCodigo.Text = frm.pProductoBE.CodigoProveedor;
                    txtNombreProducto.Text = frm.pProductoBE.NombreProducto;
                    Cargar();
                    CalcularCantidadBultos();

                    List<StockBE> lstStock = null;
                    lstStock = new StockBL().ListaProducto(Parametros.intEmpresaId, Parametros.intTiendaId,Parametros.intAlmCentralUcayali, IdProducto);
                    if (lstStock.Count > 0)
                    {
                        txtStockBultos.EditValue = lstStock[0].Cantidad;
                    }
                    else
                    {
                        txtStockBultos.EditValue = 0;
                    }
                    
                    CargarUbicaciones();
                    CargarFoto();*/
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }        
        }



        #endregion

        private void chkActivarFoto_CheckedChanged(object sender, EventArgs e)
        {
            if (chkActivarFoto.Checked == true)
            {
                this.Size = new Size(1074, 550);
                CargarFoto();
            }
            else
            {
                this.Size = new Size(660, 550);
            }
        }

        private void exportarexcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoBultosUbicacion";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvBulto.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void transferirbultoanaquelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gvBulto.RowCount == 0)
            {
                XtraMessageBox.Show("No hay bultos a transferir", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            frmRegTrasferirAnaquel frm = new frmRegTrasferirAnaquel();
            frm.IdProducto = IdProducto;
            frm.IdBulto = int.Parse(gvBulto.GetRowCellValue(gvBulto.FocusedRowHandle, "IdBulto").ToString());
            frm.NumeroBulto = gvBulto.GetRowCellValue(gvBulto.FocusedRowHandle, "NumeroBulto").ToString();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            CargarBusqueda();
        }

        private void optHangTag_CheckedChanged(object sender, EventArgs e)
        {
            txtCodigo.Focus();
            txtCodigo.SelectAll();
        }

        private void optCodigo_CheckedChanged(object sender, EventArgs e)
        {
            txtCodigo.Focus();
            txtCodigo.SelectAll();
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarBusqueda();
            }
        }
    }
}