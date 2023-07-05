using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Security.Principal;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.Ventas.Consultas
{
    public partial class frmConBuscaProductos : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        DataTable dt = new DataTable();
        public int Segundos = 0;
        
        #endregion

        #region "Eventos"

        public frmConBuscaProductos()
        {
            InitializeComponent();
        }

        private void frmConBuscaProductos_Load(object sender, EventArgs e)
        {
            txtProducto.Focus();
        }

        private void txtProducto_EditValueChanged(object sender, EventArgs e)
        {
            if (Parametros.bBusquedaTimer)
            {
                timer1.Enabled = true;
                Segundos = 0;
            }
            else
            {
                if (optCodigo.Checked)
                {
                    if (txtProducto.Text.ToString().Length > 2)
                    {
                        Cargar();
                    }
                }
            }
           
        }

        private void txtProducto_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    if (optHangTag.Checked)
            //    {
            //        CargarIdProducto();
            //    }
            //}
        }

        private void toolstpExportarExcel_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoProducto";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvProducto.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void toolstpRefrescar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void toolstpSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gvProducto_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvProducto.RowCount > 0)
            {
                DataRow dr;
                dr = gvProducto.GetDataRow(e.FocusedRowHandle);
                int IdProducto = 0;
                IdProducto = int.Parse(dr["IdProducto"].ToString());

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

        private void gvProducto_RowClick(object sender, RowClickEventArgs e)
        {
            if (gvProducto.RowCount > 0)
            {
                DataRow dr;
                dr = gvProducto.GetDataRow(e.RowHandle);
                int IdProducto = 0;
                IdProducto = int.Parse(dr["IdProducto"].ToString());

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

        private void optHangTag_CheckedChanged(object sender, EventArgs e)
        {
            if (optHangTag.Checked)
            {
                txtProducto.SelectAll();
                txtProducto.Focus();
            }
        }

        private void optCodigo_CheckedChanged(object sender, EventArgs e)
        {
            if (optCodigo.Checked)
            {
                txtProducto.SelectAll();
                txtProducto.Focus();
            }
        }

        private void gvProducto_RowStyle(object sender, RowStyleEventArgs e)
        {
            try
            {
                object obj = gvProducto.GetRow(e.RowHandle);

                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    object objDocRetiro = View.GetRowCellValue(e.RowHandle, View.Columns["FlagEstado"]);
                    if (objDocRetiro != null)
                    {
                        bool FlagEstado = bool.Parse(objDocRetiro.ToString());
                        if (FlagEstado == false)
                        {
                            e.Appearance.BackColor = Color.Gray;
                            e.Appearance.BackColor2 = Color.SeaShell;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            if (txtProducto.Text.ToString().Length > 2)
            {
                dt = FuncionBase.ToDataTable(new ProductoBL().ListaConsulta(Parametros.intPanoraramaDistribuidores, Parametros.intTiendaUcayali, txtProducto.Text));
                gcProducto.DataSource = dt;
            }
        }

        private void CargarIdProducto()
        {
            
            dt = FuncionBase.ToDataTable(new ProductoBL().ListaConsultaIdProducto(Parametros.intPanoraramaDistribuidores, Parametros.intTiendaUcayali, Convert.ToInt32(txtProducto.Text)));
            gcProducto.DataSource = dt;

            if (gvProducto.RowCount > 0)
            {
                ProductoBE objE_Producto = null;
                int IdProducto = 0;
                IdProducto = int.Parse(gvProducto.GetFocusedRowCellValue("IdProducto").ToString());

                objE_Producto = new ProductoBL().SeleccionaImagen(Parametros.intIdPanoramaDistribuidores, IdProducto);

                if (objE_Producto.Imagen != null)
                {
                    this.picImage.Image = new FuncionBase().Bytes2Image((byte[])objE_Producto.Imagen);
                }
                else
                { this.picImage.Image = ErpPanorama.Presentation.Properties.Resources.noImage; }

                txtProducto.SelectAll();
                txtProducto.Focus();
            }
            
            
        }



        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            Segundos = Segundos + 1;

            if (Segundos > 5)
            {
                if (optCodigo.Checked)
                {
                    if (txtProducto.Text.ToString().Length > 3)
                    {
                        Cargar();
                        timer1.Enabled = false;
                    }
                }
            }

            if (Segundos > 10)
                timer1.Enabled = false;
        }

        private void txtProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (optHangTag.Checked)
                {
                    CargarIdProducto();
                }
            }
        }
    }
}