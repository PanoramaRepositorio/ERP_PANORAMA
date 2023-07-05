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

namespace ErpPanorama.Presentation.Modulos.MesaAyuda.Registros
{
    public partial class frmRegTicket : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<TicketBE> mLista = new List<TicketBE>();

        #endregion

        #region "Eventos"

        public frmRegTicket()
        {
            InitializeComponent();
        }

        private void frmRegTicket_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            deDesde.EditValue = DateTime.Now;
            deHasta.EditValue = DateTime.Now;

            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmRegTicketEdit objManTicket = new frmRegTicketEdit();
                objManTicket.lstTicket = mLista;
                objManTicket.pOperacion = frmRegTicketEdit.Operacion.Nuevo;
                objManTicket.IdTicket = 0;
                objManTicket.StartPosition = FormStartPosition.CenterParent;
                objManTicket.ShowDialog();
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
                if (Parametros.strUsuarioLogin == "master" || Parametros.strUsuarioLogin == "jsanchez" || Parametros.strUsuarioLogin == "gsanchez" || Parametros.strUsuarioLogin == "jmontenegro" || Parametros.strUsuarioLogin == "fbustamante")
                { 
                  if (XtraMessageBox.Show("Esta seguro de eliminar el registro?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (!ValidarIngreso())
                    {
                        TicketBE objE_Ticket = new TicketBE();
                        objE_Ticket.IdTicket = int.Parse(gvTicket.GetFocusedRowCellValue("IdTicket").ToString());
                        objE_Ticket.Usuario = Parametros.strUsuarioLogin;
                        objE_Ticket.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Ticket.IdEmpresa = Parametros.intEmpresaId;

                        TicketBL objBL_Ticket = new TicketBL();
                        objBL_Ticket.Elimina(objE_Ticket);
                        XtraMessageBox.Show("El registro se eliminó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Cargar();
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

            //    List<ReporteTicketBE> lstReporte = null;
            //    lstReporte = new ReporteTicketBL().Listado(Parametros.intEmpresaId);

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptTicket = new RptVistaReportes();
            //            objRptTicket.VerRptTicket(lstReporte);
            //            objRptTicket.ShowDialog();
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
            string _fileName = "ListadoTicktes";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvTicket.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvTicket_DoubleClick(object sender, EventArgs e)
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

        private void gcTicket_Click(object sender, EventArgs e)
        {

        }

        private void txtNumero_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarBusquedaNumero();
            }
        }

        private void gvTicket_RowStyle(object sender, RowStyleEventArgs e)
        {
            try
            {
                object obj = gvTicket.GetRow(e.RowHandle);

                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    object objDocRetiro = View.GetRowCellValue(e.RowHandle, View.Columns["IdEstado"]);
                    if (objDocRetiro != null)
                    {
                        int IdTipoDocumento = int.Parse(objDocRetiro.ToString());
                        if (IdTipoDocumento == 189)
                        {
                            e.Appearance.BackColor = Color.LightGoldenrodYellow;
                            e.Appearance.BackColor2 = Color.SeaShell;
                        }

                        if (IdTipoDocumento == 190)
                        {
                            e.Appearance.BackColor = Color.Orange;
                            e.Appearance.BackColor2 = Color.SeaShell;
                        }

                        if (IdTipoDocumento == 191)
                        {
                            e.Appearance.BackColor = Color.Green;
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
            mLista = new TicketBL().ListaFecha(Parametros.intEmpresaId,deDesde.DateTime, deHasta.DateTime);
            gcTicket.DataSource = mLista;
            lblTotalRegistros.Text = mLista.Count().ToString() + " Registros Encontrados";
        }

        private void CargarBusquedaNumero()
        {
            if (txtNumero.Text.Length > 0)
            { 
                mLista = new TicketBL().ListaNumero(Parametros.intPeriodo, txtNumero.Text.Trim());
                gcTicket.DataSource = mLista;
                lblTotalRegistros.Text = mLista.Count().ToString() + " Registros Encontrados";
            }
            
        }

        private void CargarBusqueda()
        {
            //gcTicket.DataSource = mLista.Where(obj =>
            //                                       obj.DescTicket.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvTicket.RowCount > 0)
            {
                TicketBE objTicket = new TicketBE();
                objTicket.IdTicket = int.Parse(gvTicket.GetFocusedRowCellValue("IdTicket").ToString());
                objTicket.Fecha = DateTime.Parse(gvTicket.GetFocusedRowCellValue("Fecha").ToString());
                objTicket.Numero = gvTicket.GetFocusedRowCellValue("Numero").ToString();
                objTicket.IdSolicitante = int.Parse(gvTicket.GetFocusedRowCellValue("IdSolicitante").ToString());
                objTicket.Requerimiento = gvTicket.GetFocusedRowCellValue("Requerimiento").ToString();
                objTicket.IdResponsable = int.Parse(gvTicket.GetFocusedRowCellValue("IdResponsable").ToString());
                //if (gvTicket.GetFocusedRowCellValue("FechaCierre").ToString().Length == 0)
                //    objTicket.FechaCierre = null;
                //else
                //    objTicket.FechaCierre = DateTime.Parse(gvTicket.GetFocusedRowCellValue("FechaCierre").ToString());
                objTicket.IdPrioridad = int.Parse(gvTicket.GetFocusedRowCellValue("IdPrioridad").ToString());
                objTicket.IdEstado = int.Parse(gvTicket.GetFocusedRowCellValue("IdEstado").ToString());
                objTicket.FlagEstado = Convert.ToBoolean(gvTicket.GetFocusedRowCellValue("FlagEstado").ToString());

                frmRegTicketEdit objManTicketEdit = new frmRegTicketEdit();
                objManTicketEdit.pOperacion = frmRegTicketEdit.Operacion.Modificar;
                objManTicketEdit.IdTicket = objTicket.IdTicket;
                objManTicketEdit.pTicketBE = objTicket;
                objManTicketEdit.StartPosition = FormStartPosition.CenterParent;
                objManTicketEdit.ShowDialog();

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

            if (gvTicket.GetFocusedRowCellValue("IdTicket").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione Ticket", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

    }
}