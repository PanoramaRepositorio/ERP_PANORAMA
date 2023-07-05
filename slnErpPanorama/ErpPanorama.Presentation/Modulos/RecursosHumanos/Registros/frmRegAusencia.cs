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

namespace ErpPanorama.Presentation.Modulos.RecursosHumanos.Registros
{
    public partial class frmRegAusencia : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<AusenciaBE> mLista = new List<AusenciaBE>();
        
        #endregion

        #region "Eventos"

        public frmRegAusencia()
        {
            InitializeComponent();
        }

        private void frmRegAusencia_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            txtPeriodo.EditValue = Parametros.intPeriodo;
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmRegAusenciaEdit objManAusencia = new frmRegAusenciaEdit();
                objManAusencia.lstAusencia = mLista;
                objManAusencia.pOperacion = frmRegAusenciaEdit.Operacion.Nuevo;
                objManAusencia.IdAusencia = 0;
                objManAusencia.StartPosition = FormStartPosition.CenterParent;
                objManAusencia.ShowDialog();
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
                        AusenciaBE objE_Ausencia = new AusenciaBE();
                        objE_Ausencia.IdAusencia = int.Parse(gvAusencia.GetFocusedRowCellValue("IdAusencia").ToString());
                        objE_Ausencia.Usuario = Parametros.strUsuarioLogin;
                        objE_Ausencia.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Ausencia.IdEmpresa = Parametros.intEmpresaId;

                        AusenciaBL objBL_Ausencia = new AusenciaBL();
                        objBL_Ausencia.Elimina(objE_Ausencia);
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

            //   List<ReporteAusenciaBE> lstReporte = null;
            //   lstReporte = new ReporteAusenciaBL().Listado(Parametros.intEmpresaId,Parametros.intSoles);

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptAusencia = new RptVistaReportes();
            //            objRptAusencia.VerRptAusencia(lstReporte);
            //            objRptAusencia.ShowDialog();
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
            string _fileName = "ListadoAusencia";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvAusencia.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvAusencia_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void txtApeNom_EditValueChanged(object sender, EventArgs e)
        {
            CargarBusqueda();
        }
       

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new AusenciaBL().ListaTodosActivo(Convert.ToInt32(txtPeriodo.EditValue));
            gcAusencia.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcAusencia.DataSource = mLista.Where(obj =>
                                                   obj.ApeNom.ToUpper().Contains(txtApeNom.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvAusencia.RowCount > 0)
            {
                AusenciaBE objAusencia = new AusenciaBE();
                objAusencia.IdAusencia = int.Parse(gvAusencia.GetFocusedRowCellValue("IdAusencia").ToString());

                frmRegAusenciaEdit objManAusenciaEdit = new frmRegAusenciaEdit();
                objManAusenciaEdit.pOperacion = frmRegAusenciaEdit.Operacion.Modificar;
                objManAusenciaEdit.IdAusencia = objAusencia.IdAusencia;
                objManAusenciaEdit.StartPosition = FormStartPosition.CenterParent;
                objManAusenciaEdit.ShowDialog();

                int Id = gvAusencia.FocusedRowHandle;
                Cargar();
                gvAusencia.FocusedRowHandle=Id;
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

            if (gvAusencia.GetFocusedRowCellValue("IdAusencia").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Ausencia", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

        private void CambiarRecuperaciontoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gvAusencia.RowCount > 0)
            {
                string Valor = gvAusencia.GetFocusedRowCellValue("AsistenciaRecupera").ToString();
                if (Valor == "FALTÓ")
                {
                    string Dni = gvAusencia.GetRowCellValue(gvAusencia.FocusedRowHandle, "Dni").ToString();
                    string ApeNom = gvAusencia.GetRowCellValue(gvAusencia.FocusedRowHandle, "ApeNom").ToString();
                    DateTime Fecha = DateTime.Parse(gvAusencia.GetRowCellValue(gvAusencia.FocusedRowHandle, "FechaDesde").ToString());
                    Int32 IdPersona = int.Parse(gvAusencia.GetRowCellValue(gvAusencia.FocusedRowHandle, "IdPersona").ToString());
                    Int32 IdAusencia = int.Parse(gvAusencia.GetRowCellValue(gvAusencia.FocusedRowHandle, "IdAusencia").ToString());
  
                    frmAsignarAusencia frm = new frmAsignarAusencia();
                    frm.IdPersona = IdPersona;
                    frm.Periodo = Fecha.Year;
                    frm.Mes = Fecha.Month;
                    frm.Dia = Fecha.Day.ToString();
                    frm.Dni = Dni;
                    frm.ApeNom = ApeNom;
                    frm.Origen = 1;
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        AusenciaBE objE_Ausencia = new AusenciaBE();
                        AusenciaBL objBL_Ausencia = new AusenciaBL();
                        objE_Ausencia.IdAusencia = IdAusencia;
                        objE_Ausencia.IdEmpresa = Parametros.intEmpresaId;
                        objE_Ausencia.Usuario = Parametros.strUsuarioLogin;
                        objE_Ausencia.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objBL_Ausencia.EliminaCalendario(objE_Ausencia);

                        int IdPersonaCalendarioLaboral = 0;
                        PersonaCalendarioLaboralBL objBL_PersonaCalendario = new PersonaCalendarioLaboralBL();
                        PersonaCalendarioLaboralBE objE_PersonaCalendario = new PersonaCalendarioLaboralBE();
                        objE_PersonaCalendario.IdEmpresa = Parametros.intEmpresaId;
                        objE_PersonaCalendario.IdPersonaCalendarioLaboral = 0;
                        objE_PersonaCalendario.IdPersona = IdPersona;
                        objE_PersonaCalendario.Periodo = frm.FechaRecupera.Year;
                        objE_PersonaCalendario.Mes = frm.FechaRecupera.Month;//Mes;
                        objE_PersonaCalendario.Fecha = Convert.ToDateTime(frm.FechaRecupera);
                        objE_PersonaCalendario.FechaInicio = Convert.ToDateTime(frm.FechaRecupera);
                        objE_PersonaCalendario.FechaFin = Convert.ToDateTime(frm.FechaRecupera);
                        objE_PersonaCalendario.IdHorarioTipoIncidencia = 0;
                        objE_PersonaCalendario.Observacion = "GENERADO POR AUSENCIA";
                        objE_PersonaCalendario.FechaOrigen = Fecha;
                        objE_PersonaCalendario.IdMotivoAusencia = 8;
                        objE_PersonaCalendario.Usuario = Parametros.strUsuarioLogin;
                        objE_PersonaCalendario.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_PersonaCalendario.FlagEstado = true;

                        IdPersonaCalendarioLaboral = objBL_PersonaCalendario.Inserta(objE_PersonaCalendario);

                        objBL_Ausencia.ActualizaCalendario(IdAusencia, IdPersonaCalendarioLaboral, "Movido al Día -" + frm.FechaRecupera.ToShortDateString() + " por "  + Parametros.strUsuarioLogin);

                        Cargar();
                    }
                }
                else
                {
                    XtraMessageBox.Show("Sólo puede asignar los Días faltados[F].", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }


            }
        }

       
    }
}