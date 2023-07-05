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
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.RecursosHumanos.Registros
{
    public partial class frmRegHoraExtra : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<HoraExtraBE> mLista = new List<HoraExtraBE>();

        #endregion

        #region "Eventos"

        public frmRegHoraExtra()
        {
            InitializeComponent();
            gridColumn1.Caption = "Apellidos y\nNombres";
            gridColumn3.Caption = "Fecha\nInicio";
            gridColumn4.Caption = "Hora Inicio\nPlanificado";
            gridColumn6.Caption = "Hora Fin\nPlanificado";

            gridColumn7.Caption = "Ingreso\nClocking";
            gridColumn8.Caption = "Salida\nClocking";
            gridColumn12.Caption = "Total Horas\nTrabajadas";

            gridColumn13.Caption = "Total Horas\nContabilizadas";
            gridColumn14.Caption = "Sueldo\nBruto";
            gridColumn15.Caption = "Sueldo\nPor Hora";
            gridColumn16.Caption = "Total S/\n+35xH%";
            gridColumn18.Caption = "Fecha\nSalida";

            gridColumn19.Caption = "Caja\nMovimiento";
            gridColumn20.Caption = "Fecha\nMovimiento";
            gridColumn24.Caption = "Fecha\nCompensación";
            gridColumn25.Caption = "Código\nH.Extra";


        }

        private void frmRegHoraExtra_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            tlbMenu.Ensamblado = this.Tag.ToString();
            //deFechaDesde.EditValue = DateTime.Now;
            deFechaDesde.EditValue = Convert.ToDateTime("01/" + DateTime.Now.Month + "/" + DateTime.Now.Year);
            deFechaHasta.EditValue = DateTime.Now;
            Cargar();

            if (Parametros.intPerfilId == Parametros.intPerAdministrador || Parametros.intPerfilId == Parametros.intPerJefeRRHH || Parametros.intPerfilId == Parametros.intPerAsistenteRRHH)
            {
                gcHoraExtra.ContextMenuStrip = mnuContextual;
            }
            else
            {
                gcHoraExtra.ContextMenuStrip = null;
                gvHoraExtra.Columns["Importe"].Visible = false;
                gvHoraExtra.Columns["SueldoHora"].Visible = false;
            }
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                if (Parametros.intPerfilId == Parametros.intPerAdministrador || Parametros.intPerfilId == Parametros.intPerJefeRRHH || Parametros.intPerfilId == Parametros.intPerAsistenteRRHH)
                {
                    frmRegHoraExtraEdit objManHoraExtra = new frmRegHoraExtraEdit();
                    objManHoraExtra.lstHoraExtra = mLista;
                    objManHoraExtra.pOperacion = frmRegHoraExtraEdit.Operacion.Nuevo;
                    objManHoraExtra.IdHoraExtra = 0;
                    objManHoraExtra.StartPosition = FormStartPosition.CenterParent;
                    objManHoraExtra.ShowDialog();
                    Cargar();
                }
                else
                {
                    frmRegHoraExtraLiteEdit objManHoraExtra = new frmRegHoraExtraLiteEdit();
                    objManHoraExtra.lstHoraExtra = mLista;
                    objManHoraExtra.pOperacion = frmRegHoraExtraLiteEdit.Operacion.Nuevo;
                    objManHoraExtra.IdHoraExtra = 0;
                    objManHoraExtra.StartPosition = FormStartPosition.CenterParent;
                    objManHoraExtra.ShowDialog();
                    Cargar();
                }

                
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
                        string Caja = gvHoraExtra.GetFocusedRowCellValue("DescCaja").ToString();
                        if (Caja == "")
                        {
                            HoraExtraBE objE_HoraExtra = new HoraExtraBE();
                            objE_HoraExtra.IdHoraExtra = int.Parse(gvHoraExtra.GetFocusedRowCellValue("IdHoraExtra").ToString());
                            objE_HoraExtra.Usuario = Parametros.strUsuarioLogin;
                            objE_HoraExtra.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                            objE_HoraExtra.IdEmpresa = Parametros.intEmpresaId;

                            HoraExtraBL objBL_HoraExtra = new HoraExtraBL();
                            objBL_HoraExtra.Elimina(objE_HoraExtra);
                            XtraMessageBox.Show("El registro se eliminó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Cargar();
                        }
                        else
                        {
                            XtraMessageBox.Show("No se puede eliminar una hora extra cobrada.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            //   List<ReporteHoraExtraBE> lstReporte = null;
            //   lstReporte = new ReporteHoraExtraBL().Listado(Parametros.intEmpresaId,Parametros.intSoles);

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptHoraExtra = new RptVistaReportes();
            //            objRptHoraExtra.VerRptHoraExtra(lstReporte);
            //            objRptHoraExtra.ShowDialog();
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
            string _fileName = "ListadoHoraExtra";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvHoraExtra.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvHoraExtra_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void txtApeNom_EditValueChanged(object sender, EventArgs e)
        {
            //CargarBusqueda();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Cargar();
        }


        #endregion

        #region "Metodos"

        private void Cargar()
        {
            int IdTienda = Parametros.intTiendaId;
            if (Parametros.intPerfilId == Parametros.intPerAdministrador || Parametros.intPerfilId == Parametros.intPerJefeRRHH || Parametros.intPerfilId == Parametros.intPerAsistenteRRHH || Parametros.intPerfilId == Parametros.intPerAuditorCajaDespacho)
                IdTienda = 0;
            mLista = new HoraExtraBL().ListaFecha(IdTienda, Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()));
            gcHoraExtra.DataSource = mLista;
        }

        //private void CargarBusqueda()
        //{
        //    gcHoraExtra.DataSource = mLista.Where(obj =>
        //                                           obj.ApeNom.ToUpper().Contains(txtApeNom.Text.ToUpper())).ToList();
        //}

        public void InicializarModificar()
        {
            if (gvHoraExtra.RowCount > 0)
            {
                bool Bloqueado = false;
                bool Aprobado = false;
                Aprobado = bool.Parse(gvHoraExtra.GetFocusedRowCellValue("FlagAprobado").ToString());
                string Caja = gvHoraExtra.GetFocusedRowCellValue("DescCaja").ToString();
                if (Caja != "" || Aprobado==true)
                {
                    Bloqueado = true;
                }

                HoraExtraBE objHoraExtra = new HoraExtraBE();
                objHoraExtra.IdHoraExtra = int.Parse(gvHoraExtra.GetFocusedRowCellValue("IdHoraExtra").ToString());

                if (Parametros.intPerfilId == Parametros.intPerAdministrador || Parametros.intPerfilId == Parametros.intPerJefeRRHH || Parametros.intPerfilId == Parametros.intPerAsistenteRRHH)
                {
                    frmRegHoraExtraEdit objManHoraExtraEdit = new frmRegHoraExtraEdit();
                    objManHoraExtraEdit.pOperacion = frmRegHoraExtraEdit.Operacion.Modificar;
                    objManHoraExtraEdit.IdHoraExtra = objHoraExtra.IdHoraExtra;
                    objManHoraExtraEdit.bFlagBloqueado = Bloqueado;
                    objManHoraExtraEdit.StartPosition = FormStartPosition.CenterParent;
                    objManHoraExtraEdit.ShowDialog();
                    if (objManHoraExtraEdit.DialogResult == DialogResult.OK)
                    {
                        int intFoco = gvHoraExtra.FocusedRowHandle;
                        Cargar();
                        gvHoraExtra.FocusedRowHandle = intFoco;
                    }

                }
                else
                {
                    frmRegHoraExtraLiteEdit objManHoraExtraEdit = new frmRegHoraExtraLiteEdit();
                    objManHoraExtraEdit.pOperacion = frmRegHoraExtraLiteEdit.Operacion.Modificar;
                    objManHoraExtraEdit.IdHoraExtra = objHoraExtra.IdHoraExtra;
                    objManHoraExtraEdit.bFlagBloqueado = Bloqueado;
                    objManHoraExtraEdit.StartPosition = FormStartPosition.CenterParent;
                    
                    if (objManHoraExtraEdit.ShowDialog() == DialogResult.OK)
                    {
                        int intFoco = gvHoraExtra.FocusedRowHandle;
                        Cargar();
                        gvHoraExtra.FocusedRowHandle = intFoco;
                    }
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

        private bool ValidarIngreso()
        {
            bool flag = false;

            if (gvHoraExtra.GetFocusedRowCellValue("IdHoraExtra").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una HoraExtra", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        private void FiltrarColumnas()
        {
            if (Parametros.intPerfilId == Parametros.intPerAdministrador || Parametros.intPerfilId == Parametros.intPerJefeRRHH)
            {
                //UsuarioBE ObjE_Usuario = null;
                //ObjE_Usuario = new UsuarioBL().Selecciona(Parametros.intUsuarioId);

                //if (ObjE_Usuario != null)
                //{
                //    if (ObjE_Usuario.IdPerfil == 12)
                //    {
                //        gvHoraExtra.Columns["idcc"].OptionsColumn.AllowEdit = false;
                //        gvHoraExtra.Columns["idcc"].OptionsColumn.AllowFocus = false;

                //        gvHoraExtra.Columns["idcc"].OptionsColumn.AllowEdit = false;
                //        gvHoraExtra.Columns["idcc"].OptionsColumn.AllowFocus = false;

                //        gvHoraExtra.Columns["idcc"].OptionsColumn.AllowEdit = false;
                //        gvHoraExtra.Columns["idcc"].OptionsColumn.AllowFocus = false;

                //    }
                //}
            }
        }

        #endregion

        private void gvHoraExtra_RowStyle(object sender, RowStyleEventArgs e)
        {
            try
            {
                object obj = gvHoraExtra.GetRow(e.RowHandle);

                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    object objDocRetiro = View.GetRowCellValue(e.RowHandle, View.Columns["FlagAprobado"]);
                    if (objDocRetiro != null)
                    {
                        bool IdTipoDocumento = bool.Parse(objDocRetiro.ToString());
                        if (IdTipoDocumento == true)
                        {
                            e.Appearance.BackColor = Color.LightBlue;
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

        private void aprobartoolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
            frmAutoriza.StartPosition = FormStartPosition.CenterParent;
            frmAutoriza.ShowDialog();

            if (frmAutoriza.Edita)
            {
                HoraExtraBL objBL_HoraExtra = new HoraExtraBL();
                HoraExtraBE objE_HoraExtra = new HoraExtraBE();
                objE_HoraExtra.IdHoraExtra = int.Parse(gvHoraExtra.GetFocusedRowCellValue("IdHoraExtra").ToString());
                objE_HoraExtra.UsuarioAprobado = frmAutoriza.Usuario;
                objE_HoraExtra.FlagAprobado = true;
                objE_HoraExtra.Usuario = Parametros.strUsuarioLogin;
                objE_HoraExtra.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                objE_HoraExtra.IdEmpresa = Parametros.intEmpresaId;

                objBL_HoraExtra.ActualizaAprobado(objE_HoraExtra);

                int intFoco = gvHoraExtra.FocusedRowHandle;
                Cargar();
                gvHoraExtra.FocusedRowHandle = intFoco;
            }
        }



        private void desaprobartoolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool Aprobado = false;
            Aprobado = bool.Parse(gvHoraExtra.GetFocusedRowCellValue("FlagAprobado").ToString());
            string Caja = gvHoraExtra.GetFocusedRowCellValue("DescCaja").ToString();
            if (Caja == "")
            {
                HoraExtraBL objBL_HoraExtra = new HoraExtraBL();

                HoraExtraBE objE_HoraExtra = new HoraExtraBE();
                objE_HoraExtra.IdHoraExtra = int.Parse(gvHoraExtra.GetFocusedRowCellValue("IdHoraExtra").ToString());

                objE_HoraExtra.FlagAprobado = false;
                objE_HoraExtra.Usuario = Parametros.strUsuarioLogin;
                objE_HoraExtra.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                objE_HoraExtra.IdEmpresa = Parametros.intEmpresaId;

                objBL_HoraExtra.ActualizaAprobado(objE_HoraExtra);

                int intFoco = gvHoraExtra.FocusedRowHandle;
                Cargar();
                gvHoraExtra.FocusedRowHandle = intFoco;
            }
            else
            {
                XtraMessageBox.Show("No se puede desaprobar, la hora extra ya fue cobrada.",this.Text,MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void tlbMenu_Load(object sender, EventArgs e)
        {

        }
    }
}