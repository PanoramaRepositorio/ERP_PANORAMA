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
using ErpPanorama.Presentation.Modulos.RecursosHumanos.Otros;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
//using Microsoft.Office.Interop.Excel;

namespace ErpPanorama.Presentation.Modulos.RecursosHumanos.Registros
{
    public partial class frmRegHorarioPersona : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        List<HorarioPersonaBE> mListaPersona = new List<HorarioPersonaBE>();
        List<HorarioPersonaBE> mListaDetalle = new List<HorarioPersonaBE>();
        private int IdPersona = 0;

        #endregion
        #region "Eventos"
        public frmRegHorarioPersona()
        {
            InitializeComponent();
        }

        private void frmRegHorarioPersona_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            tlbMenu.Ensamblado = this.Tag.ToString();
            deDesde.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            deHasta.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1).AddDays(-1);

            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            //XtraMessageBox.Show("Menú No disponible para este formulario!\nUd. debe utilizar editar, para asignar la malla de horarios", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);

            try
            {
                frmRegHorarioPersonaEdit objManHorarioPersona = new frmRegHorarioPersonaEdit();
                //objManHorarioPersona.lstHorarioPersona = mLista;
                objManHorarioPersona.pOperacion = frmRegHorarioPersonaEdit.Operacion.Nuevo;
                objManHorarioPersona.IdPersona = 0;
                objManHorarioPersona.StartPosition = FormStartPosition.CenterParent;
                objManHorarioPersona.ShowDialog();
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
            XtraMessageBox.Show("No se puede Eliminar\nConsulte con su Administrador.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);


            //try
            //{
            //    Cursor = Cursors.WaitCursor;
            //    if (XtraMessageBox.Show("Esta seguro de eliminar el registro?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //    {
            //        if (!ValidarIngreso())
            //        {
            //            HorarioPersonaBE objE_HorarioPersona = new HorarioPersonaBE();
            //            objE_HorarioPersona.IdPersona = int.Parse(gvHorarioPersona.GetFocusedRowCellValue("IdPersona").ToString());
            //            objE_HorarioPersona.Usuario = Parametros.strUsuarioLogin;
            //            objE_HorarioPersona.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
            //            objE_HorarioPersona.IdEmpresa = Parametros.intEmpresaId;

            //            HorarioPersonaBL objBL_HorarioPersona = new HorarioPersonaBL();
            //            objBL_HorarioPersona.Elimina(objE_HorarioPersona);
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
            try
            {
                Cursor = Cursors.WaitCursor;

                List<ReporteHorarioPersonaBE> lstReporte = null;
                lstReporte = new ReporteHorarioPersonaBL().Listado(Convert.ToDateTime(deDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deHasta.DateTime.ToShortDateString()),IdPersona, 0);

                if (lstReporte != null)
                {
                    if (lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptHorarioPersona = new RptVistaReportes();
                        objRptHorarioPersona.VerRptHorarioPersona(lstReporte, deDesde.DateTime.ToShortDateString(), deHasta.DateTime.ToShortDateString() );
                        objRptHorarioPersona.ShowDialog();
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
            string _fileName = "ListadoHorarioPersona";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvHorarioPersona.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvHorarioPersona_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //Cargar();
            CargarDetalle();
        }

        private void gvHorarioPersona_Click(object sender, EventArgs e)
        {
            IdPersona = Int32.Parse(gvHorarioPersona.GetFocusedRowCellValue("IdPersona").ToString());

        }
        #endregion
        #region "Métodos"
        private void Cargar()
        {
            mListaPersona = new HorarioPersonaBL().ListaHorasFecha(Parametros.intEmpresaId, deDesde.DateTime, deHasta.DateTime);
            gcHorarioPersona.DataSource = mListaPersona;
        }

        private void CargarDetalle()
        {
            mListaDetalle = new HorarioPersonaBL().ListaFecha(Parametros.intEmpresaId, IdPersona, deDesde.DateTime, deHasta.DateTime);
            gcHorarioPersonaDetalle.DataSource = mListaDetalle;
        }

        public void InicializarModificar()
        {
            if (gvHorarioPersona.RowCount > 0)
            {
                HorarioPersonaBE objHorarioPersona = new HorarioPersonaBE();
                objHorarioPersona.IdPersona = int.Parse(gvHorarioPersona.GetFocusedRowCellValue("IdPersona").ToString());
                objHorarioPersona.ApeNom = gvHorarioPersona.GetFocusedRowCellValue("ApeNom").ToString();

                frmRegHorarioPersonaEdit objManHorarioPersonaEdit = new frmRegHorarioPersonaEdit();
                objManHorarioPersonaEdit.pOperacion = frmRegHorarioPersonaEdit.Operacion.Modificar;
                objManHorarioPersonaEdit.IdPersona = objHorarioPersona.IdPersona;
                objManHorarioPersonaEdit.ApeNom = objHorarioPersona.ApeNom;
                objManHorarioPersonaEdit.StartPosition = FormStartPosition.CenterParent;
                objManHorarioPersonaEdit.ShowDialog();

                //int Id = gvHorarioPersona.FocusedRowHandle;
                //Cargar();
                //gvHorarioPersona.FocusedRowHandle = Id;
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

            if (gvHorarioPersona.GetFocusedRowCellValue("IdPersona").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione un Personal", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }



        #endregion

        private void bloquearhorariotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (mListaPersona.Count > 0)
                {
                    frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
                    frmAutoriza.StartPosition = FormStartPosition.CenterParent;
                    frmAutoriza.ShowDialog();

                    if (frmAutoriza.Edita)
                    {
                        HorarioPersonaBL objBL_HorarioPersona = new HorarioPersonaBL();
                        string sApeNom = gvHorarioPersona.GetFocusedRowCellValue("ApeNom").ToString();
                        int IdPersona2 = int.Parse(gvHorarioPersona.GetFocusedRowCellValue("IdPersona").ToString());

                        if (frmAutoriza.Usuario == "master" || frmAutoriza.Usuario == "ltapia" || frmAutoriza.IdPerfil == Parametros.intPerJefeRRHH)
                        {
                            frmBloquearHorario frmB = new frmBloquearHorario();
                            frmB.sApeNom = sApeNom;
                            frmB.sMensaje = "Bloquear";

                            if (frmB.ShowDialog() == DialogResult.OK)
                            {
                                if (frmB.bTodos) IdPersona2 = 0;
                                objBL_HorarioPersona.ActualizaCerrado(Parametros.intEmpresaId, IdPersona2, true, frmB.dDesde, frmB.dHasta);
                                XtraMessageBox.Show("El Horario se bloqueó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                            Cursor = Cursors.Default;
                            Cargar();
                        }
                        else
                        {
                            Cursor = Cursors.Default;
                            XtraMessageBox.Show("Ud. no tiene los permisos para esta operación", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void desBloquearHorariotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (mListaPersona.Count > 0)
                {
                    frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
                    frmAutoriza.StartPosition = FormStartPosition.CenterParent;
                    frmAutoriza.ShowDialog();

                    if (frmAutoriza.Edita)
                    {
                        HorarioPersonaBL objBL_HorarioPersona = new HorarioPersonaBL();
                        string sApeNom = gvHorarioPersona.GetFocusedRowCellValue("ApeNom").ToString();
                        int IdPersona2 = int.Parse(gvHorarioPersona.GetFocusedRowCellValue("IdPersona").ToString());

                        if (frmAutoriza.Usuario == "master" || frmAutoriza.Usuario == "ltapia" || frmAutoriza.IdPerfil == Parametros.intPerJefeRRHH)
                        {
                            frmBloquearHorario frmB = new frmBloquearHorario();
                            frmB.sApeNom = sApeNom;
                            frmB.sMensaje = "Desbloquear";

                            if (frmB.ShowDialog() == DialogResult.OK)
                            {
                                if (frmB.bTodos) IdPersona2 = 0;
                                objBL_HorarioPersona.ActualizaCerrado(Parametros.intEmpresaId, IdPersona2, false, frmB.dDesde, frmB.dHasta);
                                XtraMessageBox.Show("El Horario se desbloqueó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                            Cursor = Cursors.Default;
                            Cargar();
                        }
                        else
                        {
                            Cursor = Cursors.Default;
                            XtraMessageBox.Show("Ud. no tiene los permisos para esta operación", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gvHorarioPersona_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            IdPersona = Int32.Parse(gvHorarioPersona.GetFocusedRowCellValue("IdPersona").ToString());
            btnBuscar_Click(sender, e);
        }

        private void tlbMenu_Load(object sender, EventArgs e)
        {

        }
    }
}