using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Modulos.Logistica.Registros;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.Logistica.Consultas
{
    public partial class frmConCajaVacia : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        
        private List<CajaVaciaBE> mLista = new List<CajaVaciaBE>();

        private int IdProducto = 0;
        
        #endregion

        #region "Eventos"

        public frmConCajaVacia()
        {
            InitializeComponent();
        }

        private void frmConCajaVacia_Load(object sender, EventArgs e)
        {

        }

        private void gvCajaVacia_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

       
        private void toolstpExportarExcel_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListaCajaVacia";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvCajaVacia.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
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

        private void txtCodigo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Cargar();   
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                frmBusProducto frm = new frmBusProducto();
                frm.pFlagMultiSelect = false;
                frm.ShowDialog();
                if (frm.pProductoBE != null)
                {
                    IdProducto = frm.pProductoBE.IdProducto;
                    txtCodigo.Text = frm.pProductoBE.CodigoProveedor;
                    txtNombreProducto.Text = frm.pProductoBE.NombreProducto;

                    Cargar(IdProducto);
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
            mLista = new CajaVaciaBL().ListaCodigo(Parametros.intEmpresaId,Parametros.intTiendaId , txtCodigo.Text.Trim());
            gcCajaVacia.DataSource = mLista;
        }

        private void Cargar(int IdProducto)
        {
            mLista = new CajaVaciaBL().ListaIdProducto(Parametros.intEmpresaId, IdProducto);
            gcCajaVacia.DataSource = mLista;
        }

        public void InicializarModificar()
        {
            if (gvCajaVacia.RowCount > 0)
            {
                CajaVaciaBE objCajaVacia = new CajaVaciaBE();
                objCajaVacia.IdCajaVacia = int.Parse(gvCajaVacia.GetFocusedRowCellValue("IdCajaVacia").ToString());

                frmRegCajaVaciaEdit objManCajaVaciaEdit = new frmRegCajaVaciaEdit();
                objManCajaVaciaEdit.pOperacion = frmRegCajaVaciaEdit.Operacion.Modificar;
                objManCajaVaciaEdit.IdCajaVacia = objCajaVacia.IdCajaVacia;
                objManCajaVaciaEdit.StartPosition = FormStartPosition.CenterParent;
                objManCajaVaciaEdit.ShowDialog();

                Cargar();
            }
            else
            {
                MessageBox.Show("No se pudo editar");
            }
        }

        private void FilaDoubleClick(GridView view, Point pt)
        {
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                InicializarModificar();
            }
        }

        #endregion

        private void txtCodigo_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}