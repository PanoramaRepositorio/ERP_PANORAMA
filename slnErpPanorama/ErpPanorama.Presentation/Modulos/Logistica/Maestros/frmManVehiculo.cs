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
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.Logistica.Maestros
{
    public partial class frmManVehiculo : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"


        private List<VehiculoBE> mLista = new List<VehiculoBE>();

        #endregion

        #region "Eventos"

        public frmManVehiculo()
        {
            InitializeComponent();
        }

        private void frmManVehiculo_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManVehiculoEdit objManVehiculo = new frmManVehiculoEdit();
                objManVehiculo.lstVehiculo = mLista;
                objManVehiculo.pOperacion = frmManVehiculoEdit.Operacion.Nuevo;
                objManVehiculo.IdVehiculo = 0;
                objManVehiculo.StartPosition = FormStartPosition.CenterParent;
                objManVehiculo.ShowDialog();
                Cargar();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tlbMenu_EditClick()
        {
            InicializarModificar();
        }

        private void tlbMenu_DeleteClick()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (XtraMessageBox.Show("Esta seguro de eliminar el registro?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (!ValidarIngreso())
                    {
                        VehiculoBE objE_Vehiculo = new VehiculoBE();
                        objE_Vehiculo.IdVehiculo = int.Parse(gvVehiculo.GetFocusedRowCellValue("IdVehiculo").ToString());
                        objE_Vehiculo.Usuario = Parametros.strUsuarioLogin;
                        objE_Vehiculo.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Vehiculo.IdEmpresa = Parametros.intEmpresaId;

                        VehiculoBL objBL_Vehiculo = new VehiculoBL();
                        objBL_Vehiculo.Elimina(objE_Vehiculo);
                        XtraMessageBox.Show("El registro se eliminó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Cargar();
                    }
                }
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tlbMenu_RefreshClick()
        {
            Cargar();
        }

        private void tlbMenu_PrintClick()
        {
            //try
            //{
            //    Cursor = Cursors.WaitCursor;

            //    List<ReporteVehiculoBE> lstReporte = null;
            //    lstReporte = new ReporteVehiculoBL().Listado(Parametros.intEmpresaId, Parametros.intTiendaId, Parametros.intAlmBultos);

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptVehiculo = new RptVistaReportes();
            //            objRptVehiculo.VerRptVehiculo(lstReporte);
            //            objRptVehiculo.ShowDialog();
            //        }
            //        else
            //            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }
            //    Cursor = Cursors.Default;
            //}
            //catch (Exception ex)
            //{
            //    Cursor = Cursors.Default;
            //    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void tlbMenu_ExportClick()
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoVehiculoes";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvVehiculo.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvVehiculo_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void txtDescripcion_KeyUp(object sender, KeyEventArgs e)
        {
            CargarBusqueda();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarBusqueda();
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new VehiculoBL().ListaTodosActivo(0);
            gcVehiculo.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcVehiculo.DataSource = mLista.Where(obj =>
                                                   obj.Marca.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvVehiculo.RowCount > 0)
            {
                VehiculoBE objVehiculo = new VehiculoBE();
                objVehiculo.IdVehiculo = int.Parse(gvVehiculo.GetFocusedRowCellValue("IdVehiculo").ToString());
                objVehiculo.IdEmpresa = int.Parse(gvVehiculo.GetFocusedRowCellValue("IdEmpresa").ToString());
                objVehiculo.Placa = gvVehiculo.GetFocusedRowCellValue("Placa").ToString();
                objVehiculo.NumeroSerie = gvVehiculo.GetFocusedRowCellValue("NumeroSerie").ToString();
                objVehiculo.NumeroMotor = gvVehiculo.GetFocusedRowCellValue("NumeroMotor").ToString();
                objVehiculo.Color = gvVehiculo.GetFocusedRowCellValue("Color").ToString();
                objVehiculo.Marca = gvVehiculo.GetFocusedRowCellValue("Marca").ToString();
                objVehiculo.Modelo = gvVehiculo.GetFocusedRowCellValue("Modelo").ToString();
                objVehiculo.Codigo = gvVehiculo.GetFocusedRowCellValue("Codigo").ToString();
                objVehiculo.Periodo = int.Parse(gvVehiculo.GetFocusedRowCellValue("Periodo").ToString());
                objVehiculo.IdConductor = int.Parse(gvVehiculo.GetFocusedRowCellValue("IdConductor").ToString());
                objVehiculo.DescConductor = gvVehiculo.GetFocusedRowCellValue("DescConductor").ToString();
                objVehiculo.Observacion = gvVehiculo.GetFocusedRowCellValue("Observacion").ToString();
                //objVehiculo.FlagEstado = Convert.ToBoolean(gvVehiculo.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManVehiculoEdit objManVehiculoEdit = new frmManVehiculoEdit();
                objManVehiculoEdit.pOperacion = frmManVehiculoEdit.Operacion.Modificar;
                objManVehiculoEdit.IdVehiculo = objVehiculo.IdVehiculo;
                objManVehiculoEdit.pVehiculoBE = objVehiculo;
                objManVehiculoEdit.StartPosition = FormStartPosition.CenterParent;
                objManVehiculoEdit.ShowDialog();

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

        private bool ValidarIngreso()
        {
            bool flag = false;

            if (gvVehiculo.GetFocusedRowCellValue("IdVehiculo").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Vehiculo", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion
    }
}