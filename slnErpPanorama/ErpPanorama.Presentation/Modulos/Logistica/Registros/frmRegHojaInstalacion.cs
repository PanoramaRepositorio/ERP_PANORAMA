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
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.Logistica.Registros
{
    public partial class frmRegHojaInstalacion : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"


        private List<HojaInstalacionBE> mLista = new List<HojaInstalacionBE>();

        #endregion

        #region "Eventos"

        public frmRegHojaInstalacion()
        {
            InitializeComponent();
        }

        private void frmRegHojaInstalacion_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            tlbMenu.Ensamblado = this.Tag.ToString();
            deDesde.EditValue = DateTime.Now;
            deHasta.EditValue = DateTime.Now.AddDays(15);
 
            Cargar();
            BloquearPerfil();

        }


        private void tlbMenu_NewClick()
        {
            try
            {
                frmRegHojaInstalacionEdit objManHojaInstalacion = new frmRegHojaInstalacionEdit();
                objManHojaInstalacion.lstHojaInstalacion = mLista;
                objManHojaInstalacion.pOperacion = frmRegHojaInstalacionEdit.Operacion.Nuevo;
                objManHojaInstalacion.IdHojaInstalacion = 0;
                objManHojaInstalacion.StartPosition = FormStartPosition.CenterParent;
                objManHojaInstalacion.ShowDialog();
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
                        HojaInstalacionBE objE_HojaInstalacion = new HojaInstalacionBE();
                        objE_HojaInstalacion.IdHojaInstalacion = int.Parse(gvHojaInstalacion.GetFocusedRowCellValue("IdHojaInstalacion").ToString());
                        objE_HojaInstalacion.Usuario = Parametros.strUsuarioLogin;
                        objE_HojaInstalacion.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_HojaInstalacion.IdEmpresa = Parametros.intEmpresaId;

                        HojaInstalacionBL objBL_HojaInstalacion = new HojaInstalacionBL();
                        objBL_HojaInstalacion.Elimina(objE_HojaInstalacion);
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
            try
            {
                Cursor = Cursors.WaitCursor;

                List<ReporteHojaInstalacionBE> lstReporte = null;
                lstReporte = new ReporteHojaInstalacionBL().Listado(Convert.ToDateTime(deDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deHasta.DateTime.ToShortDateString()));

                if (lstReporte != null)
                {
                    if (lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptHojaInstalacion = new RptVistaReportes();
                        objRptHojaInstalacion.VerRptHojaInstalacion(lstReporte, deDesde.DateTime.ToShortDateString(), deHasta.DateTime.ToShortDateString());
                        objRptHojaInstalacion.ShowDialog();
                    }
                    else
                        XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tlbMenu_ExportClick()
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoHojaInstalaciones";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvHojaInstalacion.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvHojaInstalacion_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void txtDescripcion_KeyUp(object sender, KeyEventArgs e)
        {
            CargarBusqueda();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void reservardiatoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gvHojaInstalacion.RowCount > 0)
            {
                int IdTurno = 0;
                int IdHojaInstalacion = int.Parse(gvHojaInstalacion.GetFocusedRowCellValue("IdHojaInstalacion").ToString());
                int IdCliente = int.Parse(gvHojaInstalacion.GetFocusedRowCellValue("IdCliente").ToString());
                string Direccion = gvHojaInstalacion.GetFocusedRowCellValue("Direccion").ToString();
                string Referencia = gvHojaInstalacion.GetFocusedRowCellValue("Referencia").ToString();
                string Observacion = gvHojaInstalacion.GetFocusedRowCellValue("Observacion").ToString();
                string IdUbigeo = gvHojaInstalacion.GetFocusedRowCellValue("IdUbigeo").ToString();
                IdTurno = int.Parse(gvHojaInstalacion.GetFocusedRowCellValue("IdTurno").ToString());
                DateTime Fecha = DateTime.Parse(gvHojaInstalacion.GetFocusedRowCellValue("Fecha").ToString());

                if (IdTurno == Parametros.intTurnoManana)
                    IdTurno = Parametros.intTurnoTarde;
                else
                    IdTurno = Parametros.intTurnoManana;

                HojaInstalacionBE objE_Hoja = null;
                objE_Hoja = new HojaInstalacionBL().SeleccionaFechaTurno(IdTurno, Fecha);

                if (objE_Hoja != null)
                {
                    XtraMessageBox.Show("El Turno " + objE_Hoja.DescTurno + " Para el " + objE_Hoja.Fecha + " está reservado para el Cliente " + objE_Hoja.DescCliente + "\nSi Ud. Desea reservar todo el día, primero debe eliminar la reserva y luego aplicar esta opción.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    HojaInstalacionBL objBL_HojaInstalacion = new HojaInstalacionBL();
                    HojaInstalacionBE objHojaInstalacion = new HojaInstalacionBE();
                    //objHojaInstalacion.IdAlmacen = Convert.ToInt32(cboAlmacen.EditValue);
                    objHojaInstalacion.IdHojaInstalacion = IdHojaInstalacion;
                    objHojaInstalacion.Fecha = Fecha;
                    objHojaInstalacion.IdTurno = IdTurno;
                    objHojaInstalacion.IdCliente = IdCliente;
                    objHojaInstalacion.IdUbigeo = IdUbigeo;
                    objHojaInstalacion.Direccion = Direccion;
                    objHojaInstalacion.Referencia = Referencia;
                    objHojaInstalacion.Observacion = Observacion;
                    objHojaInstalacion.FlagReserva = true;
                    objHojaInstalacion.FlagEstado = true;
                    objHojaInstalacion.Usuario = Parametros.strUsuarioLogin;
                    objHojaInstalacion.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objHojaInstalacion.IdEmpresa = Parametros.intEmpresaId;

                    //DescuentoClientePromocion Detalle
                    List<HojaInstalacionDetalleBE> lstHojaInstalacionDetalle = new List<HojaInstalacionDetalleBE>();
                    objBL_HojaInstalacion.Inserta(objHojaInstalacion, lstHojaInstalacionDetalle);

                    XtraMessageBox.Show("La Operación se realizó con exito", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Cargar();
                }
            }


        }
        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new HojaInstalacionBL().ListaTodosActivo(Parametros.intEmpresaId, Convert.ToDateTime(deDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deHasta.DateTime.ToShortDateString()));
            gcHojaInstalacion.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            //gcHojaInstalacion.DataSource = mLista.Where(obj =>
            //                                       obj.Fecha.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvHojaInstalacion.RowCount > 0)
            {
                HojaInstalacionBE objHojaInstalacion = new HojaInstalacionBE();
                //objHojaInstalacion.IdTienda = int.Parse(gvHojaInstalacion.GetFocusedRowCellValue("IdTienda").ToString());
                //objHojaInstalacion.IdAlmacen = int.Parse(gvHojaInstalacion.GetFocusedRowCellValue("IdAlmacen").ToString());
                objHojaInstalacion.IdHojaInstalacion = int.Parse(gvHojaInstalacion.GetFocusedRowCellValue("IdHojaInstalacion").ToString());
                //objHojaInstalacion.DescHojaInstalacion = gvHojaInstalacion.GetFocusedRowCellValue("DescHojaInstalacion").ToString();
                //objHojaInstalacion.FlagEstado = Convert.ToBoolean(gvHojaInstalacion.GetFocusedRowCellValue("FlagEstado").ToString());

                frmRegHojaInstalacionEdit objManHojaInstalacionEdit = new frmRegHojaInstalacionEdit();
                objManHojaInstalacionEdit.pOperacion = frmRegHojaInstalacionEdit.Operacion.Modificar;
                objManHojaInstalacionEdit.IdHojaInstalacion = objHojaInstalacion.IdHojaInstalacion;
                objManHojaInstalacionEdit.pHojaInstalacionBE = objHojaInstalacion;
                objManHojaInstalacionEdit.StartPosition = FormStartPosition.CenterParent;
                objManHojaInstalacionEdit.ShowDialog();

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

            if (gvHojaInstalacion.GetFocusedRowCellValue("IdHojaInstalacion").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una HojaInstalacion", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        private void BloquearPerfil()
        {
            if (Parametros.intPerfilId == Parametros.intPerJefeAlmacen || Parametros.intPerfilId == Parametros.intPerAsistenteAlmacen || Parametros.intPerfilId == Parametros.intPerAdministrador)
            {
                gcHojaInstalacion.ContextMenuStrip = mnuContextual;
            }
            else
            {
                gcHojaInstalacion.ContextMenuStrip = null;
            }
        }


        #endregion

        private void mnuContextual_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}