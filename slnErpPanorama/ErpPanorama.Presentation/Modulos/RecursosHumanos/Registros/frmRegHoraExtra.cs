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
using ErpPanorama.Presentation.Modulos.RecursosHumanos.Otros;
using ErpPanorama.Presentation.Utils;

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
            gridColumn16.Caption = "Total S/\nHx%";
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
            BSUtils.LoaderLook(cboCompensados, CargarComboTodosSiNo(), "Descripcion", "Id", false);
            BSUtils.LoaderLook(cboAprobado, CargarComboTodosSiNo(), "Descripcion", "Id", false);
            //deFechaDesde.EditValue = DateTime.Now;
            deFechaDesde.EditValue = Convert.ToDateTime("01/" + DateTime.Now.Month + "/" + DateTime.Now.Year);
            deFechaHasta.EditValue = DateTime.Now;
            cboCompensados.EditValue = -1;
            cboAprobado.EditValue = -1;
            Cargar();

            if (Parametros.intPerfilId == Parametros.intPerAdministrador || Parametros.intPerfilId == Parametros.intPerJefeRRHH || Parametros.intPerfilId == Parametros.intPerAsistenteRRHH)
            {
                gcHoraExtra.ContextMenuStrip = mnuContextual;
            }
            else
            {
                gcHoraExtra.ContextMenuStrip = null;
                gvHoraExtra.Columns.Remove(gvHoraExtra.Columns["Importe"]);
                gvHoraExtra.Columns.Remove(gvHoraExtra.Columns["Total25"]);
                gvHoraExtra.Columns.Remove(gvHoraExtra.Columns["Total35"]);
                gvHoraExtra.Columns.Remove(gvHoraExtra.Columns["SueldoHora"]);
                //gvHoraExtra.Columns["Importe"].Visible = false;
                //gvHoraExtra.Columns["Total25"].Visible = false;
                //gvHoraExtra.Columns["Total35"].Visible = false;
                //gvHoraExtra.Columns["Total100"].Visible = false;
                //gvHoraExtra.Columns["SueldoHora"].Visible = false;
            }
            
        }
        private DataTable CargarComboTodosSiNo()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", Type.GetType("System.Int32"));
            dt.Columns.Add("Descripcion", Type.GetType("System.String"));

            DataRow dr;
            dr = dt.NewRow();
            dr["Id"] = -1;
            dr["Descripcion"] = "--TODOS--";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Id"] = 1;
            dr["Descripcion"] = "SI";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Id"] = 0;
            dr["Descripcion"] = "NO";
            dt.Rows.Add(dr);
            return dt;
        }
        private bool SINO(int intValor)
        {
            return intValor == 1 ? true : false;
        }
        private void tlbMenu_NewClick()
        {
            try
            {
                if (Parametros.intPerfilId == Parametros.intPerAdministrador || Parametros.intPerfilId == Parametros.intPerJefeRRHH ||
                    Parametros.intPerfilId == Parametros.intPerAsistenteRRHH || Parametros.intPerfilId == Parametros.intPerAdministradorTienda ||
                     Parametros.intPerfilId == Parametros.intPerJefeAlmacen || Parametros.intPerfilId == Parametros.intPerJefeCanalMayorista || 
                     Parametros.intPerfilId == Parametros.intPerJefeMarketingPublicidad || Parametros.intPerfilId == Parametros.intPerJefeVisual ||
                     Parametros.intPerfilId == Parametros.intPerSupervisorDiseno)
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

        private void gvHoraExtra_RowStyle(object sender, RowStyleEventArgs e)
        {
            try
            {
                object obj = gvHoraExtra.GetRow(e.RowHandle);

                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    object objIdSituacion = View.GetRowCellValue(e.RowHandle, View.Columns["IdSituacion"]);
                    object objFlagAprobado = View.GetRowCellValue(e.RowHandle, View.Columns["FlagAprobado"]);
                    if (objIdSituacion != null)
                    {
                        bool FlagAprobado = objFlagAprobado == null ? false : Convert.ToBoolean(objFlagAprobado);

                        int IdSituacion = int.Parse(objIdSituacion.ToString());
                        if (IdSituacion == Parametros.intHEAprobado || FlagAprobado == true)
                        {
                            e.Appearance.BackColor = Color.LightBlue;
                            e.Appearance.BackColor2 = Color.SeaShell;
                        }
                        else if (IdSituacion == Parametros.intHERechazado)
                        {
                            e.Appearance.BackColor = Color.OrangeRed;
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
            //Validación Remuneracion
            int IdPersona = Convert.ToInt32(gvHoraExtra.GetFocusedRowCellValue("IdPersona").ToString());
            decimal Sueldo = new PersonaBL().Selecciona(Parametros.intEmpresaId, IdPersona).Sueldo;
            if (Sueldo.ToString() == "0.00")
            {
                XtraMessageBox.Show("No se ha registrado la remuneración para el Personal.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
            frmAutoriza.StartPosition = FormStartPosition.CenterParent;
            frmAutoriza.ShowDialog();

            if (frmAutoriza.Edita)
            {
                int nPeriodo = Convert.ToInt32(DateTime.Parse(gvHoraExtra.GetFocusedRowCellValue("FechaDesde").ToString()).Year);
                int nMes = Convert.ToInt32(DateTime.Parse(gvHoraExtra.GetFocusedRowCellValue("FechaDesde").ToString()).Month);

                frmPeriodoPlanilla frm2 = new frmPeriodoPlanilla();
                frm2.intPeriodo = nPeriodo;
                frm2.intMes = nMes;
                frm2.StartPosition = FormStartPosition.CenterParent;
                frm2.ShowDialog();
                if (frm2.DialogResult == DialogResult.OK)
                {
                    HoraExtraBL objBL_HoraExtra = new HoraExtraBL();
                    HoraExtraBE objE_HoraExtra = new HoraExtraBE();
                    objE_HoraExtra.IdHoraExtra = int.Parse(gvHoraExtra.GetFocusedRowCellValue("IdHoraExtra").ToString());
                    objE_HoraExtra.UsuarioAprobado = frmAutoriza.Usuario;
                    objE_HoraExtra.FlagAprobado = true;
                    objE_HoraExtra.IdSituacion = Parametros.intHEAprobado;
                    objE_HoraExtra.PeriodoPlanilla = frm2.intPeriodo;
                    objE_HoraExtra.MesPlanilla = frm2.intMes;
                    objE_HoraExtra.Usuario = Parametros.strUsuarioLogin;
                    objE_HoraExtra.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objE_HoraExtra.IdEmpresa = Parametros.intEmpresaId;

                    objBL_HoraExtra.CalcularTotalPagar(objE_HoraExtra.IdHoraExtra, Parametros.intPorcentajeAsigFamiliar);
                    objBL_HoraExtra.ActualizaAprobado(objE_HoraExtra);

                    int intFoco = gvHoraExtra.FocusedRowHandle;
                    Cargar();
                    gvHoraExtra.FocusedRowHandle = intFoco;
                }
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
                objE_HoraExtra.IdSituacion = Parametros.intHEGenerado;
                objE_HoraExtra.Usuario = Parametros.strUsuarioLogin;
                objE_HoraExtra.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                objE_HoraExtra.IdEmpresa = Parametros.intEmpresaId;

                objBL_HoraExtra.ActualizaAprobado(objE_HoraExtra);
                XtraMessageBox.Show("Datos actualizados correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                int intFoco = gvHoraExtra.FocusedRowHandle;
                Cargar();
                gvHoraExtra.FocusedRowHandle = intFoco;
            }
            else
            {
                XtraMessageBox.Show("No se puede desaprobar, la hora extra ya fue cobrada.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            int IdTienda = Parametros.intTiendaId;
            if (Parametros.intPerfilId == Parametros.intPerAdministrador || Parametros.intPerfilId == Parametros.intPerJefeRRHH || Parametros.intPerfilId == Parametros.intPerAsistenteRRHH || Parametros.intPerfilId == Parametros.intPerAuditorCajaDespacho)
                IdTienda = 0;
            mLista = new HoraExtraBL().ListaFecha(IdTienda, Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()));

            int intCompensados = Convert.ToInt32(cboCompensados.EditValue);
            int intAutorizados = Convert.ToInt32(cboAprobado.EditValue);
            string stDescripcion =  txtDescripcion.Text.Trim();
            if (intCompensados != -1) {   mLista = mLista.Where(x => x.FlagCompensacion == SINO(intCompensados)).ToList();  }
            if (intAutorizados != -1) {   mLista = mLista.Where(x => x.FlagAprobado     == SINO(intAutorizados)).ToList();  }
            if (stDescripcion.Count() > 2) {     mLista = mLista.Where(x => x.ApeNom.ToUpper().Contains(stDescripcion.ToUpper())).ToList();     }

            gcHoraExtra.DataSource = mLista;
        }

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
                    //frmRegHoraExtraLiteEdit objManHoraExtraEdit = new frmRegHoraExtraLiteEdit();
                    frmRegHoraExtraEdit objManHoraExtraEdit = new frmRegHoraExtraEdit();
                    objManHoraExtraEdit.pOperacion = frmRegHoraExtraEdit.Operacion.Modificar;
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

        private void rechazartoolStripMenuItem_Click(object sender, EventArgs e)
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
                objE_HoraExtra.IdSituacion = Parametros.intHERechazado;
                objE_HoraExtra.Usuario = Parametros.strUsuarioLogin;
                objE_HoraExtra.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                objE_HoraExtra.IdEmpresa = Parametros.intEmpresaId;

                objBL_HoraExtra.ActualizaAprobado(objE_HoraExtra);

                XtraMessageBox.Show("Datos actualizados correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                int intFoco = gvHoraExtra.FocusedRowHandle;
                Cargar();
                gvHoraExtra.FocusedRowHandle = intFoco;
            }
            else
            {
                XtraMessageBox.Show("No se puede desaprobar, la hora extra ya fue cobrada.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tlbMenu_Load(object sender, EventArgs e)
        {

        }

        private void cboCompensados_EditValueChanged(object sender, EventArgs e)
        {
            this.Cargar();
        }

        private void cboAutorizados_EditValueChanged(object sender, EventArgs e)
        {
            this.Cargar();
        }

        private void txtDescripcion_EditValueChanged(object sender, EventArgs e)
        {
            this.Cargar();
        }
    }
}