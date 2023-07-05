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

namespace ErpPanorama.Presentation.Modulos.Ventas.Maestros
{
    public partial class frmManMetaTiendaMes : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<MetaTiendaMesBE> mLista = new List<MetaTiendaMesBE>();

        #endregion

        #region "Eventos"

        public frmManMetaTiendaMes()
        {
            InitializeComponent();
        }

        private void frmManMetaTiendaMes_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManMetaTiendaMesEdit objManMetaTiendaMes = new frmManMetaTiendaMesEdit();
                objManMetaTiendaMes.lstMetaTiendaMes = mLista;
                objManMetaTiendaMes.pOperacion = frmManMetaTiendaMesEdit.Operacion.Nuevo;
                objManMetaTiendaMes.IdMetaTiendaMes = 0;
                objManMetaTiendaMes.StartPosition = FormStartPosition.CenterParent;
                objManMetaTiendaMes.ShowDialog();
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
            XtraMessageBox.Show("Esto debe ser eliminado por el personal de Sistemas.\nSolicitar mediante correo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //try
            //{
            //    Cursor = Cursors.WaitCursor;
            //    if (XtraMessageBox.Show("Esta seguro de eliminar el registro?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //    {
            //        if (!ValidarIngreso())
            //        {
            //            MetaTiendaMesBE objE_MetaTiendaMes = new MetaTiendaMesBE();
            //            objE_MetaTiendaMes.IdMetaTiendaMes = int.Parse(gvMetaTiendaMes.GetFocusedRowCellValue("IdMetaTiendaMes").ToString());
            //            objE_MetaTiendaMes.Usuario = Parametros.strUsuarioLogin;
            //            objE_MetaTiendaMes.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
            //            objE_MetaTiendaMes.IdEmpresa = Parametros.intEmpresaId;

            //            MetaTiendaMesBL objBL_MetaTiendaMes = new MetaTiendaMesBL();
            //            objBL_MetaTiendaMes.Elimina(objE_MetaTiendaMes);
            //            XtraMessageBox.Show("El registro se eliminó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            Cargar();
            //        }
            //    }
            //    Cursor = Cursors.Default;
            //}
            //catch (Exception ex)
            //{
            //    Cursor = Cursors.Default;
            //    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
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

            //    List<ReporteMetaTiendaMesBE> lstReporte = null;
            //    lstReporte = new ReporteMetaTiendaMesBL().Listado(Parametros.intEmpresaId);

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptMetaTiendaMes = new RptVistaReportes();
            //            objRptMetaTiendaMes.VerRptMetaTiendaMes(lstReporte);
            //            objRptMetaTiendaMes.ShowDialog();
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
            string _fileName = "ListadoMetaTiendaMes";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvMetaTiendaMes2.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvMetaTiendaMes_DoubleClick(object sender, EventArgs e)
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
            mLista = new MetaTiendaMesBL().ListaTodosActivoHorizontal(Parametros.intEmpresaId, Parametros.intPeriodo);
            gcMetaTiendaMes2.DataSource = mLista;

            //mLista = new MetaTiendaMesBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intPeriodo);
            //gcMetaTiendaMes.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcMetaTiendaMes.DataSource = mLista.Where(obj => obj.DescTienda.ToUpper().Contains(txtDescripcion.Text.ToUpper()) || obj.DescTipoCliente.ToUpper().Contains(txtDescripcion.Text.ToUpper()));
        }

        public void InicializarModificar()
        {
            if (gvMetaTiendaMes.RowCount > 0)
            {
                MetaTiendaMesBE objMetaTiendaMes = new MetaTiendaMesBE();
                objMetaTiendaMes.IdMetaTiendaMes = int.Parse(gvMetaTiendaMes.GetFocusedRowCellValue("IdMetaTiendaMes").ToString());

                frmManMetaTiendaMesEdit objManMetaTiendaMesEdit = new frmManMetaTiendaMesEdit();
                objManMetaTiendaMesEdit.pOperacion = frmManMetaTiendaMesEdit.Operacion.Modificar;
                objManMetaTiendaMesEdit.IdMetaTiendaMes = objMetaTiendaMes.IdMetaTiendaMes;
                objManMetaTiendaMesEdit.StartPosition = FormStartPosition.CenterParent;
                objManMetaTiendaMesEdit.ShowDialog();

                Cargar();
            }
            else
            {
                MessageBox.Show("No se pudo editar");
            }
        }


        public void InicializarModificar2()
        {
            if (gvMetaTiendaMes2.RowCount > 0)
            {
                string NombreMes = gvMetaTiendaMes2.FocusedColumn.Caption.ToString();
                int IdTienda = int.Parse(gvMetaTiendaMes2.GetFocusedRowCellValue("IdTienda").ToString());
                int IdTipoCliente = int.Parse(gvMetaTiendaMes2.GetFocusedRowCellValue("IdTipoCliente").ToString());
                int Periodo = int.Parse(gvMetaTiendaMes2.GetFocusedRowCellValue("Periodo").ToString());
                int Mes = 0;

                #region "Mes"
                
                switch (NombreMes)
                {
                    case "Enero":
                        Mes = 1;
                        break;
                    case "Febrero":
                        Mes = 2;
                        break;
                    case "Marzo":
                        Mes = 3;
                        break;
                    case "Abril":
                        Mes = 4;
                        break;
                    case "Mayo":
                        Mes = 5;
                        break;
                    case "Junio":
                        Mes = 6;
                        break;
                    case "Julio":
                        Mes = 7;
                        break;
                    case "Agosto":
                        Mes = 8;
                        break;
                    case "Setiembre":
                        Mes = 9;
                        break;
                    case "Octubre":
                        Mes = 10;
                        break;
                    case "noviembre":
                        Mes = 11;
                        break;
                    case "Diciembre":
                        Mes = 12;
                        break;
                    default:
                        Mes = 0;
                        break;
                }
                #endregion


                MetaTiendaMesBE ojbE_Meta = null;
                ojbE_Meta = new MetaTiendaMesBL().SeleccionaTiendaTipoCliente(IdTienda, IdTipoCliente, Periodo, Mes);

                if (ojbE_Meta != null)
                {
                    MetaTiendaMesBE objMetaTiendaMes = new MetaTiendaMesBE();
                    objMetaTiendaMes.IdMetaTiendaMes = ojbE_Meta.IdMetaTiendaMes; //int.Parse(gvMetaTiendaMes.GetFocusedRowCellValue("IdMetaTiendaMes").ToString());

                    frmManMetaTiendaMesEdit objManMetaTiendaMesEdit = new frmManMetaTiendaMesEdit();
                    objManMetaTiendaMesEdit.pOperacion = frmManMetaTiendaMesEdit.Operacion.Modificar;
                    objManMetaTiendaMesEdit.IdMetaTiendaMes = objMetaTiendaMes.IdMetaTiendaMes;
                    objManMetaTiendaMesEdit.StartPosition = FormStartPosition.CenterParent;
                    objManMetaTiendaMesEdit.ShowDialog();

                    Cargar();
                }
                else
                {
                    frmManMetaTiendaMesEdit objManMetaTiendaMes = new frmManMetaTiendaMesEdit();
                    objManMetaTiendaMes.lstMetaTiendaMes = mLista;
                    objManMetaTiendaMes.pOperacion = frmManMetaTiendaMesEdit.Operacion.Nuevo;
                    objManMetaTiendaMes.IdMetaTiendaMes = 0;
                    objManMetaTiendaMes.Periodo = Periodo;
                    objManMetaTiendaMes.Mes = Mes;
                    objManMetaTiendaMes.IdTienda = IdTienda;
                    objManMetaTiendaMes.IdTipoCliente = IdTipoCliente;
                    objManMetaTiendaMes.StartPosition = FormStartPosition.CenterParent;
                    objManMetaTiendaMes.ShowDialog();
                    Cargar();
                }

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
        private void FilaDoubleClick2(GridView view, Point pt)
        {
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                InicializarModificar2();
            }
        }


        private bool ValidarIngreso()
        {
            bool flag = false;

            if (gvMetaTiendaMes.GetFocusedRowCellValue("IdMetaTiendaMes").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione Registro", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

        private void gvMetaTiendaMes2_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick2(view, pt);
        }
    }
}