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
using ErpPanorama.Presentation.Modulos.Ventas.Otros;

namespace ErpPanorama.Presentation.Modulos.Creditos.Registros
{
    public partial class frmRegPagoServicio : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<PagoServicioBE> mLista = new List<PagoServicioBE>();

        #endregion

        #region "Eventos"

        public frmRegPagoServicio()
        {
            InitializeComponent();
        }

        private void frmRegPagoServicio_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            deDesde.EditValue = DateTime.Now;
            deHasta.EditValue = DateTime.Now;
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            //try
            //{
            //    frmRegPagoServicioEdit objManPagoServicio = new frmRegPagoServicioEdit();
            //    objManPagoServicio.pOperacion = frmRegPagoServicioEdit.Operacion.Nuevo;
            //    //objManPagoServicio.lstPagoServicio = mLista;
            //    objManPagoServicio.IdPagoServicio = 0;
            //    objManPagoServicio.StartPosition = FormStartPosition.CenterParent;
            //    objManPagoServicio.ShowDialog();
            //    Cargar();
            //}
            //catch (Exception ex)
            //{
            //    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
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
                        frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
                        frmAutoriza.StartPosition = FormStartPosition.CenterParent;
                        frmAutoriza.ShowDialog();

                        if (frmAutoriza.Edita)
                        {
                            if (frmAutoriza.Usuario == "etapia" || frmAutoriza.Usuario == "master" || frmAutoriza.Usuario == "mmurrugarra" || frmAutoriza.Usuario == "ygomez")
                            {
                                PagoServicioBE objE_PagoServicio = new PagoServicioBE();
                                objE_PagoServicio.IdPagoServicio = int.Parse(gvPagoServicio.GetFocusedRowCellValue("IdPagoServicio").ToString());
                                objE_PagoServicio.Usuario = Parametros.strUsuarioLogin;
                                objE_PagoServicio.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                                objE_PagoServicio.IdEmpresa = Parametros.intEmpresaId;

                                PagoServicioBL objBL_PagoServicio = new PagoServicioBL();
                                objBL_PagoServicio.Elimina(objE_PagoServicio);
                                XtraMessageBox.Show("El registro se eliminó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Cargar();
                            }
                            else
                            {
                                XtraMessageBox.Show("Ud. no esta autorizado para realizar esta operación", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
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

            //    if (gvPagoServicio.RowCount > 0)
            //    {
            //        int IdPagoServicio = 0;
            //        IdPagoServicio = int.Parse(gvPagoServicio.GetFocusedRowCellValue("IdPagoServicio").ToString());

            //        List<ReportePagoServicioBE> lstReporte = null;
            //        lstReporte = new ReportePagoServicioBL().Listado(Parametros.intEmpresaId, IdPagoServicio);

            //        if (lstReporte != null)
            //        {
            //            //Listar el datalle del reporte
            //            if (lstReporte.Count > 0)
            //            {
            //                RptVistaReportes objRptAccUsu = new RptVistaReportes();
            //                objRptAccUsu.VerRptPagoServicio(lstReporte, lstReporte);
            //                objRptAccUsu.ShowDialog();
            //            }
            //            else
            //                XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        }
            //        Cursor = Cursors.Default;
            //    }
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
            string _fileName = "ListadoPagoServicios";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvPagoServicio.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvPagoServicio_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Cargar();
        }


        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new PagoServicioBL().ListaFecha(Parametros.intEmpresaId, deDesde.DateTime, deHasta.DateTime);
            gcPagoServicio.DataSource = mLista;
        }


        public void InicializarModificar()
        {
            //if (gvPagoServicio.RowCount > 0)
            //{
            //    bool flagEnviado = true;
            //    flagEnviado = bool.Parse(gvPagoServicio.GetFocusedRowCellValue("FlagEnviado").ToString());
            //    if (flagEnviado)
            //    {
            //        XtraMessageBox.Show("No se puede modificar la solicitud ya fué enviada almacén de anaqueles", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);

            //        PagoServicioBE objPagoServicio = new PagoServicioBE();
            //        objPagoServicio.IdPagoServicio = int.Parse(gvPagoServicio.GetFocusedRowCellValue("IdPagoServicio").ToString());

            //        frmRegPagoServicioEdit objManPagoServiciolEdit = new frmRegPagoServicioEdit();
            //        objManPagoServiciolEdit.pOperacion = frmRegPagoServicioEdit.Operacion.Modificar;
            //        objManPagoServiciolEdit.IdPagoServicio = objPagoServicio.IdPagoServicio;
            //        objManPagoServiciolEdit.StartPosition = FormStartPosition.CenterParent;
            //        objManPagoServiciolEdit.btnGrabar.Enabled = false;
            //        objManPagoServiciolEdit.ShowDialog();

            //        Cargar();
            //    }
            //    else
            //    {
            //        PagoServicioBE objPagoServicio = new PagoServicioBE();
            //        objPagoServicio.IdPagoServicio = int.Parse(gvPagoServicio.GetFocusedRowCellValue("IdPagoServicio").ToString());

            //        frmRegPagoServicioEdit objManPagoServiciolEdit = new frmRegPagoServicioEdit();
            //        objManPagoServiciolEdit.pOperacion = frmRegPagoServicioEdit.Operacion.Modificar;
            //        objManPagoServiciolEdit.IdPagoServicio = objPagoServicio.IdPagoServicio;
            //        objManPagoServiciolEdit.StartPosition = FormStartPosition.CenterParent;
            //        objManPagoServiciolEdit.btnGrabar.Enabled = true;
            //        objManPagoServiciolEdit.ShowDialog();

            //        Cargar();
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("No se pudo editar");
            //}
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

            if (gvPagoServicio.GetFocusedRowCellValue("IdPagoServicio").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione un Registro", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion



    }
}