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
    public partial class frmManPromocionBulto : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<PromocionBultoBE> mLista = new List<PromocionBultoBE>();

        #endregion

        #region "Eventos"

        public frmManPromocionBulto()
        {
            InitializeComponent();
        }

        private void frmManPromocionBulto_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManPromocionBultoEdit objManPromocionBulto = new frmManPromocionBultoEdit();
                //objManPromocionBulto. = mLista;
                objManPromocionBulto.pOperacion = frmManPromocionBultoEdit.Operacion.Nuevo;
                objManPromocionBulto.IdPromocionBulto = 0;
                objManPromocionBulto.StartPosition = FormStartPosition.CenterParent;
                objManPromocionBulto.ShowDialog();
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
                        PromocionBultoBE objE_PromocionBulto = new PromocionBultoBE();
                        objE_PromocionBulto.IdPromocionBulto = int.Parse(gvPromocionBulto.GetFocusedRowCellValue("IdPromocionBulto").ToString());
                        objE_PromocionBulto.Usuario = Parametros.strUsuarioLogin;
                        objE_PromocionBulto.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_PromocionBulto.IdEmpresa = Parametros.intEmpresaId;

                        PromocionBultoBL objBL_PromocionBulto = new PromocionBultoBL();
                        objBL_PromocionBulto.Elimina(objE_PromocionBulto);
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

            //    List<ErpPanoramaServicios.ReportePromocionBultoBE> lstReporte = null;
            //    lstReporte = objServicio.ReportePromocionBulto_Listado(Parametros.intEmpresaId);

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptPromocionBulto = new RptVistaReportes();
            //            objRptPromocionBulto.VerRptPromocionBulto(lstReporte);
            //            objRptPromocionBulto.ShowDialog();
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
            string _fileName = "ListadoPromocionBulto";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvPromocionBulto.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvPromocionBulto_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void txtDescripcion_KeyUp(object sender, KeyEventArgs e)
        {
            CargarBusqueda();
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new PromocionBultoBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcPromocionBulto.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcPromocionBulto.DataSource = mLista.Where(obj =>
                                                   obj.DescFormaPago.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvPromocionBulto.RowCount > 0)
            {
                PromocionBultoBE objPromocionBulto = new PromocionBultoBE();
                objPromocionBulto.IdPromocionBulto = int.Parse(gvPromocionBulto.GetFocusedRowCellValue("IdPromocionBulto").ToString());
                objPromocionBulto.IdEmpresa = int.Parse(gvPromocionBulto.GetFocusedRowCellValue("IdEmpresa").ToString());
                objPromocionBulto.DescPromocionBulto = gvPromocionBulto.GetFocusedRowCellValue("DescPromocionBulto").ToString();
                objPromocionBulto.IdTipoCliente = int.Parse(gvPromocionBulto.GetFocusedRowCellValue("IdTipoCliente").ToString());
                objPromocionBulto.IdFormaPago = int.Parse(gvPromocionBulto.GetFocusedRowCellValue("IdFormaPago").ToString());
                objPromocionBulto.FechaInicio = DateTime.Parse(gvPromocionBulto.GetFocusedRowCellValue("FechaInicio").ToString());
                objPromocionBulto.FechaFin = DateTime.Parse(gvPromocionBulto.GetFocusedRowCellValue("FechaFin").ToString());
                objPromocionBulto.FlagEstado = Convert.ToBoolean(gvPromocionBulto.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManPromocionBultoEdit objManPromocionBultoEdit = new frmManPromocionBultoEdit();
                objManPromocionBultoEdit.pOperacion = frmManPromocionBultoEdit.Operacion.Modificar;
                objManPromocionBultoEdit.IdPromocionBulto = objPromocionBulto.IdPromocionBulto;
                objManPromocionBultoEdit.pPromocionBultoBE = objPromocionBulto;
                objManPromocionBultoEdit.StartPosition = FormStartPosition.CenterParent;
                objManPromocionBultoEdit.ShowDialog();

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

            if (gvPromocionBulto.GetFocusedRowCellValue("IdPromocionBulto").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione PromocionBulto", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion


    }
}