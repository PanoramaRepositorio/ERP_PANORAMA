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
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.Ventas.Maestros
{
    public partial class frmManLiquidacionProducto : DevExpress.XtraEditors.XtraForm
    {

        #region "Propiedades"

        public List<LiquidacionProductoBE> mLista = new List<LiquidacionProductoBE>();

        int IdModeloProducto = 0;

        #endregion

        #region "Eventos"

        public frmManLiquidacionProducto()
        {
            InitializeComponent();
        }

        private void frmManLiquidacionProducto_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboLineaProducto, new LineaProductoBL().ListaTodosActivo(Parametros.intEmpresaId), "DescLineaProducto", "IdLineaProducto", true);
        }

        private void cboLineaProducto_EditValueChanged(object sender, EventArgs e)
        {
            if (cboLineaProducto.EditValue != null)
            {
                BSUtils.LoaderLook(cboSubLineaProducto, new SubLineaProductoBL().ListaTodosActivo(Parametros.intEmpresaId, Convert.ToInt32(cboLineaProducto.EditValue)), "DescSubLineaProducto", "IdSubLineaProducto", true);
            }
        }

        private void cboSubLineaProducto_EditValueChanged(object sender, EventArgs e)
        {
            if (cboLineaProducto.EditValue != null)
            {
                BSUtils.LoaderLook(cboModeloProducto, new ModeloProductoBL().ListaTodosActivo(Parametros.intEmpresaId, Convert.ToInt32(cboLineaProducto.EditValue), Convert.ToInt32(cboSubLineaProducto.EditValue)), "DescModeloProducto", "IdModeloProducto", true);
            }
        }

        private void cboModeloProducto_EditValueChanged(object sender, EventArgs e)
        {
            IdModeloProducto = Convert.ToInt32(cboModeloProducto.EditValue);
            CargarModeloProducto();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                //if (!ValidarIngreso())
                //{
                    LiquidacionProductoBL objBL_LiquidacionProducto = new LiquidacionProductoBL();
                    List<LiquidacionProductoBE> lstLiquidacionProducto = new List<LiquidacionProductoBE>();

                    foreach (var item in mLista)
                    {
                        if (item.FlagEstado == true)
                        {
                            LiquidacionProductoBE objE_LiquidacionProducto = new LiquidacionProductoBE();
                            objE_LiquidacionProducto.IdLiquidacionProducto = item.IdLiquidacionProducto;
                            objE_LiquidacionProducto.IdProducto = item.IdProducto;
                            objE_LiquidacionProducto.Fecha = DateTime.Now;
                            objE_LiquidacionProducto.FlagEstado = item.FlagEstado;
                            lstLiquidacionProducto.Add(objE_LiquidacionProducto);                        
                        }
                    }
                    objBL_LiquidacionProducto.Inserta(lstLiquidacionProducto, IdModeloProducto);
                    
                    XtraMessageBox.Show("Datos Actualizados correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Cursor = Cursors.Default;
                //}
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

        private void toolstpExportarExcel_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoLiquidacionProducto";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvLiquidacionProducto.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void toolstpRefrescar_Click(object sender, EventArgs e)
        {
            //Cargar();
            CargarModeloProducto();
        }

        private void toolstpSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarBusqueda();
        }

        private void txtDescripcion_KeyUp(object sender, KeyEventArgs e)
        {
            CargarBusqueda();
        }

        private void btnTodos_Click(object sender, EventArgs e)
        {
            IdModeloProducto = 0;
            CargarModeloProducto();
        }

        private void activarselecciontoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gvLiquidacionProducto.SelectedRowsCount; i++)
                {
                    int row = gvLiquidacionProducto.GetSelectedRows()[i];
                    gvLiquidacionProducto.SetRowCellValue(row, "FlagEstado", true);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void desactivarselecciontoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gvLiquidacionProducto.SelectedRowsCount; i++)
                {
                    int row = gvLiquidacionProducto.GetSelectedRows()[i];
                    gvLiquidacionProducto.SetRowCellValue(row, "FlagEstado", false);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void activarselecciontodotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gvLiquidacionProducto.RowCount; i++)
                {
                    gvLiquidacionProducto.SetRowCellValue(i, "FlagEstado", true);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void desactivarselecciontodotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gvLiquidacionProducto.RowCount; i++)
                {
                    gvLiquidacionProducto.SetRowCellValue(i, "FlagEstado", false);
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
            mLista = new LiquidacionProductoBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcLiquidacionProducto.DataSource = mLista;
        }

        private void CargarModeloProducto()
        {

            mLista = new LiquidacionProductoBL().ListaModeloProducto(IdModeloProducto);
            gcLiquidacionProducto.DataSource = mLista;
            if(mLista != null)
            //lblRegistros.Text = mLista.Count().ToString() + " Registros encontrados";
             lblRegistros.Text = gvLiquidacionProducto.RowCount.ToString() + " Registros encontrados";
        }

        private void CargarBusqueda()
        {
            if(txtDescripcion.Text.Trim().Length >2)
            //gcLiquidacionProducto.DataSource = mLista.Where(obj => obj.CodigoProveedor.ToUpper().Contains(txtDescripcion.Text.ToUpper()) || obj.NombreProducto.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
            gcLiquidacionProducto.DataSource = mLista.Where(obj => obj.CodigoProveedor.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
            lblRegistros.Text = gvLiquidacionProducto.RowCount.ToString() + " Registros encontrados";
        }
        
        #endregion






    }
}